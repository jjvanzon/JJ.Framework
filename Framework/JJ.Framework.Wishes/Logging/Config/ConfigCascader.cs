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
                Loggers = XmlToDtos(rootXml)
            };
        }
        
        private static IList<LoggerConfig> XmlToDtos(RootLoggerXml rootXml)
        {
            var list = new List<LoggerConfig>();
            
            IList<string> typeStrings = GetTypeStrings(rootXml);
            
            foreach (string typeString in typeStrings)
            {
                LoggerConfig dto = ToDto(typeString, rootXml);
                list.Add(dto);
            }
            
            foreach (LoggerXml loggerXml in rootXml.Logs)
            {
                IList<LoggerConfig> dtos = ToDtos(loggerXml, rootXml);
                list.AddRange(dtos);
            }
            
            return list;
        }
        
        private static IList<LoggerConfig> ToDtos(LoggerXml loggerXml, LoggerXml template) 
            => GetTypeStrings(loggerXml)
              .Select(x => ToDto(x, loggerXml, template))
              .ToList();

        private static LoggerConfig ToDto(string typeString, LoggerXml template) => new LoggerConfig
        {
            Active     = Coalesce(            template.Active, DefaultActive),
            Type       = Coalesce(typeString, template.Type,   DefaultType  ),
            Format     = Coalesce(            template.Format, DefaultFormat),
            Categories = GetCats(template),
            ExcludedCategories = new List<string>()
        };
        
        private static LoggerConfig ToDto(string typeString, LoggerXml loggerXml, LoggerXml template)
        {
            if (loggerXml == null) throw new NullException(() => loggerXml);
            
            return new LoggerConfig
            {
                Active     = Coalesce(            loggerXml.Active, template.Active, DefaultActive),
                Type       = Coalesce(typeString, loggerXml.Type,   template.Type,   DefaultType  ),
                Format     = Coalesce(            loggerXml.Format, template.Format, DefaultFormat),
                Categories = Coalesce(GetCats(loggerXml), GetCats(template)),
                ExcludedCategories = new List<string>()
            };
        }

        private static IList<string> GetTypeStrings(LoggerXml element)
        {
            if (element == null) throw new NullException(() => element);
            
            return SplitValues(element.Types)
                  .Concat(SplitValues(element.Type))
                  .Where(FilledIn)
                  .ToList();
        }
        
        private static IList<string> GetCats(LoggerXml element)
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
