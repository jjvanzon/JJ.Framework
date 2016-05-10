using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using JJ.Framework.Xml;
using System.Configuration;

namespace JJ.Framework.Configuration
{
    public static class CustomConfigurationManager
    {
        private static object _sectionDictionaryLock = new object();
        private static Dictionary<string, object> _sectionDictionary = new Dictionary<string, object>();

        public static T GetSection<T>()
            where T : new()
        {
            Assembly assembly = typeof(T).Assembly;
            return GetSection<T>(assembly);
        }

        public static T TryGetSection<T>()
            where T : new()
        {
            Assembly assembly = typeof(T).Assembly;
            return TryGetSection<T>(assembly);
        }

        public static T GetSection<T>(Assembly assembly)
            where T : new()
        {
            if (assembly == null) throw new NullException(() => assembly);

            string sectionName = assembly.GetName().Name.ToLower();
            return GetSection<T>(sectionName);
        }

        public static T TryGetSection<T>(Assembly assembly)
            where T : new()
        {
            if (assembly == null) throw new NullException(() => assembly);

            string sectionName = assembly.GetName().Name.ToLower();
            return TryGetSection<T>(sectionName);
        }

        public static T GetSection<T>(string sectionName)
            where T : new()
        {
            T section = TryGetSection<T>(sectionName);

            bool sectionNotFound = Object.Equals(section, default(T));
            if (sectionNotFound)
            {
                throw new Exception(String.Format("Configuration section '{0}' not found.", sectionName));
            }

            return section;
        }

        public static T TryGetSection<T>(string sectionName)
            where T : new()
        {
            lock (_sectionDictionaryLock)
            {
                object section;
                if (!_sectionDictionary.TryGetValue(sectionName, out section))
                {
                    XmlElement sourceXmlElement = (XmlElement)ConfigurationManager.GetSection(sectionName);
                    if (sourceXmlElement != null)
                    {
                        var converter = new XmlToObjectConverter<T>();
                        section = converter.Convert(sourceXmlElement);
                    }

                    _sectionDictionary[sectionName] = section;
                }

                return (T)section;
            }
        }

        public static void RefreshSection(string sectionName)
        {
            lock (_sectionDictionary)
            {
                if (_sectionDictionary.ContainsKey(sectionName))
                {
                    _sectionDictionary.Remove(sectionName);
                }
            }

            ConfigurationManager.RefreshSection(sectionName);
        }
    }
}
