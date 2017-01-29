using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Relationships;
using JJ.Framework.Presentation.VectorGraphics.SideEffects;
using JJ.Framework.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class DiagramElements : IEnumerable<Element>
    {
        private readonly Diagram _diagram;
        private readonly IList<Element> _elements = new List<Element>();

        private readonly DiagramToElementsRelationship _relationship;

        internal DiagramElements(Diagram diagram)
        {
            if (diagram == null) throw new NullException(() => diagram);

            _diagram = diagram;

            _relationship = new DiagramToElementsRelationship(diagram, _elements);
        }

        [DebuggerHidden]
        public int Count => _elements.Count;

        public void Add(Element element)
        {
            ISideEffect sideEffect = new SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram(element);
            sideEffect.Execute();

            _relationship.Add(element);
        }

        public void Remove(Element element)
        {
            ISideEffect sideEffect1 = new SideEffect_AssertCannotRemoveBackgroundFromDiagram(element);
            sideEffect1.Execute();

            ISideEffect sideEffect2 = new SideEffect_AssertNoParentChildRelationShips_UponSettingDiagram(element);
            sideEffect2.Execute();

            _relationship.Remove(element);
        }

        [DebuggerHidden]
        public bool Contains(Element element) => _elements.Contains(element);

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
        public IEnumerator<Element> GetEnumerator() => _elements.GetEnumerator();

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();
    }
}
