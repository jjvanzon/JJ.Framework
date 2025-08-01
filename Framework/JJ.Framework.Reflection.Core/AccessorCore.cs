﻿
namespace JJ.Framework.Reflection.Core;

public partial class AccessorCore
{
    private static readonly ReflectionCacheLegacy _reflectionCacheLegacy = new();

    public object? Obj { get; }
    [Dyn(Intf)] private readonly Type _type;
    private readonly ICollection<Type> _typesInHierarchy;

    // Constructors

    [NoTrim(ObjectGetType)]
    public AccessorCore(object obj)
    {
        Obj = obj ?? throw new NullException(() => obj);
        _type = obj.GetType();
        _typesInHierarchy = _type.GetTypesInHierarchy();
    }

    public AccessorCore([Dyn(Intf | PublicCtors)] Type type, params ICollection<object?> constructArgs)
    {
        _type = type ?? throw new NullException(() => type);
        _typesInHierarchy = type.GetTypesInHierarchy();
        Obj = NewOrNull(type, constructArgs);
    }

    [NoTrim(GetTypes)]
    public AccessorCore(string shortTypeName, params ICollection<object?> constructArgs)
    {
        _type = _reflectionCacheLegacy.GetTypeByShortName(shortTypeName);
        _typesInHierarchy = _type.GetTypesInHierarchy();
        Obj = NewOrNull(_type, constructArgs);
    }
    
    private object? NewOrNull([Dyn(PublicCtors)] Type type, ICollection<object?> constructArgs)
    {
        if (constructArgs == null) throw new NullException(() => constructArgs);
        var constructorTypes = TypesFromObjects(constructArgs);
        ConstructorInfo? constructor = type.GetConstructor(constructorTypes);
        return constructor?.Invoke(constructArgs.ToArray());
    }

    // Fields and Properties

    /// <inheritdoc cref="_nameexpression" />
    [NoTrim(Bases)]
    public T? Get<T>(Expression<Func<T>> nameLambda) => (T?)Get(GetName(nameLambda));
    
    [NoTrim(Bases)]
    public T? Get<T>([Caller] string name = "") => (T?)Get(name);
    
    [NoTrim(Bases)]
    public object? Get([Caller] string name = "")
    {
        var prop = _type.Prop(name, nullable);
        if (prop != null)
        {
            return prop.GetValue(Obj);
        }

        var field = _type.Field(name, nullable);
        if (field != null)
        {
            return field.GetValue(Obj);
        }

        throw new Exception($"Property or field {name} not found in {_type.Name}.");
    }
    
    [Prio(1), NoTrim(Bases)] 
    public void Set<T>(string name, T value) => SetCore(name, value);
    
    [NoTrim(Bases)]
    public void Set<T>(T value, [Caller] string name = "") => SetCore(name, value);
    
    /// <inheritdoc cref="_nameexpression" />
    [NoTrim(Bases)] 
    public void Set<T>(Expression<Func<T>> nameLambda, T value) => SetCore(GetName(nameLambda), value);
    
    [NoTrim(Bases)]
    private void SetCore(string name, object? value)
    {
        var prop = _type.Prop(name, nullable);
        if (prop != null)
        {
            prop.SetValue(Obj, value);
            return;
        }
        
        var field = _type.Field(name, nullable);
        if (field != null)
        {
            field.SetValue(Obj, value);
            return;
        }

        throw new Exception($"Property or field {name} not found in {_type.Name}.");
    }
    
    // Indexers
    
    // With Indexer
    
    public object? this[params ICollection<object?> indices]
    {
    [   NoTrim(Bases)]
        get
        {
            AssertIndices(indices);
            var property = ResolveIndexer(indices, [ ]);
            return property.GetValue(Obj, indices.ToArray());
        }
        [NoTrim(Bases)]
        set
        {
            AssertIndices(indices);
            var property = ResolveIndexer(indices, [ ]);
            property.SetValue(Obj, value, indices.ToArray());
        }
    }
    
    // Indexers With Params
    
    [NoTrim(Bases)]
    public object? Get(params ICollection<object?> indices)
    {
        AssertIndices(indices);
        var property = ResolveIndexer(indices, [ ]);
        return property.GetValue(Obj, indices.ToArray());
    }
    
    [NoTrim(Bases)]
    public void Set(params ICollection<object?> indicesAndValue)
    {
        AssertIndicesAndValue(indicesAndValue);
        
        object?[] indices = indicesAndValue.Take(indicesAndValue.Count - 1).ToArray();
        object? value = indicesAndValue.Last();
        
        var property = ResolveIndexer(indices, [ ]);
        property.SetValue(Obj, value, indices);
    }
    
    // Indexers With Collections
    
    [NoTrim(Bases)]
    public object? Get(ICollection<object?> indices, ICollection<Type?> argTypes)
    {
        AssertIndices(indices);
        var property = ResolveIndexer(indices, argTypes);
        return property.GetValue(Obj, indices.ToArray());
    }

    [NoTrim(Bases)]
    public void Set(ICollection<object?> indices, object? value)
        => Set(indices, value, [ ]);
    
    // TODO: Swap argTypes and value? Support both syntaxes? So with value at the end also supported?
    
    [NoTrim(Bases)]
    public void Set(ICollection<object?> indices, object? value, ICollection<Type?> argTypes)
    {
        AssertIndices(indices);
        if (argTypes == null) throw new ArgumentNullException(nameof(argTypes));
        var property = ResolveIndexer(indices, argTypes);
        property.SetValue(Obj, value, indices.ToArray());
    }
    
    // Indexer Helpers
    
    private static void AssertIndices(ICollection<object?> indices)
    {
        if (indices == null) throw new ArgumentNullException(nameof(indices));
        if (indices.Count < 1) throw new Exception("indices.Count must be at least 1.");
    }
        
    private static void AssertIndicesAndValue(ICollection<object?> indicesAndValue)
    {
        if (indicesAndValue == null) throw new ArgumentNullException(nameof(indicesAndValue));
        if (indicesAndValue.Count < 2) throw new Exception("indicesAndValue.Count must be at least 2");
    }

    // Methods

    // With Lambdas

    /// <inheritdoc cref="_call" />
    #if !NET9_0_OR_GREATER
    [NoTrim(ExpressionsWithArrays)]
    #endif
    public void Call(Expression<Action> callLambda) => Call((LambdaExpression)callLambda);

    /// <inheritdoc cref="_call" />
    #if !NET9_0_OR_GREATER
    [NoTrim(ExpressionsWithArrays)]
    #endif
    public T? Call<T>(Expression<Func<T>> callLambda) => (T?)Call((LambdaExpression)callLambda);
    
    /// <inheritdoc cref="_call" />
    #if !NET9_0_OR_GREATER
    [NoTrim(ExpressionsWithArrays)]
    #endif
    public object? Call(LambdaExpression callLambda)
    {
        MethodCallInfo info = GetMethodCallInfo(callLambda);

        return CallCore(
            info.Name,
            info.Parameters.Select(x => x.Value        ).ToArray(), 
            info.Parameters.Select(x => x.ParameterType).ToArray());
    }

    // With Name + Params

    /// <inheritdoc cref="_call" />
    [Prio(3)] [NoTrim(Bases)] public object? Call([Caller] string name = "")
        => CallCore(name);

    /// <inheritdoc cref="_call" />
    [Prio(3)] [NoTrim(Bases)] public object? Call(
        string name,
        params ICollection<object?> args)
        => CallCore(name, args);

    // With CallerMemberName

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, [Caller] string name = "")
        => CallCore(name, [ arg1 ]);

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2 ]);

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3 ]);

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4 ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5 ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6 ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7 ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9, object? arg10, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 ]);

    // With Collections

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(
        ICollection<object?> args,
        [Caller] string name = "")
        => CallCore(name, args);

    /// <inheritdoc cref="_call" />
    [Prio(1)] 
    [NoTrim(Bases)] 
    public object? Call(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes)
        => CallCore(name, args, argTypes);

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        [Caller] string name = "")
        => CallCore(name, args, argTypes);

    /// <inheritdoc cref="_call" />
    [Prio(1)] 
    [NoTrim(Bases)] 
    public object? Call(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs)
        => CallCore(name, args, argTypes, typeArgs);

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call(
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs,
        [Caller] string name = "")
        => CallCore(name, args, argTypes, typeArgs);
    
    // With Type Args
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs:[ typeof(T1), typeof(T2) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4, T5>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4, T5, T6>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4, T5, T6, T7>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4, T5, T6, T7, T8>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) ]);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)] 
    public object? Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string name, params object?[] args)
        => CallCore(name, args, [], typeArgs: [ typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) ]);

    // Helpers
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)]
    private object? CallCore(
        string name)
        => ResolveMethod(name, [], [], []).Invoke(Obj, []);
    
    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)]
    private object? CallCore(
        string name,
        ICollection<object?> args)
        => ResolveMethod(name, args, [], []).Invoke(Obj, args.ToArray());

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)]
    private object? CallCore(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes)
        => ResolveMethod(name, args, argTypes, []).Invoke(Obj, args.ToArray());

    /// <inheritdoc cref="_call" />
    [NoTrim(Bases)]
    private object? CallCore(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs)
        => ResolveMethod(name, args, argTypes, typeArgs).Invoke(Obj, args.ToArray());

    // Super Magic Resolvers
    
    [NoTrim(Bases)]
    private MethodInfo ResolveMethod(
        string name,
        ICollection<object?> args,
        ICollection<Type?> argTypes,
        ICollection<Type> typeArgs)
    {
        ICollection<Type> complementedArgTypes = ComplementArgTypes(argTypes, args);
        foreach (Type type in _typesInHierarchy)
        {
            MethodInfo? method = _reflectionCacheLegacy.TryGetMethod(type, name, complementedArgTypes.ToArray(), typeArgs.ToArray());
            if (method != null) return method;
        }

        // Try resolve with stack trace info.
        StackTrace stackTrace = new();
        ICollection<StackFrame?> stackFrames =
        [
            stackTrace.GetFrame(4), // Likeliest
            stackTrace.GetFrame(5), // Lenience for delegation structures
            stackTrace.GetFrame(3), // For inlining
            stackTrace.GetFrame(2), // For inlining 
            stackTrace.GetFrame(1)  // For inlining
        ];
        
        foreach (StackFrame? stackFrame in stackFrames)
        {
            if (stackFrame == null) continue;

            MethodBase? stackMethod = stackFrame.GetMethod();

            if (stackMethod == null) continue;

            // Method name must match
            // (Avoids security pitfall: Prevents unintended method from being run.)
            if (!string.Equals(stackMethod.Name, name, OrdinalIgnoreCase))
            {
                continue;
            }

            Type[] argTypesFromStack = stackMethod.GetParameters().Select(x => x.ParameterType).ToArray();
            if (argTypesFromStack.Length != args.Count) continue;

            foreach (Type type in _typesInHierarchy)
            {
                MethodInfo? method = _reflectionCacheLegacy.TryGetMethod(type, name, argTypesFromStack, typeArgs.ToArray());
                if (method != null) return method;
            }
        }

        throw new Exception(
            $"Method '{name}' not found with argument types ({FormatTypes(complementedArgTypes)})" +
            (typeArgs.Any() ? $" and type arguments <{FormatTypes(typeArgs)}>." : "."));
        
    }

    private static string FormatTypes(ICollection<Type> types) 
        => Join(", ", types.Select(x => $"{x.Name}"));
    
    [NoTrim(Bases)]
    private PropertyInfo ResolveIndexer(
        ICollection<object?> indices,
        ICollection<Type?> argTypes)
    {
        var complementedArgTypes = ComplementArgTypes(argTypes, indices).ToArray();
        foreach (Type type in _typesInHierarchy)
        {
            PropertyInfo? indexerProp = _reflectionCacheLegacy.TryGetIndexer(type, complementedArgTypes);
            if (indexerProp != null) return indexerProp;
        }

        // Try resolve with stack trace info.
        StackTrace stackTrace = new();
        ICollection<StackFrame?> stackFrames =
        [
            stackTrace.GetFrame(2), // Likeliest frame.
            stackTrace.GetFrame(3), // Lenience for delegation structures / inlining
            stackTrace.GetFrame(4), // Lenience for delegation structures
            stackTrace.GetFrame(1)  // For inlining
        ];
        foreach (StackFrame? stackFrame in stackFrames)
        {
            if (stackFrame == null) continue;
            
            Type[] argTypesFromStack
                = stackFrame.GetMethod()?
                            .GetParameters()
                            .Select(x => x.ParameterType)
                            .ToArray() ?? [ ];
            
            if (argTypesFromStack.Length != indices.Count) continue; 

            foreach (Type type in _typesInHierarchy)
            {
                PropertyInfo? indexerProp = _reflectionCacheLegacy.TryGetIndexer(type, argTypesFromStack);
                if (indexerProp != null) return indexerProp;
            }
        }

        throw new Exception($"No indexer found with argument types [{FormatTypes(complementedArgTypes)}].");
    }
    
    /// <inheritdoc cref="_complementparametertypes" />
    private ICollection<Type> ComplementArgTypes(ICollection<Type?> argTypes, ICollection<object?> args)
    {
        if (argTypes.Count > args.Count) throw new Exception("More argTypes than args.");
        Type?[] argTypesArr = argTypes.ToArray();
        Resize(ref argTypesArr, args.Count); // Lenience for missing argTypes array elements.
        Type[] argTypesFromObjects = TypesFromObjects(args);
        Type[] resolvedArgTypes = argTypesArr.Zip(argTypesFromObjects, (x, y) => x ?? y).ToArray();
        return resolvedArgTypes;
    }
}