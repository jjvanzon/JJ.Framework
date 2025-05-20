using PropDic = System.Collections.Generic.Dictionary<(System.Type, string), System.Reflection.PropertyInfo?>;

namespace JJ.Framework.Reflection.Core;

public static class Reflect
{
    private const BindingFlags BindingFlags = BindingFlagsAll;
    
    private static readonly ReflectionCacheLegacy _cache = new(BindingFlags);
    
    // Prop

    private static readonly PropDic _propDic = new();
    private static readonly Lock _propDicLock = new();

    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedParameter.Local
    
    public static PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    
    // ReSharper restore UnusedParameter.Global
    // ReSharper restore UnusedParameter.Local

    [MethodImpl(AggressiveInlining)]
    internal static PropertyInfo PropOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock, ReflectionCacheLegacy cache) 
        => PropOrThrow(Type(shortTypeName, cache), name, bindingFlags, dic, dicLock);
    
    [MethodImpl(AggressiveInlining)]
    internal static PropertyInfo PropOrThrow(Type type, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock)
    {
        PropertyInfo? prop = PropOrNull(type, name, bindingFlags, dic, dicLock);
        
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        
        return prop;
    }
    
    [MethodImpl(AggressiveInlining)]
    internal static PropertyInfo? PropOrNull(string shortTypeName, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrNull(type, name, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    internal static PropertyInfo? PropOrNull(Type type, string name, BindingFlags bindingFlags, PropDic dic, Lock dicLock)
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
    internal static PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, PropDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrSomething(type, name, nullable, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    internal static PropertyInfo? PropOrSomething(Type type, string name, bool nullable, BindingFlags bindingFlags, PropDic dic, Lock dicLock) 
        => nullable ? PropOrNull(type, name, bindingFlags, dic, dicLock) : PropOrThrow(type, name, bindingFlags, dic, dicLock);

    // Type

    private static Type  Type (string shortTypeName                                        , ReflectionCacheLegacy cache) => cache.GetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, [UsedImplicitly] NullableFlag nullable, ReflectionCacheLegacy cache) => cache.TryGetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, bool                          nullable, ReflectionCacheLegacy cache) => nullable ? cache.TryGetTypeByShortName(shortTypeName) : cache.GetTypeByShortName(shortTypeName);
}
