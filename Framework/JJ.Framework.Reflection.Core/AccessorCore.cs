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
            info.Parameters.Select(x => x.ParameterType).ToArray());
    }

    /// <inheritdoc cref="_invokemethod" />
    public T? Call<T>(Expression<Func<T>> callLambda)
    {
        MethodCallInfo info = GetMethodCallInfo(callLambda);

        return (T?)CallCore(
            info.Name,
            info.Parameters.Select(x => x.Value        ).ToArray(),
            info.Parameters.Select(x => x.ParameterType).ToArray());
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(LambdaExpression callLambda)
    {
        MethodCallInfo info = GetMethodCallInfo(callLambda);

        return CallCore(
            info.Name,
            info.Parameters.Select(x => x.Value        ).ToArray(), 
            info.Parameters.Select(x => x.ParameterType).ToArray());
    }

    // With params

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(string name, params object[] parameters)
        => CallCore(name, parameters);

    // With CallerMemberName

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object[] parameters, [Caller] string name = "")
        => CallCore(name, parameters);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call([Caller] string name = "")
        => CallCore(name);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, [Caller] string name = "")
        => CallCore(name, [ param1 ]);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, [Caller] string name = "")
        => CallCore(name, [ param1, param2 ]);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3 ]);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, object param5, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, object param5, object param6, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5, param6 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8, param9 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8, param9, param10 ]);

    // With Type Arguments

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
        => CallCore(name, parameters, parameterTypes, typeArguments);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments:[ typeof(TArg1), typeof(TArg2) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, params object[] parameters)
        => CallCore(name, parameters, [], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10) ]);

    // With Collections

    public object? Call(
        string name,
        ICollection<object?> parameters)
        => CallCore(name, parameters);

    public object? Call(
        ICollection<object?> parameters,
        [Caller] string name = "")
        => CallCore(name, parameters);

    public object? Call(
        string name,
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes)
        => CallCore(name, parameters, parameterTypes);

    public object? Call(
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes,
        [Caller] string name = "")
        => CallCore(name, parameters, parameterTypes);

    public object? Call(
        string name,
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes,
        ICollection<Type> typeArguments)
        => CallCore(name, parameters, parameterTypes, typeArguments);

    public object? Call(
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes,
        ICollection<Type> typeArguments,
        [Caller] string name = "")
        => CallCore(name, parameters, parameterTypes, typeArguments);

    // TODO: Indexers

    // Helpers
    
    private object? CallCore(
        string name)
        => ResolveMethod(name, [], [], []).Invoke(_object, []);
    
    private object? CallCore(
        string name,
        ICollection<object?> parameters)
        => ResolveMethod(name, parameters, [], []).Invoke(_object, parameters.ToArray());

    private object? CallCore(
        string name,
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes)
        => ResolveMethod(name, parameters, parameterTypes, []).Invoke(_object, parameters.ToArray());

    private object? CallCore(
        string name,
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes,
        ICollection<Type> typeArguments)
        => ResolveMethod(name, parameters, parameterTypes, typeArguments).Invoke(_object, parameters.ToArray());

    private MethodInfo ResolveMethod(
        string name,
        ICollection<object?> parameters,
        ICollection<Type?> parameterTypes,
        ICollection<Type> typeArguments)
    {
        var complementedParameterTypes = ComplementParameterTypes(parameters, parameterTypes);
        foreach (Type type in _types)
        {
            MethodInfo? method = _reflectionCache.TryGetMethod(type, name, complementedParameterTypes.ToArray(), typeArguments.ToArray());
            if (method != null) return method;
        }

        // Try resolve with stack trace info.
        StackTrace stackTrace = new();
        ICollection<StackFrame?> stackFrames = [ stackTrace.GetFrame(2), stackTrace.GetFrame(3) ];
        foreach (StackFrame? stackFrame in stackFrames)
        {
            if (stackFrame == null) continue;
            var stackFrameParameterTypes = stackFrame.GetMethod()?.GetParameters().Select(x => x.ParameterType).ToArray() ?? [ ];
            foreach (Type type in _types)
            {
                MethodInfo? method = _reflectionCache.TryGetMethod(type, name, stackFrameParameterTypes.ToArray(), typeArguments.ToArray());
                if (method != null) return method;
            }
        }

        throw new Exception($"Method '{name}' not found.");
    }

    /// <inheritdoc cref="_complementparametertypes" />
    private Type[] ComplementParameterTypes(ICollection<object?> parameters, ICollection<Type?> parameterTypes)
    {
        if (parameterTypes.Count > parameters.Count) throw new ArgumentException("More parameterTypes than parameters.");
        Type?[] parameterTypesArray = parameterTypes.ToArray();
        Resize(ref parameterTypesArray, parameters.Count); // Lenience for missing parameterTypes array elements.
        Type[] parameterTypesFromObjects = TypesFromObjects(parameters);
        Type[] resolvedParameterTypes = parameterTypesArray.Zip(parameterTypesFromObjects, (x, y) => x ?? y).ToArray();
        return resolvedParameterTypes;
    }
}