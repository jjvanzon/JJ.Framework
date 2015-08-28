using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Presentation.WinForms.EventArg
{
    public class PageNumberEventArgs : EventArgs
    {
        public int PageNumber { get; private set; }

        public PageNumberEventArgs(int pageNumber)
        {
            PageNumber = pageNumber;
        }
    }
}
