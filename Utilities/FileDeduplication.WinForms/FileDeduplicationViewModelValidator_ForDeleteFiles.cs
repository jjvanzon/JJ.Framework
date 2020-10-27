using System;
using JJ.Framework.Resources;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	internal class FileDeduplicationViewModelValidator_ForDeleteFiles : VersatileValidator
	{
		public FileDeduplicationViewModelValidator_ForDeleteFiles(FileDeduplicationViewModel viewModel)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
			For(viewModel.ListOfDuplicates, CommonResourceFormatter.ListOf_WithName(ResourceFormatter.Duplicates)).NotNullOrWhiteSpace();
		}
	}
}
