// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

using static System.Reflection.BindingFlags;

namespace JJ.Framework.Reflection.Core;

public class Reflector
{    
    public override string ToString() => DebuggerDisplay(this);

    private readonly ReflectionCacheLegacy _cache;
    public BindingFlags BindingFlags { get; }
    public bool MatchCase { get; }

    // Initialization

    public Reflector(                                                      ) : this(BindingFlagsAll, false) { }
    public Reflector(BindingFlags  bindingFlags                            ) : this(bindingFlags,   !bindingFlags.HasFlag(IgnoreCase)) { }
    public Reflector(MatchCaseFlag matchcase                               ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflector(bool          matchcase                               ) : this(BindingFlagsAll, Has(matchcase)) { }
    public Reflector(MatchCaseFlag matchcase,    BindingFlags  bindingFlags) : this(bindingFlags,    Has(matchcase)) { }
    public Reflector(bool          matchcase,    BindingFlags  bindingFlags) : this(bindingFlags,    Has(matchcase)) { }
    public Reflector(BindingFlags  bindingFlags, MatchCaseFlag matchcase   ) : this(bindingFlags,    Has(matchcase)) { }
    public Reflector(BindingFlags  bindingFlags, bool          matchcase   )
    {
        bindingFlags = matchcase ? bindingFlags.ClearFlag(IgnoreCase) : bindingFlags.SetFlag(IgnoreCase);
        BindingFlags = bindingFlags;
        MatchCase = matchcase;
        _cache = new ReflectionCacheLegacy(bindingFlags);
    }

    // Prop

    private readonly Dictionary<(Type, string), PropertyInfo?> _propDic = new();
    private readonly Lock _propDicLock = new();

    public PropertyInfo  Prop<T>(                   [Caller] string name = ""                                ) => PropOrThrow    (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo  Prop(Type type,            [Caller] string name = ""                                ) => PropOrThrow    (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo  Prop(string shortTypeName, [Caller] string name = ""                                ) => PropOrThrow    (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(                            string name,           NullableFlag nullable    ) => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     string name,           NullableFlag nullable    ) => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          string name,           NullableFlag nullable    ) => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(                            string name,           bool         nullable    ) => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     string name,           bool         nullable    ) => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          string name,           bool         nullable    ) => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(                            NullableFlag nullable, [Caller] string name = "") => PropOrNull     (typeof(T),     name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     NullableFlag nullable, [Caller] string name = "") => PropOrNull     (type,          name,           BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          NullableFlag nullable, [Caller] string name = "") => PropOrNull     (shortTypeName, name,           BindingFlags, _propDic, _propDicLock, _cache);
    public PropertyInfo? Prop<T>(                            bool         nullable, [Caller] string name = "") => PropOrSomething(typeof(T),     name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(Type type,                     bool         nullable, [Caller] string name = "") => PropOrSomething(type,          name, nullable, BindingFlags, _propDic, _propDicLock        );
    public PropertyInfo? Prop(string shortTypeName,          bool         nullable, [Caller] string name = "") => PropOrSomething(shortTypeName, name, nullable, BindingFlags, _propDic, _propDicLock, _cache);
}