namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_contains" />
public static class ContainsExtensions
{
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, string? value, bool caseMatters = false) 
        => ContainsUtil.Contains(coll, value, caseMatters);
}