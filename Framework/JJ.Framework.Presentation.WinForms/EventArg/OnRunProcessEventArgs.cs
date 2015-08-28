using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Presentation.WinForms.EventArg
{
    public class OnRunProcessEventArgs : EventArgs
    {
        public string FilePath { get; set; }

        public OnRunProcessEventArgs()
        { }

        public OnRunProcessEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}
