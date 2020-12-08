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

		public FileNameExclusionForm()
		{
			InitializeComponent();

			ApplyResourceTexts();

			this.AutomaticallyAssignTabIndexes();

			_presenter = new FileNameExclusionPresenter();
		}

		private void ApplyResourceTexts()
		{
			Description = ResourceFormatter.Explanation;
			StartButtonText = CommonResourceFormatter.Delete;
			CancelButtonText = CommonResourceFormatter.Cancel;
			AreYouSureQuestion = CommonResourceFormatter.AreYouSure;
			labelInputList.Text = ResourceFormatter.InputList;
			labelExclusionList.Text = ResourceFormatter.ExclusionList;
			labelOutputList.Text = ResourceFormatter.OutputList;
		}

		private void MainForm_OnRunProcess(object sender, EventArgs e) => ExecuteAction( _presenter.RunProcess);

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

		/// <summary> Implementation detail: string reference comparisons for performance.</summary>
		private void MapViewModelToControls()
			=> OnUiThread(
				() =>
				{
					if (textBoxInputList.Text != ViewModel.InputList) textBoxInputList.Text = ViewModel.InputList;
					if (textBoxExclusionList.Text != ViewModel.ExclusionList) textBoxExclusionList.Text = ViewModel.ExclusionList;
					if (textBoxOutputList.Text != ViewModel.OutputList) textBoxOutputList.Text = ViewModel.OutputList;
				});

		private void MapControlsToViewModel()
		{
			ViewModel.InputList = textBoxInputList.Text;
			ViewModel.ExclusionList = textBoxExclusionList.Text;
			ViewModel.OutputList = textBoxOutputList.Text;
		}
	}
}
