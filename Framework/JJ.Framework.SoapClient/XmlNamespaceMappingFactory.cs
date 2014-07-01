using JJ.Framework.Common;
using JJ.Framework.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.SoapClient
{
    // TODO: Make internal if possible.
    public static class XmlNamespaceMappingFactory
    {
        public static XmlNamespaceMapping[] CreateXmlNamespaceMappings(params string[] dotNetNamespaces)
        {
            return CreateXmlNamespaceMappings(null, dotNetNamespaces);
        }

        /// <param name="excludedXmlNamespacePrefixes">
        /// Use this parameter to exclude certain prefixes from automatically generated prefixes.
        /// </param>
        public static XmlNamespaceMapping[] CreateXmlNamespaceMappings(string[] excludedXmlNamespacePrefixes, params string[] dotNetNamespaces)
        {
            XmlNamespaceMapping[] mappings = new XmlNamespaceMapping[dotNetNamespaces.Length];

            for (int i = 0; i < dotNetNamespaces.Length; i++)
            {
                string dotNetNamespace = dotNetNamespaces[i];
                XmlNamespaceMapping mapping = XmlNamespaceMappingFactory.CreateXmlNamespaceMapping(dotNetNamespace, excludedXmlNamespacePrefixes);
                mappings[i] = mapping;
            }

            return mappings;
        }

        /// <param name="excludedXmlNamespacePrefixes">
        /// Use this parameter to exclude certain prefixes from automatically generated prefixes.
        /// </param>
        public static XmlNamespaceMapping CreateXmlNamespaceMapping(string dotNetNamespace, string[] excludedXmlNamespacePrefixes = null)
        {
            string xmlNamespace = "http://schemas.datacontract.org/2004/07/" + dotNetNamespace;
            string xmlNamespacePrefix = GetXmlNamespacePrefix(dotNetNamespace, excludedXmlNamespacePrefixes);
            return new XmlNamespaceMapping(dotNetNamespace, xmlNamespace, xmlNamespacePrefix);
        }

        private static Dictionary<string, string> _xmlNamespacePrefixDictionary = new Dictionary<string, string>();

        // TODO: caching at static level and providing excluded thing as a parameter will not work.

        private static string GetXmlNamespacePrefix(string dotNetNamespace, string[] excludedXmlNamespacePrefixes = null)
        {
            string xmlNamespacePrefix;
            if (_xmlNamespacePrefixDictionary.TryGetValue(dotNetNamespace, out xmlNamespacePrefix))
            {
                return xmlNamespacePrefix;
            }

            // TODO: CutLeftUntil may not be full proof if it does not return the whole string if it does not contain "."
            string candidateXmlNamespacePrefix = dotNetNamespace.Split('.').Last().Left(1).ToLower();

            if (!XmlNamespacePrefixIsExcluded(candidateXmlNamespacePrefix, excludedXmlNamespacePrefixes))
            {
                if (!_xmlNamespacePrefixDictionary.ContainsValue(candidateXmlNamespacePrefix))
                {
                    _xmlNamespacePrefixDictionary.Add(dotNetNamespace, candidateXmlNamespacePrefix);
                    return candidateXmlNamespacePrefix;
                }
            }

            //candidateNamespacePrefix = 

            throw new NotImplementedException();
        }

        private static bool XmlNamespacePrefixIsExcluded(string candidateNamespacePrefix, string[] excludedXmlNamespacePrefixes = null)
        {
            if (excludedXmlNamespacePrefixes == null)
            {
                return false;
            }

            // This may not be fast if called frequently, but mappings are at most created at te beginning of the serialization procedure.
            return excludedXmlNamespacePrefixes.Contains(candidateNamespacePrefix);
        }

        // TODO: Maintain a counter, translate to a 26-based number.

        /*
        private int 
        private string GetOrdinalXmlNamespacePrefix()
        {

        }
        */
    }
}
