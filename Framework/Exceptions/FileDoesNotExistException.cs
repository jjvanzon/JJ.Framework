using System;

namespace JJ.Framework.Exceptions
{
	public class FileDoesNotExistException : Exception
	{
		private const string MESSAGE_TEMPLATE = "File '{0}' does not exist.";

		public FileDoesNotExistException(string filePath)
			: base(string.Format(MESSAGE_TEMPLATE, filePath))
		{ }
	}
}
