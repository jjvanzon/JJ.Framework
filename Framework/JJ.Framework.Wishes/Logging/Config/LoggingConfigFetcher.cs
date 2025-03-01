using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
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
                _cachedLoggerIDs = SplitValues(config.Types)
                                   .Union(SplitValues(config.Type))
                                   .Union(EnumerateLoggerIDsFromElements(config)).ToArray();
            }
            
            return _cachedLoggerIDs;
        }
        
        private static bool Active(LoggingConfiguration config) => config?.Active ?? DefaultActive;
        
        private static IEnumerable<string> SplitValues(string colonSeparated) 
            => colonSeparated?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()) ?? Empty<string>();
        
        private static IEnumerable<string> EnumerateLoggerIDsFromElements(LoggingConfiguration config) 
            => config.Logs?.Where(x => x != null).Select(x => x.Type) ?? Empty<string>();
        
        internal static HashSet<string> GetCategories(string sectionName = null) 
            => GetCategories(GetLoggingConfig(sectionName));

        internal static HashSet<string> GetCategories(LoggingConfiguration config)
        {
            var list = new List<string>(16);
            
            if (config == null) return new HashSet<string>(list);
            
            list.AddRange(SplitValues(config.Cat));
            list.AddRange(SplitValues(config.Cats));
            list.AddRange(SplitValues(config.Category));
            list.AddRange(SplitValues(config.Categories));
            
            if (config.Logs == null) return new HashSet<string>(list);
            
            for (var i = 0; i < config.Logs.Length; i++)
            {
                var loggerConfig = config.Logs[i];
                if (loggerConfig == null) continue;
                
                list.AddRange(SplitValues(loggerConfig.CatString));
                list.AddRange(SplitValues(loggerConfig.CatsString));
                list.AddRange(SplitValues(loggerConfig.CategoryString));
                list.AddRange(SplitValues(loggerConfig.CategoriesString));
                
                if (loggerConfig.CatCollection != null)
                {
                    for (var catIndex = 0; catIndex < loggerConfig.CatCollection.Length; catIndex++)
                    {
                        var categoryConfig = loggerConfig.CatCollection[catIndex];
                        if (categoryConfig == null) continue;
                        list.AddRange(SplitValues(categoryConfig.Name));
                    }
                }
                
                if (loggerConfig.CategoryCollection != null)
                {
                    for (var catIndex = 0; catIndex < loggerConfig.CategoryCollection.Length; catIndex++)
                    {
                        var categoryConfig = loggerConfig.CategoryCollection[catIndex];
                        if (categoryConfig == null) continue;
                        list.AddRange(SplitValues(categoryConfig.Name));
                    }
                }
            }
            
            return new HashSet<string>(list);
        }
    }
}
