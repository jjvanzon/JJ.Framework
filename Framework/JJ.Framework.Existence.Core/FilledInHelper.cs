    // ReSharper disable PossibleMultipleEnumeration
    
namespace JJ.Framework.Existence.Core;

public static class FilledInHelper
{
    // Part of the reason for so many overloads is C#'s best-matching quirks in case of generics.
    // For instance C# will choose a wider type over a more narrow generic type.
    // I.e. in case of List<T> it'd rather pick object? than IList<T>, so you have to specify an overload with List<T> explicitly.
    // Also, nullable semantics for value types couldn't be used, unless handle things specifically as `T?` (with a question mark).
        
    // TODO: Use Flags enums for more meaningful single-word parameters, e.g. `IgnoreCase` instead of `true`.
    // Or sneakier: fake it with a lower case `IgnoreCaseFlags.ignoreCase` so you can type Is(value, ignoreCase),
    // as if that's new boolean syntax.

    public static bool FilledIn   ([NotNull]            string? value)                  => FilledIn(value, false);
    //public static bool FilledIn   ([NotNull]            string? value)                  => FilledIn(value, true);
    public static bool FilledIn   ([NotNull]            string? value, bool trimSpace)  => trimSpace ? !IsNullOrWhiteSpace(value): !IsNullOrEmpty(value);
    public static bool FilledIn<T>([NotNull]            T       value)                  => !Equals(value, default(T));
    public static bool FilledIn<T>([NotNull]            T?      value) where T : struct => !Equals(value, default(T?)) && !Equals(value, default(T));
    public static bool FilledIn<T>([NotNull]            params             T[]? coll) => coll is { Length: > 0 };
    public static bool FilledIn<T>([NotNull]            List               <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            HashSet            <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            IList              <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            ISet               <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            ICollection        <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            IReadOnlyList      <T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            IReadOnlyCollection<T>? coll) => coll is { Count: > 0 };
    public static bool FilledIn<T>([NotNull]            IEnumerable        <T>? coll) => coll != null && coll.Any();
    
    public static bool Has        ([NotNull]            string? value)                  => FilledIn(value);
    public static bool Has        ([NotNull]            string? value, bool trimSpace)  => FilledIn(value, trimSpace);
    public static bool Has<T>     ([NotNull]            T       value)                  => FilledIn(value);
    public static bool Has<T>     ([NotNull]            T?      value) where T : struct => FilledIn(value);
    public static bool Has<T>     ([NotNull]            params             T[]? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            List               <T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            HashSet            <T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            IList              <T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            ISet               <T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            ICollection        <T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            IReadOnlyList      <T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            IReadOnlyCollection<T>? coll)   => FilledIn(coll);
    public static bool Has<T>     ([NotNull]            IEnumerable        <T>? coll)   => FilledIn(coll);
    
    public static bool IsNully    ([NotNullWhen(false)] string? value)                  => !FilledIn(value);
    public static bool IsNully    ([NotNullWhen(false)] string? value, bool trimSpace)  => !FilledIn(value, trimSpace);
    public static bool IsNully<T> ([NotNullWhen(false)] T       value)                  => !FilledIn(value);
    public static bool IsNully<T> ([NotNullWhen(false)] T?      value) where T : struct => !FilledIn(value);
    public static bool IsNully<T> ([NotNullWhen(false)] params             T[]? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] List               <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] HashSet            <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] IList              <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] ISet               <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] ICollection        <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] IReadOnlyList      <T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] IReadOnlyCollection<T>? coll)   => !FilledIn(coll);
    public static bool IsNully<T> ([NotNullWhen(false)] IEnumerable        <T>? coll)   => !FilledIn(coll);
    
    public static bool Is(string? value, string? comparison) => Is(value, comparison, ignoreCase: true);
    public static bool Is(string? value, string? comparison, bool ignoreCase) => string.Equals(value ?? "", comparison ?? "", ignoreCase ? OrdinalIgnoreCase : Ordinal);
    
    public static bool In(string? value, params string?[]?        comparisons                 ) => comparisons?.Contains(value, ignoreCase: true)        ?? false;
    public static bool In(string? value, ICollection<string?>?    comparisons                 ) => comparisons?.Contains(value, ignoreCase: true)        ?? false;
    public static bool In(string? value, string?[]?               comparisons, bool ignoreCase) => comparisons?.Contains(value, ignoreCase      )        ?? false;
    public static bool In<T>(T    value, params             T[]?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(T?   value, params             T[]?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, params             T?[]? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, List               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(T?   value, List               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, List               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, HashSet            <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(T?   value, HashSet            <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, HashSet            <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, IList              <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    public static bool In<T>(T?   value, IList              <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, IList              <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, ISet               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(T?   value, ISet               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, ISet               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, ICollection        <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(T?   value, ICollection        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, ICollection        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, IReadOnlyList      <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(T?   value, IReadOnlyList      <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, IReadOnlyList      <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, IReadOnlyCollection<T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(T?   value, IReadOnlyCollection<T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, IReadOnlyCollection<T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T    value, IEnumerable        <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    public static bool In<T>(T?   value, IEnumerable        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    public static bool In<T>(T?   value, IEnumerable        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);

    // TODO: Add a variation on Coalesce called `Fallback`, that won't hard coalesce nulls, but keep them if last fallback is null.

    // Plain Coalesce (for some)
    
    public static string Coalesce   (string? value                                     )  => Has(value           ) ? value       :                 ""     ;
    public static string Coalesce   (string? value,                      bool trimSpace)  => Has(value, trimSpace) ? value       :                 ""     ;
    public static T      Coalesce<T>(T       value                     )                  => Has(value           ) ? value       :                 default;
    public static T      Coalesce<T>(T?      value                     ) where T : struct => Has(value           ) ? value.Value :                 default;
    
    // Single Fallback

    public static string Coalesce   (string? value, string? defaultValue                )  => Has(value           ) ? value       : defaultValue ?? ""     ;
    public static string Coalesce   (string? value, string? defaultValue, bool trimSpace)  => Has(value, trimSpace) ? value       : defaultValue ?? ""     ;
    public static T      Coalesce<T>(T       value, T       defaultValue)                  => Has(value           ) ? value       : defaultValue ?? default;
    public static T      Coalesce<T>(T?      value, T?      defaultValue) where T : struct => Has(value           ) ? value.Value : defaultValue ?? default(T);
    public static string Coalesce<T>(T?      value, string? defaultValue)                  => Has(value           ) ? $"{value}"  : defaultValue ?? ""     ;
    public static string Coalesce<T>(T?      value, string? defaultValue) where T : struct => Has(value           ) ? $"{value}"  : defaultValue ?? ""     ;
    public static                    T[] Coalesce<T>(                   T[]? coll,                     T[]? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static List               <T> Coalesce<T>(List               <T>? coll,  List               <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static HashSet            <T> Coalesce<T>(HashSet            <T>? coll,  HashSet            <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IList              <T> Coalesce<T>(IList              <T>? coll,  IList              <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static ISet               <T> Coalesce<T>(ISet               <T>? coll,  ISet               <T>? fallback) => Has(coll) ? coll : fallback ?? new HashSet<T>();
    public static ICollection        <T> Coalesce<T>(ICollection        <T>? coll,  ICollection        <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IReadOnlyList      <T> Coalesce<T>(IReadOnlyList      <T>? coll,  IReadOnlyList      <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IReadOnlyCollection<T> Coalesce<T>(IReadOnlyCollection<T>? coll,  IReadOnlyCollection<T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    public static IEnumerable        <T> Coalesce<T>(IEnumerable        <T>? coll,  IEnumerable        <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (string? value, string? defaultValue, string? fallback)                  => Coalesce(value, Coalesce(defaultValue, fallback));
    public static string Coalesce   (string? value, string? defaultValue, string? fallback, bool trimSpace)  => Coalesce(value, Coalesce(defaultValue, fallback, trimSpace), trimSpace);
    public static T      Coalesce<T>(T       value, T       defaultValue, T       fallback)                  => Coalesce(value, Coalesce(defaultValue, fallback));
    public static T      Coalesce<T>(T?      value, T?      defaultValue, T?      fallback) where T : struct => Coalesce(value, Coalesce(defaultValue, fallback));
    public static string Coalesce<T>(T       value, T       defaultValue, string? fallback)                  => Coalesce(value, Coalesce(defaultValue, fallback));
    public static string Coalesce<T>(T?      value, T?      defaultValue, string? fallback) where T : struct => Coalesce(value, Coalesce(defaultValue, fallback));

    // Variadic Fallbacks
    
    public static string Coalesce   (params             string?[]? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(params             T[]      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(params             T?[]     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (List               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(List               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(List               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (HashSet            <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(HashSet            <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(HashSet            <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (IList              <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(IList              <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(IList              <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (ISet               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(ISet               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(ISet               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (ICollection        <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(ICollection        <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(ICollection        <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (IReadOnlyList      <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(IReadOnlyList      <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(IReadOnlyList      <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    public static string Coalesce   (IReadOnlyCollection<string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    public static T      Coalesce<T>(IReadOnlyCollection<T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    public static T      Coalesce<T>(IReadOnlyCollection<T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    
    public static string Coalesce(IEnumerable<string?>? fallbacks)
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

    public static T Coalesce<T>(IEnumerable<T>? fallbacks)
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
    
    public static T Coalesce<T>(IEnumerable<T?>? fallbacks) where T: struct 
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
