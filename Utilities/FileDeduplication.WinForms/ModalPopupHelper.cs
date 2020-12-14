using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.InvalidValues;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public class ModalPopupHelper : IModalPopupHelper
	{
		public event EventHandler ScanYesRequested;
		public event EventHandler DeleteFilesYesRequested;

		public void ShowValidationMessagesIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel)
		{
			if (parentForm == null) throw new ArgumentNullException(nameof(parentForm));
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			if (viewModel.ValidationMessages.Count == 0)
			{
				return;
			}

			// Capture text for thread safety.
			string message = string.Join(Environment.NewLine, viewModel.ValidationMessages);

			// Clear so not accidentally shown again.
			viewModel.ValidationMessages = new List<string>();

			parentForm.BeginInvoke(new Action(() => MessageBox.Show(message, ResourceFormatter.ApplicationName)));
		}

		public void ShowScanQuestionIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel)
		{
			if (parentForm == null) throw new ArgumentNullException(nameof(parentForm));
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			if (string.IsNullOrWhiteSpace(viewModel.ScanQuestion))
			{
				return;
			}

			// Capture text for thread safety.
			string message = viewModel.ScanQuestion;

			// Clear so not accidentally shown again.
			viewModel.ScanQuestion = "";

			parentForm.BeginInvoke(
				new Action(
					() =>
					{
						DialogResult dialogResult = MessageBox.Show(message, ResourceFormatter.ApplicationName, MessageBoxButtons.OKCancel);

						switch (dialogResult)
						{
							case DialogResult.OK:
								ScanYesRequested?.Invoke(this, EventArgs.Empty);
								break;

							case DialogResult.Cancel:
								break;

							default:
								throw new ValueNotSupportedException(dialogResult);
						}
					}));

		}

		public void ShowDeleteFilesQuestionIfNeeded(Form parentForm, FileDeduplicationViewModel viewModel)
		{
			if (parentForm == null) throw new ArgumentNullException(nameof(parentForm));
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			if (string.IsNullOrWhiteSpace(viewModel.DeleteFilesQuestion))
			{
				return;
			}

			// Capture text for thread safety.
			string message = viewModel.DeleteFilesQuestion;

			// Clear so not accidentally shown again.
			viewModel.DeleteFilesQuestion = "";

			parentForm.BeginInvoke(
				new Action(
					() =>
					{
						DialogResult dialogResult = MessageBox.Show(message, ResourceFormatter.ApplicationName, MessageBoxButtons.OKCancel);

						switch (dialogResult)
						{
							case DialogResult.OK:
								DeleteFilesYesRequested?.Invoke(this, EventArgs.Empty);
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
