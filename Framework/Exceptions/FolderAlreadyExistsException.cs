using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
