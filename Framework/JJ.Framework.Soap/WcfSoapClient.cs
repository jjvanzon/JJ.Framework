using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Soap
{
    public class WcfSoapClient
    {
        private string _serviceInterfaceName;
        private SoapClient _soapClient;

        /// <summary>
        /// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
        /// </summary>
        public WcfSoapClient(string url, string serviceInterfaceName)
            : this(url, serviceInterfaceName, Encoding.UTF8)
        { }

        public WcfSoapClient(string url, string serviceInterfaceName, Encoding encoding)
        {
            if (String.IsNullOrEmpty(serviceInterfaceName)) throw new ArgumentException("serviceInterfaceName is null");

            _serviceInterfaceName = serviceInterfaceName;
            _soapClient = new SoapClient(url, encoding);
        }

        public TResult Invoke<TResult>(string operationName, params SoapParameter[] parameters)
            where TResult : class, new()
        {
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", _serviceInterfaceName, operationName);
            return _soapClient.Invoke<TResult>(soapAction, operationName, parameters);
        }
    }
}
