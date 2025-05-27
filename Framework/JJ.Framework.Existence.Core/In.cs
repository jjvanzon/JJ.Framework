namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    // TODO: Variants with IEnumerable<string> (non-nullable strings) for lack of covariance?
    public static bool In   (     string? value,                  params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, ignoreCase: true);
    public static bool In   (     string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, ignoreCase      );
    public static bool In   (     string? value,                         IEnumerable<string?>? coll, bool ignoreCase) =>                    coll .Contains(value, ignoreCase      );
    public static bool In<T>(     T       value,                  params IEnumerable<T>?       coll)                  =>                    coll?.Contains(value                  ) ?? false; 
    public static bool In<T>(     T       value,                  params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    public static bool In<T>(     T?      value,                  params IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value            ) ?? false);
    public static bool In<T>(     T?      value,                  params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    
    public static bool Contains(IEnumerable<string?>? source, string? match, bool ignoreCase = false)
    {
        return source?.Any(x => (x ?? "").Equals(match, ignoreCase.ToStringComparison())) ?? false;
    }
     
    // Copied from Text.Core to prevent shipping a wide dependency.
    private static StringComparison ToStringComparison(this bool ignoreCase)
    {
        return ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }
}

public static partial class FilledInExtensions
{
    public static bool In   (this string? value,                  params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, coll);
    public static bool In   (this string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, ignoreCase, coll);
    public static bool In   (this string? value,                         IEnumerable<string?>? coll, bool ignoreCase) => FilledInHelper.In(value, coll, ignoreCase);
    public static bool In<T>(this T       value,                  params IEnumerable<T>?       coll)                  => FilledInHelper.In(value, coll);
    public static bool In<T>(this T       value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    public static bool In<T>(this T?      value,                  params IEnumerable<T>?       coll) where T : struct => FilledInHelper.In(value, coll);
    public static bool In<T>(this T?      value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    
    public static bool Contains(this IEnumerable<string?>? source, string? match, bool ignoreCase = false) => FilledInHelper.Contains(source, match, ignoreCase);
}