using System;

namespace JJ.Framework.Exceptions
{
    public class FolderDoesNotExistException : Exception
    {
        private const string MESSAGE = "Folder '{0}' does not exist.";

        public FolderDoesNotExistException(string folderPath)
            : base(string.Format(MESSAGE, folderPath))
        { }
    }
}
