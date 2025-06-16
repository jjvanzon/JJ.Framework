// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value, bool matchCase = false)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(matchCase);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool matchCase, bool spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        var stringComparison = GetStringComparison(matchCase);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool matchCase)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(matchCase);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, [UsedImplicitly] int dummy = 0)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, OrdinalIgnoreCase));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [UsedImplicitly] MatchCase matchCase)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [UsedImplicitly] MatchCase matchCase, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, Ordinal));
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
    private static StringComparison GetStringComparison(bool matchCase)
        => matchCase ? Ordinal : OrdinalIgnoreCase;
}

public static partial class FilledInHelper
{
    // Text
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll);

    // MatchCase

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, MatchCase matchCase)
        => ExistenceUtil.In(value, coll, matchCase);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool matchCase)
        => ExistenceUtil.In(value, coll, matchCase);
    
    // SpaceMatters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, int dummy = 1)
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);
    
    // MatchCase + SpaceMatters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, MatchCase matchCase, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, MatchCase matchCase)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool matchCase, bool spaceMatters)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);
    
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

    // MatchCase

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, MatchCase matchCase, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase);
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool matchCase, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, MatchCase matchCase)
        => ExistenceUtil.In(value, coll, matchCase);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool matchCase)
        => ExistenceUtil.In(value, coll, matchCase);
    
    // SpaceMatters
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool spaceMatters, int dummy = 1)
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);
    
    // MatchCase + SpaceMatters

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, MatchCase matchCase, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters, MatchCase matchCase, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);
    
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool matchCase = default, bool spaceMatters = default, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, MatchCase matchCase, SpaceMatters spaceMatters)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, MatchCase matchCase)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool matchCase, bool spaceMatters)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

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
    public static bool Contains(this IEnumerable<string?>? coll, string? value, bool matchCase = false) 
        => ExistenceUtil.Contains(coll, value, matchCase);
}