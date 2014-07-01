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
        private Dictionary<string, XmlNamespaceMapping> _dictionary;

        public NamespaceResolver(IEnumerable<XmlNamespaceMapping> namespaceMappings)
        {
            if (namespaceMappings == null) throw new ArgumentNullException("namespaceMappings");

            _dictionary = namespaceMappings.ToDictionary(x => x.DotNetNamespace);
        }

        public IEnumerable<XAttribute> GetAllNamespaceDeclarationAttributes()
        {
            foreach (XmlNamespaceMapping mapping in _dictionary.Values)
            {
                yield return new XAttribute(XNamespace.Xmlns + mapping.XmlNamespacePrefix, mapping.XmlNamespace);
            }
        }

        public XName GetXName(string name, PropertyInfo property)
        {
            return GetXName(name, property.DeclaringType);
        }

        /// <param name="type">For properties the type must be the type that the property is part of, not the type of the property value.</param>
        public XName GetXName(string name, Type type)
        {
            return GetXName(name, type.Namespace);
        }

        /// <param name="type">For properties the type must be the type that the property is part of, not the type of the property value.</param>
        public XName GetXName(string name, string dotNetNamespace)
        {
            string xmlNamespace = GetXmlNamespace(dotNetNamespace);
            if (xmlNamespace != null)
            {
                XNamespace xnamespace = xmlNamespace;
                return xnamespace + name;
            }
            else
            {
                // TODO: Perhaps a default namespace?
                return name;
            }
        }

        private string GetXmlNamespace(string dotNetNamespace)
        {
            XmlNamespaceMapping namespaceMapping;
            if (_dictionary.TryGetValue(dotNetNamespace, out namespaceMapping))
            {
                return namespaceMapping.XmlNamespace;
            }

            return null;
        }
    }
}
