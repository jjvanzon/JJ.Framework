// ReSharper disable ChangeFieldTypeToSystemThreadingLock
namespace JJ.Framework.Reflection.Core;

public class ReflectionCacheCore(BindingFlags bindingFlags = BindingFlagsAll)
{
    private readonly Dictionary<(Type, string), PropertyInfo> _propDic = new();

    #if NET9_0_OR_GREATER
        private readonly Lock _propDicLock = new ();
    #else
        private readonly object _propDicLock = new ();
    #endif
    
    public PropertyInfo Prop<T>([Caller] string name = "")
        => PropCoreOrThrow(typeof(T), name);

    public PropertyInfo Prop(Type type, [Caller] string name = "") 
        => PropCoreOrThrow(type, name)!;
    
    public PropertyInfo? Prop<T>(ReflectionFlagsCore options, [Caller] string name = "")
        => PropCore(typeof(T), name, options);
    
    public PropertyInfo? Prop(Type type, ReflectionFlagsCore options, [Caller] string name = "")
        => PropCore(type, name, options);
    
    private PropertyInfo? PropCore(Type type, string name, ReflectionFlagsCore options)
    {
        if (options.HasFlag(throws))
        {
            return PropCoreOrThrow(type, name);
        }
        else
        {
            return PropCore(type, name);
        }
    }

    private PropertyInfo PropCoreOrThrow(Type type, string name)
    {    
        PropertyInfo? prop = PropCore(type, name);
        if (prop == null)
        {
            throw new Exception($"Property '{name}' not found on type '{type.Name}'.");
        }
        return prop;
    }
    
    private PropertyInfo? PropCore(Type type, string name)
    {
        lock (_propDicLock)
        {
            if (!_propDic.TryGetValue((type, name), out PropertyInfo? prop))
            {
                prop = type.GetProperty(name, bindingFlags);
                _propDic.Add((type, name), prop);
            }
            return prop;
        }
    }
}