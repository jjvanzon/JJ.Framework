namespace JJ.Utilities.FileDeduplication
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
			this.buttonAnalyze = new System.Windows.Forms.Button();
			this.labelListOfDuplicates = new System.Windows.Forms.Label();
			this.buttonCopyListOfDuplicates = new System.Windows.Forms.Button();
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
			this.buttonAnalyze.Text = "Analyze";
			this.buttonAnalyze.UseVisualStyleBackColor = true;
			this.buttonAnalyze.Click += new System.EventHandler(this.ButtonAnalyze_Click);
			// 
			// labelListOfDuplicates
			// 
			this.labelListOfDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelListOfDuplicates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelListOfDuplicates.Location = new System.Drawing.Point(19, 251);
			this.labelListOfDuplicates.Name = "labelListOfDuplicates";
			this.labelListOfDuplicates.Size = new System.Drawing.Size(603, 181);
			this.labelListOfDuplicates.TabIndex = 4;
			this.labelListOfDuplicates.Text = "List of duplicates may appear here...";
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(638, 611);
			this.Controls.Add(this.buttonCopyListOfDuplicates);
			this.Controls.Add(this.labelListOfDuplicates);
			this.Controls.Add(this.buttonAnalyze);
			this.Controls.Add(this.checkBoxRecursive);
			this.FileBrowseMode = JJ.Framework.WinForms.Helpers.FileBrowseModeEnum.SelectFolder;
			this.Font = new System.Drawing.Font("Calibri", 8.805756F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.TextBoxLabelText = "Folder:";
			this.TextBoxVisible = true;
			this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
			this.Controls.SetChildIndex(this.checkBoxRecursive, 0);
			this.Controls.SetChildIndex(this.buttonAnalyze, 0);
			this.Controls.SetChildIndex(this.labelListOfDuplicates, 0);
			this.Controls.SetChildIndex(this.buttonCopyListOfDuplicates, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxRecursive;
		private System.Windows.Forms.Button buttonAnalyze;
		private System.Windows.Forms.Label labelListOfDuplicates;
		private System.Windows.Forms.Button buttonCopyListOfDuplicates;
	}
}

