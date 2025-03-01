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

        [XmlAttribute("cat")]        public string CatString        { get; set; }
        [XmlAttribute("cats")]       public string CatsString       { get; set; }
        [XmlAttribute("category")]   public string CategoryString   { get; set; }
        [XmlAttribute("categories")] public string CategoriesString { get; set; }
        
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public CategoryElement[] CategoryCollection { get; set; }
        
        [XmlArray("cats")]
        [XmlArrayItem("cat")]
        public CategoryElement[] CatCollection { get; set; }
    }
}