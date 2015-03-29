using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg
{
    public class DiagramElements : IEnumerable<Element>
    {
        private Diagram _diagram;

        private IList<Element> _list = new List<Element>();

        internal DiagramElements(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);
            _diagram = diagram;
        }

        public void Add(Element element)
        {
            if (element == null) throw new NullException(() => element);

            if (_list.Contains(element)) return;

            if (element.Diagram != null)
            {
                if (element.Diagram.Elements.Contains(element))
                {
                    element.Diagram.Elements.Remove(element);
                }
            }

            _list.Add(element);

            element.Diagram = _diagram;

            // Side-effect: When added to the model, it is added as a child of the root rectangle.
            if (element.Parent == null)
            {
                if (element != _diagram.RootRectangle)
                {
                    element.Parent = _diagram.RootRectangle;
                }
            }
        }

        public void Remove(Element element)
        {
            if (element == null) throw new NullException(() => element);

            if (!_list.Contains(element)) return;

            _list.Remove(element);

            element.Diagram = null;
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
