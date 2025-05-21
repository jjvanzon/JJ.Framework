namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo FieldOrThrow(string shortTypeName, string name, BindingFlags bindingFlags, FieldDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        return FieldOrThrow(Type(shortTypeName, cache), name, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo FieldOrThrow(Type type, string name, BindingFlags bindingFlags, FieldDic dic, Lock dicLock)
    {
        FieldInfo? field = FieldOrNull(type, name, bindingFlags, dic, dicLock);
        if (field == null)
        {
            throw new Exception($"Field {name} not found in {type.Name}.");
        }
        return field;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrNull(string shortTypeName, string name, BindingFlags bindingFlags, FieldDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return FieldOrNull(type, name, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrNull(Type type, string name, BindingFlags bindingFlags, FieldDic dic, Lock dicLock)
    {
        lock (dicLock)
        {
            if (dic.TryGetValue((type, name), out FieldInfo? field))
            {
                return field;
            }
            
            ThrowIfNull(type);
            ThrowIfNullOrWhiteSpace(name);
            string nameTrimmed = name.Trim();
            
            foreach (Type typeOrBase in TypesAndBases(type))
            {
                if (typeOrBase.GetField(nameTrimmed, bindingFlags) is FieldInfo fieldResolved)
                {
                    field ??= fieldResolved;
                    dic[(typeOrBase, name)] = fieldResolved;
                }
            }
            
            return field;
        }
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrSomething(string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, FieldDic dic, Lock dicLock, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return FieldOrSomething(type, name, nullable, bindingFlags, dic, dicLock);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static FieldInfo? FieldOrSomething(Type type, string name, bool nullable, BindingFlags bindingFlags, FieldDic dic, Lock dicLock) 
        => nullable ? FieldOrNull(type, name, bindingFlags, dic, dicLock) : FieldOrThrow(type, name, bindingFlags, dic, dicLock);
}

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

public static partial class Reflect
{
    internal static readonly FieldDic _fieldDic = new();
    internal static readonly Lock _fieldDicLock = new();
    
    public static FieldInfo  Field<T>(                           [Caller] string name = ""                                ) => FieldOrThrow    (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo  Field   (     Type type,            [Caller] string name = ""                                ) => FieldOrThrow    (type,          name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo  Field   (     string shortTypeName, [Caller] string name = ""                                ) => FieldOrThrow    (shortTypeName, name,           BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo  Field<T>(     T obj,                [Caller] string name = ""                                ) => FieldOrThrow    (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field<T>(                                    string name,           NullableFlag nullable    ) => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     Type type,                     string name,           NullableFlag nullable    ) => FieldOrNull     (type,          name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     string shortTypeName,          string name,           NullableFlag nullable    ) => FieldOrNull     (shortTypeName, name,           BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(     T obj,                         string name,           NullableFlag nullable    ) => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field<T>(                                    string name,           bool         nullable    ) => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     Type type,                     string name,           bool         nullable    ) => FieldOrSomething(type,          name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     string shortTypeName,          string name,           bool         nullable    ) => FieldOrSomething(shortTypeName, name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(     T obj,                         string name,           bool         nullable    ) => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field<T>(                                    NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     Type type,                     NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (type,          name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (shortTypeName, name,           BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(     T obj,                         NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field<T>(                                    bool         nullable, [Caller] string name = "") => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     Type type,                     bool         nullable, [Caller] string name = "") => FieldOrSomething(type,          name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (     string shortTypeName,          bool         nullable, [Caller] string name = "") => FieldOrSomething(shortTypeName, name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(     T obj,                         bool         nullable, [Caller] string name = "") => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
}

public partial class Reflector
{    
    private readonly FieldDic _fieldDic = new();
    private readonly Lock _fieldDicLock = new();

    public        FieldInfo  Field<T>(                           [Caller] string name = ""                                ) => FieldOrThrow    (typeof(T),     name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo  Field   (     Type type,            [Caller] string name = ""                                ) => FieldOrThrow    (type,          name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo  Field   (     string shortTypeName, [Caller] string name = ""                                ) => FieldOrThrow    (shortTypeName, name,           BindingFlags,    _fieldDic, _fieldDicLock, _cache);
    public        FieldInfo  Field<T>(     T obj,                [Caller] string name = ""                                ) => FieldOrThrow    (typeof(T),     name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field<T>(                                    string name,           NullableFlag nullable    ) => FieldOrNull     (typeof(T),     name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     Type type,                     string name,           NullableFlag nullable    ) => FieldOrNull     (type,          name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     string shortTypeName,          string name,           NullableFlag nullable    ) => FieldOrNull     (shortTypeName, name,           BindingFlags,    _fieldDic, _fieldDicLock, _cache);
    public        FieldInfo? Field<T>(     T obj,                         string name,           NullableFlag nullable    ) => FieldOrNull     (typeof(T),     name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field<T>(                                    string name,           bool         nullable    ) => FieldOrSomething(typeof(T),     name, nullable, BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     Type type,                     string name,           bool         nullable    ) => FieldOrSomething(type,          name, nullable, BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     string shortTypeName,          string name,           bool         nullable    ) => FieldOrSomething(shortTypeName, name, nullable, BindingFlags,    _fieldDic, _fieldDicLock, _cache);
    public        FieldInfo? Field<T>(     T obj,                         string name,           bool         nullable    ) => FieldOrSomething(typeof(T),     name, nullable, BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field<T>(                                    NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (typeof(T),     name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     Type type,                     NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (type,          name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (shortTypeName, name,           BindingFlags,    _fieldDic, _fieldDicLock, _cache);
    public        FieldInfo? Field<T>(     T obj,                         NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (typeof(T),     name,           BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field<T>(                                    bool         nullable, [Caller] string name = "") => FieldOrSomething(typeof(T),     name, nullable, BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     Type type,                     bool         nullable, [Caller] string name = "") => FieldOrSomething(type,          name, nullable, BindingFlags,    _fieldDic, _fieldDicLock        );
    public        FieldInfo? Field   (     string shortTypeName,          bool         nullable, [Caller] string name = "") => FieldOrSomething(shortTypeName, name, nullable, BindingFlags,    _fieldDic, _fieldDicLock, _cache);
    public        FieldInfo? Field<T>(     T obj,                         bool         nullable, [Caller] string name = "") => FieldOrSomething(typeof(T),     name, nullable, BindingFlags,    _fieldDic, _fieldDicLock        );
}

public static partial class ReflectExtensions
{
    //public static FieldInfo  Field<T>(this                              string name                                     ) => FieldOrThrow    (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo  Field   (this Type type,            [Caller] string name = ""                                ) => FieldOrThrow    (type,          name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo  Field   (this string shortTypeName, [Caller] string name = ""                                ) => FieldOrThrow    (shortTypeName, name,           BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo  Field<T>(this T obj,                [Caller] string name = ""                                ) => FieldOrThrow    (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    //public static FieldInfo? Field<T>(this                              string name,           NullableFlag nullable    ) => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this Type type,                     string name,           NullableFlag nullable    ) => FieldOrNull     (type,          name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this string shortTypeName,          string name,           NullableFlag nullable    ) => FieldOrNull     (shortTypeName, name,           BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(this T obj,                         string name,           NullableFlag nullable    ) => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    //public static FieldInfo? Field<T>(this                              string name,           bool         nullable    ) => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this Type type,                     string name,           bool         nullable    ) => FieldOrSomething(type,          name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this string shortTypeName,          string name,           bool         nullable    ) => FieldOrSomething(shortTypeName, name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(this T obj,                         string name,           bool         nullable    ) => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    //public static FieldInfo? Field<T>(this                              NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this Type type,                     NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (type,          name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (shortTypeName, name,           BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(this T obj,                         NullableFlag nullable, [Caller] string name = "") => FieldOrNull     (typeof(T),     name,           BindingFlagsAll, _fieldDic, _fieldDicLock        );
    //public static FieldInfo? Field<T>(this                              bool         nullable, [Caller] string name = "") => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this Type type,                     bool         nullable, [Caller] string name = "") => FieldOrSomething(type,          name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
    public static FieldInfo? Field   (this string shortTypeName,          bool         nullable, [Caller] string name = "") => FieldOrSomething(shortTypeName, name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock, _cache);
    public static FieldInfo? Field<T>(this T obj,                         bool         nullable, [Caller] string name = "") => FieldOrSomething(typeof(T),     name, nullable, BindingFlagsAll, _fieldDic, _fieldDicLock        );
}
