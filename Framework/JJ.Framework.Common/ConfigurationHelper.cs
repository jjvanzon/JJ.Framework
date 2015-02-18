using System;
using System.Collections.Generic;
using System.Text;

namespace JJ.Framework.Common
{
    /// <summary>
    /// For using configuration settings when you cannot be dependent on System.Configuration.
    /// </summary>
    public static class ConfigurationHelper
    {
        private static object _sectionsLock = new object();
        private static IDictionary<Type, object> _sections = new Dictionary<Type, object>();

        public static T GetSection<T>()
        {
            lock (_sectionsLock)
            {
                object section;
                if (!_sections.TryGetValue(typeof(T), out section))
                {
                    throw new Exception(String.Format(
                        "Configuration section of type '{0}' was not set. To allow {1} to use this configuration section, call {2}.SetSection.", 
                        typeof(T).FullName, 
                        typeof(ConfigurationHelper).Assembly.GetName().Name,
                        typeof(ConfigurationHelper).FullName));
                }
                return (T)section;
            }
        }

        public static void SetSection<T>(T section)
        {
            if (section == null) throw new ArgumentNullException("section");

            lock (_sectionsLock)
            {
                if (_sections.ContainsKey(typeof(T)))
                {
                    throw new Exception(String.Format("Configuration section of type '{0}' was already set.", typeof(T).FullName));
                }
                _sections.Add(typeof(T), section);
            }
        }
    }
}
