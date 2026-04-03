using JJ.Framework.Logging.Core.docs;

namespace JJ.Framework.Logging.Core.Mappers
{
    public class LoggerXml
    {
        [XmlAttribute]
        public bool? Active { get; set; }

        /// <inheritdoc cref="_loggerformat" />
        [XmlAttribute]
        public string Format { get; set; } = "";

        // Several formats in which to specify the logger types.
        
        /// <inheritdoc cref="_loggertype" />
        [XmlAttribute]
        public string Type { get; set; } = "";

        /// <inheritdoc cref="_loggertypes" />
        [XmlAttribute]
        public string Types { get; set; } = "";

        // Several ways to specify categories.
        [XmlAttribute] public string Cat        { get; set; } = "";
        [XmlAttribute] public string Cats       { get; set; } = "";
        [XmlAttribute] public string Category   { get; set; } = "";
        [XmlAttribute] public string Categories { get; set; } = "";
    }
}
