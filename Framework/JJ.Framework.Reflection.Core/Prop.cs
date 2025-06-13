namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo PropOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, PropDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        return PropOrThrow(Type(shortTypeName, cache), name, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo PropOrThrow(Type type, string name, BindingFlags bindingFlags, PropDic dic, Lock lck)
    {
        ThrowIfNull(type);
        PropertyInfo? prop = PropOrNull(type, name, bindingFlags, dic, lck);
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        return prop;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrNull(string shortTypeName, string name, BindingFlags bindingFlags, PropDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrNull(type, name, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrNull(Type type, string name, BindingFlags bindingFlags, PropDic dic, Lock lck)
    {
        PropertyInfo? prop;

        lock (lck)
        {
            if (dic.TryGetValue((type, name), out prop))
            {
                return prop;
            }
        }
            
        ThrowIfNullOrWhiteSpace(name);
        
        string trim = name.Trim();
        
        prop = (from t in TypesAndBases(type, bindingFlags)
                let p = t.GetProperty(trim, bindingFlags)
                where p != null
                select p).FirstOrDefault();
        
        lock (lck)
        {
            dic[(type, name)] = prop;
        }
        
        return prop;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, PropDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrSomething(type, name, nullable, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static PropertyInfo? PropOrSomething(Type type, string name, bool nullable, BindingFlags bindingFlags, PropDic dic, Lock lck) 
        => nullable ? 
           PropOrNull (type, name, bindingFlags, dic, lck) :
           PropOrThrow(type, name, bindingFlags, dic, lck);
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public partial class Reflector
{    
    private readonly PropDic _propDic  = new();
    private readonly Lock    _propLock = new();

    public        PropertyInfo  Prop<T>(                  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo  Prop   (     Type   type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo  Prop   (     string type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlags,    _propDic, _propLock, _cache);
    public        PropertyInfo  Prop<T>(     T      obj,  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop<T>(                           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     Type   type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     string type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlags,    _propDic, _propLock, _cache);
    public        PropertyInfo? Prop<T>(     T      obj,           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop<T>(                           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     Type   type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     string type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlags,    _propDic, _propLock, _cache);
    public        PropertyInfo? Prop<T>(     T      obj,           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop<T>(                           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     Type   type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     string type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlags,    _propDic, _propLock, _cache);
    public        PropertyInfo? Prop<T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop<T>(                           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     Type   type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlags,    _propDic, _propLock        );
    public        PropertyInfo? Prop   (     string type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlags,    _propDic, _propLock, _cache);
    public        PropertyInfo? Prop<T>(     T      obj,           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDic, _propLock        );
}

public static partial class Reflect
{
    internal static readonly PropDic _propDic  = new();
    internal static readonly Lock    _propLock = new();
    
    public static PropertyInfo  Prop<T>(                  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo  Prop   (     Type   type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo  Prop   (     string type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo  Prop<T>(     T      obj,  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop<T>(                           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     Type   type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     string type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(     T      obj,           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop<T>(                           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     Type   type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     string type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(     T      obj,           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop<T>(                           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     Type   type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     string type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop<T>(                           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     Type   type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (     string type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(     T      obj,           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDic, _propLock        );
}

public static partial class ReflectExtensions
{
    public static PropertyInfo  Prop   (this Type   type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo  Prop   (this string type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo  Prop<T>(this T      obj,  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this Type   type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this string type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(this T      obj,           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this Type   type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this string type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(this T      obj,           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this Type   type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this string type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(this T      obj,           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this Type   type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock        );
    public static PropertyInfo? Prop   (this string type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDic, _propLock, _cache);
    public static PropertyInfo? Prop<T>(this T      obj,           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDic, _propLock        );
}
