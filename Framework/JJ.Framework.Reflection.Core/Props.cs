namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [NoTrim(GetTypes)]
    public static PropertyInfo[] PropsCore(
        string shortTypeName, BindingFlags bindingFlags, PropsDic dict, Lock lck, ReflectionCacheLegacy cache)
    {        
        Type type = Type(shortTypeName, cache);
        return PropsCore(type, bindingFlags, dict, lck);
    }
    
    [NoTrim(TypeColl)]
    public static PropertyInfo[] PropsCore(
        [Dyn(Interfaces)] Type type, BindingFlags bindingFlags, PropsDic dict, Lock lck)
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
    public static Dictionary<string, PropertyInfo> PropDicCore(
        string shortTypeName, BindingFlags bindingFlags, PropsDicDic dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return PropDicCore(type, bindingFlags, dict, lck);
    }
    
    [NoTrim(TypeColl)]
    public static Dictionary<string, PropertyInfo> PropDicCore(
        [Dyn(Interfaces)] Type type, BindingFlags bindingFlags, PropsDicDic dict, Lock lck)
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
    internal static readonly PropsDic    _propsDic        = new();
    internal static readonly Lock        _propsDicLock    = new();
    internal static readonly PropsDicDic _propsDicDic     = new();
    internal static readonly Lock        _propsDicDicLock = new();
    
    [NoTrim(TypeColl)] public   static PropertyInfo[]                   Props  <[Dyn(Interfaces)] T>(                         ) => PropsCore  (typeof(T),     BindingFlagsAll, _propsDic,    _propsDicLock           );
    [NoTrim(TypeColl)] public   static PropertyInfo[]                   Props  ([Dyn(Interfaces)]         Type type           ) => PropsCore  (type,          BindingFlagsAll, _propsDic,    _propsDicLock           );
    [NoTrim(GetTypes)] public   static PropertyInfo[]                   Props  (                          string shortTypeName) => PropsCore  (shortTypeName, BindingFlagsAll, _propsDic,    _propsDicLock,    _cache);
    [NoTrim(TypeColl)] public   static PropertyInfo[]                   Props  <[Dyn(Interfaces)] T>(     T obj               ) => PropsCore  (typeof(T),     BindingFlagsAll, _propsDic,    _propsDicLock           );
    [NoTrim(TypeColl)] public   static Dictionary<string, PropertyInfo> PropDic<[Dyn(Interfaces)] T>(                         ) => PropDicCore(typeof(T),     BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
    [NoTrim(TypeColl)] public   static Dictionary<string, PropertyInfo> PropDic([Dyn(Interfaces)]         Type type           ) => PropDicCore(type,          BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
    [NoTrim(GetTypes)] public   static Dictionary<string, PropertyInfo> PropDic(                          string shortTypeName) => PropDicCore(shortTypeName, BindingFlagsAll, _propsDicDic, _propsDicDicLock, _cache);
    [NoTrim(TypeColl)] public   static Dictionary<string, PropertyInfo> PropDic<[Dyn(Interfaces)] T>(     T obj               ) => PropDicCore(typeof(T),     BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
}
public partial class Reflector
{
    private         readonly PropsDic    _propsDic        = new();
    private         readonly Lock        _propsDicLock    = new();
    private         readonly PropsDicDic _propsDicDic     = new();
    private         readonly Lock        _propsDicDicLock = new();
              
    [NoTrim(TypeColl)] public          PropertyInfo[]                   Props  <[Dyn(Interfaces)] T>(                         ) => PropsCore  (typeof(T),     BindingFlags,    _propsDic,    _propsDicLock           );
    [NoTrim(TypeColl)] public          PropertyInfo[]                   Props  ([Dyn(Interfaces)]         Type type           ) => PropsCore  (type,          BindingFlags,    _propsDic,    _propsDicLock           );
    [NoTrim(GetTypes)] public          PropertyInfo[]                   Props  (                          string shortTypeName) => PropsCore  (shortTypeName, BindingFlags,    _propsDic,    _propsDicLock,    _cache);
    [NoTrim(TypeColl)] public          PropertyInfo[]                   Props  <[Dyn(Interfaces)] T>(     T obj               ) => PropsCore  (typeof(T),     BindingFlags,    _propsDic,    _propsDicLock           );
    [NoTrim(TypeColl)] public          Dictionary<string, PropertyInfo> PropDic<[Dyn(Interfaces)] T>(                         ) => PropDicCore(typeof(T),     BindingFlags,    _propsDicDic, _propsDicDicLock        );
    [NoTrim(TypeColl)] public          Dictionary<string, PropertyInfo> PropDic([Dyn(Interfaces)]         Type type           ) => PropDicCore(type,          BindingFlags,    _propsDicDic, _propsDicDicLock        );
    [NoTrim(GetTypes)] public          Dictionary<string, PropertyInfo> PropDic(                          string shortTypeName) => PropDicCore(shortTypeName, BindingFlags,    _propsDicDic, _propsDicDicLock, _cache);
    [NoTrim(TypeColl)] public          Dictionary<string, PropertyInfo> PropDic<[Dyn(Interfaces)] T>(     T obj               ) => PropDicCore(typeof(T),     BindingFlags,    _propsDicDic, _propsDicDicLock        );
}

public static partial class ReflectExtensions
{
    [NoTrim(TypeColl)] public static PropertyInfo[]                   Props  ([Dyn(Interfaces)]    this Type type           ) => PropsCore  (type,          BindingFlagsAll, _propsDic,    _propsDicLock           );
    [NoTrim(GetTypes)] public static PropertyInfo[]                   Props  (                     this string shortTypeName) => PropsCore  (shortTypeName, BindingFlagsAll, _propsDic,    _propsDicLock,    _cache);
    [NoTrim(TypeColl)] public static PropertyInfo[]                   Props  <[Dyn(Interfaces)] T>(this T obj               ) => PropsCore  (typeof(T),     BindingFlagsAll, _propsDic,    _propsDicLock           );
    [NoTrim(TypeColl)] public static Dictionary<string, PropertyInfo> PropDic([Dyn(Interfaces)]    this Type type           ) => PropDicCore(type,          BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
    [NoTrim(GetTypes)] public static Dictionary<string, PropertyInfo> PropDic(                     this string shortTypeName) => PropDicCore(shortTypeName, BindingFlagsAll, _propsDicDic, _propsDicDicLock, _cache);
    [NoTrim(TypeColl)] public static Dictionary<string, PropertyInfo> PropDic<[Dyn(Interfaces)] T>(this T obj               ) => PropDicCore(typeof(T),     BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
}

