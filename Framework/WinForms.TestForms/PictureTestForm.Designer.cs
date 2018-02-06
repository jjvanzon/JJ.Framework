using JJ.Framework.WinForms.Controls;

namespace JJ.Framework.WinForms.TestForms
{
	partial class PictureTestForm
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
			this.diagramControl1 = new DiagramControl();
			this.SuspendLayout();
			// 
			// diagramControl1
			// 
			this.diagramControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.diagramControl1.Location = new System.Drawing.Point(0, 0);
			this.diagramControl1.Name = "diagramControl1";
			this.diagramControl1.Size = new System.Drawing.Size(519, 423);
			this.diagramControl1.TabIndex = 0;
			// 
			// HelloWorldTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 423);
			this.Controls.Add(this.diagramControl1);
			this.Name = "HelloWorldTestForm";
			this.ResumeLayout(false);

		}

		#endregion

		private DiagramControl diagramControl1;
	}
}

