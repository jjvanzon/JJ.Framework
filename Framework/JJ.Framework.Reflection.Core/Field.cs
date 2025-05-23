namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo FieldOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, FieldDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        return FieldOrThrow(Type(shortTypeName, cache), name, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo FieldOrThrow(Type type, string name, BindingFlags bindingFlags, FieldDic dic, Lock lck)
    {
        FieldInfo? field = FieldOrNull(type, name, bindingFlags, dic, lck);
        if (field == null)
        {
            throw new Exception($"Field {name} not found in {type.Name}.");
        }
        return field;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrNull(string shortTypeName, string name, BindingFlags bindingFlags, FieldDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return FieldOrNull(type, name, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrNull(Type type, string name, BindingFlags bindingFlags, FieldDic dic, Lock lck)
    {
        FieldInfo? field;
        
        lock (lck)
        {
            if (dic.TryGetValue((type, name), out field))
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
            dic[(type, name)] = field;
        }
        
        return field;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, FieldDic dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return FieldOrSomething(type, name, nullable, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrSomething(Type type, string name, bool nullable, BindingFlags bindingFlags, FieldDic dic, Lock lck) 
        => nullable ? FieldOrNull(type, name, bindingFlags, dic, lck) : FieldOrThrow(type, name, bindingFlags, dic, lck);
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public static partial class Reflect
{
          internal static readonly FieldDic _fieldDic = new();
          internal static readonly Lock _fieldLock = new();
          
          public static FieldInfo  Field<T>(                  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo  Field   (     Type   type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo  Field   (     string type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo  Field<T>(     T      obj,  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field<T>(                           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (     Type   type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (     string type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo? Field<T>(     T      obj,           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field<T>(                           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (     Type   type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (     string type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo? Field<T>(     T      obj,           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1)] public static FieldInfo? Field<T>(                           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1)] public static FieldInfo? Field   (     Type   type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1)] public static FieldInfo? Field   (     string type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
[Prio(1)] public static FieldInfo? Field<T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field<T>(                           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (     Type   type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (     string type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo? Field<T>(     T      obj,           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
}

public partial class Reflector
{    
          private readonly FieldDic _fieldDic = new();
          private readonly Lock _fieldLock = new();
         
          public        FieldInfo  Field<T>(                  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo  Field   (     Type   type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo  Field   (     string type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlags,    _fieldDic, _fieldLock, _cache);
          public        FieldInfo  Field<T>(     T      obj,  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field<T>(                           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field   (     Type   type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field   (     string type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock, _cache);
          public        FieldInfo? Field<T>(     T      obj,           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field<T>(                           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field   (     Type   type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field   (     string type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock, _cache);
          public        FieldInfo? Field<T>(     T      obj,           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
[Prio(1)] public        FieldInfo? Field<T>(                           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
[Prio(1)] public        FieldInfo? Field   (     Type   type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock        );
[Prio(1)] public        FieldInfo? Field   (     string type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlags,    _fieldDic, _fieldLock, _cache);
[Prio(1)] public        FieldInfo? Field<T>(     T      obj,           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field<T>(                           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field   (     Type   type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
          public        FieldInfo? Field   (     string type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlags,    _fieldDic, _fieldLock, _cache);
          public        FieldInfo? Field<T>(     T      obj,           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlags,    _fieldDic, _fieldLock        );
}

public static partial class ReflectExtensions
{
          public static FieldInfo  Field   (this Type   type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo  Field   (this string type, [Caller] string name = ""                             ) => FieldOrThrow    (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo  Field<T>(this T      obj,  [Caller] string name = ""                             ) => FieldOrThrow    (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (this Type   type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (this string type,          string name,        NullFlag? nullable       ) => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo? Field<T>(this T      obj,           string name,        NullFlag? nullable       ) => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (this Type   type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (this string type,          string name,        bool      nullable       ) => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo? Field<T>(this T      obj,           string name,        bool      nullable       ) => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1)] public static FieldInfo? Field   (this Type   type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock        );
[Prio(1)] public static FieldInfo? Field   (this string type,          NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (type,      name,           BindingFlagsAll, _fieldDic, _fieldLock, _cache);
[Prio(1)] public static FieldInfo? Field<T>(this T      obj,           NullFlag? nullable, [Caller] string name = "") => FieldOrNull     (typeof(T), name,           BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (this Type   type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
          public static FieldInfo? Field   (this string type,          bool      nullable, [Caller] string name = "") => FieldOrSomething(type,      name, nullable, BindingFlagsAll, _fieldDic, _fieldLock, _cache);
          public static FieldInfo? Field<T>(this T      obj,           bool      nullable, [Caller] string name = "") => FieldOrSomething(typeof(T), name, nullable, BindingFlagsAll, _fieldDic, _fieldLock        );
}
