namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    private static Type  Type (string shortTypeName                                        , ReflectionCacheLegacy cache) => cache.GetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, [UsedImplicitly] NullableFlag nullable, ReflectionCacheLegacy cache) => cache.TryGetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, bool                          nullable, ReflectionCacheLegacy cache) => nullable ? cache.TryGetTypeByShortName(shortTypeName) : cache.GetTypeByShortName(shortTypeName);
}
