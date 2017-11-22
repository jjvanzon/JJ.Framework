using System;

namespace JJ.Framework.IO
{
	/// <summary> Fully unit tested. </summary>
	public class FileLockException : Exception
	{
		public FileLockException(Exception innerException)
			: base("Failed to lock file.", innerException)
		{ }
	}
}
