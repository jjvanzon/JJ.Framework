using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Collections.Core;
using JJ.Framework.Common;
using JJ.Framework.Logging.Core.Mappers;
using JJ.Framework.Reflection;
using static System.Array;
using static System.StringSplitOptions;
using static JJ.Framework.Nully.Core.FilledInWishes;
using static JJ.Framework.Logging.Core.Config.LoggerConfigFetcher;

namespace JJ.Framework.Logging.Core.Config
{
    internal static class ConfigCascader
    {
        public static RootLoggerConfig CascadeSettings(IList<RootLoggerXml> xmlLayers)
        {
            if (!Has(xmlLayers)) 
            {
                return new RootLoggerConfig { Loggers = new List<LoggerConfig>() };
            }
            
            // For now use just one layer.
            return CascadeSettings(xmlLayers[0]);
        }
        
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

        
        private static LoggerConfig ToDto(string type, params LoggerXml[] xmlLayers)
        {
            if (xmlLayers == null) throw new NullException(() => xmlLayers);
            
            return new LoggerConfig
            {
                Active     = Coalesce(            xmlLayers.Select(x => x.Active  ).Concat(DefaultActive)),
                Type       = Coalesce(type.Concat(xmlLayers.Select(x => x.Type   )).Concat(DefaultType  )),
                Format     = Coalesce(            xmlLayers.Select(x => x.Format  ).Concat(DefaultFormat)),
                Categories = Coalesce(            xmlLayers.Select(x => GetCats(x))),
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
