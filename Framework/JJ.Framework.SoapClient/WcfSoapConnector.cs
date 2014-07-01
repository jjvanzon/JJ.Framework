using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.SoapClient
{
    public class WcfSoapConnector
    {
        private const string SOAP_XML_NAMESPACE_PREFIX = "s";
        private const string OPERATION_XML_NAMESPACE_PREFIX = "o";

        private string _serviceInterfaceName;
        private SoapConnector _baseConnector;

        /// <summary>
        /// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
        /// </summary>
        public WcfSoapConnector(string url, string serviceInterfaceName, params string[] dotNetNamespaces)
            : this(url, serviceInterfaceName, Encoding.UTF8, dotNetNamespaces)
        { }

        public WcfSoapConnector(string url, string serviceInterfaceName, Encoding encoding, params string[] dotNetNamespaces)
        {
            if (String.IsNullOrEmpty(serviceInterfaceName)) throw new ArgumentException("serviceInterfaceName is null");

            _serviceInterfaceName = serviceInterfaceName;

            string[] excludedXmlNamespacePrefixes = new string[] { SOAP_XML_NAMESPACE_PREFIX, OPERATION_XML_NAMESPACE_PREFIX };
            
            var namespaceMappings = XmlNamespaceMappingFactory.CreateXmlNamespaceMappings(excludedXmlNamespacePrefixes, dotNetNamespaces);

            _baseConnector = new SoapConnector(url, namespaceMappings, SOAP_XML_NAMESPACE_PREFIX, OPERATION_XML_NAMESPACE_PREFIX, encoding);
        }

        public TResult Invoke<TResult>(string operationName, params SoapParameter[] parameters)
            where TResult : class, new()
        {
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", _serviceInterfaceName, operationName);
            return _baseConnector.Invoke<TResult>(soapAction, operationName, parameters);
        }
    }
}
