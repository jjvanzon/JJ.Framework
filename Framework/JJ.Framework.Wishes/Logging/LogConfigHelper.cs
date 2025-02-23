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
    // TODO: Rename to LogConfigFetcher
    internal class LogConfigHelper
    {
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public const bool DefaultActive = true;
        
        private static string _previousName = "1FD83EAB"; // Initialize to something never existing. Null has a meaning.
        private static LogConfig _previousSection;
                
        public static LoggerElement[] GetActiveLoggerConfigs(LogConfig config) 
            => config.Logs.Where(x => x.Active ?? DefaultActive).ToArray();

        public static LogConfig GetConfigSection(string name = null)
        {
            // Make the main case fastest (not hit yet, still only one logger instantiated).
            if (name == _previousName)
            {
                return _previousSection;
            }

            string resolvedName  = Coalesce(name, DefaultConfigSectionName);
            var section = GetSection<LogConfig>(resolvedName);
            section = CoalesceConfig(section);
            
            _previousName = name;
            _previousSection = section;
            
            return section;
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
    }
}
