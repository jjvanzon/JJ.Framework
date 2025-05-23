namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    private static ICollection<Type> TypesAndBases(Type type, BindingFlags bindingFlags)
    {
        if (!AllowsHierarchy(bindingFlags)) return [ type ];
        
        var typesInHierarchy = type.GetTypesInHierarchy();
        var underlyingTypes = typesInHierarchy.Select(GetUnderlyingType)
                                              .Where(x => x != null)
                                              .Select(x => x!);
        
        Type[] typeAndBases = Union(typesInHierarchy, underlyingTypes).ToArray();
        return typeAndBases;
    }
    
    private static Type  Type (string shortTypeName                                     , ReflectionCacheLegacy cache) => cache.GetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, [UsedImplicitly] NullFlag? nullable, ReflectionCacheLegacy cache) => cache.TryGetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, bool                       nullable, ReflectionCacheLegacy cache) => nullable ? cache.TryGetTypeByShortName(shortTypeName) : cache.GetTypeByShortName(shortTypeName);
    
    [MethodImpl(AggressiveInlining)]
    private static bool AllowsHierarchy(BindingFlags bindingFlags)
        => !bindingFlags.HasFlag(DeclaredOnly);
}
