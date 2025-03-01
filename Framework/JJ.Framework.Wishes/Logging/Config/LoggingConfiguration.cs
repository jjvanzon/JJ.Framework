using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggingConfiguration
    {
        [XmlAttribute]
        public bool? Active { get; set; }

        // Several formats in which to specify the logger types.
        
        /// <inheritdoc cref="docs.loggertype" />
        [XmlAttribute]
        public string Type { get; set; }

        /// <inheritdoc cref="docs.loggertypes" />
        [XmlAttribute]
        public string Types { get; set; }

        [XmlAttribute]
        public string Cat { get; set; }

        [XmlAttribute]
        public string Cats { get; set; }

        [XmlAttribute]
        public string Category { get; set; }

        [XmlAttribute]
        public string Categories { get; set; }
        
        [XmlArrayItem("log")]
        public LoggerElement[] Logs { get; set; }
    }
}
