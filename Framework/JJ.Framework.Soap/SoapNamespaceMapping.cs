using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Linq
{
    public class SoapNamespaceMapping
    {
        public string DotNetNamespace { get; private set; }
        public string XmlNamespace { get; private set; }

        public SoapNamespaceMapping(string dotNetNamespace, string xmlNamespace)
        {
            if (String.IsNullOrEmpty(dotNetNamespace)) throw new ArgumentNullException("dotNetNamespace");
            if (String.IsNullOrEmpty(xmlNamespace)) throw new ArgumentNullException("xmlNamespace");

            DotNetNamespace = dotNetNamespace;
            XmlNamespace = xmlNamespace;
        }
    }
}
