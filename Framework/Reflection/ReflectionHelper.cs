using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JJ.Framework.Common;
using JJ.Framework.Common.Exceptions;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection.Exceptions;

namespace JJ.Framework.Reflection
{
    public static class ReflectionHelper
    {
        public const BindingFlags BINDING_FLAGS_ALL =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy;

        // GetImplementation

        private static object _implementationsDictionaryLock = new object();
        private static Dictionary<string, Type[]> _implementationsDictionary = new Dictionary<string, Type[]>();

        public static Type GetImplementation(Assembly assembly, Type baseType)
        {
            Type type = TryGetImplementation(assembly, baseType);

            if (type == null)
            {
                throw new Exception(String.Format("No implementation of type '{0}' found in assembly '{1}'.", baseType, assembly.GetName().Name));
            }

            return type;
        }

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

        public static Type[] GetImplementations(IEnumerable<Assembly> assemblies, Type baseType)
        {
            return assemblies.SelectMany(x => GetImplementations(x, baseType)).ToArray();
        }

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

        public static Type GetItemType(object collection)
        {
            if (collection == null) throw new NullException(() => collection);
            return GetItemType(collection.GetType());
        }

        public static Type GetItemType(PropertyInfo collectionProperty)
        {
            if (collectionProperty == null) throw new NullException(() => collectionProperty);
            return GetItemType(collectionProperty.PropertyType);
        }

        public static Type GetItemType(Type collectionType)
        {
            Type itemType = TryGetItemType(collectionType);
            if (itemType == null)
            {
                throw new Exception(String.Format("Type '{0}' has no item type.", collectionType.GetType().Name));
            }
            return itemType;
        }

        private static object _itemTypeDictionaryLock = new object ();
        private static Dictionary<Type, Type> _itemTypeDictionary = new Dictionary<Type, Type>();

        public static Type TryGetItemType(Type collectionType)
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

        public static Type[] TypesFromObjects(params object[] objects)
        {
            Type[] types = new Type[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                object parameter = objects[i];

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

            return false;
        }

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
                    throw new Exception(String.Format("IsStatic cannot be obtained from member of type '{0}'.", member.GetType().Name));
            }
        }

        public static bool IsDefault(object value)
        {
            if (value == null)
            {
                // A little dirty, because you cannot really say that null is the default per se.
                return true;
            }

            Type type = value.GetType();
            object defaultValue = Activator.CreateInstance(type);

            return Equals(value, defaultValue);
        }

        public static object CreateInstance(string typeName, params object[] args)
        {
            Type type = Type.GetType(typeName);

            if (type == null)
            {
                throw new TypeNotFoundException(typeName);
            }

            object obj = Activator.CreateInstance(type, args);

            return obj;
        }

        public static IList<Type> GetTypeAndBaseClasses(Type type)
        {
            if (type == null) throw new NullException(() => type);

            var types = new List<Type>();
            types.Add(type);

            Type tempType = type;

            while (type.BaseType != null)
            {
                type = type.BaseType;

                types.Add(type);
            }

            return types;
        }

        // Generic overloads

        public static Type GetImplementation<TBaseType>(Assembly assembly)
        {
            return GetImplementation(assembly, typeof(TBaseType));
        }

        public static Type TryGetImplementation<TBaseType>(Assembly assembly)
        {
            return TryGetImplementation(assembly, typeof(TBaseType));
        }

        public static IList<Type> GetImplementations<TBaseType>(Assembly assembly)
        {
            return GetImplementations(assembly, typeof(TBaseType));
        }

        public static IList<Type> GetImplementations<TBaseType>(IEnumerable<Assembly> assemblies)
        {
            return GetImplementations(assemblies, typeof(TBaseType));
        }
    }
}
