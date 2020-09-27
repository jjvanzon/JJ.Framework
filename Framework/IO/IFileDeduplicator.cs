using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.IO
{
	[PublicAPI]
	public interface IFileDeduplicator
	{
		IList<FileDeduplicator.FilePair> Analyze(string folderPath, bool recursive, Action<string> progressCallback = null, Func<bool> cancelCallback = null);
	}
}