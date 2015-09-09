using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;
using JJ.Framework.Reflection.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class DiagramElements : IEnumerable<Element>
    {
        private IList<Element> _elements = new List<Element>();

        private DiagramToElementsRelationship _relationship;

        internal DiagramElements(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _relationship = new DiagramToElementsRelationship(diagram, _elements);
        }

        [DebuggerHidden]
        public int Count
        {
            get { return _elements.Count; }
        }

        public void Add(Element element)
        {
            ISideEffect sideEffect = new SideEffect_VerifyNoParentChildRelationShips_WhenSettingDiagram(element);
            sideEffect.Execute();

            _relationship.Add(element);
        }

        public void Remove(Element element)
        {
            ISideEffect sideEffect = new SideEffect_VerifyNoParentChildRelationShips_WhenSettingDiagram(element);
            sideEffect.Execute();

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
