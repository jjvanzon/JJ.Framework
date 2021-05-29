using System;
using System.Windows.Forms;

namespace JJ.Utilities.FileNameFilter.WinForms
{
    internal interface IModalPopupHelper
    {
        event EventHandler AreYouSureOkRequested;

        void ShowValidationMessagesIfNeeded(Form parentForm, FileNameFilterViewModel viewModel);
        void ShowAreYouSureQuestionIfNeeded(Form parentForm, FileNameFilterViewModel viewModel);
        void ShowDonePopupMessageIfNeeded(Form parentForm, FileNameFilterViewModel viewModel);
    }
}
