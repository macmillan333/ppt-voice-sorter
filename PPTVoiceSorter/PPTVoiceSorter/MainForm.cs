using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            worker.RunWorkerAsync();
        }
        #endregion

        #region Sorting process
        private BackgroundWorker worker;
        private string gameFolder;
        private string unxwbPath;
        private string mtxToJsonPath;
        private string destinationFolder;

        private class Progress
        {
            public int itemsComplete;
            public int itemsTotal;
            public string message;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1357; i++)
            {
                Progress progress = new Progress()
                {
                    itemsComplete = i,
                    itemsTotal = 1357,
                    message = $"Processing item {i + 1} of 1357..."
                };
                worker.ReportProgress(0, progress);
                System.Threading.Thread.Sleep(10);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress progress = e.UserState as Progress;
            progressBar.Value = progress.itemsComplete;
            progressBar.Maximum = progress.itemsTotal;
            progressLabel.Text = progress.message;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                progressLabel.Text = "Export failed with error: " + e.Error;
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
