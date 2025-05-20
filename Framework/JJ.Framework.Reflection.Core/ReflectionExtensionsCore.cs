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
        
        /// <inheritdoc cref="_typesinhierarchy" />
        public static ICollection<Type> GetTypesInHierarchy(this Type type)
            => ReflectionHelperCore.GetTypesInHierarchy(type);

        /// <inheritdoc cref="_typesinhierarchy" />
        public static void AddTypesInHierarchy(this Type type, ICollection<Type> coll)
            => ReflectionHelperCore.AddTypesInHierarchy(type, coll);

        /// <inheritdoc cref="_typesinhierarchy" />
        public static bool HasTypeInHierarchy(this Type type, Type type2)
            => ReflectionHelperCore.HasTypeInHierarchy(type, type2);
        
        public static bool HasTypeInHierarchy<TSecondType>(this Type firstType) 
            => ReflectionHelperCore.HasTypeInHierarchy(firstType, typeof(TSecondType));

        // Classes

        /// <inheritdoc cref="_classesinhierarchy" />
        public static ICollection<Type> GetClassesInHierarchy(this Type type)
            => ReflectionHelperCore.GetClassesInHierarchy(type);

        /// <inheritdoc cref="_classesinhierarchy" />
        public static void AddClassesInHierarchy(this Type type, ICollection<Type> coll)
            => ReflectionHelperCore.AddClassesInHierarchy(type, coll);
        
        /// <inheritdoc cref="_classesinhierarchy" />
        public static bool HasClassInHierarchy(this Type type, Type type2)
            => ReflectionHelperCore.HasClassInHierarchy(type, type2);

        /// <inheritdoc cref="_classesinhierarchy" />
        public static bool HasClassInHierarchy<TSecond>(this Type first)
            => ReflectionHelperCore.HasClassInHierarchy(first, typeof(TSecond));

        // Interfaces

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static ICollection<Type> GetInterfacesInHierarchy(this Type type)
            => ReflectionHelperCore.GetInterfacesInHierarchy(type);

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static void AddInterfacesInHierarchy(this Type type, ICollection<Type> coll)
            => ReflectionHelperCore.AddInterfacesInHierarchy(type, coll);
        
        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy(this Type type, Type type2)
            => ReflectionHelperCore.HasInterfaceInHierarchy(type, type2);

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy<TSecond>(this Type first)
            => ReflectionHelperCore.HasInterfaceInHierarchy(first, typeof(TSecond));
    }
}
