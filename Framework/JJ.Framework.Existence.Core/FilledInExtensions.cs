    // ReSharper disable PossibleMultipleEnumeration
// ReSharper disable ConstantNullCoalescingCondition
    
namespace JJ.Framework.Existence.Core;

public static class FilledInExtensions
{
    public static bool FilledIn   ([NotNull]            this string?         value)                  => FilledInHelper.FilledIn(value);
    public static bool FilledIn   ([NotNull]            this string?         value, bool trimSpace)  => FilledInHelper.FilledIn(value, trimSpace);
    public static bool FilledIn   ([NotNull]            this object?         value)                  => FilledInHelper.FilledIn(value);
    public static bool FilledIn<T>(                     this T               value) where T : struct => FilledInHelper.FilledIn(value);
    public static bool FilledIn<T>([NotNull]            this T?              value) where T : struct => FilledInHelper.FilledIn(value);
    public static bool FilledIn<T>([NotNull]            this IEnumerable<T>? coll )                  => FilledInHelper.FilledIn(coll);
        
  //public static bool Has        ([NotNull]            this string?         value)                  => FilledInHelper.Has(value);
  //public static bool Has        ([NotNull]            this string?         value, bool trimSpace)  => FilledInHelper.Has(value, trimSpace);
  //public static bool Has        ([NotNull]            this object?         value)                  => FilledInHelper.Has(value);
  //public static bool Has<T>     (                     this T               value) where T : struct => FilledInHelper.Has(value);
  //public static bool Has<T>     ([NotNull]            this T?              value) where T : struct => FilledInHelper.Has(value);
  //public static bool Has<T>     ([NotNull]            this IEnumerable<T>? coll )                  => FilledInHelper.Has(coll);
    
    public static bool IsNully    ([NotNullWhen(false)] this string?         value)                  => FilledInHelper.IsNully(value);
    public static bool IsNully    ([NotNullWhen(false)] this string?         value, bool trimSpace)  => FilledInHelper.IsNully(value, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)] this object?         value)                  => FilledInHelper.IsNully(value);
    public static bool IsNully<T> (                     this T               value) where T : struct => FilledInHelper.IsNully(value);
    public static bool IsNully<T> ([NotNullWhen(false)] this T?              value) where T : struct => FilledInHelper.IsNully(value);
    public static bool IsNully<T> ([NotNullWhen(false)] this IEnumerable<T>? coll )                  => FilledInHelper.IsNully(coll);
    
    public static bool Is(this string? value, string? comparison                 ) => FilledInHelper.Is(value, comparison       );
    public static bool Is(this string? value, string? comparison, bool ignoreCase) => FilledInHelper.Is(value, comparison, ignoreCase);
    
    public static bool In   (this string? value,                  params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, coll);
    public static bool In   (this string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, ignoreCase, coll);
    public static bool In   (this string? value,                         IEnumerable<string?>? coll, bool ignoreCase) => FilledInHelper.In(value, coll, ignoreCase);
    public static bool In<T>(this T       value,                  params IEnumerable<T>?       coll)                  => FilledInHelper.In(value, coll);
    public static bool In<T>(this T       value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    public static bool In<T>(this T?      value,                  params IEnumerable<T>?       coll) where T : struct => FilledInHelper.In(value, coll);
    public static bool In<T>(this T?      value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    
    public static bool Contains(this IEnumerable<string> source, string match, bool ignoreCase = false) => FilledInHelper.Contains(source, match, ignoreCase);
    
    // Plain Coalesce (for some)
    
    public static string Coalesce   (this string? value                  )                  => FilledInHelper.Coalesce(value);
    public static T      Coalesce<T>(this T       value                  ) where T : new()  => FilledInHelper.Coalesce(value);
    public static T      Coalesce<T>(this T?      value                  ) where T : struct => FilledInHelper.Coalesce(value);
    
    // Single Fallback

    public static string Coalesce   (this string? value, string? fallback)                  => FilledInHelper.Coalesce(value, fallback           );
    public static string Coalesce   (this string? value, string? fallback, bool trimSpace)  => FilledInHelper.Coalesce(value, fallback, trimSpace);
    public static string Coalesce   (this object? value, string? fallback)                  => FilledInHelper.Coalesce(value, fallback           );
    public static string Coalesce<T>(this T       value, string? fallback) where T : struct => FilledInHelper.Coalesce(value, fallback           );
    public static string Coalesce<T>(this T?      value, string? fallback) where T : struct => FilledInHelper.Coalesce(value, fallback           );
    public static T      Coalesce<T>(this T       value, T       fallback) where T : struct => FilledInHelper.Coalesce(value, fallback           );
    public static T      Coalesce<T>(this T       value, T?      fallback) where T : struct => FilledInHelper.Coalesce(value, fallback           );
    public static T      Coalesce<T>(this T?      value, T       fallback) where T : struct => FilledInHelper.Coalesce(value, fallback           );
    public static T      Coalesce<T>(this T?      value, T?      fallback) where T : struct => FilledInHelper.Coalesce(value, fallback           );
    // These didn't help
    //public static T      Coalesce<T>(     object? value, T?      fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     T?      value, object? fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, object? fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, T?      fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     T?      value, object? fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, object? fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (this string? value, string? defaultValue, string? fallback)                  => Coalesce(value, Coalesce(defaultValue, fallback));
    public static string Coalesce   (this string? value, string? defaultValue, string? fallback, bool trimSpace)  => Coalesce(value, Coalesce(defaultValue, fallback, trimSpace), trimSpace);
    public static T      Coalesce<T>(this T       value, T       defaultValue, T       fallback)                  => Coalesce(value, Coalesce(defaultValue, fallback));
    public static T      Coalesce<T>(this T?      value, T?      defaultValue, T?      fallback) where T : struct => Coalesce(value, Coalesce(defaultValue, fallback));
    public static string Coalesce<T>(this T       value, T       defaultValue, string? fallback)                  => Coalesce(value, Coalesce(defaultValue, fallback));
    public static string Coalesce<T>(this T?      value, T?      defaultValue, string? fallback) where T : struct => Coalesce(value, Coalesce(defaultValue, fallback));

    // Variadic Fallbacks
    
    public static string Coalesce   (this                    string?[]? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this                    T[]      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this                    T?[]     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this List               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this List               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this List               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this HashSet            <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this HashSet            <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this HashSet            <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this IList              <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this IList              <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this IList              <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this ISet               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this ISet               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this ISet               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this ICollection        <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this ICollection        <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this ICollection        <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this IReadOnlyList      <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this IReadOnlyList      <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this IReadOnlyList      <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (this IReadOnlyCollection<string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(this IReadOnlyCollection<T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(this IReadOnlyCollection<T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    
    public static string Coalesce(this IEnumerable<string?>? fallbacks)
    {
        if (fallbacks == null) return "";
        
        string? last = "";
        
        foreach (var fallback in fallbacks)
        {
            if (Has(fallback)) return fallback;
            last = fallback;
        }
        
        return last ?? "";
    }

    public static T Coalesce<T>(this IEnumerable<T>? fallbacks)
    {
        if (fallbacks == null) return default;
        
        T last = default;
        
        foreach (var fallback in fallbacks)
        {
            if (Has(fallback)) return fallback;
            last = fallback;
        }
        
        return last;
    }
    
    public static T Coalesce<T>(this IEnumerable<T?>? fallbacks) where T: struct 
    {
        if (fallbacks == null) return default;
        
        T? last = default;
        
        foreach (var fallback in fallbacks)
        {
            if (Has(fallback))
            {
                if (fallback is T ret)
                {
                    return ret;
                }
            }
            
            last = fallback;
        }
        
        return last ?? default;
    }
}
