// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_coalesce"/>
public static partial class CoalesceExtensions
{ 
           // [Prio] attributes:
           // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
           // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
           // Prio(-1) with bool flags, to prefer booleans as values, not as flags, except when the flag is explicitly named..
         
           // 1 Arg
           
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val ) where T : struct => CoalesceVal      (val);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val ) where T : struct => CoalesceValNully (val);
         
           // 2 Args
         
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T?      fallback                           ) where T : struct => CoalesceTwoNullyVals  (val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T       fallback                           ) where T : struct => CoalesceNullyAndVal   (val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T?      fallback                           ) where T : struct => CoalesceValAndNully   (val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T       fallback                           ) where T : struct => CoalesceTwoVals       (val,  fallback);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  T?      fallback, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  T       fallback, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  T?      fallback, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceValAndNully   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  T       fallback, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T?      fallback, ZeroMatters  zeroMatters ) where T : struct => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T       fallback, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T?      fallback, ZeroMatters  zeroMatters ) where T : struct => CoalesceValAndNully   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T       fallback, ZeroMatters  zeroMatters ) where T : struct => CoalesceTwoVals       (val,  fallback, zeroMatters);

           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  bool         zeroMatters, T?      fallback ) where T : struct => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  bool         zeroMatters, T       fallback ) where T : struct => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  bool         zeroMatters, T?      fallback ) where T : struct => CoalesceValAndNully   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  bool         zeroMatters, T       fallback ) where T : struct => CoalesceTwoVals       (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T?      fallback ) where T : struct => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T       fallback ) where T : struct => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T?      fallback ) where T : struct => CoalesceValAndNully   (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T       fallback ) where T : struct => CoalesceTwoVals       (val,  fallback, zeroMatters);

           // 3 Args
        
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2                           ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T?      fallback, T       fallback2                           ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T       fallback, T?      fallback2                           ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T       fallback, T       fallback2                           ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T?      fallback, T?      fallback2                           ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T?      fallback, T       fallback2                           ) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T       fallback, T?      fallback2                           ) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T       fallback, T       fallback2                           ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  T?      fallback, T       fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  T       fallback, T?      fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  T       fallback, T       fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  T?      fallback, T?      fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  T?      fallback, T       fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  T       fallback, T?      fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  T       fallback, T       fallback2, bool         zeroMatters, NameOvl ovl = default) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T?      fallback, T       fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T       fallback, T?      fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  T       fallback, T       fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T?      fallback, T?      fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T?      fallback, T       fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T       fallback, T?      fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  T       fallback, T       fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  bool         zeroMatters, T?      fallback, T?      fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  bool         zeroMatters, T?      fallback, T       fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  bool         zeroMatters, T       fallback, T?      fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      val,  bool         zeroMatters, T       fallback, T       fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  bool         zeroMatters, T?      fallback, T?      fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  bool         zeroMatters, T?      fallback, T       fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  bool         zeroMatters, T       fallback, T?      fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       val,  bool         zeroMatters, T       fallback, T       fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T?      fallback, T?      fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T?      fallback, T       fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T       fallback, T?      fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T       fallback, T       fallback2 ) where T : struct => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T?      fallback, T?      fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T?      fallback, T       fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T       fallback, T?      fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T       fallback, T       fallback2 ) where T : struct => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);

           // N Args
         
           // TODO: Clashes
           ///// <inheritdoc cref="_coalesce" />
//[Prio(1)] public static T     Coalesce<T>(this IEnumerable<T> ?      fallbacks                           ) where T : struct => CoalesceManyVals        (fallbacks);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks                           ) where T : struct => CoalesceManyNullyVals   (fallbacks);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static T      Coalesce<T>(this IEnumerable<T> ?      fallbacks, bool         zeroMatters ) where T : struct => CoalesceManyVals        (fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks, bool         zeroMatters ) where T : struct => CoalesceManyNullyVals   (fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static T      Coalesce<T>(this IEnumerable<T>?       fallbacks, ZeroMatters  zeroMatters ) where T : struct => CoalesceManyVals        (fallbacks, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(1)]  public static T      Coalesce<T>(this IEnumerable<T?>?      fallbacks, ZeroMatters  zeroMatters ) where T : struct => CoalesceManyNullyVals   (fallbacks, zeroMatters);

           // TODO: Faster implementations with Util methods.

           // TODO: Clashes
         ///// <inheritdoc cref="_coalesce" />
         //public static T      Coalesce<T>(this T       first,                                     params IEnumerable<T> ?      fallbacks   ) where T : struct => CoalesceManyVals        (new [] {       first }.Concat(fallbacks ?? [ ]));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first,                                     params IEnumerable<T> ?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks?.Cast<T?>() ?? [ ]));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first,                                     params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {(T?)   first }.Concat(fallbacks ?? [ ]));
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first,                                     params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks ?? [ ]));
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       first, bool                  zeroMatters,  params IEnumerable<T> ?      fallbacks   ) where T : struct => CoalesceManyVals        (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      first, bool                  zeroMatters,  params IEnumerable<T> ?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks?.Cast<T?>() ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T       first, bool                  zeroMatters,  params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {(T?)   first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static T      Coalesce<T>(this T?      first, bool                  zeroMatters,  params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first, ZeroMatters           zeroMatters,  params IEnumerable<T> ?      fallbacks   ) where T : struct => CoalesceManyVals        (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first, ZeroMatters           zeroMatters,  params IEnumerable<T> ?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks?.Cast<T?>() ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first, ZeroMatters           zeroMatters,  params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {(T?)   first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first, ZeroMatters           zeroMatters,  params IEnumerable<T?>?      fallbacks   ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first, IEnumerable<T> ?      fallbacks,    bool                         zeroMatters ) where T : struct => CoalesceManyVals        (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first, IEnumerable<T> ?      fallbacks,    bool                         zeroMatters ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks?.Cast<T?>() ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first, IEnumerable<T?>?      fallbacks,    bool                         zeroMatters ) where T : struct => CoalesceManyNullyVals   (new [] {(T?)   first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first, IEnumerable<T?>?      fallbacks,    bool                         zeroMatters ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first, IEnumerable<T> ?      fallbacks,    ZeroMatters                  zeroMatters ) where T : struct => CoalesceManyVals        (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first, IEnumerable<T> ?      fallbacks,    ZeroMatters                  zeroMatters ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks?.Cast<T?>() ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T       first, IEnumerable<T?>?      fallbacks,    ZeroMatters                  zeroMatters ) where T : struct => CoalesceManyNullyVals   (new [] {(T?)   first }.Concat(fallbacks ?? [ ]), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static T      Coalesce<T>(this T?      first, IEnumerable<T?>?      fallbacks,    ZeroMatters                  zeroMatters ) where T : struct => CoalesceManyNullyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
}
