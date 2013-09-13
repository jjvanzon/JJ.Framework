using AopDraw.Controls;
namespace AopDraw
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.guiCanvas = new AopDraw.Controls.ViewPort();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(546, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(546, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(184, 483);
            this.propertyGrid1.TabIndex = 2;
            // 
            // guiCanvas
            // 
            this.guiCanvas.BackColor = System.Drawing.Color.White;
            this.guiCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guiCanvas.Location = new System.Drawing.Point(0, 0);
            this.guiCanvas.Name = "guiCanvas";
            this.guiCanvas.Size = new System.Drawing.Size(546, 460);
            this.guiCanvas.TabIndex = 0;
            this.guiCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guiCanvas_MouseDown);
            this.guiCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guiCanvas_MouseMove);
            this.guiCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.guiCanvas_Paint);
            this.guiCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guiCanvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 483);
            this.Controls.Add(this.guiCanvas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ViewPort guiCanvas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}

