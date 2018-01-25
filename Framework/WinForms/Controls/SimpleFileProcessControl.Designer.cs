namespace JJ.Framework.WinForms.Controls
{
	partial class SimpleFileProcessControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelProgress = new System.Windows.Forms.Label();
			this.labelFilePath = new System.Windows.Forms.Label();
			this.textBoxFilePath = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.labelDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonCancel.Font = new System.Drawing.Font("Calibri", 10F);
			this.buttonCancel.Location = new System.Drawing.Point(368, 286);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(126, 49);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelProgress
			// 
			this.labelProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelProgress.Font = new System.Drawing.Font("Calibri", 10F);
			this.labelProgress.Location = new System.Drawing.Point(0, 363);
			this.labelProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Padding = new System.Windows.Forms.Padding(9);
			this.labelProgress.Size = new System.Drawing.Size(568, 48);
			this.labelProgress.TabIndex = 8;
			this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelFilePath
			// 
			this.labelFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelFilePath.AutoSize = true;
			this.labelFilePath.Font = new System.Drawing.Font("Calibri", 10F);
			this.labelFilePath.Location = new System.Drawing.Point(18, 231);
			this.labelFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFilePath.Name = "labelFilePath";
			this.labelFilePath.Size = new System.Drawing.Size(53, 24);
			this.labelFilePath.TabIndex = 7;
			this.labelFilePath.Text = "Path:";
			// 
			// textBoxFilePath
			// 
			this.textBoxFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBoxFilePath.Font = new System.Drawing.Font("Calibri", 10F);
			this.textBoxFilePath.Location = new System.Drawing.Point(80, 225);
			this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxFilePath.Name = "textBoxFilePath";
			this.textBoxFilePath.Size = new System.Drawing.Size(462, 32);
			this.textBoxFilePath.TabIndex = 6;
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonStart.Font = new System.Drawing.Font("Calibri", 10F);
			this.buttonStart.Location = new System.Drawing.Point(80, 286);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(126, 49);
			this.buttonStart.TabIndex = 5;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// labelDescription
			// 
			this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelDescription.Font = new System.Drawing.Font("Calibri", 10F);
			this.labelDescription.Location = new System.Drawing.Point(22, 22);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(521, 145);
			this.labelDescription.TabIndex = 10;
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SimpleFileProcessControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelFilePath);
			this.Controls.Add(this.textBoxFilePath);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelProgress);
			this.Controls.Add(this.buttonStart);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "SimpleFileProcessControl";
			this.Size = new System.Drawing.Size(568, 411);
			this.Load += new System.EventHandler(this.SimpleFileProcessControl_Load);
			this.Resize += new System.EventHandler(this.SimpleFileProcessControl_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelProgress;
		private System.Windows.Forms.Label labelFilePath;
		private System.Windows.Forms.TextBox textBoxFilePath;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label labelDescription;
	}
}
