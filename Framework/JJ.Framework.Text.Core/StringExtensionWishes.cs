using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Core.Text
{
    public static class StringExtensionWishes
    {
        public static bool StartsWithBlankLine(this string text) => StringWishes.StartsWithBlankLine(text);
        public static bool EndsWithBlankLine  (this string text) => StringWishes.EndsWithBlankLine  (text);
    }
}