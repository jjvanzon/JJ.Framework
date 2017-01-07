using System;

namespace JJ.Framework.Exceptions
{
    public class FileDoesNotExistException : Exception
    {
        private const string MESSAGE = "File '{0}' does not exist.";

        public FileDoesNotExistException(string filePath)
            : base(String.Format(MESSAGE, filePath))
        { }
    }
}
