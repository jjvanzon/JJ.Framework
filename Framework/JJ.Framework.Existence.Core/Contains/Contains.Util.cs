namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_contains" />
internal static class ContainsUtil
{
    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value, bool caseMatters = false)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }
}