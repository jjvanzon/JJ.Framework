using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using static System.Array;
using static JJ.Framework.Configuration.CustomConfigurationManager;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Configuration.ConfigurationManagerWishes;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggingConfigFetcher
    {
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public const bool DefaultActive = true;
        
        private static readonly LoggingConfigSection _defaultConfigSection = CreateDefaultConfigSection();
        
        private static string _cachedSectionName = "1FD83EAB"; // Initialize to something never existing, because null has meaning.
        private static string[] _cachedLoggerIDs = Empty<string>();
                
        public static LoggingConfigSection GetLoggingConfig(string sectionName = null)
        {
            string resolvedSectionName  = Coalesce(sectionName, DefaultConfigSectionName);
            LoggingConfigSection configSection = TryGetSection<LoggingConfigSection>(resolvedSectionName);
            configSection = configSection ?? _defaultConfigSection;
            return configSection;
        }

        private static LoggingConfigSection CreateDefaultConfigSection() => new LoggingConfigSection
        {
            Active = DefaultActive,
            Logs   = Empty<LoggingConfigElement>(),
            Type   = "Debug"
        };

        internal static string[] GetLoggerIDs(string sectionName = null)
        {
            // Make the main case fastest (not hit yet, still only one logger instantiated).
            if (sectionName == _cachedSectionName)
            {
                return _cachedLoggerIDs;
            }
            _cachedSectionName = sectionName;
            
            // Get section or default
            LoggingConfigSection section = GetLoggingConfig(sectionName);
            
            // Handle inactive
            return GetLoggerIDs(section);
        }
        
        internal static string[] GetLoggerIDs(LoggingConfigSection section)
        {
            if (section == null) throw new NullException(() => section);
            
            if (!(Active(section)))
            {
                _cachedLoggerIDs = Empty<string>();
            }
            else
            {
                // Get logger IDs from all sources in the config.
                _cachedLoggerIDs = EnumerateParsedLoggerIDs(section.Types)
                                   .Union(EnumerateParsedLoggerIDs(section.Type))
                                   .Union(EnumerateLoggerIDsFromElements(section)).ToArray();
            }
            
            return _cachedLoggerIDs;
        }
        
        private static bool Active(LoggingConfigSection section) => section?.Active ?? DefaultActive;
        
        private static IEnumerable<string> EnumerateParsedLoggerIDs(string types) 
            => types?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()) ?? Empty<string>();
        
        private static IEnumerable<string> EnumerateLoggerIDsFromElements(LoggingConfigSection section) 
            => section.Logs?.Where(x => x != null).Select(x => x.Type) ?? Empty<string>();
    }
}
