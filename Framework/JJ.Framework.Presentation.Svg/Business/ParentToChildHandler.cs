using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Business
{
    internal class ParentToChildHandler : OneToManyHandler<Element>
    {
        private Element _parent;

        public ParentToChildHandler(Element parent)
        {
            if (parent == null) throw new NullException(() => parent);

            _parent = parent;
        }

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
