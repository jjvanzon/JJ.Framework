namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{ 
    public static string CoalesceString     (string? text)                       => HasText       (text)            ? text      : text ?? "";
    public static string CoalesceString     (string? text, bool trimSpace)       => HasText       (text, trimSpace) ? text      : text ?? "";
    public static T      CoalesceObj        <T>(T    obj) where T : class, new() => HasObj        (obj)             ? obj       : new T()    ;
    public static T      CoalesceValNonNull <T>(T    val) where T : struct       => HasValNonNull(val)             ? val       : default    ;
    public static T      CoalesceValNullable<T>(T?   val) where T : struct       => HasValNullable(val)             ? val.Value : default    ;
    
    public static string CoalesceTwoStrings(string? text, string? fallback)                 => HasText(text           ) ? text : CoalesceString(fallback);
    public static string CoalesceTwoStrings(string? text, string? fallback, bool trimSpace) => HasText(text, trimSpace) ? text : CoalesceString(fallback, trimSpace);
    
    public static string CoalesceSomethingToString<T>(bool hasObj, T obj, string fallback) => !hasObj ? CoalesceString(fallback) : CoalesceTwoStrings($"{obj}", fallback);
}

public static partial class FilledInHelper
{ 
    // Plain Coalesce (for some)
    
    public static string  Coalesce   (     string? text                 )                        => CoalesceString(text);
    public static T       Coalesce<T>(     T       obj                  ) where T : class, new() => CoalesceObj(obj);
    public static T       Coalesce<T>(     T?      val                  ) where T : struct       => CoalesceValNullable(val);
    
    // Single Fallback
    
    public static string Coalesce   (     string? text, string? fallback)                        => CoalesceTwoStrings(text, fallback);
    public static string Coalesce   (     string? text, string? fallback, bool trimSpace)        => CoalesceTwoStrings(text, fallback, trimSpace);
    public static string Coalesce   (     object? obj,  string? fallback)                        => CoalesceSomethingToString(HasObj        (obj), obj, fallback);
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct       => CoalesceSomethingToString(HasValNullable(val), val, fallback);
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct       => CoalesceSomethingToString(HasValNonNull(val), val, fallback);
    
    public static T      Coalesce<T>(     object? obj, T?      fallback) where T : class, new() =>  HasObj        (obj) ? (T)obj    : CoalesceObj        (fallback);
    public static T      Coalesce<T>(     T?      val, T?      fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(     T?      val, T       fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNonNull (fallback);
    public static T      Coalesce<T>(     T       val, T?      fallback) where T : struct       =>  HasValNonNull (val) ? val       : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(     T       val, T       fallback) where T : struct       =>  HasValNonNull (val) ? val       : CoalesceValNonNull (fallback);

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

public static partial class FilledInExtensions
{ 
    // Plain Coalesce (for some)

    public static string Coalesce   (this string? text                   )                        => CoalesceString(text);
    public static T      Coalesce<T>(this T?      obj                    ) where T : class, new() => CoalesceObj(obj);
    public static T      Coalesce<T>(this T?      val                    ) where T : struct       => CoalesceValNullable(val);

    // Single Fallback

    public static string Coalesce   (this string? text, string? fallback)                 => CoalesceTwoStrings(text, fallback);
    public static string Coalesce   (this string? text, string? fallback, bool trimSpace) => CoalesceTwoStrings(text, fallback, trimSpace);
    public static string Coalesce   (this object? obj, string? fallback)                  => CoalesceSomethingToString(HasObj        (obj), obj, fallback);
    public static string Coalesce<T>(this T       val, string? fallback) where T : struct => CoalesceSomethingToString(HasValNonNull(val), val, fallback);
    public static string Coalesce<T>(this T?      val, string? fallback) where T : struct => CoalesceSomethingToString(HasValNullable(val), val, fallback);
    
    public static T      Coalesce<T>(this object? obj, T?      fallback) where T : class, new() =>  HasObj        (obj) ? (T)obj    : CoalesceObj(fallback);
    public static T      Coalesce<T>(this T?      val, T?      fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(this T?      val, T       fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNonNull (fallback);
    public static T      Coalesce<T>(this T       val, T?      fallback) where T : struct       =>  HasValNonNull(val) ? val       : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(this T       val, T       fallback) where T : struct       =>  HasValNonNull(val) ? val       : CoalesceValNonNull (fallback);

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (this string? text, string? fallback, string? fallback2)                  => Coalesce(text, Coalesce(fallback, fallback2));
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool trimSpace)  => Coalesce(text, Coalesce(fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce<T>(this T       obj, T        fallback, string? fallback2)                  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static string Coalesce<T>(this T?      val, T?       fallback, string? fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(this T       obj, T        fallback, T       fallback2) where T : new()  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(this T?      val, T?       fallback, T?      fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));

    // Variadic Fallbacks

    public static string Coalesce   (this                       IEnumerable<string?>? fallbacks)                  => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : new()  => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(fallbacks);

    public static string Coalesce   (this string? first, params IEnumerable<string?>? fallbacks)                  => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : new()  => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
}