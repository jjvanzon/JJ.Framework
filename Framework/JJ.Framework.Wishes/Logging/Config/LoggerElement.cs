using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggerElement
    {
        /// <inheritdoc cref="docs.loggertype" />
        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string Category { get; set; }

        [XmlAttribute]
        public string Categories { get; set; }

        [XmlAttribute]
        public string Cat { get; set; }

        [XmlAttribute]
        public string Cats { get; set; }
        
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public CategoryElement[] CategoryCollection { get; set; }
        
        [XmlArray("cats")]
        [XmlArrayItem("cat")]
        public CategoryElement[] CatCollection { get; set; }
    }
}