namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    public static FieldInfo[] FieldsCore(
        string shortTypeName, BindingFlags bindingFlags, FieldsDic dic, Lock lck, ReflectionCacheLegacy cache)
    {        
        Type type = Type(shortTypeName, cache);
        return FieldsCore(type, bindingFlags, dic, lck);
    }
    
    public static FieldInfo[] FieldsCore(
        Type type, BindingFlags bindingFlags, FieldsDic dic, Lock lck)
    {
        FieldInfo[]? fields;
        
        lock (lck)
        {
            if (dic.TryGetValue(type, out fields))
            {
                return fields;
            }
        }

        fields = TypesAndBases(type, bindingFlags)
                .SelectMany(x => x.GetFields(bindingFlags))
                .Distinct(x => x.Name)
                .ToArray();
        
        lock (lck)
        {
            dic[type] = fields;
        }
        
        return fields;
    }
    
    public static Dictionary<string, FieldInfo> FieldDicCore(
        string shortTypeName, BindingFlags bindingFlags, FieldsDicDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return FieldDicCore(type, bindingFlags, dic, lck);
    }
    
    public static Dictionary<string, FieldInfo> FieldDicCore(
        Type type, BindingFlags bindingFlags, FieldsDicDic dic, Lock lck)
    { 
        Dictionary<string, FieldInfo>? fields;
        
        lock (lck)
        {
            if (dic.TryGetValue(type, out fields))
            {
                return fields;
            }
        }
        
        fields = TypesAndBases(type, bindingFlags)
                .SelectMany(x => x.GetFields(bindingFlags))
                .Distinct(x => x.Name)
                .ToDictionary(x => x.Name);
        
        lock (lck)
        {
            dic[type] = fields;
        }
        
        return fields;
    }
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public static partial class Reflect
{
    internal static readonly FieldsDic    _fieldsDic        = new();
    internal static readonly Lock         _fieldsDicLock    = new();
    internal static readonly FieldsDicDic _fieldsDicDic     = new();
    internal static readonly Lock         _fieldsDicDicLock = new();
    
    public static FieldInfo[]                   Fields  <T>(                         ) => FieldsCore  (typeof(T),     BindingFlagsAll, _fieldsDic,    _fieldsDicLock           );
    public static FieldInfo[]                   Fields     (     Type type           ) => FieldsCore  (type,          BindingFlagsAll, _fieldsDic,    _fieldsDicLock           );
    public static FieldInfo[]                   Fields     (     string shortTypeName) => FieldsCore  (shortTypeName, BindingFlagsAll, _fieldsDic,    _fieldsDicLock,    _cache);
    public static FieldInfo[]                   Fields  <T>(     T obj               ) => FieldsCore  (typeof(T),     BindingFlagsAll, _fieldsDic,    _fieldsDicLock           );
    public static Dictionary<string, FieldInfo> FieldDic<T>(                         ) => FieldDicCore(typeof(T),     BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock        );
    public static Dictionary<string, FieldInfo> FieldDic   (     Type type           ) => FieldDicCore(type,          BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock        );
    public static Dictionary<string, FieldInfo> FieldDic   (     string shortTypeName) => FieldDicCore(shortTypeName, BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock, _cache);
    public static Dictionary<string, FieldInfo> FieldDic<T>(     T obj               ) => FieldDicCore(typeof(T),     BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock        );
}
public partial class Reflector
{
    private         readonly FieldsDic    _fieldsDic        = new();
    private         readonly Lock         _fieldsDicLock    = new();
    private         readonly FieldsDicDic _fieldsDicDic     = new();
    private         readonly Lock         _fieldsDicDicLock = new();

    public        FieldInfo[]                   Fields  <T>(                         ) => FieldsCore  (typeof(T),     BindingFlags,    _fieldsDic,    _fieldsDicLock           );
    public        FieldInfo[]                   Fields     (     Type type           ) => FieldsCore  (type,          BindingFlags,    _fieldsDic,    _fieldsDicLock           );
    public        FieldInfo[]                   Fields     (     string shortTypeName) => FieldsCore  (shortTypeName, BindingFlags,    _fieldsDic,    _fieldsDicLock,    _cache);
    public        FieldInfo[]                   Fields  <T>(     T obj               ) => FieldsCore  (typeof(T),     BindingFlags,    _fieldsDic,    _fieldsDicLock           );
    public        Dictionary<string, FieldInfo> FieldDic<T>(                         ) => FieldDicCore(typeof(T),     BindingFlags,    _fieldsDicDic, _fieldsDicDicLock        );
    public        Dictionary<string, FieldInfo> FieldDic   (     Type type           ) => FieldDicCore(type,          BindingFlags,    _fieldsDicDic, _fieldsDicDicLock        );
    public        Dictionary<string, FieldInfo> FieldDic   (     string shortTypeName) => FieldDicCore(shortTypeName, BindingFlags,    _fieldsDicDic, _fieldsDicDicLock, _cache);
    public        Dictionary<string, FieldInfo> FieldDic<T>(     T obj               ) => FieldDicCore(typeof(T),     BindingFlags,    _fieldsDicDic, _fieldsDicDicLock        );
}

public static partial class ReflectExtensions
{
    public static FieldInfo[]                   Fields     (this Type type           ) => FieldsCore  (type,          BindingFlagsAll, _fieldsDic,    _fieldsDicLock           );
    public static FieldInfo[]                   Fields     (this string shortTypeName) => FieldsCore  (shortTypeName, BindingFlagsAll, _fieldsDic,    _fieldsDicLock,    _cache);
    public static FieldInfo[]                   Fields  <T>(this T obj               ) => FieldsCore  (typeof(T),     BindingFlagsAll, _fieldsDic,    _fieldsDicLock           );
    public static Dictionary<string, FieldInfo> FieldDic   (this Type type           ) => FieldDicCore(type,          BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock        );
    public static Dictionary<string, FieldInfo> FieldDic   (this string shortTypeName) => FieldDicCore(shortTypeName, BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock, _cache);
    public static Dictionary<string, FieldInfo> FieldDic<T>(this T obj               ) => FieldDicCore(typeof(T),     BindingFlagsAll, _fieldsDicDic, _fieldsDicDicLock        );
}