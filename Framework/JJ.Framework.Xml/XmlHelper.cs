using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Xml
{
    public static class XmlHelper
    {
        /// <summary>
        /// Gets the node that matches the XPath.
        /// If the node is not unique or not found, an exception is thrown with a descriptive error message.
        /// </summary>
        public static XmlNode SelectNode(XmlNode node, string xpath)
        {
            XmlNode node2 = TrySelectNode(node, xpath);

            if (node2 == null)
            {
                throw new Exception(String.Format("{0} not found.", xpath));
            }

            return node2;
        }

        /// <summary>
        /// Tries to get the node that matches the XPath.
        /// If the node is not unique, an exception is thrown with a descriptive error message.
        /// Null is returned if the node is not found.
        /// </summary>
        public static XmlNode TrySelectNode(XmlNode node, string xpath)
        {
            XmlNodeList nodes = node.SelectNodes(xpath);

            if (nodes.Count > 1)
            {
                throw new Exception(String.Format("{0} was found multiple times.", xpath));
            }

            if (nodes.Count == 0)
            {
                return null;
            }

            XmlNode node2 = nodes[0];

            return node2;
        }
    }
}
