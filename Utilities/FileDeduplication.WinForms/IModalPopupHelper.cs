using System;
using System.Windows.Forms;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	internal interface IModalPopupHelper
	{
		event EventHandler AreYouSureYouWishToScanYesRequested;
		event EventHandler AreYouSureYouWishToDeleteFilesYesRequested;

		void ShowValidationMessagesIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel);
		void ShowAreYouSureYouWishToDeleteFilesPopupIfNeeded(FileDeduplicationForm parentForm, FileDeduplicationViewModel viewModel);
		void ShowAreYouSureYouWishToScanPopupIfNeeded(FileDeduplicationForm parentForm, FileDeduplicationViewModel viewModel);
	}
}
