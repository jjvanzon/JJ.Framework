// ReSharper disable IntroduceOptionalParameters.Global


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

    public  PropertyInfo  Prop    <T>(                               [Caller] string name = "") => PropCore(typeof(T), name, false)!;
    public  PropertyInfo  Prop    (Type type,                        [Caller] string name = "") => PropCore(type,      name, false)!;
    public  PropertyInfo? Prop    <T>(        NullableFlag nullable, [Caller] string name = "") => PropCore(typeof(T), name, Has(nullable));
    public  PropertyInfo? Prop    (Type type, NullableFlag nullable, [Caller] string name = "") => PropCore(type,      name, Has(nullable));
    public  PropertyInfo? Prop    <T>(        bool         nullable, [Caller] string name = "") => PropCore(typeof(T), name, Has(nullable));
    public  PropertyInfo? Prop    (Type type, bool         nullable, [Caller] string name = "") => PropCore(type,      name, Has(nullable));
    public  PropertyInfo? Prop    <T>(        string name,            NullableFlag nullable   ) => PropCore(typeof(T), name, Has(nullable));
    public  PropertyInfo? Prop    (Type type, string name,            NullableFlag nullable   ) => PropCore(type,      name, Has(nullable));
    public  PropertyInfo? Prop    <T>(        string name,            bool        nullable    ) => PropCore(typeof(T), name, Has(nullable));
    public  PropertyInfo? Prop    (Type type, string name,            bool        nullable    ) => PropCore(type,      name, Has(nullable));
    private PropertyInfo? PropCore(Type type, string name,            bool        nullable    )
    {
        PropertyInfo? prop;
        
        lock (_propDicLock)
        {
            if (!_propDic.TryGetValue((type, name), out prop))
            {
                prop = type.GetProperty(name, BindingFlags);
                _propDic.Add((type, name), prop);
            }
        }

        if (prop == null && !nullable)
        {
            throw new Exception($"Property '{name}' not found in {type.Name}.");
        }
        
        return prop;
    }
}