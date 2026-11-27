namespace JJ.Framework.Configuration.Core.Tests.Mappers;

internal class ConfigToolingElement
{
    [XmlAttribute] public bool? AudioPlayback { get; set; }
    [XmlAttribute] public int? SamplingRate { get; set; }
    [XmlAttribute] public bool? ImpersonationMode { get; set; }

    public RootLoggerXml Logging { get; set; } = new();
}