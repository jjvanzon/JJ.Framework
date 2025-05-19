// ReSharper disable IntroduceOptionalParameters.Global

using static JJ.Framework.Reflection.Core.MatchCaseFlag;

namespace JJ.Framework.Reflection.Core;

public class Reflector
{
    public Reflector(                                                  ) : this(BindingFlagsAll, GetMatchCase(            )) { }
    public Reflector(BindingFlags bindingFlags                         ) : this(bindingFlags   , GetMatchCase(bindingFlags)) { }
    public Reflector(MatchCaseFlag matchCase                           ) : this(BindingFlagsAll, GetMatchCase(matchCase   )) { }
    public Reflector(bool matchCase                                    ) : this(BindingFlagsAll, GetMatchCase(matchCase   )) { }
    public Reflector(BindingFlags bindingFlags, MatchCaseFlag matchCase) : this(bindingFlags   , GetMatchCase(matchCase   )) { }
    public Reflector(BindingFlags bindingFlags, bool matchCase         )
    {
        if (matchCase)
        {
            bindingFlags &= ~BindingFlags.IgnoreCase;
        }
        else
        {
            bindingFlags |= BindingFlags.IgnoreCase;
        }
        
        _bindingFlags = bindingFlags;
    }

    private static bool GetMatchCase() => false;
    private static bool GetMatchCase(bool matchCase) => matchCase;
    private static bool GetMatchCase(MatchCaseFlag matchCase) => matchCase == MatchCaseFlag.matchCase;
    private static bool GetMatchCase(BindingFlags bindingFlags) => bindingFlags.HasFlag(BindingFlags.IgnoreCase);

    private readonly BindingFlags _bindingFlags;

    // Property

    private readonly Dictionary<(Type, string), PropertyInfo?> _propDic = new();
    private readonly Lock _propDicLock = new();
    
    // TODO: By (short) type name

    public  PropertyInfo  Prop    <T>(                            [Caller] string name = "") => PropCore(typeof(T), name, throws)!;
    public  PropertyInfo  Prop    (Type type,                     [Caller] string name = "") => PropCore(type,      name, throws)!;
    public  PropertyInfo? Prop    <T>(        ReflectFlags flags, [Caller] string name = "") => PropCore(typeof(T), name, flags);
    public  PropertyInfo? Prop    (Type type, ReflectFlags flags, [Caller] string name = "") => PropCore(type,      name, flags);
    public  PropertyInfo? Prop    <T>(        string name,        ReflectFlags flags       ) => PropCore(typeof(T), name, flags);
    public  PropertyInfo? Prop    (Type type, string name,        ReflectFlags flags       ) => PropCore(type,      name, flags);
    private PropertyInfo? PropCore(Type type, string name,        ReflectFlags flags       )
    {
        PropertyInfo? prop;
        
        lock (_propDicLock)
        {
            if (!_propDic.TryGetValue((type, name), out prop))
            {
                prop = type.GetProperty(name, _bindingFlags);
                _propDic.Add((type, name), prop);
            }
        }

        // TODO: Too much logic. Some flags should be fixed upon construction.
        if (HasFlag(flags, ReflectFlags.matchcase))
        {
            if (!string.Equals(prop?.Name, name, Ordinal))
            {
                prop = null;
            }
        }

        if (prop == null && ShouldThrow(flags))
        {
            throw new Exception($"Property '{name}' not found in type '{type.Name}'.");
        }
        
        return prop;
    }
 
    private bool ShouldThrow(ReflectFlags flags)
    {
        if (HasFlag(flags, throws)) return true;
        if (HasFlag(flags, nothrow)) return false;
        return true;
    }

    private bool HasFlag(ReflectFlags flags, ReflectFlags flag) => (flags & flag) != 0;
}