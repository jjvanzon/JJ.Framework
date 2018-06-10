using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.Presentation;
using JJ.Framework.WinForms.EventArg;
using JJ.Framework.WinForms.Extensions;

namespace JJ.Framework.WinForms.Controls
{
    [PublicAPI]
	public partial class PagerControl : UserControl
	{
		private PagerViewModel _viewModel;
		private readonly IList<LinkLabel> _pageNumberLinkLabels = new List<LinkLabel>();

		public event EventHandler GoToFirstPageClicked;
		public event EventHandler GoToPreviousPageClicked;
		public event EventHandler<PageNumberEventArgs> PageNumberClicked;
		public event EventHandler GoToNextPageClicked;
		public event EventHandler GoToLastPageClicked;

		public PagerControl() => InitializeComponent();

		private bool _resizeBusy;

		/// <summary>
		/// Keeps the height of control fixed.
		/// </summary>
		protected override void OnResize(EventArgs e)
		{
			if (_resizeBusy) return;
			_resizeBusy = true;

			base.OnResize(e);

			Height = linkLabelGoToFirstPage.Height + Padding.Top + Padding.Bottom;

			_resizeBusy = false;
		}

		/// <summary> nullable </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PagerViewModel PagerViewModel
		{
			get => _viewModel;
		    set
			{
				if (_viewModel == value) return;

				_viewModel = value;

				ApplyViewModel();
			}
		}

		private void ApplyViewModel()
		{
			flowLayoutPanel.SuspendLayout();
			SuspendLayout();

			if (_viewModel == null)
			{
				flowLayoutPanel.Visible = false;

				flowLayoutPanel.ResumeLayout();
				ResumeLayout();

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
			// ReSharper disable once UseObjectOrCollectionInitializer
			var childControls = new List<Control>(_pageNumberLinkLabels.Count + 6);
			childControls.Add(linkLabelGoToFirstPage);
			childControls.Add(linkLabelGoToPreviousPage);
			childControls.Add(labelLeftEllipsis);
			childControls.AddRange(_pageNumberLinkLabels);
			childControls.Add(labelRightEllipsis);
			childControls.Add(linkLabelGoToNextPage);
			childControls.Add(linkLabelGoToLastPage);

			flowLayoutPanel.Controls.Clear();

			for (int j = 0; j < childControls.Count; j++)
			{
				Control childControl = childControls[j];
				flowLayoutPanel.Controls.Add(childControl);

				// SetChildIndex is why I cannot just add controls to the flowLayoutPanel:
				// if you do then most of the times they appear in the right order,
				// but sometimes you get them arranged in an arbitrary order.
				flowLayoutPanel.Controls.SetChildIndex(childControl, j + 1);
			}

			flowLayoutPanel.Visible = true;

			flowLayoutPanel.ResumeLayout();
			ResumeLayout();

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
				var pageNumberLinkLabel = (LinkLabel)sender;
				int pageNumber = int.Parse(pageNumberLinkLabel.Text);
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
