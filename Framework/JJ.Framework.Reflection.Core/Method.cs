namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    public static object? MethodCore(
        Type type, string name, BindingFlags bindingFlags,
        MethodDic dic, Lock lck)
    {
        MethodInfo? method;
        lock (lck)
        {
            if (dic.TryGetValue((type, name), out method))
            {
                return method;
            }
        }

        method = type.GetMethod(name, bindingFlags);
        
        lock (lck)
        {
            dic[(type, name)] = method;
        }
        
        return method;
    }
        
    public static object? MethodCore(
        Type type, string name, BindingFlags bindingFlags, 
        Type?[] argTypes, 
        MethodDic dic, Lock lck)
    {
        MethodInfo? method;
        lock (lck)
        {
            if (dic.TryGetValue((type, name), out method))
            {
                return method;
            }
        }

        method = type.GetMethod(name, bindingFlags, null, argTypes, null);
        
        lock (lck)
        {
            dic[(type, name)] = method;
        }
        
        return method;
    }

    public static object? MethodCore(
        Type type, string name, BindingFlags bindingFlags, 
        Type?[] argTypes, Type[] typeArgs, 
        MethodDic dic, Lock lck)
    {
        MethodInfo? method;
        lock (lck)
        {
            if (dic.TryGetValue((type, name), out method))
            {
                return method;
            }
        }

        // TODO: Use typeArgs
        typeArgs = typeArgs;
        
        method = type.GetMethod(name, bindingFlags, null, argTypes, null);
        
        lock (lck)
        {
            dic[(type, name)] = method;
        }
        
        return method;
    }
}

public partial class Reflector
{
    private readonly MethodDic _methodDic = new();
    private readonly Lock _methodDicLock = new();

    public object? Method(Type type, string name) 
        => MethodCore(type, name, BindingFlags, _methodDic, _methodDicLock);

    public object? Method(Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlags, argTypes, _methodDic, _methodDicLock);
    
    public object? Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlags, argTypes, typeArgs, _methodDic, _methodDicLock);
}

public static partial class Reflect
{
    internal static readonly MethodDic _methodDic = new();
    internal static readonly Lock _methodDicLock = new();

    public static object? Method(Type type, string name) 
        => MethodCore(type, name, BindingFlagsAll, _methodDic, _methodDicLock);

    public static object? Method(Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, _methodDic, _methodDicLock);
    
    public static object? Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDic, _methodDicLock);
}

public static partial class ReflectExtensions
{
    public static object? Method(this Type type, string name) 
        => MethodCore(type, name, BindingFlagsAll, _methodDic, _methodDicLock);

    public static object? Method(this Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, _methodDic, _methodDicLock);
    
    public static object? Method(this Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDic, _methodDicLock);
}