namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_contains" />
public static class ContainsExtensions
{
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, string? value) 
        => ContainsUtil.Contains(coll, value);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, string? value, bool caseMatters) 
        => ContainsUtil.Contains(coll, value, caseMatters);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, bool caseMatters, string? value) 
        => ContainsUtil.Contains(coll, value, caseMatters);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, string? value, CaseMatters caseMatters) 
        => ContainsUtil.Contains(coll, value, caseMatters);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, CaseMatters caseMatters, string? value) 
        => ContainsUtil.Contains(coll, value, caseMatters);
}