using System.Diagnostics; // For StackTrace
using static System.String; 

namespace JJ.Framework.Reflection.Core;

public class AccessorCore
{
    private static readonly ReflectionCacheLegacy _reflectionCacheLegacy = new();

    public object? Obj { get; }
    private readonly ICollection<Type> _typesInHierarchy;

    // Constructors

    public AccessorCore(object obj)
    {
        Obj = obj ?? throw new NullException(() => obj);
        _typesInHierarchy = obj.GetType().GetTypesInHierarchy();
    }

    public AccessorCore(Type type, params ICollection<object?> constructArgs)
    {
        if (type == null) throw new NullException(() => type);
        _typesInHierarchy = type.GetTypesInHierarchy();
        Obj = TryCreateObject(type, constructArgs);
    }

    public AccessorCore(string shortTypeName, params ICollection<object?> constructArgs)
    {
        Type type = _reflectionCacheLegacy.GetTypeByShortName(shortTypeName);
        _typesInHierarchy = type.GetTypesInHierarchy();
        Obj = TryCreateObject(type, constructArgs);
    }
    
    private object? TryCreateObject(Type type, ICollection<object?> constructArgs)
    {
        if (constructArgs == null) throw new NullException(() => constructArgs);
        var constructorTypes = TypesFromObjects(constructArgs);
        ConstructorInfo? constructor = type.GetConstructor(constructorTypes);
        return constructor?.Invoke(constructArgs.ToArray());
    }

    // Fields and Properties

    /// <inheritdoc cref="_nameexpression" />
    public T? Get<T>(Expression<Func<T>> nameLambda) => (T?)Get(GetName(nameLambda));
    
    public T? Get<T>([Caller] string name = "") => (T?)Get(name);
    
    public object? Get([Caller] string name = "")
    {
        foreach (Type type in _typesInHierarchy)
        {
            var property = _reflectionCacheLegacy.TryGetProperty(type, name);
            if (property != null) return property.GetValue(Obj, null);
            var field = _reflectionCacheLegacy.TryGetField(type, name);
            if (field != null) return field.GetValue(Obj);
        }

        throw new Exception($"Property or field '{name}' not found.");
    }
    
    [OverloadPriority(1)]
    public void Set<T>(string name, T value) => SetCore(name, value);
    
    public void Set<T>(T value, [Caller] string name = "") => SetCore(name, value);
    
    /// <inheritdoc cref="_nameexpression" />
    public void Set<T>(Expression<Func<T>> nameLambda, T value) => SetCore(GetName(nameLambda), value);
    
    private void SetCore(string name, object? value)
    {
        foreach (Type type in _typesInHierarchy)
        {
            var property = _reflectionCacheLegacy.TryGetProperty(type, name);
            if (property != null) { property.SetValue(Obj, value, null); return; }
            var field = _reflectionCacheLegacy.TryGetField(type, name);
            if (field != null) { field.SetValue(Obj, value); return; }
        }

        throw new Exception($"Property or field '{name}' not found.");
    }
    
    // Indexers
    
    // With Indexer
    
    public object? this[params ICollection<object?> indexes]
    {
        get
        {
            AssertIndexes(indexes);
            var property = ResolveIndexer(indexes, [ ]);
            return property.GetValue(Obj, indexes.ToArray());
        }
        set
        {
            AssertIndexes(indexes);
            var property = ResolveIndexer(indexes, [ ]);
            property.SetValue(Obj, value, indexes.ToArray());
        }
    }
    
    // With Params
    
    public object? Get(params ICollection<object?> indexes)
    {
        AssertIndexes(indexes);
        var property = ResolveIndexer(indexes, [ ]);
        return property.GetValue(Obj, indexes.ToArray());
    }
    
    public void Set(params ICollection<object?> indexesAndValue)
    {
        AssertIndexesAndValue(indexesAndValue);
        
        object?[] indexes = indexesAndValue.Take(indexesAndValue.Count - 1).ToArray();
        object? value = indexesAndValue.Last();
        
        var property = ResolveIndexer(indexes, [ ]);
        property.SetValue(Obj, value, indexes);
    }
    
    // With Collections
    
    public object? Get(ICollection<object?> indexes, ICollection<Type?> indexTypes)
    {
        AssertIndexes(indexes);
        var property = ResolveIndexer(indexes, indexTypes);
        return property.GetValue(Obj, indexes.ToArray());
    }

    public void Set(ICollection<object?> indexes, object? value, ICollection<Type?> indexTypes)
    {
        AssertIndexes(indexes);
        if (indexTypes == null) throw new ArgumentNullException(nameof(indexTypes));
        var property = ResolveIndexer(indexes, indexTypes);
        property.SetValue(Obj, value, indexes.ToArray());
    }
    
    // Helpers
    
    private static void AssertIndexes(ICollection<object?> indexes)
    {
        if (indexes == null) throw new ArgumentNullException(nameof(indexes));
        if (indexes.Count < 1) throw new Exception("indexes.Count must be at least 1.");
    }
        
    private static void AssertIndexesAndValue(ICollection<object?> indexesAndValue)
    {
        if (indexesAndValue == null) throw new ArgumentNullException(nameof(indexesAndValue));
        if (indexesAndValue.Count < 2) throw new Exception("indexesAndValue.Count must be at least 2");
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

    [OverloadPriority(1)] 
    public object? Call(
        string name,
        params ICollection<object?> args)
        => CallCore(name, args);

    public object? Call(
        ICollection<object?> args,
        [Caller] string name = "")
        => CallCore(name, args);

    [OverloadPriority(1)] 
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

    [OverloadPriority(1)] 
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
        ICollection<Type> complementedArgTypes = ComplementArgTypes(args, argTypes);
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
            ICollection<Type> stackFrameArgTypes = stackFrame.GetMethod()?.GetParameters().Select(x => x.ParameterType).ToArray() ?? [ ];
            foreach (Type type in _typesInHierarchy)
            {
                MethodInfo? method = _reflectionCacheLegacy.TryGetMethod(type, name, stackFrameArgTypes.ToArray(), typeArgs.ToArray());
                if (method != null) return method;
            }
        }

        throw new Exception($"Method '{name}' not found.");
    }

    private PropertyInfo ResolveIndexer(
        ICollection<object?> indexes,
        ICollection<Type?> indexTypes)
    {
        ICollection<Type> complementedIndexTypes = ComplementArgTypes(indexes, indexTypes);
        foreach (Type type in _typesInHierarchy)
        {
            PropertyInfo? property = _reflectionCacheLegacy.TryGetIndexer(type, complementedIndexTypes.ToArray());
            if (property != null) return property;
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
            
            ICollection<Type> stackFrameArgTypes
                = stackFrame.GetMethod()?
                            .GetParameters()
                            .Select(x => x.ParameterType)
                            .ToArray()
                            .Take(indexes.Count)
                            .ToArray() ?? [ ];
            
            foreach (Type type in _typesInHierarchy)
            {
                PropertyInfo? property = _reflectionCacheLegacy.TryGetIndexer(type, stackFrameArgTypes.ToArray());
                if (property != null) return property;
            }
        }

        throw new Exception($"Indexer not found with index types: [{Join(", ", indexTypes.Select(x => $"{x}"))}].");
    }
    
    /// <inheritdoc cref="_complementparametertypes" />
    private ICollection<Type> ComplementArgTypes(ICollection<object?> args, ICollection<Type?> argTypes)
    {
        if (argTypes.Count > args.Count) throw new Exception("More argTypes than args.");
        Type?[] argTypesArray = argTypes.ToArray();
        Resize(ref argTypesArray, args.Count); // Lenience for missing argTypes array elements.
        Type[] argTypesFromObjects = TypesFromObjects(args);
        Type[] resolvedArgTypes = argTypesArray.Zip(argTypesFromObjects, (x, y) => x ?? y).ToArray();
        return resolvedArgTypes;
    }
}