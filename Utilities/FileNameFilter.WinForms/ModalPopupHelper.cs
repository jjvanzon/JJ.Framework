using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JJ.Framework.Exceptions.InvalidValues;

namespace JJ.Utilities.FileNameFilter.WinForms
{
	public class ModalPopupHelper : IModalPopupHelper
	{
		public event EventHandler AreYouSureOkRequested;

		public void ShowValidationMessagesIfNeeded(Form parentForm, FileNameFilterViewModel viewModel)
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

		public void ShowAreYouSureQuestionIfNeeded(Form parentForm, FileNameFilterViewModel viewModel)
		{
			if (parentForm == null) throw new ArgumentNullException(nameof(parentForm));
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			if (string.IsNullOrWhiteSpace(viewModel.AreYouSureQuestion))
			{
				return;
			}

			// Capture text for thread safety.
			string message = viewModel.AreYouSureQuestion;

			// Clear so not accidentally shown again.
			viewModel.AreYouSureQuestion = "";

			parentForm.BeginInvoke(
				new Action(
					() =>
					{
						DialogResult dialogResult = MessageBox.Show(message, ResourceFormatter.ApplicationName, MessageBoxButtons.OKCancel);

						switch (dialogResult)
						{
							case DialogResult.OK:
								AreYouSureOkRequested?.Invoke(this, EventArgs.Empty);
								break;

							case DialogResult.Cancel:
								break;

							default:
								throw new ValueNotSupportedException(dialogResult);
						}
					}));
		}

		public void ShowDonePopupMessageIfNeeded(Form parentForm, FileNameFilterViewModel viewModel)
		{
			if (parentForm == null) throw new ArgumentNullException(nameof(parentForm));
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			if (string.IsNullOrWhiteSpace(viewModel.DonePopupMessage))
			{
				return;
			}

			// Capture text for thread safety.
			string message = viewModel.DonePopupMessage;

			// Clear so not accidentally shown again.
			viewModel.DonePopupMessage = "";

			parentForm.BeginInvoke(
				new Action(() => MessageBox.Show(message, ResourceFormatter.ApplicationName)));

		}
	}
}
