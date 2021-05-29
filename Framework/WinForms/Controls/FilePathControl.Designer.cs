namespace JJ.Framework.WinForms.Controls
{
    partial class FilePathControl
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

            if (!disposing)
            {
                if (_graphics != null)
                {
                    _graphics.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.timerPositionControls = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(223, 10);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(35, 28);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(11, 10);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(39, 16);
            this.label.TabIndex = 1;
            this.label.Text = "Path";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(57, 6);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(132, 22);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // timerPositionControls
            // 
            this.timerPositionControls.Enabled = true;
            this.timerPositionControls.Interval = 1;
            this.timerPositionControls.Tick += new System.EventHandler(this.TimerPositionControls_Tick);
            // 
            // FilePathControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonBrowse);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FilePathControl";
            this.Size = new System.Drawing.Size(309, 74);
            this.EnabledChanged += new System.EventHandler(this.FilePathControl_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Timer timerPositionControls;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
