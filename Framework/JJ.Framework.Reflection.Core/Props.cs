namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [NoTrim(GetTypes)]
    public static PropertyInfo[] PropsCore(
        string shortTypeName, BindingFlags bindingFlags, PropsDict dict, Lock lck, ReflectionCacheLegacy cache)
    {        
        Type type = Type(shortTypeName, cache);
        return PropsCore(type, bindingFlags, dict, lck);
    }
    
    [NoTrim(Bases)]
    public static PropertyInfo[] PropsCore(
        [Dyn(Intf)] Type type, BindingFlags bindingFlags, PropsDict dict, Lock lck)
    {
        PropertyInfo[]? props;
        
        lock (lck)
        {
            if (dict.TryGetValue(type, out props))
            {
                return props;
            }
        }

        props = TypesAndBases(type, bindingFlags)
                .SelectMany(x => x.GetProperties(bindingFlags))
                .Distinct(x => x.Name)
                .ToArray();
        
        lock (lck)
        {
            dict[type] = props;
        }
        
        return props;
    }
    
    [NoTrim(GetTypes)]
    public static Dictionary<string, PropertyInfo> PropDictCore(
        string shortTypeName, BindingFlags bindingFlags, PropsDictDict dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return PropDictCore(type, bindingFlags, dict, lck);
    }
    
    [NoTrim(Bases)]
    public static Dictionary<string, PropertyInfo> PropDictCore(
        [Dyn(Intf)] Type type, BindingFlags bindingFlags, PropsDictDict dict, Lock lck)
    { 
        Dictionary<string, PropertyInfo>? props;
        
        lock (lck)
        {
            if (dict.TryGetValue(type, out props))
            {
                return props;
            }
        }
        
        props = TypesAndBases(type, bindingFlags)
                .SelectMany(x => x.GetProperties(bindingFlags))
                .Distinct(x => x.Name)
                .ToDictionary(x => x.Name);
        
        lock (lck)
        {
            dict[type] = props;
        }
        
        return props;
    }
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public static partial class Reflect
{
    internal static readonly PropsDict     _propsDict         = new();
    internal static readonly Lock          _propsDictLock     = new();
    internal static readonly PropsDictDict _propsDictDict     = new();
    internal static readonly Lock          _propsDictDictLock = new();
    
    [NoTrim(Bases   )] public static PropertyInfo[]                   Props  <[Dyn(Intf)] T>(                         ) => PropsCore   (typeof(T),     BindingFlagsAll, _propsDict,     _propsDictLock            );
    [NoTrim(Bases   )] public static PropertyInfo[]                   Props  ([Dyn(Intf)]         Type type           ) => PropsCore   (type,          BindingFlagsAll, _propsDict,     _propsDictLock            );
    [NoTrim(GetTypes)] public static PropertyInfo[]                   Props  (                    string shortTypeName) => PropsCore   (shortTypeName, BindingFlagsAll, _propsDict,     _propsDictLock,     _cache);
    [NoTrim(Bases   )] public static PropertyInfo[]                   Props  <[Dyn(Intf)] T>(     T obj               ) => PropsCore   (typeof(T),     BindingFlagsAll, _propsDict,     _propsDictLock            );
    [NoTrim(Bases   )] public static Dictionary<string, PropertyInfo> PropDic<[Dyn(Intf)] T>(                         ) => PropDictCore(typeof(T),     BindingFlagsAll, _propsDictDict, _propsDictDictLock        );
    [NoTrim(Bases   )] public static Dictionary<string, PropertyInfo> PropDic([Dyn(Intf)]         Type type           ) => PropDictCore(type,          BindingFlagsAll, _propsDictDict, _propsDictDictLock        );
    [NoTrim(GetTypes)] public static Dictionary<string, PropertyInfo> PropDic(                    string shortTypeName) => PropDictCore(shortTypeName, BindingFlagsAll, _propsDictDict, _propsDictDictLock, _cache);
    [NoTrim(Bases   )] public static Dictionary<string, PropertyInfo> PropDic<[Dyn(Intf)] T>(     T obj               ) => PropDictCore(typeof(T),     BindingFlagsAll, _propsDictDict, _propsDictDictLock        );
}
public partial class Reflector
{
    private         readonly PropsDict     _propsDict         = new();
    private         readonly Lock          _propsDictLock     = new();
    private         readonly PropsDictDict _propsDictDict     = new();
    private         readonly Lock          _propsDictDictLock = new();
              
    [NoTrim(Bases   )] public        PropertyInfo[]                   Props  <[Dyn(Intf)] T>(                         ) => PropsCore   (typeof(T),     BindingFlags,    _propsDict,     _propsDictLock            );
    [NoTrim(Bases   )] public        PropertyInfo[]                   Props  ([Dyn(Intf)]         Type type           ) => PropsCore   (type,          BindingFlags,    _propsDict,     _propsDictLock            );
    [NoTrim(GetTypes)] public        PropertyInfo[]                   Props  (                    string shortTypeName) => PropsCore   (shortTypeName, BindingFlags,    _propsDict,     _propsDictLock,     _cache);
    [NoTrim(Bases   )] public        PropertyInfo[]                   Props  <[Dyn(Intf)] T>(     T obj               ) => PropsCore   (typeof(T),     BindingFlags,    _propsDict,     _propsDictLock            );
    [NoTrim(Bases   )] public        Dictionary<string, PropertyInfo> PropDic<[Dyn(Intf)] T>(                         ) => PropDictCore(typeof(T),     BindingFlags,    _propsDictDict, _propsDictDictLock        );
    [NoTrim(Bases   )] public        Dictionary<string, PropertyInfo> PropDic([Dyn(Intf)]         Type type           ) => PropDictCore(type,          BindingFlags,    _propsDictDict, _propsDictDictLock        );
    [NoTrim(GetTypes)] public        Dictionary<string, PropertyInfo> PropDic(                    string shortTypeName) => PropDictCore(shortTypeName, BindingFlags,    _propsDictDict, _propsDictDictLock, _cache);
    [NoTrim(Bases   )] public        Dictionary<string, PropertyInfo> PropDic<[Dyn(Intf)] T>(     T obj               ) => PropDictCore(typeof(T),     BindingFlags,    _propsDictDict, _propsDictDictLock        );
}

public static partial class ReflectExtensions
{
    [NoTrim(Bases   )] public static PropertyInfo[]                   Props  ([Dyn(Intf)]    this Type type           ) => PropsCore   (type,          BindingFlagsAll, _propsDict,     _propsDictLock            );
    [NoTrim(GetTypes)] public static PropertyInfo[]                   Props  (               this string shortTypeName) => PropsCore   (shortTypeName, BindingFlagsAll, _propsDict,     _propsDictLock,     _cache);
    [NoTrim(Bases   )] public static PropertyInfo[]                   Props  <[Dyn(Intf)] T>(this T obj               ) => PropsCore   (typeof(T),     BindingFlagsAll, _propsDict,     _propsDictLock            );
    [NoTrim(Bases   )] public static Dictionary<string, PropertyInfo> PropDic([Dyn(Intf)]    this Type type           ) => PropDictCore(type,          BindingFlagsAll, _propsDictDict, _propsDictDictLock        );
    [NoTrim(GetTypes)] public static Dictionary<string, PropertyInfo> PropDic(               this string shortTypeName) => PropDictCore(shortTypeName, BindingFlagsAll, _propsDictDict, _propsDictDictLock, _cache);
    [NoTrim(Bases   )] public static Dictionary<string, PropertyInfo> PropDic<[Dyn(Intf)] T>(this T obj               ) => PropDictCore(typeof(T),     BindingFlagsAll, _propsDictDict, _propsDictDictLock        );
}

