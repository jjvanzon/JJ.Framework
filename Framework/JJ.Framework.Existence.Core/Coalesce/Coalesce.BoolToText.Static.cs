namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{ 
           // 2 Args

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val,  string? fallback                         ) => CoalesceNullyValToText(val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val,  string? fallback                         ) => CoalesceValToText     (val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val,  string? fallback, bool        zeroMatters) => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val,  string? fallback, bool        zeroMatters) => CoalesceValToText     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val,  string? fallback, ZeroMatters zeroMatters) => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val,  string? fallback, ZeroMatters zeroMatters) => CoalesceValToText     (val, fallback, zeroMatters);
         // Clash with 3-Arg                                                                                                
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (     bool         zeroMatters, bool?   val,  string? fallback)                  => CoalesceNullyValToText(val, fallback, zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (     bool         zeroMatters, bool    val,  string? fallback)                  => CoalesceValToText     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     ZeroMatters zeroMatters, bool? val, string? fallback ) => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     ZeroMatters zeroMatters, bool  val, string? fallback ) => CoalesceValToText     (val, fallback, zeroMatters);

           // 3 Args
           
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool? fallback, string? fallback2                         ) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool? fallback, string? fallback2                         ) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool  fallback, string? fallback2                         ) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool  fallback, string? fallback2                         ) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool? fallback, string? fallback2, bool        zeroMatters) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool? fallback, string? fallback2, bool        zeroMatters) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool  fallback, string? fallback2, bool        zeroMatters) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool  fallback, string? fallback2, bool        zeroMatters) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool? fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool? fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool  fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool  fallback, string? fallback2, ZeroMatters zeroMatters) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
         // Clash with 4-Arg                                                                                                                    
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (     bool         zeroMatters, bool?   val,  bool?   fallback, string? fallback2 )                                                   => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (     bool         zeroMatters, bool    val,  bool?   fallback, string? fallback2 )                                                   => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (     bool         zeroMatters, bool?   val,  bool    fallback, string? fallback2 )                                                   => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
         ///// <inheritdoc cref="_coalesce" />
         //public static string Coalesce   (     bool         zeroMatters, bool    val,  bool    fallback, string? fallback2 )                                                   => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     ZeroMatters zeroMatters, bool? val, bool? fallback, string? fallback2) => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     ZeroMatters zeroMatters, bool  val, bool? fallback, string? fallback2) => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     ZeroMatters zeroMatters, bool? val, bool  fallback, string? fallback2) => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     ZeroMatters zeroMatters, bool  val, bool  fallback, string? fallback2) => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);

           // 4-Arg (only for bools)
 
           // * These help bools map to values, instead of unnamed flags.
           // * For instance (bool,bool,bool,bool) shadows (T,T,T,bool) whereas (params bool[]) alone can't.
           // * String variants like (bool,bool,bool,string) shadow (bool,T,T,string) overloads.

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool  fallback1, bool  fallback2, string? fallback3) => CoalesceValToText     ( val, CoalesceValToText     (fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool  fallback1, bool? fallback2, string? fallback3) => CoalesceValToText     ( val, CoalesceValToText     (fallback1, CoalesceNullyValToText(fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool? fallback1, bool  fallback2, string? fallback3) => CoalesceValToText     ( val, CoalesceNullyValToText(fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool  val, bool? fallback1, bool? fallback2, string? fallback3) => CoalesceValToText     ( val, CoalesceNullyValToText(fallback1, CoalesceNullyValToText(fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool  fallback1, bool  fallback2, string? fallback3) => CoalesceNullyValToText( val, CoalesceValToText     (fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool  fallback1, bool? fallback2, string? fallback3) => CoalesceNullyValToText( val, CoalesceValToText     (fallback1, CoalesceNullyValToText(fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool? fallback1, bool  fallback2, string? fallback3) => CoalesceNullyValToText( val, CoalesceNullyValToText(fallback1, CoalesceValToText     (fallback2, fallback3)));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce   (     bool? val, bool? fallback1, bool? fallback2, string? fallback3) => CoalesceNullyValToText( val, CoalesceNullyValToText(fallback1, CoalesceNullyValToText(fallback2, fallback3)));
}