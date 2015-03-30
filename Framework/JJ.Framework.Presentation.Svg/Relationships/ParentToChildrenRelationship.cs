using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Relationships
{
    internal class ParentToChildrenRelationship : OneToManyRelationship<Element, Element>
    {
        public ParentToChildrenRelationship(Element parent, ICollection<Element> children)
            : base(parent, children)
        { }

        protected override void SetParent(Element child)
        {
            child.Parent = _parent;
        }

        protected override void NullifyParent(Element child)
        {
            child.Parent = null;
        }
    }
}
