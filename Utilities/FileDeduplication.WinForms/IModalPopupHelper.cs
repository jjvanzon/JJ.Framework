using System;
using System.Windows.Forms;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	internal interface IModalPopupHelper
	{
		event EventHandler AreYouSureYouWishToScanYesRequested;

		void ShowValidationMessagesIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel);
		void ShowAreYouSureYouWishToScanPopupIfNeeded(FileDeduplicationForm parentForm, FileDeduplicationViewModel viewModel);
	}
}
