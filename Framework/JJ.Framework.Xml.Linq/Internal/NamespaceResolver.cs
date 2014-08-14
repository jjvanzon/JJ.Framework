using JJ.Framework.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.Xml.Linq.Internal
{
    internal class NamespaceResolver
    {
        private HashSet<string> _xmlNamespaceStrings = new HashSet<string>();

        /// <summary>
        /// Adds an extra XML namespace on top of the ones generated on-the-fly.
        /// </summary>
        public void AddXmlNamespaceString(string xmlNamespaceString)
        {
            if (!_xmlNamespaceStrings.Contains(xmlNamespaceString))
            {
                _xmlNamespaceStrings.Add(xmlNamespaceString);
            }
        }

        public IEnumerable<XAttribute> GetNamespaceDeclarationAttributes()
        {
            int i = 0;

            foreach (string xmlNamespaceString in _xmlNamespaceStrings)
            {
                string namespacePrefix = NumberingSystems.ToLetterSequence(i, 'a', 'z');

                yield return new XAttribute(XNamespace.Xmlns + namespacePrefix, xmlNamespaceString);

                i++;
            }
        }

        public XName GetXName(string name, PropertyInfo property)
        {
            return GetXName(name, property.DeclaringType);
        }

        /// <param name="type">
        /// For properties the type must be the type that the property is part of, not the type of the property value.
        /// </param>
        public XName GetXName(string name, Type type)
        {
            return GetXName(name, type.Namespace);
        }
        
        private const string WCF_SOAP_NAMESPACE_START = "http://schemas.datacontract.org/2004/07/";

        /// <param name="type">
        /// For properties the type must be the type that the property is part of, not the type of the property value.
        /// </param>
        public XName GetXName(string name, string dotNetNamespace)
        {
            string xmlNamespaceString = WCF_SOAP_NAMESPACE_START + dotNetNamespace;

            // System.Xml.Linq will ensure that the same namespace is the same XNamespace instance.
            XNamespace xnamespace = xmlNamespaceString;

            // Maintain a list of used namespaces so that the GetNamespaceDeclarationAttributes can work.
            if (!_xmlNamespaceStrings.Contains(xmlNamespaceString))
            {
                _xmlNamespaceStrings.Add(xmlNamespaceString);
            }

            return xnamespace + name;
        }
    }
}
