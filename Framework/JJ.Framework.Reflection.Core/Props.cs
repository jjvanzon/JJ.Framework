// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
    // Prop

    private static readonly PropDic _propDic = new();
    private static readonly Lock _propDicLock = new();
    
    public static PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name,           BindingFlagsAll, _propDic, _propDicLock, _cache);
    public static PropertyInfo  Prop<T>(T obj,             [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name,           BindingFlagsAll, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable, BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable, BindingFlagsAll, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name,           BindingFlagsAll, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable, BindingFlagsAll, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable, BindingFlagsAll, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _propDic, _propDicLock        );
}

public partial class Reflector
{    
    private readonly PropDic _propDic = new();
    private readonly Lock _propDicLock = new();

    public PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo  Prop<T>(T obj,             [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(T obj,                      string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(T obj,                      string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(T obj,                      NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(T obj,                      bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
}

public static partial class ReflectExtensions
{
    public static PropertyInfo  Prop(this Type type,                        [Caller] string name = "") => Reflect.Prop(type, name);
    public static PropertyInfo? Prop(this Type type, NullableFlag nullable, [Caller] string name = "") => Reflect.Prop(type, nullable, name);
    public static PropertyInfo? Prop(this Type type, bool         nullable, [Caller] string name = "") => Reflect.Prop(type, nullable, name);
    public static PropertyInfo? Prop(this Type type, string       name,     NullableFlag    nullable ) => Reflect.Prop(type, name, nullable);
    public static PropertyInfo? Prop(this Type type, string       name,     bool            nullable ) => Reflect.Prop(type, name, nullable);
    public static PropertyInfo  Prop<T>(this T obj,                         [Caller] string name = "") => Reflect.Prop(obj,  name);
    public static PropertyInfo? Prop<T>(this T obj,  NullableFlag nullable, [Caller] string name = "") => Reflect.Prop(obj,  nullable, name);
    public static PropertyInfo? Prop<T>(this T obj,  bool         nullable, [Caller] string name = "") => Reflect.Prop(obj,  nullable, name);
    public static PropertyInfo? Prop<T>(this T obj,  string       name,     NullableFlag    nullable ) => Reflect.Prop(obj,  name, nullable);
    public static PropertyInfo? Prop<T>(this T obj,  string       name,     bool            nullable ) => Reflect.Prop(obj,  name, nullable);
}

// ReSharper restore UnusedParameter.Global
// ReSharper restore UnusedParameter.Local

internal static partial class ReflectUtility
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
            
            foreach (Type typeOrBase in TypesAndBases(type))
            {
                if (typeOrBase.GetProperty(nameTrimmed, bindingFlags) is PropertyInfo propResolved)
                {
                    prop ??= propResolved;
                    dic[(typeOrBase, name)] = propResolved;
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
}
