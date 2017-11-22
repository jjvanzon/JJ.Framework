using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
	internal class ElementWithCollection<T>
	{
		[XmlArrayItem("item")]
		public T Collection { get; set; }
	}
}
