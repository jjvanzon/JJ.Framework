#pragma warning disable IDE0004
#pragma warning disable IDE0034
namespace JJ.Framework.Existence.Core;
using SB = StringBuilder;

/// <inheritdoc cref="_coalesce"/>
internal static class CoalesceUtil
{
    // 1 Arg
    
    // In 1-arg variants, when the input is empty, it may still be the best option, unless it is null.
    // This simplifies this code from having to do a Has-check.

    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceText          (string? text                  )                            => text ?? ""     ;
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceSB            (SB?     sb                    )                            => sb   ?? new()  ;
    ///// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceBool          (bool    val                   )                            => val            ;
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceBoolNully     (bool?   val                   )                            => val  ?? false;
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
    public static string CoalesceObjectToText  <T>(T?   obj,  string? fallback                           ) where T : class  => HasObject  (obj             ) ? CoalesceTwoTexts($"{obj}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceNullyValToText<T>(T?   val,  string? fallback                           ) where T : struct => HasValNully(val             ) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceNullyValToText<T>(T?   val,  string? fallback, bool         zeroMatters ) where T : struct => HasValNully(val, zeroMatters) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceNullyValToText<T>(T?   val,  string? fallback, ZeroMatters  zeroMatters ) where T : struct => HasValNully(val, zeroMatters) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceValToText     <T>(T    val,  string? fallback                           ) where T : struct => HasVal     (val             ) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceValToText     <T>(T    val,  string? fallback, bool         zeroMatters ) where T : struct => HasVal     (val, zeroMatters) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceValToText     <T>(T    val,  string? fallback, ZeroMatters  zeroMatters ) where T : struct => HasVal     (val, zeroMatters) ? CoalesceTwoTexts($"{val}", fallback) : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoNullyVals  <T>(T?   val,  T?      fallback                           ) where T : struct => HasValNully(val             ) ? val.Value : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoNullyVals  <T>(T?   val,  T?      fallback, bool         zeroMatters ) where T : struct => HasValNully(val, zeroMatters) ? val.Value : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoNullyVals  <T>(T?   val,  T?      fallback, ZeroMatters  zeroMatters ) where T : struct => HasValNully(val, zeroMatters) ? val.Value : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceNullyAndVal   <T>(T?   val,  T       fallback                           ) where T : struct => HasValNully(val             ) ? val.Value : CoalesceVal     (fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceNullyAndVal   <T>(T?   val,  T       fallback, bool         zeroMatters ) where T : struct => HasValNully(val, zeroMatters) ? val.Value : CoalesceVal     (fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceNullyAndVal   <T>(T?   val,  T       fallback, ZeroMatters  zeroMatters ) where T : struct => HasValNully(val, zeroMatters) ? val.Value : CoalesceVal     (fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceValAndNully   <T>(T    val,  T?      fallback                           ) where T : struct => HasVal     (val             ) ? val       : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceValAndNully   <T>(T    val,  T?      fallback, bool         zeroMatters ) where T : struct => HasVal     (val, zeroMatters) ? val       : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceValAndNully   <T>(T    val,  T?      fallback, ZeroMatters  zeroMatters ) where T : struct => HasVal     (val, zeroMatters) ? val       : CoalesceValNully(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoVals       <T>(T    val,  T       fallback                           ) where T : struct => HasVal     (val             ) ? val       : CoalesceVal     (fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoVals       <T>(T    val,  T       fallback, bool         zeroMatters ) where T : struct => HasVal     (val, zeroMatters) ? val       : CoalesceVal     (fallback);
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoVals       <T>(T    val,  T       fallback, ZeroMatters  zeroMatters ) where T : struct => HasVal     (val, zeroMatters) ? val       : CoalesceVal     (fallback);
    // ncrunch: no coverage start
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceTwoObjects    <T>(T?   obj,  T?      fallback                           ) where T : class, new() => HasObject  (obj) ? obj : CoalesceObject  (fallback);
    // ncrunch: no coverage end

    // Many Texts
    
    /// <inheritdoc cref="_coalesce" /> 
    public static string CoalesceManyTexts  (             IEnumerable<string?>? fallbacks                           )
    {
        if (fallbacks == null) 
            return "";

        string? last = default;
        foreach (var text in fallbacks)
        {
            if (HasText(text)) 
                return text;
            last = text;
        }
        return last ?? "";
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceManyTexts  (             IEnumerable<string?>? fallbacks, bool         spaceMatters)
    {
        if (fallbacks == null) 
            return "";

        string? last = default;
        foreach (var text in fallbacks)
        {
            if (HasText(text, spaceMatters)) 
                return text;
            last = text;
        }
        return last ?? "";
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceManyTexts  (             IEnumerable<string?>? fallbacks, SpaceMatters spaceMatters)
    {
        if (fallbacks == null) 
            return "";

        string? last = default;
        foreach (var text in fallbacks)
        {
            if (HasText(text, spaceMatters)) 
                return text;
            last = text;
        }
        return last ?? "";
    }

    // Many StringBuilders

    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceManySBs    (             IEnumerable<SB    ?>? fallbacks                           )
    {
        if (fallbacks == null) 
            return new();

        SB? last = default;
        foreach (var sb in fallbacks)
        {
            if (HasSB(sb)) 
                return sb;
            last = sb;
        }
        return last ?? new();
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceManySBs    (             IEnumerable<SB    ?>? fallbacks, bool         spaceMatters)
    {
        if (fallbacks == null) 
            return new();
        SB? last = default;
        foreach (var sb in fallbacks)
        {
            if (HasSB(sb, spaceMatters)) 
                return sb;
            last = sb;
        }
        return last ?? new();
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static SB     CoalesceManySBs    (             IEnumerable<SB    ?>? fallbacks, SpaceMatters spaceMatters)
    {
        if (fallbacks == null) 
            return new();
        SB? last = default;
        foreach (var sb in fallbacks)
        {
            if (HasSB(sb, spaceMatters)) 
                return sb;
            last = sb;
        }
        return last ?? new();
    }
              
    // Many Bools

    /// <inheritdoc cref="_coalesce" /> 
    public static bool   CoalesceManyBools  (             IEnumerable<bool   >? fallbacks                           )
    {
        if (fallbacks == null) 
            return false;
        foreach (bool boo in fallbacks)
        {
            if (boo) 
                return true;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (             IEnumerable<bool   >? fallbacks, bool         zeroMatters )
    {
        if (fallbacks == null) 
            return false;
        foreach (bool boo in fallbacks)
        {
            if (HasBool(boo, zeroMatters)) 
                return boo;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (             IEnumerable<bool   >? fallbacks, ZeroMatters  zeroMatters )
    {
        if (fallbacks == null) 
            return false;
        foreach (bool boo in fallbacks)
        {
            if (HasBool(boo, zeroMatters)) 
                return boo;
        } // ncrunch: no coverage
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (             IEnumerable<bool?  >? fallbacks                           )
    {
        if (fallbacks == null)
            return false;
        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo)) 
                return true;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (             IEnumerable<bool?  >? fallbacks, bool         zeroMatters )
    {
        if (fallbacks == null) 
            return false;
        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo, zeroMatters)) 
                return (bool)boo;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (             IEnumerable<bool?  >? fallbacks, ZeroMatters  zeroMatters )
    {
        if (fallbacks == null) 
            return false;
        foreach (var val in fallbacks)
        {
            if (HasBoolNully(val, zeroMatters)) 
                return (bool)val;
        }

        return false;
    }

    // Many Bools with First Arg
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool  first, IEnumerable<bool   >? fallbacks                           )
    {
        if (HasBool(first)) 
            return true;
        if (fallbacks == null)
            return false;

        foreach (bool boo in fallbacks)
        {
            if (boo) 
                return true;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool  first, IEnumerable<bool?  >? fallbacks                           )
    {
        if (HasBool(first)) 
            return true;
        if (fallbacks == null) 
            return false;
        
        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo)) 
                return true;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool? first, IEnumerable<bool   >? fallbacks                           )
    {
        if (HasBoolNully(first)) 
            return true;
        if (fallbacks == null) 
            return false;

        foreach (bool boo in fallbacks)
        {
            if (boo) 
                return true;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool? first, IEnumerable<bool?  >? fallbacks                           )
    {
        if (HasBoolNully(first)) 
            return true;
        if (fallbacks == null) 
            return false;
        
        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo))
                return true;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool  first, IEnumerable<bool   >? fallbacks, bool         zeroMatters )
    {
        if (HasBool(first, zeroMatters)) 
            return (bool)first;
        if (fallbacks == null) 
            return false;

        foreach (bool boo in fallbacks)
        {
            if (HasBool(boo, zeroMatters)) 
                return (bool)boo;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool  first, IEnumerable<bool?  >? fallbacks, bool         zeroMatters )
    {
        if (HasBool(first, zeroMatters)) 
            return (bool)first;
        if (fallbacks == null) 
            return false;

        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo, zeroMatters)) 
                return (bool)boo;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool? first, IEnumerable<bool   >? fallbacks, bool         zeroMatters )
    {
        if (HasBoolNully(first, zeroMatters)) 
            return (bool)first;
        if (fallbacks == null) 
            return false;

        foreach (bool boo in fallbacks)
        {
            if (HasBool(boo, zeroMatters)) 
                return (bool)boo;
        }
        return false;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool? first, IEnumerable<bool?  >? fallbacks, bool         zeroMatters )
    {
        if (HasBoolNully(first, zeroMatters)) 
            return (bool)first;
        if (fallbacks == null) 
            return false;

        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo, zeroMatters)) 
                return (bool)boo;
        }
        return false;
    }

    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool  first, IEnumerable<bool   >? fallbacks, ZeroMatters  zeroMatters ) 
        => first;

    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool  first, IEnumerable<bool?  >? fallbacks, ZeroMatters  zeroMatters ) 
        => first;

    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool? first, IEnumerable<bool   >? fallbacks, ZeroMatters  zeroMatters )
    {
        if (HasBoolNully(first, zeroMatters)) 
            return (bool)first;
        if (fallbacks == null) 
            return false;

        foreach (bool boo in fallbacks)
        {
            return (bool)boo;
        }
        return false;
    }
            
    /// <inheritdoc cref="_coalesce" />
    public static bool   CoalesceManyBools  (bool? first, IEnumerable<bool?  >? fallbacks, ZeroMatters  zeroMatters )
    {
        if (HasBoolNully(first, zeroMatters)) 
            return (bool)first;
        if (fallbacks == null) 
            return false;

        foreach (bool? boo in fallbacks)
        {
            if (HasBoolNully(boo, zeroMatters)) 
                return (bool)boo;
        }

        return false;
    }

    // Many Values
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(             IEnumerable<T      >? fallbacks                           )
        where T : struct 
    {
        // TODO: Probably unreachable because overload shadowed (check that)

        if (fallbacks == null) 
            return default(T);
        T last = default;
        foreach (var val in fallbacks)
        {
            if (HasVal(val))
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(             IEnumerable<T      >? fallbacks, bool         zeroMatters )
        where T : struct 
    {
        if (fallbacks == null) return 
            default(T);
        T last = default;
        foreach (var val in fallbacks)
        {
            if (HasVal(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(             IEnumerable<T      >? fallbacks, ZeroMatters  zeroMatters )
        where T : struct 
    {
        if (fallbacks == null) return 
            default(T);
        T last = default;
        foreach (var val in fallbacks)
        {
            if (HasVal(val, zeroMatters)) 
                return (T)val;
            last = val;
        }

        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(             IEnumerable<T?     >? fallbacks                           )
        where T : struct 
    {
        if (fallbacks == null) 
            return default(T);
        T? last = default;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val)) 
                return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(             IEnumerable<T?     >? fallbacks, bool         zeroMatters )
        where T : struct 
    {
        if (fallbacks == null) 
            return default(T);
        T? last = default;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(             IEnumerable<T?     >? fallbacks, ZeroMatters  zeroMatters )
        where T : struct 
    {
        if (fallbacks == null) 
            return default(T);
        T? last = default;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val, zeroMatters))
                return (T)val;
            last = val;
        }

        return last ?? default(T);
    }

    // Many Vals with First Arg
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T     first, IEnumerable<T      >? fallbacks                           )
        where T : struct 
    {
        if (HasVal(first)) 
            return (T)first;
        if (fallbacks == null)
            return first;

        T last = first;
        foreach (var val in fallbacks)
        {
            if (HasVal(val)) 
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T     first, IEnumerable<T?     >? fallbacks                           )
        where T : struct 
    {
        if (HasVal(first)) 
            return first;
        if (fallbacks == null) 
            return first;
        
        T? last = first;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val)) 
                return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T?    first, IEnumerable<T      >? fallbacks                           )
        where T : struct 
    {
        if (HasValNully(first)) 
            return (T)first;
        if (fallbacks == null) 
            return first ?? default(T);

        T last = first ?? default(T);
        foreach (var val in fallbacks)
        {
            if (HasVal(val)) 
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T?    first, IEnumerable<T?     >? fallbacks                           )
        where T : struct 
    {
        if (HasValNully(first)) 
            return (T)first;
        if (fallbacks == null) 
            return first ?? default(T);
        
        T? last = first;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val))
                return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T     first, IEnumerable<T      >? fallbacks, bool         zeroMatters )
        where T : struct
    {
        if (HasVal(first, zeroMatters)) 
            return (T)first;
        if (fallbacks == null) 
            return first;

        T last = first;
        foreach (var val in fallbacks)
        {
            if (HasVal(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T     first, IEnumerable<T?     >? fallbacks, bool         zeroMatters )
        where T : struct 
    {
        if (HasVal(first, zeroMatters)) 
            return (T)first;
        if (fallbacks == null) 
            return first;

        T? last = first;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T?    first, IEnumerable<T      >? fallbacks, bool         zeroMatters )
        where T : struct 
    {
        if (HasValNully(first, zeroMatters)) 
            return (T)first;
        if (fallbacks == null) 
            return first ?? default(T);

        T last = first ?? default(T);
        foreach (var val in fallbacks)
        {
            if (HasVal(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T?    first, IEnumerable<T?     >? fallbacks, bool         zeroMatters )
        where T : struct 
    {
        if (HasValNully(first, zeroMatters)) 
            return (T)first;
        if (fallbacks == null) 
            return first ?? default(T);

        T? last = first;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last ?? default(T);
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T     first, IEnumerable<T      >? fallbacks, ZeroMatters  zeroMatters )
        where T : struct
    {
        return first;
    }

    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T     first, IEnumerable<T?     >? fallbacks, ZeroMatters  zeroMatters )
        where T : struct
    {
        return first;
    }

    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T?    first, IEnumerable<T      >? fallbacks, ZeroMatters  zeroMatters )
        where T : struct 
    {
        if (HasValNully(first, zeroMatters)) 
            return (T)first;
        if (fallbacks == null) 
            return first ?? default(T);

        T last = first ?? default(T);
        foreach (var val in fallbacks)
        {
            if (HasVal(val, zeroMatters)) 
                return (T)val;
            last = val;
        }
        return last;
    }
    
    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyVals<T>(T?    first, IEnumerable<T?     >? fallbacks, ZeroMatters  zeroMatters )
        where T : struct 
    {
        if (HasValNully(first, zeroMatters)) 
            return (T)first;
        if (fallbacks == null) 
            return first ?? default(T);

        T? last = first;
        foreach (var val in fallbacks)
        {
            if (HasValNully(val, zeroMatters)) 
                return (T)val;
            last = val;
        }

        return last ?? default(T);
    }

    // Many Objects

    /// <inheritdoc cref="_coalesce" />
    public static T      CoalesceManyObjects<T>(          IEnumerable<T?     >? fallbacks                           )
        where T: new()
    {
        if (fallbacks == null) 
            return new T();
        T? last = default;
        foreach (var obj in fallbacks)
        {
            if (HasObject(obj))
                return obj;
            last = obj;
        }
        return last ?? new T();
    }
}
