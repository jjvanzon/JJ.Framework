using System.Collections.Generic;

namespace JJ.Framework.IO
{
	public interface IFileNameFilter
	{
		/// <inheritdoc cref="IFileNameFilter" />
		IList<string> Execute(IList<string> inputFilePaths, IList<string> pathsWithFileNamesToKeep);
	}
}