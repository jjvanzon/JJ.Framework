using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection
{
    public static class TypeExtensions
    {
        public static bool IsAssignableTo(this Type type, Type otherType)
        {
            return otherType.IsAssignableFrom(type);
        }

        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetUnderlyingNullableType(this Type type)
        {
            // For performance, do not check if it is a nullable type.
            return type.GetGenericArguments()[0];
        }

        public static bool IsReferenceType(this Type type)
        {
            return !type.IsValueType;
        }

        // TODO: ItemTypes are used a lot. Perhaps this should be cached.

        public static Type GetItemType(this object collection)
        {
            return ReflectionHelper.GetItemType(collection);
        }

        public static Type GetItemType(this Type collectionType)
        {
            return ReflectionHelper.GetItemType(collectionType);
        }

        public static Type TryGetItemType(this Type collectionType)
        {
            return ReflectionHelper.TryGetItemType(collectionType);
        }
    }
}
