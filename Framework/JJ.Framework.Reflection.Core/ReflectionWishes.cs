using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Collections.Core;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core
{
    public class ReflectionWishes
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

        /// <inheritdoc cref="docs._typesrecursive" />
        public static ICollection<Type> GetTypesRecursive(Type type)
        {
            if (type == null) throw new NullException(() => type);
            var coll = new HashSet<Type>();
            AddTypesRecursive(type, coll);
            return coll;
        }
        
        /// <inheritdoc cref="docs._typesrecursive" />
        public static ICollection<Type> GetTypesRecursive<TType>() => GetTypesRecursive(typeof(TType));
    
        /// <inheritdoc cref="docs._typesrecursive" />
        public static void AddTypesRecursive(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);

            AddClassesRecursive(type, coll);
            AddInterfacesRecursive(type, coll);
        }
                
        /// <inheritdoc cref="docs._typesrecursive" />
        public static void AddTypesRecursive<TType>(ICollection<Type> coll) => AddTypesRecursive(typeof(TType), coll);

        /// <inheritdoc cref="docs._typesrecursive" />
        public static bool HasTypeRecursive(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            return GetTypesRecursive(type).Contains(secondType);
        }

        /// <inheritdoc cref="docs._typesrecursive" />
        public static bool HasTypeRecursive<TFirst>(Type secondType) => HasTypeRecursive(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="docs._typesrecursive" />
        public static bool HasTypeRecursive<TFirst, TSecond>() => HasTypeRecursive(typeof(TFirst), typeof(TSecond));
        
        // Classes

        /// <inheritdoc cref="docs._classesrecursive" />
        public static ICollection<Type> GetClassesRecursive(Type type)
        {
            if (type == null) throw new NullException(() => type);
            var coll = new HashSet<Type>();
            AddClassesRecursive(type, coll);
            return coll;
        }

        /// <inheritdoc cref="docs._classesrecursive" />
        public static ICollection<Type> GetClassesRecursive<T>() => GetClassesRecursive(typeof(T));
        
        /// <inheritdoc cref="docs._classesrecursive" />
        public static void AddClassesRecursive(Type type, ICollection<Type> coll)
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

        /// <inheritdoc cref="docs._classesrecursive" />
        public static void AddClassesRecursive<T>(ICollection<Type> coll) => AddClassesRecursive(typeof(T), coll);

        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            if (!secondType.IsClass) throw new Exception($"{nameof(secondType)} '{secondType.Name}' is not a class.");
            return GetClassesRecursive(type).Contains(secondType);
        }
        
        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive<TFirst>(Type secondType) => HasClassRecursive(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive<TFirst, TSecond>() => HasClassRecursive(typeof(TFirst), typeof(TSecond));

        // Interfaces
                
        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static ICollection<Type> GetInterfacesRecursive(Type type)
        {
            var list = new HashSet<Type>();
            AddInterfacesRecursive(type, list);
            return list;
        }

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static ICollection<Type> GetInterfacesRecursive<T>() => GetInterfacesRecursive(typeof(T));

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static void AddInterfacesRecursive(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);
            
            if (type.IsInterface) coll.Add(type);
            coll.AddRange(type.GetInterfaces()); // GetInterfaces from .NET is already recursive.
        }

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static void AddInterfacesRecursive<T>(ICollection<Type> coll) => AddInterfacesRecursive(typeof(T), coll);

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive(Type type, Type secondType)
        {
            if (secondType == null) throw new NullException(() => secondType);
            if (!secondType.IsInterface) throw new Exception($"{nameof(secondType)} {secondType.Name} is not an interface.");
            return GetInterfacesRecursive(type).Contains(secondType);
        }
        
        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive<TFirst>(Type secondType) => HasInterfaceRecursive(typeof(TFirst), secondType);
        
        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive<TFirst, TSecond>() => HasInterfaceRecursive(typeof(TFirst), typeof(TSecond));
    }
}