using JJ.Framework.IO;
using JJ.Framework.Xml.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using JJ.Framework.Common;

namespace JJ.Framework.Soap
{
    /// <summary>
    /// This class exists because some mobile platforms running on Mono
    /// do not fully support System.ServiceModel or System.Web.Services.
    /// </summary>
    public class SoapClient
    {
        private const string HTTP_METHOD_POST = "POST";
        private const string SOAP_ENVELOPE_NAMESPACE_NAME = "http://schemas.xmlsoap.org/soap/envelope/";
        private const string DEFAULT_NAMESPACE_NAME = "http://tempuri.org/";

        private string _url;
        private Encoding _encoding;

        /// <summary> nullable </summary>
        private Dictionary<string, string> _namespaceDictionary;

        /// <summary> nullable </summary>
        private IEnumerable<CustomArrayItemNameMapping> _customArrayItemNameMappings;

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
            if (String.IsNullOrEmpty(url)) throw new ArgumentException("url cannot be null or empty");
            if (encoding == null) throw new ArgumentNullException("encoding");

            _url = url;
            _encoding = encoding;
            _customArrayItemNameMappings = customArrayItemNameMappings;

            InitializeNamespaceMappings(namespaceMappings);
        }

        /// <param name="namespaceMappings">nullable</param>
        private void InitializeNamespaceMappings(IEnumerable<SoapNamespaceMapping> namespaceMappings)
        {
            if (namespaceMappings != null)
            {
                _namespaceDictionary = namespaceMappings.ToDictionary(x => x.SourceXmlNamespace, x => x.DestXmlNamespace);
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
                        TResult result = ParseReceivedData<TResult>(operationName, dataReceived);
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
            XNamespace s = SOAP_ENVELOPE_NAMESPACE_NAME;
            XNamespace o = DEFAULT_NAMESPACE_NAME;

            XElement operationElement;

            // Create SOAP envelope.
            var envelopeElement =
                new XElement(s + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "s", SOAP_ENVELOPE_NAMESPACE_NAME),
                    new XAttribute(XNamespace.Xmlns + "o", DEFAULT_NAMESPACE_NAME),
                    new XElement(s + "Header"),
                    new XElement(s + "Body",
                        operationElement = new XElement(o + operationName)));

            foreach (SoapParameter parameter in parameters)
            {
                var converter = new ObjectToXmlConverter
                (
                    XmlCasingEnum.UnmodifiedCase,
                    mustGenerateNamespaces: true,
                    mustGenerateNilAttributes: true,
                    mustSortElementsByName: true,
                    rootElementName: parameter.Name,
                    customArrayItemNameMappings: _customArrayItemNameMappings
                );

                XElement parameterElement = converter.ConvertObjectToXElement(parameter.Value);

                // Add operation namespace prefix to parameterElement.
                // (The ObjectToXmlConvert will return it namespace-less, but we need to put it in the operation namespace.)
                parameterElement.Name = o.GetName(parameterElement.Name.LocalName);

                operationElement.Add(parameterElement);
            }

            ApplyNamespaceMappings(envelopeElement);

            return envelopeElement;
        }

        /// <summary>
        /// Apply namespace mappings i.e. translate the standard WCF namespaces to the provided custom ones by traversing the whole XML tree.
        /// </summary>
        private void ApplyNamespaceMappings(XElement root)
        {
            if (_namespaceDictionary != null)
            {
                // Replace the namespace of each element.
                foreach (XElement element in root.DescendantsAndSelf())
                {
                    string originalNamespaceName = element.Name.NamespaceName;
                    string newNamespaceName;

                    if (_namespaceDictionary.TryGetValue(originalNamespaceName, out newNamespaceName))
                    {
                        XNamespace newNamespace = newNamespaceName;
                        element.Name = newNamespace.GetName(element.Name.LocalName);
                    }

                    // Replace the xmlns's
                    IList<XAttribute> xmlnsAttributes = element.Attributes()
                                                               .Where(x => x.Name.Namespace == XNamespace.Xmlns)
                                                               .ToArray();

                    foreach (XAttribute xmlnsAttribute in xmlnsAttributes)
                    {
                        string originalNamespaceName2 = xmlnsAttribute.Value;
                        string newNamespaceName2;
                        if (_namespaceDictionary.TryGetValue(originalNamespaceName2, out newNamespaceName2))
                        {
                            xmlnsAttribute.Value = newNamespaceName2;
                        }
                    }
                }
            }
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

        private TResult ParseReceivedData<TResult>(string operationName, string data)
            where TResult : class, new()
        {
            XNamespace o = DEFAULT_NAMESPACE_NAME;

            XElement root = XElement.Parse(data);
            string elementName = operationName + "Result";
            XElement saveResult = root.Descendants(o + elementName).Single();

            // You do not need to apply namespace mappings,
            // because namespaces of the elements are ignored when parsing the XML.
            // Ignoring namespaces should not be a problem,
            // because the converter looks at the property names,
            // which should match with the XML element names.
            var converter = new XmlToObjectConverter<TResult>(XmlCasingEnum.UnmodifiedCase);
            TResult result = converter.Convert(saveResult);
            return result;
        }
    }
}
