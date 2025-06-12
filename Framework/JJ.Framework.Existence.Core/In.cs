namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    // TODO: Variants with IEnumerable<string> (non-nullable strings) for lack of covariance?
    
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                  params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, ignoreCase: true);
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, ignoreCase      );
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                         IEnumerable<string?>? coll, bool ignoreCase) =>                    coll .Contains(value, ignoreCase      );
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                  params IEnumerable<T>?       coll)                  =>                    coll?.Contains(value                  ) ?? false; 
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                  params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                  params IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value            ) ?? false);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                  params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? source, string? match, bool ignoreCase = false)
    {
        if (source == null) return false;
        match = (match ?? "").Trim();
        var stringComparison = ignoreCase.ToStringComparison();
        return source.Any(x => (x ?? "").Trim().Equals(match, stringComparison));
    }
     
    // Copied from Text.Core to prevent shipping a wide dependency.
    private static StringComparison ToStringComparison(this bool ignoreCase)
    {
        return ignoreCase ? OrdinalIgnoreCase : Ordinal;
    }
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value,                  params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, ignoreCase, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value,                         IEnumerable<string?>? coll, bool ignoreCase) => FilledInHelper.In(value, coll, ignoreCase);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T       value,                  params IEnumerable<T>?       coll)                  => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T       value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T?      value,                  params IEnumerable<T>?       coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T?      value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? source, string? match, bool ignoreCase = false) => FilledInHelper.Contains(source, match, ignoreCase);
}