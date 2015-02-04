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
    }
}
