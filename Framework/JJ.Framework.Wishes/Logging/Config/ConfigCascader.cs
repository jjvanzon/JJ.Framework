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

namespace JJ.Framework.Wishes.Logging.Config
{
    internal static class ConfigCascader
    {
        public static RootLoggingConfig CascadeSettings(RootLoggingXml rootXml)
        {
            if (rootXml == null) throw new NullException(() => rootXml);
            
            return new RootLoggingConfig
            {
                Active = rootXml.Active.Value,
                Loggers = XmlToLoggerConfigs(rootXml)
            };
        }
        
        private static IList<LoggerConfig> XmlToLoggerConfigs(RootLoggingXml rootXml)
        {
            return SplitValues(rootXml.Types)
                  .Concat(SplitValues(rootXml.Type))
                  .Select(text => StringToLoggerConfig(rootXml, text))
                  .Concat(rootXml.Logs.Select(element => ElementToLoggerConfig(rootXml, element)))
                  .Where(x => Has(x.Type))
                  .ToList();
        }
        
        private static LoggerConfig StringToLoggerConfig(RootLoggingXml rootXml, string loggerType) => new LoggerConfig
        {
            Type = loggerType,
            Categories = XmlToCategories(rootXml),
            ExcludedCategories = new List<string>()
        };
        
        private static LoggerConfig ElementToLoggerConfig(RootLoggingXml rootXml, LoggerXml loggerXml)
        {
            if (loggerXml == null) throw new NullException(() => loggerXml);
            
            return new LoggerConfig
            {
                Type = loggerXml.Type,
                Categories = Coalesce(XmlToCategories(loggerXml), XmlToCategories(rootXml)),
                ExcludedCategories = new List<string>()
            };
        }
        
        private static IList<string> XmlToCategories(CategoriesXml categoriesXml)
        {
            if (categoriesXml == null) throw new NullException(() => categoriesXml);
            
            return SplitValues(categoriesXml.Categories)
                   .Concat(SplitValues(categoriesXml.Category))
                   .Concat(SplitValues(categoriesXml.Cats))
                   .Concat(SplitValues(categoriesXml.Cat))
                   .Where(FilledIn)
                   .ToList();
        }
        
        private static IList<string> SplitValues(string colonSeparated) 
            => colonSeparated?.Split(";", RemoveEmptyEntries).TrimAll() ?? Empty<string>();
    }
}
