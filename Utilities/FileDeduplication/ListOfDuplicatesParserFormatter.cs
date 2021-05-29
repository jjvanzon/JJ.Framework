using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.IO;
using JJ.Framework.Text;

// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Utilities.FileDeduplication
{
    public class ListOfDuplicatesParserFormatter : IListOfDuplicatesParserFormatter
    {
        private const string DUPLICATE_FILE_PATH_PREFIX = "| ";

        public string FormatDuplicateFilePairs(IList<DuplicateFilePair> duplicateFilePairs)
            => string.Join(
                Environment.NewLine + Environment.NewLine,
                duplicateFilePairs.GroupBy(x => x.OriginalFilePath).Select(FormatGroupOfDuplicateFilePairs));

        private string FormatGroupOfDuplicateFilePairs(IEnumerable<DuplicateFilePair> duplicateFilePairs)
        {
            string separator = Environment.NewLine + DUPLICATE_FILE_PATH_PREFIX;
            string formattedDuplicates = DUPLICATE_FILE_PATH_PREFIX + string.Join(separator, duplicateFilePairs.Select(x => x.DuplicateFilePath));
            return duplicateFilePairs.First().OriginalFilePath + Environment.NewLine + formattedDuplicates;
        }

        /// <summary>
        /// Would convert a list of duplicates and the original file paths (one copy is deemed the original)
        /// in a specific format where duplicate file paths are prefixed with "| ".
        /// It would return the file paths deemed the duplicate files / files to delete.
        /// </summary>
        public IList<string> GetDuplicateFilePaths(string listOfDuplicatesString)
        {
            if (string.IsNullOrWhiteSpace(listOfDuplicatesString))
            {
                return new List<string>();
            }

            IList<string> split = listOfDuplicatesString.Split(Environment.NewLine);
            IList<string> duplicateFilePaths = split.Where(x => x.StartsWith(DUPLICATE_FILE_PATH_PREFIX))
                                                    .Select(x => x.TrimFirst(DUPLICATE_FILE_PATH_PREFIX))
                                                    .ToList();
            return duplicateFilePaths;
        }
    }
}
