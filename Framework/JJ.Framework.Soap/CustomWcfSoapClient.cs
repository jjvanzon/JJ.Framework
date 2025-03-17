using JJ.Framework.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Soap
{
    /// <summary>
    /// This class exists because some mobile platforms running on Mono
    /// do not fully support System.ServiceModel or System.Web.Services.
    /// </summary>
    internal class CustomWcfSoapClient
    {
        private string _serviceInterfaceName;
        private SoapClient _client;

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
        /// </summary>
        /// <param name="serviceInterfaceName">
        /// The short name of the interface. So without the namespace in front of it, e.g. "ITestService".
        /// </param>
        public CustomWcfSoapClient(string url, string serviceInterfaceName)
            : this(url, serviceInterfaceName, Encoding.UTF8)
        { }

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// </summary>
        /// <param name="serviceInterfaceName">
        /// The short name of the interface. So without the namespace in front of it, e.g. "ITestService".
        /// </param>
        public CustomWcfSoapClient(string url, string serviceInterfaceName, Encoding encoding)
        {
            if (String.IsNullOrEmpty(serviceInterfaceName)) throw new ArgumentException("serviceInterfaceName cannot be null or empty.");

            _serviceInterfaceName = serviceInterfaceName;

            IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = WcfHelper.GetCustomArrayItemNameMappings();

            _client = new SoapClient(url, encoding, customArrayItemNameMappings: customArrayItemNameMappings);
        }

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// </summary>
        /// <param name="serviceInterfaceName">
        /// The short name of the interface. So without the namespace in front of it, e.g. "ITestService".
        /// </param>
        /// <param name="sendMessageDelegate">
        /// You can handle the sending of the SOAP message and the receiving of the response yourself
        /// by passing this sendMessageDelegate. This is for environments that do not support HttpWebRequest.
        /// First parameter of the delegate is SOAP action, second parameter is SOAP message as an XML string,
        /// return value should be text received.
        /// </param>
        public CustomWcfSoapClient(string url, string serviceInterfaceName, Func<string, string, string> sendMessageDelegate)
        {
            if (String.IsNullOrEmpty(serviceInterfaceName)) throw new ArgumentException("serviceInterfaceName cannot be null or empty.");

            _serviceInterfaceName = serviceInterfaceName;

            IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = WcfHelper.GetCustomArrayItemNameMappings();

            _client = new SoapClient(url, sendMessageDelegate, customArrayItemNameMappings: customArrayItemNameMappings);
        }

        public TResult Invoke<TResult>(string operationName, params SoapParameter[] parameters)
            where TResult : class, new()
        {
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", _serviceInterfaceName, operationName);
            return _client.Invoke<TResult>(soapAction, operationName, parameters);
        }

        // TODO: A method like Invoke but then returns void.
    }
}
