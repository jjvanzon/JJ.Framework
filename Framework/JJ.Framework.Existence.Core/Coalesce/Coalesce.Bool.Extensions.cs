// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_coalesce"/>
public static class CoalesceBoolExtensions
{
           // [Prio] attributes:
           // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
           // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
           // Prio(-1) with bool flags, to prefer booleans as values, not as flags, except when the flag is explicitly named.
           
           // 1 Arg
 
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val) => CoalesceBool     (val);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val) => CoalesceBoolNully(val);
 
           // 2 Args
 
           /// <inheritdoc cref="_coalesce" /> 
           public static bool Coalesce   (this bool? val, bool? fallback                                                ) => CoalesceTwoNullyVals(val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback                                                ) => CoalesceNullyAndVal (val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback                                                ) => CoalesceValAndNully (val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback                                                ) => CoalesceTwoVals     (val, fallback             );
           // ReSharper disable UnusedParameter.Global
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? val, bool? fallback, bool        zeroMatters, NameOvl ovl = default) => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? val, bool  fallback, bool        zeroMatters, NameOvl ovl = default) => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  val, bool? fallback, bool        zeroMatters, NameOvl ovl = default) => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  val, bool  fallback, bool        zeroMatters, NameOvl ovl = default) => CoalesceTwoVals     (val, fallback, zeroMatters);
           // ReSharper restore UnusedParameter.Global
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback, ZeroMatters zeroMatters                       ) => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback, ZeroMatters zeroMatters                       ) => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback, ZeroMatters zeroMatters                       ) => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback, ZeroMatters zeroMatters                       ) => CoalesceTwoVals     (val, fallback, zeroMatters);
         // Clashes 3-Arg                                                                                                    
         ///// <inheritdoc cref="_coalesce" />
         //public static bool Coalesce   (this bool? val, bool        zeroMatters, bool? fallback                       ) => CoalesceTwoNullyVals(val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                          
         //public static bool Coalesce   (this bool? val, bool        zeroMatters, bool  fallback                       ) => CoalesceNullyAndVal (val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                          
         //public static bool Coalesce   (this bool  val, bool        zeroMatters, bool? fallback                       ) => CoalesceValAndNully (val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                          
         //public static bool Coalesce   (this bool  val, bool        zeroMatters, bool  fallback                       ) => CoalesceTwoVals     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, ZeroMatters zeroMatters, bool? fallback                       ) => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, ZeroMatters zeroMatters, bool  fallback                       ) => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, ZeroMatters zeroMatters, bool? fallback                       ) => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, ZeroMatters zeroMatters, bool  fallback                       ) => CoalesceTwoVals     (val, fallback, zeroMatters);
 
           // 3 Args
 
           /// <inheritdoc cref="_coalesce" /> 
           public static bool Coalesce   (this bool? val, bool? fallback, bool? fallback2                                                ) => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback, bool  fallback2                                                ) => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback, bool? fallback2                                                ) => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback, bool  fallback2                                                ) => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback, bool? fallback2                                                ) => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback, bool  fallback2                                                ) => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback, bool? fallback2                                                ) => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback, bool  fallback2                                                ) => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2));
           // ReSharper disable UnusedParameter.Global
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? val, bool? fallback, bool? fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? val, bool? fallback, bool  fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? val, bool  fallback, bool? fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? val, bool  fallback, bool  fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  val, bool? fallback, bool? fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  val, bool? fallback, bool  fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  val, bool  fallback, bool? fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  val, bool  fallback, bool  fallback2, bool        zeroMatters, NameOvl ovl = default) => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           // ReSharper restore UnusedParameter.Global
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback, bool? fallback2, ZeroMatters zeroMatters                       ) => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback, bool  fallback2, ZeroMatters zeroMatters                       ) => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback, bool? fallback2, ZeroMatters zeroMatters                       ) => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback, bool  fallback2, ZeroMatters zeroMatters                       ) => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback, bool? fallback2, ZeroMatters zeroMatters                       ) => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback, bool  fallback2, ZeroMatters zeroMatters                       ) => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback, bool? fallback2, ZeroMatters zeroMatters                       ) => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback, bool  fallback2, ZeroMatters zeroMatters                       ) => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
         // Clash with 4-arg: Use named flag instead
         ///// <inheritdoc cref="_coalesce" />
         //public static bool Coalesce   (this bool? val, bool zeroMatters, bool? fallback, bool? fallback2                              ) => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool? val, bool zeroMatters, bool? fallback, bool  fallback2                              ) => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool? val, bool zeroMatters, bool  fallback, bool? fallback2                              ) => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool? val, bool zeroMatters, bool  fallback, bool  fallback2                              ) => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool  val, bool zeroMatters, bool? fallback, bool? fallback2                              ) => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool  val, bool zeroMatters, bool? fallback, bool  fallback2                              ) => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool  val, bool zeroMatters, bool  fallback, bool? fallback2                              ) => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />                                                                                           
         //public static bool Coalesce   (this bool  val, bool zeroMatters, bool  fallback, bool  fallback2                              ) => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, ZeroMatters zeroMatters, bool? fallback, bool? fallback2                       ) => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, ZeroMatters zeroMatters, bool? fallback, bool  fallback2                       ) => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, ZeroMatters zeroMatters, bool  fallback, bool? fallback2                       ) => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, ZeroMatters zeroMatters, bool  fallback, bool  fallback2                       ) => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, ZeroMatters zeroMatters, bool? fallback, bool? fallback2                       ) => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, ZeroMatters zeroMatters, bool? fallback, bool  fallback2                       ) => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, ZeroMatters zeroMatters, bool  fallback, bool? fallback2                       ) => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, ZeroMatters zeroMatters, bool  fallback, bool  fallback2                       ) => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           
           // 4 Args (only for bools)
 
           // * These help bools map to values, instead of unnamed flags.
           // * For instance (bool,bool,bool,bool) shadows (T,T,T,bool) whereas (params bool[]) alone can't.
           // * String variants like (bool,bool,bool,string) shadow (bool,T,T,string) overloads.
 
           /// <inheritdoc cref="_coalesce" /> 
           public static bool Coalesce   (this bool  val, bool  fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool  fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  val, bool? fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool  fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? val, bool? fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
 
           // N Args

           /// <inheritdoc cref="_coalesce" /> 
[Prio(1)]  public static bool Coalesce   (this IEnumerable<bool> ? fallbacks                         ) => CoalesceManyBools(fallbacks             );
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static bool Coalesce   (this IEnumerable<bool?>? fallbacks                         ) => CoalesceManyBools(fallbacks             );
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static bool Coalesce   (this IEnumerable<bool> ? fallbacks, bool        zeroMatters) => CoalesceManyBools(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static bool Coalesce   (this IEnumerable<bool?>? fallbacks, bool        zeroMatters) => CoalesceManyBools(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static bool Coalesce   (this IEnumerable<bool> ? fallbacks, ZeroMatters zeroMatters) => CoalesceManyBools(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static bool Coalesce   (this IEnumerable<bool?>? fallbacks, ZeroMatters zeroMatters) => CoalesceManyBools(fallbacks, zeroMatters);

           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first,                                  params IEnumerable<bool >? fallbacks  ) => CoalesceManyBools(first, fallbacks             );
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first,                                  params IEnumerable<bool >? fallbacks  ) => CoalesceManyBools(first, fallbacks             );
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first,                                  params IEnumerable<bool?>? fallbacks  ) => CoalesceManyBools(first, fallbacks             );
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first,                                  params IEnumerable<bool?>? fallbacks  ) => CoalesceManyBools(first, fallbacks             );
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  first, bool                zeroMatters, params IEnumerable<bool >? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? first, bool                zeroMatters, params IEnumerable<bool >? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool  first, bool                zeroMatters, params IEnumerable<bool?>? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static bool Coalesce   (this bool? first, bool                zeroMatters, params IEnumerable<bool?>? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first, ZeroMatters         zeroMatters, params IEnumerable<bool >? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first, ZeroMatters         zeroMatters, params IEnumerable<bool >? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first, ZeroMatters         zeroMatters, params IEnumerable<bool?>? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first, ZeroMatters         zeroMatters, params IEnumerable<bool?>? fallbacks  ) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first, IEnumerable<bool> ? fallbacks,   bool                       zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first, IEnumerable<bool> ? fallbacks,   bool                       zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first, IEnumerable<bool?>? fallbacks,   bool                       zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first, IEnumerable<bool?>? fallbacks,   bool                       zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first, IEnumerable<bool> ? fallbacks,   ZeroMatters                zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first, IEnumerable<bool> ? fallbacks,   ZeroMatters                zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool  first, IEnumerable<bool?>? fallbacks,   ZeroMatters                zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static bool Coalesce   (this bool? first, IEnumerable<bool?>? fallbacks,   ZeroMatters                zeroMatters) => CoalesceManyBools(first, fallbacks, zeroMatters);
}