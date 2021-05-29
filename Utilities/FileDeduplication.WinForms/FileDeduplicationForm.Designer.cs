namespace JJ.Utilities.FileDeduplication.WinForms
{
    partial class FileDeduplicationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileDeduplicationForm));
            this.checkBoxAlsoScanSubFolders = new System.Windows.Forms.CheckBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.textBoxListOfDuplicates = new System.Windows.Forms.TextBox();
            this.buttonCopyListOfDuplicates = new System.Windows.Forms.Button();
            this.labelListOfDuplicatesTitle = new System.Windows.Forms.Label();
            this.labelFilePattern = new System.Windows.Forms.Label();
            this.textBoxFilePattern = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxAlsoScanSubFolders
            // 
            this.checkBoxAlsoScanSubFolders.Checked = true;
            this.checkBoxAlsoScanSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlsoScanSubFolders.Location = new System.Drawing.Point(19, 190);
            this.checkBoxAlsoScanSubFolders.Name = "checkBoxAlsoScanSubFolders";
            this.checkBoxAlsoScanSubFolders.Size = new System.Drawing.Size(245, 26);
            this.checkBoxAlsoScanSubFolders.TabIndex = 1;
            this.checkBoxAlsoScanSubFolders.Text = "checkBoxAlsoScanSubFolders";
            this.checkBoxAlsoScanSubFolders.UseVisualStyleBackColor = true;
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(17, 230);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(125, 49);
            this.buttonScan.TabIndex = 2;
            this.buttonScan.Text = "buttonScan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.ButtonScan_Click);
            // 
            // textBoxListOfDuplicates
            // 
            this.textBoxListOfDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxListOfDuplicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxListOfDuplicates.Location = new System.Drawing.Point(17, 321);
            this.textBoxListOfDuplicates.MaxLength = 0;
            this.textBoxListOfDuplicates.Multiline = true;
            this.textBoxListOfDuplicates.Name = "textBoxListOfDuplicates";
            this.textBoxListOfDuplicates.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxListOfDuplicates.Size = new System.Drawing.Size(694, 210);
            this.textBoxListOfDuplicates.TabIndex = 4;
            this.textBoxListOfDuplicates.WordWrap = false;
            // 
            // buttonCopyListOfDuplicates
            // 
            this.buttonCopyListOfDuplicates.Location = new System.Drawing.Point(159, 230);
            this.buttonCopyListOfDuplicates.Name = "buttonCopyListOfDuplicates";
            this.buttonCopyListOfDuplicates.Size = new System.Drawing.Size(219, 49);
            this.buttonCopyListOfDuplicates.TabIndex = 5;
            this.buttonCopyListOfDuplicates.Text = "buttonCopyListOfDuplicates";
            this.buttonCopyListOfDuplicates.UseVisualStyleBackColor = true;
            this.buttonCopyListOfDuplicates.Click += new System.EventHandler(this.ButtonCopyListOfDuplicates_Click);
            // 
            // labelListOfDuplicatesTitle
            // 
            this.labelListOfDuplicatesTitle.AutoSize = true;
            this.labelListOfDuplicatesTitle.Location = new System.Drawing.Point(15, 296);
            this.labelListOfDuplicatesTitle.Name = "labelListOfDuplicatesTitle";
            this.labelListOfDuplicatesTitle.Size = new System.Drawing.Size(199, 22);
            this.labelListOfDuplicatesTitle.TabIndex = 6;
            this.labelListOfDuplicatesTitle.Text = "labelListOfDuplicatesTitle";
            // 
            // labelFilePattern
            // 
            this.labelFilePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFilePattern.Location = new System.Drawing.Point(433, 193);
            this.labelFilePattern.Name = "labelFilePattern";
            this.labelFilePattern.Size = new System.Drawing.Size(200, 24);
            this.labelFilePattern.TabIndex = 7;
            this.labelFilePattern.Text = "labelFilePattern";
            this.labelFilePattern.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxFilePattern
            // 
            this.textBoxFilePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePattern.Location = new System.Drawing.Point(639, 189);
            this.textBoxFilePattern.Name = "textBoxFilePattern";
            this.textBoxFilePattern.Size = new System.Drawing.Size(72, 29);
            this.textBoxFilePattern.TabIndex = 8;
            this.textBoxFilePattern.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileDeduplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 673);
            this.Controls.Add(this.textBoxFilePattern);
            this.Controls.Add(this.labelFilePattern);
            this.Controls.Add(this.labelListOfDuplicatesTitle);
            this.Controls.Add(this.buttonCopyListOfDuplicates);
            this.Controls.Add(this.textBoxListOfDuplicates);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.checkBoxAlsoScanSubFolders);
            this.Description = resources.GetString("$this.Description");
            this.FileBrowseMode = JJ.Framework.WinForms.Helpers.FileBrowseModeEnum.SelectFolder;
            this.Font = new System.Drawing.Font("Calibri", 8.805756F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileDeduplicationForm";
            this.StartButtonText = "Delete";
            this.TextBoxLabelText = "Folder:";
            this.TextBoxOrientation = JJ.Framework.WinForms.Helpers.UpDownOrientationEnum.Up;
            this.TextBoxRightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
            this.Cancelled += new System.EventHandler(this.MainForm_Cancelled);
            this.Load += new System.EventHandler(this.FileDeduplicationForm_Load);
            this.Controls.SetChildIndex(this.checkBoxAlsoScanSubFolders, 0);
            this.Controls.SetChildIndex(this.buttonScan, 0);
            this.Controls.SetChildIndex(this.textBoxListOfDuplicates, 0);
            this.Controls.SetChildIndex(this.buttonCopyListOfDuplicates, 0);
            this.Controls.SetChildIndex(this.labelListOfDuplicatesTitle, 0);
            this.Controls.SetChildIndex(this.labelFilePattern, 0);
            this.Controls.SetChildIndex(this.textBoxFilePattern, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAlsoScanSubFolders;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.TextBox textBoxListOfDuplicates;
        private System.Windows.Forms.Button buttonCopyListOfDuplicates;
        private System.Windows.Forms.Label labelListOfDuplicatesTitle;
        private System.Windows.Forms.Label labelFilePattern;
        private System.Windows.Forms.TextBox textBoxFilePattern;
    }
}

