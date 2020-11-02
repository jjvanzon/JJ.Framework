using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.InvalidValues;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public class ModalPopupHelper : IModalPopupHelper
	{
		public event EventHandler AreYouSureYouWishToScanYesRequested;
		public event EventHandler AreYouSureYouWishToDeleteFilesYesRequested;

		public void ShowValidationMessagesIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel)
		{
			if (parentForm == null) throw new NullException(() => parentForm);
			if (viewModel == null) throw new NullException(() => viewModel);

			if (viewModel.ValidationMessages.Count == 0)
			{
				return;
			}

			// Capture text for thread safety.
			string text = string.Join(Environment.NewLine, viewModel.ValidationMessages);

			// Clear so not accidentally shown again.
			viewModel.ValidationMessages = new List<string>();

			parentForm.BeginInvoke(new Action(() => MessageBox.Show(text, ResourceFormatter.ApplicationName)));
		}

		public void ShowAreYouSureYouWishToScanPopupIfNeeded(FileDeduplicationForm parentForm, FileDeduplicationViewModel viewModel)
		{
			if (parentForm == null) throw new NullException(() => parentForm);
			if (viewModel == null) throw new NullException(() => viewModel);

			if (string.IsNullOrWhiteSpace(viewModel.AreYouSureYouWishToScanPopupMessage))
			{
				return;
			}

			// Capture text for thread safety.
			string message = viewModel.AreYouSureYouWishToScanPopupMessage;

			// Clear so not accidentally shown again.
			viewModel.AreYouSureYouWishToScanPopupMessage = "";

			parentForm.BeginInvoke(
				new Action(
					() =>
					{
						DialogResult dialogResult = MessageBox.Show(message, ResourceFormatter.ApplicationName, MessageBoxButtons.OKCancel);

						switch (dialogResult)
						{
							case DialogResult.OK:
								AreYouSureYouWishToScanYesRequested?.Invoke(this, EventArgs.Empty);
								break;

							case DialogResult.Cancel:
								break;

							default:
								throw new ValueNotSupportedException(dialogResult);
						}
					}));

		}

		public void ShowAreYouSureYouWishToDeleteFilesPopupIfNeeded(FileDeduplicationForm parentForm, FileDeduplicationViewModel viewModel)
		{
			if (parentForm == null) throw new NullException(() => parentForm);
			if (viewModel == null) throw new NullException(() => viewModel);

			if (string.IsNullOrWhiteSpace(viewModel.AreYouSureYouWishToDeleteFilesPopupMessage))
			{
				return;
			}

			// Capture text for thread safety.
			string message = viewModel.AreYouSureYouWishToDeleteFilesPopupMessage;

			// Clear so not accidentally shown again.
			viewModel.AreYouSureYouWishToDeleteFilesPopupMessage = "";

			parentForm.BeginInvoke(
				new Action(
					() =>
					{
						DialogResult dialogResult = MessageBox.Show(message, ResourceFormatter.ApplicationName, MessageBoxButtons.OKCancel);

						switch (dialogResult)
						{
							case DialogResult.OK:
								AreYouSureYouWishToDeleteFilesYesRequested?.Invoke(this, EventArgs.Empty);
								break;

							case DialogResult.Cancel:
								break;

							default:
								throw new ValueNotSupportedException(dialogResult);
						}
					}));

		}
	}
}
