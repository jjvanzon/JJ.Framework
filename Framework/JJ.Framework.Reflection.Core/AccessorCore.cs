

using System.Diagnostics;

namespace JJ.Framework.Reflection.Core;

public class AccessorCore
{
    private static readonly ReflectionCacheLegacy _reflectionCache = new();
    
    private readonly object? _object;
    private readonly ICollection<Type> _types;

    // Constructors
    
    public AccessorCore(object obj)
    {
        _object = obj ?? throw new NullException(() => obj);
        _types = obj.GetType().GetTypesInHierarchy();
    }
    
    public AccessorCore(Type type, params object[] constructArgs)
    {
        if (type == null) throw new NullException(() => type);
        _types = type.GetTypesInHierarchy();
        _object = TryCreateObject(type, constructArgs);
    }
    
    public AccessorCore(string shortTypeName, params object[] constructArgs)
    {
        Type type = _reflectionCache.GetTypeByShortName(shortTypeName);
        _types = type.GetTypesInHierarchy();
        _object = TryCreateObject(type, constructArgs);
    }
    
    private object? TryCreateObject(Type type, object[] constructArgs)
    {
        if (constructArgs == null) throw new NullException(() => constructArgs);
        var constructorTypes = TypesFromObjects(constructArgs);
        ConstructorInfo? constructor = type.GetConstructor(constructorTypes);
        return constructor?.Invoke(constructArgs);
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
            if (property != null) return property.GetValue(_object, null);
            var field = _reflectionCache.TryGetField(type, name);
            if (field != null) return field.GetValue(_object);
        }
        
        throw new Exception($"Property or field '{name}' not found.");
    }
    
    /// <inheritdoc cref="_nameexpression" />
    public void Set<T>  (Expression<Func<T>> nameLambda, T value)  => SetCore(GetName(nameLambda), value);
    public void Set<T>  (T       value, [Caller] string name = "") => SetCore(name, value);
    public void Set     (object? value, [Caller] string name = "") => SetCore(name, value);
    public void Set<T>  (string  name,  T       value)             => SetCore(name, value);
    public void Set     (string  name,  object? value)             => SetCore(name, value);
    private void SetCore(string  name,  object? value)
    {
        foreach (Type type in _types)
        {
            var property = _reflectionCache.TryGetProperty(type, name);
            if (property != null) { property.SetValue(_object, value, null); return; }
            var field = _reflectionCache.TryGetField(type, name);
            if (field != null) { field.SetValue(_object, value); return; }
        }
        
        throw new Exception($"Property or field '{name}' not found.");
    }
    
    // Methods
    
    // With Lambdas

    /// <inheritdoc cref="_invokemethod" />
    public void Call(Expression<Action> callLambda)
    {
        MethodCallInfo info = GetMethodCallInfo(callLambda);
        
        CallCore(
            info.Name,
            info.Parameters.Select(x => x.Value        ).ToArray(),
            info.Parameters.Select(x => x.ParameterType).ToArray(),
            new StackTrace().GetFrame(2));
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public T Call<T>(Expression<Func<T>> callLambda)
    {
        MethodCallInfo info = GetMethodCallInfo(callLambda);
        
        return (T)CallCore(
            info.Name,
            info.Parameters.Select(x => x.Value        ).ToArray(),
            info.Parameters.Select(x => x.ParameterType).ToArray(),
            new StackTrace().GetFrame(2));
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call(LambdaExpression callLambda)
    {
        MethodCallInfo info = GetMethodCallInfo(callLambda);
        
        return CallCore(
            info.Name, 
            info.Parameters.Select(x => x.Value        ).ToArray(), 
            info.Parameters.Select(x => x.ParameterType).ToArray(),
            new StackTrace().GetFrame(2));
    }
            
    // With params
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call(string name, params object[] parameters) 
        => CallCore(name, parameters, new StackTrace().GetFrame(1));
    
    // With CallerMemberName

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object[] parameters, [Caller] string name = "")
        => CallCore(name, parameters, new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call([Caller] string name = "") 
        => CallCore(name, new StackTrace().GetFrame(1));
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, [Caller] string name = "") 
        => CallCore(name, [ param1 ], new StackTrace().GetFrame(1));
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, [Caller] string name = "")
        => CallCore(name, [ param1, param2 ], new StackTrace().GetFrame(1));
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, object param5, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4, param5 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, object param5, object param6, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4, param5, param6 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8, param9 ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, [Caller] string name = "") 
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8, param9, param10 ], new StackTrace().GetFrame(1));

    // With Type Arguments
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments) 
        => CallCore(name, parameters, parameterTypes, typeArguments, new StackTrace().GetFrame(1));
    
    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9) ], new StackTrace().GetFrame(1));

    /// <inheritdoc cref="_invokemethod" />
    public object Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10) ], new StackTrace().GetFrame(1));
    
    // Helpers

    private object CallCore(
        string name, 
        params ICollection<StackFrame?> stackFrames)
        => GetMethod(name, [], [], [], stackFrames).Invoke(_object, []);

    private object CallCore(
        string name, 
        ICollection<object?> parameters, 
        params ICollection<StackFrame?> stackFrames)
        => GetMethod(name, parameters, [], [], stackFrames).Invoke(_object, parameters.ToArray());

    private object CallCore(
        string name, 
        ICollection<object?> parameters, 
        ICollection<Type?> parameterTypes, 
        params ICollection<StackFrame?> stackFrames)
        => GetMethod(name, parameters, parameterTypes, [], stackFrames).Invoke(_object, parameters.ToArray());
    
    private object CallCore(
        string name, 
        ICollection<object?> parameters, 
        ICollection<Type?> parameterTypes, 
        ICollection<Type> typeArguments, 
        params ICollection<StackFrame?> stackFrames)
        => GetMethod(name, parameters, parameterTypes, typeArguments, stackFrames).Invoke(_object, parameters.ToArray());
        
    private MethodInfo GetMethod(
        string name, 
        ICollection<object?> parameters, 
        ICollection<Type?> parameterTypes, 
        ICollection<Type> typeArguments,
        ICollection<StackFrame?> stackFrames)
    {
        foreach (StackFrame? stackFrame in stackFrames)
        {
            if (stackFrame == null) continue;
            var stackFrameParameterTypes = stackFrame.GetMethod().GetParameters().Select(x => x.ParameterType).ToArray();
            foreach (Type type in _types)
            {
                MethodInfo? method = _reflectionCache.TryGetMethod(type, name, stackFrameParameterTypes.ToArray(), typeArguments.ToArray());
                if (method != null) return method;
            }
        }
        
        { 
            var complementedParameterTypes = ComplementParameterTypes(parameters, parameterTypes);
            foreach (Type type in _types)
            {
                MethodInfo? method = _reflectionCache.TryGetMethod(type, name, complementedParameterTypes.ToArray(), typeArguments.ToArray());
                if (method != null) return method;
            }
        }
        
        throw new Exception($"Method '{name}' not found.");
    }
    
    /// <inheritdoc cref="_complementparametertypes" />
    private Type[] ComplementParameterTypes(ICollection<object?> parameters, ICollection<Type?> parameterTypes)
    {
        if (parameterTypes == null) throw new ArgumentNullException(nameof(parameters));
        if (parameters == null) throw new ArgumentNullException(nameof(parameters));
        if (parameterTypes.Count > parameters.Count) throw new ArgumentException("More parameterTypes than parameters.");
        Type?[] parameterTypesArray = parameterTypes.ToArray();
        Resize(ref parameterTypesArray, parameters.Count); // Lenience for missing parameterTypes array elements.
        Type[] parameterTypesFromObjects = TypesFromObjects(parameters);
        Type[] resolvedParameterTypes = parameterTypes.Zip(parameterTypesFromObjects, (x, y) => x ?? y).ToArray();
        return resolvedParameterTypes;
    }
}
