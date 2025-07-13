using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using JJ.Framework.Xml;
using System.Configuration;

namespace JJ.Framework.Configuration.Legacy
{
    public static class CustomConfigurationManager
    {
        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static T GetSection<[Dyn(AllProperties)] T>()
            where T : new()
        {
            Assembly assembly = typeof(T).Assembly;
            return GetSection<T>(assembly);
        }

        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static T GetSection<[Dyn(AllProperties)] T>(Assembly assembly)
            where T : new()
        {
            string sectionName = assembly.GetName().Name.ToLower();
            return GetSection<T>(sectionName);
        }

        private static object _sectionDictionaryLock = new object();
        private static Dictionary<string, object> _sectionDictionary = new Dictionary<string, object>();

        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static T GetSection<[Dyn(AllProperties)] T>(string sectionName)
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
