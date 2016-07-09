using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Presentation.VectorGraphics.Helpers
{
    internal static class CloneExtensions
    {
        public static BackStyle Clone(this BackStyle source)
        {
            if (source == null) throw new NullException(() => source);

            var dest = new BackStyle
            {
                Color = source.Color,
                Visible = source.Visible
            };

            return dest;
        }
    }
}
