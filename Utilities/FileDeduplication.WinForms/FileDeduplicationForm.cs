using System;
using JJ.Framework.IO;
using JJ.Framework.Microsoft.VisualBasic;
using JJ.Framework.ResourceStrings;
using JJ.Framework.WinForms.Extensions;
using JJ.Framework.WinForms.Forms;
using JJ.Framework.WinForms.Helpers;
// ReSharper disable LocalizableElement

// ReSharper disable EmptyGeneralCatchClause
// ReSharper disable ArrangeMethodOrOperatorBody

namespace JJ.Utilities.FileDeduplication.WinForms
{
    public partial class FileDeduplicationForm : SimpleProcessForm
    {
        private readonly FileDeduplicationPresenter _presenter;
        private FileDeduplicationViewModel ViewModel => _presenter.ViewModel;

        private readonly IModalPopupHelper _modalPopupHelper;

        public FileDeduplicationForm()
        {
            InitializeComponent();

            ApplyResourceTexts();

            this.AutomaticallyAssignTabIndexes();

            _presenter = new FileDeduplicationPresenter(
                new FileDeduplicator(),
                new BulkFileDeleter_WithRecycleBin(),
                new ClipboardUtilizer(),
                new ListOfDuplicatesParserFormatter());
            _presenter.Initialize(MapViewModelToControls);

            _modalPopupHelper = new ModalPopupHelper();
            _modalPopupHelper.ScanYesRequested += ModalPopupHelper_ScanYesRequested;
            _modalPopupHelper.DeleteFilesYesRequested += ModalPopupHelper_DeleteFilesYesRequested;
        }

        private void ApplyResourceTexts()
        {
            checkBoxAlsoScanSubFolders.Text = ResourceFormatter.AlsoScanSubFolders;
            labelFilePattern.Text = CommonResourceFormatter.FilePattern + ":";
            buttonScan.Text = CommonResourceFormatter.Scan;
            buttonCopyListOfDuplicates.Text =
                CommonResourceFormatter.Copy_WithName(CommonResourceFormatter.ListOf_WithName(ResourceFormatter.Duplicates));

            labelListOfDuplicatesTitle.Text = CommonResourceFormatter.ListOf_WithName(ResourceFormatter.Duplicates) + ":";
            TextBoxLabelText = CommonResourceFormatter.Folder + ":";
            StartButtonText = CommonResourceFormatter.Delete;
            CancelButtonText = CommonResourceFormatter.Cancel;
        }

        private void FileDeduplicationForm_Load(object sender, EventArgs e) => MapViewModelToControls();

        // Actions

        private void ButtonScan_Click(object sender, EventArgs e) 
            => OnBackgroundThread(() => ExecuteAction(_presenter.Scan));

        private void ModalPopupHelper_ScanYesRequested(object sender, EventArgs e) 
            => OnBackgroundThread(() => ExecuteAction(_presenter.ScanYes));

        private void ButtonCopyListOfDuplicates_Click(object sender, EventArgs e) 
            => ExecuteAction(_presenter.CopyListOfDuplicates);

        private void MainForm_OnRunProcess(object sender, EventArgs e) 
            => ExecuteAction(_presenter.DeleteFiles);

        private void ModalPopupHelper_DeleteFilesYesRequested(object sender, EventArgs e) 
            => OnBackgroundThread(() => ExecuteAction(_presenter.DeleteFilesYes));

        private void MainForm_Cancelled(object sender, EventArgs e) 
            => ExecuteAction(_presenter.Cancel);

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
            => OnUiThread(
                () =>
                {
                    if (Text != ViewModel.TitleBarText) Text = ViewModel.TitleBarText;
                    if (Description != ViewModel.Explanation) Description = ViewModel.Explanation;
                    if (checkBoxAlsoScanSubFolders.Checked != ViewModel.AlsoScanSubFolders)
                    {
                        checkBoxAlsoScanSubFolders.Checked = ViewModel.AlsoScanSubFolders;
                    }

                    if (textBoxFilePattern.Text != ViewModel.FilePattern) textBoxFilePattern.Text = ViewModel.FilePattern;
                    if (textBoxListOfDuplicates.Text != ViewModel.ListOfDuplicates)
                    {
                        textBoxListOfDuplicates.Text = ViewModel.ListOfDuplicates;
                    }

                    if (TextBoxText != ViewModel.FolderPath) TextBoxText = ViewModel.FolderPath;
                    ShowProgress(ViewModel.ProgressMessage);
                    IsRunning = ViewModel.IsRunning;

                    bool enabled = !IsRunning;
                    if (checkBoxAlsoScanSubFolders.Enabled != enabled) checkBoxAlsoScanSubFolders.Enabled = enabled;
                    if (labelFilePattern.Enabled != enabled) labelFilePattern.Enabled = enabled;
                    if (textBoxFilePattern.Enabled != enabled) textBoxFilePattern.Enabled = enabled;
                    if (TextBoxEnabled != enabled) TextBoxEnabled = enabled;
                    if (BrowseButtonEnabled != enabled) BrowseButtonEnabled = enabled;
                    if (buttonScan.Enabled != enabled) buttonScan.Enabled = enabled;
                    if (buttonCopyListOfDuplicates.Enabled != enabled) buttonCopyListOfDuplicates.Enabled = enabled;

                    _modalPopupHelper.ShowValidationMessagesIfNeeded(this, ViewModel);
                    _modalPopupHelper.ShowScanQuestionIfNeeded(this, ViewModel);
                    _modalPopupHelper.ShowDeleteFilesQuestionIfNeeded(this, ViewModel);
                });

        private void MapControlsToViewModel()
        {
            ViewModel.AlsoScanSubFolders = checkBoxAlsoScanSubFolders.Checked;
            ViewModel.FilePattern = textBoxFilePattern.Text;
            ViewModel.FolderPath = TextBoxText;
            ViewModel.ListOfDuplicates = textBoxListOfDuplicates.Text;
        }
    }
}
