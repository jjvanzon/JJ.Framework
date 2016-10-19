using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Linq
{
    public class SoapNamespaceMapping
    {
        public const string WCF_SOAP_NAMESPACE_HEADER = "http://schemas.datacontract.org/2004/07/";

        public string SourceXmlNamespace { get; private set; }
        public string DestXmlNamespace { get; private set; }

        public SoapNamespaceMapping(string sourceXmlNamespace, string destXmlNamespace)
        {
            if (String.IsNullOrEmpty(sourceXmlNamespace)) throw new NullException(() => sourceXmlNamespace);
            if (String.IsNullOrEmpty(destXmlNamespace)) throw new NullException(() => destXmlNamespace);

            SourceXmlNamespace = sourceXmlNamespace;
            DestXmlNamespace = destXmlNamespace;
        }
    }
}
