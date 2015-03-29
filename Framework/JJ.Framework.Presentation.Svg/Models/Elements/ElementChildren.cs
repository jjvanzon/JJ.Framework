using JJ.Framework.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class ElementChildren : IEnumerable<Element>
    {
        private Element _parent;
        private IList<Element> _list = new List<Element>();

        internal ElementChildren(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);
            _parent = parent;
        }

        public void Add(Element child)
        {
            if (child == null) throw new NullException(() => child);

            // Side- effect
            if (_parent.Diagram == null)
            {
                throw new Exception("To add a child the parent must be part of a diagram.");
            }

            if (_list.Contains(child)) return;

            if (child.Parent != null)
            {
                if (child.Parent.Children.Contains(child))
                {
                    child.Parent.Children.Remove(child);
                }
            }

            _list.Add(child);

            child.Parent = _parent;

            // Side-effect: added children are made part of the same Diagram as the parent.
            child.Diagram = _parent.Diagram;
        }

        public void Remove(Element child)
        {
            if (child == null) throw new NullException(() => child);

            if (!_list.Contains(child)) return;

            _list.Remove(child);

            child.Parent = null;

            // Side-effect: orphaned children are added to the Diagram's root rectangle.
            if (child != child.Diagram.RootRectangle)
            {
                child.Diagram.RootRectangle.Children.Add(child);
            }
        }

        [DebuggerHidden]
        public bool Contains(Element child)
        {
            return _list.Contains(child);
        }

        // IEnumerable

        [DebuggerHidden]
        public IEnumerator<Element> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
