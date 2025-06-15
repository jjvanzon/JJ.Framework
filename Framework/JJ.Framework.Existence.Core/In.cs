using static System.Runtime.CompilerServices.MethodImplOptions;

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
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, int dummy = 0)
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
    public static bool In(string? value, IEnumerable<string?>? coll, MatchCase matchCase)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, Ordinal));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(value, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, MatchCase matchCase, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(value, spaceMatters).Equals(value, Ordinal));
    }
    
    // Helpers

    [MethodImpl(AggressiveInlining)]
    private static string FormatValue(string? value) => (value ?? "").Trim();
    [MethodImpl(AggressiveInlining)]
    private static string FormatValue(string? value, [UsedImplicitly] SpaceMatters spaceMatters) => value ?? "";
    [MethodImpl(AggressiveInlining)]
    private static string FormatValue(string? value, bool spaceMatters)
    {
        if (!spaceMatters)
        {
            return FormatValue(value);
        }
        else
        {
            return FormatValue(value, SpaceMatters.spaceMatters);
        }
    }
    
    private static StringComparison GetStringComparison(bool matchCase) => matchCase ? Ordinal : OrdinalIgnoreCase;
}

public static partial class FilledInHelper
{
    // TODO: Variants with IEnumerable<string> (non-nullable strings) for lack of covariance?
    
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                 params IEnumerable<string?>? coll                 ) =>                    ExistenceUtil.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value, bool matchCase, params IEnumerable<string?>? coll                 ) =>                    ExistenceUtil.In(value, coll, matchCase);
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                        IEnumerable<string?>? coll, bool matchCase ) =>                    ExistenceUtil.In(value, coll, matchCase);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                 params IEnumerable<T>?       coll)                  =>                    coll?.Contains(value                  ) ?? false; 
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                 params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                 params IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value            ) ?? false);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                 params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value,                 params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value, bool matchCase, params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, matchCase, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value,                        IEnumerable<string?>? coll, bool matchCase ) => FilledInHelper.In(value, coll, matchCase);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T       value,                 params IEnumerable<T>?       coll)                  => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T       value,                 params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T?      value,                 params IEnumerable<T>?       coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T?      value,                 params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? source, string? match, bool matchCase = false) => ExistenceUtil.Contains(source, match, matchCase);
}