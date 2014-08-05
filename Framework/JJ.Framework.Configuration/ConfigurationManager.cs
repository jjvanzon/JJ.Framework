using JJ.Framework.Reflection;
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
            string sectionName = assembly.GetName().Name.ToLower();
            return GetSection<T>(sectionName);
        }

        // Cache the objects, but allow RefreshSection to refresh the configuration
        // by using XmlElement as the cache key instead of e.g. the sectionName.
        // (The solution below, however, keeps the old object in memory though.)
        // TODO: Make sure you get rid of old objects.
        // TODO: You do not need to support RefeshSection. The symmetrical thing to do is give this class its own RefreshSection method.

        private static object _sectionDictionaryLock = new object();
        private static Dictionary<XmlNode, object> _sectionDictionary = new Dictionary<XmlNode, object>();

        public static T GetSection<T>(string sectionName)
            where T : new()
        {
            XmlElement sourceXmlElement = (XmlElement)ConfigurationManager.GetSection(sectionName);
            if (sourceXmlElement == null)
            {
                throw new Exception(String.Format("Configuration section '{0}' not found.", sectionName));
            }

            lock (_sectionDictionaryLock)
            {
                if (_sectionDictionary.ContainsKey(sourceXmlElement))
                {
                    return (T)_sectionDictionary[sourceXmlElement];
                }
                
                var converter = new XmlToObjectConverter<T>();
                T destObject = converter.Convert(sourceXmlElement);

                _sectionDictionary[sourceXmlElement] = destObject;

                return destObject;
            }
        }
    }
}
