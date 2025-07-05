namespace JJ.Framework.Text.Core
{
    public static class StringExtensionsCore
    {
        public static bool StartsWithBlankLine(this string text) => StringHelperCore.StartsWithBlankLine(text);
        public static bool EndsWithBlankLine  (this string text) => StringHelperCore.EndsWithBlankLine  (text);
   }
}