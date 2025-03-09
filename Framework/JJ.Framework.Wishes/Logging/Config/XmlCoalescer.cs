using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Wishes.Logging.Mappers;

namespace JJ.Framework.Wishes.Logging.Config
{
    internal static class XmlCoalescer
    {
        public const bool DefaultActive = true;

        public static RootLoggingXml Coalesce(RootLoggingXml element)
        {
            element        = element        ?? new RootLoggingXml();
            element.Logs   = element.Logs   ?? new List<LoggerXml>();
            element.Type   = element.Type   ?? "";
            element.Types  = element.Types  ?? "";
            element.Active = element.Active ?? DefaultActive;
            
            CoalesceCategories(element);
            
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
            element.Type = element.Type ?? "";
            CoalesceCategories(element);
            return element;
        }

        private static void CoalesceCategories(CategoriesXml element)
        {
            element.Cat        = element.Cat        ?? "";
            element.Cats       = element.Cats       ?? "";
            element.Category   = element.Category   ?? "";
            element.Categories = element.Categories ?? "";
        }
    }
}
