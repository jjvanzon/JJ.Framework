// ReSharper disable PossiblyImpureMethodCallOnReadonlyVariable
namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    public static object? MethodCore(
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
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }

    // TODO: Add up to arity 5 specialized methods for faster lookup.
 
    public static object? MethodCore(
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
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }

    public static object? MethodCore(
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
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
}

public partial class Reflector
{
    private readonly MethodDic0 _methodDic0 = new();
    private readonly Lock _methodDicLock0 = new();
    private readonly MethodDicN _methodDicN = new();
    private readonly Lock _methodDicLockN = new();

    public object? Method(Type type, string name) 
        => MethodCore(type, name, BindingFlags, _methodDic0, _methodDicLock0);

    public object? Method(Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlags, argTypes, _methodDicN, _methodDicLockN);
    
    public object? Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlags, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

public static partial class Reflect
{
    internal static readonly MethodDic0 _methodDic0 = new();
    internal static readonly Lock _methodDicLock0 = new();
    internal static readonly MethodDicN _methodDicN = new();
    internal static readonly Lock _methodDicLockN = new();

    public static object? Method(Type type, string name) 
        => MethodCore(type, name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static object? Method(Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static object? Method(Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

public static partial class ReflectExtensions
{
    public static object? Method(this Type type, string name) 
        => MethodCore(type, name, BindingFlagsAll, _methodDic0, _methodDicLock0);

    public static object? Method(this Type type, string name, params Type?[] argTypes) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, _methodDicN, _methodDicLockN);
    
    public static object? Method(this Type type, string name, Type?[] argTypes, Type[] typeArgs) 
        => MethodCore(type, name, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN);
}

// TODO: Move to separate MethodKeys.cs

internal readonly struct MethodKey0 : IEquatable<MethodKey0>
{
    private readonly RuntimeTypeHandle _handle;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKey0(Type type, string name)
    {
        _handle = type.TypeHandle;
        _name = name;
        _hash = HashCode.Combine(_handle, _name);
    }

    public bool Equals(MethodKey0 other) =>
        _handle.Equals(other._handle) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct MethodKey1 : IEquatable<MethodKey1>
{
    private readonly RuntimeTypeHandle _handle0;
    private readonly RuntimeTypeHandle _handle1;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKey1(Type type, string name, Type argType1)
    {
        _handle0 = type.TypeHandle;
        _handle1 = argType1.TypeHandle;
        _name = name;
        _hash = Combine(_handle0, _handle1, _name);
    }

    public bool Equals(MethodKey1 other) =>
        _handle0.Equals(other._handle0) &&
        _handle1.Equals(other._handle1) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct MethodKey2 : IEquatable<MethodKey2>
{
    private readonly RuntimeTypeHandle _handle0;
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKey2(Type type, string name, Type argType1, Type argType2)
    {
        _handle0 = type.TypeHandle;
        _handle1 = argType1.TypeHandle;
        _handle2 = argType2.TypeHandle;
        _name = name;
        _hash = Combine(_handle0, _handle1, _handle2, _name);
    }

    public bool Equals(MethodKey2 other) =>
        _handle0.Equals(other._handle0) &&
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct MethodKey3 : IEquatable<MethodKey3>
{
    private readonly RuntimeTypeHandle _handle0;
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly RuntimeTypeHandle _handle3;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKey3(Type type, string name, Type argType1, Type argType2, Type argType3)
    {
        _handle0 = type.TypeHandle;
        _handle1 = argType1.TypeHandle;
        _handle2 = argType2.TypeHandle;
        _handle3 = argType3.TypeHandle;
        _name = name;
        _hash = Combine(_handle0, _handle1, _handle2, _handle3, _name);
    }

    public bool Equals(MethodKey3 other) =>
        _handle0.Equals(other._handle0) &&
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        _handle3.Equals(other._handle3) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct MethodKey4 : IEquatable<MethodKey4>
{
    private readonly RuntimeTypeHandle _handle0;
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly RuntimeTypeHandle _handle3;
    private readonly RuntimeTypeHandle _handle4;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKey4(Type type, string name, Type argType1, Type argType2, Type argType3, Type argType4)
    {
        _handle0 = type.TypeHandle;
        _handle1 = argType1.TypeHandle;
        _handle2 = argType2.TypeHandle;
        _handle3 = argType3.TypeHandle;
        _handle4 = argType4.TypeHandle;
        _name = name;
        _hash = Combine(_handle0, _handle1, _handle2, _handle3, _handle4, _name);
    }

    public bool Equals(MethodKey4 other) =>
        _handle0.Equals(other._handle0) &&
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        _handle3.Equals(other._handle3) &&
        _handle4.Equals(other._handle4) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct MethodKey5 : IEquatable<MethodKey5>
{
    private readonly RuntimeTypeHandle _handle0;
    private readonly RuntimeTypeHandle _handle1;
    private readonly RuntimeTypeHandle _handle2;
    private readonly RuntimeTypeHandle _handle3;
    private readonly RuntimeTypeHandle _handle4;
    private readonly RuntimeTypeHandle _handle5;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKey5(Type type, string name, Type argType1, Type argType2, Type argType3, Type argType4, Type argType5)
    {
        _handle0 = type.TypeHandle;
        _handle1 = argType1.TypeHandle;
        _handle2 = argType2.TypeHandle;
        _handle3 = argType3.TypeHandle;
        _handle4 = argType4.TypeHandle;
        _handle5 = argType5.TypeHandle;
        _name = name;
        _hash = Combine(_handle0, _handle1, _handle2, _handle3, _handle4, _handle5, _name);
    }

    public bool Equals(MethodKey5 other) =>
        _handle0.Equals(other._handle0) &&
        _handle1.Equals(other._handle1) &&
        _handle2.Equals(other._handle2) &&
        _handle3.Equals(other._handle3) &&
        _handle4.Equals(other._handle4) &&
        _handle5.Equals(other._handle5) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));
}

internal readonly struct MethodKeyN : IEquatable<MethodKeyN>
{
    private readonly RuntimeTypeHandle _handle0;
    private readonly RuntimeTypeHandle[] _handleN;
    private readonly string _name;
    private readonly int _hash;
    public override int GetHashCode() => _hash;

    public MethodKeyN(Type type, string name, params Type[] argTypes)
    {
        _handle0 = type.TypeHandle;
        
        _handleN = new RuntimeTypeHandle[argTypes.Length];
        for (int i = 0; i < argTypes.Length; i++)
        {
            _handleN[i] = argTypes[i].TypeHandle;
        }
        
        _name = name;
        _hash = HashHandles(_handle0, _handleN, _name);
    }

    public bool Equals(MethodKeyN other) =>
        _handle0.Equals(other._handle0) &&
        _handleN.SequenceEqual(other._handleN) &&
        (_name == other._name || string.Equals(_name, other._name, Ordinal));

    private static int HashHandles(RuntimeTypeHandle first, RuntimeTypeHandle[] rest, string name)
    {
        #if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
            var hc = new HashCode();
            hc.Add(first);
            foreach (var h in rest)
                hc.Add(h);
            hc.Add(name, StringComparer.Ordinal);
            return hc.ToHashCode();
        #else
            // FNV-1a 32-bit
            const int seed = unchecked((int)0x811C9DC5);
            const int prime = 16777619;

            int hash = seed ^ first.GetHashCode();
            hash *= prime;

            foreach (var h in rest)
            {
                hash ^= h.GetHashCode();
                hash *= prime;
            }

            hash ^= name.GetHashCode();
            return hash * prime;
        #endif
    }
}
