using JJ.Framework.Presentation.Svg.Models.Elements;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Svg.LinkTo
{
    internal static class UnlinkExtensions
    {
        public static void UnlinkParent(this Element element)
        {
            if (element == null) throw new NullException(() => element);
            element.LinkTo((Element)null);
        }

        public static void UnlinkSvgModel(this Element element)
        {
            if (element == null) throw new NullException(() => element);
            element.LinkTo((SvgModel)null);
        }
    }
}