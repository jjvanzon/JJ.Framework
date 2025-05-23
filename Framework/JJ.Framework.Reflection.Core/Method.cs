namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    public static MethodInfo MethodCore(
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

        method = type.GetMethod(name, bindingFlags);
        if (method == null)
        {
            throw new Exception($"Method {name} not found in {type.Name}.");
        }
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }

    // TODO: Add up to arity 5 specialized methods for faster lookup.
 
    public static MethodInfo MethodCore(
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

        method = type.GetMethod(name, bindingFlags, null, argTypes, null);
        if (method == null)
        {
            // TODO: Mention arg types.
            throw new Exception($"Method {name} not found in {type.Name}.");
        }
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }

    public static MethodInfo MethodCore(
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
        
        method = type.GetMethod(name, bindingFlags, null, argTypes, null);
        if (method == null)
        {
            // TODO: Mention arg types and type args.
            throw new Exception($"Method {name} not found in {type.Name}.");
        }

        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
}

// ReSharper disable UnusedParameter.Global

public partial class Reflector
{
    private readonly MethodDic0 _methodDic0 = new();
    private readonly Lock _methodDicLock0 = new();
    private readonly MethodDicN _methodDicN = new();
    private readonly Lock _methodDicLockN = new();

    public MethodInfo Method(Type type, string name) 
        => MethodCore(type, name, BindingFlags, _methodDic0, _methodDicLock0);

    public MethodInfo Method(Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlags, argTypes, _methodDicN, _methodDicLockN);
    
    public MethodInfo Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlags, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public MethodInfo Method<T>(T obj, string name) 
        => MethodCore(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public MethodInfo Method<T>(T obj, string name, params Type?[] argTypes) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public MethodInfo Method<T>(T obj, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public MethodInfo Method<T>(string name) 
        => MethodCore(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public MethodInfo Method<T>(string name, params Type?[] argTypes) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public MethodInfo Method<T>(string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

public static partial class Reflect
{
    internal static readonly MethodDic0 _methodDic0 = new();
    internal static readonly Lock _methodDicLock0 = new();
    internal static readonly MethodDicN _methodDicN = new();
    internal static readonly Lock _methodDicLockN = new();

    public static MethodInfo Method(Type type, [Caller] string name = "") 
        => MethodCore(type, name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method(Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(T obj, [Caller] string name = "") 
        => MethodCore(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method<T>(T obj, string name, params Type?[] argTypes) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(T obj, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>([Caller] string name = "") 
        => MethodCore(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method<T>(string name, params Type?[] argTypes) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

public static partial class ReflectExtensions
{
    public static MethodInfo Method(this Type type, [Caller] string name = "") 
        => MethodCore(type, name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method(this Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method(this Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(this T obj, [Caller] string name = "") 
        => MethodCore(typeof(T), name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static MethodInfo Method<T>(this T obj, string name, params Type?[] argTypes) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static MethodInfo Method<T>(this T obj, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(typeof(T), name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}
