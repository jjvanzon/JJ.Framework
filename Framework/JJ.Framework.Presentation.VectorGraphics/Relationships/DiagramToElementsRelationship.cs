using JJ.Framework.Business;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System.Collections.Generic;

namespace JJ.Framework.Presentation.VectorGraphics.Relationships
{
    internal class DiagramToElementsRelationship : OneToManyRelationship<Diagram, Element>
    {
        public DiagramToElementsRelationship(Diagram diagram, IList<Element> elements)
            : base(diagram, elements)
        { }

        protected override void SetParent(Element element)
        {
            element.Diagram = _parent;
        }

        protected override void NullifyParent(Element element)
        {
            element.Diagram = null;
        }
    }
}
