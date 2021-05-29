using System;
using System.Windows.Forms;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
    internal interface IModalPopupHelper
    {
        event EventHandler AreYouSureOkRequested;

        void ShowValidationMessagesIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel);
        void ShowAreYouSureQuestionIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel);
        void ShowDonePopupMessageIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel);
    }
}
