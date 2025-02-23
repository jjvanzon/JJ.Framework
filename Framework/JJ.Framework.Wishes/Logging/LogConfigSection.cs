using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging
{
    public class LogConfigSection
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
        
        [XmlArrayItem("log")]
        public LogConfigElement[] Logs { get; set; }
    }
}
