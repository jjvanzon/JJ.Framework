using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Collections;
using JJ.Framework.Wishes.Logging.Mappers;
using static System.Array;
using static System.StringSplitOptions;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Logging.Config.LoggerConfigFetcher;

namespace JJ.Framework.Wishes.Logging.Config
{
    internal static class ConfigCascader
    {
        public static RootLoggerConfig CascadeSettings(IList<RootLoggerXml> layerXmls)
        {
            return new RootLoggerConfig
            {
                Loggers = XmlToDtos(layerXmls)
            };
        }
        
        private static IList<LoggerConfig> XmlToDtos(IList<RootLoggerXml> layerXmls)
        {
            if (layerXmls == null) throw new NullException(() => layerXmls);
            
            var list = new List<LoggerConfig>();
            
            IList<string> typeStrings = ResolveTypeStrings(layerXmls);
            foreach (string typeString in typeStrings)
            {
                LoggerConfig dto = ToDto(typeString, layerXmls);
                list.Add(dto);
            }
            
            foreach (RootLoggerXml layerXml in layerXmls)
            {
                IList<LoggerConfig> dtos = ToDtos(layerXml);
                if (dtos.Count > 0) 
                {
                    list.AddRange(dtos);
                    break;
                }
            }
            
            return list;
        }
        
        private static IList<LoggerConfig> ToDtos(LoggerXml xml) 
            => ParseTypeStrings(xml)
              .Select(typeString => ToDto(typeString, xml))
              .ToList();

        
        private static LoggerConfig ToDto(string typeString, params LoggerXml[] xmlLayers) => ToDto(typeString, (IEnumerable<LoggerXml>)xmlLayers);
        private static LoggerConfig ToDto(string typeString, IEnumerable<LoggerXml> xmlLayers)
        {
            if (xmlLayers == null) throw new NullException(() => xmlLayers);
            
            return new LoggerConfig
            {
                Active     = Coalesce(                  xmlLayers.Select(x => x.Active  ).Concat(DefaultActive)),
                Type       = Coalesce(typeString.Concat(xmlLayers.Select(x => x.Type   )).Concat(DefaultType  )),
                Format     = Coalesce(                  xmlLayers.Select(x => x.Format  ).Concat(DefaultFormat)),
                Categories = Coalesce(                  xmlLayers.Select(x => GetCats(x))),
                ExcludedCategories = new List<string>()
            };
        }

        private static IList<string> ResolveTypeStrings(IEnumerable<LoggerXml> layerXmls)
        {
            if (layerXmls == null) throw new NullException(() => layerXmls);
            
            foreach (LoggerXml xmlLayer in layerXmls)
            {
                IList<string> typeStrings = ParseTypeStrings(xmlLayer);
                if (typeStrings.Count > 0) return typeStrings;
            }
            
            return Empty<string>();
        }
        
        private static IList<string> ParseTypeStrings(LoggerXml xml)
        {
            if (xml == null) throw new NullException(() => xml);
            
            return SplitValues(xml.Types)
                  .Concat(SplitValues(xml.Type))
                  .ToList();
        }
        
        private static IList<string> GetCats(LoggerXml xml)
        {
            if (xml == null) throw new NullException(() => xml);
            
            return SplitValues(xml.Categories)
                  .Concat(SplitValues(xml.Category))
                  .Concat(SplitValues(xml.Cats))
                  .Concat(SplitValues(xml.Cat))
                  .ToList();
        }
        
        private static IList<string> SplitValues(string semiColonSeparated) 
            => semiColonSeparated?.Split(";", RemoveEmptyEntries).TrimAll() ?? Empty<string>();
    }
}
