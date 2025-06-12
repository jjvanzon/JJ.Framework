
namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    // TODO: Add up to arity 5 specialized methods for faster lookup?

    // Nullable
    
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
        
        //method = type.GetMethod(name, bindingFlags);
        method = TryResolveMethod(type, name, bindingFlags);
        
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
            
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, 
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
        
        method = TryResolveMethod(type, name, bindingFlags, argTypes);
        //method = type.GetMethod(name, bindingFlags, null, argTypes, null);
        
        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
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

        method = TryResolveMethod(type, name, bindingFlags, argTypes);
        //method = type.GetMethod(name, bindingFlags, null, argTypes, null);

        lock (lck)
        {
            dic[key] = method;
        }
        
        return method;
    }

    // Not Null
        
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        Type type, string name, BindingFlags bindingFlags,
        MethodDic0 dic, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, dic, lck);
        if (method == null)
        {
            throw new Exception("Method not found: " + Format(type, name));

        }
        return method;
    }
        
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDicN dic, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, argTypes, dic, lck);
        if (method == null)
        {
            throw new Exception("Method not found: " + Format(type, name, argTypes));
        }
        return method;
    }

    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDicN dic, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, argTypes, typeArgs, dic, lck);
        if (method == null)
        {
            throw new Exception("Method not found: " + Format(type, name, argTypes, typeArgs));
        }
        return method;
    }

    // Short Type Names
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        string shortTypeName, string name, BindingFlags bindingFlags, 
        MethodDic0 dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        ThrowIfNull(type, nameof(shortTypeName));
        return MethodOrThrow(type, name, bindingFlags, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        string shortTypeName, string name, BindingFlags bindingFlags,
        MethodDic0 dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return MethodOrNull(type, name, bindingFlags, dic, lck);
    }
        
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        string typeShortName, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDicN dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(typeShortName, cache);
        return MethodOrThrow(type, name, bindingFlags, argTypes, dic, lck);
    }
        
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        string shortTypeName, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDicN dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return MethodOrNull(type, name, bindingFlags, argTypes, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        string shortTypeName, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDicN dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return MethodOrThrow(type, name, bindingFlags, argTypes, typeArgs, dic, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        string shortTypeName, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDicN dic, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return MethodOrNull(type, name, bindingFlags, argTypes, typeArgs, dic, lck);
    }

    // Nullable as Option
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrSomething(
        string typeShortName, string name, bool nullable, BindingFlags bindingFlags, 
        MethodDic0 dic, Lock lck, ReflectionCacheLegacy cache)
        => nullable ?
           MethodOrNull (typeShortName, name, bindingFlags, dic, lck, cache) :
           MethodOrThrow(typeShortName, name, bindingFlags, dic, lck, cache);
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrSomething(
        Type type, string name, bool nullable, BindingFlags bindingFlags, 
        MethodDic0 dic, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, dic, lck) :
           MethodOrThrow(type, name, bindingFlags, dic, lck);

    public static MethodInfo? MethodOrSomething(
        string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes,
        MethodDicN dic, Lock lck, ReflectionCacheLegacy cache)
        => nullable ? 
           MethodOrNull (shortTypeName, name, bindingFlags, argTypes, dic, lck, cache): 
           MethodOrThrow(shortTypeName, name, bindingFlags, argTypes, dic, lck, cache);

    public static MethodInfo? MethodOrSomething(
        Type type, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDicN dic, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, argTypes, dic, lck):
           MethodOrThrow(type, name, bindingFlags, argTypes, dic, lck);

    public static MethodInfo? MethodOrSomething(
        string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs,
        MethodDicN dic, Lock lck, ReflectionCacheLegacy cache)
        => nullable ?
           MethodOrNull (shortTypeName, name, bindingFlags, argTypes, typeArgs, dic, lck, cache) :
           MethodOrThrow(shortTypeName, name, bindingFlags, argTypes, typeArgs, dic, lck, cache);
    
    public static MethodInfo? MethodOrSomething(
        Type type, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs,
        MethodDicN dic, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, argTypes, typeArgs, dic, lck) :
           MethodOrThrow(type, name, bindingFlags, argTypes, typeArgs, dic, lck);

    /// <summary>
    /// Temporary solution to keep some argTypes optional and still resolve the method.
    /// More refined resolution might be ported from AccessorCore eventually.
    /// </summary>
    private static MethodInfo? TryResolveMethod(Type type, string name, BindingFlags bindingFlags, params Type?[] argTypes)
    { 
        MethodInfo[] candidates = type.GetMethods(bindingFlags).Where(x => Is(x.Name, name)).ToArray();
        
        if (!Has(candidates)) return null;

        Binder? defaultBinder = System.Type.DefaultBinder;
        if (defaultBinder == null) throw new Exception(TextOf(System.Type.DefaultBinder) + " is null.");

        MethodBase? bestMatch = defaultBinder.SelectMethod(
            bindingFlags,
            candidates,
            argTypes.Select(x => x ?? typeof(object)).ToArray(), 
            null);
        
        if (bestMatch == null)
        {
            return null;
        }
        
        if (bestMatch is MethodInfo methodInfo)
        {
            return methodInfo;
        }
        
        throw new Exception(
            $"Unexpected Type '{bestMatch.GetType().Name}' " +
            $"where {nameof(MethodInfo)} was expected: " + NewLine +
            Format(type, name, argTypes));
    }
    
    // Helpers
    
    // TODO: Make reusable somewhere. I could reuse it in some places.
    
    private static string Format(Type? type, string? name, Type?[] argTypes, Type[] typeArgs) 
        => $"{Format(type)}.{Format(name)}<{Format(typeArgs)}>({Format(argTypes)})";
    
    private static string Format(Type? type, string? name, params Type?[] argTypes) 
        => $"{Format(type)}.{Format(name)}({Format(argTypes)})";
    
    private static string Format(Type?[] types) => Join(", ", types.Select(Format));
    
    private static string Format(Type? type) => Has(type) ? type.Name : "?";
    
    private static string Format(string? name) => Has(name) ? name : "?";
}

// ReSharper disable UnusedParameter.Global

public partial class Reflector
{
          private readonly MethodDic0 _methodDic0 = new();
          private readonly Lock   _methodDicLock0 = new();
          private readonly MethodDicN _methodDicN = new();
          private readonly Lock   _methodDicLockN = new();
          
          public        MethodInfo  Method   (     string type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlags,                        _methodDic0, _methodDicLock0, _cache);
          public        MethodInfo  Method   (     Type   type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo  Method<T>(     T      obj,                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo  Method<T>(                                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo? Method   (     string type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0, _cache);
          public        MethodInfo? Method   (     Type   type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo? Method<T>(     T      obj,               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo? Method<T>(                               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0        );
[Prio(1)] public        MethodInfo? Method   (     string type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0, _cache);
[Prio(1)] public        MethodInfo? Method   (     Type   type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0        );
[Prio(1)] public        MethodInfo? Method<T>(     T      obj,               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0        );
[Prio(1)] public        MethodInfo? Method<T>(                               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo? Method   (     string type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0, _cache);
          public        MethodInfo? Method   (     Type   type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo? Method<T>(     T      obj,  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo? Method<T>(                  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDic0, _methodDicLock0        );
[Prio(1)] public        MethodInfo? Method   (     string type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0, _cache);
[Prio(1)] public        MethodInfo? Method   (     Type   type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0        );
[Prio(1)] public        MethodInfo? Method<T>(     T      obj,  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0        );
[Prio(1)] public        MethodInfo? Method<T>(                  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDic0, _methodDicLock0        );
          public        MethodInfo  Method   (     string type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes,           _methodDicN, _methodDicLockN, _cache);
          public        MethodInfo  Method   (     Type   type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
          public        MethodInfo  Method<T>(     T      obj,  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
          public        MethodInfo  Method<T>(                  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
          public        MethodInfo? Method   (     string type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes,           _methodDicN, _methodDicLockN, _cache);
          public        MethodInfo? Method   (     Type   type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
          public        MethodInfo? Method<T>(     T      obj,  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
          public        MethodInfo? Method<T>(                  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public        MethodInfo? Method   (     string type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes,           _methodDicN, _methodDicLockN, _cache);
[Prio(1)] public        MethodInfo? Method   (     Type   type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public        MethodInfo? Method<T>(     T      obj,  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public        MethodInfo? Method<T>(                  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes,           _methodDicN, _methodDicLockN        );
          public        MethodInfo  Method   (     string type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
          public        MethodInfo  Method   (     Type   type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public        MethodInfo  Method<T>(     T      obj,  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public        MethodInfo  Method<T>(                  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public        MethodInfo? Method   (     string type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
          public        MethodInfo? Method   (     Type   type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public        MethodInfo? Method<T>(     T      obj,  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public        MethodInfo? Method<T>(                  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public        MethodInfo? Method   (     string type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
[Prio(1)] public        MethodInfo? Method   (     Type   type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public        MethodInfo? Method<T>(     T      obj,  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public        MethodInfo? Method<T>(                  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDicN, _methodDicLockN        );
}                                                     
public static partial class Reflect
{
          internal static readonly MethodDic0 _methodDic0 = new();
          internal static readonly Lock   _methodDicLock0 = new();
          internal static readonly MethodDicN _methodDicN = new();
          internal static readonly Lock   _methodDicLockN = new();

          public static MethodInfo  Method   (     string type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
          public static MethodInfo  Method   (     Type   type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo  Method<T>(     T      obj,                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo  Method<T>(                                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method   (     string type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
          public static MethodInfo? Method   (     Type   type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(     T      obj,               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(                               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method   (     string type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
[Prio(1)] public static MethodInfo? Method   (     Type   type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(     T      obj,               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(                               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method   (     string type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
          public static MethodInfo? Method   (     Type   type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(     T      obj,  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(                  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method   (     string type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
[Prio(1)] public static MethodInfo? Method   (     Type   type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(     T      obj,  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(                  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo  Method   (     string type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo  Method   (     Type   type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(     T      obj,  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(                  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method   (     string type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo? Method   (     Type   type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(     T      obj,  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(                  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method   (     string type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN, _cache);
[Prio(1)] public static MethodInfo? Method   (     Type   type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(     T      obj,  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(                  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method   (     string type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo  Method   (     Type   type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(     T      obj,  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(                  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method   (     string type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo? Method   (     Type   type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(     T      obj,  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(                  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method   (     string type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
[Prio(1)] public static MethodInfo? Method   (     Type   type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(     T      obj,  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(                  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
}

public static partial class ReflectExtensions
{
          public static MethodInfo  Method   (this string type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
          public static MethodInfo  Method   (this Type   type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo  Method<T>(this T      obj,                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo  Method<T>(this                                                        string name             ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method   (this string type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
          public static MethodInfo? Method   (this Type   type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(this T      obj,               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          //public static MethodInfo? Method<T>(this                           bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method   (this string type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
[Prio(1)] public static MethodInfo? Method   (this Type   type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(this T      obj,               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
//[Prio(1)] public static MethodInfo? Method<T>(this                           NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method   (this string type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
          public static MethodInfo? Method   (this Type   type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(this T      obj,  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo? Method<T>(this              string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method   (this string type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0, _cache);
[Prio(1)] public static MethodInfo? Method   (this Type   type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(this T      obj,  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
[Prio(1)] public static MethodInfo? Method<T>(this              string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDic0, _methodDicLock0        );
          public static MethodInfo  Method   (this string type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo  Method   (this Type   type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(this T      obj,  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(this              string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method   (this string type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo? Method   (this Type   type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(this T      obj,  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(this              string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method   (this string type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN, _cache);
[Prio(1)] public static MethodInfo? Method   (this Type   type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(this T      obj,  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(this              string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method   (this string type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo  Method   (this Type   type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(this T      obj,  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo  Method<T>(this              string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method   (this string type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
          public static MethodInfo? Method   (this Type   type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(this T      obj,  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
          public static MethodInfo? Method<T>(this              string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method   (this string type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN, _cache);
[Prio(1)] public static MethodInfo? Method   (this Type   type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(this T      obj,  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
[Prio(1)] public static MethodInfo? Method<T>(this              string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDicN, _methodDicLockN        );
}
