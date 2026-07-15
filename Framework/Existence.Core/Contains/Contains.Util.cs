#pragma warning disable IDE0060 // Unused parameter

namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_contains" />
internal static class ContainsUtil
{
    // String Collections Contains

    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, OrdinalIgnoreCase));
    }

    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value, bool caseMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value, [Implic(Reason = MagicBool)] CaseMatters caseMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, Ordinal));
    }

    // Contains Substring

    // TODO: spaceMatters flags?
    //  string formattedStr = FormatValue(str);
    //  string formattedSubstring = FormatValue(substring);

    // This one clashes with .NET's own.
    ///// <inheritdoc cref="_contains" />
    //public static bool Contains(this string? str, string? substring)
    //{
    //    if (!Has(str)) return false;
    //    if (!Has(substring)) return false;
    //    return str.IndexOf(substring, OrdinalIgnoreCase) >= 0;
    //}
        
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string? substring, bool caseMatters)
    {
        if (!Has(str)) return false;
        if (!Has(substring)) return false;
        var stringComparison = GetStringComparison(caseMatters);
        return str.IndexOf(substring, stringComparison) >= 0;
    }
    

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string? substring, [Implic(Reason = MagicBool)] CaseMatters caseMatters)
    {
        if (!Has(str)) return false;
        if (!Has(substring)) return false;
        return str.IndexOf(substring, Ordinal) >= 0;
    }
    
    // Contains Words/Chars

    // TODO: Distinction between ContainsAny and ContainsAll might be welcome.

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string[] words)
    {
        if (!Has(str)) return false;
        if (!Has(words)) return false;
        return words.Any(x => str.IndexOf(x, OrdinalIgnoreCase) >= 0);
    }

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string[] words, bool caseMatters)
    {
        if (!Has(str)) return false;
        if (!Has(words)) return false;
        var stringComparison = GetStringComparison(caseMatters);
        return words.Any(x => str.IndexOf(x, stringComparison) >= 0);
    }

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string[] words, [Implic(Reason = MagicBool)] CaseMatters caseMatters)
    {
        if (!Has(str)) return false;
        if (!Has(words)) return false;
        return words.Any(x => str.IndexOf(x, Ordinal) >= 0);
    }

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, char[] chars)
    {
        if (!Has(str)) return false;
        if (!Has(chars)) return false;
        return chars.Any(str.Contains);
    }
}