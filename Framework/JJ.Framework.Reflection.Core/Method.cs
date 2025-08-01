﻿
namespace JJ.Framework.Reflection.Core;

internal static partial class ReflectUtility
{
    // TODO: Add up to arity 5 specialized methods for faster lookup?

    // Nullable
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        [Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags,
        MethodDict0 dict, Lock lck)
    {
        MethodInfo? method;

        var key = new MethodKey0(type, name);
        
        lock (lck)
        {
            if (dict.TryGetValue(key, out method))
            {
                return method;
            }
        }

        ThrowIfNull(type);
        
        method = TryResolveMethod(type, name, bindingFlags);
        
        lock (lck)
        {
            dict[key] = method;
        }
        
        return method;
    }
            
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        [Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDictN dict, Lock lck)
    {
        MethodInfo? method;
        
        var key = new MethodKeyN(type, name, argTypes);
        lock (lck)
        {
            if (dict.TryGetValue(key, out method))
            {
                return method;
            }
        }

        ThrowIfNull(type);
        
        method = TryResolveMethod(type, name, bindingFlags, argTypes);
        
        lock (lck)
        {
            dict[key] = method;
        }
        
        return method;
    }
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrNull(
        // ReSharper disable once UnusedParameter.Global
        [Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDictN dict, Lock lck)
    {
        MethodInfo? method;
        
        // TODO: Use typeArgs as part of the key
        var key = new MethodKeyN(type, name, argTypes);
        
        lock (lck)
        {
            if (dict.TryGetValue(key, out method))
            {
                return method;
            }
        }
        
        ThrowIfNull(type);

        // TODO: Use typeArgs
        method = TryResolveMethod(type, name, bindingFlags, argTypes);

        lock (lck)
        {
            dict[key] = method;
        }
        
        return method;
    }

    // Not Null
        
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        [Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags,
        MethodDict0 dict, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, dict, lck);
        if (method == null)
        {
            throw new Exception("Method not found: " + Format(type, name));

        }
        return method;
    }
        
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        [Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDictN dict, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, argTypes, dict, lck);
        if (method == null)
        {
            throw new Exception("Method not found: " + Format(type, name, argTypes));
        }
        return method;
    }

    [MethodImpl(AggressiveInlining)]
    public static MethodInfo MethodOrThrow(
        [Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDictN dict, Lock lck)
    {
        MethodInfo? method = MethodOrNull(type, name, bindingFlags, argTypes, typeArgs, dict, lck);
        if (method == null)
        {
            throw new Exception("Method not found: " + Format(type, name, argTypes, typeArgs));
        }
        return method;
    }

    // Short Type Names
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo MethodOrThrow(
        string shortTypeName, string name, BindingFlags bindingFlags, 
        MethodDict0 dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        ThrowIfNull(type, nameof(shortTypeName));
        return MethodOrThrow(type, name, bindingFlags, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo? MethodOrNull(
        string shortTypeName, string name, BindingFlags bindingFlags,
        MethodDict0 dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return MethodOrNull(type, name, bindingFlags, dict, lck);
    }
        
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo MethodOrThrow(
        string typeShortName, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDictN dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(typeShortName, cache);
        return MethodOrThrow(type, name, bindingFlags, argTypes, dict, lck);
    }
        
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo? MethodOrNull(
        string shortTypeName, string name, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDictN dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return MethodOrNull(type, name, bindingFlags, argTypes, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo MethodOrThrow(
        string shortTypeName, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDictN dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type type = Type(shortTypeName, cache);
        return MethodOrThrow(type, name, bindingFlags, argTypes, typeArgs, dict, lck);
    }
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo? MethodOrNull(
        string shortTypeName, string name, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs, 
        MethodDictN dict, Lock lck, ReflectionCacheLegacy cache)
    {
        Type? type = Type(shortTypeName, nullable, cache);
        if (type == null) return null;
        return MethodOrNull(type, name, bindingFlags, argTypes, typeArgs, dict, lck);
    }

    // Nullable as Option
    
    [MethodImpl(AggressiveInlining)]
    [NoTrim(GetTypes)]
    public static MethodInfo? MethodOrSomething(
        string typeShortName, string name, bool nullable, BindingFlags bindingFlags, 
        MethodDict0 dict, Lock lck, ReflectionCacheLegacy cache)
        => nullable ?
           MethodOrNull (typeShortName, name, bindingFlags, dict, lck, cache) :
           MethodOrThrow(typeShortName, name, bindingFlags, dict, lck, cache);
    
    [MethodImpl(AggressiveInlining)]
    public static MethodInfo? MethodOrSomething(
        [Dyn(AllMethods)] Type type, string name, bool nullable, BindingFlags bindingFlags, 
        MethodDict0 dict, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, dict, lck) :
           MethodOrThrow(type, name, bindingFlags, dict, lck);

    [NoTrim(GetTypes)]
    public static MethodInfo? MethodOrSomething(
        string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes,
        MethodDictN dict, Lock lck, ReflectionCacheLegacy cache)
        => nullable ? 
           MethodOrNull (shortTypeName, name, bindingFlags, argTypes, dict, lck, cache): 
           MethodOrThrow(shortTypeName, name, bindingFlags, argTypes, dict, lck, cache);

    public static MethodInfo? MethodOrSomething(
        [Dyn(AllMethods)] Type type, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes, 
        MethodDictN dict, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, argTypes, dict, lck):
           MethodOrThrow(type, name, bindingFlags, argTypes, dict, lck);

    [NoTrim(GetTypes)]
    public static MethodInfo? MethodOrSomething(
        string shortTypeName, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs,
        MethodDictN dict, Lock lck, ReflectionCacheLegacy cache)
        => nullable ?
           MethodOrNull (shortTypeName, name, bindingFlags, argTypes, typeArgs, dict, lck, cache) :
           MethodOrThrow(shortTypeName, name, bindingFlags, argTypes, typeArgs, dict, lck, cache);
    
    public static MethodInfo? MethodOrSomething(
        [Dyn(AllMethods)] Type type, string name, bool nullable, BindingFlags bindingFlags, Type?[] argTypes, Type[] typeArgs,
        MethodDictN dict, Lock lck)
        => nullable ?
           MethodOrNull (type, name, bindingFlags, argTypes, typeArgs, dict, lck) :
           MethodOrThrow(type, name, bindingFlags, argTypes, typeArgs, dict, lck);

    /// <summary>
    /// Temporary solution to keep some argTypes optional and still resolve the method.
    /// More refined resolution might be ported from AccessorCore eventually.
    /// </summary>
    private static MethodInfo? TryResolveMethod([Dyn(AllMethods)] Type type, string name, BindingFlags bindingFlags, params Type?[] argTypes)
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
    private readonly MethodDict0 _methodDict0     = new();
    private readonly Lock        _methodDictLock0 = new();
    private readonly MethodDictN _methodDictN     = new();
    private readonly Lock        _methodDictLockN = new();
          
        [NoTrim(GetTypes)] public        MethodInfo  Method(                          string type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlags,                        _methodDict0, _methodDictLock0, _cache);
                           public        MethodInfo  Method([Dyn(AllMethods)]         Type   type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlags,                        _methodDict0, _methodDictLock0        );
                           public        MethodInfo  Method<[Dyn(AllMethods)] T>(     T      obj,                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,                        _methodDict0, _methodDictLock0        );
                           public        MethodInfo  Method<[Dyn(AllMethods)] T>(                                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,                        _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public        MethodInfo? Method(                          string type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0, _cache);
                           public        MethodInfo? Method([Dyn(AllMethods)]         Type   type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(                               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0        );
[Prio(1),NoTrim(GetTypes)] public        MethodInfo? Method(                          string type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0, _cache);
[Prio(1)]                  public        MethodInfo? Method([Dyn(AllMethods)]         Type   type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(                               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public        MethodInfo? Method(                          string type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0, _cache);
                           public        MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,                        _methodDict0, _methodDictLock0        );
[Prio(1),NoTrim(GetTypes)] public        MethodInfo? Method(                          string type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0, _cache);
[Prio(1)]                  public        MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,                        _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public        MethodInfo  Method(                          string type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes,           _methodDictN, _methodDictLockN, _cache);
                           public        MethodInfo  Method([Dyn(AllMethods)]         Type   type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
                           public        MethodInfo  Method<[Dyn(AllMethods)] T>(     T      obj,  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
                           public        MethodInfo  Method<[Dyn(AllMethods)] T>(                  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public        MethodInfo? Method(                          string type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes,           _methodDictN, _methodDictLockN, _cache);
                           public        MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1),NoTrim(GetTypes)] public        MethodInfo? Method(                          string type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes,           _methodDictN, _methodDictLockN, _cache);
[Prio(1)]                  public        MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes,           _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public        MethodInfo  Method(                          string type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
                           public        MethodInfo  Method([Dyn(AllMethods)]         Type   type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public        MethodInfo  Method<[Dyn(AllMethods)] T>(     T      obj,  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public        MethodInfo  Method<[Dyn(AllMethods)] T>(                  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public        MethodInfo? Method(                          string type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
                           public        MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public        MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1),NoTrim(GetTypes)] public        MethodInfo? Method(                          string type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
[Prio(1)]                  public        MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1)]                  public        MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlags,    argTypes, typeArgs, _methodDictN, _methodDictLockN        );
}  

public static partial class Reflect
{
    internal static readonly MethodDict0 _methodDict0      = new();
    internal static readonly Lock        _methodDictLock0 = new();
    internal static readonly MethodDictN _methodDictN      = new();
    internal static readonly Lock        _methodDictLockN = new();

        [NoTrim(GetTypes)] public static MethodInfo  Method(                          string type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
                           public static MethodInfo  Method([Dyn(AllMethods)]         Type   type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(     T      obj,                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(                                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                          string type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]         Type   type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(                               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                          string type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]         Type   type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(                               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                          string type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                          string type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public static MethodInfo  Method(                          string type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo  Method([Dyn(AllMethods)]         Type   type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(     T      obj,  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(                  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                          string type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                          string type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public static MethodInfo  Method(                          string type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo  Method([Dyn(AllMethods)]         Type   type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(     T      obj,  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(                  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                          string type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                          string type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]         Type   type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(     T      obj,  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(                  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
}

public static partial class ReflectExtensions
{
        [NoTrim(GetTypes)] public static MethodInfo  Method(                     this string type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
                           public static MethodInfo  Method([Dyn(AllMethods)]    this Type   type,                                  [Caller] string name = ""        ) => MethodOrThrow    (type,      name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(this T      obj,                                   [Caller] string name = ""        ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(this                                                        string name             ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type,              bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,               bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                         //public static MethodInfo? Method<[Dyn(AllMethods)] T>(this                           bool      nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type,              NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,               NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
//[Prio(1)]                public static MethodInfo? Method<[Dyn(AllMethods)] T>(this                           NullFlag? nullable, [Caller] string name = ""        ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type, string name, bool      nullable                                   ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,  string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this              string name, bool      nullable                                   ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type, string name, NullFlag? nullable                                   ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,  string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this              string name, NullFlag? nullable                                   ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll,                     _methodDict0, _methodDictLock0        );
        [NoTrim(GetTypes)] public static MethodInfo  Method(                     this string type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo  Method([Dyn(AllMethods)]    this Type   type, string name,                     params Type?[] argTypes          ) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(this T      obj,  string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(this              string name,                     params Type?[] argTypes          ) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type, string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,  string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this              string name, bool      nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type, string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,  string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this              string name, NullFlag? nullable, params Type?[] argTypes          ) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes,           _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public static MethodInfo  Method(                     this string type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo  Method([Dyn(AllMethods)]    this Type   type, string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (type,      name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(this T      obj,  string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo  Method<[Dyn(AllMethods)] T>(this              string name,                     Type?[] argTypes, Type[] typeArgs) => MethodOrThrow    (typeof(T), name,                   BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
        [NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
                           public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type, string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,  string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
                           public static MethodInfo? Method<[Dyn(AllMethods)] T>(this              string name, bool      nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable,         BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1),NoTrim(GetTypes)] public static MethodInfo? Method(                     this string type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN, _cache);
[Prio(1)]                  public static MethodInfo? Method([Dyn(AllMethods)]    this Type   type, string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(type,      name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this T      obj,  string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
[Prio(1)]                  public static MethodInfo? Method<[Dyn(AllMethods)] T>(this              string name, NullFlag? nullable, Type?[] argTypes, Type[] typeArgs) => MethodOrSomething(typeof(T), name, nullable == null, BindingFlagsAll, argTypes, typeArgs, _methodDictN, _methodDictLockN        );
}
