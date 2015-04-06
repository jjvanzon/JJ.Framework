using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Presentation.Svg.Relationships;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    public class DiagramElements : IEnumerable<Element>
    {
        private Diagram _diagram;

        private IList<Element> _elements = new List<Element>();

        private DiagramToElementsRelationship _relationship;

        internal DiagramElements(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;
            _relationship = new DiagramToElementsRelationship(diagram, _elements);
        }

        public int Count
        {
            get { return _elements.Count; }
        }

        public void Add(Element element)
        {
            _relationship.Add(element);

            // Side-effect: When added to the model, it is added as a child of the root rectangle.
            if (element.Parent == null)
            {
                if (element != _diagram.Canvas)
                {
                    element.Parent = _diagram.Canvas;
                }
            }
        }

        public void Remove(Element element)
        {
            _relationship.Remove(element);
        }

        [DebuggerHidden]
        public bool Contains(Element child)
        {
            return _elements.Contains(child);
        }

        // IEnumerable

        [DebuggerHidden]
        public IEnumerator<Element> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }
}
