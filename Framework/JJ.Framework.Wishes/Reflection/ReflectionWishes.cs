using System.Reflection;
using System;
using JJ.Framework.Reflection;
using System.Collections.Generic;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Wishes.Reflection
{
    public class ReflectionWishes
    {
        // Assemblies

        public static string GetAssemblyName<TType>()
            => typeof(TType).Assembly.GetName().Name;

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
        public static void AddTypesRecursive(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);

            AddClassesRecursive(type, coll);
            AddInterfacesRecursive(type, coll);
        }

        /// <inheritdoc cref="docs._typesrecursive" />
        public static bool HasTypeRecursive(Type type, Type type2)
        {
            if (type2 == null) throw new NullException(() => type2);
            return GetTypesRecursive(type).Contains(type2);
        }

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
        public static bool HasClassRecursive(Type type, Type type2)
        {
            if (type2 == null) throw new NullException(() => type2);
            if (!type2.IsClass) throw new Exception($"{nameof(type2)} {type2.Name} is not a class.");
            return GetClassesRecursive(type).Contains(type2);
        }

        // Interfaces

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static ICollection<Type> GetInterfacesRecursive(Type type)
        {
            var list = new HashSet<Type>();
            AddInterfacesRecursive(type, list);
            return list;
        }

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static void AddInterfacesRecursive(Type type, ICollection<Type> coll)
        {
            if (type == null) throw new NullException(() => type);
            if (coll == null) throw new NullException(() => coll);
            
            if (type.IsInterface) coll.Add(type);
            
            foreach (var deeperType in type.GetInterfaces())
            {
                AddInterfacesRecursive(deeperType, coll);
            }
        }

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive(Type type, Type type2)
        {
            if (type2 == null) throw new NullException(() => type2);
            if (!type2.IsInterface) throw new Exception($"{nameof(type2)} {type2.Name} is not an interface.");
            return GetInterfacesRecursive(type).Contains(type2);
        }
    }
}