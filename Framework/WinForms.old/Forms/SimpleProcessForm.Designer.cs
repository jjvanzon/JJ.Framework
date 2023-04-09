
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
            this.simpleProcessControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleProcessControl.MustShowExceptions = false;
            this.simpleProcessControl.Name = "simpleProcessControl";
            this.simpleProcessControl.Size = new System.Drawing.Size(627, 348);
            this.simpleProcessControl.TabIndex = 0;
            // 
            // SimpleProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 432);
            this.Controls.Add(this.simpleProcessControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SimpleProcessForm";
            this.Text = "SimpleProcessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Base_FormClosing);
            this.Load += new System.EventHandler(this.SimpleProcessForm_Load);
            this.Resize += new System.EventHandler(this.SimpleProcessForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SimpleProcessControl simpleProcessControl;
    }
}