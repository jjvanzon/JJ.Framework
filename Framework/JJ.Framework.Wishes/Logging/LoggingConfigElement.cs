using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggingConfigElement
    {
        /// <inheritdoc cref="docs.loggertype" />
        [XmlAttribute]
        public string Type { get; set; }
    }
}