using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPTVoiceSorter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            optimizeForTrainingToolTip.SetToolTip(optimizeForTrainingCheckBox,
                "Adjust the output to be more friendly to speech synthesizers.\n" +
                "* Any line containing sound effects, such as *thinking sounds*, will be removed.\n" +
                "* Spelling of some names will be adjusted to be less ambiguous, such as Amitie --> Amitee.\n");

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        #region Event handlers
        private void gameFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = gameFolderBox.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                gameFolderBox.Text = dialog.SelectedPath;
            }
        }

        private void unxwbBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.FileName = unxwbBox.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                unxwbBox.Text = dialog.FileName;
            }
        }

        private void mtxToJsonBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.FileName = mtxToJsonBox.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                mtxToJsonBox.Text = dialog.FileName;
            }
        }

        private void destinationFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = destinationFolderBox.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                destinationFolderBox.Text = dialog.SelectedPath;
            }
        }

        private void unxwbDownloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenBrowser("http://aluigi.altervista.org/papers/unxwb.zip");
        }

        private void mtxToJsonDownloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenBrowser("https://github.com/nickworonekin/puyo-text-editor/releases");
        }

        public static void OpenBrowser(string url)
        {
            // Process.Start doesn't work as expected on .NET Core.
            // https://github.com/dotnet/runtime/issues/17938
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                Process.Start(url);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy) return;

            startButton.Enabled = false;

            gameFolder = gameFolderBox.Text;
            unxwbPath = unxwbBox.Text;
            mtxToJsonPath = mtxToJsonBox.Text;
            destinationFolder = destinationFolderBox.Text;
            optimizeForTraining = optimizeForTrainingCheckBox.Checked;
            worker.RunWorkerAsync();
        }
        #endregion

        #region Sorting process
        private BackgroundWorker worker;
        private string gameFolder;
        private string unxwbPath;
        private string mtxToJsonPath;
        private string destinationFolder;
        private bool optimizeForTraining;

        private const int totalClips = 3084;
        private const int totalSpeakers = 34;
        private const int totalActionItems = totalClips
            + 1  // For extracting transcripts
            + totalSpeakers 
            + 1;  // For cleaning up

        private struct Progress
        {
            public int itemsComplete;
            public string message;
        }

        // For deserializing JSON extracted from game.
        private class Transcript
        {
            public bool Has64BitOffsets { get; set; }
            public List<List<string>> Entries { get; set; }
        }

        private class Speaker
        {
            public List<string> clipPaths = new List<string>();
            public List<string> lines = new List<string>();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Adventure mode's sound banks are located at:
            // PuyoPuyoTetris\data_stream\data\sound\manzai\manzai_xxyyzz_e.xwb
            // xxyyzz can be 6 digits, or "opening", or "ending".
            //
            // Transcripts are located at:
            // PuyoPuyoTetris\data_steam\data\tenp\text\adventure\chapterxxEnglish.mtx
            //                                                   \generalEnglish.mtx

            // Step 1: Extract voice clips. Also collect extracted file names in order.
            List<string> xwbPaths = new List<string>();
            List<string> clipPaths = new List<string>();
            try
            {
                // Collect xwbFiles in a very specific order: opening, acts 1~7, ending, acts 8~10.
                string xwbFolder = gameFolder + @"\data_steam\data\sound\manzai";

                xwbPaths.Add(xwbFolder + @"\manzai_opening_e.xwb");
                for (int act = 1; act <= 7; act++)
                {
                    xwbPaths.AddRange(Directory.GetFiles(xwbFolder, $"manzai_{act:D2}????_e.xwb"));
                }
                xwbPaths.Add(xwbFolder + @"\manzai_ending_e.xwb");
                for (int act = 8; act <= 10; act++)
                {
                    xwbPaths.AddRange(Directory.GetFiles(xwbFolder, $"manzai_{act:D2}????_e.xwb"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred when looking for XWB files in the game folder.", ex);
            }

            Progress progress = new Progress()
            {
                itemsComplete = 0
            };
            foreach (string path in xwbPaths)
            {
                string[] splits = path.Split('\\');
                progress.message = $"Extracting voice clips from {splits[^1]} ({progress.itemsComplete} / {totalClips})...";
                worker.ReportProgress(0, progress);

                string basename = splits[^1].Split('.')[0];
                string outFolder = destinationFolder + $@"\{basename}";
                Directory.CreateDirectory(outFolder);

                Process p = new Process();
                p.StartInfo.FileName = unxwbPath;
                p.StartInfo.Arguments = $@"-D -d ""{outFolder}"" ""{path}""";
                p.StartInfo.CreateNoWindow = true;
                try
                {
                    p.Start();
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred when running unxwb.", ex);
                }
                p.WaitForExit();

                int numClips = Directory.GetFiles(outFolder).Length;
                progress.itemsComplete += numClips;

                // We can't just copy Directory.GetFiles(outDir) into clipPaths because the
                // former is in lexicographical order (0, 1, 10, 11, 12, ...) which is not
                // the order we want (0, 1, 2, 3, ...).
                for (int i = 0; i < numClips; i++)
                {
                    clipPaths.Add(outFolder + $@"\{i}.wav");
                }
            }
            // Due to what I assume is the developers' oversight, destinationFolder\manzai_070101_e
            // contains 40 files when that scene only has 39 lines. The extra file, 39.wav,
            // is unused, and its content is the same as destinationFolder\manzai_070102_e\0.wav.
            clipPaths.Remove(destinationFolder + @"\manzai_070101_e\39.wav");

            // Step 2: Extract transcripts.
            List<string> mtxBasenames = new List<string>();
            List<string> transcriptPaths = new List<string>();
            string generalTranscriptPath;

            for (int i = 1; i <= 10; i++)
            {
                string basename = $"chapter{i:D2}English";
                mtxBasenames.Add(basename);
                transcriptPaths.Add(destinationFolder + $@"\{basename}.json");
            }
            const string generalBasename = "generalEnglish";
            mtxBasenames.Add(generalBasename);
            generalTranscriptPath = destinationFolder + $@"\{generalBasename}.json";

            progress.itemsComplete = totalClips;
            progress.message = $"Extracting transcripts...";
            worker.ReportProgress(0, progress);

            foreach (string basename in mtxBasenames)
            {
                string inPath = gameFolder + $@"\data_steam\data\tenp\text\adventure\{basename}.mtx";
                string outPath = destinationFolder + $@"\{basename}.json";

                Process p = new Process();
                p.StartInfo.FileName = mtxToJsonPath;
                p.StartInfo.Arguments = $@"-o ""{outPath}"" ""{inPath}""";
                p.StartInfo.CreateNoWindow = true;
                try
                {
                    p.Start();
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred when running MtxToJson.", ex);
                }
                p.WaitForExit();
            }

            // Step 3: Load transcripts into memory, again in a very specific order.
            List<string> lines = new List<string>();
            Transcript generalTranscript = LoadTranscript(generalTranscriptPath);
            lines.AddRange(generalTranscript.Entries[0]);  // Opening
            
            for (int act = 1; act <= 7; act++)
            {
                Transcript transcript = LoadTranscript(transcriptPaths[act - 1]);
                foreach (List<string> scene in transcript.Entries)
                {
                    lines.AddRange(scene);
                }
            }

            lines.AddRange(generalTranscript.Entries[1]);  // Ending

            for (int act = 8; act <= 10; act++)
            {
                Transcript transcript = LoadTranscript(transcriptPaths[act - 1]);
                foreach (List<string> scene in transcript.Entries)
                {
                    lines.AddRange(scene);
                }
            }

            // Step 4: Load speaker list.
            List<string> nameList = System.Text.Json.JsonSerializer.Deserialize<List<string>>(
                Properties.Resources.names);
            Dictionary<string, Speaker> speakers = new Dictionary<string, Speaker>();
            for (int i = 0; i < nameList.Count; i++)
            {
                string name = nameList[i];
                if (!speakers.ContainsKey(name))
                {
                    speakers.Add(name, new Speaker());
                }
                Speaker speaker = speakers[name];

                speaker.clipPaths.Add(clipPaths[i]);
                speaker.lines.Add(lines[i]);
            }

            // Step 5: Sort clips and export transcripts.
            for (int i = 0; i < speakers.Count; i++)
            {
                string name = speakers.ElementAt(i).Key;
                Speaker speaker = speakers.ElementAt(i).Value;

                progress.itemsComplete = totalClips + 1 + i;
                progress.message = $"Writing clips and transcript for {name} ({i + 1}/{speakers.Count})...";
                worker.ReportProgress(0, progress);

                string outFolder = destinationFolder + $@"\{name}";
                Directory.CreateDirectory(outFolder);

                StringBuilder transcript = new StringBuilder();
                for (int line = 0; line < speaker.lines.Count; line++)
                {
                    if (optimizeForTraining && ContainsSoundEffects(speaker.lines[line]))
                    {
                        continue;
                    }

                    string basename = (line + 1).ToString("D9");
                    string outClipPath = outFolder + $@"\{basename}.wav";
                    File.Move(speaker.clipPaths[line], outClipPath);

                    string processedLine = PostProcess(speaker.lines[line]);
                    transcript.AppendLine($"{basename}\t{processedLine}");
                }

                string transcriptPath = outFolder + @"\transcript.txt";
                File.WriteAllText(transcriptPath, transcript.ToString());
            }

            // Step 6: Clean up.
            progress.itemsComplete = totalActionItems - 1;
            progress.message = "Cleaning up...";
            worker.ReportProgress(0, progress);

            foreach (string folder in Directory.GetDirectories(destinationFolder, "manzai*"))
            {
                Directory.Delete(folder, recursive: true);
            }
            foreach (string path in Directory.GetFiles(destinationFolder, "*.json"))
            {
                File.Delete(path);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress progress = (Progress)e.UserState;
            progressBar.Value = progress.itemsComplete;
            progressBar.Maximum = totalActionItems;
            progressLabel.Text = progress.message;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
                progressLabel.Text = "Failed.";
            }
            else
            {
                progressLabel.Text = "Done.";
                // TODO: Open destination folder
            }
            progressBar.Value = 0;
            startButton.Enabled = true;
        }

        private Transcript LoadTranscript(string path)
        {
            string jsonString = File.ReadAllText(path);
            Transcript t = System.Text.Json.JsonSerializer.Deserialize<Transcript>(jsonString);
            // Each scene ends with an unused line "W". Remove them.
            foreach (List<string> scene in t.Entries)
            {
                scene.RemoveAt(scene.Count - 1);

                // Preprocess lines to remove "\n" and "{arrow}".
                for (int i = 0; i < scene.Count; i++)
                {
                    scene[i] = PreProcess(scene[i]);
                }
            }
            return t;
        }

        private string PreProcess(string line)
        {
            return line.Replace("\n", " ").Replace("  ", " ").Replace("{arrow}", "");
        }

        private bool ContainsSoundEffects(string line)
        {
            return line.Contains('*');
        }

        private string PostProcess(string line)
        {
            if (optimizeForTraining)
            {
                return line.Replace("Amitie", "Amitee")
                .Replace("Ecolo", "Ehcolo")
                .Replace("Klug", "Kloog")
                .Replace("Rulue", "Rooloo")
                .Replace("Maguro", "Mahguro")
                .Replace("Raffina", "Raffeena")
                .Replace("Schezo", "Shezo")
                .Replace("Suketoudara", "Sukehtohdara")
                .Replace("Ai", "I")
                .Replace("Lidelle", "Leedelle")
                .Replace("Rei", "Ray")
                .Replace("Tetrimino", "Tetremiino");
            }
            else
            {
                return line;
            }
        }
        #endregion
    }
}
