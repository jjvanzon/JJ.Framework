// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.Reflection.Core;

public partial class Reflector
{    
    public override string ToString() => Descriptor(this);

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
}
