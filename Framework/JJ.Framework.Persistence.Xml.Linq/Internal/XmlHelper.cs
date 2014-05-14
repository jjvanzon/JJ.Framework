using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.Persistence.Xml.Linq.Internal
{
    internal static class XmlHelper
    {
        [Obsolete("You cannot use XPath with System.Xml.Linq. Refactor any call to this method.", true)]
        public static XNode GetNode(XNode parentNode, string xpath)
        {
            throw new NotImplementedException();
            //XNode node = TryGetNode(parentNode, xpath);
            //if (node == null)
            //{
            //    throw new Exception(String.Format("Node '{0}' does not exist in parent node '{1}'.", xpath, parentNode.Name));
            //}
            //return node;
        }

        [Obsolete("You cannot use XPath with System.Xml.Linq. Refactor any call to this method.", true)]
        public static XNode TryGetNode(XNode parentNode, string xpath)
        {
            throw new NotImplementedException();
            //XmlNodeList nodes = parentNode.SelectNodes(xpath);
            //switch (nodes.Count)
            //{
            //    case 0:
            //        return null;

            //    case 1:
            //        return nodes[0];

            //    default:
            //        throw new Exception(String.Format("Node '{0}' is not unique.", xpath));
            //}
        }
    }
}
