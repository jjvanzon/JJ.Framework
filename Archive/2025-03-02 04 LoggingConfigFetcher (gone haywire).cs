using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Collections;
using JJ.Framework.Wishes.Logging.Xml;
using static System.Array;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Configuration.ConfigurationManagerWishes;
using static JJ.Framework.Wishes.Logging.Config.XmlCoalescer;

namespace JJ.Framework.Wishes.Logging.Config
{
    internal static class LoggingConfigFetcherOld
    {
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public const bool DefaultActive = true;
        
        private static readonly RootLoggingXml _defaultConfigSection = CreateDefaultConfigSection();
        
        // Cache a main use case
        private static string _cachedSectionName = "1FD83EAB"; // Initialize to something never existing, because null has meaning.
        private static string[] _cachedLoggerIDs = Empty<string>();
                
        public static RootLoggingXml GetLoggingConfig(string sectionName = null)
        {
            string resolvedSectionName  = Coalesce(sectionName, DefaultConfigSectionName);
            RootLoggingXml configSection = TryGetSection<RootLoggingXml>(resolvedSectionName);
            configSection = Coalesce(configSection ?? _defaultConfigSection);
            return configSection;
        }

        private static RootLoggingXml CreateDefaultConfigSection() => new RootLoggingXml
        {
            Active = DefaultActive,
            Type   = "Debug"
        };
        
        internal static IList<LoggerXml> ToLoggerConfigs(RootLoggingXml config)
        {
            if (config == null) return Empty<LoggerXml>();
            if (!Active(config)) return Empty<LoggerXml>();
            
            IList<LoggerXml> loggerConfigs = new List<LoggerXml>();
            
            if (config.Logs != null)
            {
                loggerConfigs.AddRange(config.Logs);
            }

            loggerConfigs.AddRange(SplitValues(config.Type)
                                   .Union(SplitValues(config.Types))
                                   .Select(type => new LoggerXml { Type = type }));
            
            loggerConfigs = loggerConfigs.Distinct(x => x.Type).ToArray();
            
            return loggerConfigs;
        }

        
        internal static string[] GetLoggerIDs(string sectionName = null)
        {
            // Make the main case fastest (not hit yet, still only one logger instantiated).
            if (sectionName == _cachedSectionName)
            {
                return _cachedLoggerIDs;
            }
            _cachedSectionName = sectionName;
            
            // Get section or default
            RootLoggingXml section = GetLoggingConfig(sectionName);
            
            // Handle inactive
            return GetLoggerIDs(section);
        }
        
        internal static string[] GetLoggerIDs(RootLoggingXml config)
        {
            if (config == null) throw new NullException(() => config);
            
            if (!Active(config))
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
        
        internal static HashSet<string> GetCategoriesRecursive(string sectionName = null) 
            => GetCategoriesRecursive(GetLoggingConfig(sectionName));

        internal static HashSet<string> GetCategoriesRecursive(RootLoggingXml config)
        {
            var list = new List<string>(16);
            
            if (config == null) return new HashSet<string>(list);
            
            AddCategories(list, config);
            
            if (config.Logs == null) return new HashSet<string>(list);
            
            for (var i = 0; i < config.Logs.Count; i++)
            {
                var loggerConfig = config.Logs[i];
                if (loggerConfig == null) continue;
                
                AddCategories(list, loggerConfig);
            }
            
            return new HashSet<string>(list);
        }
        
        internal static List<string> GetCategories(CategoriesXml loggerConfig)
        {
            if (loggerConfig == null) throw new NullException(() => loggerConfig);
            var list = new List<string>();
            AddCategories(list, loggerConfig);
            return list;
        }
        
        private static void AddCategories(ICollection<string> coll, CategoriesXml config)
        {
            if (config == null) return;
            
            coll.AddRange(SplitValues(config.CatString));
            coll.AddRange(SplitValues(config.CatsString));
            coll.AddRange(SplitValues(config.CategoryString));
            coll.AddRange(SplitValues(config.CategoriesString));
            
            if (config.CatCollection != null)
            {
                for (var i = 0; i < config.CatCollection.Count; i++)
                {
                    var categoryConfig = config.CatCollection[i];
                    if (categoryConfig == null) continue;
                    coll.AddRange(SplitValues(categoryConfig.Name));
                }
            }
            
            if (config.CategoryCollection != null)
            {
                for (var i = 0; i < config.CategoryCollection.Count; i++)
                {
                    var categoryConfig = config.CategoryCollection[i];
                    if (categoryConfig == null) continue;
                    coll.AddRange(SplitValues(categoryConfig.Name));
                }
            }
        }

        // Helpers

        private static bool Active(RootLoggingXml config) => config?.Active ?? DefaultActive;
        
        private static IEnumerable<string> SplitValues(string colonSeparated) 
            => colonSeparated?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()) ?? Empty<string>();
        
        private static IEnumerable<string> EnumerateLoggerIDsFromElements(RootLoggingXml config) 
            => config.Logs?.Where(x => x != null).Select(x => x.Type) ?? Empty<string>();
    }
}
