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

        public IEnumerable<XAttribute> GetNamespaceDeclarationAttributes(string firstNamespacePrefix)
        {
            int ordinal = NumberBase.FromBaseNNumber(firstNamespacePrefix, 26, 'a');

            foreach (string mapping in _xmlNamespaceStrings)
            {
                string namespacePrefix = NumberBase.ToBaseNNumber(ordinal, 26, 'a');

                yield return new XAttribute(XNamespace.Xmlns + namespacePrefix, mapping);

                ordinal++;
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

        /// <param name="type">
        /// For properties the type must be the type that the property is part of, not the type of the property value.
        /// </param>
        public XName GetXName(string name, string dotNetNamespace)
        {
            string xmlNamespaceString = "http://schemas.datacontract.org/2004/07/" + dotNetNamespace;

            // System.Xml.Linq will ensure that the same namespace is the same XNamespace instance.
            XNamespace xnamespace = xmlNamespaceString;

            if (!_xmlNamespaceStrings.Contains(xmlNamespaceString))
            {
                _xmlNamespaceStrings.Add(xmlNamespaceString);
            }

            return xnamespace + name;
        }
    }
}
