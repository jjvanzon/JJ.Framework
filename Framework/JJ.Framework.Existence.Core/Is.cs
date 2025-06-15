// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, [UsedImplicitly] MatchCase    matchCase   ) => Is(a, b, matchCase: true);
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, [UsedImplicitly] SpaceMatters spaceMatters) => Is(a, b, spaceMatters: true);
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, bool matchCase = false, bool spaceMatters = false)
    {
        if (a == b) return true;
        
        StringComparison compare = matchCase.MatchCaseToStringComparison();
        
        if (!spaceMatters) { a = (a ?? "").Trim(); b = (b ?? "").Trim(); }
        if (string.Equals(a, b, compare)) return true;
        
        if (!spaceMatters) { a = a.RemoveExcessiveWhiteSpace(); b = b.RemoveExcessiveWhiteSpace(); }
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }
}

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b                           ) => ExistenceUtil.Is(a, b);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, MatchCase    matchCase   ) => ExistenceUtil.Is(a, b, matchCase);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         matchCase   ) => ExistenceUtil.Is(a, b, matchCase);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, SpaceMatters spaceMatters) => ExistenceUtil.Is(a, b, spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         spaceMatters, [UsedImplicitly] int dummy = 0) => ExistenceUtil.Is(a, b, spaceMatters: spaceMatters);
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b                           ) => ExistenceUtil.Is(a, b);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, MatchCase    matchCase   ) => ExistenceUtil.Is(a, b, matchCase);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         matchCase   ) => ExistenceUtil.Is(a, b, matchCase);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters) => ExistenceUtil.Is(a, b, spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         spaceMatters, [UsedImplicitly] int dummy = 0) => ExistenceUtil.Is(a, b, spaceMatters: spaceMatters);
}