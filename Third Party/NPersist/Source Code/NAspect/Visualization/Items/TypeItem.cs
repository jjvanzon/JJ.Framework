using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.NAspect.Visualization.Items
{
    public class TypeItem : ItemBase
    {

        public TypeItem(Type type)
            : base(type.FullName)
        {
            this.ImageIndex = 1;

            this.SubItems.Add(type.Assembly.GetName().Name);
        }

        private Type type;
        public virtual Type Type
        {
            get { return type; }
            set { type = value; }
        }
	
        public override object Object
        {
            get
            {
                return type;
            }
        }

        public override void Refresh()
        {
            this.Text = type.FullName;
            this.SubItems[0].Text = type.Assembly.GetName().Name;

            base.Refresh();
        }
    }
}
