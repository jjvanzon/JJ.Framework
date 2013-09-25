namespace JJ.Framework.Presentation.WinForms
{
    partial class SimpleFileProcessForm
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
                simpleFileProcessControl.OnRunProcess -= simpleProcessControl_OnRunProcess;
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
            this.simpleFileProcessControl = new JJ.Framework.Presentation.WinForms.SimpleFileProcessControl();
            this.SuspendLayout();
            // 
            // simpleProcessControl
            // 
            this.simpleFileProcessControl.Description = "";
            this.simpleFileProcessControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleFileProcessControl.FilePath = "";
            this.simpleFileProcessControl.Location = new System.Drawing.Point(0, 0);
            this.simpleFileProcessControl.Name = "simpleProcessControl";
            this.simpleFileProcessControl.Size = new System.Drawing.Size(646, 280);
            this.simpleFileProcessControl.TabIndex = 0;
            // 
            // SimpleProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 280);
            this.Controls.Add(this.simpleFileProcessControl);
            this.Name = "SimpleProcessForm";
            this.Text = "SimpleProcessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Base_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleFileProcessControl simpleFileProcessControl;
    }
}