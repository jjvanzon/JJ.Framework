using System;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	internal class FileNameExclusionViewModelValidator : VersatileValidator
	{
		public FileNameExclusionViewModelValidator(FileNameExclusionViewModel viewModel)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

			For(viewModel.InputList, ResourceFormatter.InputList).NotNullOrWhiteSpace();
			For(viewModel.ExclusionList, ResourceFormatter.ExclusionList).NotNullOrWhiteSpace();
		}
	}
}
