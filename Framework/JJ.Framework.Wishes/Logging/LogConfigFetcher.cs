using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        private static string _previousName = "1FD83EAB"; // Initialize to something never existing. Null has a meaning.
        private static LoggerElement[] _previousElements;

        public static LoggerElement[] GetActiveLoggerConfigs(string configSectionName = null)
        {
            // Make the main case fastest (not hit yet, still only one logger instantiated).
            if (configSectionName == _previousName)
            {
                return _previousElements;
            }

            var section = GetConfigSection(configSectionName);
            section = CoalesceConfig(section);
            var elements = GetActiveLoggerConfigs(section);
            
            _previousName = configSectionName;
            _previousElements = elements;
            return elements;
        }

        private static LogConfig GetConfigSection(string name = null)
        {
            string resolvedName = Coalesce(name, DefaultConfigSectionName);
            return GetSection<LogConfig>(resolvedName);
        }
        
        private static LogConfig CoalesceConfig(LogConfig config)
        {
            config = config ?? new LogConfig();
            config.Logs = config.Logs ?? Empty<LoggerElement>();
            
            for (int i = 0; i < config.Logs.Length; i++)
            {
                config.Logs[i] = config.Logs[i] ?? new LoggerElement();
            }
            
            return config;
        }
        
        private static LoggerElement[] GetActiveLoggerConfigs(LogConfig config)
        {
            bool active = config.Active ?? DefaultActive;
            if (!active) return Empty<LoggerElement>();
            return config.Logs.Where(x => x.Active ?? DefaultActive).ToArray();
        }
    }
}
