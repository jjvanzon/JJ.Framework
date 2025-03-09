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
        [XmlAttribute] public string Cat        { get; set; }
        [XmlAttribute] public string Cats       { get; set; }
        [XmlAttribute] public string Category   { get; set; }
        [XmlAttribute] public string Categories { get; set; }
    }
}
