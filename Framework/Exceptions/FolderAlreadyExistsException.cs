using System;

namespace JJ.Framework.Exceptions
{
    public class FolderAlreadyExistsException : Exception
    {
        private const string MESSAGE = "Folder '{0}' already exists.";

        public FolderAlreadyExistsException(string filePath)
            : base(String.Format(MESSAGE, filePath))
        { }
    }
}
