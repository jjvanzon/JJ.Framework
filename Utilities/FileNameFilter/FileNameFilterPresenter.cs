using System;
using System.Collections.Generic;
using JJ.Framework.IO;
using JJ.Framework.ResourceStrings;
using JJ.Framework.Text;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameFilter
{
	public class FileNameFilterPresenter
	{
		private readonly IFileNameFilterer _fileNameFilterer;

		public FileNameFilterPresenter(IFileNameFilterer fileNameFilterer)
			=> _fileNameFilterer = fileNameFilterer;

		public FileNameFilterViewModel ViewModel { get; } = CreateEmptyViewModel();

		// Actions

		public void RunProcess()
		{
			ClearMessages(ViewModel);

			IValidator validator = new FileNameFilterViewModelValidator(ViewModel);
			if (!validator.IsValid)
			{
				ViewModel.ValidationMessages = validator.Messages;
				return;
			}

			if (!string.IsNullOrWhiteSpace(ViewModel.OutputList))
			{
				ViewModel.AreYouSureQuestion = CommonResourceFormatter.AreYouSure;
			}
			else
			{
				AreYouSureYes();
			}
		}

		public void AreYouSureYes()
		{
			IList<string> inputListSplit = ViewModel.InputList.Split(Environment.NewLine);
			IList<string> fileNamesToKeepSplit = ViewModel.FileNamesToKeep.Split(Environment.NewLine);

			IList<string> outputList = _fileNameFilterer.Execute(inputListSplit, fileNamesToKeepSplit);

			ViewModel.OutputList = string.Join(Environment.NewLine, outputList);
			ViewModel.DonePopupMessage = CommonResourceFormatter.Done;
		}

		// Helpers

		private static FileNameFilterViewModel CreateEmptyViewModel()
			=> new FileNameFilterViewModel
			{
				DonePopupMessage = "",
				ValidationMessages = new List<string>()
			};

		private static void ClearMessages(FileNameFilterViewModel viewModel)
		{
			viewModel.DonePopupMessage = "";
			viewModel.ValidationMessages = new List<string>();
		}
	}
}
