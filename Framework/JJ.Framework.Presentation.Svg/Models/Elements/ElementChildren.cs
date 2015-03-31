using JJ.Framework.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using JJ.Framework.Presentation.Svg.Relationships;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class ElementChildren : IEnumerable<Element>
    {
        private Element _parent;
        private IList<Element> _list;

        private ParentToChildrenRelationship _childrenRelationship;

        internal ElementChildren(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            _parent = parent;
            _list = new List<Element>();

            _childrenRelationship = new ParentToChildrenRelationship(_parent, _list);
        }

        public void Add(Element child)
        {
            if (child == null) throw new NullException(() => child);

            // Side-effect
            if (_parent.Diagram == null)
            {
                throw new Exception("To add a child, the parent must be part of a diagram.");
            }

            _childrenRelationship.Add(child);

            // Side-effect: added children are made part of the same Diagram as the parent.
            child.Diagram = _parent.Diagram;
        }

        public void Remove(Element child)
        {
            _childrenRelationship.Remove(child);

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
