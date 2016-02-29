using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common.Exceptions
{
    public class FolderDoesNotExistException : Exception
    {
        private const string MESSAGE = "Folder '{0}' does not exist.";

        public FolderDoesNotExistException(string folderPath)
            : base(String.Format(MESSAGE, folderPath))
        { }
    }
}
