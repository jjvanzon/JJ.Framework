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
    
    public PropertyInfo  Prop<T>(                                     [Caller] string name = "") => PropCore<T>(   name, throws)!;
    public PropertyInfo  Prop(Type type,                              [Caller] string name = "") => PropCore(type, name, throws)!;
    public PropertyInfo? Prop<T>(        ReflectionFlagsCore options, [Caller] string name = "") => PropCore<T>(   name, options);
    public PropertyInfo? Prop(Type type, ReflectionFlagsCore options, [Caller] string name = "") => PropCore(type, name, options);
    
    private PropertyInfo? PropCore<T>(string name, ReflectionFlagsCore options) => PropCore(typeof(T), name, options);
    private PropertyInfo? PropCore(Type type, string name, ReflectionFlagsCore options)
    {
        lock (_propDicLock)
        {
            if (!_propDic.TryGetValue((type, name), out PropertyInfo? prop))
            {
                prop = type.GetProperty(name, bindingFlags);
                _propDic.Add((type, name), prop);
            }
            
            if (prop == null && options.HasFlag(throws))
            {
                throw new Exception($"Property '{name}' not found on type '{type.Name}'.");
            }
            
            return prop;
        }
    }
}