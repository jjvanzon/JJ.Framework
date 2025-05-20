using JJ.Framework.Collections.Core;

namespace JJ.Framework.Reflection.Core
{
    public class ReflectionHelperCore
    {
        public const BindingFlags BindingFlagsAll =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy |
            BindingFlags.IgnoreCase;

        // Assemblies

        public static string GetAssemblyName<TType>()
            => TryGetAssemblyName(typeof(TType).Assembly);
        
        public static string TryGetAssemblyName(Assembly assembly) => assembly?.GetName().Name;
        
        public static string GetAssemblyName(Assembly assembly) => TryGetAssemblyName(assembly) ?? throw new NullException(() => assembly);
        
        // Fields

        /// <summary>
        /// Type.GetField returns null if the field does not exist.
        /// This method is a little safer than that and throws a clear exception if the field does not exist.
        /// </summary>
        public static FieldInfo GetFieldOrException(Type type, string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            FieldInfo field = type.GetField(name, BINDING_FLAGS_ALL);
            if (field == null) throw new Exception($"Field '{name}' not found on type '{type}'.");
            return field;
        }
    
        // Types

        /// <inheritdoc cref="_typesinhierarchy" />
        public static ICollection<Type> GetTypesInHierarchy(Type type)
        {
            if (type == null) throw new NullException(() => type);
            var coll = new HashSet<Type>();
            AddTypesInHierarchy(type, coll);
            return coll;
        }
        
        /// <inheritdoc cref="_typesinhierarchy" />
        public static ICollection<Type> GetTypesInHierarchy<TType>() => GetTypesInHierarchy(typeof(TType));
    
        /// <inheritdoc cref="_typesinhierarchy" />
        public static void AddTypesInHierarchy(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);

            AddStateTypesInHierarchy(type, coll);
            AddInterfacesInHierarchy(type, coll);
        }
                
        /// <inheritdoc cref="_typesinhierarchy" />
        public static void AddTypesInHierarchy<TType>(ICollection<Type> coll) => AddTypesInHierarchy(typeof(TType), coll);

        /// <inheritdoc cref="_typesinhierarchy" />
        public static bool HasTypeInHierarchy(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            return GetTypesInHierarchy(type).Contains(secondType);
        }

        /// <inheritdoc cref="_typesinhierarchy" />
        public static bool HasTypeInHierarchy<TFirst>(Type secondType) => HasTypeInHierarchy(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="_typesinhierarchy" />
        public static bool HasTypeInHierarchy<TFirst, TSecond>() => HasTypeInHierarchy(typeof(TFirst), typeof(TSecond));
        
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
            
            while (type != null)
            {
                coll.Add(type);
                type = type.BaseType;
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
        public static ICollection<Type> GetInterfacesInHierarchy(Type type)
        {
            var list = new HashSet<Type>();
            AddInterfacesInHierarchy(type, list);
            return list;
        }

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static ICollection<Type> GetInterfacesInHierarchy<T>() => GetInterfacesInHierarchy(typeof(T));

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static void AddInterfacesInHierarchy(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);
            
            if (type.IsInterface) coll.Add(type);
            coll.AddRange(type.GetInterfaces()); // GetInterfaces from .NET is already recursive.
        }

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static void AddInterfacesInHierarchy<T>(ICollection<Type> coll) => AddInterfacesInHierarchy(typeof(T), coll);

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            if (!secondType.IsInterface) throw new Exception($"{nameof(secondType)} {secondType.Name} is not an interface.");
            return GetInterfacesInHierarchy(type).Contains(secondType);
        }
        
        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy<TFirst>(Type secondType) => HasInterfaceInHierarchy(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy<TFirst, TSecond>() => HasInterfaceInHierarchy(typeof(TFirst), typeof(TSecond));
    }
}