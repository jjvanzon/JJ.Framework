using JJ.Framework.Exceptions;
using System;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Xml.Linq
{
	public class SoapNamespaceMapping
	{
		public const string WCF_SOAP_NAMESPACE_HEADER = "http://schemas.datacontract.org/2004/07/";

		public string SourceXmlNamespace { get; }
		public string DestXmlNamespace { get; }

		public SoapNamespaceMapping(string sourceXmlNamespace, string destXmlNamespace)
		{
			if (string.IsNullOrEmpty(sourceXmlNamespace)) throw new NullException(() => sourceXmlNamespace);
			if (string.IsNullOrEmpty(destXmlNamespace)) throw new NullException(() => destXmlNamespace);

			SourceXmlNamespace = sourceXmlNamespace;
			DestXmlNamespace = destXmlNamespace;
		}
	}
}
