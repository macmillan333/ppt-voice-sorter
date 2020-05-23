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
            worker.RunWorkerAsync();
        }
        #endregion

        #region Sorting process
        private BackgroundWorker worker;
        private string gameFolder;
        private string unxwbPath;
        private string mtxToJsonPath;
        private string destinationFolder;

        private const int totalClips = 3084;
        private const int totalTranscriptFiles = 11;
        private const int totalSpeakers = 34;
        private const int totalActionItems = totalClips + totalTranscriptFiles + totalSpeakers;

        private struct Progress
        {
            public int itemsComplete;
            public string message;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Adventure mode's sound banks are located at:
            // PuyoPuyoTetris\data_stream\data\sound\manzai\manzai_xxyyzz_e.xwb
            // xxyyzz can be 6 digits, "opening" or "ending".
            //
            // Transcripts are located at:
            // PuyoPuyoTetris\data_steam\data\tenp\text\adventure\chapterxxEnglish.mtx
            //                                                   \generalEnglish.mtx
            //
            // Action items:
            // * Extract voice clips (3,084)
            // * Extract transcript (11)
            // * Sort clips and transcript (34)

            // Step 1: Extract voice clips.
            string[] xwbFiles;
            try
            {
                xwbFiles = Directory.GetFiles(gameFolder + @"\data_steam\data\sound\manzai", "manzai_*_e.xwb");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred when looking for XWB files in the game folder.", ex);
            }

            Progress progress = new Progress()
            {
                itemsComplete = 0
            };
            foreach (string path in xwbFiles)
            {
                string[] splits = path.Split('\\');
                progress.message = $"Extracting voice clips from {splits[^1]} ({progress.itemsComplete} / {totalClips})...";
                worker.ReportProgress(0, progress);

                string basename = splits[^1].Split('.')[0];
                string outDir = destinationFolder + $@"\{basename}";
                Directory.CreateDirectory(outDir);

                Process p = new Process();
                p.StartInfo.FileName = unxwbPath;
                p.StartInfo.Arguments = $@"-D -d ""{outDir}"" ""{path}""";
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

                progress.itemsComplete += Directory.GetFiles(outDir).Length;
            }

            // Step 2: Extract transcripts.
            List<string> mtxPartialBasenames = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                mtxPartialBasenames.Add($"chapter{i:D2}");
            }
            mtxPartialBasenames.Add("general");

            int transcriptsExtracted = 0;
            foreach (string mtxPartialBasename in mtxPartialBasenames)
            {
                string basename = mtxPartialBasename + "English";

                progress.itemsComplete = totalClips + transcriptsExtracted;
                progress.message = $"Extracting transcript from {basename}.mtx ({transcriptsExtracted} / {totalTranscriptFiles})...";
                worker.ReportProgress(0, progress);

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
        #endregion
    }
}
