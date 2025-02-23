using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Array;
using static JJ.Framework.Configuration.CustomConfigurationManager;
using static JJ.Framework.Wishes.Common.FilledInWishes;

namespace JJ.Framework.Wishes.Logging
{
    internal class LogConfigFetcher
    {
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public const bool DefaultActive = true;
        
        private static string _previousSectionName = "1FD83EAB"; // Initialize to something never existing. Null has a meaning.
        private static string[] _previousLoggerNames;

        public static string[] GetActiveLoggerNames(string sectionName = null)
        {
            // Make the main case fastest (not hit yet, still only one logger instantiated).
            if (sectionName == _previousSectionName)
            {
                return _previousLoggerNames;
            }
            
            LogConfigSection section = GetConfigSection(sectionName);
            section = CoalesceConfig(section);
            LogConfigElement[] elements = GetActiveLoggerConfigs(section);
            string[] loggerNames = elements.Select(x => x.Type).ToArray();
            
            _previousSectionName = sectionName;
            _previousLoggerNames = loggerNames;

            return loggerNames;
        }

        private static LogConfigSection GetConfigSection(string name = null)
        {
            string resolvedName = Coalesce(name, DefaultConfigSectionName);
            return GetSection<LogConfigSection>(resolvedName);
        }
        
        private static LogConfigSection CoalesceConfig(LogConfigSection config)
        {
            config = config ?? new LogConfigSection();
            config.Logs = config.Logs ?? Empty<LogConfigElement>();
            
            for (int i = 0; i < config.Logs.Length; i++)
            {
                config.Logs[i] = config.Logs[i] ?? new LogConfigElement();
            }
            
            return config;
        }
        
        private static LogConfigElement[] GetActiveLoggerConfigs(LogConfigSection config)
        {
            bool active = config.Active ?? DefaultActive;
            if (!active) return Empty<LogConfigElement>();
            return config.Logs.Where(x => x.Active ?? DefaultActive).ToArray();
        }
    }
}
