using System.Linq;
using System.Xml.Linq;

namespace JJ.Framework.Xml.Linq.Internal
{
	internal static class NilHelper
	{
		public const string NIL_XML_NAMESPACE_NAME = "http://www.w3.org/2001/XMLSchema-instance";
		private const string NIL_ATTRIBUTE_NAME = "nil";

		public static XNamespace GetNilXNamespace()
		{
			XNamespace xnamespace = NIL_XML_NAMESPACE_NAME;
			return xnamespace;
		}

		public static XElement CreateNilElement(XName destXName)
		{
			XElement destElement = new XElement(destXName, null);
			XAttribute nilAttribute = new XAttribute(GetNilXNamespace() + NIL_ATTRIBUTE_NAME, true);
			destElement.Add(nilAttribute);
			return destElement;
		}

		public static bool HasNilAttribute(XElement element)
		{
			return element.Attributes(GetNilXNamespace() + NIL_ATTRIBUTE_NAME).Any();
		}
	}
}
