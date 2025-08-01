﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Reflection.Legacy
{
    /// <inheritdoc cref="_reflectionhelper" />
    public static class ReflectionHelper
    {
        /// <inheritdoc cref="_bindingflagsall" />
        public const BindingFlags BINDING_FLAGS_ALL =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy;

        // GetImplementation

        private static object _implementationsDictionaryLock = new object();
        private static Dictionary<string, Type[]> _implementationsDictionary = new Dictionary<string, Type[]>();

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type GetImplementation(Assembly assembly, Type baseType)
        {
            Type type = TryGetImplementation(assembly, baseType);

            if (type == null)
            {
                throw new Exception(String.Format("No implementation of type '{0}' found in assembly '{1}'.", baseType, assembly.GetName().Name));
            }

            return type;
        }

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type TryGetImplementation(Assembly assembly, Type baseType)
        {
            Type[] types = GetImplementations(assembly, baseType);

            if (types.Length == 0)
            {
                return null;
            }

            if (types.Length > 1)
            {
                throw new Exception(String.Format("Multiple implementations of type '{0}' found in assembly '{1}'.", baseType, assembly.GetName().Name));
            }

            return types[0];
        }

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type[] GetImplementations(IEnumerable<Assembly> assemblies, Type baseType)
        {
            return assemblies.SelectMany(x => GetImplementations(x, baseType)).ToArray();
        }

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type[] GetImplementations(Assembly assembly, Type baseType)
        {
            if (assembly == null) throw new NullException(() => assembly);
            if (baseType == null) throw new NullException(() => baseType);

            lock (_implementationsDictionaryLock)
            {
                string key = GetImplementationsDictionaryKey(assembly, baseType);
                Type[] types;
                if (!_implementationsDictionary.TryGetValue(key, out types))
                {
                    types = assembly.GetTypes();
                    types = Enumerable.Union(types.Where(x => x.BaseType == baseType),
                                             types.Where(x => x.GetInterface_PlatformSafe(baseType.Name) != null)).ToArray();

                    _implementationsDictionary.Add(key, types);
                }

                return types;
            }
        }

        private static string GetImplementationsDictionaryKey(Assembly assembly, Type baseType)
        {
            // TODO: Is it not a bad plan to hash a large string?
            return assembly.FullName + "$" + baseType.FullName + "$" + baseType.Assembly.FullName;
        }

        // GetItemType

        /// <inheritdoc cref="_getitemtype" />
        [NoTrim(ObjectGetType)]
        public static Type GetItemType(object collection)
        {
            if (collection == null) throw new NullException(() => collection);
            return GetItemType(collection.GetType());
        }

        /// <inheritdoc cref="_getitemtype" />
        [NoTrim(PropertyType)]
        public static Type GetItemType(PropertyInfo collectionProperty)
        {
            if (collectionProperty == null) throw new NullException(() => collectionProperty);
            return GetItemType(collectionProperty.PropertyType);
        }

        /// <inheritdoc cref="_getitemtype" />
        public static Type GetItemType([Dyn(Interfaces)] Type collectionType)
        {
            Type itemType = TryGetItemType(collectionType);
            if (itemType == null)
            {
                throw new Exception(String.Format("Type '{0}' has no item type.", collectionType.Name));
            }
            return itemType;
        }

        private static object _itemTypeDictionaryLock = new object ();
        private static Dictionary<Type, Type> _itemTypeDictionary = new Dictionary<Type, Type>();

        /// <inheritdoc cref="_getitemtype" />
        public static Type TryGetItemType([Dyn(Interfaces)] Type collectionType)
        {
            if (collectionType == null) throw new NullException(() => collectionType);

            lock (_itemTypeDictionaryLock)
            {
                Type itemType;
                if (!_itemTypeDictionary.TryGetValue(collectionType, out itemType))
                {
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
                }

                return itemType;
            }
        }

        // Other

        /// <inheritdoc cref="_typesfromobjects" />
        public static Type[] TypesFromObjects(params ICollection<object> objects)
        {
            object[] arr = objects.ToArray();
            Type[] types = new Type[objects.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                object parameter = arr[i];

                if (parameter != null)
                {
                    types[i] = parameter.GetType();
                }
                else
                {
                    types[i] = typeof(object);
                }
            }
            return types;
        }

        /// <inheritdoc cref="_isindexermethod" />
        public static bool IsIndexerMethod(MethodInfo method)
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

            string propertyName = method.Name.CutLeft("get_").CutLeft("set_");

            Type type = method.DeclaringType;
            var defaultMemberAttribute = (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
            if (defaultMemberAttribute == null)
            {
                return false;
            }

            if (defaultMemberAttribute.MemberName == propertyName)
            {
                return true;
            }

            return false; // ncrunch: no coverage
        }

        /// <inheritdoc cref="_isstatic" />
        public static bool IsStatic(MemberInfo member)
        {
            if (member == null) throw new NullException(() => member);

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
                    MethodInfo getterOrSetter = property.GetGetMethod(nonPublic: true) ?? property.GetSetMethod(nonPublic: true);
                    return getterOrSetter.IsStatic;

                default:
                    throw new Exception(String.Format("IsStatic cannot be obtained from member of type '{0}'.", memberType));
            }
        }

        // Generic overloads

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type GetImplementation<TBaseType>(Assembly assembly)
        {
            return GetImplementation(assembly, typeof(TBaseType));
        }

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type TryGetImplementation<TBaseType>(Assembly assembly)
        {
            return TryGetImplementation(assembly, typeof(TBaseType));
        }

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type[] GetImplementations<TBaseType>(Assembly assembly)
        {
            return GetImplementations(assembly, typeof(TBaseType));
        }

        /// <inheritdoc cref="_getimplementations" />
        [NoTrim(GetTypes)]
        public static Type[] GetImplementations<TBaseType>(IEnumerable<Assembly> assemblies)
        {
            return GetImplementations(assemblies, typeof(TBaseType));
        }
    }
}
