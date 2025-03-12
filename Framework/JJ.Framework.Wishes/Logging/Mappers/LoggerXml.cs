using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using JJ.Framework.Wishes.docs;

namespace JJ.Framework.Wishes.Logging.Mappers
{
    public class LoggerXml
    {
        /// <inheritdoc cref="_loggertype" />
        [XmlAttribute]
        public string Type { get; set; }

        /// <inheritdoc cref="_loggerformat">
        [XmlAttribute]
        public string Format { get; set; }

        // Several ways to specify categories.
        [XmlAttribute] public string Cat        { get; set; }
        [XmlAttribute] public string Cats       { get; set; }
        [XmlAttribute] public string Category   { get; set; }
        [XmlAttribute] public string Categories { get; set; }
    }
}
