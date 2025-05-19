// ReSharper disable IntroduceOptionalParameters.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Reflection.Core;

public class Reflector
{
    public Reflector(                                                  ) : this(BindingFlagsAll, false) { }
    public Reflector(BindingFlags bindingFlags                         ) : this(bindingFlags   , GetMatchCase(bindingFlags)) { }
    public Reflector(MatchCaseFlag matchcase                           ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflector(bool matchcase                                    ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflector(BindingFlags bindingFlags, MatchCaseFlag matchcase) : this(bindingFlags   , Has(matchcase)) { }
    public Reflector(BindingFlags bindingFlags, bool matchcase         )
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
    }

    private static bool GetMatchCase(BindingFlags bindingFlags) => !bindingFlags.HasFlag(BindingFlags.IgnoreCase);

    public BindingFlags BindingFlags { get; }
    public bool MatchCase { get; }

    public override string ToString() => DebuggerDisplay(this);

    // Property

    private readonly Dictionary<(Type, string), PropertyInfo?> _propDic = new();
    private readonly Lock _propDicLock = new();
    
    // TODO: By (short) type name

    public  PropertyInfo  Prop<T>(        [Caller] string name = ""                                ) => PropOrThrow    (typeof(T), name);
    public  PropertyInfo  Prop(Type type, [Caller] string name = ""                                ) => PropOrThrow    (type,      name);
    public  PropertyInfo? Prop<T>(                 string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T), name);
    public  PropertyInfo? Prop(Type type,          string name,           NullableFlag nullable    ) => PropOrNull     (type,      name);
    public  PropertyInfo? Prop<T>(                 string name,           bool         nullable    ) => PropOrSomething(typeof(T), name, nullable);
    public  PropertyInfo? Prop(Type type,          string name,           bool         nullable    ) => PropOrSomething(type,      name, nullable);
    public  PropertyInfo? Prop<T>(                 NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T), name);
    public  PropertyInfo? Prop(Type type,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,      name);
    public  PropertyInfo? Prop<T>(                 bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T), name, nullable);
    public  PropertyInfo? Prop(Type type,          bool         nullable, [Caller] string name = "") => PropOrSomething(type,      name, nullable);
    
    private PropertyInfo PropOrThrow(Type type, string name)
    {
        PropertyInfo? prop = PropOrNull(type, name);
        
        if (prop == null)
        {
            throw new Exception($"Property {name} not found in {type.Name}.");
        }
        
        return prop;
    }

    private PropertyInfo? PropOrNull(Type type, string name)
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

    private PropertyInfo? PropOrSomething(Type type, string name, bool nullable)
    {
        return nullable ? PropOrNull(type, name) : PropOrThrow(type, name);
    }
}