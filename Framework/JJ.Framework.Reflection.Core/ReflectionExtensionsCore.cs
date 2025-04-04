using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    public static class ReflectionExtensionsCore
    {
        // Fields

        /// <summary>
        /// Type.GetField returns null if the field does not exist.
        /// This method is a little safer than that and throws a clear exception if the field does not exist.
        /// </summary>
        public static FieldInfo GetFieldOrException(this Type type, string name)
            => ReflectionHelperCore.GetFieldOrException(type, name);
        
        // Types
        
        /// <inheritdoc cref="docs._typesrecursive" />
        public static ICollection<Type> GetTypesRecursive(this Type type)
            => ReflectionHelperCore.GetTypesRecursive(type);

        /// <inheritdoc cref="docs._typesrecursive" />
        public static void AddTypesRecursive(this Type type, ICollection<Type> coll)
            => ReflectionHelperCore.AddTypesRecursive(type, coll);

        /// <inheritdoc cref="docs._typesrecursive" />
        public static bool HasTypeRecursive(this Type type, Type type2)
            => ReflectionHelperCore.HasTypeRecursive(type, type2);
        
        public static bool HasTypeRecursive<TSecondType>(this Type firstType) 
            => ReflectionHelperCore.HasTypeRecursive(firstType, typeof(TSecondType));

        // Classes

        /// <inheritdoc cref="docs._classesrecursive" />
        public static ICollection<Type> GetClassesRecursive(this Type type)
            => ReflectionHelperCore.GetClassesRecursive(type);

        /// <inheritdoc cref="docs._classesrecursive" />
        public static void AddClassesRecursive(this Type type, ICollection<Type> coll)
            => ReflectionHelperCore.AddClassesRecursive(type, coll);
        
        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive(this Type type, Type type2)
            => ReflectionHelperCore.HasClassRecursive(type, type2);

        /// <inheritdoc cref="docs._classesrecursive" />
        public static bool HasClassRecursive<TSecond>(this Type first)
            => ReflectionHelperCore.HasClassRecursive(first, typeof(TSecond));

        // Interfaces

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static ICollection<Type> GetInterfacesRecursive(this Type type)
            => ReflectionHelperCore.GetInterfacesRecursive(type);

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static void AddInterfacesRecursive(this Type type, ICollection<Type> coll)
            => ReflectionHelperCore.AddInterfacesRecursive(type, coll);
        
        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive(this Type type, Type type2)
            => ReflectionHelperCore.HasInterfaceRecursive(type, type2);

        /// <inheritdoc cref="docs._interfacesrecursive" />
        public static bool HasInterfaceRecursive<TSecond>(this Type first)
            => ReflectionHelperCore.HasInterfaceRecursive(first, typeof(TSecond));
    }
}
