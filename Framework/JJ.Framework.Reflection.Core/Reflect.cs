// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Reflection.Core;

public class Reflect
{    
    public override string ToString() => DebuggerDisplay(this);
    public BindingFlags BindingFlags { get; }
    public bool MatchCase { get; }

    private readonly ReflectionCacheLegacy _reflectionCacheLegacy;

    public Reflect(                                                    ) : this(BindingFlagsAll, false) { }
    public Reflect(BindingFlags bindingFlags                           ) : this(bindingFlags   , GetMatchCase(bindingFlags)) { }
    public Reflect(MatchCaseFlag matchcase                             ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflect(bool matchcase                                      ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflect(MatchCaseFlag matchcase  , BindingFlags bindingFlags) : this(bindingFlags   , Has(matchcase)) { }
    public Reflect(bool matchcase           , BindingFlags bindingFlags) : this(bindingFlags   , Has(matchcase)) { }
    public Reflect(BindingFlags bindingFlags, MatchCaseFlag matchcase  ) : this(bindingFlags   , Has(matchcase)) { }
    public Reflect(BindingFlags bindingFlags, bool matchcase           )
    {
        if (matchcase)
        {
            bindingFlags &= ~BindingFlags.IgnoreCase;
        }
        else
        {
            bindingFlags |= BindingFlags.IgnoreCase;
        }
        
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

    private PropertyInfo PropOrThrow(string shortTypeName, string name) => PropOrThrow(TypeByShortName(shortTypeName), name);
    private PropertyInfo PropOrThrow(Type   type,          string name)
    {
        PropertyInfo? prop = PropOrNull(type, name);
        
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        
        return prop;
    }

    private PropertyInfo? PropOrNull(string shortTypeName, string name) => PropOrNull(TypeByShortName(shortTypeName), name);
    private PropertyInfo? PropOrNull(Type   type,          string name)
    {
        lock (_propDicLock)
        {
            if (_propDic.TryGetValue((type, name), out PropertyInfo? prop))
            {
                return prop;
            }
            else
            {
                prop = type.GetProperty(name, BindingFlags);
                _propDic.Add((type, name), prop);
                return prop;
            }
        }
    }

    private PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable) => PropOrSomething(TypeByShortName(shortTypeName), name, nullable);
    private PropertyInfo? PropOrSomething(Type   type,          string name, bool nullable)
    {
        return nullable ? PropOrNull(type, name) : PropOrThrow(type, name);
    }
    
    // Helpers

    private static bool GetMatchCase(BindingFlags bindingFlags) => !bindingFlags.HasFlag(BindingFlags.IgnoreCase);
    private Type TypeByShortName(string shortTypeName) => _reflectionCacheLegacy.GetTypeByShortName(shortTypeName);
}