using JJ.Framework.IO;
using System.Collections.Generic;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public interface IListOfDuplicatesParserFormatter
	{
		string FormatDuplicateFilePairs(IList<DuplicateFilePair> duplicateFilePairs);
		IList<string> GetDuplicateFilePaths(string listOfDuplicatesString);
	}
}