using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.IO
{
	[PublicAPI]
	public interface IFileDeduplicator
	{
		/// <param name="callbackCount">
		/// The amount of times cancelCallback and progressCallback might be called,
		/// for instance to report progress percentage.
		/// Default may be 100, so with each percent processed, progress would be reported.
		/// </param>
		IList<FileDeduplicator.FilePair> Scan(
			string folderPath, bool recursive, string filePattern = "*.*", 
			Action<string> progressCallback = null, Func<bool> cancelCallback = null, long callbackCount = 100);
	}
}