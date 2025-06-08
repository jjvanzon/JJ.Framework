namespace JJ.Framework.Existence.Core;
using SB = StringBuilder;

internal static partial class ExistenceUtility
{
    // 1 Arg
    
    // TODO: Simplify logic like the next outcommented line is replaced by the one after that.
    // After some testing.
    
  //public static  string CoalesceText     (string? text)                         => HasText    (text) ? text      : text ?? ""   ;
    public static  string CoalesceText     (string? text)                         => text ?? ""   ;
    public static  SB     CoalesceSB       (SB?     sb  )                         => HasSB      (sb  ) ? sb        : sb   ?? new();
  //public static  SB     CoalesceSB       (SB?     sb  )                         => sb   ?? new();
    public static  T      CoalesceObject   <T>(T?   obj ) where T : class, new()  => HasObject  (obj ) ? obj       : new T()      ;
    public static  T      CoalesceVal      <T>(T    val ) where T : struct        => HasVal     (val ) ? val       : default      ;
    public static  T      CoalesceValNully <T>(T?   val ) where T : struct        => HasValNully(val ) ? val.Value : default      ;
    
    // 2 Args
    
    public static  string  CoalesceTwoTexts      (string? text, string? fallback)                  => HasText(text           ) ? text : CoalesceText(fallback);
    public static  string  CoalesceTwoTexts      (string? text, string? fallback, bool trimSpace)  => HasText(text, trimSpace) ? text : CoalesceText(fallback);
    public static  SB      CoalesceTwoSBs        (SB?     sb,   SB?     fallback)                  => HasSB  (sb             ) ? sb   : CoalesceSB  (fallback);
    public static  SB      CoalesceTwoSBs        (SB?     sb,   SB?     fallback, bool trimSpace)  => HasSB  (sb,   trimSpace) ? sb   : CoalesceSB  (fallback);
    
    public static  string  CoalesceSBToText      (SB?     sb,   string? fallback)                  => CoalesceConditionToText(HasSB      (sb           ), sb,  fallback);
    public static  string  CoalesceSBToText      (SB?     sb,   string? fallback, bool trimSpace)  => CoalesceConditionToText(HasSB      (sb, trimSpace), sb,  fallback);
    public static  string  CoalesceObjectToText  <T>(T?   obj,  string? fallback) where T : class  => CoalesceConditionToText(HasObject  (obj          ), obj, fallback);
    public static  string  CoalesceNullyValToText<T>(T?   val,  string? fallback) where T : struct => CoalesceConditionToText(HasValNully(val          ), val, fallback);
    public static  string  CoalesceValToText     <T>(T    val,  string? fallback) where T : struct => CoalesceConditionToText(HasVal     (val          ), val, fallback);
    private static string  CoalesceConditionToText(bool condition, object? obj, string? fallback) => !condition ? CoalesceText(fallback) : CoalesceTwoTexts($"{obj}", fallback);
                                                       
    public static  T       CoalesceTwoNullyVals  <T>(T?   val,  T?      fallback) where T : struct => HasValNully(val) ? val.Value : CoalesceValNully(fallback);
    public static  T       CoalesceNullyAndVal   <T>(T?   val,  T       fallback) where T : struct => HasValNully(val) ? val.Value : CoalesceVal     (fallback);
    public static  T       CoalesceValAndNully   <T>(T    val,  T?      fallback) where T : struct => HasVal     (val) ? val       : CoalesceValNully(fallback);
    public static  T       CoalesceTwoVals       <T>(T    val,  T       fallback) where T : struct => HasVal     (val) ? val       : CoalesceVal     (fallback);

    // ncrunch: no coverage start
    public static  T      CoalesceTwoObjects    <T>(T?   obj,  T?      fallback) where T : class, new() => HasObject  (obj) ? obj       : CoalesceObject  (fallback);
    // ncrunch: no coverage end

    // N Args
    
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
    // 1 Arg (for some)
    
    public static string Coalesce   (     string? text)                  => CoalesceText    (text);
    public static SB     Coalesce   (     SB?     sb  )                  => CoalesceSB      (sb  );
    public static T      Coalesce<T>(     T       val ) where T : struct => CoalesceVal     (val );
    public static T      Coalesce<T>(     T?      val ) where T : struct => CoalesceValNully(val );
    
    // 2 Args (for some)
    
    public static string Coalesce   (     string? text, string? fallback)                  => CoalesceTwoTexts(text, fallback);
    public static string Coalesce   (     string? text, string? fallback, bool trimSpace)  => CoalesceTwoTexts(text, fallback, trimSpace);
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback)                  => CoalesceTwoSBs  (sb,   fallback);
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, bool trimSpace)  => CoalesceTwoSBs  (sb,   fallback, trimSpace);

    public static string Coalesce   (     object? obj,  string? fallback)                  => CoalesceObjectToText  (obj,      fallback);
    public static string Coalesce   (     SB?     sb,   string? fallback)                  => CoalesceSBToText      (sb,       fallback);
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct => CoalesceNullyValToText(val,      fallback);
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct => CoalesceValToText     (val,      fallback);
    public static T      Coalesce<T>(     T?      val,  T?      fallback) where T : struct => CoalesceTwoNullyVals  (val,      fallback);
    public static T      Coalesce<T>(     T?      val,  T       fallback) where T : struct => CoalesceNullyAndVal   (val,      fallback);
    public static T      Coalesce<T>(     T       val,  T?      fallback) where T : struct => CoalesceValAndNully   (val,      fallback);
    public static T      Coalesce<T>(     T       val,  T       fallback) where T : struct => CoalesceTwoVals       (val,      fallback);

    // 3 Args (for some)
    
    public static string Coalesce   (     string? text, string? fallback, string? fallback2)                  => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2));
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, bool trimSpace)  => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, trimSpace), trimSpace);
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2)                  => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2));
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2, bool trimSpace)  => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2)                  => CoalesceSBToText      (sb,   CoalesceSBToText      (fallback, fallback2));
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2, bool trimSpace)  => CoalesceSBToText      (sb,   CoalesceSBToText      (fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce   (     object? obj,  object? fallback, string? fallback2)                  => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));
    public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
    public static string Coalesce<T>(     T       val,  T?      fallback, string? fallback2) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
    public static string Coalesce<T>(     T?      val,  T       fallback, string? fallback2) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
    public static string Coalesce<T>(     T       val,  T       fallback, string? fallback2) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
    public static T      Coalesce<T>(     T?      val,  T?      fallback, T?      fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    public static T      Coalesce<T>(     T?      val,  T?      fallback, T       fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
    public static T      Coalesce<T>(     T?      val,  T       fallback, T?      fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
    public static T      Coalesce<T>(     T?      val,  T       fallback, T       fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
    public static T      Coalesce<T>(     T       val,  T?      fallback, T?      fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    public static T      Coalesce<T>(     T       val,  T?      fallback, T       fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
    public static T      Coalesce<T>(     T       val,  T       fallback, T?      fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
    public static T      Coalesce<T>(     T       val,  T       fallback, T       fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));

    // N Args (for all others)

    public static string Coalesce   (params IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (fallbacks);
    public static T      Coalesce<T>(params IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(fallbacks);
    public static T      Coalesce<T>(params IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (fallbacks);
}

public static partial class FilledInExtensions
{ 
    // [Prio] attributes:
    // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
    // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
    // Prio(2) on string.Coalesce() makes it win over IEnumerable<char> in string-specific calls.

    // 1 Arg (for some)

    [Prio(2)]
    public static string Coalesce   (this string? text)                  => CoalesceText    (text);
    public static SB     Coalesce   (this SB?     sb  )                  => CoalesceSB      (sb);
    public static T      Coalesce<T>(this T       val ) where T : struct => CoalesceVal     (val);
    public static T      Coalesce<T>(this T?      val ) where T : struct => CoalesceValNully(val);

    // 2 Args (for some)

    public static string Coalesce   (this string? text, string? fallback)                  => CoalesceTwoTexts      (text, fallback);
    public static string Coalesce   (this string? text, string? fallback, bool trimSpace)  => CoalesceTwoTexts      (text, fallback, trimSpace);
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback)                  => CoalesceTwoSBs        (sb,   fallback);
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, bool trimSpace)  => CoalesceTwoSBs        (sb,   fallback, trimSpace);
    public static string Coalesce   (this SB?     sb,   string? fallback)                  => CoalesceSBToText      (sb,   fallback);
    public static string Coalesce   (this object? obj,  string? fallback)                  => CoalesceObjectToText  (obj,  fallback);
    public static string Coalesce<T>(this T       val,  string? fallback) where T : struct => CoalesceValToText     (val,  fallback);
    public static string Coalesce<T>(this T?      val,  string? fallback) where T : struct => CoalesceNullyValToText(val,  fallback);
    public static T      Coalesce<T>(this T?      val,  T?      fallback) where T : struct => CoalesceTwoNullyVals  (val,  fallback);
    public static T      Coalesce<T>(this T?      val,  T       fallback) where T : struct => CoalesceNullyAndVal   (val,  fallback);
    public static T      Coalesce<T>(this T       val,  T?      fallback) where T : struct => CoalesceValAndNully   (val,  fallback);
    public static T      Coalesce<T>(this T       val,  T       fallback) where T : struct => CoalesceTwoVals       (val,  fallback);

    // 3 Args (for some)
    
    public static string Coalesce   (this string? text, string? fallback, string? fallback2)                  => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2));
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool trimSpace)  => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, trimSpace), trimSpace);
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2)                  => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2));
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2, bool trimSpace)  => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2)                  => CoalesceSBToText      (sb,   CoalesceSBToText      (fallback, fallback2));
    public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2, bool trimSpace)  => CoalesceSBToText      (sb,   CoalesceSBToText      (fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce   (this object? obj,  object? fallback, string? fallback2)                  => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));
    public static string Coalesce<T>(this T       val,  T       fallback, string? fallback2) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
    public static string Coalesce<T>(this T       val,  T?      fallback, string? fallback2) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
    public static string Coalesce<T>(this T?      val,  T       fallback, string? fallback2) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
    public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
    public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    public static T      Coalesce<T>(this T?      val,  T?      fallback, T       fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
    public static T      Coalesce<T>(this T?      val,  T       fallback, T?      fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
    public static T      Coalesce<T>(this T?      val,  T       fallback, T       fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
    public static T      Coalesce<T>(this T       val,  T?      fallback, T?      fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    public static T      Coalesce<T>(this T       val,  T?      fallback, T       fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
    public static T      Coalesce<T>(this T       val,  T       fallback, T?      fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
    public static T      Coalesce<T>(this T       val,  T       fallback, T       fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));

    // N Args (for all others)

    [Prio(1)] public static string Coalesce   (this IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (fallbacks);
    [Prio(1)] public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(fallbacks);
    [Prio(1)] public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (fallbacks);

    public static string Coalesce   (this string? first, params IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (new [] {     first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(new [] {     first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (new [] {     first }.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T       first, params IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (new [] { (T?)first }.Concat(fallbacks ?? [ ]));
}