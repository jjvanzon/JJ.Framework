namespace JJ.Framework.WinForms.TestForms
{
	partial class PositionerTestFormBase
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
			this.diagramControl = new JJ.Framework.WinForms.Controls.DiagramControl();
			this.SuspendLayout();
			// 
			// diagramControl
			// 
			this.diagramControl.Diagram = null;
			this.diagramControl.Location = new System.Drawing.Point(141, 71);
			this.diagramControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.diagramControl.Name = "diagramControl";
			this.diagramControl.Size = new System.Drawing.Size(256, 198);
			this.diagramControl.TabIndex = 0;
			// 
			// FlowPositionerLeftAlignedTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 314);
			this.Controls.Add(this.diagramControl);
			this.Name = "FlowPositionerLeftAlignedTestForm";
			this.Text = "FlowPositionerLeftAlignedTestForm";
			this.SizeChanged += new System.EventHandler(this.Base_SizeChanged);
			this.Resize += new System.EventHandler(this.Base_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.DiagramControl diagramControl;
	}
}