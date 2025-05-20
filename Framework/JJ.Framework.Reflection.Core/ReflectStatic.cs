// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local
namespace JJ.Framework.Reflection.Core;

public static class Reflect
{
    private static readonly ReflectionCacheLegacy _reflectionCacheLegacy = new(BindingFlagsAll);
    
    // Prop

    private static readonly Dictionary<(Type, string), PropertyInfo?> _propDic = new();
    private static readonly Lock _propDicLock = new();

    public static PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name);
    public static PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name);
    public static PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name);
    public static PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name);
    public static PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name);
    public static PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name);
    public static PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable);
    public static PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable);
    public static PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable);
    public static PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name);
    public static PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name);
    public static PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name);
    public static PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable);
    public static PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable);
    public static PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable);

    private static PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable)
    {
        return Type(shortTypeName, nullable)?.Prop(name, nullable);
    }
    private static PropertyInfo? PropOrSomething(Type type, string name, bool nullable)
    {
        return nullable ? PropOrNull(type, name) : PropOrThrow(type, name);
    }
    
    private static PropertyInfo PropOrThrow(string shortTypeName, string name) => PropOrThrow(Type(shortTypeName), name);
    private static PropertyInfo PropOrThrow(Type   type,          string name)
    {
        PropertyInfo? prop = PropOrNull(type, name);
        
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        
        return prop;
    }

    private static PropertyInfo? PropOrNull(string shortTypeName, string name) => Type(shortTypeName, nullable)?.Prop(name, nullable);
    private static PropertyInfo? PropOrNull(Type   type,          string name)
    {
        lock (_propDicLock)
        {
            if (_propDic.TryGetValue((type, name), out PropertyInfo? prop))
            {
                return prop;
            }
            
            ThrowIfNull(type);
            ThrowIfNullOrWhiteSpace(name);
            
            string nameTrimmed = name.Trim();
            
            foreach (Type t in type.GetTypesInHierarchy())
            {
                if (t.GetProperty(nameTrimmed, BindingFlagsAll) is PropertyInfo p)
                {
                    prop ??= p;
                    _propDic[(t, name)] = p;
                }
            }
            
            return prop;
        }
    }
    
    // Type

    private static Type  Type (string shortTypeName                       ) =>            _reflectionCacheLegacy.   GetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, NullableFlag nullable) =>            _reflectionCacheLegacy.TryGetTypeByShortName(shortTypeName);
    private static Type? Type (string shortTypeName, bool         nullable) => nullable ? _reflectionCacheLegacy.TryGetTypeByShortName(shortTypeName) 
                                                                                        : _reflectionCacheLegacy.   GetTypeByShortName(shortTypeName);
}
