using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.IO;
using JJ.Framework.Xml.Linq;

namespace JJ.Framework.Soap
{
	/// <summary>
	/// This class exists because some mobile platforms running on Mono
	/// do not fully support System.ServiceModel or System.Web.Services.
	/// </summary>
	public class SoapClient
	{
		private const string HTTP_METHOD_POST = "POST";
		private const string DEFAULT_NAMESPACE_NAME = "http://tempuri.org/";

		private string _url;
		private Encoding _encoding;

		private SoapFormatter _soapFormatter;

		/// <summary>
		/// First parameter of the delegate is soapAction, second parameter is SOAP message as an XML string,
		/// return value should be text received.
		/// </summary>
		private Func<string, string, string> _sendMessageDelegate;

		/// <summary>
		/// This class exists because some mobile platforms running on Mono
		/// do not fully support System.ServiceModel or System.Web.Services.
		/// UTF-8 encoding is assumed. Use the other overload to specify encoding explicitly.
		/// </summary>
		/// <param name="namespaceMappings">
		/// If set to null, standard WCF namespaces are generated. Otherwise the provided namespaces are used.
		/// If a namespace mapping is missing, it will remain unchanged.
		/// </param>
		public SoapClient(
			string url,
			IEnumerable<SoapNamespaceMapping> namespaceMappings = null,
			IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = null)
			: this(url, Encoding.UTF8, namespaceMappings, customArrayItemNameMappings)
		{ }

		/// <summary>
		/// This class exists because some mobile platforms running on Mono
		/// do not fully support System.ServiceModel or System.Web.Services.
		/// </summary>
		/// <param name="namespaceMappings">
		/// If set to null, standard WCF namespaces are generated. Otherwise the provided namespaces are used.
		/// If a namespace mapping is missing, it will remain unchanged.
		/// </param>
		public SoapClient(
			string url, Encoding encoding,
			IEnumerable<SoapNamespaceMapping> namespaceMappings = null,
			IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = null)
		{
			if (string.IsNullOrEmpty(url)) throw new ArgumentException("url cannot be null or empty");
			if (encoding == null) throw new NullException(() => encoding);

			_url = url;
			_encoding = encoding;
			_sendMessageDelegate = SendMessage;

			_soapFormatter = new SoapFormatter(namespaceMappings, customArrayItemNameMappings);
		}

		/// <summary>
		/// This class exists because some mobile platforms running on Mono
		/// do not fully support System.ServiceModel or System.Web.Services.
		/// </summary>
		/// <param name="namespaceMappings">
		/// If set to null, standard WCF namespaces are generated. Otherwise the provided namespaces are used.
		/// If a namespace mapping is missing, it will remain unchanged.
		/// </param>
		/// <param name="sendMessageDelegate">
		/// You can handle the sending of the SOAP message and the receiving of the response yourself
		/// by passing this sendMessageDelegate. This is for environments that do not support HttpWebRequest.
		/// First parameter of the delegate is SOAP action, second parameter is SOAP message as an XML string,
		/// return value should be text received.
		/// </param>
		public SoapClient(
			string url, Func<string, string, string> sendMessageDelegate,
			IEnumerable<SoapNamespaceMapping> namespaceMappings = null,
			IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = null)
		{
			if (string.IsNullOrEmpty(url)) throw new ArgumentException("url cannot be null or empty");

			_url = url;
			_sendMessageDelegate = sendMessageDelegate ?? throw new NullException(() => sendMessageDelegate);

			_soapFormatter = new SoapFormatter(namespaceMappings, customArrayItemNameMappings);
		}


		public TResult Invoke<TResult>(string soapAction, string operationName, params SoapParameter[] parameters)
			where TResult : class, new()
		{
			string textToSend = _soapFormatter.GetStringToSend(operationName, parameters);
			string textReceived = _sendMessageDelegate(soapAction, textToSend);
			TResult result = _soapFormatter.ParseStringReceived<TResult>(operationName, textReceived);
			return result;
		}

		private string SendMessage(string soapAction, string textToSend)
		{
			byte[] bytesToSend = StreamHelper.StringToBytes(textToSend, _encoding);

			HttpWebRequest request = CreateSoapRequest(_url, soapAction, bytesToSend);

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					using (var reader = new StreamReader(responseStream, _encoding))
					{
						string textReceived = reader.ReadToEnd();
						return textReceived;
					}
				}
			}
		}

		private HttpWebRequest CreateSoapRequest(string url, string soapAction, byte[] content)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = HTTP_METHOD_POST;
			request.ContentLength = content.Length;
			// TODO: The charset should actually vary with the encoding.
			request.ContentType = @"text/xml;charset=""utf-8""";
			request.Accept = "text/xml";
			request.Headers.Add("SOAPAction", soapAction);

			Stream requestStream = request.GetRequestStream();
			requestStream.Write(content, 0, content.Length);

			return request;
		}
	}
}
