namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    // TODO: Add up to arity 5 specialized methods for faster lookup.

    // No Args
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        Type type, string name, BindingFlags bindingFlags,
        MethodDic0 dic, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, dic, lck);
        if (method == null)
        {
            throw new Exception($"Method {name} not found in {type.Name}.");
        }
        return method;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        Type type, string name, BindingFlags bindingFlags,
        MethodDic0 dic, Lock lck)
    {
        MethodInfo? method;

        var key = new MethodKey0(type, name);
        
        lock (lck)
        {
            if (dic.TryGetValue(key, out method))
            {
                return method;
            }
        }

        ThrowIfNull(type);
        
        method = type.GetMethod(name, bindingFlags);
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
    
    public static MethodInfo? MethodOrSomething(
        Type type, string name, bool nullable, BindingFlags bindingFlags, 
        MethodDic0 dic, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, dic, lck) :
           MethodOrThrow(type, name, bindingFlags, dic, lck);

    // With ArgTypes
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        Type type, string name, BindingFlags bindingFlags, 
        Type?[] argTypes, 
        MethodDicN dic, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, argTypes, dic, lck);
        if (method == null)
        {
            // TODO: Mention arg types.
            throw new Exception($"Method {name} not found in {type.Name}.");
        }
        return method;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        Type type, string name, BindingFlags bindingFlags, 
        Type?[] argTypes, 
        MethodDicN dic, Lock lck)
    {
        MethodInfo? method;
        
        var key = new MethodKeyN(type, name, argTypes);
        lock (lck)
        {
            if (dic.TryGetValue(key, out method))
            {
                return method;
            }
        }

        ThrowIfNull(type);
        
        method = type.GetMethod(name, bindingFlags, null, argTypes, null);
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
    
    public static MethodInfo? MethodOrSomething(
        Type type, string name, bool nullable, BindingFlags bindingFlags, 
        Type?[] argTypes, 
        MethodDicN dic, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, argTypes, dic, lck) :
           MethodOrThrow(type, name, bindingFlags, argTypes, dic, lck);

    // With TypeArgs

    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        Type type, string name, BindingFlags bindingFlags, 
        Type?[] argTypes, Type[] typeArgs, 
        MethodDicN dic, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, argTypes, typeArgs, dic, lck);
        if (method == null)
        {
            // TODO: Mention arg types.
            throw new Exception($"Method {name} not found in {type.Name}.");
        }
        return method;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrNull(
        Type type, string name, BindingFlags bindingFlags, 
        Type?[] argTypes, Type[] typeArgs, 
        MethodDicN dic, Lock lck)
    {
        MethodInfo? method;
        
        // TODO: Use typeArgs as part of the key
        var key = new MethodKeyN(type, name, argTypes);
        
        lock (lck)
        {
            if (dic.TryGetValue(key, out method))
            {
                return method;
            }
        }

        // TODO: Use typeArgs
        typeArgs = typeArgs;
        
        ThrowIfNull(type);

        method = type.GetMethod(name, bindingFlags, null, argTypes, null);

        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
    
    public static MethodInfo? MethodOrSomething(
        Type type, string name, bool nullable, BindingFlags bindingFlags, 
        Type?[] argTypes, Type[] typeArgs,
        MethodDicN dic, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, argTypes, typeArgs, dic, lck) :
           MethodOrThrow(type, name, bindingFlags, argTypes, typeArgs, dic, lck);
}

// ReSharper disable UnusedParameter.Global

public partial class Reflector
{
          private readonly MethodDic0 _methodDic0 = new();
          private readonly Lock   _methodDicLock0 = new();
          private readonly MethodDicN _methodDicN = new();
          private readonly Lock   _methodDicLockN = new();
          
          public MethodInfo  Method(Type type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type, name,                   BindingFlags,                     _methodDic0, _methodDicLock0);
          public MethodInfo? Method(Type type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type, name, nullable,         BindingFlags,                     _methodDic0, _methodDicLock0);
[Prio(1)] public MethodInfo? Method(Type type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type, name, nullable == null, BindingFlags,                     _methodDic0, _methodDicLock0);
          public MethodInfo? Method(Type type, string name, bool      nullable                                   ) => MethodOrSomething(type, name, nullable,         BindingFlags,                     _methodDic0, _methodDicLock0);
[Prio(1)] public MethodInfo? Method(Type type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type, name, nullable == null, BindingFlags,                     _methodDic0, _methodDicLock0);
          public MethodInfo  Method(Type type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type, name,                   BindingFlags, argTypes,           _methodDicN, _methodDicLockN);
          public MethodInfo? Method(Type type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type, name, nullable,         BindingFlags, argTypes,           _methodDicN, _methodDicLockN);
[Prio(1)] public MethodInfo? Method(Type type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type, name, nullable == null, BindingFlags, argTypes,           _methodDicN, _methodDicLockN);
          public MethodInfo  Method(Type type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type, name,                   BindingFlags, argTypes, typeArgs, _methodDicN, _methodDicLockN);
          public MethodInfo? Method(Type type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type, name, nullable,         BindingFlags, argTypes, typeArgs, _methodDicN, _methodDicLockN);
[Prio(1)] public MethodInfo? Method(Type type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type, name, nullable == null, BindingFlags, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
          public MethodInfo Method<T>(T obj,  [Caller] string name = "") => MethodOrThrow(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);
          public MethodInfo Method<T>(T obj, string name, params Type?[] argTypes) => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
          public MethodInfo Method<T>(T obj, string name, Type?[] argTypes, Type[] typeArgs) => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
          public MethodInfo Method<T>([Caller] string name = "") => MethodOrThrow(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);
          public MethodInfo Method<T>(string name, params Type?[] argTypes) => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
          public MethodInfo Method<T>(string name, Type?[] argTypes, Type[] typeArgs) => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

public static partial class Reflect
{
    internal static readonly MethodDic0 _methodDic0 = new();
    internal static readonly Lock _methodDicLock0 = new();
    internal static readonly MethodDicN _methodDicN = new();
    internal static readonly Lock _methodDicLockN = new();

    public static MethodInfo Method(Type type, [Caller] string name = "") 
        => MethodOrThrow(type, name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method(Type type, string name, params Type?[] argTypes) 
        => MethodOrThrow(type, name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodOrThrow(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(T obj, [Caller] string name = "") 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method<T>(T obj, string name, params Type?[] argTypes) 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(T obj, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>([Caller] string name = "") 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method<T>(string name, params Type?[] argTypes) 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

public static partial class ReflectExtensions
{
    public static MethodInfo Method(this Type type, [Caller] string name = "") 
        => MethodOrThrow(type, name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method(this Type type, string name, params Type?[] argTypes) 
        => MethodOrThrow(type, name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method(this Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodOrThrow(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(this T obj, [Caller] string name = "") 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method<T>(this T obj, string name, params Type?[] argTypes) 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(this T obj, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodOrThrow(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}
