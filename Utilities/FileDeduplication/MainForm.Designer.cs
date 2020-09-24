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
			this.buttonShowListOfDuplicates = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBoxRecursive
			// 
			this.checkBoxRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxRecursive.AutoSize = true;
			this.checkBoxRecursive.Location = new System.Drawing.Point(23, 470);
			this.checkBoxRecursive.Name = "checkBoxRecursive";
			this.checkBoxRecursive.Size = new System.Drawing.Size(106, 26);
			this.checkBoxRecursive.TabIndex = 1;
			this.checkBoxRecursive.Text = "Recursive";
			this.checkBoxRecursive.UseVisualStyleBackColor = true;
			// 
			// buttonAnalyze
			// 
			this.buttonAnalyze.Location = new System.Drawing.Point(23, 392);
			this.buttonAnalyze.Name = "buttonAnalyze";
			this.buttonAnalyze.Size = new System.Drawing.Size(118, 49);
			this.buttonAnalyze.TabIndex = 2;
			this.buttonAnalyze.Text = "Analyze";
			this.buttonAnalyze.UseVisualStyleBackColor = true;
			this.buttonAnalyze.Click += new System.EventHandler(this.ButtonAnalyze_Click);
			// 
			// buttonShowListOfDuplicates
			// 
			this.buttonShowListOfDuplicates.Location = new System.Drawing.Point(729, 392);
			this.buttonShowListOfDuplicates.Name = "buttonShowListOfDuplicates";
			this.buttonShowListOfDuplicates.Size = new System.Drawing.Size(209, 49);
			this.buttonShowListOfDuplicates.TabIndex = 3;
			this.buttonShowListOfDuplicates.Text = "Show List of Duplicates";
			this.buttonShowListOfDuplicates.UseVisualStyleBackColor = true;
			this.buttonShowListOfDuplicates.Click += new System.EventHandler(this.ButtonShowListOfDuplicates_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(955, 673);
			this.Controls.Add(this.buttonShowListOfDuplicates);
			this.Controls.Add(this.buttonAnalyze);
			this.Controls.Add(this.checkBoxRecursive);
			this.Font = new System.Drawing.Font("Calibri", 8.805756F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.OnRunProcess += new System.EventHandler(this.MainForm_OnRunProcess);
			this.Controls.SetChildIndex(this.checkBoxRecursive, 0);
			this.Controls.SetChildIndex(this.buttonAnalyze, 0);
			this.Controls.SetChildIndex(this.buttonShowListOfDuplicates, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxRecursive;
		private System.Windows.Forms.Button buttonAnalyze;
		private System.Windows.Forms.Button buttonShowListOfDuplicates;
	}
}

