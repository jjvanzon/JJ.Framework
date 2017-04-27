using System;

namespace JJ.Framework.Presentation.WinForms.EventArg
{
    public class FilePathEventArgs : EventArgs
    {
        public string FilePath { get; }

        public FilePathEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}
