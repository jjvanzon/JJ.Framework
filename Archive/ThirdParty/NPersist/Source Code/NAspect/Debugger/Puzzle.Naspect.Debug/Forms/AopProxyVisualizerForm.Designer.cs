namespace Puzzle.NAspect.Debug.Forms
{
    partial class AopProxyVisualizerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AopProxyVisualizerForm));
            this.lstMethods = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picInterceptors = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTypeName = new Puzzle.NAspect.Debug.Controls.Caption();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpInterception = new System.Windows.Forms.TabPage();
            this.tpComposition = new System.Windows.Forms.TabPage();
            this.imlIcons = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInterceptors)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpInterception.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMethods
            // 
            this.lstMethods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMethods.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstMethods.FormattingEnabled = true;
            this.lstMethods.IntegralHeight = false;
            this.lstMethods.ItemHeight = 20;
            this.lstMethods.Location = new System.Drawing.Point(1, 26);
            this.lstMethods.Name = "lstMethods";
            this.lstMethods.Size = new System.Drawing.Size(231, 309);
            this.lstMethods.TabIndex = 0;
            this.lstMethods.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMethods_DrawItem);
            this.lstMethods.SelectedIndexChanged += new System.EventHandler(this.lstMethods_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.picInterceptors);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 334);
            this.panel1.TabIndex = 4;
            // 
            // picInterceptors
            // 
            this.picInterceptors.Image = global::Puzzle.NAspect.Debug.Properties.Resources.interceptor;
            this.picInterceptors.Location = new System.Drawing.Point(0, -1);
            this.picInterceptors.Name = "picInterceptors";
            this.picInterceptors.Size = new System.Drawing.Size(330, 462);
            this.picInterceptors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInterceptors.TabIndex = 0;
            this.picInterceptors.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.lstMethods);
            this.splitContainer1.Panel1.Controls.Add(this.lblTypeName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Size = new System.Drawing.Size(872, 381);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 5;
            // 
            // lblTypeName
            // 
            this.lblTypeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeName.Location = new System.Drawing.Point(1, 1);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(231, 25);
            this.lblTypeName.TabIndex = 2;
            this.lblTypeName.Text = "caption1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(1, 335);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(231, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "This is a list of all adviced methods in the currently selected proxy type\r\n";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(1, 335);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(633, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "This view shows the call flow from your consumer code into your interceptors and " +
                "finally into your base implementation, \r\nand then back again.\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpInterception);
            this.tabControl1.Controls.Add(this.tpComposition);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(886, 413);
            this.tabControl1.TabIndex = 6;
            // 
            // tpInterception
            // 
            this.tpInterception.Controls.Add(this.splitContainer1);
            this.tpInterception.Location = new System.Drawing.Point(4, 22);
            this.tpInterception.Name = "tpInterception";
            this.tpInterception.Padding = new System.Windows.Forms.Padding(3);
            this.tpInterception.Size = new System.Drawing.Size(878, 387);
            this.tpInterception.TabIndex = 0;
            this.tpInterception.Text = "Interception";
            this.tpInterception.UseVisualStyleBackColor = true;
            // 
            // tpComposition
            // 
            this.tpComposition.Location = new System.Drawing.Point(4, 22);
            this.tpComposition.Name = "tpComposition";
            this.tpComposition.Padding = new System.Windows.Forms.Padding(3);
            this.tpComposition.Size = new System.Drawing.Size(878, 387);
            this.tpComposition.TabIndex = 1;
            this.tpComposition.Text = "Composition";
            this.tpComposition.UseVisualStyleBackColor = true;
            // 
            // imlIcons
            // 
            this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
            this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlIcons.Images.SetKeyName(0, "Method.gif");
            this.imlIcons.Images.SetKeyName(1, "ctor.gif");
            this.imlIcons.Images.SetKeyName(2, "property.gif");
            // 
            // AopProxyVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 413);
            this.Controls.Add(this.tabControl1);
            this.Name = "AopProxyVisualizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AopProxyVisualizerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AopProxyVisualizerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInterceptors)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpInterception.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMethods;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picInterceptors;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpInterception;
        private System.Windows.Forms.TabPage tpComposition;
        private Puzzle.NAspect.Debug.Controls.Caption lblTypeName;
        private System.Windows.Forms.ImageList imlIcons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}