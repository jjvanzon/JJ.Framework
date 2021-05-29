using System;
using System.Windows.Forms;

namespace JJ.Utilities.FileDeduplication.WinForms
{
    internal interface IModalPopupHelper
    {
        event EventHandler ScanYesRequested;
        event EventHandler DeleteFilesYesRequested;

        void ShowValidationMessagesIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel);
        void ShowDeleteFilesQuestionIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel);
        void ShowScanQuestionIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel);
    }
}
