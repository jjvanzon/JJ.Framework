using System.Collections.Generic;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	/// <summary>
	/// This utility class aims to take a list of file paths, then exclude certain file names, generating a new list. There is some lenience towards formatting. The paths can be surrounded by double quotes (") and white space. The list of file names to exclude can be both full paths or just the file names.
	/// </summary>
	public interface IFileNameExcluder
	{
		IList<string> Run(IList<string> inputFilePaths, IList<string> fileNamesToExclude);
	}
}