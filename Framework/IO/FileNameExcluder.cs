using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JJ.Framework.Text;

namespace JJ.Framework.IO
{
	/// <inheritdoc />
	public class FileNameExcluder : IFileNameExcluder
	{
		/// <inheritdoc />
		public IList<string> Execute(IList<string> inputFilePaths, IList<string> pathsWithFileNamesToExclude)
		{
			if (inputFilePaths == null) throw new ArgumentNullException(nameof(inputFilePaths));
			if (pathsWithFileNamesToExclude == null) throw new ArgumentNullException(nameof(pathsWithFileNamesToExclude));

			IList<string> formattedFileNamesToExclude = GetFileNamesToExclude(pathsWithFileNamesToExclude);
			IList<string> outputList = new List<string>();

			foreach (string inputFilePath in inputFilePaths)
			{
				string inputFileName = GetInputFileName(inputFilePath);

				bool isExcluded =
					formattedFileNamesToExclude.Any(x => string.Equals(x, inputFileName, StringComparison.OrdinalIgnoreCase));

				if (!isExcluded)
				{
					outputList.Add(inputFilePath);
				}
			}

			return outputList;
		}

		private IList<string> GetFileNamesToExclude(IList<string> pathsWithFileNamesToExclude)
			=> pathsWithFileNamesToExclude.Select(x => Path.GetFileName(FormatPath(x))).ToList();

		private static string GetInputFileName(string inputFilePath)
			=> Path.GetFileName(FormatPath(inputFilePath));

		private static string FormatPath(string inputFilePath)
			=> inputFilePath.Trim()
							.TrimStart(@"""")
							.TrimEnd(@"""");
	}
}
