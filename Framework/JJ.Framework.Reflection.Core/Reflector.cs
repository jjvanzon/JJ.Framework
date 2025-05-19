namespace JJ.Framework.Reflection.Core;

public class Reflector(BindingFlags bindingFlags = BindingFlagsAll)
{
    // Property
    
    private readonly Dictionary<(Type, string), PropertyInfo?> _propDic = new();
    private readonly Lock _propDicLock = new ();
    
    public  PropertyInfo  Prop    <T>(                            [Caller] string name = "") => PropCore(typeof(T), name, throws)!;
    public  PropertyInfo  Prop    (Type type,                     [Caller] string name = "") => PropCore(type,      name, throws)!;
    public  PropertyInfo? Prop    <T>(        ReflectFlags flags, [Caller] string name = "") => PropCore(typeof(T), name, flags);
    public  PropertyInfo? Prop    (Type type, ReflectFlags flags, [Caller] string name = "") => PropCore(type,      name, flags);
    public  PropertyInfo? Prop    <T>(        string name,        ReflectFlags flags       ) => PropCore(typeof(T), name, flags);
    public  PropertyInfo? Prop    (Type type, string name,        ReflectFlags flags       ) => PropCore(type,      name, flags);
    private PropertyInfo? PropCore(Type type, string name,        ReflectFlags flags       )
    {
        lock (_propDicLock)
        {
            if (!_propDic.TryGetValue((type, name), out PropertyInfo? prop))
            {
                prop = type.GetProperty(name, bindingFlags);
                _propDic.Add((type, name), prop);
            }

            if (Has(flags, matchcase))
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
    }
 
    private bool ShouldThrow(ReflectFlags flags)
    {
        if (Has(flags, throws)) return true;
        if (Has(flags, nothrow)) return false;
        return true;
    }

    private bool Has(ReflectFlags flags, ReflectFlags flag) => (flags & flag) != 0;
}