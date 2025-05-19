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

    public  PropertyInfo  Prop    <T>(                             [Caller] string name = "") => PropCore(typeof(T), name, false)!;
    public  PropertyInfo  Prop    (Type type,                      [Caller] string name = "") => PropCore(type,      name, false)!;
    public  PropertyInfo? Prop    <T>(        NoThrowFlag nothrow, [Caller] string name = "") => PropCore(typeof(T), name, Has(nothrow));
    public  PropertyInfo? Prop    (Type type, NoThrowFlag nothrow, [Caller] string name = "") => PropCore(type,      name, Has(nothrow));
    public  PropertyInfo? Prop    <T>(        bool        nothrow, [Caller] string name = "") => PropCore(typeof(T), name, Has(nothrow));
    public  PropertyInfo? Prop    (Type type, bool        nothrow, [Caller] string name = "") => PropCore(type,      name, Has(nothrow));
    public  PropertyInfo? Prop    <T>(        string name,         NoThrowFlag nothrow      ) => PropCore(typeof(T), name, Has(nothrow));
    public  PropertyInfo? Prop    (Type type, string name,         NoThrowFlag nothrow      ) => PropCore(type,      name, Has(nothrow));
    public  PropertyInfo? Prop    <T>(        string name,         bool        nothrow      ) => PropCore(typeof(T), name, Has(nothrow));
    public  PropertyInfo? Prop    (Type type, string name,         bool        nothrow      ) => PropCore(type,      name, Has(nothrow));
    private PropertyInfo? PropCore(Type type, string name,         bool        nothrow      )
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

        if (prop == null && !nothrow)
        {
            throw new Exception($"Property '{name}' not found in {type.Name}.");
        }
        
        return prop;
    }
}