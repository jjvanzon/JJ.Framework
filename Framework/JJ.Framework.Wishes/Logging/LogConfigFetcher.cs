using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using static System.Array;
using static JJ.Framework.Configuration.CustomConfigurationManager;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Configuration.ConfigurationManagerWishes;

namespace JJ.Framework.Wishes.Logging
{
    internal class LogConfigFetcher
    {
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public const bool DefaultActive = true;
        
        private static readonly LogConfigSection _defaultConfiguration = CreateDefaultConfiguration();
        private static LogConfigSection CreateDefaultConfiguration() => new LogConfigSection
        {
            Active = DefaultActive,
            Logs   = Empty<LogConfigElement>(),
            Type   = "Debug"
        };
        
        private static string _cachedSectionName = "1FD83EAB"; // Initialize to something never existing, because null has meaning.
        private static string[] _cachedLoggerIDs = Empty<string>();

        public static string[] GetLoggerIDs(string sectionName = null)
        {
            // Make the main case fastest (not hit yet, still only one logger instantiated).
            if (sectionName == _cachedSectionName)
            {
                return _cachedLoggerIDs;
            }
            _cachedSectionName = sectionName;
            
            // Get section or default
            LogConfigSection section = TryGetConfigSection(sectionName) ?? _defaultConfiguration;
            
            // Handle inactive
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
        
        private static LogConfigSection TryGetConfigSection(string name = null)
        {
            string resolvedName = Coalesce(name, DefaultConfigSectionName);
            return TryGetSection<LogConfigSection>(resolvedName);
        }
        
        private static bool Active(LogConfigSection section) => section?.Active ?? DefaultActive;
        
        private static IEnumerable<string> EnumerateParsedLoggerIDs(string types) 
            => types?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()) ?? Empty<string>();
        
        private static IEnumerable<string> EnumerateLoggerIDsFromElements(LogConfigSection section) 
            => section.Logs?.Where(x => x != null).Select(x => x.Type) ?? Empty<string>();
    }
}
