using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggerConfigElement
    {
        /// <inheritdoc cref="docs.loggertype" />
        [XmlAttribute]
        public string Type { get; set; }
        
        [XmlAttribute]
        public bool? Enabled { get; set; }
    }
}