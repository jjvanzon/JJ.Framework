namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    public static PropertyInfo[] PropsCore(
        string shortTypeName, BindingFlags bindingFlags, PropsDic dic, Lock lck, ReflectionCacheLegacy cache)
    {        
        Type type = Type(shortTypeName, cache);
        return PropsCore(type, bindingFlags, dic, lck);
    }
    
    public static PropertyInfo[] PropsCore(
        Type type, BindingFlags bindingFlags, PropsDic dic, Lock lck)
    {
        PropertyInfo[]? props;
        
        lock (lck)
        {
            if (dic.TryGetValue(type, out props))
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
            dic[type] = props;
        }
        
        return props;
    }
    
    public static Dictionary<string, PropertyInfo> PropDicCore(
        string shortTypeName, BindingFlags bindingFlags, PropsDicDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return PropDicCore(type, bindingFlags, dic, lck);
    }
    
    public static Dictionary<string, PropertyInfo> PropDicCore(
        Type type, BindingFlags bindingFlags, PropsDicDic dic, Lock lck)
    { 
        Dictionary<string, PropertyInfo>? props;
        
        lock (lck)
        {
            if (dic.TryGetValue(type, out props))
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
            dic[type] = props;
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
    
    public static PropertyInfo[]                   Props  <T>(                         ) => PropsCore  (typeof(T),     BindingFlagsAll, _propsDic,    _propsDicLock           );
    public static PropertyInfo[]                   Props     (     Type type           ) => PropsCore  (type,          BindingFlagsAll, _propsDic,    _propsDicLock           );
    public static PropertyInfo[]                   Props     (     string shortTypeName) => PropsCore  (shortTypeName, BindingFlagsAll, _propsDic,    _propsDicLock,    _cache);
    public static PropertyInfo[]                   Props  <T>(     T obj               ) => PropsCore  (typeof(T),     BindingFlagsAll, _propsDic,    _propsDicLock           );
    public static Dictionary<string, PropertyInfo> PropDic<T>(                         ) => PropDicCore(typeof(T),     BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
    public static Dictionary<string, PropertyInfo> PropDic   (     Type type           ) => PropDicCore(type,          BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
    public static Dictionary<string, PropertyInfo> PropDic   (     string shortTypeName) => PropDicCore(shortTypeName, BindingFlagsAll, _propsDicDic, _propsDicDicLock, _cache);
    public static Dictionary<string, PropertyInfo> PropDic<T>(     T obj               ) => PropDicCore(typeof(T),     BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
}
public partial class Reflector
{
    private         readonly PropsDic    _propsDic        = new();
    private         readonly Lock        _propsDicLock    = new();
    private         readonly PropsDicDic _propsDicDic     = new();
    private         readonly Lock        _propsDicDicLock = new();

    public        PropertyInfo[]                   Props  <T>(                         ) => PropsCore  (typeof(T),     BindingFlags,    _propsDic,    _propsDicLock           );
    public        PropertyInfo[]                   Props     (     Type type           ) => PropsCore  (type,          BindingFlags,    _propsDic,    _propsDicLock           );
    public        PropertyInfo[]                   Props     (     string shortTypeName) => PropsCore  (shortTypeName, BindingFlags,    _propsDic,    _propsDicLock,    _cache);
    public        PropertyInfo[]                   Props  <T>(     T obj               ) => PropsCore  (typeof(T),     BindingFlags,    _propsDic,    _propsDicLock           );
    public        Dictionary<string, PropertyInfo> PropDic<T>(                         ) => PropDicCore(typeof(T),     BindingFlags,    _propsDicDic, _propsDicDicLock        );
    public        Dictionary<string, PropertyInfo> PropDic   (     Type type           ) => PropDicCore(type,          BindingFlags,    _propsDicDic, _propsDicDicLock        );
    public        Dictionary<string, PropertyInfo> PropDic   (     string shortTypeName) => PropDicCore(shortTypeName, BindingFlags,    _propsDicDic, _propsDicDicLock, _cache);
    public        Dictionary<string, PropertyInfo> PropDic<T>(     T obj               ) => PropDicCore(typeof(T),     BindingFlags,    _propsDicDic, _propsDicDicLock        );
}

public static partial class ReflectExtensions
{
    public static PropertyInfo[]                   Props     (this Type type           ) => PropsCore  (type,          BindingFlagsAll, _propsDic,    _propsDicLock           );
    public static PropertyInfo[]                   Props     (this string shortTypeName) => PropsCore  (shortTypeName, BindingFlagsAll, _propsDic,    _propsDicLock,    _cache);
    public static PropertyInfo[]                   Props  <T>(this T obj               ) => PropsCore  (typeof(T),     BindingFlagsAll, _propsDic,    _propsDicLock           );
    public static Dictionary<string, PropertyInfo> PropDic   (this Type type           ) => PropDicCore(type,          BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
    public static Dictionary<string, PropertyInfo> PropDic   (this string shortTypeName) => PropDicCore(shortTypeName, BindingFlagsAll, _propsDicDic, _propsDicDicLock, _cache);
    public static Dictionary<string, PropertyInfo> PropDic<T>(this T obj               ) => PropDicCore(typeof(T),     BindingFlagsAll, _propsDicDic, _propsDicDicLock        );
}

