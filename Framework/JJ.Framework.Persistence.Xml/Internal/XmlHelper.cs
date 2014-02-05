using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml.Internal
{
    internal static class XmlHelper
    {
        public static XmlNode GetNode(XmlNode parentNode, string xpath)
        {
            XmlNode node = TryGetNode(parentNode, xpath);
            if (node == null)
            {
                throw new Exception(String.Format("Node '{0}' does not exist in parent node '{1}'.", xpath, parentNode.Name));
            }
            return node;
        }

        public static XmlNode TryGetNode(XmlNode parentNode, string xpath)
        {
            XmlNodeList nodes = parentNode.SelectNodes(xpath);
            switch (nodes.Count)
            {
                case 0:
                    return null;

                case 1:
                    return nodes[0];

                default:
                    throw new Exception(String.Format("Node '{0}' is not unique.", xpath));
            }
        }
    }
}
