using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Presentation.Svg.LinkTo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class SvgChildren : SpecializedList<ElementBase>
    {
        private ElementBase _parent;

        internal ElementBase Parent { get; set; }

        public SvgChildren()
        { }

        public SvgChildren(IEnumerable<ElementBase> collection)
        {
            foreach (ElementBase item in collection)
            {
                Add(item);
            }
        }

        public override void Add(ElementBase item)
        {
            item.LinkTo(_parent);
        }

        public override bool Remove(ElementBase item)
        {
            bool ret = false;
            if (Contains(item))
            {
                ret = true;
                item.UnlinkParent();
            }
            return ret;
        }

        public override void Clear()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                Remove(this[i]);
            }
        }

        public override void AddRange(IEnumerable<ElementBase> collection)
        {
            if (collection == null) throw new NullException(() => collection);

            foreach (ElementBase item in collection)
            {
                Add(item);
            }
        }

        public override void Insert(int index, ElementBase item)
        {
            throw new NotSupportedException();
        }

        public override void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public override ElementBase this[int index]
        {
            get { return base[index]; }
            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
