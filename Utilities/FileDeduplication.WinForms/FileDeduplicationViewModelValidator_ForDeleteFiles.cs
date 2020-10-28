using System;
using System.Collections.Generic;
using JJ.Framework.Resources;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	internal class FileDeduplicationViewModelValidator_ForDeleteFiles : VersatileValidator
	{
		public FileDeduplicationViewModelValidator_ForDeleteFiles(
			FileDeduplicationViewModel viewModel,
			IListOfDuplicatesParserFormatter listOfDuplicatesParserFormatter)
		{
			if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
			if (listOfDuplicatesParserFormatter == null) throw new ArgumentNullException(nameof(listOfDuplicatesParserFormatter));

			IList<string> duplicateFilePaths = listOfDuplicatesParserFormatter.GetDuplicateFilePaths(viewModel.ListOfDuplicates);

			For(duplicateFilePaths, CommonResourceFormatter.ListOf_WithName(ResourceFormatter.Duplicates)).CollectionNotEmpty();
		}
	}
}
