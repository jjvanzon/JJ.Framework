using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Puzzle.NAspect.Visualization.Items
{
    public class ItemBase : ListViewItem
    {
        public ItemBase(string text)
            : base(text)
        {
            ;
        }

        public virtual object Object
        {
            get { return null; }
        }

        public virtual void Refresh()
        {
            ;
        }
    }
}
