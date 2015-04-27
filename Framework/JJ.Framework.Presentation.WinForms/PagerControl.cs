using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Visitors;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Drawing;
using JJ.Framework.Presentation.Svg;
using JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms
{
    public partial class PagerControl : UserControl
    {
        private PagerViewModel _viewModel;
        private IList<LinkLabel> _pageNumberLinkLabels = new List<LinkLabel>();

        public event EventHandler GoToFirstPageClicked;
        public event EventHandler GoToPreviousPageClicked;
        public event EventHandler<PageNumberEventArgs> PageNumberClicked;
        public event EventHandler GoToNextPageClicked;
        public event EventHandler GoToLastPageClicked;

        public PagerControl()
        {
            InitializeComponent();
        }

        /// <summary> nullable </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PagerViewModel PagerViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel == value) return;

                _viewModel = value;

                ApplyViewModel();
            }
        }

        private void ApplyViewModel()
        {
            //flowLayoutPanel.SuspendLayout();
            //SuspendLayout();

            if (_viewModel == null)
            {
                flowLayoutPanel.Visible = false;

                //flowLayoutPanel.ResumeLayout();
                //ResumeLayout();

                return;
            }

            linkLabelGoToFirstPage.Visible = _viewModel.CanGoToFirstPage;
            linkLabelGoToPreviousPage.Visible = _viewModel.CanGoToPreviousPage;
            labelLeftEllipsis.Visible = _viewModel.MustShowLeftEllipsis;
            labelRightEllipsis.Visible = _viewModel.MustShowRightEllipsis;
            linkLabelGoToNextPage.Visible = _viewModel.CanGoToNextPage;
            linkLabelGoToLastPage.Visible = _viewModel.CanGoToLastPage;

            // Dispose original _pageNumberLinkLabels
            foreach (LinkLabel pageNumberLinkLabel in _pageNumberLinkLabels)
            {
                pageNumberLinkLabel.Dispose();
            }
            _pageNumberLinkLabels.Clear();

            // Create new _pageNumberLinkLabels
            int i = 1;
            foreach (int pageNumber in _viewModel.VisiblePageNumbers)
            {
                var pageNumberLinkLabel = new LinkLabel
                {
                    Name = "pageNumberLinkLabel" + i,
                    Text = pageNumber.ToString(),
                    TabStop = true,
                    AutoSize = true
                };

                pageNumberLinkLabel.LinkClicked += pageNumberLinkLabel_LinkClicked;

                _pageNumberLinkLabels.Add(pageNumberLinkLabel);
                i++;
            }

            // Rearrange controls in flowLayoutPanel
            flowLayoutPanel.Controls.Clear();
            flowLayoutPanel.Controls.Add(linkLabelGoToFirstPage);
            flowLayoutPanel.Controls.Add(linkLabelGoToPreviousPage);
            flowLayoutPanel.Controls.Add(labelLeftEllipsis);
            flowLayoutPanel.Controls.AddRange(_pageNumberLinkLabels.ToArray());
            flowLayoutPanel.Controls.Add(labelRightEllipsis);
            flowLayoutPanel.Controls.Add(linkLabelGoToNextPage);
            flowLayoutPanel.Controls.Add(linkLabelGoToLastPage);

            flowLayoutPanel.Visible = true;

            //flowLayoutPanel.ResumeLayout();
            //ResumeLayout();

            this.AutomaticallyAssignTabIndexes();
        }

        private void linkLabelGoToFirstPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GoToFirstPageClicked != null)
            {
                GoToFirstPageClicked(sender, EventArgs.Empty);
            }
        }

        private void linkLabelGoToPreviousPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GoToPreviousPageClicked != null)
            {
                GoToPreviousPageClicked(sender, EventArgs.Empty);
            }
        }

        private void pageNumberLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PageNumberClicked != null)
            {
                LinkLabel pageNumberLinkLabel = (LinkLabel)sender;
                int pageNumber = Int32.Parse(pageNumberLinkLabel.Text);
                var e2 = new PageNumberEventArgs(pageNumber);
                PageNumberClicked(sender, e2);
            }
        }

        private void linkLabelGoToNextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GoToNextPageClicked != null)
            {
                GoToNextPageClicked(sender, EventArgs.Empty);
            }
        }

        private void linkLabelGoToLastPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GoToLastPageClicked != null)
            {
                GoToLastPageClicked(sender, EventArgs.Empty);
            }
        }
    }
}
