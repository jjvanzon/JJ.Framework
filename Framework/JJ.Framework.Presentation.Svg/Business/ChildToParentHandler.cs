using JJ.Framework.Business;
using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.Business
{
    internal class ChildToParentHandler : ManyToOneHandler<Element>
    {
        private Element _child;

        public ChildToParentHandler(Element child)
        {
            if (child == null) throw new NullException(() => child);

            _child = child;
        }

        protected override bool Contains(Element parent)
        {
            return parent.Children.Contains(_child);
        }

        protected override void Add(Element parent)
        {
            parent.Children.Add(_child);
        }

        protected override void Remove(Element parent)
        {
            parent.Children.Remove(_child);
        }
    }
}
