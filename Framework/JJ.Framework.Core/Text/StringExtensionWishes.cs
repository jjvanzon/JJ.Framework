namespace JJ.Framework.Wishes.Text
{
    public static class StringExtensionWishes
    {
        public static bool StartsWithBlankLine(this string text) => StringWishes.StartsWithBlankLine(text);
        public static bool EndsWithBlankLine  (this string text) => StringWishes.EndsWithBlankLine  (text);
    }
}