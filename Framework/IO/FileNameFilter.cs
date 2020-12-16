using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JJ.Framework.Text;

namespace JJ.Framework.IO
{
	/// <inheritdoc />
	public class FileNameFilter : IFileNameFilter
	{
		/// <inheritdoc />
		public IList<string> Execute(IList<string> inputFilePaths, IList<string> pathsWithFileNamesToKeep)
		{
			if (inputFilePaths == null) throw new ArgumentNullException(nameof(inputFilePaths));
			if (pathsWithFileNamesToKeep == null) throw new ArgumentNullException(nameof(pathsWithFileNamesToKeep));

			throw new System.NotImplementedException();
		}

		private IList<string> GetFileNamesToKeep(IList<string> pathsWithFileNamesToExclude)
			=> pathsWithFileNamesToExclude.Select(x => Path.GetFileName(FormatPath(x))).ToList();

		private static string GetInputFileName(string inputFilePath)
			=> Path.GetFileName(FormatPath(inputFilePath));

		private static string FormatPath(string inputFilePath)
			=> inputFilePath.Trim()
							.TrimStart(@"""")
							.TrimEnd(@"""");
	}
}
