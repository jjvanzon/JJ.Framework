﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Text;

namespace JJ.Framework.Reflection
{
    [PublicAPI]
    public static class ReflectionExtensions
    {
        // ItemType

        private static readonly object _itemTypeDictionaryLock = new object();
        private static readonly Dictionary<Type, Type> _itemTypeDictionary = new Dictionary<Type, Type>();

        public static Type GetItemType(this PropertyInfo collectionProperty)
        {
            if (collectionProperty == null) throw new ArgumentNullException(nameof(collectionProperty));
            return GetItemType(collectionProperty.PropertyType);
        }

        public static Type GetItemType(this object collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return GetItemType(collection.GetType());
        }

        public static Type GetItemType(this Type collectionType)
        {
            Type itemType = TryGetItemType(collectionType);

            if (itemType == null)
            {
                throw new Exception($"Type '{collectionType}' has no item type.");
            }

            return itemType;
        }

        public static Type TryGetItemType(this Type collectionType)
        {
            if (collectionType == null) throw new ArgumentNullException(nameof(collectionType));

            lock (_itemTypeDictionaryLock)
            {
                if (_itemTypeDictionary.TryGetValue(collectionType, out Type itemType))
                {
                    return itemType;
                }

                // This works for IEnumerable<T> itself.
                if (collectionType.IsGenericType)
                {
                    Type openGenericCollectionType = collectionType.GetGenericTypeDefinition();

                    if (openGenericCollectionType == typeof(IEnumerable<>))
                    {
                        itemType = collectionType.GetGenericArguments()[0];
                    }
                }

                // This works for types that implement IEnumerable<T> / have IEnumerable<T> as a base.
                Type enumerableInterface = collectionType.GetInterface_PlatformSafe(typeof(IEnumerable<>).FullName);

                if (enumerableInterface != null)
                {
                    itemType = enumerableInterface.GetGenericArguments()[0];
                }

                _itemTypeDictionary.Add(collectionType, itemType);

                return itemType;
            }
        }

        // GetImplementation

        private static readonly object _implementationsDictionaryLock = new object();
        private static readonly Dictionary<string, Type[]> _implementationsDictionary = new Dictionary<string, Type[]>();

        /// <summary>
        /// Allows you to retrieve implementations of a specified base class or interface from an assembly,
        /// which is useful for plug-in development.
        /// </summary>
        public static Type GetImplementation(this Assembly assembly, Type baseType)
        {
            Type type = TryGetImplementation(assembly, baseType);

            if (type == null)
            {
                throw new Exception($"No implementation of type '{baseType}' found in assembly '{assembly.GetName().Name}'.");
            }

            return type;
        }

        /// <summary>
        /// Allows you to retrieve implementations of a specified base class or interface from an assembly,
        /// which is useful for plug-in development.
        /// </summary>
        public static Type TryGetImplementation(this Assembly assembly, Type baseType)
        {
            Type[] types = GetImplementations(assembly, baseType);

            if (types.Length == 0)
            {
                return null;
            }

            if (types.Length > 1)
            {
                throw new Exception($"Multiple implementations of type '{baseType}' found in assembly '{assembly.GetName().Name}'.");
            }

            return types[0];
        }

        /// <summary>
        /// Allows you to retrieve implementations of a specified base class or interface from an assembly,
        /// which is useful for plug-in development.
        /// </summary>
        public static Type[] GetImplementations(this IEnumerable<Assembly> assemblies, Type baseType)
            => assemblies.SelectMany(x => GetImplementations(x, baseType)).ToArray();

        /// <summary>
        /// Allows you to retrieve implementations of a specified base class or interface from an assembly,
        /// which is useful for plug-in development.
        /// </summary>
        public static Type[] GetImplementations(this Assembly assembly, Type baseType)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (baseType == null) throw new ArgumentNullException(nameof(baseType));

            lock (_implementationsDictionaryLock)
            {
                string key = GetImplementationsDictionaryKey(assembly, baseType);

                // ReSharper disable once InvertIf
                if (!_implementationsDictionary.TryGetValue(key, out Type[] types))
                {
                    types = assembly.GetTypes();

                    types = types.Where(x => x.GetBaseClasses().Contains(baseType))
                                 .Union(
                                     types.Where(x => x.GetInterface_PlatformSafe(baseType.Name) != null))
                                 .ToArray();

                    _implementationsDictionary.Add(key, types);
                }

                return types;
            }
        }

        private static string GetImplementationsDictionaryKey(this Assembly assembly, Type baseType)
            => assembly.FullName + "$" + baseType.FullName + "$" + baseType.Assembly.FullName;

        // Generic overloads

        public static Type GetImplementation<TBaseType>(this Assembly assembly) => GetImplementation(assembly, typeof(TBaseType));

        public static Type TryGetImplementation<TBaseType>(this Assembly assembly) => TryGetImplementation(assembly, typeof(TBaseType));

        public static IList<Type> GetImplementations<TBaseType>(this Assembly assembly) => GetImplementations(assembly, typeof(TBaseType));

        public static IList<Type> GetImplementations<TBaseType>(this IEnumerable<Assembly> assemblies)
            => GetImplementations(assemblies, typeof(TBaseType));

        // Misc


        /// <summary> Returns a type's base type and its base type etc. </summary>
        public static IList<Type> GetBaseClasses(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            var types = new List<Type>();

            while (type.BaseType != null)
            {
                types.Add(type.BaseType);

                type = type.BaseType;
            }

            return types;
        }

        /// <summary>
        /// Type.GetProperty returns null if the property does not exist.
        /// This method is a little safer than that and throws a clear exception if the property does not exist.
        /// </summary>
        public static PropertyInfo GetPropertyOrException(this Type type, string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            PropertyInfo property = type.GetProperty(name);
            if (property == null) throw new Exception($"Property '{name}' not found on type '{type}'.");
            return property;
        }

        /// <summary>
        /// Slightly faster than Nullable.GetUnderlyingType, but gives false positives if the type is not nullable to begin with.
        /// </summary>
        public static Type GetUnderlyingNullableTypeFast(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            // For performance, do not check if it is a nullable type.
            return type.GetGenericArguments()[0];
        }

        /// <summary> Returns the property value. For static properties this will work without an object parameter. </summary>
        public static object GetValue(this PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            return property.GetValue(null);
        }

        /// <inheritdoc cref="Invoke(MethodBase, object, object[])" />
        public static object Invoke(this MethodBase methodBase, params object[] parameters) => methodBase.Invoke(null, parameters);

        /// <summary>
        /// Invokes a method or constructor. For static methods this will work without an object parameter.
        /// This overload may allow parameters to be specified with params / variable amount of arguments
        /// </summary>
        public static object Invoke(this MethodBase methodBase, object obj, params object[] parameters)
        {
            if (methodBase == null) throw new ArgumentNullException(nameof(methodBase));
            return methodBase.Invoke(obj, parameters);
        }


        public static bool IsAssignableFrom<T>(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return type.IsAssignableFrom(typeof(T));
        }

        public static bool IsAssignableTo<T>(this Type type) => IsAssignableTo(type, typeof(T));

        public static bool IsAssignableTo(this Type type, Type otherType)
        {
            if (otherType == null) throw new ArgumentNullException(nameof(otherType));

            return otherType.IsAssignableFrom(type);
        }

        public static bool IsIndexer(this MethodBase method)
        {
            if (!method.IsSpecialName)
            {
                return false;
            }

            if (!method.Name.StartsWith("get_") &&
                !method.Name.StartsWith("set_"))
            {
                return false;
            }

            string propertyName = method.Name.TrimStart("get_").TrimStart("set_");

            Type type = method.DeclaringType;

            // ReSharper disable once PossibleNullReferenceException
            var defaultMemberAttribute =
                (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), true).SingleOrDefault();

            if (defaultMemberAttribute == null)
            {
                return false;
            }

            if (defaultMemberAttribute.MemberName == propertyName)
            {
                return true;
            }

            return false;
        }

        public static bool IsNullableType(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static bool IsReferenceType(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return !type.IsValueType;
        }

        public static bool IsProperty(this MethodBase method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));

            bool isProperty = method.Name.StartsWith("get_") ||
                              method.Name.StartsWith("set_");

            return isProperty;
        }

        public static bool IsStatic(this MemberInfo member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));

            MemberTypes_PlatformSafe memberType = member.MemberType_PlatformSafe();

            switch (memberType)
            {
                case MemberTypes_PlatformSafe.Field:
                    var field = (FieldInfo)member;
                    return field.IsStatic;

                case MemberTypes_PlatformSafe.Method:
                    var method = (MethodInfo)member;
                    return method.IsStatic;

                case MemberTypes_PlatformSafe.Property:
                    var property = (PropertyInfo)member;
                    // TODO: Check if this will work for public members.
                    MethodInfo getterOrSetter = property.GetGetMethod(true) ?? property.GetSetMethod(true);
                    return getterOrSetter.IsStatic;

                default:
                    throw new Exception($"IsStatic cannot be obtained from member of type '{member.GetType()}'.");
            }
        }

        /// <summary>
        /// Tells you if a Type is a 'simple type'.
        /// A simple type can be a .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr,
        /// the numeric types, their signed and unsigned variations, but also
        /// String, Guid, DateTime, TimeSpan and Enum types.
        /// </summary>
        public static bool IsSimpleType(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (type.IsPrimitive ||
                type.IsEnum ||
                type == typeof(string) ||
                type == typeof(Guid) ||
                type == typeof(DateTime) ||
                type == typeof(TimeSpan))
            {
                return true;
            }

            if (type.IsNullableType())
            {
                Type underlyingType = type.GetUnderlyingNullableTypeFast();
                return IsSimpleType(underlyingType);
            }

            return false;
        }
    }
}