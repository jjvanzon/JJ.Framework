namespace JJ.Framework.Configuration.Core.Tests.Mappers;

internal class ConfigSection
{
    // Audio Quality
        
    [XmlAttribute] public int? Bits { get; set; }
    [XmlAttribute] public int? Channels { get; set; }
    [XmlAttribute] public int? SamplingRate { get; set; }
    [XmlAttribute] public AudioFileFormatEnum? AudioFormat { get; set; }
    [XmlAttribute] public InterpolationTypeEnum? Interpolation { get; set; }
    [XmlAttribute] public int? CourtesyFrames { get; set; }
        
    // Durations
        
    [XmlAttribute] public double? NoteLength { get; set; }
    [XmlAttribute] public double? BarLength { get; set; }
    [XmlAttribute] public double? BeatLength { get; set; }
    [XmlAttribute] public double? AudioLength { get; set; }
    [XmlAttribute] public double? LeadingSilence { get; set; }
    [XmlAttribute] public double? TrailingSilence { get; set; }
        
    // Feature Toggles
        
    [XmlAttribute] public bool? AudioPlayback { get; set; }
    [XmlAttribute] public bool? DiskCache { get; set; }
    [XmlAttribute] public bool? MathBoost { get; set; }
    [XmlAttribute] public bool? ParallelProcessing { get; set; }
    [XmlAttribute] public bool? PlayAllTapes { get; set; }
        
    // Tooling
    
    public ConfigToolingElement AzurePipelines { get; set; } = new();
    public ConfigToolingElement NCrunch { get; set; } = new();
    public RootLoggerXml Logging { get; set; } = new();
        
    // Misc
        
    [XmlAttribute] public double? LeafCheckTimeOut { get; set; }
    [XmlAttribute] public TimeOutActionEnum? TimeOutAction { get; set; }
    [XmlAttribute] public int? FileExtensionMaxLength { get; set; }
}