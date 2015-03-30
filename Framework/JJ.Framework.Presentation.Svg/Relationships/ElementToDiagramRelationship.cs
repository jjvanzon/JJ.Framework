using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Elements;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Relationships
{
    internal class ElementToDiagramRelationship : ManyToOneRelationship<Element, Diagram>
    {
        public ElementToDiagramRelationship(Element element)
            : base(element)
        { }

        protected override bool Contains(Diagram diagram)
        {
            return diagram.Elements.Contains(_child);
        }

        protected override void Add(Diagram diagram)
        {
            diagram.Elements.Add(_child);
        }

        protected override void Remove(Diagram diagram)
        {
            diagram.Elements.Remove(_child);
        }
    }
}
