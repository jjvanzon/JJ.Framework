using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JJ.Framework.Xml.Linq;

namespace JJ.Framework.Soap
{
    public class SoapFormatter
    {
        private const string SOAP_ENVELOPE_NAMESPACE_NAME = "http://schemas.xmlsoap.org/soap/envelope/";
        private const string DEFAULT_NAMESPACE_NAME = "http://tempuri.org/";

        /// <summary> nullable </summary>
        private readonly IEnumerable<CustomArrayItemNameMapping> _customArrayItemNameMappings;

        /// <summary> nullable </summary>
        private Dictionary<string, string> _namespaceDictionary;

        /// <summary>
        /// This class exists because some mobile platforms running on Mono
        /// do not fully support System.ServiceModel or System.Web.Services.
        /// </summary>
        /// <param name="namespaceMappings">
        /// If set to null, standard WCF namespaces are generated. Otherwise the provided namespaces are used.
        /// If a namespace mapping is missing, it will remain unchanged.
        /// </param>
        public SoapFormatter(
            IEnumerable<SoapNamespaceMapping> namespaceMappings = null,
            IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = null)
        {
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

        public string GetStringToSend(string operationName, SoapParameter[] parameters)
        {
            XElement element = CreateSoapXElement(operationName, parameters);
            string text = element.ToString();
            return text;
        }

        public TResult ParseStringReceived<TResult>(string operationName, string data)
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
            var converter = new XmlToObjectConverter<TResult>(
                XmlCasingEnum.UnmodifiedCase,
                true,
                _customArrayItemNameMappings);

            TResult result = converter.Convert(saveResult);
            return result;
        }

        private XElement CreateSoapXElement(string operationName, SoapParameter[] parameters)
        {
            XNamespace s = SOAP_ENVELOPE_NAMESPACE_NAME;
            XNamespace o = DEFAULT_NAMESPACE_NAME;

            XElement operationElement;

            // Create SOAP envelope.
            var envelopeElement =
                new XElement(
                    s + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "s", SOAP_ENVELOPE_NAMESPACE_NAME),
                    new XAttribute(XNamespace.Xmlns + "o", DEFAULT_NAMESPACE_NAME),
                    new XElement(s + "Header"),
                    new XElement(
                        s + "Body",
                        operationElement = new XElement(o + operationName)));

            foreach (SoapParameter parameter in parameters)
            {
                var converter = new ObjectToXmlConverter(
                    XmlCasingEnum.UnmodifiedCase,
                    true,
                    true,
                    true,
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
        /// Apply namespace mappings i.e. translate the standard WCF namespaces to the provided custom ones by traversing the whole
        /// XML tree.
        /// </summary>
        private void ApplyNamespaceMappings(XElement root)
        {
            if (_namespaceDictionary != null)
            {
                // Replace the namespace of each element.
                foreach (XElement element in root.DescendantsAndSelf())
                {
                    string originalNamespaceName = element.Name.NamespaceName;

                    if (_namespaceDictionary.TryGetValue(originalNamespaceName, out string newNamespaceName))
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

                        if (_namespaceDictionary.TryGetValue(originalNamespaceName2, out string newNamespaceName2))
                        {
                            xmlnsAttribute.Value = newNamespaceName2;
                        }
                    }
                }
            }
        }
    }
}