namespace JJ.Framework.Presentation.WinForms.Controls
{
    partial class DiagramControl
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                _graphicsBuffer.Dispose();
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
            this.SuspendLayout();
            // 
            // DiagramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DiagramControl";
            this.Size = new System.Drawing.Size(506, 255);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DiagramControl_Paint);
            this.Resize += new System.EventHandler(this.DiagramControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
