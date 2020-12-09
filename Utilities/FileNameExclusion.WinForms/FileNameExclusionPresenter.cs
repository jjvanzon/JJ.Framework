using System;
using System.Collections.Generic;
using JJ.Framework.Resources;
using JJ.Framework.Text;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	public class FileNameExclusionPresenter
	{
		private readonly IFileNameExcluder _fileNameExcluder;

		public FileNameExclusionPresenter(IFileNameExcluder fileNameExcluder)
			=> _fileNameExcluder = fileNameExcluder;

		public FileNameExclusionViewModel ViewModel { get; } = CreateEmptyViewModel();

		public void RunProcess()
		{
			ClearMessages(ViewModel);

			IValidator validator = new FileNameExclusionViewModelValidator(ViewModel);

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
			IList<string> exclusionListSplit = ViewModel.ExclusionList.Split(Environment.NewLine);

			IList<string> outputList = _fileNameExcluder.Run(inputListSplit, exclusionListSplit);

			ViewModel.OutputList = string.Join(Environment.NewLine, outputList);
			ViewModel.DonePopupMessage = CommonResourceFormatter.Done;
		}

		private static FileNameExclusionViewModel CreateEmptyViewModel()
			=> new FileNameExclusionViewModel
			{
				DonePopupMessage = "",
				ValidationMessages = new List<string>()
			};

		private static void ClearMessages(FileNameExclusionViewModel viewModel)
		{
			viewModel.DonePopupMessage = "";
			viewModel.ValidationMessages = new List<string>();
		}
	}
}
