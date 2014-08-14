using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;

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

        public static Type[] GetImplementations(Assembly assembly, Type baseType)
        {
            // TODO: Caching please.
            Type[] types = assembly.GetTypes();

            return Enumerable.Union(types.Where(x => x.BaseType == baseType),
                                    types.Where(x => x.GetInterface_PlatformSafe(baseType.Name) != null)).ToArray();
        }

        public static Type[] GetImplementations(IEnumerable<Assembly> assemblies, Type baseType)
        {
            return assemblies.SelectMany(x => GetImplementations(x, baseType)).ToArray();
        }

        // GetItemType

        // TODO: ItemTypes are used a lot. Perhaps this should be cached.

        public static Type GetItemType(object collection)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            return GetItemType(collection.GetType());
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

        public static Type TryGetItemType(Type collectionType)
        {
            if (collectionType == null) throw new ArgumentNullException("collectionType");

            // The code after this block does not work for when collectionType is IEnumerable<T> itself,
            // only if collectionType implements IEnumerable<T>.
            if (collectionType.IsGenericType)
            {
                Type openGenericCollectionType = collectionType.GetGenericTypeDefinition();
                if (openGenericCollectionType == typeof(IEnumerable<>))
                {
                    return collectionType.GetGenericArguments()[0];
                }
            }

            Type enumerableInterface = collectionType.GetInterface_PlatformSafe(typeof(IEnumerable<>).FullName);
            if (enumerableInterface != null)
            {
                Type itemType = enumerableInterface.GetGenericArguments()[0];
                return itemType;
            }

            return null;
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
            if (member == null) throw new ArgumentNullException("member");

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

        // Generic overloads

        public static Type GetImplementation<TBaseType>(Assembly assembly)
        {
            return GetImplementation(assembly, typeof(TBaseType));
        }

        public static Type TryGetImplementation<TBaseType>(Assembly assembly)
        {
            return TryGetImplementation(assembly, typeof(TBaseType));
        }

        public static Type[] GetImplementations<TBaseType>(Assembly assembly)
        {
            return GetImplementations(assembly, typeof(TBaseType));
        }

        public static Type[] GetImplementations<TBaseType>(IEnumerable<Assembly> assemblies)
        {
            return GetImplementations(assemblies, typeof(TBaseType));
        }
    }
}
