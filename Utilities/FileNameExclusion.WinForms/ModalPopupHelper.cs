using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	public class ModalPopupHelper : IModalPopupHelper
	{

		public void ShowValidationMessagesIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel)
		{
			if (parentForm == null) throw new ArgumentNullException(nameof(parentForm));
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

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

		public void ShowDonePopupMessageIfNeeded(Form parentForm, FileNameExclusionViewModel viewModel)
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
