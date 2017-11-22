using System.Xml.Serialization;

namespace JJ.Framework.Xml.Linq.Tests.Mocks
{
	internal class Element_WithArray_WithExplicitName
	{
		[XmlArray("Array_WithExplicitName")]
		[XmlArrayItem("item")]
		public int[] Array_WithExplicitName { get; set; }
	}
}
