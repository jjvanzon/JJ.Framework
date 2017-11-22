using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
	internal class Element_WithAttribute<T>
	{
		[XmlAttribute]
		public T Attribute { get; set; }
	}
}
