
namespace JJ.Utilities.FileNameFilter.WinForms
{
	partial class FileNameFilterForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileNameFilterForm));
			this.textBoxInputList = new System.Windows.Forms.TextBox();
			this.textBoxFileNamesToKeep = new System.Windows.Forms.TextBox();
			this.textBoxOutputList = new System.Windows.Forms.TextBox();
			this.labelOutputList = new System.Windows.Forms.Label();
			this.labelFileNamesToKeep = new System.Windows.Forms.Label();
			this.labelInputList = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxInputList
			// 
			this.textBoxInputList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxInputList.Location = new System.Drawing.Point(250, 150);
			this.textBoxInputList.MaxLength = 0;
			this.textBoxInputList.Multiline = true;
			this.textBoxInputList.Name = "textBoxInputList";
			this.textBoxInputList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxInputList.Size = new System.Drawing.Size(290, 90);
			this.textBoxInputList.TabIndex = 5;
			this.textBoxInputList.WordWrap = false;
			// 
			// textBoxFileNamesToKeep
			// 
			this.textBoxFileNamesToKeep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxFileNamesToKeep.Location = new System.Drawing.Point(132, 168);
			this.textBoxFileNamesToKeep.MaxLength = 0;
			this.textBoxFileNamesToKeep.Multiline = true;
			this.textBoxFileNamesToKeep.Name = "textBoxFileNamesToKeep";
			this.textBoxFileNamesToKeep.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxFileNamesToKeep.Size = new System.Drawing.Size(365, 92);
			this.textBoxFileNamesToKeep.TabIndex = 6;
			this.textBoxFileNamesToKeep.WordWrap = false;
			// 
			// textBoxOutputList
			// 
			this.textBoxOutputList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxOutputList.Location = new System.Drawing.Point(20, 266);
			this.textBoxOutputList.MaxLength = 0;
			this.textBoxOutputList.Multiline = true;
			this.textBoxOutputList.Name = "textBoxOutputList";
			this.textBoxOutputList.ReadOnly = true;
			this.textBoxOutputList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxOutputList.Size = new System.Drawing.Size(394, 49);
			this.textBoxOutputList.TabIndex = 7;
			this.textBoxOutputList.WordWrap = false;
			// 
			// labelOutputList
			// 
			this.labelOutputList.AutoSize = true;
			this.labelOutputList.Location = new System.Drawing.Point(34, 615);
			this.labelOutputList.Name = "labelOutputList";
			this.labelOutputList.Size = new System.Drawing.Size(125, 22);
			this.labelOutputList.TabIndex = 9;
			this.labelOutputList.Text = "labelOutputList";
			// 
			// labelFileNamesToKeep
			// 
			this.labelFileNamesToKeep.AutoSize = true;
			this.labelFileNamesToKeep.Location = new System.Drawing.Point(23, 233);
			this.labelFileNamesToKeep.Name = "labelFileNamesToKeep";
			this.labelFileNamesToKeep.Size = new System.Drawing.Size(178, 22);
			this.labelFileNamesToKeep.TabIndex = 10;
			this.labelFileNamesToKeep.Text = "labelFileNamesToKeep";
			// 
			// labelInputList
			// 
			this.labelInputList.AutoSize = true;
			this.labelInputList.Location = new System.Drawing.Point(12, 152);
			this.labelInputList.Name = "labelInputList";
			this.labelInputList.Size = new System.Drawing.Size(112, 22);
			this.labelInputList.TabIndex = 11;
			this.labelInputList.Text = "labelInputList";
			// 
			// FileNameFilterForm
			// 
			this.AreYouSureQuestion = "";
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BrowseButtonEnabled = false;
			this.CancelButtonVisible = false;
			this.ClientSize = new System.Drawing.Size(495, 427);
			this.Controls.Add(this.labelInputList);
			this.Controls.Add(this.labelFileNamesToKeep);
			this.Controls.Add(this.labelOutputList);
			this.Controls.Add(this.textBoxOutputList);
			this.Controls.Add(this.textBoxFileNamesToKeep);
			this.Controls.Add(this.textBoxInputList);
			this.Description = "This utility aims to take a list of file paths, then exclude certain file names, " +
    "generating a new list.";
			this.FileBrowseMode = JJ.Framework.WinForms.Helpers.FileBrowseModeEnum.None;
			this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MustShowEmptyProgressBar = false;
			this.Name = "FileNameFilterForm";
			this.Text = "";
			this.TextBoxEnabled = false;
			this.TextBoxLabelText = "";
			this.TextBoxVisible = false;
			this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
			this.Load += new System.EventHandler(this.FileNameFilterForm_Load);
			this.Resize += new System.EventHandler(this.FileNameFilterForm_Resize);
			this.Controls.SetChildIndex(this.textBoxInputList, 0);
			this.Controls.SetChildIndex(this.textBoxFileNamesToKeep, 0);
			this.Controls.SetChildIndex(this.textBoxOutputList, 0);
			this.Controls.SetChildIndex(this.labelOutputList, 0);
			this.Controls.SetChildIndex(this.labelFileNamesToKeep, 0);
			this.Controls.SetChildIndex(this.labelInputList, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxInputList;
		private System.Windows.Forms.TextBox textBoxFileNamesToKeep;
		private System.Windows.Forms.TextBox textBoxOutputList;
		private System.Windows.Forms.Label labelOutputList;
		private System.Windows.Forms.Label labelFileNamesToKeep;
		private System.Windows.Forms.Label labelInputList;
	}
}

