
namespace JJ.Framework.Presentation.WinForms.Forms
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
            this.simpleFileProcessControl = new JJ.Framework.Presentation.WinForms.Controls.SimpleFileProcessControl();
            this.SuspendLayout();
            // 
            // simpleFileProcessControl
            // 
            this.simpleFileProcessControl.Description = "";
            this.simpleFileProcessControl.FilePath = "";
            this.simpleFileProcessControl.IsRunning = false;
            this.simpleFileProcessControl.Location = new System.Drawing.Point(0, 0);
            this.simpleFileProcessControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleFileProcessControl.MustShowExceptions = false;
            this.simpleFileProcessControl.Name = "simpleFileProcessControl";
            this.simpleFileProcessControl.Size = new System.Drawing.Size(627, 347);
            this.simpleFileProcessControl.TabIndex = 0;
            // 
            // SimpleFileProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 432);
            this.Controls.Add(this.simpleFileProcessControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SimpleFileProcessForm";
            this.Text = "SimpleProcessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Base_FormClosing);
            this.Load += new System.EventHandler(this.SimpleFileProcessForm_Load);
            this.SizeChanged += new System.EventHandler(this.SimpleFileProcessForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SimpleFileProcessControl simpleFileProcessControl;
    }
}