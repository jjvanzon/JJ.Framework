using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JJ.Framework.Xml;

namespace JJ.Framework.Configuration
{
    public static class ConfigurationManager
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

        // Cache the objects, but allow RefreshSection to refresh the configuration.
        // (The solution below, however, keeps the old object in memory though.)
        // TODO: Make sure you get rid of old objects.

        private static object _sectionDictionaryLock = new object();
        private static Dictionary<XmlNode, object> _sectionDictionary = new Dictionary<XmlNode, object>();

        public static T GetSection<T>(string sectionName)
            where T : new()
        {
            XmlNode sourceNode = (XmlNode)System.Configuration.ConfigurationManager.GetSection(sectionName);
            if (sourceNode == null)
            {
                throw new Exception(String.Format("Configuration section '{0}' not found.", sectionName));
            }

            lock (_sectionDictionaryLock)
            {
                if (_sectionDictionary.ContainsKey(sourceNode))
                {
                    return (T)_sectionDictionary[sourceNode];
                }
                
                var converter = new XmlToObjectConverter<T>();
                T destObject = converter.Convert(sourceNode);

                _sectionDictionary[sourceNode] = destObject;

                return destObject;
            }
        }
    }
}
