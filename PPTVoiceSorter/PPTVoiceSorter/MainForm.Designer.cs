namespace PPTVoiceSorter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gameFolderBox = new System.Windows.Forms.TextBox();
            this.gameFolderBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.unxwbBox = new System.Windows.Forms.TextBox();
            this.unxwbBrowseButton = new System.Windows.Forms.Button();
            this.unxwbDownloadLink = new System.Windows.Forms.LinkLabel();
            this.mtxToJsonDownloadLink = new System.Windows.Forms.LinkLabel();
            this.mtxToJsonBrowseButton = new System.Windows.Forms.Button();
            this.mtxToJsonBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.destinationFolderBox = new System.Windows.Forms.TextBox();
            this.destinationFolderBrowseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Locate Puyo Puyo Tetris folder. It\'s usually <Steam>\\steamapps\\common\\PuyoPuyo" +
    "Tetris.";
            // 
            // gameFolderBox
            // 
            this.gameFolderBox.Location = new System.Drawing.Point(30, 36);
            this.gameFolderBox.Name = "gameFolderBox";
            this.gameFolderBox.Size = new System.Drawing.Size(400, 27);
            this.gameFolderBox.TabIndex = 1;
            // 
            // gameFolderBrowseButton
            // 
            this.gameFolderBrowseButton.Location = new System.Drawing.Point(436, 35);
            this.gameFolderBrowseButton.Name = "gameFolderBrowseButton";
            this.gameFolderBrowseButton.Size = new System.Drawing.Size(94, 29);
            this.gameFolderBrowseButton.TabIndex = 2;
            this.gameFolderBrowseButton.Text = "Browse...";
            this.gameFolderBrowseButton.UseVisualStyleBackColor = true;
            this.gameFolderBrowseButton.Click += new System.EventHandler(this.gameFolderBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "2. Locate unxwb.exe.";
            // 
            // unxwbBox
            // 
            this.unxwbBox.Location = new System.Drawing.Point(30, 90);
            this.unxwbBox.Name = "unxwbBox";
            this.unxwbBox.Size = new System.Drawing.Size(400, 27);
            this.unxwbBox.TabIndex = 4;
            // 
            // unxwbBrowseButton
            // 
            this.unxwbBrowseButton.Location = new System.Drawing.Point(436, 89);
            this.unxwbBrowseButton.Name = "unxwbBrowseButton";
            this.unxwbBrowseButton.Size = new System.Drawing.Size(94, 29);
            this.unxwbBrowseButton.TabIndex = 5;
            this.unxwbBrowseButton.Text = "Browse...";
            this.unxwbBrowseButton.UseVisualStyleBackColor = true;
            this.unxwbBrowseButton.Click += new System.EventHandler(this.unxwbBrowseButton_Click);
            // 
            // unxwbDownloadLink
            // 
            this.unxwbDownloadLink.AutoSize = true;
            this.unxwbDownloadLink.Location = new System.Drawing.Point(163, 67);
            this.unxwbDownloadLink.Name = "unxwbDownloadLink";
            this.unxwbDownloadLink.Size = new System.Drawing.Size(127, 20);
            this.unxwbDownloadLink.TabIndex = 3;
            this.unxwbDownloadLink.TabStop = true;
            this.unxwbDownloadLink.Text = "Download it here.";
            this.unxwbDownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.unxwbDownloadLink_LinkClicked);
            // 
            // mtxToJsonDownloadLink
            // 
            this.mtxToJsonDownloadLink.AutoSize = true;
            this.mtxToJsonDownloadLink.Location = new System.Drawing.Point(189, 120);
            this.mtxToJsonDownloadLink.Name = "mtxToJsonDownloadLink";
            this.mtxToJsonDownloadLink.Size = new System.Drawing.Size(127, 20);
            this.mtxToJsonDownloadLink.TabIndex = 6;
            this.mtxToJsonDownloadLink.TabStop = true;
            this.mtxToJsonDownloadLink.Text = "Download it here.";
            this.mtxToJsonDownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mtxToJsonDownloadLink_LinkClicked);
            // 
            // mtxToJsonBrowseButton
            // 
            this.mtxToJsonBrowseButton.Location = new System.Drawing.Point(436, 142);
            this.mtxToJsonBrowseButton.Name = "mtxToJsonBrowseButton";
            this.mtxToJsonBrowseButton.Size = new System.Drawing.Size(94, 29);
            this.mtxToJsonBrowseButton.TabIndex = 8;
            this.mtxToJsonBrowseButton.Text = "Browse...";
            this.mtxToJsonBrowseButton.UseVisualStyleBackColor = true;
            this.mtxToJsonBrowseButton.Click += new System.EventHandler(this.mtxToJsonBrowseButton_Click);
            // 
            // mtxToJsonBox
            // 
            this.mtxToJsonBox.Location = new System.Drawing.Point(30, 143);
            this.mtxToJsonBox.Name = "mtxToJsonBox";
            this.mtxToJsonBox.Size = new System.Drawing.Size(400, 27);
            this.mtxToJsonBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "3. Locate MtxToJson.exe.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(426, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "4. Pick destination folder. Sorted voice clips will be stored here.";
            // 
            // destinationFolderBox
            // 
            this.destinationFolderBox.Location = new System.Drawing.Point(30, 196);
            this.destinationFolderBox.Name = "destinationFolderBox";
            this.destinationFolderBox.Size = new System.Drawing.Size(400, 27);
            this.destinationFolderBox.TabIndex = 9;
            // 
            // destinationFolderBrowseButton
            // 
            this.destinationFolderBrowseButton.Location = new System.Drawing.Point(436, 195);
            this.destinationFolderBrowseButton.Name = "destinationFolderBrowseButton";
            this.destinationFolderBrowseButton.Size = new System.Drawing.Size(94, 29);
            this.destinationFolderBrowseButton.TabIndex = 10;
            this.destinationFolderBrowseButton.Text = "Browse...";
            this.destinationFolderBrowseButton.UseVisualStyleBackColor = true;
            this.destinationFolderBrowseButton.Click += new System.EventHandler(this.destinationFolderBrowseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 279);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 29);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(113, 279);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(417, 29);
            this.progressBar.TabIndex = 5;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(113, 315);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 20);
            this.progressLabel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 355);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.destinationFolderBrowseButton);
            this.Controls.Add(this.destinationFolderBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtxToJsonBox);
            this.Controls.Add(this.mtxToJsonBrowseButton);
            this.Controls.Add(this.mtxToJsonDownloadLink);
            this.Controls.Add(this.unxwbDownloadLink);
            this.Controls.Add(this.unxwbBrowseButton);
            this.Controls.Add(this.unxwbBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gameFolderBrowseButton);
            this.Controls.Add(this.gameFolderBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "PPT Voice Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gameFolderBox;
        private System.Windows.Forms.Button gameFolderBrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unxwbBox;
        private System.Windows.Forms.Button unxwbBrowseButton;
        private System.Windows.Forms.LinkLabel unxwbDownloadLink;
        private System.Windows.Forms.LinkLabel mtxToJsonDownloadLink;
        private System.Windows.Forms.Button mtxToJsonBrowseButton;
        private System.Windows.Forms.TextBox mtxToJsonBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox destinationFolderBox;
        private System.Windows.Forms.Button destinationFolderBrowseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
    }
}

