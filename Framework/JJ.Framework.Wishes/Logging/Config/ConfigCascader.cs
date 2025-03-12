using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Logging.Mappers;
using static System.Array;
using static System.StringSplitOptions;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Logging.Config.LoggerConfigFetcher;

namespace JJ.Framework.Wishes.Logging.Config
{
    internal static class ConfigCascader
    {
        public static RootLoggerConfig CascadeSettings(RootLoggerXml rootXml)
        {
            if (rootXml == null) throw new NullException(() => rootXml);
            
            return new RootLoggerConfig
            {
                Active = rootXml.Active.Value,
                Loggers = XmlToLoggerConfigs(rootXml)
            };
        }
        
        private static IList<LoggerConfig> XmlToLoggerConfigs(RootLoggerXml rootXml)
        {
            return SplitValues(rootXml.Types)
                  .Concat(SplitValues(rootXml.Type))
                  .Select(text => StringToLoggerConfig(rootXml, text))
                  .Concat(rootXml.Logs.Select(element => ElementToLoggerConfig(rootXml, element)))
                  .Where(x => Has(x.Type))
                  .ToList();
        }
        
        private static LoggerConfig StringToLoggerConfig(RootLoggerXml rootXml, string loggerType) => new LoggerConfig
        {
            Type = loggerType,
            Categories = XmlToCategories(rootXml),
            ExcludedCategories = new List<string>()
        };
        
        private static LoggerConfig ElementToLoggerConfig(RootLoggerXml rootXml, LoggerXml loggerXml)
        {
            if (loggerXml == null) throw new NullException(() => loggerXml);
            
            return new LoggerConfig
            {
                Type       = Coalesce(loggerXml.Type,   rootXml.Type,   DefaultType),
                Format     = Coalesce(loggerXml.Format, rootXml.Format, DefaultFormat),
                Categories = Coalesce(XmlToCategories(loggerXml), XmlToCategories(rootXml)),
                ExcludedCategories = new List<string>()
            };
        }
        
        private static IList<string> XmlToCategories(LoggerXml element)
        {
            if (element == null) throw new NullException(() => element);
            
            return SplitValues(element.Categories)
                  .Concat(SplitValues(element.Category))
                  .Concat(SplitValues(element.Cats))
                  .Concat(SplitValues(element.Cat))
                  .Where(FilledIn)
                  .ToList();
        }
        
        private static IList<string> SplitValues(string colonSeparated) 
            => colonSeparated?.Split(";", RemoveEmptyEntries).TrimAll() ?? Empty<string>();
    }
}
