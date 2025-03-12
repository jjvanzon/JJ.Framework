using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Wishes.Logging.Mappers;

namespace JJ.Framework.Wishes.Logging.Config
{
    internal static class ConfigCoalescer
    {
        public const bool DefaultActive = true;

        public static RootLoggerXml Coalesce(RootLoggerXml element)
        {
            element        = element        ?? new RootLoggerXml();
            element.Logs   = element.Logs   ?? new List<LoggerXml>();
            element.Types  = element.Types  ?? "";
            element.Active = element.Active ?? DefaultActive;
            
            CoalesceBase(element);
            
            // For loop for in-place replacement of nulls.
            for (int i = 0; i < element.Logs.Count; i++)
            {
                element.Logs[i] = Coalesce(element.Logs[i]);
            }
            
            return element;
        }
        
        private static LoggerXml Coalesce(LoggerXml element)
        {
            element = element ?? new LoggerXml();
            CoalesceBase(element);
            return element;
        }

        private static void CoalesceBase(LoggerXml element)
        {
            element.Type       = element.Type       ?? "";
            element.Format     = element.Format     ?? "";
            element.Cat        = element.Cat        ?? "";
            element.Cats       = element.Cats       ?? "";
            element.Category   = element.Category   ?? "";
            element.Categories = element.Categories ?? "";
        }
    }
}
