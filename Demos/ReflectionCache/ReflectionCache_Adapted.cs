using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JJ.Framework.Exceptions.Basic;

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace JJ.Demos.ReflectionCache
{
    public class ReflectionCache_Adapted
    {
        // Dictionary of composite struct type may give bad performance.
        // I wonder how it compares to an actual Tuple of .NET 4.0.
        // ContainsKey and [] on dictionary seem much slower than TryGetValue and Add.

        private readonly BindingFlags _bindingFlags;

        public ReflectionCache_Adapted(BindingFlags bindingFlags) => _bindingFlags = bindingFlags;

        private const BindingFlags BINDING_FLAGS_ALL =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy;

        // Properties

        private readonly Dictionary<Type, PropertyInfo[]> _propertiesDictionary = new Dictionary<Type, PropertyInfo[]>();
        private readonly object _propertiesDictionaryLock = new object();

        public PropertyInfo[] GetProperties(Type type)
        {
            lock (_propertiesDictionaryLock)
            {
                if (!_propertiesDictionary.TryGetValue(type, out PropertyInfo[] properties))
                {
                    properties = type.GetProperties(_bindingFlags);
                    _propertiesDictionary.Add(type, properties);
                }

                return properties;
            }
        }

        private readonly Dictionary<Tuple<Type, string>, PropertyInfo> _propertyDictionary = new Dictionary<Tuple<Type, string>, PropertyInfo>();
        private readonly object _propertyDictionaryLock = new object();

        public PropertyInfo GetProperty(Type type, string name)
        {
            PropertyInfo property = TryGetProperty(type, name);

            if (property == null)
            {
                throw new Exception($"Property '{name}' not found.");
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

                PropertyInfo property = type.GetProperty(name, _bindingFlags);
                _propertyDictionary[key] = property;
                return property;
            }
        }

        // Fields

        private readonly Dictionary<Type, FieldInfo[]> _fieldsDictionary = new Dictionary<Type, FieldInfo[]>();
        private readonly object _fieldsDictionaryLock = new object();

        public FieldInfo[] GetFields(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_fieldsDictionaryLock)
            {
                if (!_fieldsDictionary.TryGetValue(type, out FieldInfo[] fields))
                {
                    fields = type.GetFields(_bindingFlags);
                    _fieldsDictionary.Add(type, fields);
                }

                return fields;
            }
        }

        private readonly Dictionary<Tuple<Type, string>, FieldInfo> _fieldDictionary = new Dictionary<Tuple<Type, string>, FieldInfo>();
        private readonly object _fieldDictionaryLock = new object();

        public FieldInfo GetField(Type type, string name)
        {
            FieldInfo field = TryGetField(type, name);

            if (field == null)
            {
                throw new Exception($"Field '{name}' not found.");
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

                FieldInfo field = type.GetField(name, _bindingFlags);
                _fieldDictionary[key] = field;
                return field;
            }
        }

        // Indexers

        private readonly Dictionary<Tuple<Type, string>, PropertyInfo> _indexerDictionary = new Dictionary<Tuple<Type, string>, PropertyInfo>();
        private readonly object _indexerDictionaryLock = new object();

        public PropertyInfo GetIndexer(Type type, params Type[] parameterTypes)
        {
            PropertyInfo property = TryGetIndexer(type, parameterTypes);

            if (property == null)
            {
                throw new Exception(
                    $"Indexer not found with parameterTypes '{string.Join(", ", parameterTypes.Select(x => x.ToString()).ToArray())}'.");
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

                var defaultMemberAttribute =
                    (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), true).SingleOrDefault();

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

        // Methods

        private readonly Dictionary<Type, MethodInfo[]> _methodsDictionary = new Dictionary<Type, MethodInfo[]>();
        private readonly object _methodsDictionaryLock = new object();

        public MethodInfo[] GetMethods(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            lock (_methodsDictionaryLock)
            {
                if (!_methodsDictionary.TryGetValue(type, out MethodInfo[] methods))
                {
                    methods = type.GetMethods(_bindingFlags);
                    _methodsDictionary.Add(type, methods);
                }

                return methods;
            }
        }

        private readonly Dictionary<Tuple<Type, string, string>, MethodInfo> _methodDictionary =
            new Dictionary<Tuple<Type, string, string>, MethodInfo>();
        private readonly object _methodDictionaryLock = new object();

        public MethodInfo GetMethod(Type type, string name, params Type[] parameterTypes)
        {
            MethodInfo method = TryGetMethod(type, name, parameterTypes);

            if (method == null)
            {
                throw new Exception($"Method '{name}' not found.");
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

                MethodInfo method = type.GetMethod(name, _bindingFlags, null, parameterTypes, null);
                _methodDictionary[key] = method;
                return method;
            }
        }

        private readonly string _keySeparator = "@";

        private string CreateKey(Type[] values)
        {
            var strings = new string[values.Length];

            for (var i = 0; i < strings.Length; i++)
            {
                strings[i] = Convert.ToString(values[i]);
            }

            string key = string.Join(_keySeparator, strings);

            return key;
        }
    }
}