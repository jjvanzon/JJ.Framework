using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using JJ.Framework.Wishes.docs;

namespace JJ.Framework.Wishes.Logging.Mappers
{
    public class RootLoggerXml : LoggerXml
    {
        [XmlAttribute]
        public bool? Active { get; set; }

        // Several formats in which to specify the logger types.

        /// <inheritdoc cref="_loggertypes" />
        [XmlAttribute]
        public string Types { get; set; }
        
        [XmlArrayItem("log")]
        public IList<LoggerXml> Logs { get; set; }
    }
}
