using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging.Xml
{
    public class RootLoggingXml : CategoriesXml
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
        public IList<LoggerXml> Logs { get; set; }
    }
}
