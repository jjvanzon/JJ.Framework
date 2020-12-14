using System;
using JJ.Framework.Resources;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileDeduplication
{
	internal class FileDeduplicationViewModelValidator_ForScan : VersatileValidator
	{
		public FileDeduplicationViewModelValidator_ForScan(FileDeduplicationViewModel viewModel)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
			For(viewModel.FolderPath, CommonResourceFormatter.Folder).NotNullOrWhiteSpace().FolderExists();
		}
	}
}
