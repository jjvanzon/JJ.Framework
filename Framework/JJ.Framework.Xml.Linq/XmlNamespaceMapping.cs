using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Linq
{
    public class XmlNamespaceMapping
    {
        public string DotNetNamespace { get; private set; }
        public string XmlNamespace { get; private set; }
        public string XmlNamespacePrefix { get; private set; }

        /// <summary> nullable </summary>
        //public string XmlNamespacePrefix { get; set; }

        public XmlNamespaceMapping(string dotNetNamespace, string xmlNamespace, string xmlNamespacePrefix)
        {
            if (String.IsNullOrEmpty(dotNetNamespace)) throw new ArgumentNullException("dotNetNamespace");
            if (String.IsNullOrEmpty(xmlNamespace)) throw new ArgumentNullException("xmlNamespace");
            if (String.IsNullOrEmpty(xmlNamespacePrefix)) throw new ArgumentNullException("xmlNamespacePrefix");

            DotNetNamespace = dotNetNamespace;
            XmlNamespace = xmlNamespace;
            XmlNamespacePrefix = xmlNamespacePrefix;
        }
    }
}
