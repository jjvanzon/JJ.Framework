    // ReSharper disable PossibleMultipleEnumeration
    
namespace JJ.Framework.Existence.Core;

public static class FilledInExtensions
{
    // Part of the reason for so many overloads is C#'s best-matching quirks in case of generics.
    // For instance C# will choose a wider type over a more narrow generic type.
    // I.e. in case of List<T> it'd rather pick object? than IList<T>, so you have to specify an overload with List<T> explicitly.
    // Also, nullable semantics for value types couldn't be used, unless handle things specifically as `T?` (with a question mark).
        
    // TODO: Use Flags enums for more meaningful single-word parameters, e.g. `IgnoreCase` instead of `true`.
    // Or sneakier: fake it with a lower case `IgnoreCaseFlags.ignoreCase` so you can type Is(value, ignoreCase),
    // as if that's new boolean syntax.
    
    public static bool FilledIn   ([NotNull] this           string? value)                  => FilledIn(value, false);
    public static bool FilledIn   ([NotNull] this           string? value, bool trimSpace)  => trimSpace ? !IsNullOrWhiteSpace(value): !IsNullOrEmpty(value);
    public static bool FilledIn<T>([NotNull] this           T       value)                  => !Equals(value, default(T));
    public static bool FilledIn<T>([NotNull] this           T?      value) where T : struct => !Equals(value, default(T?)) && !Equals(value, default(T));
    public static bool FilledIn<T>([NotNull] this                              T[]? coll) => coll is { Length: > 0 };
    public static bool FilledIn<T>([NotNull] this           List               <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           HashSet            <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           IList              <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           ISet               <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           ICollection        <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           IReadOnlyList      <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           IReadOnlyCollection<T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull] this           IEnumerable        <T>? coll) => coll != null && coll.Any();
    
    private static bool Has        ([NotNull] this           string? value)                  => FilledIn(value);
    private static bool Has        ([NotNull] this           string? value, bool trimSpace)  => FilledIn(value, trimSpace);
    private static bool Has<T>     ([NotNull] this           T       value)                  => FilledIn(value);
    private static bool Has<T>     ([NotNull] this           T?      value) where T : struct => FilledIn(value);
    private static bool Has<T>     ([NotNull] this                              T[]? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           List               <T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           HashSet            <T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           IList              <T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           ISet               <T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           ICollection        <T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           IReadOnlyList      <T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           IReadOnlyCollection<T>? coll)   => FilledIn(coll);
    private static bool Has<T>     ([NotNull] this           IEnumerable        <T>? coll)   => FilledIn(coll);
    
    public static bool IsNully    ([NotNullWhen(false)] this string? value)                  => !FilledIn(value);
    public static bool IsNully    ([NotNullWhen(false)] this string? value, bool trimSpace)  => !FilledIn(value, trimSpace);
    public static bool IsNully<T> ([NotNullWhen(false)] this T       value)                  => !FilledIn(value);
    public static bool IsNully<T> ([NotNullWhen(false)] this T?      value) where T : struct => !FilledIn(value);
    public static bool IsNully<T> ([NotNullWhen(false)] this                    T[]? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this List               <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this HashSet            <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this IList              <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this ISet               <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this ICollection        <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this IReadOnlyList      <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this IReadOnlyCollection<T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] this IEnumerable        <T>? coll)   => !FilledIn(coll);
    
    public static bool Is(this string? value, string? comparison) => Is(value, comparison, ignoreCase: true);
    public static bool Is(this string? value, string? comparison, bool ignoreCase) => string.Equals(value ?? "", comparison ?? "", ignoreCase ? OrdinalIgnoreCase : Ordinal);
    
    public static bool In(this string? value, params string?[]?        comparisons                 ) => comparisons?.Contains(value, ignoreCase: true)        ?? false;
    public static bool In(this string? value, ICollection<string?>?    comparisons                 ) => comparisons?.Contains(value, ignoreCase: true)        ?? false;
    public static bool In(this string? value, string?[]?               comparisons, bool ignoreCase) => comparisons?.Contains(value, ignoreCase      )        ?? false;
    public static bool In<T>(this T    value, params             T[]?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(this T?   value, params             T[]?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, params             T?[]? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, List               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(this T?   value, List               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, List               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, HashSet            <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(this T?   value, HashSet            <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, HashSet            <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, IList              <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(this T?   value, IList              <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, IList              <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, ISet               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(this T?   value, ISet               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, ISet               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, ICollection        <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(this T?   value, ICollection        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, ICollection        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, IReadOnlyList      <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(this T?   value, IReadOnlyList      <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, IReadOnlyList      <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, IReadOnlyCollection<T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(this T?   value, IReadOnlyCollection<T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, IReadOnlyCollection<T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T    value, IEnumerable        <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(this T?   value, IEnumerable        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(this T?   value, IEnumerable        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    
    // Plain Coalesce (for some)
    
    public static string Coalesce   (this string? value                                     )  => Has(value           ) ? value       :                 ""     ;
    public static string Coalesce   (this string? value,                      bool trimSpace)  => Has(value, trimSpace) ? value       :                 ""     ;
    public static T      Coalesce<T>(this T       value                     )                  => Has(value           ) ? value       :                 default;
    public static T      Coalesce<T>(this T?      value                     ) where T : struct => Has(value           ) ? value.Value :                 default;
    
    // Single Fallback

    public static string Coalesce   (this string? value, string? defaultValue                )  => Has(value           ) ? value       : defaultValue ?? ""     ;
    public static string Coalesce   (this string? value, string? defaultValue, bool trimSpace)  => Has(value, trimSpace) ? value       : defaultValue ?? ""     ;
    public static T      Coalesce<T>(this T       value, T       defaultValue)                  => Has(value           ) ? value       : defaultValue ?? default;
    public static T      Coalesce<T>(this T?      value, T?      defaultValue) where T : struct => Has(value           ) ? value.Value : defaultValue ?? default(T);
    public static string Coalesce<T>(this T?      value, string? defaultValue)                  => Has(value           ) ? $"{value}"  : defaultValue ?? ""     ;
    public static string Coalesce<T>(this T?      value, string? defaultValue) where T : struct => Has(value           ) ? $"{value}"  : defaultValue ?? ""     ;
    public static                    T[] Coalesce<T>(this                    T[]? coll,                     T[]? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static List               <T> Coalesce<T>(this List               <T>? coll,  List               <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static HashSet            <T> Coalesce<T>(this HashSet            <T>? coll,  HashSet            <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IList              <T> Coalesce<T>(this IList              <T>? coll,  IList              <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static ISet               <T> Coalesce<T>(this ISet               <T>? coll,  ISet               <T>? fallback) => Has(coll) ? coll : fallback ?? new HashSet<T>();
    public static ICollection        <T> Coalesce<T>(this ICollection        <T>? coll,  ICollection        <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IReadOnlyList      <T> Coalesce<T>(this IReadOnlyList      <T>? coll,  IReadOnlyList      <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IReadOnlyCollection<T> Coalesce<T>(this IReadOnlyCollection<T>? coll,  IReadOnlyCollection<T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IEnumerable        <T> Coalesce<T>(this IEnumerable        <T>? coll,  IEnumerable        <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];

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
