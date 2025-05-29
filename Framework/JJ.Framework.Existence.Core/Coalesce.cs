namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    // Arity 1
    
    public static  string CoalesceText          (string? text)                         => HasText    (text)            ? text      : text ?? "";
    public static  string CoalesceText          (string? text, bool trimSpace)         => HasText    (text, trimSpace) ? text      : text ?? "";
    public static  T      CoalesceObject        <T>(T?   obj ) where T : class, new()  => HasObject  (obj)             ? obj       : new T()   ;
    public static  T      CoalesceVal           <T>(T    val ) where T : struct        => HasVal     (val)             ? val       : default   ;
    public static  T      CoalesceValNully      <T>(T?   val ) where T : struct        => HasValNully(val)             ? val.Value : default   ;
    
    // Arity 2
    
    public static  string CoalesceTwoTexts      (string? text, string? fallback)                        => HasText(text           ) ? text : CoalesceText(fallback);
    public static  string CoalesceTwoTexts      (string? text, string? fallback, bool trimSpace)        => HasText(text, trimSpace) ? text : CoalesceText(fallback, trimSpace);
    
    public static  string CoalesceObjectToText  <T>(T?   obj,  string? fallback) where T : class        => CoalesceThingToText(HasObject  (obj), obj, fallback);
    public static  string CoalesceNullyValToText<T>(T?   val,  string? fallback) where T : struct       => CoalesceThingToText(HasValNully(val), val, fallback);
    public static  string CoalesceValToText     <T>(T    val,  string? fallback) where T : struct       => CoalesceThingToText(HasVal     (val), val, fallback);
    private static string CoalesceThingToText   (bool condition, object? obj, string? fallback)         => !condition ? CoalesceText(fallback) : CoalesceTwoTexts($"{obj}", fallback);
    
    public static  T      CoalesceTwoObjects    <T>(T?   obj,  T?      fallback) where T : class, new() => HasObject  (obj) ? obj       : CoalesceObject  (fallback);
    public static  T      CoalesceTwoNullyVals  <T>(T?   val,  T?      fallback) where T : struct       => HasValNully(val) ? val.Value : CoalesceValNully(fallback);
    public static  T      CoalesceNullyAndVal   <T>(T?   val,  T       fallback) where T : struct       => HasValNully(val) ? val.Value : CoalesceVal     (fallback);
    public static  T      CoalesceValAndNully   <T>(T    val,  T?      fallback) where T : struct       => HasVal     (val) ? val       : CoalesceValNully(fallback);
    public static  T      CoalesceTwoVals       <T>(T    val,  T       fallback) where T : struct       => HasVal     (val) ? val       : CoalesceVal     (fallback);
    
    // Arity N
    
    public static string CoalesceManyTexts(params IEnumerable<string?>? fallbacks)
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
    
    public static T CoalesceManyVals<T>(params IEnumerable<T?>? fallbacks)
        where T : struct 
    {
        if (fallbacks == null) return default(T);
        T? last = default;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val)) return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    public static T CoalesceManyObjects<T>(params IEnumerable<T?>? fallbacks)
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
}

public static partial class FilledInHelper
{ 
    // Arity 1 (for some)
    
    public static string Coalesce   (     string? text)                        => CoalesceText    (text);
    public static string Coalesce   (     string? text, bool trimSpace)        => CoalesceText    (text, trimSpace);
    public static T      Coalesce<T>(     T?      obj ) where T : class, new() => CoalesceObject  (obj);
    public static T      Coalesce<T>(     T?      val ) where T : struct       => CoalesceValNully(val);
    
    // Arity 2
    
    public static string Coalesce   (     string? text, string? fallback)                        => CoalesceTwoTexts      (text,     fallback);
    public static string Coalesce   (     string? text, string? fallback, bool trimSpace)        => CoalesceTwoTexts      (text,     fallback, trimSpace);
    public static string Coalesce   (     object? obj,  string? fallback)                        => CoalesceObjectToText  (obj,      fallback);
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct       => CoalesceNullyValToText(val,      fallback);
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct       => CoalesceValToText     (val,      fallback);
    
    public static T      Coalesce<T>(     object? obj,  T?      fallback) where T : class, new() => CoalesceTwoObjects    (obj as T, fallback);
    public static T      Coalesce<T>(     T?      val,  T?      fallback) where T : struct       => CoalesceTwoNullyVals  (val,      fallback);
    public static T      Coalesce<T>(     T?      val,  T       fallback) where T : struct       => CoalesceNullyAndVal   (val,      fallback);
    public static T      Coalesce<T>(     T       val,  T?      fallback) where T : struct       => CoalesceValAndNully   (val,      fallback);
    public static T      Coalesce<T>(     T       val,  T       fallback) where T : struct       => CoalesceTwoVals       (val,      fallback);

    // Arity 3 (for some)
    
    public static string Coalesce   (     string? text, string? fallback, string? fallback2)                        => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2));
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, bool trimSpace)        => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce   (     object? obj,  object? fallback, string? fallback2)                        => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));
    public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2) where T : struct       => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
    public static T      Coalesce<T>(     T       val,  T       fallback, T       fallback2) where T : class, new() => CoalesceTwoObjects    (val,  CoalesceTwoObjects    (fallback, fallback2));
    public static T      Coalesce<T>(     T?      val,  T?      fallback, T?      fallback2) where T : struct       => CoalesceTwoNullyVals  (val,  CoalesceTwoNullyVals  (fallback, fallback2));

    // Arity N

    public static string Coalesce   (params IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (fallbacks);
    public static T      Coalesce<T>(params IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(fallbacks);
    public static T      Coalesce<T>(params IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (fallbacks);
}

public static partial class FilledInExtensions
{ 
    // Arity 1

    public static string Coalesce   (this string? text)                        => CoalesceText    (text);
    public static string Coalesce   (this string? text, bool trimSpace)        => CoalesceText    (text, trimSpace);
    public static T      Coalesce<T>(this T?      obj ) where T : class, new() => CoalesceObject  (obj);
    public static T      Coalesce<T>(this T?      val ) where T : struct       => CoalesceValNully(val);

    // Arity 2

    public static string Coalesce   (this string? text, string? fallback)                        => CoalesceTwoTexts      (text, fallback);
    public static string Coalesce   (this string? text, string? fallback, bool trimSpace)        => CoalesceTwoTexts      (text, fallback, trimSpace);
    public static string Coalesce   (this object? obj,  string? fallback)                        => CoalesceObjectToText  (obj,  fallback);
    public static string Coalesce<T>(this T       val,  string? fallback) where T : struct       => CoalesceValToText     (val,  fallback);
    public static string Coalesce<T>(this T?      val,  string? fallback) where T : struct       => CoalesceNullyValToText(val,  fallback);

    public static T      Coalesce<T>(this object? obj,  T?      fallback) where T : class, new() => CoalesceTwoObjects    (obj as T, fallback);
    public static T      Coalesce<T>(this T?      val,  T?      fallback) where T : struct       => CoalesceTwoNullyVals  (val,      fallback);
    public static T      Coalesce<T>(this T?      val,  T       fallback) where T : struct       => CoalesceNullyAndVal   (val,      fallback);
    public static T      Coalesce<T>(this T       val,  T?      fallback) where T : struct       => CoalesceValAndNully   (val,      fallback);
    public static T      Coalesce<T>(this T       val,  T       fallback) where T : struct       => CoalesceTwoVals       (val,      fallback);

    // Arity 3 (for some)
    
    public static string Coalesce   (this string? text, string? fallback, string? fallback2)                        => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2));
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool trimSpace)        => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce   (this object? obj,  object? fallback, string? fallback2)                        => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));
    public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2) where T : struct       => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
    public static T      Coalesce<T>(this T       val,  T       fallback, T       fallback2) where T : class, new() => CoalesceTwoObjects    (val,  CoalesceTwoObjects    (fallback, fallback2));
    public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2) where T : struct       => CoalesceTwoNullyVals  (val,  CoalesceTwoNullyVals  (fallback, fallback2));

    // Arity N

    public static string Coalesce   (this                       IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (fallbacks);

    public static string Coalesce   (this string? first, params IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (new [] { first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(new [] { first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (new [] { first }.Concat(fallbacks ?? [ ]));
}