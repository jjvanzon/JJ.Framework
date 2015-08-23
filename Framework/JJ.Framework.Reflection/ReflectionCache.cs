using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection
{
    public class ReflectionCache
    {
        private BindingFlags _bindingFlags;

        public ReflectionCache(BindingFlags bindingFlags)
        {
            _bindingFlags = bindingFlags;
        }

        // Properties

        private IDictionary<Type, PropertyInfo[]> _propertiesDictionary = new Dictionary<Type, PropertyInfo[]>();
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

        // PropertyDictionaries

        private IDictionary<Type, IDictionary<string, PropertyInfo>> _propertyDictionaryDictionary = new Dictionary<Type, IDictionary<string, PropertyInfo>>();
        private object _propertyDictionaryDictionaryLock = new object();

        public IDictionary<string, PropertyInfo> GetPropertyDictionary(Type type)
        {
            lock (_propertyDictionaryDictionaryLock)
            {
                IDictionary<string, PropertyInfo> propertyDictionary;
                if (!_propertyDictionaryDictionary.TryGetValue(type, out propertyDictionary))
                {
                    propertyDictionary = type.GetProperties(_bindingFlags).ToDictionary(x => x.Name);
                    _propertyDictionaryDictionary.Add(type, propertyDictionary);
                }
                return propertyDictionary;
            }
        }

        // Fields

        private IDictionary<Type, FieldInfo[]> _fieldsDictionary = new Dictionary<Type, FieldInfo[]>();
        private object _fieldsDictionaryLock = new object();

        public FieldInfo[] GetFields(Type type)
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

        // Types

        private IDictionary<string, Type[]> _typeByShortNameDictionary = new Dictionary<string, Type[]>();
        private object _typeByShortNameDictionaryLock = new object();

        public Type GetTypeByShortName(string shortTypeName)
        {
            Type type = TryGetTypeByShortName(shortTypeName);
            if (type == null)
            {
                throw new Exception(String.Format("Type with short name '{0}' not found in the AppDomain's assemblies.", shortTypeName));
            }
            return type;
        }

        public Type TryGetTypeByShortName(string shortTypeName)
        {
            IList<Type> types = GetTypesByShortName(shortTypeName);

            switch (types.Count)
            {
                case 1:
                    return types[0];

                case 0:
                    return null;

                default:
                    throw new Exception(String.Format(
                        "Type with short name '{0}' found multiple times in the AppDomain's assemblies. Found types:{1}{2}",
                        shortTypeName, Environment.NewLine, String_PlatformSupport.Join(Environment.NewLine, types.Select(x => x.FullName))));
            }
        }

        public IList<Type> GetTypesByShortName(string shortTypeName)
        {
            lock (_typeByShortNameDictionaryLock)
            {
                Type[] types;
                if (_typeByShortNameDictionary.TryGetValue(shortTypeName, out types))
                {
                    return types;
                }

                List<Type> list = new List<Type>();
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        list.AddRange(assembly.GetTypes().Where(x => String.Equals(x.Name, shortTypeName)));
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        // Ignore.
                        // TODO: Learn why types of some assemblies cannot be retrieved,
                        // and why it says the assembly cannot be loaded (file not found),
                        // while it clearly is part of the app domain.
                    }
                }
                types = list.ToArray();

                _typeByShortNameDictionary.Add(shortTypeName, types);
                return types;
            }
        }

        // Constructors

        private IDictionary<Type, ConstructorInfo> _constructorDictionary = new Dictionary<Type, ConstructorInfo>();
        private object _constructorDictionaryLock = new object();

        public ConstructorInfo GetConstructor(Type type)
        {
            lock (_constructorDictionaryLock)
            {
                ConstructorInfo constructor;
                if (_constructorDictionary.TryGetValue(type, out constructor))
                {
                    return constructor;
                }

                IList<ConstructorInfo> constructors = type.GetConstructors(_bindingFlags);
                switch (constructors.Count)
                {
                    case 1:
                        _constructorDictionary.Add(type, constructors[0]);
                        return constructors[0];

                    case 0:
                        throw new Exception(String.Format("No constructor found for type '{0}' for binding flags '{1}'.", type.FullName, _bindingFlags));

                    default:
                        throw new Exception(String.Format(
                            "Multiple constructors found on type '{0}' for binding flags '{1}'. Found constructors: {2}", 
                            type.FullName, _bindingFlags, String_PlatformSupport.Join(", ", constructors.Select(x => x.ToString()))));
                }
            }
        }

    }
}
