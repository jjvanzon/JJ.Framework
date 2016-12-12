using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common.Exceptions
{
    public class FileDoesNotExistException : Exception
    {
        private const string MESSAGE = "File '{0}' does not exist.";

        public FileDoesNotExistException(string filePath)
            : base(String.Format(MESSAGE, filePath))
        { }
    }
}
