using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    public static class ReflectionExtensionWishes
    {
        // Fields

        /// <summary>
        /// Type.GetField returns null if the field does not exist.
        /// This method is a little safer than that and throws a clear exception if the field does not exist.
        /// </summary>
        public static FieldInfo GetFieldOrException(this Type type, string name)
            => ReflectionWishes.GetFieldOrException(type, name);
        
        // Types
        
        /// <inheritdoc cref="docs._typesrecursive" />
        public static ICollection<Type> GetTypesRecursive(this Type type)
            => ReflectionWishes.GetTypesRecursive(type);

        /// <inheritdoc cref="docs._typesrecursive" />
        public static void AddTypesRecursive(this Type type, ICollection<Type> coll)
            => ReflectionWishes.AddTypesRecursive(type, coll);

        /// <inheritdoc cref="docs._typesrecursive" />
        public static bool HasTypeRecursive(this Type type, Type type2)
            => ReflectionWishes.HasTypeRecursive(type, type2);
        
        public static bool HasTypeRecursive<TSecondType>(this Type firstType) 
            => ReflectionWishes.HasTypeRecursive(firstType, typeof(TSecondType));

        // Classes

        /// <inheritdoc cref="docs._classesrecursive" />
        public static ICollection<Type> GetClassesRecursive(this Type type)
            => ReflectionWishes.GetClassesRecursive(type);

        /// <inheritdoc cref="docs._classesrecursive" />
        public static void AddClassesRecursive(this Type type, ICollection<Type> coll)
            => ReflectionWishes.AddClassesRecursive(type, coll);
        
        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive(this Type type, Type type2)
            => ReflectionWishes.HasClassRecursive(type, type2);

        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive<TSecond>(this Type first)
            => ReflectionWishes.HasClassRecursive(first, typeof(TSecond));

        // Interfaces

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static ICollection<Type> GetInterfacesRecursive(this Type type)
            => ReflectionWishes.GetInterfacesRecursive(type);

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static void AddInterfacesRecursive(this Type type, ICollection<Type> coll)
            => ReflectionWishes.AddInterfacesRecursive(type, coll);
        
        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive(this Type type, Type type2)
            => ReflectionWishes.HasInterfaceRecursive(type, type2);

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive<TSecond>(this Type first)
            => ReflectionWishes.HasInterfaceRecursive(first, typeof(TSecond));
    }
}
