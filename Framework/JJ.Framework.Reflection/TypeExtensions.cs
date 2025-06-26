using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Legacy
{
    public static class TypeExtensions
    {
        // NOTE: Unclear why NCrunch reports this code as uncovered.
        
        // ncrunch: no coverage start
        public static bool IsAssignableTo(this Type type, Type otherType)
        { 
            return otherType.IsAssignableFrom(type);
        }
        // ncrunch: no coverage end
        
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
