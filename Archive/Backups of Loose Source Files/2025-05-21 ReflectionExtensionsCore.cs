namespace JJ.Framework.Reflection.Core
{
    // TODO: Move together with static methods in the same file.
    public static partial class ReflectExtensions
    {
        // Types
        
        /// <inheritdoc cref="_typesinhierarchy" />
        public static ICollection<Type> GetTypesInHierarchy(this Type type)
            => Reflect.GetTypesInHierarchy(type);

        /// <inheritdoc cref="_typesinhierarchy" />
        public static void AddTypesInHierarchy(this Type type, ICollection<Type> coll)
            => Reflect.AddTypesInHierarchy(type, coll);

        /// <inheritdoc cref="_typesinhierarchy" />
        public static bool HasTypeInHierarchy(this Type type, Type type2)
            => Reflect.HasTypeInHierarchy(type, type2);
        
        public static bool HasTypeInHierarchy<TSecondType>(this Type firstType) 
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
        public static ICollection<Type> GetInterfacesInHierarchy(this Type type)
            => Reflect.GetInterfacesInHierarchy(type);

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static void AddInterfacesInHierarchy(this Type type, ICollection<Type> coll)
            => Reflect.AddInterfacesInHierarchy(type, coll);
        
        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy(this Type type, Type type2)
            => Reflect.HasInterfaceInHierarchy(type, type2);

        /// <inheritdoc cref="_interfacesinhierarchy" />
        public static bool HasInterfaceInHierarchy<TSecond>(this Type first)
            => Reflect.HasInterfaceInHierarchy(first, typeof(TSecond));
    }
}
