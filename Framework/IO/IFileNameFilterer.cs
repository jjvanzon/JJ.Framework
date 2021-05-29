using System.Collections.Generic;

namespace JJ.Framework.IO
{
    /// <summary>
    /// This utility class aims to take a list of file paths,
    /// then filter out only certain file names, generating a new list.
    /// 
    /// <para> There is some lenience towards formatting. The paths can be surrounded by double quotes (") and white space.
    /// The list of file names to keep can be both full paths or just the file names. </para>
    /// </summary>
    public interface IFileNameFilterer
    {
        /// <inheritdoc cref="IFileNameFilterer" />
        IList<string> Execute(IList<string> inputFilePaths, IList<string> pathsWithFileNamesToKeep);
    }
}