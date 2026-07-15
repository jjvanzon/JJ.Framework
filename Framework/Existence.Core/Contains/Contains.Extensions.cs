namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_contains" />
public static class ContainsExtensions
{
    // Collection Contains

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

    // Contains Substring

    // This one clashes with .NET's own.
    ///// <inheritdoc cref="_contains" />
    //public static bool Contains(this string? str, string? substring)
    //    => ContainsUtil.Contains(str, substring);
        
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string? substring, bool caseMatters)
        => ContainsUtil.Contains(str ?? "", substring, caseMatters);
        
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string? substring, [Implic(Reason = MagicBool)] CaseMatters caseMatters)
        => ContainsUtil.Contains(str ?? "", substring, caseMatters);
    
    // Contains Words/Chars

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string[] words)
        => ContainsUtil.Contains(str, words);

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string[] words, bool caseMatters)
        => ContainsUtil.Contains(str, words, caseMatters);

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, string[] words, [Implic(Reason = MagicBool)] CaseMatters caseMatters)
        => ContainsUtil.Contains(str, words, caseMatters);

    /// <inheritdoc cref="_contains" />
    public static bool Contains(this string? str, char[] chars)
        => ContainsUtil.Contains(str ?? "", chars);

}