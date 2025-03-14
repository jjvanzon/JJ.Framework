using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Logging.Mappers;
using JJ.Framework.Wishes.docs;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Configuration.ConfigurationManagerWishes;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggerConfigFetcher
    {
        public const bool DefaultActive = true;
        public const string DefaultType = "Console";
        public const string DefaultFormat = "{0} {1} {2}";
        
        /// <inheritdoc cref="_defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        private static readonly RootLoggerXml _defaultConfigSection = CreateDefaultConfigSection();
        
        public static RootLoggerXml GetLoggerXml(string sectionName = null)
        {
            string resolvedSectionName = Coalesce(sectionName, DefaultConfigSectionName);
            RootLoggerXml rootLoggerXml = TryGetSection<RootLoggerXml>(resolvedSectionName);
            return rootLoggerXml ?? _defaultConfigSection;
        }
        
        public static RootLoggerConfig CreateLoggerConfig(string sectionName = null)
        {
            RootLoggerXml rootLoggerXml = GetLoggerXml(sectionName);
            return CreateLoggerConfig(rootLoggerXml);
        }

        public static RootLoggerConfig CreateLoggerConfig(params RootLoggerXml[] layerXmls) => CreateLoggerConfig((IList<RootLoggerXml>)layerXmls);
        public static RootLoggerConfig CreateLoggerConfig(IList<RootLoggerXml> layerXmls)
        {
            if (layerXmls == null) throw new NullException(() => layerXmls);
            layerXmls = ConfigCoalescer.Coalesce(layerXmls);
            RootLoggerConfig rootLoggerConfig = ConfigCascader.CascadeSettings(layerXmls);
            return rootLoggerConfig;
        }
        
        private static RootLoggerXml CreateDefaultConfigSection() => new RootLoggerXml
        {
            Active = DefaultActive,
            Type   = DefaultType,
            Format = DefaultFormat
        };
    }
}
