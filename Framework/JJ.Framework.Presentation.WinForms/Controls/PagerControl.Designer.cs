namespace JJ.Framework.Presentation.WinForms.Controls
{
    partial class PagerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelGoToFirstPage = new System.Windows.Forms.LinkLabel();
            this.linkLabelGoToPreviousPage = new System.Windows.Forms.LinkLabel();
            this.labelLeftEllipsis = new System.Windows.Forms.Label();
            this.labelRightEllipsis = new System.Windows.Forms.Label();
            this.linkLabelGoToNextPage = new System.Windows.Forms.LinkLabel();
            this.linkLabelGoToLastPage = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.linkLabelGoToFirstPage);
            this.flowLayoutPanel.Controls.Add(this.linkLabelGoToPreviousPage);
            this.flowLayoutPanel.Controls.Add(this.labelLeftEllipsis);
            this.flowLayoutPanel.Controls.Add(this.labelRightEllipsis);
            this.flowLayoutPanel.Controls.Add(this.linkLabelGoToNextPage);
            this.flowLayoutPanel.Controls.Add(this.linkLabelGoToLastPage);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(342, 84);
            this.flowLayoutPanel.TabIndex = 3;
            // 
            // linkLabelGoToFirstPage
            // 
            this.linkLabelGoToFirstPage.AutoSize = true;
            this.linkLabelGoToFirstPage.Location = new System.Drawing.Point(3, 0);
            this.linkLabelGoToFirstPage.Name = "linkLabelGoToFirstPage";
            this.linkLabelGoToFirstPage.Size = new System.Drawing.Size(19, 13);
            this.linkLabelGoToFirstPage.TabIndex = 0;
            this.linkLabelGoToFirstPage.TabStop = true;
            this.linkLabelGoToFirstPage.Text = "<<";
            this.linkLabelGoToFirstPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToFirstPage_LinkClicked);
            // 
            // linkLabelGoToPreviousPage
            // 
            this.linkLabelGoToPreviousPage.AutoSize = true;
            this.linkLabelGoToPreviousPage.Location = new System.Drawing.Point(28, 0);
            this.linkLabelGoToPreviousPage.Name = "linkLabelGoToPreviousPage";
            this.linkLabelGoToPreviousPage.Size = new System.Drawing.Size(13, 13);
            this.linkLabelGoToPreviousPage.TabIndex = 1;
            this.linkLabelGoToPreviousPage.TabStop = true;
            this.linkLabelGoToPreviousPage.Text = "<";
            this.linkLabelGoToPreviousPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToPreviousPage_LinkClicked);
            // 
            // labelLeftEllipsis
            // 
            this.labelLeftEllipsis.AutoSize = true;
            this.labelLeftEllipsis.Location = new System.Drawing.Point(47, 0);
            this.labelLeftEllipsis.Name = "labelLeftEllipsis";
            this.labelLeftEllipsis.Size = new System.Drawing.Size(16, 13);
            this.labelLeftEllipsis.TabIndex = 2;
            this.labelLeftEllipsis.Text = "...";
            // 
            // labelRightEllipsis
            // 
            this.labelRightEllipsis.AutoSize = true;
            this.labelRightEllipsis.Location = new System.Drawing.Point(69, 0);
            this.labelRightEllipsis.Name = "labelRightEllipsis";
            this.labelRightEllipsis.Size = new System.Drawing.Size(16, 13);
            this.labelRightEllipsis.TabIndex = 4;
            this.labelRightEllipsis.Text = "...";
            // 
            // linkLabelGoToNextPage
            // 
            this.linkLabelGoToNextPage.AutoSize = true;
            this.linkLabelGoToNextPage.Location = new System.Drawing.Point(91, 0);
            this.linkLabelGoToNextPage.Name = "linkLabelGoToNextPage";
            this.linkLabelGoToNextPage.Size = new System.Drawing.Size(13, 13);
            this.linkLabelGoToNextPage.TabIndex = 5;
            this.linkLabelGoToNextPage.TabStop = true;
            this.linkLabelGoToNextPage.Text = ">";
            this.linkLabelGoToNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToNextPage_LinkClicked);
            // 
            // linkLabelGoToLastPage
            // 
            this.linkLabelGoToLastPage.AutoSize = true;
            this.linkLabelGoToLastPage.Location = new System.Drawing.Point(110, 0);
            this.linkLabelGoToLastPage.Name = "linkLabelGoToLastPage";
            this.linkLabelGoToLastPage.Size = new System.Drawing.Size(19, 13);
            this.linkLabelGoToLastPage.TabIndex = 6;
            this.linkLabelGoToLastPage.TabStop = true;
            this.linkLabelGoToLastPage.Text = ">>";
            this.linkLabelGoToLastPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToLastPage_LinkClicked);
            // 
            // PagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(342, 84);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.LinkLabel linkLabelGoToFirstPage;
        private System.Windows.Forms.LinkLabel linkLabelGoToPreviousPage;
        private System.Windows.Forms.Label labelLeftEllipsis;
        private System.Windows.Forms.Label labelRightEllipsis;
        private System.Windows.Forms.LinkLabel linkLabelGoToNextPage;
        private System.Windows.Forms.LinkLabel linkLabelGoToLastPage;

    }
}
