// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

using static System.Reflection.BindingFlags;

namespace JJ.Framework.Reflection.Core;

public class Reflect
{    
    public override string ToString() => DebuggerDisplay(this);

    private readonly ReflectionCacheLegacy _reflectionCacheLegacy;
    public BindingFlags BindingFlags { get; }
    public bool MatchCase { get; }

    // Initialization

    public Reflect(                                                      ) : this(BindingFlagsAll, false) { }
    public Reflect(BindingFlags  bindingFlags                            ) : this(bindingFlags,   !bindingFlags.HasFlag(IgnoreCase)) { }
    public Reflect(MatchCaseFlag matchcase                               ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflect(bool          matchcase                               ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflect(MatchCaseFlag matchcase,    BindingFlags  bindingFlags) : this(bindingFlags,    Has(matchcase)) { }
    public Reflect(bool          matchcase,    BindingFlags  bindingFlags) : this(bindingFlags,    Has(matchcase)) { }
    public Reflect(BindingFlags  bindingFlags, MatchCaseFlag matchcase   ) : this(bindingFlags,    Has(matchcase)) { }
    public Reflect(BindingFlags  bindingFlags, bool          matchcase   )
    {
        bindingFlags = matchcase ? bindingFlags.ClearFlag(IgnoreCase) : bindingFlags.SetFlag(IgnoreCase);
        BindingFlags = bindingFlags;
        MatchCase = matchcase;
        _reflectionCacheLegacy = new ReflectionCacheLegacy(bindingFlags);
    }

    // Property

    private readonly Dictionary<(Type, string), PropertyInfo?> _propDic = new();
    private readonly Lock _propDicLock = new();

    public  PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name);
    public  PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name);
    public  PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name);
    public  PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name);
    public  PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name);
    public  PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name);
    public  PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable);
    public  PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable);
    public  PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable);
    public  PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name);
    public  PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name);
    public  PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name);
    public  PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable);
    public  PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable);
    public  PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable);

    private PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable)
    {
        return Type(shortTypeName, nullable)?.Prop(name, nullable, this);
    }
    private PropertyInfo? PropOrSomething(Type type, string name, bool nullable)
    {
        return nullable ? PropOrNull(type, name) : PropOrThrow(type, name);
    }
    
    private PropertyInfo PropOrThrow(string shortTypeName, string name) => PropOrThrow(Type(shortTypeName), name);
    private PropertyInfo PropOrThrow(Type   type,          string name)
    {
        PropertyInfo? prop = PropOrNull(type, name);
        
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        
        return prop;
    }

    private PropertyInfo? PropOrNull(string shortTypeName, string name) => Type(shortTypeName, nullable)?.Prop(name, nullable, this);
    private PropertyInfo? PropOrNull(Type   type,          string name)
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
                if (t.GetProperty(nameTrimmed, BindingFlags) is PropertyInfo p)
                {
                    prop ??= p;
                    _propDic[(t, name)] = p;
                }
            }

            return prop;
        }
    }
    
    // Type

    private Type  Type (string shortTypeName                       ) =>            _reflectionCacheLegacy.   GetTypeByShortName(shortTypeName);
    private Type? Type (string shortTypeName, NullableFlag nullable) =>            _reflectionCacheLegacy.TryGetTypeByShortName(shortTypeName);
    private Type? Type (string shortTypeName, bool         nullable) => nullable ? _reflectionCacheLegacy.TryGetTypeByShortName(shortTypeName) 
                                                                                 : _reflectionCacheLegacy.   GetTypeByShortName(shortTypeName);
}