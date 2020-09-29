using System;
using JJ.Framework.IO;
using JJ.Framework.Microsoft.VisualBasic;
using JJ.Framework.WinForms.Extensions;
using JJ.Framework.WinForms.Forms;
using JJ.Framework.WinForms.Helpers;

// ReSharper disable EmptyGeneralCatchClause
// ReSharper disable ArrangeMethodOrOperatorBody

namespace JJ.Utilities.FileDeduplication
{
	public partial class FileDeduplicationForm : SimpleFileProcessForm
	{
		private readonly FileDeduplicationPresenter _presenter;
		private FileDeduplicationViewModel ViewModel => _presenter.ViewModel;

		public FileDeduplicationForm()
		{
			InitializeComponent();

			this.AutomaticallyAssignTabIndexes();

			_presenter = new FileDeduplicationPresenter(
				new FileDeduplicator(),
				new BulkFileDeleter_WithRecycleBin(),
				new ClipboardUtilizer());

			_presenter.Initialize(MapViewModelToControls);
		}

		private void FileDeduplicationForm_Load(object sender, EventArgs e) => MapViewModelToControls();

		// Actions

		private void ButtonAnalyze_Click(object sender, EventArgs e) => OnBackgroundThread(() => ExecuteAction(_presenter.Scan));

		private void ButtonCopyListOfDuplicates_Click(object sender, EventArgs e) => ExecuteAction(_presenter.CopyListOfDuplicates);

		private void MainForm_OnRunProcess(object sender, EventArgs e) => OnBackgroundThread(() => ExecuteAction(_presenter.DeleteFiles));

		private void MainForm_Cancelled(object sender, EventArgs e) => ExecuteAction(_presenter.Cancel);

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

		/// <summary>
		/// Aims to apply the view model data to the WinForms controls.
		/// Implementation details:
		/// Equality checks would be for an attempt in advance to try and keep WinForms calmer.
		/// Strings reference-equals checked would be intentional
		/// (instead of using string.Equals), to try and prevent unnecessary performance strain.
		/// I just would like the toll of switching to using presenters, view models and mapping to be low.
		/// </summary>
		private void MapViewModelToControls()
		{
			OnUiThread(
				() =>
				{
					if (Text != ViewModel.TitleBarText) Text = ViewModel.TitleBarText;
					if (Description != ViewModel.Explanation) Description = ViewModel.Explanation;
					if (checkBoxRecursive.Checked != ViewModel.Recursive) checkBoxRecursive.Checked = ViewModel.Recursive;
					if (textBoxListOfDuplicates.Text != ViewModel.ListOfDuplicates) textBoxListOfDuplicates.Text = ViewModel.ListOfDuplicates;
					if (TextBoxText != ViewModel.FolderPath) TextBoxText = ViewModel.FolderPath;
					ShowProgress(ViewModel.ProgressMessage);
					IsRunning = ViewModel.IsRunning;

					bool enabled = !IsRunning;
					if (checkBoxRecursive.Enabled != enabled) checkBoxRecursive.Enabled = enabled;
					if (TextBoxEnabled != enabled) TextBoxEnabled = enabled;
					if (BrowseButtonEnabled != enabled) BrowseButtonEnabled = enabled;
					if (buttonScan.Enabled != enabled) buttonScan.Enabled = enabled;
					if (buttonCopyListOfDuplicates.Enabled != enabled) buttonCopyListOfDuplicates.Enabled = enabled;
				});
		}

		private void MapControlsToViewModel()
		{
			ViewModel.Recursive = checkBoxRecursive.Checked;
			ViewModel.FolderPath = TextBoxText;
		}
	}
}
