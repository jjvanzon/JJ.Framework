
using JJ.Framework.WinForms.Controls;

namespace JJ.Framework.WinForms.Forms
{
	partial class SimpleProcessForm
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

			// Custom code line.
			if (!this.DesignMode)
			{
				simpleProcessControl.OnRunProcess -= SimpleProcessControl_OnRunProcess;
				simpleProcessControl.Cancelled -= SimpleProcessControl_Cancelled;
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
			this.simpleProcessControl = new JJ.Framework.WinForms.Controls.SimpleProcessControl();
			this.SuspendLayout();
			// 
			// simpleProcessControl
			// 
			this.simpleProcessControl.Description = "";
			this.simpleProcessControl.TextBoxText = "";
			this.simpleProcessControl.IsRunning = false;
			this.simpleProcessControl.Location = new System.Drawing.Point(0, 0);
			this.simpleProcessControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.simpleProcessControl.MustShowExceptions = false;
			this.simpleProcessControl.Name = "simpleProcessControl";
			this.simpleProcessControl.Size = new System.Drawing.Size(557, 278);
			this.simpleProcessControl.TabIndex = 0;
			// 
			// SimpleProcessForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 346);
			this.Controls.Add(this.simpleProcessControl);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "SimpleProcessForm";
			this.Text = "SimpleProcessForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Base_FormClosing);
			this.Load += new System.EventHandler(this.SimpleProcessForm_Load);
			this.SizeChanged += new System.EventHandler(this.SimpleProcessForm_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.SimpleProcessControl simpleProcessControl;
	}
}