using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging.Mappers
{
    public class CategoriesXml
    {
        // Several ways to specify categories.
        
        [XmlAttribute("cat")]        public string CatString        { get; set; }
        [XmlAttribute("cats")]       public string CatsString       { get; set; }
        [XmlAttribute("category")]   public string CategoryString   { get; set; }
        [XmlAttribute("categories")] public string CategoriesString { get; set; }
        
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public IList<CategoryXml> CategoryCollection { get; set; }
        
        [XmlArray("cats")]
        [XmlArrayItem("cat")]
        public IList<CategoryXml> CatCollection { get; set; }
    }
}
