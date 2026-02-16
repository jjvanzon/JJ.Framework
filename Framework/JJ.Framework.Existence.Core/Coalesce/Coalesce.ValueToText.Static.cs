namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{
           // 2 Args

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  string? fallback                          ) where T : struct => CoalesceNullyValToText(val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  string? fallback                          ) where T : struct => CoalesceValToText     (val, fallback             );
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  string? fallback, bool         zeroMatters) where T : struct => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  string? fallback, bool         zeroMatters) where T : struct => CoalesceValToText     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  string? fallback, ZeroMatters  zeroMatters) where T : struct => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  string? fallback, ZeroMatters  zeroMatters) where T : struct => CoalesceValToText     (val, fallback, zeroMatters);

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     bool         zeroMatters, T?      val,  string? fallback) where T : struct => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     bool         zeroMatters, T       val,  string? fallback) where T : struct => CoalesceValToText     (val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  string? fallback) where T : struct => CoalesceNullyValToText(val, fallback, zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  string? fallback) where T : struct => CoalesceValToText     (val, fallback, zeroMatters);

           // 3 Args

           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2                           ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  T?      fallback, string? fallback2                           ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  T       fallback, string? fallback2                           ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  T       fallback, string? fallback2                           ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2));
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  T?      fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  T       fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  T       fallback, string? fallback2, bool         zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  T?      fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  T?      fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T?      val,  T       fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     T       val,  T       fallback, string? fallback2, ZeroMatters  zeroMatters ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);

           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static string Coalesce<T>(     bool         zeroMatters, T?      val,  T?      fallback, string? fallback2, NameOvl ovl = default) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static string Coalesce<T>(     bool         zeroMatters, T       val,  T?      fallback, string? fallback2, NameOvl ovl = default) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static string Coalesce<T>(     bool         zeroMatters, T?      val,  T       fallback, string? fallback2, NameOvl ovl = default) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
[Prio(-1)] public static string Coalesce<T>(     bool         zeroMatters, T       val,  T       fallback, string? fallback2, NameOvl ovl = default) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  T?      fallback, string? fallback2 ) where T : struct => CoalesceNullyValToText(val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  T?      fallback, string? fallback2 ) where T : struct => CoalesceValToText     (val,  CoalesceNullyValToText(fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     ZeroMatters  zeroMatters, T?      val,  T       fallback, string? fallback2 ) where T : struct => CoalesceNullyValToText(val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
           /// <inheritdoc cref="_coalesce" />
           public static string Coalesce<T>(     ZeroMatters  zeroMatters, T       val,  T       fallback, string? fallback2 ) where T : struct => CoalesceValToText     (val,  CoalesceValToText     (fallback, fallback2, zeroMatters), zeroMatters);
}
