
namespace JJ.Utilities.FileNameExclusion.WinForms
{
	partial class FileNameExclusionForm
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
			this.textBoxInputList = new System.Windows.Forms.TextBox();
			this.textBoxExclusionList = new System.Windows.Forms.TextBox();
			this.textBoxOutputList = new System.Windows.Forms.TextBox();
			this.labelOutputList = new System.Windows.Forms.Label();
			this.labelExclusionList = new System.Windows.Forms.Label();
			this.labelInputList = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxInputList
			// 
			this.textBoxInputList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxInputList.Location = new System.Drawing.Point(12, 87);
			this.textBoxInputList.MaxLength = 0;
			this.textBoxInputList.Multiline = true;
			this.textBoxInputList.Name = "textBoxInputList";
			this.textBoxInputList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxInputList.Size = new System.Drawing.Size(776, 104);
			this.textBoxInputList.TabIndex = 5;
			this.textBoxInputList.WordWrap = false;
			// 
			// textBoxExclusionList
			// 
			this.textBoxExclusionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxExclusionList.Location = new System.Drawing.Point(12, 219);
			this.textBoxExclusionList.MaxLength = 0;
			this.textBoxExclusionList.Multiline = true;
			this.textBoxExclusionList.Name = "textBoxExclusionList";
			this.textBoxExclusionList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxExclusionList.Size = new System.Drawing.Size(776, 92);
			this.textBoxExclusionList.TabIndex = 6;
			this.textBoxExclusionList.WordWrap = false;
			// 
			// textBoxOutputList
			// 
			this.textBoxOutputList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxOutputList.Location = new System.Drawing.Point(12, 352);
			this.textBoxOutputList.MaxLength = 0;
			this.textBoxOutputList.Multiline = true;
			this.textBoxOutputList.Name = "textBoxOutputList";
			this.textBoxOutputList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxOutputList.Size = new System.Drawing.Size(776, 91);
			this.textBoxOutputList.TabIndex = 7;
			this.textBoxOutputList.WordWrap = false;
			// 
			// labelOutputList
			// 
			this.labelOutputList.AutoSize = true;
			this.labelOutputList.Location = new System.Drawing.Point(12, 327);
			this.labelOutputList.Name = "labelOutputList";
			this.labelOutputList.Size = new System.Drawing.Size(125, 22);
			this.labelOutputList.TabIndex = 9;
			this.labelOutputList.Text = "labelOutputList";
			// 
			// labelExclusionList
			// 
			this.labelExclusionList.AutoSize = true;
			this.labelExclusionList.Location = new System.Drawing.Point(8, 194);
			this.labelExclusionList.Name = "labelExclusionList";
			this.labelExclusionList.Size = new System.Drawing.Size(141, 22);
			this.labelExclusionList.TabIndex = 10;
			this.labelExclusionList.Text = "labelExclusionList";
			// 
			// labelInputList
			// 
			this.labelInputList.AutoSize = true;
			this.labelInputList.Location = new System.Drawing.Point(12, 62);
			this.labelInputList.Name = "labelInputList";
			this.labelInputList.Size = new System.Drawing.Size(112, 22);
			this.labelInputList.TabIndex = 11;
			this.labelInputList.Text = "labelInputList";
			// 
			// FileNameExclusionForm
			// 
			this.AreYouSureQuestion = "";
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BrowseButtonEnabled = false;
			this.CancelButtonVisible = false;
			this.ClientSize = new System.Drawing.Size(583, 528);
			this.Controls.Add(this.labelInputList);
			this.Controls.Add(this.labelExclusionList);
			this.Controls.Add(this.labelOutputList);
			this.Controls.Add(this.textBoxOutputList);
			this.Controls.Add(this.textBoxExclusionList);
			this.Controls.Add(this.textBoxInputList);
			this.Description = "This utility aims to take a list of file paths, then exclude certain file names, " +
    "generating a new list.";
			this.FileBrowseMode = JJ.Framework.WinForms.Helpers.FileBrowseModeEnum.None;
			this.Font = new System.Drawing.Font("Calibri", 8.805756F, System.Drawing.FontStyle.Bold);
			this.MustShowEmptyProgressBar = false;
			this.Name = "FileNameExclusionForm";
			this.Text = "";
			this.TextBoxEnabled = false;
			this.TextBoxLabelText = "";
			this.TextBoxVisible = false;
			this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
			this.Load += new System.EventHandler(this.FileNameExclusionForm_Load);
			this.Resize += new System.EventHandler(this.FileNameExclusionForm_Resize);
			this.Controls.SetChildIndex(this.textBoxInputList, 0);
			this.Controls.SetChildIndex(this.textBoxExclusionList, 0);
			this.Controls.SetChildIndex(this.textBoxOutputList, 0);
			this.Controls.SetChildIndex(this.labelOutputList, 0);
			this.Controls.SetChildIndex(this.labelExclusionList, 0);
			this.Controls.SetChildIndex(this.labelInputList, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxInputList;
		private System.Windows.Forms.TextBox textBoxExclusionList;
		private System.Windows.Forms.TextBox textBoxOutputList;
		private System.Windows.Forms.Label labelOutputList;
		private System.Windows.Forms.Label labelExclusionList;
		private System.Windows.Forms.Label labelInputList;
	}
}

