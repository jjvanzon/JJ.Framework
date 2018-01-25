using JJ.Framework.WinForms.Controls;
using JJ.Framework.WinForms.EventArg;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Framework.WinForms.TestForms
{
	partial class FilePathControlTestForm
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.filePathControl2 = new FilePathControl();
			this.filePathControl1 = new FilePathControl();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.filePathControl2, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(111, 202);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// filePathControl2
			// 
			this.filePathControl2.BrowseMode = FileBrowseModeEnum.Open;
			this.filePathControl2.FilePath = "";
			this.filePathControl2.LabelText = "Path";
			this.filePathControl2.Location = new System.Drawing.Point(103, 53);
			this.filePathControl2.Name = "filePathControl2";
			this.filePathControl2.Size = new System.Drawing.Size(94, 44);
			this.filePathControl2.Spacing = 0;
			this.filePathControl2.TabIndex = 0;
			// 
			// filePathControl1
			// 
			this.filePathControl1.BrowseMode = FileBrowseModeEnum.Open;
			this.filePathControl1.FilePath = "fadsfs";
			this.filePathControl1.Font = new System.Drawing.Font("Verdana", 10F);
			this.filePathControl1.LabelText = "Path";
			this.filePathControl1.Location = new System.Drawing.Point(39, 41);
			this.filePathControl1.Margin = new System.Windows.Forms.Padding(0);
			this.filePathControl1.Name = "filePathControl1";
			this.filePathControl1.Size = new System.Drawing.Size(159, 77);
			this.filePathControl1.Spacing = 0;
			this.filePathControl1.TabIndex = 0;
			this.filePathControl1.Browsed += new System.EventHandler<FilePathEventArgs>(this.filePathControl1_Browsed);
			// 
			// FilePathControlTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 325);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.filePathControl1);
			this.Name = "FilePathControlTestForm";
			this.Text = "FilePathControlTestForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private FilePathControl filePathControl1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private FilePathControl filePathControl2;
	}
}