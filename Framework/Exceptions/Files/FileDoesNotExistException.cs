using System;

namespace JJ.Framework.Exceptions.Files
{
	public class FileDoesNotExistException : Exception
	{
		private const string MESSAGE_TEMPLATE = "File '{0}' does not exist.";

		/// <summary>
		/// throw new FileDoesNotExistException("test.txt")
		/// will have message: "File 'test.txt' does not exist."
		/// </summary>
		public FileDoesNotExistException(string filePath)
			: base(string.Format(MESSAGE_TEMPLATE, filePath))
		{ }
	}
}
