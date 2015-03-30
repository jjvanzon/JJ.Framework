using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Business
{
    internal class ParentToChildrenRelationship : OneToManyHandler<Element>
    {
        private Element _parent;
        private IList<Element> _children;

        public ParentToChildrenRelationship(Element parent, IList<Element> children)
        {
            if (parent == null) throw new NullException(() => parent);
            if (children == null) throw new NullException(() => children);

            _parent = parent;
            _children = children;
        }

        protected override void OnSetParent(Element child)
        {
            child.Parent = _parent;
        }
    }
}
