using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JJ.Framework.Text;

namespace JJ.Framework.IO
{
	/// <inheritdoc />
	public class FileNameFilterer : IFileNameFilterer
	{
		/// <inheritdoc />
		public IList<string> Execute(IList<string> inputFilePaths, IList<string> pathsWithFileNamesToKeep)
		{
			if (inputFilePaths == null) throw new ArgumentNullException(nameof(inputFilePaths));
			if (pathsWithFileNamesToKeep == null) throw new ArgumentNullException(nameof(pathsWithFileNamesToKeep));

			IList<string> formattedFileNamesToKeep = FormatFileNames(pathsWithFileNamesToKeep);
			IList<string> outputList = new List<string>();

			foreach (string inputFilePath in inputFilePaths)
			{
				string formattedInputFileName = FormatFileName(inputFilePath);

				bool mustKeep = formattedFileNamesToKeep.Any(x => string.Equals(x, formattedInputFileName, StringComparison.Ordinal));

				if (mustKeep)
				{
					outputList.Add(inputFilePath);
				}
			}

			return outputList;
		}

		private IList<string> FormatFileNames(IList<string> paths)
			=> paths.Select(FormatFileName).ToList();

		private static string FormatFileName(string path)
			=> Path.GetFileName(FormatPath(path));

		private static string FormatPath(string path)
			=> (path ?? "").Trim()
			               .TrimStart(@"""")
			               .TrimEnd(@"""")
			               .ToLower();
	}
}
