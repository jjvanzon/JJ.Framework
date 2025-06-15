namespace JJ.Framework.Existence.Core;
using SB = StringBuilder;

/// <inheritdoc cref="_existencecore"/>
internal static partial class ExistenceUtility
{
    // 1 Arg
    
    // In 1-arg variants, when the input is empty, it may still be the best option, unless it is null.
    // This simplifies this code from having to do a Has-check.

    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceText          (string? text                  )                            => text ?? ""     ;
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceSB            (SB?     sb                    )                            => sb   ?? new()  ;
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceVal           <T>(T    val                   ) where T : struct           => val            ;
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceValNully      <T>(T?   val                   ) where T : struct           => val  ?? default;
    // ncrunch: no coverage start
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceObject        <T>(T?   obj                   ) where T : class, new()     => obj  ?? new T();
    // ncrunch: no coverage end
    
    // 2 Args
    
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceTwoTexts      (string? text, string? fallback                           ) => HasText    (text              ) ? text : $"{fallback}";
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceTwoTexts      (string? text, string? fallback, bool         spaceMatters) => HasText    (text, spaceMatters) ? text : $"{fallback}";
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceTwoTexts      (string? text, string? fallback, SpaceMatters spaceMatters) => HasText    (text, spaceMatters) ? text : $"{fallback}";
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceTextAndSB     (string? text, SB?     fallback                           ) => HasText    (text              ) ? text : $"{fallback}";
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceTextAndSB     (string? text, SB?     fallback, bool         spaceMatters) => HasText    (text, spaceMatters) ? text : $"{fallback}";
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceTextAndSB     (string? text, SB?     fallback, SpaceMatters spaceMatters) => HasText    (text, spaceMatters) ? text : $"{fallback}";
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceSBAndText     (SB?     sb,   string? fallback                           ) => CoalesceTwoTexts($"{sb}", CoalesceText(fallback));
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceSBAndText     (SB?     sb,   string? fallback, bool         spaceMatters) => CoalesceTwoTexts($"{sb}", CoalesceText(fallback), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceSBAndText     (SB?     sb,   string? fallback, SpaceMatters spaceMatters) => CoalesceTwoTexts($"{sb}", CoalesceText(fallback), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceTwoSBs        (SB?     sb,   SB?     fallback                           ) => HasSB      (sb                ) ? sb   : CoalesceSB(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceTwoSBs        (SB?     sb,   SB?     fallback, bool         spaceMatters) => HasSB      (sb,   spaceMatters) ? sb   : CoalesceSB(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceTwoSBs        (SB?     sb,   SB?     fallback, SpaceMatters spaceMatters) => HasSB      (sb,   spaceMatters) ? sb   : CoalesceSB(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceObjectToText  <T>(T?   obj,  string? fallback) where T : class            => HasObject  (obj) ? CoalesceTwoTexts($"{obj}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceNullyValToText<T>(T?   val,  string? fallback) where T : struct           => HasValNully(val) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceValToText     <T>(T    val,  string? fallback) where T : struct           => HasVal     (val) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoNullyVals  <T>(T?   val,  T?      fallback) where T : struct           => HasValNully(val) ? val.Value : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceNullyAndVal   <T>(T?   val,  T       fallback) where T : struct           => HasValNully(val) ? val.Value : CoalesceVal     (fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceValAndNully   <T>(T    val,  T?      fallback) where T : struct           => HasVal     (val) ? val       : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoVals       <T>(T    val,  T       fallback) where T : struct           => HasVal     (val) ? val       : CoalesceVal     (fallback);

    // ncrunch: no coverage start
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoObjects    <T>(T?   obj,  T?      fallback) where T : class, new()     => HasObject  (obj) ? obj       : CoalesceObject  (fallback);
    // ncrunch: no coverage end

    // N Args
    
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceManyTexts(params IEnumerable<string?>? fallbacks)
    {
        if (fallbacks == null) return "";
        string? last = default;
        foreach (var text in fallbacks)
        {
            if (HasText(text)) return text;
            last = text;
        }
        return last ?? "";
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceManyTexts(bool spaceMatters, params IEnumerable<string?>? fallbacks)
    {
        if (fallbacks == null) return "";
        string? last = default;
        foreach (var text in fallbacks)
        {
            if (HasText(text, spaceMatters)) return text;
            last = text;
        }
        return last ?? "";
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceManyTexts(SpaceMatters spaceMatters, params IEnumerable<string?>? fallbacks)
    {
        if (fallbacks == null) return "";
        string? last = default;
        foreach (var text in fallbacks)
        {
            if (HasText(text, spaceMatters)) return text;
            last = text;
        }
        return last ?? "";
    }
    
    
    
    /// <inheritdoc cref="_coalesce" />
    public static SB CoalesceManySBs(params IEnumerable<SB?>? fallbacks)
    {
        if (fallbacks == null) return new();
        SB? last = default;
        foreach (var sb in fallbacks)
        {
            if (HasSB(sb)) return sb;
            last = sb;
        }
        return last ?? new();
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static SB CoalesceManySBs(bool spaceMatters, params IEnumerable<SB?>? fallbacks)
    {
        if (fallbacks == null) return new();
        SB? last = default;
        foreach (var sb in fallbacks)
        {
            if (HasSB(sb, spaceMatters)) return sb;
            last = sb;
        }
        return last ?? new();
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static SB CoalesceManySBs(SpaceMatters spaceMatters, params IEnumerable<SB?>? fallbacks)
    {
        if (fallbacks == null) return new();
        SB? last = default;
        foreach (var sb in fallbacks)
        {
            if (HasSB(sb, spaceMatters)) return sb;
            last = sb;
        }
        return last ?? new();
    }
    
    /// <inheritdoc cref="_coalesce" />
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
    
    /// <inheritdoc cref="_coalesce" />
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

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{ 
    // [Prio] attributes:
    // string and StringBuilder overloads can clash if keywords like null are used as parameters.
    // [Prio(1)] for strings wins in this case, so that:
    // `Coalesce(" ", null, "Hi!")` => Coalesce(string, string string)

    // 1 Arg (for some)
    
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text)                  => CoalesceText    (text);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb  )                  => CoalesceSB      (sb  );
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val ) where T : struct => CoalesceVal     (val );
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val ) where T : struct => CoalesceValNully(val );
    
    // 2 Args (for text)
    
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static string Coalesce   (     string? text, string? fallback                           ) => CoalesceTwoTexts      (text, fallback);
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static string Coalesce   (     string? text, string? fallback, bool         spaceMatters) => CoalesceTwoTexts      (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static string Coalesce   (     string? text, string? fallback, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback                           ) => CoalesceTextAndSB     (text, fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, bool         spaceMatters) => CoalesceTextAndSB     (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SpaceMatters spaceMatters) => CoalesceTextAndSB     (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback                           ) => CoalesceSBAndText     (sb,   fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, bool         spaceMatters) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback                           ) => CoalesceTwoSBs        (sb,   fallback);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, bool         spaceMatters) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SpaceMatters spaceMatters) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
    // 2 Args (for some)
    
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     object? obj,  string? fallback)                            => CoalesceObjectToText  (obj,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(     T?      val,  string? fallback) where T : struct           => CoalesceNullyValToText(val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(     T       val,  string? fallback) where T : struct           => CoalesceValToText     (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val,  T?      fallback) where T : struct           => CoalesceTwoNullyVals  (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val,  T       fallback) where T : struct           => CoalesceNullyAndVal   (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val,  T?      fallback) where T : struct           => CoalesceValAndNully   (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val,  T       fallback) where T : struct           => CoalesceTwoVals       (val,  fallback);

    // 3 Args (for text)

    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static string Coalesce   (     string? text, string? fallback, string? fallback2                           ) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SB?     fallback2                           ) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, string? fallback2                           ) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SB?     fallback2                           ) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2                           ) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SB?     fallback2                           ) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2                           ) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2                           ) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);

    // 3 Args (for some)
    
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     object? obj,  object? fallback, string? fallback2)                  => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(     T       val,  T?      fallback, string? fallback2) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(     T?      val,  T       fallback, string? fallback2) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(     T       val,  T       fallback, string? fallback2) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val,  T?      fallback, T?      fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val,  T?      fallback, T       fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val,  T       fallback, T?      fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T?      val,  T       fallback, T       fallback2) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val,  T?      fallback, T?      fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val,  T?      fallback, T       fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val,  T       fallback, T?      fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(     T       val,  T       fallback, T       fallback2) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));

    // N Args (for all others)

    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (                           params IEnumerable<string?>? fallbacks) => CoalesceManyTexts  (              fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (bool         spaceMatters, params IEnumerable<string?>? fallbacks) => CoalesceManyTexts  (spaceMatters, fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (SpaceMatters spaceMatters, params IEnumerable<string?>? fallbacks) => CoalesceManyTexts  (spaceMatters, fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (                           params IEnumerable<SB?>?     fallbacks) => CoalesceManySBs    (              fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (bool         spaceMatters, params IEnumerable<SB?>?     fallbacks) => CoalesceManySBs    (spaceMatters, fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (SpaceMatters spaceMatters, params IEnumerable<SB?>?     fallbacks) => CoalesceManySBs    (spaceMatters, fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(params IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(params IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (fallbacks);
}

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInExtensions
{ 
    // [Prio] attributes:
    // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
    // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
    // Prio(2) on string.Coalesce() makes it win over IEnumerable<char> in string-specific calls.
    // Prio(2) on other string-only variants makes e.g. null be seen as string rather than StringBuilder.

    // 1 Arg (for some)

    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text)                  => CoalesceText    (text);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb  )                  => CoalesceSB      (sb);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val ) where T : struct => CoalesceVal     (val);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val ) where T : struct => CoalesceValNully(val);

    // 2 Args (for some)

    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text, string? fallback                           ) => CoalesceTwoTexts      (text, fallback);
    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text, string? fallback, bool         spaceMatters) => CoalesceTwoTexts      (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text, string? fallback, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback                           ) => CoalesceTextAndSB     (text, fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, bool         spaceMatters) => CoalesceTextAndSB     (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, SpaceMatters spaceMatters) => CoalesceTextAndSB     (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback                           ) => CoalesceSBAndText     (sb,   fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, bool         spaceMatters) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback                           ) => CoalesceTwoSBs        (sb,   fallback);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, bool         spaceMatters) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SpaceMatters spaceMatters) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this object? obj,  string? fallback)                            => CoalesceObjectToText  (obj,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(this T       val,  string? fallback) where T : struct           => CoalesceValToText     (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(this T?      val,  string? fallback) where T : struct           => CoalesceNullyValToText(val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val,  T?      fallback) where T : struct           => CoalesceTwoNullyVals  (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val,  T       fallback) where T : struct           => CoalesceNullyAndVal   (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val,  T?      fallback) where T : struct           => CoalesceValAndNully   (val,  fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val,  T       fallback) where T : struct           => CoalesceTwoVals       (val,  fallback);

    // 3 Args (for some)
    
    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text, string? fallback, string? fallback2                           ) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    [Prio(2)]
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, string? fallback, SB?     fallback2                           ) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, string? fallback2                           ) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, SB?     fallback2                           ) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? text, SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, string? fallback2                           ) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, SB?     fallback2                           ) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2                           ) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2                           ) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this object? obj,  object? fallback, string? fallback2)                            => CoalesceObjectToText  (obj,  CoalesceObjectToText  (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(this T       val,  T       fallback, string? fallback2) where T : struct           => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(this T       val,  T?      fallback, string? fallback2) where T : struct           => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(this T?      val,  T       fallback, string? fallback2) where T : struct           => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2) where T : struct           => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2) where T : struct           => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val,  T?      fallback, T       fallback2) where T : struct           => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val,  T       fallback, T?      fallback2) where T : struct           => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      val,  T       fallback, T       fallback2) where T : struct           => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val,  T?      fallback, T?      fallback2) where T : struct           => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val,  T?      fallback, T       fallback2) where T : struct           => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val,  T       fallback, T?      fallback2) where T : struct           => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       val,  T       fallback, T       fallback2) where T : struct           => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));

    // N Args (for all others)

    /// <inheritdoc cref="_coalesce" />
    [Prio(1)] 
    public static string Coalesce   (this IEnumerable<string?>? fallbacks)                  => CoalesceManyTexts  (fallbacks);
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)] 
    public static SB     Coalesce   (this IEnumerable<SB?>?     fallbacks)                  => CoalesceManySBs    (fallbacks);
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks) where T : new()  => CoalesceManyObjects(fallbacks);
    /// <inheritdoc cref="_coalesce" />
    [Prio(1)]
    public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks) where T : struct => CoalesceManyVals   (fallbacks);

    // TODO: spaceMatters variants.
    
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? first,                            params IEnumerable<string?>? fallbacks) => CoalesceManyTexts(              new [] { first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? first, bool         spaceMatters, params IEnumerable<string?>? fallbacks) => CoalesceManyTexts(spaceMatters, new [] { first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (this string? first, SpaceMatters spaceMatters, params IEnumerable<string?>? fallbacks) => CoalesceManyTexts(spaceMatters, new [] { first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     first,                            params IEnumerable<SB?>?     fallbacks) => CoalesceManySBs  (              new [] { first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     first, bool         spaceMatters, params IEnumerable<SB?>?     fallbacks) => CoalesceManySBs  (spaceMatters, new [] { first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (this SB?     first, SpaceMatters spaceMatters, params IEnumerable<SB?>?     fallbacks) => CoalesceManySBs  (spaceMatters, new [] { first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>? fallbacks) where T : new()  => CoalesceManyObjects(new [] {    first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>? fallbacks) where T : struct => CoalesceManyVals   (new [] {    first }.Concat(fallbacks ?? [ ]));
    /// <inheritdoc cref="_coalesce" />
    public static T      Coalesce<T>(this T       first, params IEnumerable<T?>? fallbacks) where T : struct => CoalesceManyVals   (new [] {(T?)first }.Concat(fallbacks ?? [ ]));
}