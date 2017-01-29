using System;

namespace JJ.Framework.Exceptions
{
    public class FolderAlreadyExistsException : Exception
    {
        private const string MESSAGE = "Folder '{0}' already exists.";

        public FolderAlreadyExistsException(string filePath)
            : base(string.Format(MESSAGE, filePath))
        { }
    }
}
