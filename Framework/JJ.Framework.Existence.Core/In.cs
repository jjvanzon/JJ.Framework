namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    // TODO: Variants with IEnumerable<string> (non-nullable strings) for lack of covariance?
    
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                 params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, matchCase: false);
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value, bool matchCase, params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, matchCase       );
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                        IEnumerable<string?>? coll, bool matchCase ) =>                    coll .Contains(value, matchCase       );
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                 params IEnumerable<T>?       coll)                  =>                    coll?.Contains(value                  ) ?? false; 
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                 params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                 params IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value            ) ?? false);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                 params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? source, string? match, bool matchCase = false)
    {
        if (source == null) return false;
        match = (match ?? "").Trim();
        var stringComparison = matchCase.MatchCaseToStringComparison();
        return source.Any(x => (x ?? "").Trim().Equals(match, stringComparison));
    }
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
    public static bool Contains(this IEnumerable<string?>? source, string? match, bool matchCase = false) => FilledInHelper.Contains(source, match, matchCase);
}