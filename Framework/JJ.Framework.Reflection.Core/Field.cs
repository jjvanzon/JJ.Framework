namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static FieldInfo FieldOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, FieldDic dict, Lock lck, ReflectionCacheLegacy cache)
    {
        return FieldOrThrow(Type(shortTypeName, cache), name, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(TypeColl)]
    public static FieldInfo FieldOrThrow([Dyn(Interfaces)] Type type, string name, BindingFlags bindingFlags, FieldDic dict, Lock lck)
    {
        ThrowIfNull(type);
        FieldInfo? field = FieldOrNull(type, name, bindingFlags, dict, lck);
        if (field == null)
        {
            throw new Exception($"Field {name} not found in {type.Name}.");
        }
        return field;
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static FieldInfo? FieldOrNull(string shortTypeName, string name, BindingFlags bindingFlags, FieldDic dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return FieldOrNull(type, name, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(TypeColl)]
    public static FieldInfo? FieldOrNull([Dyn(Interfaces)] Type type, string name, BindingFlags bindingFlags, FieldDic dict, Lock lck)
    {
        FieldInfo? field;
        
        lock (lck)
        {
            if (dict.TryGetValue((type, name), out field))
            {
                return field;
            }
        }
            
        ThrowIfNullOrWhiteSpace(name);
        
        string trim = name.Trim();
        
        field = (from t in TypesAndBases(type, bindingFlags)
                 let f = t.GetField(trim, bindingFlags)
                 where f != null
                 select f).FirstOrDefault();
        
        lock (lck)
        {
            dict[(type, name)] = field;
        }
        
        return field;
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static FieldInfo? FieldOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, FieldDic dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return FieldOrSomething(type, name, nullable, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(TypeColl)]
    public static FieldInfo? FieldOrSomething([Dyn(Interfaces)] Type type, string name, bool nullable, BindingFlags bindingFlags, FieldDic dict, Lock lck) 
        => nullable ? FieldOrNull(type, name, bindingFlags, dict, lck) : FieldOrThrow(type, name, bindingFlags, dict, lck);
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public static partial class Reflect
{
                           internal static readonly FieldDic _fieldDic = new();
                           internal static readonly Lock _fieldLock = new();
                   
        [NoTrim(TypeColl)] public static FieldInfo  Field<[Dyn(Interfaces)] T>(                  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo  Field([Dyn(Interfaces)]         Type   type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo  Field(                          string type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo  Field<[Dyn(Interfaces)] T>(     T      obj,  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(                           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]         Type   type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo? Field(                          string type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(                           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]         Type   type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo? Field(                          string type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1),NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(                           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1),NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]         Type   type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1),NoTrim(GetTypes)] public static FieldInfo? Field(                          string type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
[Prio(1),NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(                           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]         Type   type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo? Field(                          string type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
}

public partial class Reflector
{    
                           private readonly FieldDic _fieldDic = new();
                           private readonly Lock _fieldLock = new();
         
        [NoTrim(TypeColl)] public        FieldInfo  Field<[Dyn(Interfaces)] T>(                  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo  Field([Dyn(Interfaces)]         Type   type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public        FieldInfo  Field(                          string type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlags,    _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public        FieldInfo  Field<[Dyn(Interfaces)] T>(     T      obj,  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(                           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo? Field([Dyn(Interfaces)]         Type   type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public        FieldInfo? Field(                          string type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(                           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo? Field([Dyn(Interfaces)]         Type   type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public        FieldInfo? Field(                          string type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
[Prio(1),NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(                           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
[Prio(1),NoTrim(TypeColl)] public        FieldInfo? Field([Dyn(Interfaces)]         Type   type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock        );
[Prio(1),NoTrim(GetTypes)] public        FieldInfo? Field(                          string type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock, _cache);
[Prio(1),NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(                           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public        FieldInfo? Field([Dyn(Interfaces)]         Type   type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public        FieldInfo? Field(                          string type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public        FieldInfo? Field<[Dyn(Interfaces)] T>(     T      obj,           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
}

public static partial class ReflectExtensions
{
        [NoTrim(TypeColl)] public static FieldInfo  Field([Dyn(Interfaces)]    this Type   type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo  Field(                     this string type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo  Field<[Dyn(Interfaces)] T>(this T      obj,  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]    this Type   type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo? Field(                     this string type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(this T      obj,           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]    this Type   type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo? Field(                     this string type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(this T      obj,           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1),NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]    this Type   type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1),NoTrim(GetTypes)] public static FieldInfo? Field(                     this string type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
[Prio(1),NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(this T      obj,           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(TypeColl)] public static FieldInfo? Field([Dyn(Interfaces)]    this Type   type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
        [NoTrim(GetTypes)] public static FieldInfo? Field(                     this string type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
        [NoTrim(TypeColl)] public static FieldInfo? Field<[Dyn(Interfaces)] T>(this T      obj,           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
}
