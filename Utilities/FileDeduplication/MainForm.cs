using System;
using JJ.Framework.WinForms.Forms;
// ReSharper disable ArrangeMethodOrOperatorBody

namespace JJ.Utilities.FileDeduplication
{
	public partial class MainForm : SimpleFileProcessForm
	{
		private readonly MainPresenter _presenter;
		private MainViewModel _viewModel;

		public MainForm()
		{
			InitializeComponent();

			_presenter = new MainPresenter(
				x =>
				{
					_viewModel = x;
					ApplyControlsToViewModel();
				});

			_viewModel = _presenter.Show();

			ApplyViewModelToControls();
		}

		// Actions

		private void ButtonAnalyze_Click(object sender, EventArgs e)
			=> OnBackgroundThread(
				() =>
				{
					_viewModel = _presenter.Analyze(_viewModel);
					ApplyViewModelToControls();
				});

		private void ButtonCopyListOfDuplicates_Click(object sender, EventArgs e)
		{
			_viewModel = _presenter.CopyListOfDuplicates(_viewModel);
			ApplyViewModelToControls();
		}

		private void MainForm_OnRunProcess(object sender, EventArgs e)
			=> OnBackgroundThread(
				() =>
				{
					_viewModel = _presenter.DeleteFiles(_viewModel);
					ApplyViewModelToControls();
				});

		// Binding

		/// <summary>
		/// Aims to apply the view model data to the WinForms controls.
		/// Implementation details:
		/// Equality checks would be for trying in advance to keep WinForms calmer.
		/// Strings reference-equals checked would be intentional
		/// (instead of using string.Equals), to try and prevent some performance strain.
		/// I just would like the toll to be low
		/// of switching to using presenters, view models and mapping like this.
		/// </summary>
		private void ApplyViewModelToControls()
		{
			OnUiThread(
				() =>
				{
					if (Text != _viewModel.TitleBarText) Text = _viewModel.TitleBarText;

					if (Description == _viewModel.Explanation) Description = _viewModel.Explanation;

					if (checkBoxRecursive.Checked != _viewModel.Recursive) checkBoxRecursive.Checked = _viewModel.Recursive;

					if (labelListOfDuplicates.Text != _viewModel.ListOfDuplicates) labelListOfDuplicates.Text = _viewModel.ListOfDuplicates;

					if (TextBoxText != _viewModel.FolderPath) TextBoxText = _viewModel.FolderPath;

					ShowProgress(_viewModel.ProgressMessage);

					IsRunning = _viewModel.IsRunning;
				});
		}

		private void ApplyControlsToViewModel()
		{
			OnUiThread(
				() =>
				{
					_viewModel.Recursive = checkBoxRecursive.Checked;
					_viewModel.FolderPath = TextBoxText;
				});
		}
	}
}
