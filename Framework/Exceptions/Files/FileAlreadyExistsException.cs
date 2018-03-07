using System;

namespace JJ.Framework.Exceptions.Files
{
	public class FileAlreadyExistsException : Exception
	{
		private const string MESSAGE_TEMPLATE = "File '{0}' already exists.";

		/// <summary>
		/// throw new FileAlreadyExistsException("test.txt")
		/// will have message: "File 'test.txt' already exists."
		/// </summary>
		public FileAlreadyExistsException(string filePath)
			: base(string.Format(MESSAGE_TEMPLATE, filePath))
		{ }
	}
}
