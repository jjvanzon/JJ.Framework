using JJ.Framework.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class Children : IEnumerable<ElementBase>
    {
        private ElementBase _parent;
        private IList<ElementBase> _list = new List<ElementBase>();

        internal Children(ElementBase parent)
        {
            if (parent == null) throw new NullException(() => parent);
            _parent = parent;
        }

        // TODO: Inverse property management may not be required anymore if everything goes through the SvgManager.

        internal void Add(ElementBase child)
        {
            if (child == null) throw new NullException(() => child);

            // Return if nothing changes.
            if (child.Parent == _parent) return;

            // Remove the old relationship.
            if (child.Parent != null)
            {
                child.Parent.Children.Remove(child);
            }

            // Create the new relationship.
            child.Parent = _parent;
            _list.Add(child);
        }

        internal void Remove(ElementBase child)
        {
            if (child == null) throw new NullException(() => child);

            // Return if nothing changes.
            if (child.Parent != _parent) return;

            // Remove relationship.
            _list.Remove(child);
            child.Parent = null;
        }

        internal void Contains(ElementBase child)
        {
            _list.Contains(child);
        }

        // IEnumerable

        public IEnumerator<ElementBase> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
