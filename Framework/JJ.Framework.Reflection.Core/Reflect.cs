// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.Reflection.Core;

public static class Reflect
{
    private const BindingFlags BindingFlags = BindingFlagsAll;
    private static readonly ReflectionCacheLegacy _cache = new(BindingFlags);
    
    // Prop

    private static readonly PropDic _propDic = new();
    private static readonly Lock _propDicLock = new();
    
    public static PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo  Prop<T>(T obj,             [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public static PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    public static PropertyInfo? Prop<T>(T obj,                      bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
}
