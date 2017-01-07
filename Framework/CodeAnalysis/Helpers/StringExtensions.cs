namespace JJ.Framework.CodeAnalysis.Helpers
{
    internal static class StringExtensions
    {
        public static bool StartsWith(this string value, char chr)
        {
            if (value.Length == 0)
            {
                return false;
            }

            char firstChar = value[0];

            return firstChar == chr;
        }
    }
}
