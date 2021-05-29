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

            IList<string> formattedFileNamesToExclude = FormatFileNames(pathsWithFileNamesToExclude);
            IList<string> outputList = new List<string>();

            foreach (string inputFilePath in inputFilePaths)
            {
                string formattedInputFileName = FormatFileName(inputFilePath);

                bool isExcluded = formattedFileNamesToExclude.Any(x => string.Equals(x, formattedInputFileName, StringComparison.Ordinal));

                if (!isExcluded)
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
