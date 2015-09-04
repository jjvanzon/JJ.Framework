using JJ.Framework.Reflection.Exceptions;
using System;
using System.Reflection;

namespace JJ.Framework.Reflection
{
    public static class TypeExtensions
    {
        public static bool IsAssignableTo(this Type type, Type otherType)
        {
            if (otherType == null) throw new NullException(() => otherType);

            return otherType.IsAssignableFrom(type);
        }

        public static bool IsNullableType(this Type type)
        {
            if (type == null) throw new NullException(() => type);

            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetUnderlyingNullableType(this Type type)
        {
            if (type == null) throw new NullException(() => type);

            // For performance, do not check if it is a nullable type.
            return type.GetGenericArguments()[0];
        }

        public static bool IsReferenceType(this Type type)
        {
            if (type == null) throw new NullException(() => type);

            return !type.IsValueType;
        }

        public static Type GetItemType(this PropertyInfo collectionProperty)
        {
            return ReflectionHelper.GetItemType(collectionProperty);
        }

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
