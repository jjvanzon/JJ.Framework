using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Legacy
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeExtensions
    {
        // NOTE: Unclear why NCrunch reports this code as uncovered.
        
        // ncrunch: no coverage start
        /// <inheritdoc cref="_isassignableto"/>
        public static bool IsAssignableTo(this Type type, Type otherType)
        { 
            return otherType.IsAssignableFrom(type);
        }
        // ncrunch: no coverage end
        
        /// <inheritdoc cref="_isnullabletype" />
        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        
        /// <inheritdoc cref="_getunderlyingnullabletype" />
        public static Type GetUnderlyingNullableType(this Type type)
        {
            // For performance, do not check if it is a nullable type.
            return type.GetGenericArguments()[0];
        }

        /// <inheritdoc cref="_isreferencetype" />
        public static bool IsReferenceType(this Type type)
        {
            return !type.IsValueType;
        }

        /// <inheritdoc cref="_getitemtype" />
        [NoTrim(PropertyType)]
        public static Type GetItemType(this PropertyInfo collectionProperty)
        {
            return ReflectionHelper.GetItemType(collectionProperty);
        }

        /// <inheritdoc cref="_getitemtype" />
        [NoTrim(ObjectGetType)]
        public static Type GetItemType(this object collection)
        {
            return ReflectionHelper.GetItemType(collection);
        }

        /// <inheritdoc cref="_getitemtype" />
        public static Type GetItemType([Dyn(Interfaces)] this Type collectionType)
        {
            return ReflectionHelper.GetItemType(collectionType);
        }

        /// <inheritdoc cref="_getitemtype" />
        public static Type TryGetItemType([Dyn(Interfaces)] this Type collectionType)
        {
            return ReflectionHelper.TryGetItemType(collectionType);
        }
    }
}
