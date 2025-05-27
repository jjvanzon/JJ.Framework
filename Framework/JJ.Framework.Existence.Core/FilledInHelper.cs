
// ReSharper disable RedundantNullableFlowAttribute
namespace JJ.Framework.Existence.Core;

internal static class ExistenceUtility
{
    public static bool HasString           ([NotNullWhen(true)]       string?         value)                           => !IsNullOrWhiteSpace(value);
    public static bool HasString           ([NotNullWhen(true)]       string?         value, bool trimSpace)           => trimSpace ? !IsNullOrWhiteSpace(value): !IsNullOrEmpty(value);
    public static bool HasRef              ([NotNullWhen(true)]       object?         value)                           => value != null;
    // TODO: Replace the next 2 into one HasStruct method ??
    public static bool Default<T>          ([NotNullWhen(true)]       T               value) where T : notnull         => Equals(value, default(T));
    public static bool HasStructNonNull<T> ([NotNullWhen(true)]       T               value) where T : struct          => !Equals(value, default(T));
    public static bool HasStructNullable<T>([NotNullWhen(true)]       T?              value) where T : struct          => !Equals(value, default(T?)) && !Equals(value, default(T));
    public static bool HasCollection<T>    ([NotNullWhen(true)]       IEnumerable<T>? coll )                           => coll?.Any() ?? false;

    public static string CoalesceString   (string? value)                                        => HasString(value           ) ? value : value ?? "";
    public static string CoalesceString   (string? value, bool trimSpace)                        => HasString(value, trimSpace) ? value : value ?? "";
    public static T      CoalesceRef   <T>(T       value                ) where T : class, new() => HasRef   (value           ) ? value : new T();
    public static T      CoalesceStructNullable<T>(T?      value                ) where T : struct       => HasStructNullable(value           ) ? value.Value : default;
    public static T      CoalesceStructNonNull<T>(T      value                ) where T : struct       => HasStructNonNull(value           ) ? value : default;


    public static string CoalesceTwoStrings(string? value, string? fallback)                        => HasString(value           ) ? value       : CoalesceString(fallback);
    public static string CoalesceTwoStrings(string? value, string? fallback, bool trimSpace)        => HasString(value, trimSpace) ? value       : CoalesceString(fallback, trimSpace);
    
    public static string CoalesceObjectToString<T>(bool hasObj, T obj, string fallback) => !hasObj ? CoalesceString(fallback) : CoalesceTwoStrings($"{obj}", fallback);
    
    //public static string CoalesceRefToString(bool hasRef, object? obj, string fallback)       => !hasRef ? CoalesceString(fallback) : CoalesceStrings($"{obj}", fallback);
}

public static class FilledInHelper
{
    public static bool FilledIn   ([NotNullWhen(true)]       string?         text)                  => HasString(text);
    public static bool FilledIn   ([NotNullWhen(true)]       string?         text, bool trimSpace)  => HasString(text, trimSpace);
    public static bool FilledIn   ([NotNullWhen(true)]       object?         obj )                  => HasRef(obj);
    public static bool FilledIn<T>([NotNullWhen(true)]       T               val ) where T : struct => HasStructNonNull(val);
    public static bool FilledIn<T>([NotNullWhen(true)]       T?              val ) where T : struct => HasStructNullable(val);
    public static bool FilledIn<T>([NotNullWhen(true)]       IEnumerable<T>? coll)                  => HasCollection(coll);
  //public static bool FilledIn<T>([NotNullWhen(true)]       T?              val) where T : notnull => !Default(val);
  //public static bool FilledIn<T>([NotNullWhen(true)]       T?              val) where T : new()   => !Default(val);
                                                             
    public static bool Has        ([NotNullWhen(true)]       string?         value)                   => HasString(value);
    public static bool Has        ([NotNullWhen(true)]       string?         value, bool trimSpace)   => HasString(value, trimSpace);
    public static bool Has        ([NotNullWhen(true)]       object?         value)                   => HasRef(value);
    public static bool Has<T>     ([NotNullWhen(true)]       T?              value) where T : struct  => HasStructNullable(value);
    public static bool Has<T>     ([NotNullWhen(true)]       T               value) where T : struct  => HasStructNonNull(value);
    public static bool Has<T>     ([NotNullWhen(true)]       IEnumerable<T>? coll )                   => HasCollection(coll);
  //public static bool Has<T>     ([NotNullWhen(true)]       T?              value) where T : notnull => !Default(value);
  //public static bool Has<T>     ([NotNullWhen(true)]       T?              value) where T : new()   => !Default(value);
                                                             
    public static bool IsNully    ([NotNullWhen(false)]      string?         value)                   => !HasString(value);
    public static bool IsNully    ([NotNullWhen(false)]      string?         value, bool trimSpace)   => !HasString(value, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)]      object?         value)                   => !HasRef(value);
    public static bool IsNully<T> ([NotNullWhen(false)]      T?              value) where T : struct  => !HasStructNullable(value);
    public static bool IsNully<T> ([NotNullWhen(false)]      T               value) where T : struct  => !HasStructNonNull(value);
    public static bool IsNully<T> ([NotNullWhen(false)]      IEnumerable<T>? coll )                   => !HasCollection(coll);
  //public static bool IsNully<T> ([NotNullWhen(false)]      T?              value) where T : notnull =>  Default(value);
  //public static bool IsNully<T> ([NotNullWhen(false)]      T               value) where T : struct  => !HasStruct<T>(value);
  //public static bool IsNully<T> ([NotNullWhen(false)]      T?              value) where T : new()   => !HasStruct(value);
    
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
    
    public static string  Coalesce   (     string? value                  )                        => CoalesceString(value);
    public static T       Coalesce<T>(     T       value                  ) where T : class, new() => CoalesceRef(value);
    public static T       Coalesce<T>(     T?      value                  ) where T : struct       => CoalesceStructNullable(value);
  //public static T?      Coalesce<T>(     T?      value                  ) where T : class        => HasRef        (value           ) ? value       : default;
  //public static T?      Coalesce<T>(     T?      value                  ) where T : new()        => HasRef        (value           ) ? value       : default;
  //public static T       Coalesce<T>(     T       value                  ) where T : notnull      => !Default      (value           ) ? value       : default;
    
    // Single Fallback
    
    public static string Coalesce   (     string? text, string? fallback)                        => CoalesceTwoStrings(text, fallback);
    public static string Coalesce   (     string? text, string? fallback, bool trimSpace)        => CoalesceTwoStrings(text, fallback, trimSpace);
    public static string Coalesce   (     object? val,  string? fallback)                        => CoalesceObjectToString(HasRef   (val), val, fallback);
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct       => CoalesceObjectToString(HasStructNullable(val), val, fallback);
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct       => CoalesceObjectToString(HasStructNonNull(val), val, fallback);
    
    public static T      Coalesce<T>(     object? value, T?      fallback) where T : class, new() =>  HasRef           (value) ? (T)value    : CoalesceRef(fallback);
    public static T      Coalesce<T>(     T?      value, T?      fallback) where T : struct       =>  HasStructNullable(value) ? value.Value : CoalesceStructNullable(fallback);
    public static T      Coalesce<T>(     T?      value, T       fallback) where T : struct       =>  HasStructNullable(value) ? value.Value : CoalesceStructNonNull (fallback);
    public static T      Coalesce<T>(     T       value, T?      fallback) where T : struct       =>  HasStructNonNull (value) ? value       : CoalesceStructNullable(fallback);
    public static T      Coalesce<T>(     T       value, T       fallback) where T : struct       =>  HasStructNonNull (value) ? value       : CoalesceStructNonNull (fallback);
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : notnull      => !Default      (value    ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : struct       => !NullOrDefault(value    ) ? value.Value : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : notnull      => !Default      (value    ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T       value, T       fallback) where T : struct       => Has(value               ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : new()        => Has(value                      ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T       value, T       fallback) where T : class, new() => !Default      (value           ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : new()        => !NullOrDefault(value           ) ? value.Value : Coalesce(fallback)    ;

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

    public static T Coalesce<T>(params IEnumerable<T?>? fallbacks)
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
    
    public static T Coalesce<T>(params IEnumerable<T?>? fallbacks) 
        where T: struct 
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
