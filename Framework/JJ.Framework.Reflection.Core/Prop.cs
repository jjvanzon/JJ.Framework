namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static PropertyInfo PropOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, PropDict dict, Lock lck, ReflectionCacheLegacy cache)
    {
        return PropOrThrow(Type(shortTypeName, cache), name, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(Bases)]
    public static PropertyInfo PropOrThrow([Dyn(Intf)] Type type, string name, BindingFlags bindingFlags, PropDict dict, Lock lck)
    {
        ThrowIfNull(type);
        PropertyInfo? prop = PropOrNull(type, name, bindingFlags, dict, lck);
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        return prop;
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static PropertyInfo? PropOrNull(string shortTypeName, string name, BindingFlags bindingFlags, PropDict dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrNull(type, name, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(Bases)]
    public static PropertyInfo? PropOrNull([Dyn(Intf)] Type type, string name, BindingFlags bindingFlags, PropDict dict, Lock lck)
    {
        PropertyInfo? prop;

        lock (lck)
        {
            if (dict.TryGetValue((type, name), out prop))
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
            dict[(type, name)] = prop;
        }
        
        return prop;
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, PropDict dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return PropOrSomething(type, name, nullable, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(Bases)]
    public static PropertyInfo? PropOrSomething([Dyn(Intf)] Type type, string name, bool nullable, BindingFlags bindingFlags, PropDict dict, Lock lck) 
        => nullable ? 
           PropOrNull (type, name, bindingFlags, dict, lck) :
           PropOrThrow(type, name, bindingFlags, dict, lck);
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public partial class Reflector
{    
    private readonly PropDict _propDict = new();
    private readonly Lock     _propLock = new();

    [NoTrim(Bases   )] public        PropertyInfo  Prop<[Dyn(Intf)] T>(                  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo  Prop([Dyn(Intf)]         Type   type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(GetTypes)] public        PropertyInfo  Prop(                    string type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlags,    _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public        PropertyInfo  Prop<[Dyn(Intf)] T>(     T      obj,  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(                           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop([Dyn(Intf)]         Type   type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(GetTypes)] public        PropertyInfo? Prop(                    string type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlags,    _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(                           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop([Dyn(Intf)]         Type   type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlags,    _propDict, _propLock        );
    [NoTrim(GetTypes)] public        PropertyInfo? Prop(                    string type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlags,    _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(                           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop([Dyn(Intf)]         Type   type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(GetTypes)] public        PropertyInfo? Prop(                    string type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlags,    _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(                           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDict, _propLock        );
    [NoTrim(Bases   )] public        PropertyInfo? Prop([Dyn(Intf)]         Type   type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlags,    _propDict, _propLock        );
    [NoTrim(GetTypes)] public        PropertyInfo? Prop(                    string type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlags,    _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public        PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlags,    _propDict, _propLock        );
}

public static partial class Reflect
{
    internal static readonly PropDict _propDict  = new();
    internal static readonly Lock     _propLock = new();
    
    [NoTrim(Bases   )] public static PropertyInfo  Prop<[Dyn(Intf)] T>(                  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo  Prop([Dyn(Intf)]         Type   type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo  Prop(                    string type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo  Prop<[Dyn(Intf)] T>(     T      obj,  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(                           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]         Type   type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(                    string type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(                           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]         Type   type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(                    string type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(                           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]         Type   type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(                    string type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(                           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]         Type   type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(                    string type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(     T      obj,           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDict, _propLock        );
}

public static partial class ReflectExtensions
{
    [NoTrim(Bases   )] public static PropertyInfo  Prop([Dyn(Intf)]    this Type   type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo  Prop(               this string type, [Caller] string    name = ""                          ) => PropOrThrow    (type,      name,           BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo  Prop<[Dyn(Intf)] T>(this T      obj,  [Caller] string    name = ""                          ) => PropOrThrow    (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]    this Type   type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(               this string type,          string    name,     NullFlag? nullable       ) => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(this T      obj,           string    name,     NullFlag? nullable       ) => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]    this Type   type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(               this string type,          string    name,     bool      nullable       ) => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(this T      obj,           string    name,     bool      nullable       ) => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]    this Type   type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(               this string type,          NullFlag? nullable, [Caller] string name = "") => PropOrNull     (type,      name,           BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(this T      obj,           NullFlag? nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name,           BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(Bases   )] public static PropertyInfo? Prop([Dyn(Intf)]    this Type   type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock        );
    [NoTrim(GetTypes)] public static PropertyInfo? Prop(               this string type,          bool      nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable, BindingFlagsAll, _propDict, _propLock, _cache);
    [NoTrim(Bases   )] public static PropertyInfo? Prop<[Dyn(Intf)] T>(this T      obj,           bool      nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable, BindingFlagsAll, _propDict, _propLock        );
}
