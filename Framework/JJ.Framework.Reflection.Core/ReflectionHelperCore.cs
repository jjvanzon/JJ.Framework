using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Collections.Core;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core
{
    public class ReflectionHelperCore
    {
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

        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static ICollection<Type> GetTypesInHierarchy(Type type)
        {
            if (type == null) throw new NullException(() => type);
            var coll = new HashSet<Type>();
            AddTypesInHierarchy(type, coll);
            return coll;
        }
        
        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static ICollection<Type> GetTypesInHierarchy<TType>() => GetTypesInHierarchy(typeof(TType));
    
        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static void AddTypesInHierarchy(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);

            AddClassesInHierarchy(type, coll);
            AddInterfacesInHierarchy(type, coll);
        }
                
        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static void AddTypesInHierarchy<TType>(ICollection<Type> coll) => AddTypesInHierarchy(typeof(TType), coll);

        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static bool HasTypeInHierarchy(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            return GetTypesInHierarchy(type).Contains(secondType);
        }

        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static bool HasTypeInHierarchy<TFirst>(Type secondType) => HasTypeInHierarchy(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="docs._typesinhierarchy" />
        public static bool HasTypeInHierarchy<TFirst, TSecond>() => HasTypeInHierarchy(typeof(TFirst), typeof(TSecond));
        
        // Classes

        /// <inheritdoc cref="_classesinhierarchy" />
        public static ICollection<Type> GetClassesInHierarchy(Type type)
        {
            if (type == null) throw new NullException(() => type);
            var coll = new HashSet<Type>();
            AddClassesInHierarchy(type, coll);
            return coll;
        }

        /// <inheritdoc cref="_classesinhierarchy" />
        public static ICollection<Type> GetClassesInHierarchy<T>() => GetClassesInHierarchy(typeof(T));
        
        /// <inheritdoc cref="_classesinhierarchy" />
        public static void AddClassesInHierarchy(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);

            if (!type.IsClass) return;
            
            while (type != null)
            {
                coll.Add(type);
                type = type.BaseType;
            }
        }

        /// <inheritdoc cref="_classesinhierarchy" />
        public static void AddClassesInHierarchy<T>(ICollection<Type> coll) => AddClassesInHierarchy(typeof(T), coll);

        /// <inheritdoc cref="_classesinhierarchy" />
        public static bool HasClassInHierarchy(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            if (!secondType.IsClass) throw new Exception($"{nameof(secondType)} '{secondType.Name}' is not a class.");
            return GetClassesInHierarchy(type).Contains(secondType);
        }
        
        /// <inheritdoc cref="_classesinhierarchy" />
        public static bool HasClassInHierarchy<TFirst>(Type secondType) => HasClassInHierarchy(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="_classesinhierarchy" />
        public static bool HasClassInHierarchy<TFirst, TSecond>() => HasClassInHierarchy(typeof(TFirst), typeof(TSecond));

        // Interfaces
                
        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static ICollection<Type> GetInterfacesInHierarchy(Type type)
        {
            var list = new HashSet<Type>();
            AddInterfacesInHierarchy(type, list);
            return list;
        }

        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static ICollection<Type> GetInterfacesInHierarchy<T>() => GetInterfacesInHierarchy(typeof(T));

        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static void AddInterfacesInHierarchy(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);
            
            if (type.IsInterface) coll.Add(type);
            coll.AddRange(type.GetInterfaces()); // GetInterfaces from .NET is already recursive.
        }

        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static void AddInterfacesInHierarchy<T>(ICollection<Type> coll) => AddInterfacesInHierarchy(typeof(T), coll);

        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            if (!secondType.IsInterface) throw new Exception($"{nameof(secondType)} {secondType.Name} is not an interface.");
            return GetInterfacesInHierarchy(type).Contains(secondType);
        }
        
        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy<TFirst>(Type secondType) => HasInterfaceInHierarchy(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="docs._interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy<TFirst, TSecond>() => HasInterfaceInHierarchy(typeof(TFirst), typeof(TSecond));
    }
}