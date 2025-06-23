// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value, bool caseMatters = false)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, OrdinalIgnoreCase));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [UsedImplicitly] CaseMatters caseMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, [UsedImplicitly] int dummy = 0)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [UsedImplicitly] CaseMatters caseMatters, [UsedImplicitly] SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [UsedImplicitly] CaseMatters caseMatters, bool spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters, [UsedImplicitly] SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters, bool spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, stringComparison));
    }
    
    // Helpers

    [MethodImpl(AggressiveInlining)]
    private static string FormatValue(string? value) 
        => (value ?? "").Trim();

    [MethodImpl(AggressiveInlining)]
    private static string FormatValue(string? value, [UsedImplicitly] SpaceMatters spaceMatters) 
        => value ?? "";

    [MethodImpl(AggressiveInlining)]
    private static string FormatValue(string? value, bool spaceMatters)
        => spaceMatters ? value ?? "" : (value ?? "").Trim();

    [MethodImpl(AggressiveInlining)]
    private static StringComparison GetStringComparison(bool caseMatters)
        => caseMatters ? Ordinal : OrdinalIgnoreCase;
}

public static partial class FilledInHelper
{
    // Text
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll);

    // CaseMatters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, CaseMatters caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, CaseMatters caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters);
    
    // SpaceMatters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool spaceMatters, IEnumerable<string?>? coll, int dummy = 1)
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, int dummy = 1)
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);
    
    // CaseMatters + SpaceMatters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, CaseMatters caseMatters, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, CaseMatters caseMatters, bool spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool caseMatters, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters, CaseMatters caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters, bool caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool spaceMatters, CaseMatters caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool caseMatters = default, bool spaceMatters = default, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, CaseMatters caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, CaseMatters caseMatters, bool spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, bool caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters, bool spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);
    
    // Values and Objects

    /// <inheritdoc cref="_in" />
    public static bool In<T>(T value, IEnumerable<T>? coll) => coll?.Contains(value) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(T value, IEnumerable<T?>? coll) where T : struct => coll?.Contains(value) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(T? value, IEnumerable<T>? coll) where T : struct => value.HasValue && (coll?.Contains(value.Value) ?? false);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(T? value, IEnumerable<T?>? coll) where T : struct => coll?.Contains(value) ?? false;
}

public static partial class FilledInExtensions
{
    // Text
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, params IEnumerable<string?>? coll) 
        => ExistenceUtil.In(value, coll);

    // CaseMatters

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, CaseMatters caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters);
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, CaseMatters caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters);
    
    // SpaceMatters
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, spaceMatters);
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool spaceMatters, IEnumerable<string?>? coll, int dummy = 1)
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool spaceMatters, int dummy = 1)
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);

    // CaseMatters + SpaceMatters

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, CaseMatters caseMatters, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, CaseMatters caseMatters, bool spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool caseMatters, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters, CaseMatters caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters, bool caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool spaceMatters, CaseMatters caseMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool caseMatters = default, bool spaceMatters = default, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, CaseMatters caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, CaseMatters caseMatters, bool spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, bool caseMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool caseMatters, bool spaceMatters)
        => ExistenceUtil.In(value, coll, caseMatters, spaceMatters);

    // Values and Objects

    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T value, params IEnumerable<T>? coll) => FilledInHelper.In(value, coll);

    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T value, params IEnumerable<T?>? coll) where T : struct => FilledInHelper.In(value, coll);

    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T? value, params IEnumerable<T>? coll) where T : struct => FilledInHelper.In(value, coll);

    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T? value, params IEnumerable<T?>? coll) where T : struct => FilledInHelper.In(value, coll);
    
    // Contains
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? coll, string? value, bool caseMatters = false) 
        => ExistenceUtil.Contains(coll, value, caseMatters);
}