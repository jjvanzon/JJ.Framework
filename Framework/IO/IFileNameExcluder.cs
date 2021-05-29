using System.Collections.Generic;

namespace JJ.Framework.IO
{
    /// <summary>
    /// <para> This utility class aims to take a list of file paths,
    /// then exclude certain file names, generating a new list. </para>
    /// 
    /// <para> There is some lenience towards formatting. The paths can be surrounded by double quotes (") and white space.
    /// The list of file names to exclude can be both full paths or just the file names. </para>
    /// </summary>
    public interface IFileNameExcluder
    {
        /// <inheritdoc cref="IFileNameExcluder" />
        IList<string> Execute(IList<string> inputFilePaths, IList<string> pathsWithFileNamesToExclude);
    }
}