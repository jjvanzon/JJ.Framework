using System.Xml.Serialization;

namespace JJ.Framework.Configuration.Tests
{
    public class TestConfiguration
    {
        [XmlAttribute]
        public int IntAttribute { get; set; }

        [XmlAttribute]
        public string StringAttribute { get; set; }

        [XmlAttribute("stringAttribute2_WithAlternativeName")]
        public string StringAttribute2 { get; set; }

        public string Element { get; set; }

        [XmlElement("element2WithAlternativeName")]
        public string Element2 { get; set; }

        public TestSubConfiguration SubConfiguration { get; set; }

        [XmlArrayItem("arrayItem")]
        public string[] Array { get; set; }

        [XmlArrayItem("subConfiguration")]
        public TestSubConfiguration[] ArrayOfSubConfigurations { get; set; }
    }
}
