namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_coalesce"/>
public static partial class CoalesceExtensions
{
          // [Prio] attributes:
          // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
          // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
          // Prio(2) on string.Coalesce() makes it win over IEnumerable<char> in string-specific calls.
          
          // 1 Arg

          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val )                  => CoalesceBool     (val);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val )                  => CoalesceBoolNully(val);

          // 2 Args

          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  string? fallback                           ) => CoalesceValToText     (val,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  string? fallback                           ) => CoalesceNullyValToText(val,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback                           ) => CoalesceTwoNullyVals  (val,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback                           ) => CoalesceNullyAndVal   (val,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback                           ) => CoalesceValAndNully   (val,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback                           ) => CoalesceTwoVals       (val,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  string? fallback, bool         zeroMatters ) => CoalesceValToText     (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  string? fallback, bool         zeroMatters ) => CoalesceNullyValToText(val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceValAndNully   (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0) => CoalesceTwoVals       (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  string? fallback, ZeroMatters  zeroMatters ) => CoalesceValToText     (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  string? fallback, ZeroMatters  zeroMatters ) => CoalesceNullyValToText(val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, ZeroMatters  zeroMatters ) => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, ZeroMatters  zeroMatters ) => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, ZeroMatters  zeroMatters ) => CoalesceValAndNully   (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, ZeroMatters  zeroMatters ) => CoalesceTwoVals       (val,  fallback, zeroMatters);
        // Clashes 3-Arg
        ///// <inheritdoc cref="_coalesce" />
        //public static string Coalesce   (this bool    val,  bool         zeroMatters, string? fallback ) => CoalesceValToText     (val,  fallback, zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static string Coalesce   (this bool?   val,  bool         zeroMatters, string? fallback ) => CoalesceNullyValToText(val,  fallback, zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool?   val,  bool         zeroMatters, bool?   fallback ) => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool?   val,  bool         zeroMatters, bool    fallback ) => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool    val,  bool         zeroMatters, bool?   fallback ) => CoalesceValAndNully   (val,  fallback, zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool    val,  bool         zeroMatters, bool    fallback ) => CoalesceTwoVals       (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  ZeroMatters  zeroMatters, string? fallback ) => CoalesceValToText     (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, string? fallback ) => CoalesceNullyValToText(val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool?   fallback ) => CoalesceTwoNullyVals  (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool    fallback ) => CoalesceNullyAndVal   (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool?   fallback ) => CoalesceValAndNully   (val,  fallback, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool    fallback ) => CoalesceTwoVals       (val,  fallback, zeroMatters);

          // 3 Args

          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool    fallback, string? fallback2                           )                  => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool?   fallback, string? fallback2                           )                  => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool    fallback, string? fallback2                           )                  => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool?   fallback, string? fallback2                           )                  => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool?   fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool    fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool?   fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool    fallback2                           )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool?   fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool    fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool?   fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool    fallback2                           )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool    fallback, string? fallback2, bool         zeroMatters )                  => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool?   fallback, string? fallback2, bool         zeroMatters )                  => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool    fallback, string? fallback2, bool         zeroMatters )                  => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool?   fallback, string? fallback2, bool         zeroMatters )                  => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool?   fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool    fallback2, bool         zeroMatters,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool    fallback, string? fallback2, ZeroMatters  zeroMatters )                  => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool?   fallback, string? fallback2, ZeroMatters  zeroMatters )                  => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool    fallback, string? fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool?   fallback, string? fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool?   fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  bool    fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool?   fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool?   fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  bool    fallback, bool    fallback2, ZeroMatters  zeroMatters )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool         zeroMatters, bool    fallback, string? fallback2 )                  => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  bool         zeroMatters, bool?   fallback, string? fallback2 )                  => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool         zeroMatters, bool    fallback, string? fallback2 )                  => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  bool         zeroMatters, bool?   fallback, string? fallback2 )                  => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
        // Clash with 4-Arg
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool?   val,  bool         zeroMatters, bool?   fallback, bool?   fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool?   val,  bool         zeroMatters, bool?   fallback, bool    fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool?   val,  bool         zeroMatters, bool    fallback, bool?   fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool?   val,  bool         zeroMatters, bool    fallback, bool    fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool    val,  bool         zeroMatters, bool?   fallback, bool?   fallback2 )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool    val,  bool         zeroMatters, bool?   fallback, bool    fallback2 )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool    val,  bool         zeroMatters, bool    fallback, bool?   fallback2 )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
        ///// <inheritdoc cref="_coalesce" />
        //public static bool   Coalesce   (this bool    val,  bool         zeroMatters, bool    fallback, bool    fallback2 )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool    fallback, string? fallback2 )                  => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool?   fallback, string? fallback2 )                  => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool    fallback, string? fallback2 )                  => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool?   fallback, string? fallback2 )                  => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool?   fallback, bool?   fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool?   fallback, bool    fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool    fallback, bool?   fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   val,  ZeroMatters  zeroMatters, bool    fallback, bool    fallback2 )                  => CoalesceNullyAndVal   (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool?   fallback, bool?   fallback2 )                  => CoalesceTwoVals       (val,  CoalesceTwoNullyVals  (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool?   fallback, bool    fallback2 )                  => CoalesceTwoVals       (val,  CoalesceNullyAndVal   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool    fallback, bool?   fallback2 )                  => CoalesceTwoVals       (val,  CoalesceValAndNully   (fallback, fallback2, zeroMatters), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    val,  ZeroMatters  zeroMatters, bool    fallback, bool    fallback2 )                  => CoalesceTwoVals       (val,  CoalesceTwoVals       (fallback, fallback2, zeroMatters), zeroMatters);
          
          // 4 Args (only for bools)

          // These help bools mapp to values, instead of unnamed flags.

          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool  fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool  fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool  fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool  fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool? fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool? fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool? fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool  val, bool? fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool  fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool  fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool  fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool  fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool? fallback1, bool  fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool? fallback1, bool  fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool? fallback1, bool? fallback2, bool  fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool? val, bool? fallback1, bool? fallback2, bool? fallback3) => CoalesceManyBools([val, fallback1, fallback2, fallback3]);

          // N Args

          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static bool   Coalesce   (this IEnumerable<bool?>?   fallbacks                           ) => CoalesceManyVals   (fallbacks);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static bool   Coalesce   (this IEnumerable<bool?>?   fallbacks, bool         zeroMatters ) => CoalesceManyVals   (fallbacks, zeroMatters);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static bool   Coalesce   (this IEnumerable<bool?>?   fallbacks, ZeroMatters  zeroMatters ) => CoalesceManyVals   (fallbacks, zeroMatters);

          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   first,                                     params IEnumerable<bool?>?   fallbacks   )                  => CoalesceManyVals   (new [] {       first }.Concat(fallbacks ?? [ ]));
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   first, bool                  zeroMatters,  params IEnumerable<bool?>?   fallbacks   )                  => CoalesceManyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   first, ZeroMatters           zeroMatters,  params IEnumerable<bool?>?   fallbacks   )                  => CoalesceManyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   first, IEnumerable<bool?>?   fallbacks,    bool                         zeroMatters )                  => CoalesceManyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool?   first, IEnumerable<bool?>?   fallbacks,    ZeroMatters                  zeroMatters )                  => CoalesceManyVals   (new [] {       first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    first,                                     params IEnumerable<bool?>?   fallbacks   )                  => CoalesceManyVals   (new [] {(bool?)first }.Concat(fallbacks ?? [ ]));

          // Prio(-1) is used to prefer mapping booleans as values,
          // not as flags, except when the flag is explicitly named.

          /// <inheritdoc cref="_coalesce" />
          [Prio(-1)]
          public static bool   Coalesce   (this bool    first, bool                  zeroMatters,  params IEnumerable<bool?>?   fallbacks   )                  => CoalesceManyVals   (new [] {(bool?)first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    first, ZeroMatters           zeroMatters,  params IEnumerable<bool?>?   fallbacks   )                  => CoalesceManyVals   (new [] {(bool?)first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    first, IEnumerable<bool?>?   fallbacks,    bool                         zeroMatters )                  => CoalesceManyVals   (new [] {(bool?)first }.Concat(fallbacks ?? [ ]), zeroMatters);
          /// <inheritdoc cref="_coalesce" />
          public static bool   Coalesce   (this bool    first, IEnumerable<bool?>?   fallbacks,    ZeroMatters                  zeroMatters )                  => CoalesceManyVals   (new [] {(bool?)first }.Concat(fallbacks ?? [ ]), zeroMatters);
}