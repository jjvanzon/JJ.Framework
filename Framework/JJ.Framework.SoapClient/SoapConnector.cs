using JJ.Framework.IO;
using JJ.Framework.Xml.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.SoapClient
{
    public class SoapConnector
    {
        private const string HTTP_METHOD_POST = "POST";

        private string _url;
        private IList<XmlNamespaceMapping> _xmlNamespaceMappings;
        private string _soapNamespacePrefix;
        private string _operationNamespacePrefix;
        private Encoding _encoding;

        public SoapConnector(
            string url,
            IEnumerable<XmlNamespaceMapping> xmlNamespaceMappings, 
            string soapXmlNamespacePrefix, 
            string operationXmlNamespacePrefix,
            Encoding encoding)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentException("url cannot be null or empty");
            if (xmlNamespaceMappings == null) throw new ArgumentNullException("xmlNamespaceMappings");
            if (String.IsNullOrEmpty(soapXmlNamespacePrefix)) throw new ArgumentException("soapXmlNamespacePrefix cannot be null or empty.");
            if (String.IsNullOrEmpty(operationXmlNamespacePrefix)) throw new ArgumentException("operationXmlNamespacePrefix cannot be null or empty.");
            if (encoding == null) throw new ArgumentNullException("encoding");

            _url = url;
            _xmlNamespaceMappings = xmlNamespaceMappings.ToArray();
            _soapNamespacePrefix = soapXmlNamespacePrefix;
            _operationNamespacePrefix = operationXmlNamespacePrefix;
            _encoding = encoding;
        }

        public TResult Invoke<TResult>(string soapAction, string operationName, params SoapParameter[] parameters)
            where TResult : class, new()
        {
            byte[] dataToSend = GetDataToSend(operationName, parameters);
            HttpWebRequest request = CreateSoapRequest(_url, soapAction, dataToSend);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, _encoding))
                    {
                        string dataReceived = reader.ReadToEnd();
                        TResult result = ParseReceivedData<TResult>(dataReceived);
                        return result;
                    }
                }
            }
        }

        private byte[] GetDataToSend(string operationName, SoapParameter[] parameters)
        {
            XElement element = CreateSoapXElement(operationName, parameters);
            string text = element.ToString();
            byte[] dataToSend = StreamHelper.StringToBytes(text, _encoding);
            return dataToSend;
        }

        private XElement CreateSoapXElement(string operationName, SoapParameter[] parameters)
        {
            string soapNamespaceString = "http://schemas.xmlsoap.org/soap/envelope/";
            string operationNamespaceString = "http://tempuri.org/";

            XNamespace s = soapNamespaceString;
            XNamespace o = operationNamespaceString;

            XElement operationElement;

            // Create SOAP envelope.
            var envelopeElement =
                new XElement(s + "Envelope",
                    new XAttribute(XNamespace.Xmlns + _soapNamespacePrefix, soapNamespaceString),
                    new XAttribute(XNamespace.Xmlns + _operationNamespacePrefix, operationNamespaceString),
                    new XElement(s + "Header"),
                    new XElement(s + "Body",
                        operationElement = new XElement(o + operationName)));

            foreach (SoapParameter parameter in parameters)
            {
                var converter = new ObjectToXmlConverter(XmlCasingEnum.UnmodifiedCase, _xmlNamespaceMappings, rootElementName: parameter.Name);
                XElement parameterElement = converter.ConvertObjectToXElement(parameter.Value);

                // Add namespace prefix to parameterElement.
                parameterElement.Name = o.GetName(parameterElement.Name.LocalName);

                operationElement.Add(parameterElement);
            }

            return envelopeElement;
        }

        private HttpWebRequest CreateSoapRequest(string url, string soapAction, byte[] content)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = HTTP_METHOD_POST;
            request.ContentLength = content.Length;
            request.ContentType = @"text/xml;charset=""utf-8""";
            request.Accept = "text/xml";
            request.Headers.Add("SOAPAction", soapAction);

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(content, 0, content.Length);

            return request;
        }

        private TResult ParseReceivedData<TResult>(string data)
            where TResult : class, new()
        {
            XNamespace def = "http://tempuri.org/";
            //XNamespace vm = "http://schemas.datacontract.org/2004/07/JJ.Apps.SetText.ViewModels";

            XElement root = XElement.Parse(data);
            XElement saveResult = root.Descendants(def + "SaveResult").Single();

            var converter = new XmlToObjectConverter<TResult>(XmlCasingEnum.UnmodifiedCase);
            TResult result = converter.Convert(saveResult);
            return result;
        }
    }
}
