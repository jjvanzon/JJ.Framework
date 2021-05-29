using System;
using System.Windows.Forms;
using JJ.Framework.IO;
using JJ.Framework.ResourceStrings;
using JJ.Framework.VectorGraphics.Positioners;
using JJ.Framework.WinForms.Extensions;
using JJ.Framework.WinForms.Forms;

namespace JJ.Utilities.FileNameFilter.WinForms
{
	public partial class FileNameFilterForm : SimpleProcessForm
	{
		private readonly FileNameFilterPresenter _presenter;
		private FileNameFilterViewModel ViewModel => _presenter.ViewModel;

		private readonly IModalPopupHelper _modalPopupHelper;
		private readonly (Label label, TextBox textBox)[] _elementTuples;

		public FileNameFilterForm()
		{
			InitializeComponent();

			ApplyResourceTexts();

			this.AutomaticallyAssignTabIndexes();

			_presenter = new FileNameFilterPresenter(new FileNameFilterer());

			_modalPopupHelper = new ModalPopupHelper();
			_modalPopupHelper.AreYouSureOkRequested += ModalPopupHelper_AreYouSureOkRequested;

			_elementTuples = new[]
			{
				(labelInputList, textBoxInputList),
				(labelFileNamesToKeep, textBoxFileNamesToKeep),
				(labelOutputList, textBoxOutputList),
			};
		}

		private void ApplyResourceTexts()
		{
			Text = ResourceFormatter.ApplicationName;
			Description = ResourceFormatter.Explanation;
			StartButtonText = CommonResourceFormatter.Start;
			labelInputList.Text = ResourceFormatter.InputList + ":";
			labelFileNamesToKeep.Text = ResourceFormatter.FileNamesToKeep + ":";
			labelOutputList.Text = ResourceFormatter.OutputList + ":";
		}

		// Actions

		private void ModalPopupHelper_AreYouSureOkRequested(object sender, EventArgs e)
			=> OnBackgroundThread(() => ExecuteAction(_presenter.AreYouSureYes));

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
					if (textBoxFileNamesToKeep.Text != ViewModel.FileNamesToKeep) textBoxFileNamesToKeep.Text = ViewModel.FileNamesToKeep;
					if (textBoxOutputList.Text != ViewModel.OutputList) textBoxOutputList.Text = ViewModel.OutputList;
					_modalPopupHelper.ShowValidationMessagesIfNeeded(this, ViewModel);
					_modalPopupHelper.ShowAreYouSureQuestionIfNeeded(this, ViewModel);
					_modalPopupHelper.ShowDonePopupMessageIfNeeded(this, ViewModel);
				});

		private void MapControlsToViewModel()
		{
			ViewModel.InputList = textBoxInputList.Text;
			ViewModel.FileNamesToKeep = textBoxFileNamesToKeep.Text;
			ViewModel.OutputList = textBoxOutputList.Text;
		}

		// Positioning

		private void FileNameFilterForm_Load(object sender, EventArgs e) => PositionControls();
		private void FileNameFilterForm_Resize(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			const int elementCount = 3;

			int topY = Spacing * 4;
			int bottomY = ClientSize.Height - Spacing - ButtonHeight - Spacing;
			int availableHeight = bottomY - topY;
			int availableWidth = ClientSize.Width - Spacing - Spacing;

			int labelHeight = labelInputList.Height;

			var rectangles = new VerticalPositioner(Spacing, topY, availableWidth, availableHeight, elementCount).Calculate();

			for (int i = 0; i < elementCount; i++)
			{
				(Label label, TextBox textBox) = _elementTuples[i];
				(float x, float y, float width, float height) = rectangles[i];

				label.Left = (int)x;
				label.Top = (int)y;

				textBox.Left = (int)x;
				textBox.Top = (int)y + labelHeight;
				textBox.Width = (int)width;
				textBox.Height = (int)height - labelHeight;
			}
		}
	}
}
