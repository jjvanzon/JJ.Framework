// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{
           

    

           // Prio(-1) with bool flags, to prefer booleans as values, not as flags, except when the flag is explicitly named..

           // 1 Arg
         
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val) where T : struct => CoalesceVal     (val);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val) where T : struct => CoalesceValNully(val);
         
           // 2 Args
         
           /// <inheritdoc cref="_coalesce" /> 
           public static T    Coalesce<T>(     T?    val, T?    fallback                                                ) where T : struct => CoalesceTwoNullyVals(val, fallback);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T     fallback                                                ) where T : struct => CoalesceNullyAndVal (val, fallback);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T?    fallback                                                ) where T : struct => CoalesceValAndNully (val, fallback);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T     fallback                                                ) where T : struct => CoalesceTwoVals     (val, fallback);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T?    val, T?    fallback, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T?    val, T     fallback, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T     val, T?    fallback, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T     val, T     fallback, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T?    fallback, ZeroMatters zeroMatters                       ) where T : struct => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T     fallback, ZeroMatters zeroMatters                       ) where T : struct => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T?    fallback, ZeroMatters zeroMatters                       ) where T : struct => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T     fallback, ZeroMatters zeroMatters                       ) where T : struct => CoalesceTwoVals     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     bool        zeroMatters, T?    val, T?    fallback                       ) where T : struct => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     bool        zeroMatters, T?    val, T     fallback                       ) where T : struct => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     bool        zeroMatters, T     val, T?    fallback                       ) where T : struct => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     bool        zeroMatters, T     val, T     fallback                       ) where T : struct => CoalesceTwoVals     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters zeroMatters, T?    val, T?    fallback                       ) where T : struct => CoalesceTwoNullyVals(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters zeroMatters, T?    val, T     fallback                       ) where T : struct => CoalesceNullyAndVal (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters zeroMatters, T     val, T?    fallback                       ) where T : struct => CoalesceValAndNully (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters zeroMatters, T     val, T     fallback                       ) where T : struct => CoalesceTwoVals     (val, fallback, zeroMatters);

           // 3 Args

           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T?    fallback, T?    fallback2                                                ) where T : struct => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T?    fallback, T     fallback2                                                ) where T : struct => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T     fallback, T?    fallback2                                                ) where T : struct => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T     fallback, T     fallback2                                                ) where T : struct => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T?    fallback, T?    fallback2                                                ) where T : struct => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T?    fallback, T     fallback2                                                ) where T : struct => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T     fallback, T?    fallback2                                                ) where T : struct => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T     fallback, T     fallback2                                                ) where T : struct => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T?    val, T?    fallback, T?    fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T?    val, T?    fallback, T     fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T?    val, T     fallback, T?    fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T?    val, T     fallback, T     fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T     val, T?    fallback, T?    fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T     val, T?    fallback, T     fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T     val, T     fallback, T?    fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     T     val, T     fallback, T     fallback2, bool        zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T?    fallback, T?    fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceNullyAndVal(val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T?    fallback, T     fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceNullyAndVal(val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T     fallback, T?    fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceNullyAndVal(val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T?    val, T     fallback, T     fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceNullyAndVal(val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T?    fallback, T?    fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceTwoVals    (val, CoalesceTwoNullyVals(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T?    fallback, T     fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceTwoVals    (val, CoalesceNullyAndVal (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T     fallback, T?    fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceTwoVals    (val, CoalesceValAndNully (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     T     val, T     fallback, T     fallback2, ZeroMatters zeroMatters                       ) where T : struct => CoalesceTwoVals    (val, CoalesceTwoVals     (fallback, fallback2, zeroMatters), zeroMatters);

           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T?      val,  T?      fallback, T?      fallback2, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T?      val,  T?      fallback, T       fallback2, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T?      val,  T       fallback, T?      fallback2, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T?      val,  T       fallback, T       fallback2, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T       val,  T?      fallback, T?      fallback2, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T       val,  T?      fallback, T       fallback2, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T       val,  T       fallback, T?      fallback2, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(     bool         zeroMatters, T       val,  T       fallback, T       fallback2, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  T?      fallback, T?      fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  T?      fallback, T       fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  T       fallback, T?      fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  T       fallback, T       fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  T?      fallback, T?      fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  T?      fallback, T       fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  T       fallback, T?      fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  T       fallback, T       fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);

           // N Args

           // TODO: Clashes
         ///// <inheritdoc cref="_coalesce" />
         //public static T      Coalesce<T>(                                    params IEnumerable<T>?       fallbacks   ) where T : struct => CoalesceManyVals        (fallbacks);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(                                    params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyVals(fallbacks             );
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(bool                  zeroMatters,  params IEnumerable<T >?      fallbacks   ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T    Coalesce<T>(bool                  zeroMatters,  params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(ZeroMatters           zeroMatters,  params IEnumerable<T >?      fallbacks   ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(ZeroMatters           zeroMatters,  params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(IEnumerable<T >?      fallbacks,    bool                         zeroMatters ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(IEnumerable<T?>?      fallbacks,    bool                         zeroMatters ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(IEnumerable<T>?       fallbacks,    ZeroMatters                  zeroMatters ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T    Coalesce<T>(IEnumerable<T?>?      fallbacks,    ZeroMatters                  zeroMatters ) where T : struct => CoalesceManyVals(fallbacks, zeroMatters);
}
