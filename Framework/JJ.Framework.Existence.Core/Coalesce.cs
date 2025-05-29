namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{ 
    public static string  CoalesceText           (string? text)                                   => HasText       (text)            ? text      : text ?? "";
    public static string  CoalesceText           (string? text, bool trimSpace)                   => HasText       (text, trimSpace) ? text      : text ?? "";
    public static T       CoalesceObject         <T>(T?   obj ) where T : class, new()            => HasObject     (obj)             ? obj       : new T()   ;
    public static T       CoalesceValNonNull     <T>(T    val ) where T : struct                  => HasValNonNull (val)             ? val       : default   ;
    public static T       CoalesceValNullable    <T>(T?   val ) where T : struct                  => HasValNullable(val)             ? val.Value : default   ;
    
    public static string  CoalesceTwoTexts       (string? text, string? fallback)                 => HasText(text           ) ? text : CoalesceText(fallback);
    public static string  CoalesceTwoTexts       (string? text, string? fallback, bool trimSpace) => HasText(text, trimSpace) ? text : CoalesceText(fallback, trimSpace);
    
    public static string  CoalesceObjectToText   <T>(T? obj, string? fallback) where T : class  => CoalesceThingToText(HasObject     (obj), obj, fallback);
    public static string  CoalesceNullyValToText <T>(T? val, string? fallback) where T : struct => CoalesceThingToText(HasValNullable(val), val, fallback);
    public static string  CoalesceNoNullValToText<T>(T  val, string? fallback) where T : struct => CoalesceThingToText(HasValNonNull (val), val, fallback);
    private static string CoalesceThingToText    (bool condition, object? obj, string? fallback) => !condition ? CoalesceText(fallback) : CoalesceTwoTexts($"{obj}", fallback);
    
    public static T CoalesceTwoObjects <T>(T? obj, T? fallback) where T : class, new()  => HasObject(obj) ? obj : CoalesceObject(fallback);
}

public static partial class FilledInHelper
{ 
    // Plain Coalesce (for some)
    
    public static string Coalesce   (     string? text)                        => CoalesceText(text);
    public static string Coalesce   (     string? text, bool trimSpace)        => CoalesceText(text, trimSpace);
    public static T      Coalesce<T>(     T       obj ) where T : class, new() => CoalesceObject(obj);
    public static T      Coalesce<T>(     T?      val ) where T : struct       => CoalesceValNullable(val);
    
    // Single Fallback
    
    public static string Coalesce   (     string? text, string? fallback)                        => CoalesceTwoTexts       (text, fallback);
    public static string Coalesce   (     string? text, string? fallback, bool trimSpace)        => CoalesceTwoTexts       (text, fallback, trimSpace);
    public static string Coalesce   (     object? obj,  string? fallback)                        => CoalesceObjectToText   (obj, fallback);
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct       => CoalesceNullyValToText (val, fallback);
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct       => CoalesceNoNullValToText(val, fallback);
    
    public static T      Coalesce<T>(     object? obj,  T?      fallback) where T : class, new() =>  CoalesceTwoObjects(obj as T, fallback);
    public static T      Coalesce<T>(     T?      val,  T?      fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(     T?      val,  T       fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNonNull (fallback);
    public static T      Coalesce<T>(     T       val,  T?      fallback) where T : struct       =>  HasValNonNull (val) ? val       : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(     T       val,  T       fallback) where T : struct       =>  HasValNonNull (val) ? val       : CoalesceValNonNull (fallback);

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
        if (fallbacks == null) return new T();
        T? last = default;
        foreach (var obj in fallbacks)
        {
            if (HasObject(obj)) return obj;
            last = obj;
        }
        return last ?? new T();
    }
    
    public static T Coalesce<T>(params IEnumerable<T?>? fallbacks) 
        where T: struct 
    {
        if (fallbacks == null) return default(T);
        T? last = default;
        foreach (var val in fallbacks)
        {
            if (HasValNullable(val)) return (T)val;
            //if (HasValNullable(val))
            //{
            //    if (val is T ret)
            //    {
            //        return ret;
            //    }
            //}
            last = val;
        }
        return last ?? default(T);
    }
}

public static partial class FilledInExtensions
{ 
    // Plain Coalesce (for some)

    public static string Coalesce   (this string? text)                        => CoalesceText(text);
    public static T      Coalesce<T>(this T?      obj ) where T : class, new() => CoalesceObject(obj);
    public static T      Coalesce<T>(this T?      val ) where T : struct       => CoalesceValNullable(val);

    // Single Fallback

    public static string Coalesce   (this string? text, string? fallback)                        => CoalesceTwoTexts       (text, fallback);
    public static string Coalesce   (this string? text, string? fallback, bool trimSpace)        => CoalesceTwoTexts       (text, fallback, trimSpace);
    public static string Coalesce   (this object? obj,  string? fallback)                        => CoalesceObjectToText   (obj, fallback);
    public static string Coalesce<T>(this T       val,  string? fallback) where T : struct       => CoalesceNoNullValToText(val, fallback);
    public static string Coalesce<T>(this T?      val,  string? fallback) where T : struct       => CoalesceNullyValToText (val, fallback);
    
    public static T      Coalesce<T>(this object? obj,  T?      fallback) where T : class, new() => HasObject     (obj) ? (T)obj    : CoalesceObject     (fallback);
    public static T      Coalesce<T>(this T?      val,  T?      fallback) where T : struct       => HasValNullable(val) ? val.Value : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(this T?      val,  T       fallback) where T : struct       => HasValNullable(val) ? val.Value : CoalesceValNonNull (fallback);
    public static T      Coalesce<T>(this T       val,  T?      fallback) where T : struct       => HasValNonNull (val) ? val       : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(this T       val,  T       fallback) where T : struct       => HasValNonNull (val) ? val       : CoalesceValNonNull (fallback);

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (this string? text, string? fallback, string? fallback2)                  => Coalesce(text, Coalesce(fallback, fallback2));
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool trimSpace)  => Coalesce(text, Coalesce(fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce<T>(this T       obj,  T       fallback, string? fallback2)                  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(this T       obj,  T       fallback, T       fallback2) where T : new()  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));

    // Variadic Fallbacks

    public static string Coalesce   (this                       IEnumerable<string?>? fallbacks)                  => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : new()  => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(fallbacks);

    public static string Coalesce   (this string? first, params IEnumerable<string?>? fallbacks)                  => FilledInHelper.Coalesce(new [] { first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : new()  => FilledInHelper.Coalesce(new [] { first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(new [] { first }.Concat(fallbacks ?? [ ]));
}