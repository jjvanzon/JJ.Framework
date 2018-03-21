namespace JJ.Utilities.CreateFileInEmptyFoldersRecursive
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
			this.checkBoxPreviewOnly = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBoxPreviewOnly
			// 
			this.checkBoxPreviewOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxPreviewOnly.AutoSize = true;
			this.checkBoxPreviewOnly.Location = new System.Drawing.Point(175, 137);
			this.checkBoxPreviewOnly.Name = "checkBoxPreviewOnly";
			this.checkBoxPreviewOnly.Size = new System.Drawing.Size(273, 20);
			this.checkBoxPreviewOnly.TabIndex = 1;
			this.checkBoxPreviewOnly.Text = "Preview only (don\'t actually write the files)";
			this.checkBoxPreviewOnly.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 346);
			this.Controls.Add(this.checkBoxPreviewOnly);
			this.Description = resources.GetString("$this.Description");
			this.FilePath = "D:\\Source\\JJs Software\\Circle Docs";
			this.Name = "MainForm";
			this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
			this.Controls.SetChildIndex(this.checkBoxPreviewOnly, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxPreviewOnly;
	}
}

