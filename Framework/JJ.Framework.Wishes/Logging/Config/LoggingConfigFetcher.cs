using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection;
using static System.Array;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Configuration.ConfigurationManagerWishes;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggingConfigFetcher
    {
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public const bool DefaultActive = true;
        
        private static readonly LoggingConfiguration _defaultConfigSection = CreateDefaultConfigSection();
        
        // Cache a main use case
        private static string _cachedSectionName = "1FD83EAB"; // Initialize to something never existing, because null has meaning.
        private static string[] _cachedLoggerIDs = Empty<string>();
                
        public static LoggingConfiguration GetLoggingConfig(string sectionName = null)
        {
            string resolvedSectionName  = Coalesce(sectionName, DefaultConfigSectionName);
            LoggingConfiguration configSection = TryGetSection<LoggingConfiguration>(resolvedSectionName);
            configSection = configSection ?? _defaultConfigSection;
            return configSection;
        }

        private static LoggingConfiguration CreateDefaultConfigSection() => new LoggingConfiguration
        {
            Active = DefaultActive,
            Logs   = Empty<LoggerElement>(),
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
            LoggingConfiguration section = GetLoggingConfig(sectionName);
            
            // Handle inactive
            return GetLoggerIDs(section);
        }
        
        internal static string[] GetLoggerIDs(LoggingConfiguration config)
        {
            if (config == null) throw new NullException(() => config);
            
            if (!(Active(config)))
            {
                _cachedLoggerIDs = Empty<string>();
            }
            else
            {
                // Get logger IDs from all sources in the config.
                _cachedLoggerIDs = EnumerateParsedLoggerIDs(config.Types)
                                   .Union(EnumerateParsedLoggerIDs(config.Type))
                                   .Union(EnumerateLoggerIDsFromElements(config)).ToArray();
            }
            
            return _cachedLoggerIDs;
        }
        
        private static bool Active(LoggingConfiguration config) => config?.Active ?? DefaultActive;
        
        private static IEnumerable<string> EnumerateParsedLoggerIDs(string types) 
            => types?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()) ?? Empty<string>();
        
        private static IEnumerable<string> EnumerateLoggerIDsFromElements(LoggingConfiguration config) 
            => config.Logs?.Where(x => x != null).Select(x => x.Type) ?? Empty<string>();
    }
}
