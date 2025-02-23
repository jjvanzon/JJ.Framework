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

        // Preliminary. Might use later.
        /// <inheritdoc cref="docs.loggertype" />
        //[XmlAttribute]
        //public string Types { get; set; }
        
        [XmlArrayItem("log")]
        public LogConfigElement[] Logs { get; set; }
    }
}
