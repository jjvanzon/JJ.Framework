using System.Xml.Serialization;

namespace JJ.Framework.Xml.Linq.Tests.Mocks
{
	internal class Element_WithChildElement_WithExplicitName
	{
		[XmlElement("Element_WithExplicitName")]
		public int Element_WithExplicitName { get; set; }

	}
}
