namespace JJ.Framework.Existence.Core;

public static class FilledInExtensions
{
    // Part of the reason for so many overloads is C#'s best-matching quirks in case of generics.
    // For instance C# will choose a wider type over a more narrow generic type.
    // I.e. in case of List<T> it'd rather pick object? than IList<T>, so you have to specify an overload with List<T> explicitly.
    // Also, nullable semantics for value types couldn't be used, unless handle things specifically as `T?` (with a question mark).
    
    public static bool FilledIn   (this string         value)                  => FilledInHelper.FilledIn(value, false);
    public static bool FilledIn   (this string         value, bool trimSpace)  => FilledInHelper.FilledIn(value, trimSpace);
    public static bool FilledIn<T>(this T[]            arr)                    => FilledInHelper.FilledIn(arr);
    public static bool FilledIn<T>(this IList<T>       coll)                   => FilledInHelper.FilledIn(coll);
    public static bool FilledIn<T>(this ICollection<T> coll)                   => FilledInHelper.FilledIn(coll);
    public static bool FilledIn<T>(this HashSet<T>     coll)                   => FilledInHelper.FilledIn(coll);
    public static bool FilledIn<T>(this T              value)                  => FilledInHelper.FilledIn(value);
    public static bool FilledIn<T>(this T?             value) where T : struct => FilledInHelper.FilledIn(value);
    
    public static bool IsNully   (this string         value)                  => FilledInHelper.IsNully(value);
    public static bool IsNully   (this string         value, bool trimSpace)  => FilledInHelper.IsNully(value, trimSpace);
    public static bool IsNully<T>(this T[]            arr)                    => FilledInHelper.IsNully(arr);
    public static bool IsNully<T>(this IList<T>       coll)                   => FilledInHelper.IsNully(coll);
    public static bool IsNully<T>(this ICollection<T> coll)                   => FilledInHelper.IsNully(coll);
    public static bool IsNully<T>(this HashSet<T>     coll)                   => FilledInHelper.IsNully(coll);
    public static bool IsNully<T>(this T              value)                  => FilledInHelper.IsNully(value);
    public static bool IsNully<T>(this T?             value) where T : struct => FilledInHelper.IsNully(value);

    public static bool Is(this string value, string comparison)                  => FilledInHelper.Is(value, comparison);
    public static bool Is(this string value, string comparison, bool ignoreCase) => FilledInHelper.Is(value, comparison, ignoreCase);
    
    public static bool In<T>(this T      value, params T         [] comparisons                 ) => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T      value, ICollection<T>      comparisons                 ) => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T?     value, params T?        [] comparisons) where T : struct => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T?     value, params T         [] comparisons) where T : struct => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T      value, params T?        [] comparisons) where T : struct => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T?     value, ICollection<T?>     comparisons) where T : struct => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T?     value, ICollection<T>      comparisons) where T : struct => FilledInHelper.In(value, comparisons);
    public static bool In<T>(this T      value, ICollection<T?>     comparisons) where T : struct => FilledInHelper.In(value, comparisons);
    public static bool In   (this string value, params string    [] comparisons                 ) => FilledInHelper.In(value, comparisons);
    public static bool In   (this string value, ICollection<string> comparisons                 ) => FilledInHelper.In(value, comparisons);
    public static bool In   (this string value, string[]        comparisons, bool ignoreCase) => FilledInHelper.In(value, comparisons, ignoreCase);
    
    public static T      Coalesce<T>(this T   value, T      defaultValue)             => FilledInHelper.Coalesce(value, defaultValue);
    public static T      Coalesce<T>(this T   value, T      defaultValue, T fallback) => FilledInHelper.Coalesce(value, defaultValue, fallback);
    public static string Coalesce<T>(this T   value, string defaultValue)             => FilledInHelper.Coalesce(value, defaultValue);
    public static T      Coalesce<T>(this T?  value, T      defaultValue)             where T : struct => FilledInHelper.Coalesce(value, defaultValue);
    public static T      Coalesce<T>(this T?  value, T?     defaultValue, T fallback) where T : struct => FilledInHelper.Coalesce(value, defaultValue, fallback);
    public static string Coalesce<T>(this T?  value, string defaultValue)             where T : struct => FilledInHelper.Coalesce(value, defaultValue);
    public static string Coalesce(this string value, string defaultValue)                                  => FilledInHelper.Coalesce(value, defaultValue);
    public static string Coalesce(this string value, string defaultValue, bool   trimSpace)                => FilledInHelper.Coalesce(value, defaultValue, trimSpace);
    public static string Coalesce(this string value, string defaultValue, string fallback, bool trimSpace) => FilledInHelper.Coalesce(value, defaultValue, fallback, trimSpace);
}
