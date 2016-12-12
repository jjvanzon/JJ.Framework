using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace JJ.Demos.ReflectionCache
{
    public class ReflectionCache_Adapted
    {
        // Dictionary of composite struct type may give bad performance.
        // I wonder how it compares to an actual Tuple of .NET 4.0.
        // ContainsKey and [] on dictionary seem much slower than TryGetValue and Add.

        private BindingFlags _bindingFlags;

        public ReflectionCache_Adapted(BindingFlags bindingFlags)
        {
            _bindingFlags = bindingFlags;
        }

        private const BindingFlags BINDING_FLAGS_ALL =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy;

        // Properties

        private Dictionary<Type, PropertyInfo[]> _propertiesDictionary = new Dictionary<Type, PropertyInfo[]>();
        private object _propertiesDictionaryLock = new object();

        public PropertyInfo[] GetProperties(Type type)
        {
            lock (_propertiesDictionaryLock)
            {
                PropertyInfo[] properties;
                if (!_propertiesDictionary.TryGetValue(type, out properties))
                {
                    properties = type.GetProperties(_bindingFlags);
                    _propertiesDictionary.Add(type, properties);
                }
                return properties;
            }
        }

        private Dictionary<Tuple<Type, string>, PropertyInfo> _propertyDictionary = new Dictionary<Tuple<Type, string>, PropertyInfo>();
        private object _propertyDictionaryLock = new object();

        public PropertyInfo GetProperty(Type type, string name)
        {
            PropertyInfo property = TryGetProperty(type, name);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found.", name));
            }
            return property;
        }

        public PropertyInfo TryGetProperty(Type type, string name)
        {
            lock (_propertyDictionaryLock)
            {
                var key = new Tuple<Type, string>(type, name);
                if (_propertyDictionary.ContainsKey(key))
                {
                    return _propertyDictionary[key];
                }
                else
                {
                    PropertyInfo property = type.GetProperty(name, _bindingFlags);
                    _propertyDictionary[key] = property;
                    return property;
                }
            }
        }

        // Fields

        private Dictionary<Type, FieldInfo[]> _fieldsDictionary = new Dictionary<Type, FieldInfo[]>();
        private object _fieldsDictionaryLock = new object();

        public FieldInfo[] GetFields(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_fieldsDictionaryLock)
            {
                FieldInfo[] fields;
                if (!_fieldsDictionary.TryGetValue(type, out fields))
                {
                    fields = type.GetFields(_bindingFlags);
                    _fieldsDictionary.Add(type, fields);
                }
                return fields;
            }
        }

        private Dictionary<Tuple<Type, string>, FieldInfo> _fieldDictionary = new Dictionary<Tuple<Type, string>, FieldInfo>();
        private object _fieldDictionaryLock = new object();

        public FieldInfo GetField(Type type, string name)
        {
            FieldInfo field = TryGetField(type, name);
            if (field == null)
            {
                throw new Exception(String.Format("Field '{0}' not found.", name));
            }
            return field;
        }

        public FieldInfo TryGetField(Type type, string name)
        {
            lock (_fieldDictionaryLock)
            {
                var key = new Tuple<Type, string>(type, name);
                if (_fieldDictionary.ContainsKey(key))
                {
                    return _fieldDictionary[key];
                }
                else
                {
                    FieldInfo field = type.GetField(name, _bindingFlags);
                    _fieldDictionary[key] = field;
                    return field;
                }
            }
        }

        // Indexers

        private Dictionary<Tuple<Type, string>, PropertyInfo> _indexerDictionary = new Dictionary<Tuple<Type, string>, PropertyInfo>();
        private object _indexerDictionaryLock = new object();

        public PropertyInfo GetIndexer(Type type, params Type[] parameterTypes)
        {
            PropertyInfo property = TryGetIndexer(type, parameterTypes);
            if (property == null)
            {
                throw new Exception(String.Format("Indexer not found with parameterTypes '{0}'.", String.Join(", ", parameterTypes.Select(x => x.ToString()).ToArray())));
            }
            return property;
        }

        public PropertyInfo TryGetIndexer(Type type, params Type[] parameterTypes)
        {
            if (parameterTypes == null) throw new NullException(() => parameterTypes);
            if (parameterTypes.Length == 0) throw new ArgumentException("parameterTypes cannot be empty.");

            string parameterTypesKey = CreateKey(parameterTypes);

            lock (_indexerDictionaryLock)
            {
                var key = new Tuple<Type, string>(type, parameterTypesKey);
                if (_indexerDictionary.ContainsKey(key))
                {
                    return _indexerDictionary[key];
                }
                else
                {
                    var defaultMemberAttribute = (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
                    if (defaultMemberAttribute == null)
                    {
                        return null;
                    }
                    string name = defaultMemberAttribute.MemberName;
                    PropertyInfo property = type.GetProperty(name, _bindingFlags, null, null, parameterTypes, null);
                    _indexerDictionary[key] = property;
                    return property;
                }
            }
        }

        // Methods

        private Dictionary<Type, MethodInfo[]> _methodsDictionary = new Dictionary<Type, MethodInfo[]>();
        private object _methodsDictionaryLock = new object();

        public MethodInfo[] GetMethods(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_methodsDictionaryLock)
            {
                MethodInfo[] methods;
                if (!_methodsDictionary.TryGetValue(type, out methods))
                {
                    methods = type.GetMethods(_bindingFlags);
                    _methodsDictionary.Add(type, methods);
                }
                return methods;
            }
        }

        private Dictionary<Tuple<Type, string, string>, MethodInfo> _methodDictionary = new Dictionary<Tuple<Type, string, string>, MethodInfo>();
        private object _methodDictionaryLock = new object();

        public MethodInfo GetMethod(Type type, string name, params Type[] parameterTypes)
        {
            MethodInfo method = TryGetMethod(type, name, parameterTypes);
            if (method == null)
            {
                throw new Exception(String.Format("Method '{0}' not found.", name));
            }
            return method;
        }

        public MethodInfo TryGetMethod(Type type, string name, params Type[] parameterTypes)
        {
            if (parameterTypes == null) throw new NullException(() => parameterTypes);

            string parameterTypesKey = CreateKey(parameterTypes);

            lock (_methodDictionaryLock)
            {
                var key = new Tuple<Type, string, string>(type, name, parameterTypesKey);
                if (_methodDictionary.ContainsKey(key))
                {
                    return _methodDictionary[key];
                }
                else
                {
                    MethodInfo method = type.GetMethod(name, _bindingFlags, null, parameterTypes, null);
                    _methodDictionary[key] = method;
                    return method;
                }
            }
        }

        private string _keySeparator = "@";

        private string CreateKey(Type[] values)
        {
            string[] strings = new string[values.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = Convert.ToString(values[i]);
            }

            string key = String.Join(_keySeparator, strings);

            return key;
        }
    }
}