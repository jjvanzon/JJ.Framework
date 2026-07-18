// ReSharper disable ConvertToExtensionBlock

namespace JJ.Framework.Text.Core;

public static class StringExtensionsCore
{
    // Prettify

    /// <inheritdoc cref="_prettyduration" />
    public static string PrettyDuration     (this double?  sec              ) => StringHelperCore.PrettyDuration(sec);
    /// <inheritdoc cref="_prettyduration" />
    public static string PrettyDuration     (this double   sec              ) => StringHelperCore.PrettyDuration(sec);
    /// <inheritdoc cref="_prettyduration" />
    public static string PrettyDuration     (this int      sec              ) => StringHelperCore.PrettyDuration(sec);
    /// <inheritdoc cref="_prettytimespan" />
    public static string PrettyTimeSpan     (this TimeSpan timeSpan         ) => StringHelperCore.PrettyTimeSpan(timeSpan);
    /// <inheritdoc cref="_prettytime" />
    public static string PrettyTime         (this DateTime dateTime         ) => StringHelperCore.PrettyTime(dateTime);
    /// <inheritdoc cref="_prettybytecount" />
    public static string PrettyByteCount    (this byte[]?  bytes            ) => StringHelperCore.PrettyByteCount(bytes);
    /// <inheritdoc cref="_prettybytecount" />
    public static string PrettyByteCount    (this int      byteCount        ) => StringHelperCore.PrettyByteCount(byteCount);
    /// <inheritdoc cref="_prettybytecount" />
    public static string PrettyByteCount    (this long     byteCount        ) => StringHelperCore.PrettyByteCount(byteCount);
    /// <inheritdoc cref="_withshortguids" />
    public static string WithShortGuids     (this string?  input, int length) => StringHelperCore.WithShortGuids(input, length);

    // Punctuation & Spacing

    /// <inheritdoc cref="_countlines" />
    public static int    CountLines         (this string?  text ) => StringHelperCore.CountLines(text);
    /// <inheritdoc cref="_startswithblankline" />
    public static bool   StartsWithBlankLine(this string?  text ) => StringHelperCore.StartsWithBlankLine(text);
    /// <inheritdoc cref="endswithblankline" />
    public static bool   EndsWithBlankLine  (this string?  text ) => StringHelperCore.EndsWithBlankLine(text);
    /// <inheritdoc cref="_endswithpunctuation" />
    public static bool   EndsWithPunctuation(this string?  text, bool ignoreWhiteSpace = true) => StringHelperCore.EndsWithPunctuation(text, ignoreWhiteSpace);
    /// <inheritdoc cref="_removeaccents" />
    public static string RemoveAccents      (this string?  input) => StringHelperCore.RemoveAccents(input);

    // Basics
    
    /// <inheritdoc cref="_trim" />
    public static string Trim   (this string? text, string trim) => StringHelperCore.Trim(text, trim);

    /// <inheritdoc cref="_replace" />
    public static string Replace(this string? text, string oldValue, char newValue) => StringHelperCore.Replace(text, oldValue, newValue);

    /// <inheritdoc cref="_replace" />
    public static string Replace(this string? text, char oldValue, string newValue) => StringHelperCore.Replace(text, oldValue, newValue);
}