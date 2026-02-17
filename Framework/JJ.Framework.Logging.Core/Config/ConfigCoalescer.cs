using JJ.Framework.Logging.Core.Mappers;

namespace JJ.Framework.Logging.Core.Config
{
    internal static class ConfigCoalescer
    {
        public const bool DefaultActive = true;

        public static RootLoggerXml[] Coalesce(params RootLoggerXml[] layerXmls) => (RootLoggerXml[])Coalesce((IList<RootLoggerXml>)layerXmls);
        public static IList<RootLoggerXml> Coalesce(IList<RootLoggerXml> layerXmls)
        {
            layerXmls ??= new List<RootLoggerXml> { new RootLoggerXml() };
            
            for (int i = 0; i < layerXmls.Count; i++)
            {
                layerXmls[i] = Coalesce(layerXmls[i]);
            }
            
            return layerXmls;
        }
        
        public static RootLoggerXml Coalesce(RootLoggerXml element)
        {
            element      ??= new RootLoggerXml();
            element.Logs ??= new List<LoggerXml>();
            
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
            element ??= new LoggerXml();
            CoalesceBase(element);
            return element;
        }

        private static void CoalesceBase(LoggerXml element)
        {
            element.Active     ??= DefaultActive;
            element.Format     ??= "";
            element.Type       ??= "";
            element.Types      ??= "";
            element.Cat        ??= "";
            element.Cats       ??= "";
            element.Category   ??= "";
            element.Categories ??= "";
        }
    }
}
