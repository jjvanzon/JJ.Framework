using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using JJ.Framework.Xml;
using System.Configuration;

namespace JJ.Framework.Configuration
{
    public static class CustomConfigurationManager
    {
        public static T GetSection<T>()
            where T : new()
        {
            Assembly assembly = typeof(T).Assembly;
            return GetSection<T>(assembly);
        }

        public static T GetSection<T>(Assembly assembly)
            where T : new()
        {
            if (assembly == null) throw new NullException(() => assembly);

            string sectionName = assembly.GetName().Name.ToLower();
            return GetSection<T>(sectionName);
        }

        private static object _sectionDictionaryLock = new object();
        private static Dictionary<string, object> _sectionDictionary = new Dictionary<string, object>();

        public static T GetSection<T>(string sectionName)
            where T : new()
        {
            lock (_sectionDictionaryLock)
            {
                object section;
                if (!_sectionDictionary.TryGetValue(sectionName, out section))
                {
                    XmlElement sourceXmlElement = (XmlElement)ConfigurationManager.GetSection(sectionName);
                    if (sourceXmlElement == null)
                    {
                        throw new Exception(String.Format("Configuration section '{0}' not found.", sectionName));
                    }

                    var converter = new XmlToObjectConverter<T>();
                    section = converter.Convert(sourceXmlElement);

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
