namespace JJ.Utilities.FileDeduplication
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
			this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
			this.buttonAnalyze = new System.Windows.Forms.Button();
			this.textBoxListOfDuplicates = new System.Windows.Forms.TextBox();
			this.buttonCopyListOfDuplicates = new System.Windows.Forms.Button();
			this.labelListOfDuplicatesTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// checkBoxRecursive
			// 
			this.checkBoxRecursive.AutoSize = true;
			this.checkBoxRecursive.Checked = true;
			this.checkBoxRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxRecursive.Location = new System.Drawing.Point(19, 147);
			this.checkBoxRecursive.Name = "checkBoxRecursive";
			this.checkBoxRecursive.Size = new System.Drawing.Size(106, 26);
			this.checkBoxRecursive.TabIndex = 1;
			this.checkBoxRecursive.Text = "Recursive";
			this.checkBoxRecursive.UseVisualStyleBackColor = true;
			// 
			// buttonAnalyze
			// 
			this.buttonAnalyze.Location = new System.Drawing.Point(17, 184);
			this.buttonAnalyze.Name = "buttonAnalyze";
			this.buttonAnalyze.Size = new System.Drawing.Size(125, 49);
			this.buttonAnalyze.TabIndex = 2;
			this.buttonAnalyze.Text = "Scan";
			this.buttonAnalyze.UseVisualStyleBackColor = true;
			this.buttonAnalyze.Click += new System.EventHandler(this.ButtonAnalyze_Click);
			// 
			// textBoxListOfDuplicates
			// 
			this.textBoxListOfDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxListOfDuplicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxListOfDuplicates.Location = new System.Drawing.Point(19, 275);
			this.textBoxListOfDuplicates.Multiline = true;
			this.textBoxListOfDuplicates.Name = "textBoxListOfDuplicates";
			this.textBoxListOfDuplicates.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxListOfDuplicates.Size = new System.Drawing.Size(598, 152);
			this.textBoxListOfDuplicates.TabIndex = 4;
			this.textBoxListOfDuplicates.WordWrap = false;
			// 
			// buttonCopyListOfDuplicates
			// 
			this.buttonCopyListOfDuplicates.Location = new System.Drawing.Point(159, 184);
			this.buttonCopyListOfDuplicates.Name = "buttonCopyListOfDuplicates";
			this.buttonCopyListOfDuplicates.Size = new System.Drawing.Size(195, 49);
			this.buttonCopyListOfDuplicates.TabIndex = 5;
			this.buttonCopyListOfDuplicates.Text = "Copy List of Duplicates";
			this.buttonCopyListOfDuplicates.UseVisualStyleBackColor = true;
			this.buttonCopyListOfDuplicates.Click += new System.EventHandler(this.ButtonCopyListOfDuplicates_Click);
			// 
			// labelListOfDuplicatesTitle
			// 
			this.labelListOfDuplicatesTitle.AutoSize = true;
			this.labelListOfDuplicatesTitle.Location = new System.Drawing.Point(15, 250);
			this.labelListOfDuplicatesTitle.Name = "labelListOfDuplicatesTitle";
			this.labelListOfDuplicatesTitle.Size = new System.Drawing.Size(142, 22);
			this.labelListOfDuplicatesTitle.TabIndex = 6;
			this.labelListOfDuplicatesTitle.Text = "List of Duplicates:";
			// 
			// FileDeduplicationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 606);
			this.Controls.Add(this.labelListOfDuplicatesTitle);
			this.Controls.Add(this.buttonCopyListOfDuplicates);
			this.Controls.Add(this.textBoxListOfDuplicates);
			this.Controls.Add(this.buttonAnalyze);
			this.Controls.Add(this.checkBoxRecursive);
			this.FileBrowseMode = JJ.Framework.WinForms.Helpers.FileBrowseModeEnum.SelectFolder;
			this.Font = new System.Drawing.Font("Calibri", 8.805756F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FileDeduplicationForm";
			this.TextBoxLabelText = "Folder:";
			this.TextBoxVisible = true;
			this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
			this.Cancelled += new System.EventHandler(this.MainForm_Cancelled);
			this.Load += new System.EventHandler(this.FileDeduplicationForm_Load);
			this.Controls.SetChildIndex(this.checkBoxRecursive, 0);
			this.Controls.SetChildIndex(this.buttonAnalyze, 0);
			this.Controls.SetChildIndex(this.textBoxListOfDuplicates, 0);
			this.Controls.SetChildIndex(this.buttonCopyListOfDuplicates, 0);
			this.Controls.SetChildIndex(this.labelListOfDuplicatesTitle, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxRecursive;
		private System.Windows.Forms.Button buttonAnalyze;
		private System.Windows.Forms.TextBox textBoxListOfDuplicates;
		private System.Windows.Forms.Button buttonCopyListOfDuplicates;
		private System.Windows.Forms.Label labelListOfDuplicatesTitle;
	}
}

