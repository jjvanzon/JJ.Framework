﻿using System;
using System.Collections.Generic;
using JJ.Framework.ResourceStrings;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileDeduplication
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

            if (duplicateFilePaths.Count == 0)
            {
                Messages.Add(ResourceFormatter.MaybeDoFirst_WithName(CommonResourceFormatter.Scan));
            }
        }
    }
}
