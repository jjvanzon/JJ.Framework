
namespace JJ.Framework.WinForms.TestForms
{
	partial class SimpleProcessControlTestForm
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
			this.simpleProcessControl1 = new JJ.Framework.WinForms.Controls.SimpleProcessControl();
			this.SuspendLayout();
			// 
			// simpleProcessControl1
			// 
			this.simpleProcessControl1.Description = "";
			this.simpleProcessControl1.FileBrowseMode = JJ.Framework.WinForms.Helpers.FileBrowseModeEnum.OpenFile;
			this.simpleProcessControl1.IsRunning = false;
			this.simpleProcessControl1.Location = new System.Drawing.Point(98, 14);
			this.simpleProcessControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.simpleProcessControl1.Name = "simpleProcessControl1";
			this.simpleProcessControl1.Size = new System.Drawing.Size(568, 411);
			this.simpleProcessControl1.TabIndex = 0;
			this.simpleProcessControl1.TextBoxLabelText = "Path";
			this.simpleProcessControl1.TextBoxText = "";
			this.simpleProcessControl1.TextBoxVisible = false;
			// 
			// SimpleProcessControlTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.simpleProcessControl1);
			this.Name = "SimpleProcessControlTestForm";
			this.Text = "SimpleProcessControlTestForm";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.SimpleProcessControl simpleProcessControl1;
	}
}