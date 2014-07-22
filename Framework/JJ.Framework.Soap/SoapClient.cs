using JJ.Framework.IO;
using JJ.Framework.Xml.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.Soap
{
    public class SoapClient
    {
        private const string HTTP_METHOD_POST = "POST";

        private string _url;
        private Encoding _encoding;

        /// <summary> nullable </summary>
        private IList<NamespaceMapping> _namespaceMappings;

        /// <param name="namespaceMappings">
        /// If set to null, standard WCF namespaces are generated. Otherwise the namespaces provided are used.
        /// </param>
        public SoapClient(
            string url, Encoding encoding, 
            IEnumerable<NamespaceMapping> namespaceMappings = null)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentException("url cannot be null or empty");
            if (encoding == null) throw new ArgumentNullException("encoding");

            _url = url;
            _encoding = encoding;

            if (namespaceMappings != null)
            {
                _namespaceMappings = namespaceMappings.ToArray();
            }
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
                    new XAttribute(XNamespace.Xmlns + "s", soapNamespaceString),
                    new XAttribute(XNamespace.Xmlns + "o", operationNamespaceString),
                    new XElement(s + "Header"),
                    new XElement(s + "Body",
                        operationElement = new XElement(o + operationName)));

            foreach (SoapParameter parameter in parameters)
            {
                var converter = new ObjectToXmlConverter
                (
                    XmlCasingEnum.UnmodifiedCase, 
                    mustGenerateNamespaces: true, 
                    rootElementName: parameter.Name
                );

                XElement parameterElement = converter.ConvertObjectToXElement(parameter.Value);

                // Add operation namespace prefix to parameterElement.
                // (The ObjectToXmlConvert will return it namespace-less, but we need to put it in the operation namespace.)
                parameterElement.Name = o.GetName(parameterElement.Name.LocalName);

                operationElement.Add(parameterElement);
            }

            // TODO: Apply namespace mappings i.e. translate the standard WCF namespaces to the custom ones provided by traversing the whole XML tree.

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
