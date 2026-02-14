// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{ 




           // Prio(-1) with bool flags, to prefer booleans as values, not as flags, except when the flag is explicitly named..

           // 1 Arg
       
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool    val )                  => CoalesceBool     (val );
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool?   val )                  => CoalesceBoolNully(val );
       
           // 2 Args
           
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool?   val,  bool?   fallback                          )                  => CoalesceTwoNullyVals  (val, fallback             );
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool?   val,  bool    fallback                          )                  => CoalesceNullyAndVal   (val, fallback             );
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool    val,  bool?   fallback                          )                  => CoalesceValAndNully   (val, fallback             );
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool    val,  bool    fallback                          )                  => CoalesceTwoVals       (val, fallback             );
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceTwoNullyVals  (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                                
[Prio(-1)] public static bool   Coalesce   (     bool?   val,  bool    fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyAndVal   (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                                
[Prio(-1)] public static bool   Coalesce   (     bool    val,  bool?   fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceValAndNully   (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                                
[Prio(-1)] public static bool   Coalesce   (     bool    val,  bool    fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceTwoVals       (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool?   val,  bool?   fallback, ZeroMatters  zeroMatters)                  => CoalesceTwoNullyVals  (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool?   val,  bool    fallback, ZeroMatters  zeroMatters)                  => CoalesceNullyAndVal   (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool    val,  bool?   fallback, ZeroMatters  zeroMatters)                  => CoalesceValAndNully   (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     bool    val,  bool    fallback, ZeroMatters  zeroMatters)                  => CoalesceTwoVals       (val, fallback, zeroMatters);
         // Clash with 3-Arg                                                                                                
         ///// <inheritdoc cref="_coalesce" />                                                                              
         //public static bool   Coalesce   (     bool         zeroMatters, bool?   val,  bool?   fallback)                  => CoalesceTwoNullyVals  (val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                              
         //public static bool   Coalesce   (     bool         zeroMatters, bool?   val,  bool    fallback)                  => CoalesceNullyAndVal   (val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                              
         //public static bool   Coalesce   (     bool         zeroMatters, bool    val,  bool?   fallback)                  => CoalesceValAndNully   (val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                              
         //public static bool   Coalesce   (     bool         zeroMatters, bool    val,  bool    fallback)                  => CoalesceTwoVals       (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool?   val,  bool?   fallback)                  => CoalesceTwoNullyVals  (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool?   val,  bool    fallback)                  => CoalesceNullyAndVal   (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool    val,  bool?   fallback)                  => CoalesceValAndNully   (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                              
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool    val,  bool    fallback)                  => CoalesceTwoVals       (val, fallback, zeroMatters);
       
           // 3 Args
           
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool?   fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool    fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool    fallback, bool?   fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool    fallback, bool    fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool?   fallback, bool?   fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool?   fallback, bool    fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool    fallback, bool?   fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool    fallback, bool    fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool?   val,  bool    fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool?   val,  bool    fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool    val,  bool?   fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool    val,  bool?   fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool    val,  bool    fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (     bool    val,  bool    fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool?   fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool    fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool?   val,  bool    fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool?   fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool?   fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool    fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     bool    val,  bool    fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
         // Clash with 4-Arg                                                                                                                    
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool?   val,  bool?   fallback, bool?   fallback2 )                                                   => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool?   val,  bool?   fallback, bool    fallback2 )                                                   => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool?   val,  bool    fallback, bool?   fallback2 )                                                   => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool?   val,  bool    fallback, bool    fallback2 )                                                   => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool    val,  bool?   fallback, bool?   fallback2 )                                                   => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool    val,  bool?   fallback, bool    fallback2 )                                                   => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool    val,  bool    fallback, bool?   fallback2 )                                                   => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                                                                   
         //public static bool   Coalesce   (     bool         zeroMatters, bool    val,  bool    fallback, bool    fallback2 )                                                   => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool?   val,  bool?   fallback, bool?   fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool?   val,  bool?   fallback, bool    fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool?   val,  bool    fallback, bool?   fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool?   val,  bool    fallback, bool    fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool    val,  bool?   fallback, bool?   fallback2 )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool    val,  bool?   fallback, bool    fallback2 )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool    val,  bool    fallback, bool?   fallback2 )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />                                                                                                  
           public static bool   Coalesce   (     ZeroMatters  zeroMatters, bool    val,  bool    fallback, bool    fallback2 )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
       
           // 4-Arg (only for bools)
 
           // * These help bools map to values, instead of unnamed flags.
           // * E.g. clashes with (T,T,T,bool) are by shadowed by (bool,bool,bool,bool), not (params bool).
       
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool  fallback1, bool  fallback2, bool    fallback3) => CoalesceManyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool  fallback1, bool  fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool  fallback1, bool? fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool  fallback1, bool? fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool? fallback1, bool  fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool? fallback1, bool  fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool? fallback1, bool? fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool  val, bool? fallback1, bool? fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool  fallback1, bool  fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool  fallback1, bool  fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool  fallback1, bool? fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool  fallback1, bool? fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool? fallback1, bool  fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool? fallback1, bool  fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool? fallback1, bool? fallback2, bool    fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (     bool? val, bool? fallback1, bool? fallback2, bool?   fallback3) => CoalesceManyNullyBools     ([val, fallback1, fallback2, fallback3]);
       
           // N Args
       
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (                                    params IEnumerable<bool?>?   fallbacks   ) => CoalesceManyNullyBools   (fallbacks);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool   Coalesce   (bool                  zeroMatters,  params IEnumerable<bool?>?   fallbacks   ) => CoalesceManyNullyBools   (fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (ZeroMatters           zeroMatters,  params IEnumerable<bool?>?   fallbacks   ) => CoalesceManyNullyBools   (fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (IEnumerable<bool?>?   fallbacks,    bool                         zeroMatters ) => CoalesceManyNullyBools   (fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool   Coalesce   (IEnumerable<bool?>?   fallbacks,    ZeroMatters                  zeroMatters ) => CoalesceManyNullyBools   (fallbacks, zeroMatters);
}
