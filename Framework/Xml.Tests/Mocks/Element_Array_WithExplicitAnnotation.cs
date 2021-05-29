using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class Element_Array_WithExplicitAnnotation
    {
        [XmlArray]
        [XmlArrayItem("item")]
        public int[] Array_WithExplicitAnnotation { get; set; }
    }
}
