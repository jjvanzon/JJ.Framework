using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.WinForms
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
