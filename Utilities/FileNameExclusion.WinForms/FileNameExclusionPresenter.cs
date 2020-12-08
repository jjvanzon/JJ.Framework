using System;
using System.Collections.Generic;
using JJ.Framework.Text;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	public class FileNameExclusionPresenter
	{
		private readonly IFileNameExcluder _fileNameExcluder;

		public FileNameExclusionPresenter(IFileNameExcluder fileNameExcluder)
			=> _fileNameExcluder = fileNameExcluder;

		public FileNameExclusionViewModel ViewModel { get; } = new FileNameExclusionViewModel();

		public void RunProcess()
		{
			IValidator validator = new FileNameExclusionViewModelValidator(ViewModel);

			if (!validator.IsValid)
			{
				ViewModel.ValidationMessages = validator.Messages;
				return;
			}

			IList<string> inputListSplit = ViewModel.InputList.Split(Environment.NewLine);
			IList<string> exclusionListSplit = ViewModel.ExclusionList.Split(Environment.NewLine);

			IList<string> outputList = _fileNameExcluder.Run(inputListSplit, exclusionListSplit);

			ViewModel.OutputList = string.Join(Environment.NewLine, outputList);
		}
	}
}
