namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_coalesce"/>
public static class CoalesceValueToTextExtensions
{ 
           // 2 Args

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  string? fallback                           ) where T : struct => CoalesceValToText     (val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  string? fallback                           ) where T : struct => CoalesceNullyValToText(val,  fallback);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  string? fallback, bool         zeroMatters ) where T : struct => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  string? fallback, bool         zeroMatters ) where T : struct => CoalesceNullyValToText(val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  string? fallback, ZeroMatters  zeroMatters ) where T : struct => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  string? fallback, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyValToText(val,  fallback, zeroMatters);

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  bool         zeroMatters, string? fallback ) where T : struct => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  bool         zeroMatters, string? fallback ) where T : struct => CoalesceNullyValToText(val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, string? fallback ) where T : struct => CoalesceValToText     (val,  fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, string? fallback ) where T : struct => CoalesceNullyValToText(val,  fallback, zeroMatters);

           // 3 Args

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  T       fallback, string? fallback2                           ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  T?      fallback, string? fallback2                           ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  T       fallback, string? fallback2                           ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2                           ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  T       fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  T?      fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  T       fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  T       fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  T?      fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  T       fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  bool         zeroMatters, T       fallback, string? fallback2 ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  bool         zeroMatters, T?      fallback, string? fallback2 ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  bool         zeroMatters, T       fallback, string? fallback2 ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  bool         zeroMatters, T?      fallback, string? fallback2 ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T       fallback, string? fallback2 ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T       val,  ZeroMatters  zeroMatters, T?      fallback, string? fallback2 ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T       fallback, string? fallback2 ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(this T?      val,  ZeroMatters  zeroMatters, T?      fallback, string? fallback2 ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
}
