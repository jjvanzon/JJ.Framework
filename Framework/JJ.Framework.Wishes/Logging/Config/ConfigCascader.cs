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
        
        private static IList<LoggerConfig> ToDtos(LoggerXml xml, LoggerXml template) 
            => GetTypeStrings(xml)
              .Select(x => ToDto(x, xml, template))
              .ToList();

        private static LoggerConfig ToDto(string typeString, LoggerXml template) => new LoggerConfig
        {
            Active     = Coalesce(            template.Active, DefaultActive),
            Type       = Coalesce(typeString, template.Type,   DefaultType  ),
            Format     = Coalesce(            template.Format, DefaultFormat),
            Categories = GetCats(template),
            ExcludedCategories = new List<string>()
        };
        
        private static LoggerConfig ToDto(string typeString, LoggerXml xml, LoggerXml template)
        {
            if (xml == null) throw new NullException(() => xml);
            
            return new LoggerConfig
            {
                Active     = Coalesce(            xml.Active, template.Active, DefaultActive),
                Type       = Coalesce(typeString, xml.Type,   template.Type,   DefaultType  ),
                Format     = Coalesce(            xml.Format, template.Format, DefaultFormat),
                Categories = Coalesce(GetCats(xml), GetCats(template)),
                ExcludedCategories = new List<string>()
            };
        }

        private static IList<string> GetTypeStrings(LoggerXml xml)
        {
            if (xml == null) throw new NullException(() => xml);
            
            return SplitValues(xml.Types)
                  .Concat(SplitValues(xml.Type))
                  .Where(FilledIn)
                  .ToList();
        }
        
        private static IList<string> GetCats(LoggerXml xml)
        {
            if (xml == null) throw new NullException(() => xml);
            
            return SplitValues(xml.Categories)
                  .Concat(SplitValues(xml.Category))
                  .Concat(SplitValues(xml.Cats))
                  .Concat(SplitValues(xml.Cat))
                  .Where(FilledIn)
                  .ToList();
        }
        
        private static IList<string> SplitValues(string semiColonSeparated) 
            => semiColonSeparated?.Split(";", RemoveEmptyEntries).TrimAll() ?? Empty<string>();
    }
}
