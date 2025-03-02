using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Logging.Xml;
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
                  .ToArray();
        }
        
        private static LoggerConfig StringToLoggerConfig(RootLoggingXml rootXml, string loggerType) => new LoggerConfig
        {
            Type = loggerType,
            Categories = XmlToCategoryConfigs(rootXml)
        };
        
        private static LoggerConfig ElementToLoggerConfig(RootLoggingXml rootXml, LoggerXml loggerXml)
        {
            if (rootXml  == null) throw new NullException(() => rootXml);
            if (loggerXml == null) throw new NullException(() => loggerXml);
            
            // Turn category strings into CategoryConfig objects.
            IList<CategoryConfig> categoryConfigs = XmlToCategoryConfigs(loggerXml);
            
            // TODO: Use Coalesce method instead.
            
            // Check if loggerConfig defined categories itself..
            if (categoryConfigs.Count == 0)
            {
                // Otherwise use those of root config.
                categoryConfigs = XmlToCategoryConfigs(rootXml);
            }
            
            return new LoggerConfig
            {
                Type = loggerXml.Type,
                Categories = categoryConfigs
            };
        }
        
        private static IList<CategoryConfig> XmlToCategoryConfigs(CategoriesXml categoriesXml)
        {
            return SplitValues(categoriesXml.CategoriesString)
                   .Concat(SplitValues(categoriesXml.CategoryString))
                   .Concat(SplitValues(categoriesXml.CatsString))
                   .Concat(SplitValues(categoriesXml.CatString))
                   .Select(StringToCategoryConfig)
                   .Concat(categoriesXml.CategoryCollection.Select(ElementToCategoryConfig))
                   .Concat(categoriesXml.CatCollection.Select(ElementToCategoryConfig))
                   .Where(x => Has(x.Name))
                   .ToArray();
        }
        
        private static CategoryConfig ElementToCategoryConfig(CategoryXml categoryXml) => new CategoryConfig
        {
            Name   = categoryXml.Name,
            Tagged = categoryXml.Tagged.Value
        };
        
        private static CategoryConfig StringToCategoryConfig(string categoryString) 
            => new CategoryConfig { Name = categoryString };
        
        private static IList<string> SplitValues(string colonSeparated) 
            => colonSeparated?.Split(";", RemoveEmptyEntries).TrimAll() ?? Empty<string>();

    }
}
