using System.Diagnostics; // For StackTrace

namespace JJ.Framework.Reflection.Core;

public class AccessorCore
{
    private static readonly ReflectionCacheLegacy _reflectionCache = new();

    public object? Obj { get; }
    private readonly ICollection<Type> _types;

    // Constructors

    public AccessorCore(object obj)
    {
        Obj = obj ?? throw new NullException(() => obj);
        _types = obj.GetType().GetTypesInHierarchy();
    }

    public AccessorCore(Type type, params object[] constructArgs)
    {
        if (type == null) throw new NullException(() => type);
        _types = type.GetTypesInHierarchy();
        Obj = TryCreateObject(type, constructArgs);
    }

    public AccessorCore(string shortTypeName, params object[] constructArgs)
    {
        Type type = _reflectionCache.GetTypeByShortName(shortTypeName);
        _types = type.GetTypesInHierarchy();
        Obj = TryCreateObject(type, constructArgs);
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
    public T?      Get<T>(Expression<Func<T>> nameLambda) => (T?)Get(GetName(nameLambda));
    public T?      Get<T>(    [Caller] string name = "" ) => (T?)Get(name);
    public object? Get   (    [Caller] string name = "" )
    {
        foreach (Type type in _types)
        {
            var property = _reflectionCache.TryGetProperty(type, name);
            if (property != null) return property.GetValue(Obj, null);
            var field = _reflectionCache.TryGetField(type, name);
            if (field != null) return field.GetValue(Obj);
        }

        throw new Exception($"Property or field '{name}' not found.");
    }

    [OverloadPrio(1)]
    public void Set<T>(string name, T value) => SetCore(name, value);
    public void Set<T>(T value, [Caller] string name = "") => SetCore(name, value);
    /// <inheritdoc cref="_nameexpression" />
    public void Set<T>(Expression<Func<T>> nameLambda, T value) => SetCore(GetName(nameLambda), value);
    private void SetCore(string name, object? value)
    {
        foreach (Type type in _types)
        {
            var property = _reflectionCache.TryGetProperty(type, name);
            if (property != null) { property.SetValue(Obj, value, null); return; }
            var field = _reflectionCache.TryGetField(type, name);
            if (field != null) { field.SetValue(Obj, value); return; }
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
    [OverloadPrio(1)] 
    public object? Call(string name, params object?[] args)
        => CallCore(name, args);

    // With CallerMemberName

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object?[] args, [Caller] string name = "")
        => CallCore(name, args);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call([Caller] string name = "")
        => CallCore(name);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, [Caller] string name = "")
        => CallCore(name, [ arg1 ]);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2 ]);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3 ]);

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9, object? arg10, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 ]);

    // With Type Args

    /// <inheritdoc cref="_invokemethod" />
    public object? Call(string name, object?[] args, Type?[] argTypes, Type[] typeArgs)
        => CallCore(name, args, argTypes, typeArgs);
    
    // TODO: CallerMemberName variants.
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs:[ typeof(T1), typeof(T2) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4, T5>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4, T5, T6>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4, T5, T6, T7>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4, T5, T6, T7, T8>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) ]);
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) ]);

    // With Collections

    [OverloadPrio(1)] 
    public object? Call(
        string name,
        ICollection<object?> args)
        => CallCore(name, args);

    public object? Call(
        ICollection<object?> args,
        [Caller] string name = "")
        => CallCore(name, args);

    [OverloadPrio(1)] 
    public object? Call(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes)
        => CallCore(name, args, argTypes);

    public object? Call(
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        [Caller] string name = "")
        => CallCore(name, args, argTypes);

    [OverloadPrio(1)] 
    public object? Call(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs)
        => CallCore(name, args, argTypes, typeArgs);

    public object? Call(
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs,
        [Caller] string name = "")
        => CallCore(name, args, argTypes, typeArgs);

    // TODO: Indexers

    // Helpers
    
    private object? CallCore(
        string name)
        => ResolveMethod(name, [], [], []).Invoke(Obj, []);
    
    private object? CallCore(
        string name,
        ICollection<object?> args)
        => ResolveMethod(name, args, [], []).Invoke(Obj, args.ToArray());

    private object? CallCore(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes)
        => ResolveMethod(name, args, argTypes, []).Invoke(Obj, args.ToArray());

    private object? CallCore(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs)
        => ResolveMethod(name, args, argTypes, typeArgs).Invoke(Obj, args.ToArray());

    private MethodInfo ResolveMethod(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs)
    {
        var complementedArgTypes = ComplementArgTypes(args, argTypes);
        foreach (Type type in _types)
        {
            MethodInfo? method = _reflectionCache.TryGetMethod(type, name, complementedArgTypes.ToArray(), typeArgs.ToArray());
            if (method != null) return method;
        }

        // Try resolve with stack trace info.
        StackTrace stackTrace = new();
        ICollection<StackFrame?> stackFrames = [ stackTrace.GetFrame(2), stackTrace.GetFrame(3) ];
        foreach (StackFrame? stackFrame in stackFrames)
        {
            if (stackFrame == null) continue;
            var stackFrameArgTypes = stackFrame.GetMethod()?.GetParameters().Select(x => x.ParameterType).ToArray() ?? [ ];
            foreach (Type type in _types)
            {
                MethodInfo? method = _reflectionCache.TryGetMethod(type, name, stackFrameArgTypes.ToArray(), typeArgs.ToArray());
                if (method != null) return method;
            }
        }

        throw new Exception($"Method '{name}' not found.");
    }

    /// <inheritdoc cref="_complementparametertypes" />
    private Type[] ComplementArgTypes(ICollection<object?> args, ICollection<Type?> argTypes)
    {
        if (argTypes.Count > args.Count) throw new Exception("More argTypes than args.");
        Type?[] argTypesArray = argTypes.ToArray();
        Resize(ref argTypesArray, args.Count); // Lenience for missing argTypes array elements.
        Type[] argTypesFromObjects = TypesFromObjects(args);
        Type[] resolvedArgTypes = argTypesArray.Zip(argTypesFromObjects, (x, y) => x ?? y).ToArray();
        return resolvedArgTypes;
    }
}