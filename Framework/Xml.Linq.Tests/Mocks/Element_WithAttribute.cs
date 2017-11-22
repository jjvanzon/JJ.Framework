using System.Xml.Serialization;

namespace JJ.Framework.Xml.Linq.Tests.Mocks
{
	internal class Element_WithAttribute<T>
	{
		[XmlAttribute]
		public T Attribute { get; set; }
	}
}
