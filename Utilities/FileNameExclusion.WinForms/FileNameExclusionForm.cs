using System;
using JJ.Framework.Resources;
using JJ.Framework.WinForms.Extensions;
using JJ.Framework.WinForms.Forms;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	public partial class FileNameExclusionForm : SimpleProcessForm
	{
		private readonly FileNameExclusionPresenter _presenter;
		private FileNameExclusionViewModel ViewModel => _presenter.ViewModel;

		private readonly IModalPopupHelper _modalPopupHelper;

		public FileNameExclusionForm()
		{
			InitializeComponent();

			ApplyResourceTexts();

			this.AutomaticallyAssignTabIndexes();

			_presenter = new FileNameExclusionPresenter(new FileNameExcluder());

			_modalPopupHelper = new ModalPopupHelper();
			_modalPopupHelper.AreYouSureOkRequested += ModalPopupHelper_AreYouSureOkRequested;
		}

		private void ApplyResourceTexts()
		{
			Text = ResourceFormatter.ApplicationName;
			Description = ResourceFormatter.Explanation;
			StartButtonText = CommonResourceFormatter.Start;
			labelInputList.Text = ResourceFormatter.InputList + ":";
			labelExclusionList.Text = ResourceFormatter.ExclusionList + ":";
			labelOutputList.Text = ResourceFormatter.OutputList + ":";
		}

		// Actions

		private void ModalPopupHelper_AreYouSureOkRequested(object sender, EventArgs e) => OnBackgroundThread(() => ExecuteAction(_presenter.AreYouSureYes));

		private void MainForm_OnRunProcess(object sender, EventArgs e) => ExecuteAction(_presenter.RunProcess);

		private void ExecuteAction(Action action)
		{
			try
			{
				MapControlsToViewModel();
				action();
			}
			finally
			{
				MapViewModelToControls();
			}
		}

		// Binding

		/// <summary> Implementation detail: string reference comparisons for performance. </summary>
		private void MapViewModelToControls()
			=> OnUiThread(
				() =>
				{
					if (textBoxInputList.Text != ViewModel.InputList) textBoxInputList.Text = ViewModel.InputList;
					if (textBoxExclusionList.Text != ViewModel.ExclusionList) textBoxExclusionList.Text = ViewModel.ExclusionList;
					if (textBoxOutputList.Text != ViewModel.OutputList) textBoxOutputList.Text = ViewModel.OutputList;
					_modalPopupHelper.ShowValidationMessagesIfNeeded(this, ViewModel);
					_modalPopupHelper.ShowAreYouSureQuestionIfNeeded(this, ViewModel);
					_modalPopupHelper.ShowDonePopupMessageIfNeeded(this, ViewModel);
				});

		private void MapControlsToViewModel()
		{
			ViewModel.InputList = textBoxInputList.Text;
			ViewModel.ExclusionList = textBoxExclusionList.Text;
			ViewModel.OutputList = textBoxOutputList.Text;
		}

		// Positioning

		private void FileNameExclusionForm_Load(object sender, EventArgs e) => PositionControls();
		private void FileNameExclusionForm_Resize(object sender, EventArgs e) => PositionControls();

		protected void PositionControls()
		{
			int topY = Spacing * 4;
			int bottomY = ClientSize.Height - Spacing - ButtonHeight - Spacing;
			int availableHeight = bottomY - topY;
			int availableWidth = ClientSize.Width - Spacing - Spacing;
			int heightPerSection = availableHeight / 3;

			int labelHeight = labelInputList.Height;
			int textBoxHeight = heightPerSection - labelHeight;

			int y = topY;

			// TODO: Positioner class might be nice.

			labelInputList.Top = y;
			labelInputList.Left = Spacing;

			y += labelHeight;

			textBoxInputList.Top = y;
			textBoxInputList.Left = Spacing;
			textBoxInputList.Width = availableWidth;
			textBoxInputList.Height = textBoxHeight;

			y += textBoxHeight;

			labelExclusionList.Top = y;
			labelExclusionList.Left = Spacing;

			y += labelHeight;

			textBoxExclusionList.Top = y;
			textBoxExclusionList.Left = Spacing;
			textBoxExclusionList.Width = availableWidth;
			textBoxExclusionList.Height = textBoxHeight;

			y += textBoxHeight;

			labelOutputList.Top = y;
			labelOutputList.Left = Spacing;

			y += labelHeight;

			textBoxOutputList.Top = y;
			textBoxOutputList.Left = Spacing;
			textBoxOutputList.Width = availableWidth;
			textBoxOutputList.Height = textBoxHeight;
		}
	}
}
