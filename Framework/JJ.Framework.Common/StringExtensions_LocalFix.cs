#pragma warning disable IDE0056

namespace JJ.Framework.Common.Legacy;

internal static class StringExtensions_LocalFix
{
    public static string TrimOnce(this string? str, char trimChar)
    {
        if (str == null) return "";
        if (str.Length == 0) return "";

        int startPos = 0;
        int endPos = str.Length - 1;

        if (str[0] == trimChar) startPos = 1;
        if (str[str.Length - 1] == trimChar) endPos -= 1;

        return str.FromTillNoThrow(startPos, endPos);
    }

    public static string FromTillNoThrow(this string input, int startIndex, int endIndex)
    {
        if (endIndex < startIndex) 
            return "";
        return input.Substring(startIndex, endIndex - startIndex + 1);
    }
}
