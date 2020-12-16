using System;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameFilter
{
	internal class FileNameFilterViewModelValidator : VersatileValidator
	{
		public FileNameFilterViewModelValidator(FileNameFilterViewModel viewModel)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			For(viewModel.InputList, ResourceFormatter.InputList).NotNullOrWhiteSpace();
			For(viewModel.ListOfFileNamesToKeep, ResourceFormatter.ListOfFileNamesToKeep).NotNullOrWhiteSpace();
		}
	}
}
