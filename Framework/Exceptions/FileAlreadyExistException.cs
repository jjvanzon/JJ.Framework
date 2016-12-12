using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Exceptions
{
    public class FileAlreadyExistException : Exception
    {
        private const string MESSAGE = "File '{0}' already exists.";

        public FileAlreadyExistException(string filePath)
            : base(String.Format(MESSAGE, filePath))
        { }
    }
}
