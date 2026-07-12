using static System.Globalization.CharUnicodeInfo;
using static System.Globalization.UnicodeCategory;
using static System.Text.NormalizationForm;

namespace JJ.Framework.Text.Core;

public static class StringExtensionsCore
{
    public static bool StartsWithBlankLine(this string text) => StringHelperCore.StartsWithBlankLine(text);
    public static bool EndsWithBlankLine  (this string text) => StringHelperCore.EndsWithBlankLine  (text);

    /// <inheritdoc cref="_removeaccents" />
    public static string RemoveAccents(this string? input)
    {
        if (input == null) return "";
        string formD = input.Normalize(FormD);
        var stripped = formD.Where(x => GetUnicodeCategory(x) != NonSpacingMark);
        return new string(stripped.ToArray()).Normalize(FormC);
    }
}
