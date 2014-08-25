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
    internal class WcfSoapClient
    {
        private string _serviceInterfaceName;
        private SoapClient _client;

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
        /// </summary>
        public WcfSoapClient(string url, string serviceInterfaceName)
            : this(url, serviceInterfaceName, Encoding.UTF8)
        { }

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// </summary>
        public WcfSoapClient(string url, string serviceInterfaceName, Encoding encoding)
        {
            if (String.IsNullOrEmpty(serviceInterfaceName)) throw new ArgumentException("serviceInterfaceName is null");

            _serviceInterfaceName = serviceInterfaceName;

            IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = GetCustomArrayItemNameMappings();
            _client = new SoapClient(url, encoding, customArrayItemNameMappings: customArrayItemNameMappings);
        }

        public TResult Invoke<TResult>(string operationName, params SoapParameter[] parameters)
            where TResult : class, new()
        {
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", _serviceInterfaceName, operationName);
            return _client.Invoke<TResult>(soapAction, operationName, parameters);
        }

        // TODO: A method like Invoke but then returns void.

        private IEnumerable<CustomArrayItemNameMapping> GetCustomArrayItemNameMappings()
        {
            return new CustomArrayItemNameMapping[]
            {
                new CustomArrayItemNameMapping(typeof(bool), "boolean"),
                new CustomArrayItemNameMapping(typeof(char), "char"),
                new CustomArrayItemNameMapping(typeof(DateTime), "dateTime"),
                new CustomArrayItemNameMapping(typeof(double), "double"),
                new CustomArrayItemNameMapping(typeof(Guid), "guid"),
                new CustomArrayItemNameMapping(typeof(short), "short"),
                new CustomArrayItemNameMapping(typeof(int), "int"),
                new CustomArrayItemNameMapping(typeof(long), "long"),
                new CustomArrayItemNameMapping(typeof(SByte), "byte"),
                new CustomArrayItemNameMapping(typeof(float), "float"),
                new CustomArrayItemNameMapping(typeof(string), "string"),
                new CustomArrayItemNameMapping(typeof(TimeSpan), "duration"),
                new CustomArrayItemNameMapping(typeof(UInt16), "unsignedShort"),
                new CustomArrayItemNameMapping(typeof(UInt32), "unsignedInt"),
                new CustomArrayItemNameMapping(typeof(UInt64), "unsignedLong")
            };
        }
    }
}
