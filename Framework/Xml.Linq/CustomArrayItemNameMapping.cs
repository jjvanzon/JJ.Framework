using JJ.Framework.Exceptions;
using System;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Xml.Linq
{
	public class CustomArrayItemNameMapping
	{
		public const string DEFAULT_XML_ARRAY_ITEM_NAMESPACE_STRING = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

		public Type DotNetItemType { get; }
		public string XmlArrayItemName { get; }

		public CustomArrayItemNameMapping(Type dotNetItemType, string xmlArrayItemName)
		{
			if (dotNetItemType == null) throw new NullException(() => dotNetItemType);
			if (string.IsNullOrEmpty(xmlArrayItemName)) throw new ArgumentException("xmlArrayItemName cannot be null or empty.");

			DotNetItemType = dotNetItemType;
			XmlArrayItemName = xmlArrayItemName;
		}
	}
}
