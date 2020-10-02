using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.IO
{
	[PublicAPI]
	public interface IFileDeduplicator
	{
		IList<FileDeduplicator.FilePair> Scan(string folderPath, bool recursive, string filePattern = "*.*", Action<string> progressCallback = null, Func<bool> cancelCallback = null);
	}
}