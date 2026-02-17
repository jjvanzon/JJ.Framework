using JJ.Framework.Logging.Core.docs;
using JJ.Framework.Logging.Core.Mappers;
using static JJ.Framework.Existence.Core.FilledInHelper;
using static JJ.Framework.Configuration.Core.CustomConfigurationManagerCore;

namespace JJ.Framework.Logging.Core.Config
{
    public static class LoggerConfigFetcher
    {
        public const bool DefaultActive = true;
        public const string DefaultType = "Console";
        public const string DefaultFormat = "{0} {1} {2}";
        
        /// <inheritdoc cref="_defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        private static readonly RootLoggerXml _defaultConfigSection = CreateDefaultConfigSection();
        
        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static RootLoggerXml GetLoggerXml(string sectionName = "")
        {
            string resolvedSectionName = Coalesce(sectionName, DefaultConfigSectionName);
            RootLoggerXml? rootLoggerXml = TryGetSection<RootLoggerXml>(resolvedSectionName);
            return rootLoggerXml ?? _defaultConfigSection;
        }
        
        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static RootLoggerConfig CreateLoggerConfig(string sectionName = "")
        {
            RootLoggerXml rootLoggerXml = GetLoggerXml(sectionName);
            return CreateLoggerConfig(rootLoggerXml);
        }

        // TOD: Layers not yet used. Only first layer is used. No cascading between layers.
        public static RootLoggerConfig CreateLoggerConfig(params RootLoggerXml[] xmlLayers) => CreateLoggerConfig((IList<RootLoggerXml>)xmlLayers);
        public static RootLoggerConfig CreateLoggerConfig(IList<RootLoggerXml> xmlLayers)
        {
            xmlLayers = ConfigCoalescer.Coalesce(xmlLayers);
            RootLoggerConfig rootLoggerConfig = ConfigCascader.CascadeSettings(xmlLayers);
            return rootLoggerConfig;
        }
        
        private static RootLoggerXml CreateDefaultConfigSection() => new()
        {
            Active = DefaultActive,
            Type   = DefaultType,
            Format = DefaultFormat
        };
    }
}
