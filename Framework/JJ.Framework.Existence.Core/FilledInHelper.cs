
// ReSharper disable RedundantNullableFlowAttribute
namespace JJ.Framework.Existence.Core;

internal static class ExistenceUtility
{
    public static bool   HasText          ([NotNullWhen(true)] string?         text)                 => !IsNullOrWhiteSpace(text);
    public static bool   HasText          ([NotNullWhen(true)] string?         text, bool trimSpace) =>  trimSpace ? !IsNullOrWhiteSpace(text): !IsNullOrEmpty(text);
    public static bool   HasObj           ([NotNullWhen(true)] object?         obj)                  =>  obj != null;
    public static bool   HasValtNonNull<T>([NotNullWhen(true)] T               val) where T : struct => !Equals(val, default(T));
    public static bool   HasValNullable<T>([NotNullWhen(true)] T?              val) where T : struct => !Equals(val, default(T?)) && !Equals(val, default(T));
    public static bool   HasCollection<T> ([NotNullWhen(true)] IEnumerable<T>? coll)                 =>  coll?.Any() ?? false;

    public static string CoalesceString     (string? text)                       => HasText       (text)            ? text      : text ?? "";
    public static string CoalesceString     (string? text, bool trimSpace)       => HasText       (text, trimSpace) ? text      : text ?? "";
    public static T      CoalesceObj        <T>(T    obj) where T : class, new() => HasObj        (obj)             ? obj       : new T()    ;
    public static T      CoalesceValNonNull <T>(T    val) where T : struct       => HasValtNonNull(val)             ? val       : default    ;
    public static T      CoalesceValNullable<T>(T?   val) where T : struct       => HasValNullable(val)             ? val.Value : default    ;
    
    public static string CoalesceTwoStrings(string? text, string? fallback)                 => HasText(text           ) ? text : CoalesceString(fallback);
    public static string CoalesceTwoStrings(string? text, string? fallback, bool trimSpace) => HasText(text, trimSpace) ? text : CoalesceString(fallback, trimSpace);
    
    public static string CoalesceSomethingToString<T>(bool hasObj, T obj, string fallback) => !hasObj ? CoalesceString(fallback) : CoalesceTwoStrings($"{obj}", fallback);
}

public static class FilledInHelper
{
    public static bool FilledIn   ([NotNullWhen(true)]       string?         text)                  =>  HasText(text);
    public static bool FilledIn   ([NotNullWhen(true)]       string?         text, bool trimSpace)  =>  HasText(text, trimSpace);
    public static bool FilledIn   ([NotNullWhen(true)]       object?         obj )                  =>  HasObj(obj);
    public static bool FilledIn<T>([NotNullWhen(true)]       T               val ) where T : struct =>  HasValtNonNull(val);
    public static bool FilledIn<T>([NotNullWhen(true)]       T?              val ) where T : struct =>  HasValNullable(val);
    public static bool FilledIn<T>([NotNullWhen(true)]       IEnumerable<T>? coll)                  =>  HasCollection(coll);
                                                             
    public static bool Has        ([NotNullWhen(true)]       string?         text)                  =>  HasText(text);
    public static bool Has        ([NotNullWhen(true)]       string?         text, bool trimSpace)  =>  HasText(text, trimSpace);
    public static bool Has        ([NotNullWhen(true)]       object?         obj )                  =>  HasObj(obj);
    public static bool Has<T>     ([NotNullWhen(true)]       T?              val ) where T : struct =>  HasValNullable(val);
    public static bool Has<T>     ([NotNullWhen(true)]       T               val ) where T : struct =>  HasValtNonNull(val);
    public static bool Has<T>     ([NotNullWhen(true)]       IEnumerable<T>? coll)                  =>  HasCollection(coll);
                                                             
    public static bool IsNully    ([NotNullWhen(false)]      string?         text)                  => !HasText(text);
    public static bool IsNully    ([NotNullWhen(false)]      string?         text, bool trimSpace)  => !HasText(text, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)]      object?         obj )                  => !HasObj(obj);
    public static bool IsNully<T> ([NotNullWhen(false)]      T?              val ) where T : struct => !HasValNullable(val);
    public static bool IsNully<T> ([NotNullWhen(false)]      T               val ) where T : struct => !HasValtNonNull(val);
    public static bool IsNully<T> ([NotNullWhen(false)]      IEnumerable<T>? coll)                  => !HasCollection(coll);
    
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
    
    public static string  Coalesce   (     string? text                 )                        => CoalesceString(text);
    public static T       Coalesce<T>(     T       obj                  ) where T : class, new() => CoalesceObj(obj);
    public static T       Coalesce<T>(     T?      val                  ) where T : struct       => CoalesceValNullable(val);
    
    // Single Fallback
    
    public static string Coalesce   (     string? text, string? fallback)                        => CoalesceTwoStrings(text, fallback);
    public static string Coalesce   (     string? text, string? fallback, bool trimSpace)        => CoalesceTwoStrings(text, fallback, trimSpace);
    public static string Coalesce   (     object? obj,  string? fallback)                        => CoalesceSomethingToString(HasObj        (obj), obj, fallback);
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct       => CoalesceSomethingToString(HasValNullable(val), val, fallback);
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct       => CoalesceSomethingToString(HasValtNonNull(val), val, fallback);
    
    public static T      Coalesce<T>(     object? obj, T?      fallback) where T : class, new() =>  HasObj        (obj) ? (T)obj    : CoalesceObj        (fallback);
    public static T      Coalesce<T>(     T?      val, T?      fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(     T?      val, T       fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNonNull (fallback);
    public static T      Coalesce<T>(     T       val, T?      fallback) where T : struct       =>  HasValtNonNull(val) ? val       : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(     T       val, T       fallback) where T : struct       =>  HasValtNonNull(val) ? val       : CoalesceValNonNull (fallback);

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (     string? text, string? fallback, string? fallback2)                  => Coalesce(text, Coalesce(fallback, fallback2));
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, bool trimSpace)  => Coalesce(text, Coalesce(fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce<T>(     T       obj,  T       fallback, string? fallback2)                  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(     T       obj,  T       fallback, T       fallback2) where T : new()  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(     T?      val,  T?      fallback, T?      fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));

    // Variadic Fallbacks

    public static string Coalesce(params IEnumerable<string?>? fallbacks)
    {
        if (fallbacks == null) return "";
        
        string? last = "";
        
        foreach (var text in fallbacks)
        {
            if (HasText(text)) return text;
            last = text;
        }
        
        return last ?? "";
    }

    public static T Coalesce<T>(params IEnumerable<T?>? fallbacks)
        where T: new()
    {
        if (fallbacks == null) return new();
        
        T last = default;
        
        foreach (var obj in fallbacks)
        {
            if (HasObj(obj)) return obj;
            last = obj;
        }
        
        return last ?? new();
    }
    
    public static T Coalesce<T>(params IEnumerable<T?>? fallbacks) 
        where T: struct 
    {
        if (fallbacks == null) return default(T);

        T? last = default;
        
        foreach (var val in fallbacks)
        {
            if (HasValNullable(val))
            {
                if (val is T ret)
                {
                    return ret;
                }
            }
            
            last = val;
        }
        
        return last ?? default(T);
    }
}
