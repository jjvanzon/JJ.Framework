using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Common;

namespace JJ.Framework.Reflection
{
    public static class ReflectionHelper
    {
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
            Type[] types = assembly.GetTypes();

            return Enumerable.Union(types.Where(x => x.BaseType == baseType),
                                    types.Where(x => x.GetInterface(baseType.Name) != null)).ToArray();
        }

        public static Type[] GetImplementations(IEnumerable<Assembly> assemblies, Type baseType)
        {
            return assemblies.SelectMany(x => GetImplementations(x, baseType)).ToArray();
        }

        // GetItemType

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

            Type enumerableInterface = collectionType.GetInterface(typeof(IEnumerable<>).FullName);
            if (enumerableInterface != null)
            {
                Type itemType = enumerableInterface.GetGenericArguments()[0];
                return itemType;
            }

            return null;
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
