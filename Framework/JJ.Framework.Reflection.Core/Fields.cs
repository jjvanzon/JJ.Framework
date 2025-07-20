namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [NoTrim(GetTypes)]
    public static FieldInfo[] FieldsCore(
        string shortTypeName, BindingFlags bindingFlags, FieldsDict dict, Lock lck, ReflectionCacheLegacy cache)
    {        
        Type type = Type(shortTypeName, cache);
        return FieldsCore(type, bindingFlags, dict, lck);
    }
    
    [NoTrim(Bases)]
    public static FieldInfo[] FieldsCore(
        [Dyn(AllFields | Intf)] Type type, BindingFlags bindingFlags, FieldsDict dict, Lock lck)
    {
        FieldInfo[]? fields;
        
        lock (lck)
        {
            if (dict.TryGetValue(type, out fields))
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
            dict[type] = fields;
        }
        
        return fields;
    }
    
    [NoTrim(GetTypes)]
    public static Dictionary<string, FieldInfo> FieldDictCore(
        string shortTypeName, BindingFlags bindingFlags, FieldsDictDict dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return FieldDictCore(type, bindingFlags, dict, lck);
    }
    
    [NoTrim(Bases)]
    public static Dictionary<string, FieldInfo> FieldDictCore(
        [Dyn(AllFields | Intf)] Type type, BindingFlags bindingFlags, FieldsDictDict dict, Lock lck)
    { 
        Dictionary<string, FieldInfo>? fields;
        
        lock (lck)
        {
            if (dict.TryGetValue(type, out fields))
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
            dict[type] = fields;
        }
        
        return fields;
    }
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public static partial class Reflect
{
    internal static readonly FieldsDict     _fieldsDict         = new();
    internal static readonly Lock           _fieldsDictLock     = new();
    internal static readonly FieldsDictDict _fieldsDictDict     = new();
    internal static readonly Lock           _fieldsDictDictLock = new();
    
    [NoTrim(Bases   )] public static FieldInfo[]                   Fields  <[Dyn(AllFields | Intf)] T>(                         ) => FieldsCore   (typeof(T),     BindingFlagsAll, _fieldsDict,     _fieldsDictLock            );
    [NoTrim(Bases   )] public static FieldInfo[]                   Fields  ([Dyn(AllFields | Intf)]         Type type           ) => FieldsCore   (type,          BindingFlagsAll, _fieldsDict,     _fieldsDictLock            );
    [NoTrim(GetTypes)] public static FieldInfo[]                   Fields  (                                string shortTypeName) => FieldsCore   (shortTypeName, BindingFlagsAll, _fieldsDict,     _fieldsDictLock,     _cache);
    [NoTrim(Bases   )] public static FieldInfo[]                   Fields  <[Dyn(AllFields | Intf)] T>(     T obj               ) => FieldsCore   (typeof(T),     BindingFlagsAll, _fieldsDict,     _fieldsDictLock            );
    [NoTrim(Bases   )] public static Dictionary<string, FieldInfo> FieldDic<[Dyn(AllFields | Intf)] T>(                         ) => FieldDictCore(typeof(T),     BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock        );
    [NoTrim(Bases   )] public static Dictionary<string, FieldInfo> FieldDic([Dyn(AllFields | Intf)]         Type type           ) => FieldDictCore(type,          BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock        );
    [NoTrim(GetTypes)] public static Dictionary<string, FieldInfo> FieldDic(                                string shortTypeName) => FieldDictCore(shortTypeName, BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock, _cache);
    [NoTrim(Bases   )] public static Dictionary<string, FieldInfo> FieldDic<[Dyn(AllFields | Intf)] T>(     T obj               ) => FieldDictCore(typeof(T),     BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock        );
}

public partial class Reflector
{
    private         readonly FieldsDict     _fieldsDict         = new();
    private         readonly Lock           _fieldsDictLock     = new();
    private         readonly FieldsDictDict _fieldsDictDict     = new();
    private         readonly Lock           _fieldsDictDictLock = new();

    [NoTrim(Bases   )] public        FieldInfo[]                   Fields  <[Dyn(AllFields | Intf)] T>(                         ) => FieldsCore   (typeof(T),     BindingFlags,    _fieldsDict,     _fieldsDictLock            );
    [NoTrim(Bases   )] public        FieldInfo[]                   Fields  ([Dyn(AllFields | Intf)]         Type type           ) => FieldsCore   (type,          BindingFlags,    _fieldsDict,     _fieldsDictLock            );
    [NoTrim(GetTypes)] public        FieldInfo[]                   Fields  (                                string shortTypeName) => FieldsCore   (shortTypeName, BindingFlags,    _fieldsDict,     _fieldsDictLock,     _cache);
    [NoTrim(Bases   )] public        FieldInfo[]                   Fields  <[Dyn(AllFields | Intf)] T>(     T obj               ) => FieldsCore   (typeof(T),     BindingFlags,    _fieldsDict,     _fieldsDictLock            );
    [NoTrim(Bases   )] public        Dictionary<string, FieldInfo> FieldDic<[Dyn(AllFields | Intf)] T>(                         ) => FieldDictCore(typeof(T),     BindingFlags,    _fieldsDictDict, _fieldsDictDictLock        );
    [NoTrim(Bases   )] public        Dictionary<string, FieldInfo> FieldDic([Dyn(AllFields | Intf)]         Type type           ) => FieldDictCore(type,          BindingFlags,    _fieldsDictDict, _fieldsDictDictLock        );
    [NoTrim(GetTypes)] public        Dictionary<string, FieldInfo> FieldDic(                                string shortTypeName) => FieldDictCore(shortTypeName, BindingFlags,    _fieldsDictDict, _fieldsDictDictLock, _cache);
    [NoTrim(Bases   )] public        Dictionary<string, FieldInfo> FieldDic<[Dyn(AllFields | Intf)] T>(     T obj               ) => FieldDictCore(typeof(T),     BindingFlags,    _fieldsDictDict, _fieldsDictDictLock        );
}

public static partial class ReflectExtensions
{
    [NoTrim(Bases   )] public static FieldInfo[]                   Fields  ([Dyn(AllFields | Intf)]    this Type type           ) => FieldsCore   (type,          BindingFlagsAll, _fieldsDict,     _fieldsDictLock            );
    [NoTrim(GetTypes)] public static FieldInfo[]                   Fields  (                           this string shortTypeName) => FieldsCore   (shortTypeName, BindingFlagsAll, _fieldsDict,     _fieldsDictLock,     _cache);
    [NoTrim(Bases   )] public static FieldInfo[]                   Fields  <[Dyn(AllFields | Intf)] T>(this T obj               ) => FieldsCore   (typeof(T),     BindingFlagsAll, _fieldsDict,     _fieldsDictLock            );
    [NoTrim(Bases   )] public static Dictionary<string, FieldInfo> FieldDic([Dyn(AllFields | Intf)]    this Type type           ) => FieldDictCore(type,          BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock        );
    [NoTrim(GetTypes)] public static Dictionary<string, FieldInfo> FieldDic(                           this string shortTypeName) => FieldDictCore(shortTypeName, BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock, _cache);
    [NoTrim(Bases   )] public static Dictionary<string, FieldInfo> FieldDic<[Dyn(AllFields | Intf)] T>(this T obj               ) => FieldDictCore(typeof(T),     BindingFlagsAll, _fieldsDictDict, _fieldsDictDictLock        );
}