using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;
using JJ.Framework.Reflection.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class DiagramElements : IEnumerable<Element>
    {
        private readonly Diagram _diagram;
        private readonly IList<Element> _elements = new List<Element>();

        private DiagramToElementsRelationship _relationship;

        internal DiagramElements(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;

            _relationship = new DiagramToElementsRelationship(diagram, _elements);
        }

        [DebuggerHidden]
        public int Count
        {
            get { return _elements.Count; }
        }

        public void Add(Element element)
        {
            ISideEffect sideEffect = new SideEffect_VerifyNoParentChildRelationShips_UponSettingDiagram(element);
            sideEffect.Execute();

            _relationship.Add(element);
        }

        public void Remove(Element element)
        {
            if (element == _diagram.Background)
            {
                throw new Exception("Cannot remove Background Element from Diagram.");
            }

            ISideEffect sideEffect = new SideEffect_VerifyNoParentChildRelationShips_UponSettingDiagram(element);
            sideEffect.Execute();

            _relationship.Remove(element);
        }

        [DebuggerHidden]
        public bool Contains(Element element)
        {
            return _elements.Contains(element);
        }

        public void Clear()
        {
            foreach (Element element in _elements.ToArray())
            {
                if (element == _diagram.Background)
                {
                    continue;
                }

                Remove(element);
            }
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
