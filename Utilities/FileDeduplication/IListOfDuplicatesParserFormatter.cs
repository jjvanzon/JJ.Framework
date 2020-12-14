using System.Collections.Generic;
using JJ.Framework.IO;

namespace JJ.Utilities.FileDeduplication
{
	public interface IListOfDuplicatesParserFormatter
	{
		string FormatDuplicateFilePairs(IList<DuplicateFilePair> duplicateFilePairs);
		IList<string> GetDuplicateFilePaths(string listOfDuplicatesString);
	}
}