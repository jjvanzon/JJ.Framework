using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JJ.Framework.Text;

namespace JJ.Utilities.FileNameExclusion
{
	/// <inheritdoc />
	public class FileNameExcluder : IFileNameExcluder
	{
		public IList<string> Run(IList<string> inputFilePaths, IList<string> fileNamesToExclude)
		{
			if (inputFilePaths == null) throw new ArgumentNullException(nameof(inputFilePaths));
			if (fileNamesToExclude == null) throw new ArgumentNullException(nameof(fileNamesToExclude));

			IList<string> formattedExclusionList = FormatExclusionList(fileNamesToExclude);
			IList<string> outputList = new List<string>();

			foreach (string inputFilePath in inputFilePaths)
			{
				string inputFileName = GetInputFileName(inputFilePath);

				bool isExcluded =
					formattedExclusionList.Any(x => string.Equals(x, inputFileName, StringComparison.OrdinalIgnoreCase));

				if (!isExcluded)
				{
					outputList.Add(inputFilePath);
				}
			}

			return outputList;
		}

		private IList<string> FormatExclusionList(IList<string> list)
			=> list.Select(x => Path.GetFileName(FormatPath(x))).ToList();

		private static string GetInputFileName(string inputFilePath)
			=> Path.GetFileName(FormatPath(inputFilePath));

		private static string FormatPath(string inputFilePath)
			=> inputFilePath.Trim()
							.TrimStart(@"""")
							.TrimEnd(@"""");
	}
}
