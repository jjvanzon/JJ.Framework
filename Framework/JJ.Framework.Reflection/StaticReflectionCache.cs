using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Reflection.Legacy
{
    // Outcommented: Deprecating this makes no sense if ReflectionCache does not fully replace it.
    //[Obsolete("May not give much performance gain because the dictionaries use complex keys. You might want to use ReflectionCache instead.")]
    /// <inheritdoc cref="_reflectioncache" />
    public static class StaticReflectionCache
    {
        // TODO: The use of these Tuples as keys (or at least the ones in JJ.Framework.PlatformCompatibility), are not fast dictionary keys.
        // Use a different approach to reflection caching (like in ReflectionCacheDemo) and test what happens when you use .NET's own Tuple class.

        // Fields

        private static Dictionary<Tuple_PlatformSupport<Type, BindingFlags>, FieldInfo[]> _fieldsIndex = new Dictionary<Tuple_PlatformSupport<Type, BindingFlags>, FieldInfo[]>();
        private static object _fieldsIndexLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static FieldInfo[] GetFields([Dyn(AllFields)] Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_fieldsIndexLock)
            {
                var key = new Tuple_PlatformSupport<Type, BindingFlags>(type, bindingFlags);
                if (_fieldsIndex.ContainsKey(key))
                {
                    return _fieldsIndex[key];
                }
                else
                {
                    FieldInfo[] fields = type.GetFields(bindingFlags);
                    _fieldsIndex[key] = fields;
                    return fields;
                }
            }
        }

        private static Dictionary<Tuple_PlatformSupport<Type, string>, FieldInfo> _fieldIndex = new Dictionary<Tuple_PlatformSupport<Type, string>, FieldInfo>();
        private static object _fieldIndexLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static FieldInfo GetField([Dyn(AllFields)] Type type, string name)
        {
            FieldInfo field = TryGetField(type, name);
            if (field == null)
            {
                throw new Exception(String.Format("Field '{0}' not found.", name));
            }
            return field;
        }

        /// <inheritdoc cref="_reflectioncache" />
        public static FieldInfo TryGetField([Dyn(AllFields)] Type type, string name)
        {
            lock (_fieldIndexLock)
            {
                var key = new Tuple_PlatformSupport<Type, string>(type, name);
                if (_fieldIndex.ContainsKey(key))
                {
                    return _fieldIndex[key];
                }
                else
                {
                    FieldInfo field = type.GetField(name, ReflectionHelper.BINDING_FLAGS_ALL);
                    _fieldIndex[key] = field;
                    return field;
                }
            }
        }

        // Properties

        private static Dictionary<Tuple_PlatformSupport<Type, BindingFlags>, PropertyInfo[]> _propertiesIndex = new Dictionary<Tuple_PlatformSupport<Type, BindingFlags>, PropertyInfo[]>();
        private static object _propertiesIndexLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static PropertyInfo[] GetProperties([Dyn(AllProperties)] Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_propertiesIndexLock)
            {
                var key = new Tuple_PlatformSupport<Type, BindingFlags>(type, bindingFlags);
                if (_propertiesIndex.ContainsKey(key))
                {
                    return _propertiesIndex[key];
                }
                else
                {
                    PropertyInfo[] properties = type.GetProperties(bindingFlags);
                    _propertiesIndex[key] = properties;
                    return properties;
                }
            }
        }

        private static Dictionary<Tuple_PlatformSupport<Type, string>, PropertyInfo> _propertyIndex = new Dictionary<Tuple_PlatformSupport<Type, string>, PropertyInfo>();
        private static object _propertyIndexLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static PropertyInfo GetProperty([Dyn(AllProperties)] Type type, string name)
        {
            PropertyInfo property = TryGetProperty(type, name);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found.", name));
            }
            return property;
        }

        /// <inheritdoc cref="_reflectioncache" />
        public static PropertyInfo TryGetProperty([Dyn(AllProperties)] Type type, string name)
        {
            lock (_propertyIndexLock)
            {
                var key = new Tuple_PlatformSupport<Type, string>(type, name);
                if (_propertyIndex.ContainsKey(key))
                {
                    return _propertyIndex[key];
                }
                else
                {
                    PropertyInfo property = type.GetProperty(name, ReflectionHelper.BINDING_FLAGS_ALL);
                    _propertyIndex[key] = property;
                    return property;
                }
            }
        }

        // Indexers

        private static Dictionary<Tuple_PlatformSupport<Type, string>, PropertyInfo> _indexerIndex = new Dictionary<Tuple_PlatformSupport<Type, string>, PropertyInfo>();
        private static object _indexerIndexLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static PropertyInfo GetIndexer([Dyn(AllProperties)] Type type, params Type[] parameterTypes)
        {
            PropertyInfo property = TryGetIndexer(type, parameterTypes);
            if (property == null)
            {
                throw new Exception(String.Format("Indexer not found with parameterTypes '{0}'.", String_PlatformSupport.Join(", ", parameterTypes.Select(x => x.ToString()))));
            }
            return property;
        }

        /// <inheritdoc cref="_reflectioncache" />
        public static PropertyInfo TryGetIndexer([Dyn(AllProperties)] Type type, params Type[] parameterTypes)
        {
            if (parameterTypes == null) throw new NullException(() => parameterTypes);
            if (parameterTypes.Length == 0) throw new ArgumentException("parameterTypes cannot be empty.");

            string parameterTypesKey = KeyHelper.CreateKey(parameterTypes);

            lock (_indexerIndexLock)
            {
                var key = new Tuple_PlatformSupport<Type, string>(type, parameterTypesKey);
                if (_indexerIndex.ContainsKey(key))
                {
                    return _indexerIndex[key];
                }
                else
                {
                    var defaultMemberAttribute = (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
                    if (defaultMemberAttribute == null)
                    {
                        return null;
                    }
                    string name = defaultMemberAttribute.MemberName;
                    PropertyInfo property = type.GetProperty(name, ReflectionHelper.BINDING_FLAGS_ALL, null, null, parameterTypes, null);
                    _indexerIndex[key] = property;
                    return property;
                }
            }
        }

        // Methods

        private static Dictionary<Tuple_PlatformSupport<Type, BindingFlags>, MethodInfo[]> _methodsIndex = new Dictionary<Tuple_PlatformSupport<Type, BindingFlags>, MethodInfo[]>();
        private static object _methodsIndexLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static MethodInfo[] GetMethods([Dyn(AllMethods)] Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_methodsIndexLock)
            {
                var key = new Tuple_PlatformSupport<Type, BindingFlags>(type, bindingFlags);
                if (_methodsIndex.ContainsKey(key))
                {
                    return _methodsIndex[key];
                }
                else
                {
                    MethodInfo[] methods = type.GetMethods(bindingFlags);
                    _methodsIndex[key] = methods;
                    return methods;
                }
            }
        }

        private static Dictionary<Tuple_PlatformSupport<Type, string, string>, MethodInfo> _methodDictionary = new Dictionary<Tuple_PlatformSupport<Type, string, string>, MethodInfo>();
        private static object _methodDictionaryLock = new object();

        /// <inheritdoc cref="_reflectioncache" />
        public static MethodInfo GetMethod([Dyn(AllMethods)] Type type, string name, params Type[] parameterTypes)
        {
            MethodInfo method = TryGetMethod(type, name, parameterTypes);
            if (method == null)
            {
                throw new Exception(String.Format("Method '{0}' not found.", name));
            }
            return method;
        }

        /// <inheritdoc cref="_reflectioncache" />
        public static MethodInfo TryGetMethod([Dyn(AllMethods)] Type type, string name, params Type[] parameterTypes)
        {
            if (parameterTypes == null) throw new NullException(() => parameterTypes);
            
            string parameterTypesKey = KeyHelper.CreateKey(parameterTypes);

            lock (_methodDictionaryLock)
            {
                var key = new Tuple_PlatformSupport<Type, string, string>(type, name, parameterTypesKey);
                if (_methodDictionary.ContainsKey(key))
                {
                    return _methodDictionary[key];
                }
                else
                {
                    MethodInfo method = type.GetMethod(name, ReflectionHelper.BINDING_FLAGS_ALL, null, parameterTypes, null);
                    _methodDictionary[key] = method;
                    return method;
                }
            }
        }
    }
}
