namespace PPTVoiceSorter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.label5 = new System.Windows.Forms.Label();
            this.optimizeForTrainingCheckBox = new System.Windows.Forms.CheckBox();
            this.optimizeForTrainingToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Locate Puyo Puyo Tetris folder. It\'s usually <Steam>\\steamapps\\common\\PuyoPuyo" +
    "Tetris.";
            // 
            // gameFolderBox
            // 
            this.gameFolderBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolderBox.Location = new System.Drawing.Point(25, 25);
            this.gameFolderBox.Margin = new System.Windows.Forms.Padding(2);
            this.gameFolderBox.Name = "gameFolderBox";
            this.gameFolderBox.Size = new System.Drawing.Size(300, 23);
            this.gameFolderBox.TabIndex = 1;
            // 
            // gameFolderBrowseButton
            // 
            this.gameFolderBrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolderBrowseButton.Location = new System.Drawing.Point(330, 25);
            this.gameFolderBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.gameFolderBrowseButton.Name = "gameFolderBrowseButton";
            this.gameFolderBrowseButton.Size = new System.Drawing.Size(80, 23);
            this.gameFolderBrowseButton.TabIndex = 2;
            this.gameFolderBrowseButton.Text = "Browse...";
            this.gameFolderBrowseButton.UseVisualStyleBackColor = true;
            this.gameFolderBrowseButton.Click += new System.EventHandler(this.gameFolderBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "2. Locate unxwb.exe.";
            // 
            // unxwbBox
            // 
            this.unxwbBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unxwbBox.Location = new System.Drawing.Point(25, 67);
            this.unxwbBox.Margin = new System.Windows.Forms.Padding(2);
            this.unxwbBox.Name = "unxwbBox";
            this.unxwbBox.Size = new System.Drawing.Size(301, 23);
            this.unxwbBox.TabIndex = 4;
            // 
            // unxwbBrowseButton
            // 
            this.unxwbBrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unxwbBrowseButton.Location = new System.Drawing.Point(330, 67);
            this.unxwbBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.unxwbBrowseButton.Name = "unxwbBrowseButton";
            this.unxwbBrowseButton.Size = new System.Drawing.Size(80, 23);
            this.unxwbBrowseButton.TabIndex = 5;
            this.unxwbBrowseButton.Text = "Browse...";
            this.unxwbBrowseButton.UseVisualStyleBackColor = true;
            this.unxwbBrowseButton.Click += new System.EventHandler(this.unxwbBrowseButton_Click);
            // 
            // unxwbDownloadLink
            // 
            this.unxwbDownloadLink.AutoSize = true;
            this.unxwbDownloadLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unxwbDownloadLink.Location = new System.Drawing.Point(131, 50);
            this.unxwbDownloadLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unxwbDownloadLink.Name = "unxwbDownloadLink";
            this.unxwbDownloadLink.Size = new System.Drawing.Size(100, 15);
            this.unxwbDownloadLink.TabIndex = 3;
            this.unxwbDownloadLink.TabStop = true;
            this.unxwbDownloadLink.Text = "Download it here.";
            this.unxwbDownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.unxwbDownloadLink_LinkClicked);
            // 
            // mtxToJsonDownloadLink
            // 
            this.mtxToJsonDownloadLink.AutoSize = true;
            this.mtxToJsonDownloadLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxToJsonDownloadLink.Location = new System.Drawing.Point(271, 92);
            this.mtxToJsonDownloadLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mtxToJsonDownloadLink.Name = "mtxToJsonDownloadLink";
            this.mtxToJsonDownloadLink.Size = new System.Drawing.Size(100, 15);
            this.mtxToJsonDownloadLink.TabIndex = 6;
            this.mtxToJsonDownloadLink.TabStop = true;
            this.mtxToJsonDownloadLink.Text = "Download it here.";
            this.mtxToJsonDownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mtxToJsonDownloadLink_LinkClicked);
            // 
            // mtxToJsonBrowseButton
            // 
            this.mtxToJsonBrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxToJsonBrowseButton.Location = new System.Drawing.Point(330, 109);
            this.mtxToJsonBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.mtxToJsonBrowseButton.Name = "mtxToJsonBrowseButton";
            this.mtxToJsonBrowseButton.Size = new System.Drawing.Size(80, 23);
            this.mtxToJsonBrowseButton.TabIndex = 8;
            this.mtxToJsonBrowseButton.Text = "Browse...";
            this.mtxToJsonBrowseButton.UseVisualStyleBackColor = true;
            this.mtxToJsonBrowseButton.Click += new System.EventHandler(this.mtxToJsonBrowseButton_Click);
            // 
            // mtxToJsonBox
            // 
            this.mtxToJsonBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxToJsonBox.Location = new System.Drawing.Point(25, 109);
            this.mtxToJsonBox.Margin = new System.Windows.Forms.Padding(2);
            this.mtxToJsonBox.Name = "mtxToJsonBox";
            this.mtxToJsonBox.Size = new System.Drawing.Size(301, 23);
            this.mtxToJsonBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "3. Locate MtxToJson.exe from Puyo Text Editor.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(418, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "4. Pick destination folder. Sorted voice clips and transcripts will be stored her" +
    "e.";
            // 
            // destinationFolderBox
            // 
            this.destinationFolderBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationFolderBox.Location = new System.Drawing.Point(25, 151);
            this.destinationFolderBox.Margin = new System.Windows.Forms.Padding(2);
            this.destinationFolderBox.Name = "destinationFolderBox";
            this.destinationFolderBox.Size = new System.Drawing.Size(301, 23);
            this.destinationFolderBox.TabIndex = 9;
            // 
            // destinationFolderBrowseButton
            // 
            this.destinationFolderBrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationFolderBrowseButton.Location = new System.Drawing.Point(330, 151);
            this.destinationFolderBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.destinationFolderBrowseButton.Name = "destinationFolderBrowseButton";
            this.destinationFolderBrowseButton.Size = new System.Drawing.Size(80, 23);
            this.destinationFolderBrowseButton.TabIndex = 10;
            this.destinationFolderBrowseButton.Text = "Browse...";
            this.destinationFolderBrowseButton.UseVisualStyleBackColor = true;
            this.destinationFolderBrowseButton.Click += new System.EventHandler(this.destinationFolderBrowseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(16, 242);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(100, 242);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(310, 23);
            this.progressBar.TabIndex = 5;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(97, 267);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(46, 15);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "(status)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 176);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Options (mouse over for explanation):";
            // 
            // optimizeForTrainingCheckBox
            // 
            this.optimizeForTrainingCheckBox.AutoSize = true;
            this.optimizeForTrainingCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optimizeForTrainingCheckBox.Location = new System.Drawing.Point(25, 193);
            this.optimizeForTrainingCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.optimizeForTrainingCheckBox.Name = "optimizeForTrainingCheckBox";
            this.optimizeForTrainingCheckBox.Size = new System.Drawing.Size(237, 19);
            this.optimizeForTrainingCheckBox.TabIndex = 12;
            this.optimizeForTrainingCheckBox.Text = "Optimize for speech synthesizer training";
            this.optimizeForTrainingCheckBox.UseVisualStyleBackColor = true;
            // 
            // optimizeForTrainingToolTip
            // 
            this.optimizeForTrainingToolTip.AutoPopDelay = 20000;
            this.optimizeForTrainingToolTip.InitialDelay = 500;
            this.optimizeForTrainingToolTip.ReshowDelay = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 303);
            this.Controls.Add(this.optimizeForTrainingCheckBox);
            this.Controls.Add(this.label5);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox optimizeForTrainingCheckBox;
        private System.Windows.Forms.ToolTip optimizeForTrainingToolTip;
    }
}

