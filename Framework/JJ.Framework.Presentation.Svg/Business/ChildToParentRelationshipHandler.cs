using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Business
{
    internal class ChildToParentRelationshipHandler : ManyToOneRelationshipHandler<Element, Element>
    {
        public ChildToParentRelationshipHandler(Element child)
            : base(child)
        { }

        protected override bool Contains(Element parent, Element child)
        {
            return parent.Children.Contains(child);
        }

        protected override void Add(Element parent, Element child)
        {
            parent.Children.Add(child);
        }

        protected override void Remove(Element parent, Element child)
        {
            parent.Children.Remove(child);
        }
    }
}
