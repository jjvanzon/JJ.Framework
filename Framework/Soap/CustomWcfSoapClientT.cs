using JJ.Framework.Reflection;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Soap
{
	/// <summary>
	/// This class exists because some mobile platforms running on Mono
	/// do not fully support System.ServiceModel or System.Web.Services.
	/// </summary>
	public class CustomWcfSoapClient<TServiceInterface>
	{
		private CustomWcfSoapClient _client;

		/// <summary>
		/// This class exists because some mobile platforms running on Mono
		/// do not fully support System.ServiceModel or System.Web.Services.
		/// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
		/// </summary>
		public CustomWcfSoapClient(string url)
			: this(url, Encoding.UTF8)
		{ }

		/// <summary>
		/// This class exists because some mobile platforms running on Mono
		/// do not fully support System.ServiceModel or System.Web.Services.
		/// </summary>
		public CustomWcfSoapClient(string url, Encoding encoding)
		{
			_client = new CustomWcfSoapClient(url, typeof(TServiceInterface).Name, encoding);
		}

		/// <summary>
		/// This class exists because some mobile platforms running on Mono
		/// do not fully support System.ServiceModel or System.Web.Services.
		/// </summary>
		/// <param name="sendMessageDelegate">
		/// You can handle the sending of the SOAP message and the receiving of the response yourself
		/// by passing this sendMessageDelegate. This is for environments that do not support HttpWebRequest.
		/// First parameter of the delegate is SOAP action, second parameter is SOAP message as an XML string,
		/// return value should be text received.
		/// </param>
		public CustomWcfSoapClient(string url, Func<string, string, string> sendMessageDelegate)
		{
			_client = new CustomWcfSoapClient(url, typeof(TServiceInterface).Name, sendMessageDelegate);
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
