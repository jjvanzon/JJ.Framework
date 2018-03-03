using System;

namespace JJ.Framework.IO
{
	public class FileLockException : Exception
	{
		public FileLockException(Exception innerException)
			: base("Failed to lock file.", innerException)
		{ }
	}
}
