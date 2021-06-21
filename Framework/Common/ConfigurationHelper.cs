using System;
using System.Collections.Generic;

namespace JJ.Framework.Common
{
    /// <summary>
    /// <para>
    /// This may be a helper class for specific use-cases,
    /// when using configuration settings normally might be unavailable.
    /// In some project, there was an environment, that had a variation on .NET,
    /// on which normal use of System.Configuration might not have been available.
    /// To allow those environments to operate on a similar configuration structure as
    /// environments that can use System.Configuration, using this ConfigurationHelper may
    /// have offered a way out.
    /// </para>
    /// 
    /// <para>
    /// XML deserialization of a config file to an object might be realized differently,
    /// after which ConfigurationHelper.SetSection may be called.
    /// </para>
    /// 
    /// <para>
    /// Parts of code that may otherwise have used ConfigurationManager.GetSection,
    /// might instead call ConfigurationHelper.GetSection instead.
    /// </para>
    /// </summary>
    public static class ConfigurationHelper
    {
        private static readonly object _sectionsLock = new object();
        private static readonly IDictionary<string, object> _sections = new Dictionary<string, object>();

        /// <param name="sectionName">If null it may be assumed to be assembly name in lower case.</param>
        public static T GetSection<T>(string sectionName = null)
        {
            lock (_sectionsLock)
            {
                sectionName = ResolveSectionName<T>(sectionName);

                object section = TryGetSection<T>(sectionName);

                if (section == null)
                {
                    // ReSharper disable once UseStringInterpolation
                    throw new ApplicationException(
                        $"Configuration section with name '{sectionName}' was not set. " +
                        $"To allow {typeof(ConfigurationHelper).Assembly.GetName().Name} to use this configuration section, " +
                        $"call {typeof(ConfigurationHelper).FullName}.SetSection.");
                }

                return (T)section;
            }
        }

        /// <param name="sectionName">If null it may be assumed to be assembly name in lower case.</param>
        public static T TryGetSection<T>(string sectionName = null)
        {
            sectionName = ResolveSectionName<T>(sectionName);

            lock (_sectionsLock)
            {
                _sections.TryGetValue(sectionName, out object section);
                return (T)section;
            }
        }

        /// <param name="sectionName">If null it may be assumed to be assembly name in lower case.</param>
        public static void SetSection<T>(T section, string sectionName = null)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));

            sectionName = ResolveSectionName<T>(sectionName);

            lock (_sectionsLock)
            {
                if (_sections.ContainsKey(sectionName))
                {
                    throw new ApplicationException($"Configuration section with with name '{sectionName}' was already set.");
                }

                _sections.Add(sectionName, section);
            }
        }

        /// <summary> Section name. when not provided, may be assumed to be assembly name in lower case. </summary>
        private static string ResolveSectionName<T>(string sectionName)
        {
            if (!string.IsNullOrEmpty(sectionName))
            {
                return sectionName;
            }

            return typeof(T).Assembly.GetName().Name.ToLower();
        }
    }
}
