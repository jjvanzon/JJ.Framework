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

    public static string Coalesce   (     string? value, string? fallback)                  => Has(value           ) ? value       : Coalesce(fallback)    ;
    public static string Coalesce   (     string? value, string? fallback, bool trimSpace)  => Has(value, trimSpace) ? value       : Coalesce(fallback)    ;
    public static string Coalesce   (     object? value, string? fallback)                  => Has(value           ) ? $"{value}"  : Coalesce(fallback)    ;
    public static string Coalesce<T>(     T       value, string? fallback) where T : struct => Has(value           ) ? $"{value}"  : Coalesce(fallback)    ;
    public static string Coalesce<T>(     T?      value, string? fallback) where T : struct => Has(value           ) ? $"{value}"  : Coalesce(fallback)    ;
    public static T      Coalesce<T>(     T       value, T       fallback) where T : struct => Has(value           ) ? value       : Coalesce(fallback)    ;
    public static T      Coalesce<T>(     T       value, T?      fallback) where T : struct => Has(value           ) ? value       : Coalesce(fallback)    ;
    public static T      Coalesce<T>(     T?      value, T       fallback) where T : struct => Has(value           ) ? value.Value : Coalesce(fallback)    ;
    public static T      Coalesce<T>(     T?      value, T?      fallback) where T : struct => Has(value           ) ? value.Value : Coalesce(fallback)    ;

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (     string? value, string? fallback, string? fallback2)                  => Coalesce(value, Coalesce(fallback, fallback2));
    public static string Coalesce   (     string? value, string? fallback, string? fallback2, bool trimSpace)  => Coalesce(value, Coalesce(fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce<T>(     T       value, T       fallback, string? fallback2)                  => Coalesce(value, Coalesce(fallback, fallback2));
    public static string Coalesce<T>(     T?      value, T?      fallback, string? fallback2) where T : struct => Coalesce(value, Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(     T       value, T       fallback, T       fallback2) where T : new()  => Coalesce(value, Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(     T?      value, T?      fallback, T?      fallback2) where T : struct => Coalesce(value, Coalesce(fallback, fallback2));

    // Variadic Fallbacks

    public static string Coalesce(params IEnumerable<string?>? fallbacks)
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

    public static T Coalesce<T>(params IEnumerable<T>? fallbacks)
        where T: new()
    {
        if (fallbacks == null) return new();
        
        T last = default;
        
        foreach (var fallback in fallbacks)
        {
            if (Has(fallback)) return fallback;
            last = fallback;
        }
        
        return last ?? new();
    }
    
    public static T Coalesce<T>(params IEnumerable<T?>? fallbacks) where T: struct 
    {
        if (fallbacks == null) return default(T);

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
        
        return last ?? default(T);
    }
}
