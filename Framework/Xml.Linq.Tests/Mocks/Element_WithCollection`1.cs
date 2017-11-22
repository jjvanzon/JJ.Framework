using System.Xml.Serialization;

namespace JJ.Framework.Xml.Linq.Tests.Mocks
{
	internal class Element_WithCollection<T>
	{
		[XmlArrayItem("item")]
		public T Collection { get; set; }
	}
}
