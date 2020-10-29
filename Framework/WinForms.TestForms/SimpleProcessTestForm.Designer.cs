namespace JJ.Framework.WinForms.TestForms
{
	partial class SimpleProcessTestForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleProcessTestForm));
			this.SuspendLayout();
			// 
			// SimpleProcessTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.Description = resources.GetString("$this.Description");
			this.DescriptionHeight = 120;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.805756F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.Name = "SimpleProcessTestForm";
			this.Text = "SimpleProcessTestForm";
			this.TextBoxOrientation = JJ.Framework.WinForms.Helpers.UpDownOrientationEnum.Up;
			this.TextBoxVisible = true;
			this.ResumeLayout(false);

		}

		#endregion
	}
}