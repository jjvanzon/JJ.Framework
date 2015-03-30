using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Elements;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Relationships
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
