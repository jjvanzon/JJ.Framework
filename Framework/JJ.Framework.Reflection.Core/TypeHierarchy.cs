namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
    /// <inheritdoc cref="_typesinhierarchy" />
    public static ICollection<Type> GetTypesInHierarchy([Dyn(Interfaces)] Type type)
    {
        if (type == null) throw new NullException(() => type);
        var coll = new HashSet<Type>();
        AddTypesInHierarchy(type, coll);
        return coll;
    }
    
    /// <inheritdoc cref="_typesinhierarchy" />
    public static ICollection<Type> GetTypesInHierarchy<[Dyn(Interfaces)] TType>() => GetTypesInHierarchy(typeof(TType));

    /// <inheritdoc cref="_typesinhierarchy" />
    public static void AddTypesInHierarchy([Dyn(Interfaces)] Type type, ICollection<Type> coll)
    {
        if (type == null) throw new NullException(() => type);
        if (coll == null) throw new NullException(() => coll);

        AddStateTypesInHierarchy(type, coll);
        AddInterfacesInHierarchy(type, coll);
    }
            
    /// <inheritdoc cref="_typesinhierarchy" />
    public static void AddTypesInHierarchy<[Dyn(Interfaces)] TType>(ICollection<Type> coll) => AddTypesInHierarchy(typeof(TType), coll);

    /// <inheritdoc cref="_typesinhierarchy" />
    public static bool HasTypeInHierarchy([Dyn(Interfaces)] Type type, Type secondType)
    {
        if (secondType == null) throw new NullException(() => secondType);
        return GetTypesInHierarchy(type).Contains(secondType);
    }

    /// <inheritdoc cref="_typesinhierarchy" />
    public static bool HasTypeInHierarchy<[Dyn(Interfaces)] TFirst>(Type secondType) => HasTypeInHierarchy(typeof(TFirst), secondType);
    
    /// <inheritdoc cref="_typesinhierarchy" />
    public static bool HasTypeInHierarchy<[Dyn(Interfaces)] TFirst, TSecond>() => HasTypeInHierarchy(typeof(TFirst), typeof(TSecond));
    
    // Classes

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static ICollection<Type> GetStateTypesInHierarchy(Type type)
    {
        if (type == null) throw new NullException(() => type);
        var coll = new HashSet<Type>();
        AddStateTypesInHierarchy(type, coll);
        return coll;
    }

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static ICollection<Type> GetStateTypesInHierarchy<T>() => GetStateTypesInHierarchy(typeof(T));
    
    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static void AddStateTypesInHierarchy(Type type, ICollection<Type> coll)
    {
        if (type == null) throw new NullException(() => type);
        if (coll == null) throw new NullException(() => coll);

        if (type is { IsClass: false, IsValueType: false }) return;
        
        Type? t = type;
        while (t != null)
        {
            coll.Add(t);
            t = t.BaseType;
        }
    }

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static void AddStateTypesInHierarchy<T>(ICollection<Type> coll) => AddStateTypesInHierarchy(typeof(T), coll);

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static bool HasStateTypeInHierarchy(Type type, Type secondType)
    {
        if (secondType == null) throw new NullException(() => secondType);
        if (!secondType.IsClass) throw new Exception($"{nameof(secondType)} '{secondType.Name}' is not a class.");
        return GetStateTypesInHierarchy(type).Contains(secondType);
    }
    
    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static bool HasStateTypeInHierarchy<TFirst>(Type secondType) => HasStateTypeInHierarchy(typeof(TFirst), secondType);
    
    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static bool HasStateTypeInHierarchy<TFirst, TSecond>() => HasStateTypeInHierarchy(typeof(TFirst), typeof(TSecond));

    // Interfaces
            
    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static ICollection<Type> GetInterfacesInHierarchy([Dyn(Interfaces)] Type type)
    {
        var list = new HashSet<Type>();
        AddInterfacesInHierarchy(type, list);
        return list;
    }

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static ICollection<Type> GetInterfacesInHierarchy<[Dyn(Interfaces)] T>() => GetInterfacesInHierarchy(typeof(T));

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static void AddInterfacesInHierarchy([Dyn(Interfaces)] Type type, ICollection<Type> coll)
    {
        if (type == null) throw new NullException(() => type);
        if (coll == null) throw new NullException(() => coll);
        
        if (type.IsInterface) coll.Add(type);
        coll.AddRange(type.GetInterfaces()); // GetInterfaces from .NET is already recursive.
    }

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static void AddInterfacesInHierarchy<[Dyn(Interfaces)] T>(ICollection<Type> coll) => AddInterfacesInHierarchy(typeof(T), coll);

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static bool HasInterfaceInHierarchy([Dyn(Interfaces)] Type type, Type secondType)
    {
        if (secondType == null) throw new NullException(() => secondType);
        if (!secondType.IsInterface) throw new Exception($"{nameof(secondType)} {secondType.Name} is not an interface.");
        return GetInterfacesInHierarchy(type).Contains(secondType);
    }
    
    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static bool HasInterfaceInHierarchy<[Dyn(Interfaces)] TFirst>(Type secondType) => HasInterfaceInHierarchy(typeof(TFirst), secondType);
    
    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static bool HasInterfaceInHierarchy<[Dyn(Interfaces)] TFirst, TSecond>() => HasInterfaceInHierarchy(typeof(TFirst), typeof(TSecond));
}

public static partial class ReflectExtensions
{
    // Types
    
    /// <inheritdoc cref="_typesinhierarchy" />
    public static ICollection<Type> GetTypesInHierarchy([Dyn(Interfaces)] this Type type)
        => Reflect.GetTypesInHierarchy(type);

    /// <inheritdoc cref="_typesinhierarchy" />
    public static void AddTypesInHierarchy([Dyn(Interfaces)] this Type type, ICollection<Type> coll)
        => Reflect.AddTypesInHierarchy(type, coll);

    /// <inheritdoc cref="_typesinhierarchy" />
    public static bool HasTypeInHierarchy([Dyn(Interfaces)] this Type type, Type type2)
        => Reflect.HasTypeInHierarchy(type, type2);
    
    public static bool HasTypeInHierarchy<TSecondType>([Dyn(Interfaces)] this Type firstType) 
        => Reflect.HasTypeInHierarchy(firstType, typeof(TSecondType));

    // Classes

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static ICollection<Type> GetStateTypesInHierarchy(this Type type)
        => Reflect.GetStateTypesInHierarchy(type);

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static void AddStateTypesInHierarchy(this Type type, ICollection<Type> coll)
        => Reflect.AddStateTypesInHierarchy(type, coll);
    
    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static bool HasStateTypeInHierarchy(this Type type, Type type2)
        => Reflect.HasStateTypeInHierarchy(type, type2);

    /// <inheritdoc cref="_statetypesinhierarchy" />
    public static bool HasStateTypeInHierarchy<TSecond>(this Type first)
        => Reflect.HasStateTypeInHierarchy(first, typeof(TSecond));

    // Interfaces

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static ICollection<Type> GetInterfacesInHierarchy([Dyn(Interfaces)] this Type type)
        => Reflect.GetInterfacesInHierarchy(type);

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static void AddInterfacesInHierarchy([Dyn(Interfaces)] this Type type, ICollection<Type> coll)
        => Reflect.AddInterfacesInHierarchy(type, coll);
    
    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static bool HasInterfaceInHierarchy([Dyn(Interfaces)] this Type type, Type type2)
        => Reflect.HasInterfaceInHierarchy(type, type2);

    /// <inheritdoc cref="_interfacesinhierarchy" />
    public static bool HasInterfaceInHierarchy<TSecond>([Dyn(Interfaces)] this Type first)
        => Reflect.HasInterfaceInHierarchy(first, typeof(TSecond));
}
