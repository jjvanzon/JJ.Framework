using System;

namespace JJ.Framework.Exceptions.Files
{
	public class FolderDoesNotExistException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Folder '{0}' does not exist.";

		/// <summary>
		/// throw new FolderDoesNotExistException("C:\MyFolder")
		/// will have message: "Folder 'C:\MyFolder' does not exist."
		/// </summary>
		public FolderDoesNotExistException(string folderPath)
			: base(string.Format(MESSAGE_TEMPLATE, folderPath))
		{ }
	}
}
