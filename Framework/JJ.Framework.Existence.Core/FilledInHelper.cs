    // ReSharper disable PossibleMultipleEnumeration
// ReSharper disable ConstantNullCoalescingCondition
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
    
namespace JJ.Framework.Existence.Core;

public static class FilledInHelper
{
    public static bool FilledIn   ([NotNull]                 string?         value)                  => FilledIn(value, true);
    public static bool FilledIn   ([NotNull]                 string?         value, bool trimSpace)  => trimSpace ? !IsNullOrWhiteSpace(value): !IsNullOrEmpty(value);
    public static bool FilledIn   ([NotNull]                 object?         value)                  => value != null;
    public static bool FilledIn<T>(                          T               value) where T : struct => !Equals(value, default(T));
    public static bool FilledIn<T>([NotNull]                 T?              value) where T : struct => !Equals(value, default(T?)) && !Equals(value, default(T));
    public static bool FilledIn<T>([NotNull]                 IEnumerable<T>? coll )                  => coll?.Any() ?? false;
        
    public static bool Has        ([NotNull]                 string?         value)                  => FilledIn(value);
    public static bool Has        ([NotNull]                 string?         value, bool trimSpace)  => FilledIn(value, trimSpace);
    public static bool Has        ([NotNull]                 object?         value)                  => FilledIn(value);
    public static bool Has<T>     (                          T               value) where T : struct => FilledIn(value);
    public static bool Has<T>     ([NotNull]                 T?              value) where T : struct => FilledIn(value);
    public static bool Has<T>     ([NotNull]                 IEnumerable<T>? coll )                  => FilledIn(coll);

    public static bool IsNully    ([NotNullWhen(false)]      string?         value)                  => !FilledIn(value);
    public static bool IsNully    ([NotNullWhen(false)]      string?         value, bool trimSpace)  => !FilledIn(value, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)]      object?         value)                  => !FilledIn(value);
    public static bool IsNully<T> (                          T               value) where T : struct => !FilledIn(value);
    public static bool IsNully<T> ([NotNullWhen(false)]      T?              value) where T : struct => !FilledIn(value);
    public static bool IsNully<T> ([NotNullWhen(false)]      IEnumerable<T>? coll )                  => !FilledIn(coll);
    
    public static bool Is(string? a, string? b) => Is(a, b, ignoreCase: true);
    public static bool Is(string? a, string? b, bool ignoreCase)
    {
        if (a == b) return true;
    
        StringComparison compare = ignoreCase.ToStringComparison();
    
        a = (a ?? "").Trim(); b = (b ?? "").Trim();
        if (string.Equals(a, b, compare)) return true;
    
        a = a.RemoveExcessiveWhiteSpace();
        b = b.RemoveExcessiveWhiteSpace();
        if (string.Equals(a, b, compare)) return true;

        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }

    public static bool In   (     string? value,                  params IEnumerable<string?>? coll                 ) =>                    coll?.Contains(value, ignoreCase: true) ?? false;
    public static bool In   (     string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) =>                    coll?.Contains(value, ignoreCase      ) ?? false;
    public static bool In   (     string? value,                         IEnumerable<string?>? coll, bool ignoreCase) =>                    coll?.Contains(value, ignoreCase      ) ?? false;
    public static bool In<T>(     T       value,                  params IEnumerable<T>?       coll)                  =>                    coll?.Contains(value                  ) ?? false; 
    public static bool In<T>(     T       value,                  params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    public static bool In<T>(     T?      value,                  params IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value            ) ?? false);
    public static bool In<T>(     T?      value,                  params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    
    public static bool Contains(IEnumerable<string> source, string match, bool ignoreCase = false)
    {
        ThrowIfNull(source);
        return source.Any(x => (x ?? "").Equals(match, ignoreCase.ToStringComparison()));
    }

    // Plain Coalesce (for some)
    
    public static string Coalesce   (     string? value                  )                  => Has(value           ) ? value       : value ?? "";
    public static T      Coalesce<T>(     T?      value                  ) where T : new()  => Has(value           ) ? value       : new();
    public static T      Coalesce<T>(     T?      value                  ) where T : struct => Has(value           ) ? value.Value : default;
    
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
