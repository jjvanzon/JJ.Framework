using static System.Globalization.CharUnicodeInfo;
using static System.Globalization.UnicodeCategory;
using static System.Text.NormalizationForm;

namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_removeaccents" />
public static class CommonStringExtensionsCore
{
    // TODO: Move to JJ.Framework.Text.Core once that's fully tested.

    /// <inheritdoc cref="_removeaccents" />
    public static string RemoveAccents(this string? input)
    {
        if (input == null) return "";
        string formD = input.Normalize(FormD);
        var stripped = formD.Where(x => GetUnicodeCategory(x) != NonSpacingMark);
        return new string(stripped.ToArray()).Normalize(FormC);
    }
}