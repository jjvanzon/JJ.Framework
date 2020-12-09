using System;
using System.Windows.Forms;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	internal interface IModalPopupHelper
	{
		void ShowValidationMessagesIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel);
		void ShowDonePopupMessageIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel);
	}
}
