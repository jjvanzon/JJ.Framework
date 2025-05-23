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


internal readonly struct NameTypeKey : IEquatable<NameTypeKey>
{
    private readonly RuntimeTypeHandle _handle;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public NameTypeKey(string name, Type type)
    {
        _handle = type.TypeHandle;
        _name = name;
        _hash = HashCode.Combine(_handle, _name);
    }

    public bool Equals(NameTypeKey other) =>
        _handle.Equals(other._handle) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));

}

internal readonly struct NameTypesKey2 : IEquatable<NameTypesKey2>
{
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public NameTypesKey2(string name, Type type1, Type type2)
    {
        _handle1 = type1.TypeHandle;
        _handle2 = type2.TypeHandle;
        _name = name;
        _hash = Combine(_handle1, _handle2, _name);
    }

    public bool Equals(NameTypesKey2 other) =>
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));

}

internal readonly struct NameTypesKey3 : IEquatable<NameTypesKey3>
{
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly RuntimeTypeHandle _handle3;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public NameTypesKey3(string name, Type type1, Type type2, Type type3)
    {
        _handle1 = type1.TypeHandle;
        _handle2 = type2.TypeHandle;
        _handle3 = type3.TypeHandle;
        _name = name;
        _hash = Combine(_handle1, _handle2, _handle3, _name);
    }

    public bool Equals(NameTypesKey3 other) =>
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        _handle3.Equals(other._handle3) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct NameTypesKey4 : IEquatable<NameTypesKey4>
{
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly RuntimeTypeHandle _handle3;
    private readonly RuntimeTypeHandle _handle4;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public NameTypesKey4(string name, Type type1, Type type2, Type type3, Type type4)
    {
        _handle1 = type1.TypeHandle;
        _handle2 = type2.TypeHandle;
        _handle3 = type3.TypeHandle;
        _handle4 = type4.TypeHandle;
        _name = name;
        _hash = Combine(_handle1, _handle2, _handle3, _handle4, _name);
    }

    public bool Equals(NameTypesKey4 other) =>
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        _handle3.Equals(other._handle3) &&
        _handle4.Equals(other._handle4) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}
