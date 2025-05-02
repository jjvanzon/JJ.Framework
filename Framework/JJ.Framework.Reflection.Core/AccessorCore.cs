
namespace JJ.Framework.Reflection.Core;

public class AccessorCore
{
    private static readonly ReflectionCacheLegacy _reflectionCache = new();
    
    private readonly object?                     _object;
    private readonly ICollection<Type>           _types;
    //private readonly ICollection<AccessorLegacy> _accessors;

    // Constructors
    
    public AccessorCore(object obj)
    {
        _object = obj ?? throw new NullException(() => obj);
        _types = obj.GetType().GetTypesInHierarchy();
        //_accessors = _types.Select(x => new AccessorLegacy(obj, x)).ToArray();
    }
    
    public AccessorCore(Type type)
    {
        if (type == null) throw new NullException(() => type);
        _types = type.GetTypesInHierarchy();
        //_accessors = _types.Select(x => new AccessorLegacy(x)).ToArray();
    }
    
    public AccessorCore(string shortTypeName, params object[] args)
    {
        if (args == null) throw new NullException(() => args);
        
        Type type = _reflectionCache.GetTypeByShortName(shortTypeName);
        _types = type.GetTypesInHierarchy();

        ConstructorInfo? constructor = type.GetConstructor(args.Select(x => x.GetType()).ToArray());
        
        if (constructor != null)
        {
            _object = constructor.Invoke(args);
            //_accessors = _types.Select(x => new AccessorLegacy(_object, x)).ToArray();
        }
        else
        {
            //_accessors = _types.Select(x => new AccessorLegacy(x)).ToArray();
        }
    }
    
    // Fields and Properties

    /// <inheritdoc cref="_nameexpression" />
    public T?      Get<T>(Expression<Func<T>> nameLambda) => Get<T>(GetName(nameLambda));
    public T?      Get<T>([Caller] string name = "") => (T?)Get(name);
    public object? Get   ([Caller] string name = "")
    {
        foreach (Type type in _types)
        {
            var property = _reflectionCache.TryGetProperty(type, name);
            if (property != null)
            {
                return property.GetValue(_object, null);
            }
            
            var field = _reflectionCache.TryGetField(type, name);
            if (field != null)
            {
                return field.GetValue(_object);
            }
        }
        
        throw new Exception($"Property or field '{name}' not found.");
    }
    
    /// <inheritdoc cref="_nameexpression" />
    public void Set<T>  (Expression<Func<T>> nameLambda, T value)  => SetBase(GetName(nameLambda), value);
    public void Set<T>  (T       value, [Caller] string name = "") => SetBase(name, value);
    public void Set     (object? value, [Caller] string name = "") => SetBase(name, value);
    public void Set<T>  (string  name,  T       value)             => SetBase(name, value);
    public void Set     (string  name,  object? value)             => SetBase(name, value);
    private void SetBase(string  name,  object? value)
    {
        foreach (Type type in _types)
        {
            var property = _reflectionCache.TryGetProperty(type, name);
            if (property != null)
            {
                property.SetValue(_object, value, null);
                return;
            }
            
            var field = _reflectionCache.TryGetField(type, name);
            if (field != null)
            {
                field.SetValue(_object, value);
                return;
            }
        }
        
        throw new Exception($"Property or field '{name}' not found.");
    }
}
