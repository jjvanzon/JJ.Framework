using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.LinkTo
{
    internal static class LinkToExtensions
    {
        public static void LinkTo(this Element child, Element parent)
        {
            if (child == null) throw new NullException(() => child);

            if (child.Parent != null)
            {
                if (child.Parent.Children.Contains(child))
                {
                    child.Parent.Children.Remove(child);
                }
            }

            child.Parent = parent;

            if (child.Parent != null)
            {
                if (!child.Parent.Children.Contains(child))
                {
                    child.Parent.Children.Add(child);
                }
            }
        }

        public static void LinkTo(this Element element, SvgModel svgModel)
        {
            if (element == null) throw new NullException(() => element);

            if (element.SvgModel != null)
            {
                if (element.SvgModel.Elements.Contains(element))
                {
                    element.SvgModel.Elements.Remove(element);
                }
            }

            element.SvgModel = svgModel;

            if (element.SvgModel != null)
            {
                if (!element.SvgModel.Elements.Contains(element))
                {
                    element.SvgModel.Elements.Add(element);
                }
            }
        }
    }
}
