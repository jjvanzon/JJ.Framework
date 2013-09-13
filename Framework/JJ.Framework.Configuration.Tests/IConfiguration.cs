using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Configuration.Tests
{
    public interface IConfiguration
    {
        [XmlAttribute]
        int IntAttribute { get; }

        [XmlAttribute]
        string StringAttribute { get; }

        [XmlAttribute("stringAttribute2_WithAlternativeName")]
        string StringAttribute2 { get; }

        string Element { get; }

        [XmlElement("element2WithAlternativeName")]
        string Element2 { get; }

        ISubConfiguration SubConfiguration { get; }

        [XmlArrayItem("arrayItem")]
        string[] Array { get; }

        [XmlArrayItem("subConfiguration")]
        ISubConfiguration[] ArrayOfSubConfigurations { get; }
    }
}
