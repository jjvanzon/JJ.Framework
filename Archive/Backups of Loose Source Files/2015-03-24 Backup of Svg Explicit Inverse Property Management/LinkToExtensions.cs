using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.LinkTo
{
    internal static class LinkToExtensions
    {
        public static void LinkTo(this ElementBase child, ElementBase parent)
        {
            if (child == null) { throw new ArgumentNullException("child"); }

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

        public static void UnlinkParent(this ElementBase child)
        {
            if (child == null) { throw new ArgumentNullException("child"); }

            child.LinkTo((ElementBase)null);
        }
    }
}
