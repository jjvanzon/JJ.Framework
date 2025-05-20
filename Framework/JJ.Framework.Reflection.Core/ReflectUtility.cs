namespace JJ.Framework.Reflection.Core;

internal static class ReflectUtility
{
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo PropOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        return PropOrThrow(Type(shortTypeName, cache), name, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo PropOrThrow(Type type, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock)
    {
        PropertyInfo? prop = PropOrNull(type, name, bindingFlags, dic, dicLock);
        
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        
        return prop;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrNull(string shortTypeName, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrNull(type, name, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrNull(Type type, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock)
    {
        lock (dicLock)
        {
            if (dic.TryGetValue((type, name), out PropertyInfo? prop))
            {
                return prop;
            }
            
            ThrowIfNull(type);
            ThrowIfNullOrWhiteSpace(name);
            
            string nameTrimmed = name.Trim();
            
            foreach (Type t in type.GetTypesInHierarchy())
            {
                if (t.GetProperty(nameTrimmed, bindingFlags) is PropertyInfo p)
                {
                    prop ??= p;
                    dic[(t, name)] = p;
                }
            }
            
            return prop;
        }
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, PropDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrSomething(type, name, nullable, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrSomething(Type type, string name, bool nullable, BindingFlags bindingFlags, PropDic dic, Lock dicLock) 
        => nullable ? PropOrNull(type, name, bindingFlags, dic, dicLock) : PropOrThrow(type, name, bindingFlags, dic, dicLock);

    // Type

    private static Type  Type (string shortTypeName                                        , ReflectionCacheLegacy cache) => cache.GetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, [UsedImplicitly] NullableFlag nullable, ReflectionCacheLegacy cache) => cache.TryGetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, bool                          nullable, ReflectionCacheLegacy cache) => nullable ? cache.TryGetTypeByShortName(shortTypeName) : cache.GetTypeByShortName(shortTypeName);
}
