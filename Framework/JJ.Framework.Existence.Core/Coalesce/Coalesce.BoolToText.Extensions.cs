namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_coalesce"/>
public static class CoalesceBoolToTextExtensions
{
           // 2 Args

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, string? fallback                         ) => CoalesceValToText     (val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, string? fallback                         ) => CoalesceNullyValToText(val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, string? fallback, bool        zeroMatters) => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, string? fallback, bool        zeroMatters) => CoalesceNullyValToText(val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, string? fallback, ZeroMatters zeroMatters) => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, string? fallback, ZeroMatters zeroMatters) => CoalesceNullyValToText(val,  fallback, zeroMatters);
         // Clashes 3-Arg                                                                                                    
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (this bool    val,  bool         zeroMatters, string? fallback )                  => CoalesceValToText     (val,  fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (this bool?   val,  bool         zeroMatters, string? fallback )                  => CoalesceNullyValToText(val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, ZeroMatters zeroMatters, string? fallback) => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, ZeroMatters zeroMatters, string? fallback) => CoalesceNullyValToText(val,  fallback, zeroMatters);
 
           // 3 Args

           /// <inheritdoc cref="_coalesce" /> 
           public static string Coalesce   (this bool  val, bool  fallback, string? fallback2                         ) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool? fallback, string? fallback2                         ) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool  fallback, string? fallback2                         ) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool? fallback, string? fallback2                         ) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool  fallback, string? fallback2, bool        zeroMatters) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool? fallback, string? fallback2, bool        zeroMatters) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool  fallback, string? fallback2, bool        zeroMatters) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool? fallback, string? fallback2, bool        zeroMatters) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool  fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool? fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool  fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool? fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
         // Clash with 4-arg: Use named flag instead
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (this bool    val,  bool         zeroMatters, bool    fallback, string? fallback2,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (this bool    val,  bool         zeroMatters, bool?   fallback, string? fallback2,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (this bool?   val,  bool         zeroMatters, bool    fallback, string? fallback2,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (this bool?   val,  bool         zeroMatters, bool?   fallback, string? fallback2,[Implic(Reason=NameOvl)]int dum=0)                  => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, ZeroMatters zeroMatters, bool  fallback, string? fallback2) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, ZeroMatters zeroMatters, bool? fallback, string? fallback2) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, ZeroMatters zeroMatters, bool  fallback, string? fallback2) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, ZeroMatters zeroMatters, bool? fallback, string? fallback2) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           
           // 4 Args (only for bools)
 
           // * These help bools map to values, instead of unnamed flags.
           // * For instance (bool,bool,bool,bool) shadows (T,T,T,bool) whereas (params bool[]) alone can't.
           // * String variants like (bool,bool,bool,string) shadow (bool,T,T,string) overloads.

           /// <inheritdoc cref="_coalesce" /> 
           public static string Coalesce   (this bool  val, bool  fallback1, bool  fallback2, string? fallback3) => CoalesceValToText     (val, CoalesceValToText     (fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool  fallback1, bool? fallback2, string? fallback3) => CoalesceValToText     (val, CoalesceValToText     (fallback1, CoalesceNullyValToText(fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool? fallback1, bool  fallback2, string? fallback3) => CoalesceValToText     (val, CoalesceNullyValToText(fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool  val, bool? fallback1, bool? fallback2, string? fallback3) => CoalesceValToText     (val, CoalesceNullyValToText(fallback1, CoalesceNullyValToText(fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool  fallback1, bool  fallback2, string? fallback3) => CoalesceNullyValToText(val, CoalesceValToText     (fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool  fallback1, bool? fallback2, string? fallback3) => CoalesceNullyValToText(val, CoalesceValToText     (fallback1, CoalesceNullyValToText(fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool? fallback1, bool  fallback2, string? fallback3) => CoalesceNullyValToText(val, CoalesceNullyValToText(fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (this bool? val, bool? fallback1, bool? fallback2, string? fallback3) => CoalesceNullyValToText(val, CoalesceNullyValToText(fallback1, CoalesceNullyValToText(fallback2, fallback3)));
}