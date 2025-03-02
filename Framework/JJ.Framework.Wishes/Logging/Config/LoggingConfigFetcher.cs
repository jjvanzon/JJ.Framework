using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Wishes.Logging.Xml;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Configuration.ConfigurationManagerWishes;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggingConfigFetcher
    {
        private const bool DefaultActive = true;
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        private static readonly RootLoggingXml _defaultConfigSection = CreateDefaultConfigSection();

        public static RootLoggingConfig GetLoggingConfig(string sectionName = null)
        {
            RootLoggingXml rootLoggingXml = GetLoggingXml(sectionName);
            return GetLoggingConfig(rootLoggingXml);
        }
        
        public static RootLoggingXml GetLoggingXml(string sectionName = null)
        {
            string resolvedSectionName = Coalesce(sectionName, DefaultConfigSectionName);
            RootLoggingXml rootLoggingXml = TryGetSection<RootLoggingXml>(resolvedSectionName);
            return rootLoggingXml ?? _defaultConfigSection;
        }

        public static RootLoggingConfig GetLoggingConfig(RootLoggingXml rootLoggingXml)
        {
            rootLoggingXml = XmlCoalescer.Coalesce(rootLoggingXml);
            RootLoggingConfig rootLoggingConfig = ConfigCascader.CascadeSettings(rootLoggingXml);
            return rootLoggingConfig;
        }
        
        private static RootLoggingXml CreateDefaultConfigSection() => new RootLoggingXml
        {
            Active = DefaultActive,
            Type   = "Debug"
        };
    }
}
