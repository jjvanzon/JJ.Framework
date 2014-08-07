using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Soap
{
    /// <summary>
    /// This class exists because some mobile platforms running on Mono
    /// do not fully support System.ServiceModel or System.Web.Services.
    /// </summary>
    public class WcfSoapClient<TServiceInterface>
    {
        private WcfSoapClient _client;

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
        /// </summary>
        public WcfSoapClient(string url)
            : this(url, Encoding.UTF8)
        { }

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// </summary>
        public WcfSoapClient(string url, Encoding encoding)
        {
            _client = new WcfSoapClient(url, typeof(TServiceInterface).Name, encoding);
        }

        public TResult Invoke<TResult>(Expression<Func<TServiceInterface, TResult>> expression)
            where TResult : class, new()
        {
            MethodCallInfo methodCallInfo = ExpressionHelper.GetMethodCallInfo(expression);
            SoapParameter[] soapParameters = methodCallInfo.Parameters.Select(x => new SoapParameter(x.Name, x.Value)).ToArray();
            TResult result = _client.Invoke<TResult>(methodCallInfo.Name, soapParameters);
            return result;
        }

        // TODO: A method like Invoke but then returns void.
    }
}
