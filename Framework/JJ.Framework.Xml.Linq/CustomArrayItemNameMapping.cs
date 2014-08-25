using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Linq
{
    public class CustomArrayItemNameMapping
    {
        public const string DEFAULT_XML_ARRAY_ITEM_NAMESPACE_STRING = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

        public Type DotNetItemType { get; private set; }
        public string XmlArrayItemName { get; private set; }

        public CustomArrayItemNameMapping(Type dotNetItemType, string xmlArrayItemName)
        {
            if (dotNetItemType == null) throw new ArgumentNullException("dotNetItemType");
            if (String.IsNullOrEmpty(xmlArrayItemName)) throw new ArgumentException("xmlArrayItemName cannot be null or empty.");

            DotNetItemType = dotNetItemType;
            XmlArrayItemName = xmlArrayItemName;
        }
    }
}
