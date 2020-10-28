using JJ.Framework.IO;
using System.Collections.Generic;

namespace JJ.Utilities.FileDeduplication.WinForms
{
	public interface IListOfDuplicatesParserFormatter
	{
		string FormatFilePairs(IList<FileDeduplicator.FilePair> filePairs);
		IList<string> GetDuplicateFilePaths(string listOfDuplicatesString);
	}
}