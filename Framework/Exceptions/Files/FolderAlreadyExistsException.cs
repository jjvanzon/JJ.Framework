using System;

namespace JJ.Framework.Exceptions.Files
{
	public class FolderAlreadyExistsException : Exception
	{
		private const string MESSAGE_TEMPLATE = "Folder '{0}' already exists.";

		/// <summary>
		/// throw new FolderAlreadyExistsException("C:\MyFolder")
		/// will have message: "Folder 'C:\MyFolder' already exists."
		/// </summary>
		public FolderAlreadyExistsException(string folderPath)
			: base(string.Format(MESSAGE_TEMPLATE, folderPath))
		{ }
	}
}
