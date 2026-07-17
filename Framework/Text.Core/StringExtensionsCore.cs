namespace JJ.Framework.Text.Core;

public static class StringExtensionsCore
{
    // Prettify

    /// <inheritdoc cref="_prettyduration" />
    public static string PrettyDuration(this double? sec) => StringHelperCore.PrettyDuration(sec);
    /// <inheritdoc cref="_prettyduration" />
    public static string PrettyDuration(this double sec) => StringHelperCore.PrettyDuration(sec);
    public static string PrettyTimeSpan(this TimeSpan timeSpan) => StringHelperCore.PrettyTimeSpan(timeSpan);
    public static string PrettyByteCount(this byte[]? bytes) => StringHelperCore.PrettyByteCount(bytes);
    //public static string PrettyTime() => PrettyTime(DateTime.Now);
    public static string PrettyTime(this DateTime dateTime) => StringHelperCore.PrettyTime(dateTime);
    public static string PrettyByteCount(this long byteCount) => StringHelperCore.PrettyByteCount(byteCount);
    public static string WithShortGuids(this string? input, int length) => StringHelperCore.WithShortGuids(input, length);
    public static string ToShortGuid(this Guid? input, int length) => StringHelperCore.ToShortGuid(input, length);

    // Punctuation & Spacing

    public static int CountLines(this string? str) => StringHelperCore.CountLines(str);
    public static bool StartsWithBlankLine(this string? text) => StringHelperCore.StartsWithBlankLine(text);
    public static bool EndsWithBlankLine(this string? text) => StringHelperCore.EndsWithBlankLine(text);
    /// <inheritdoc cref="_endswithpunctuation" />
    public static bool EndsWithPunctuation(this string? text, bool ignoreWhiteSpace = true) => StringHelperCore.EndsWithPunctuation(text, ignoreWhiteSpace);
    /// <inheritdoc cref="_removeaccents" />
    public static string RemoveAccents(this string? input) => StringHelperCore.RemoveAccents(input);

    // TODO: Accept null in, output non-null. Do not throw.

    // Basics
    
    public static string Trim(this string? text, string trim) => StringHelperCore.Trim(text, trim);

    /// <inheritdoc cref="_replace" />
    public static string Replace(this string? text, string oldValue, char newValue) => StringHelperCore.Replace(text, oldValue, newValue);

    /// <inheritdoc cref="_replace" />
    public static string Replace(this string? text, char oldValue, string newValue) => StringHelperCore.Replace(text, oldValue, newValue);
}