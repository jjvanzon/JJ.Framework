using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using JJ.Framework.Common;

namespace JJ.Framework.Configuration
{
    internal class XmlExpressionTranslator
    {
        private XmlNode _rootXmlNode;

        private Stack<XmlNode> _stack = new Stack<XmlNode>();

        public XmlExpressionTranslator(XmlNode rootXmlNode)
        {
            if (rootXmlNode == null) throw new ArgumentNullException("rootXmlNode");
            _rootXmlNode = rootXmlNode;
            _stack.Push(_rootXmlNode);
        }

        public string Result
        {
            get 
            {
                XmlNode xmlNode = _stack.Peek();
                if (xmlNode == null)
                {
                    return null;
                }
                return xmlNode.InnerText;
            }
        }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Visit((LambdaExpression)expression);
        }

        public void Visit(LambdaExpression expression)
        {
            Visit(expression.Body);
        }

        private void Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.MemberAccess:
                    {
                        var memberExpression = (MemberExpression)node;
                        VisitMember(memberExpression);
                        return;
                    }

                //case ExpressionType.ArrayLength:
                //    {
                //        var unaryExpression = (UnaryExpression)node;
                //        VisitArrayLength(unaryExpression);
                //        return;
                //    }

                case ExpressionType.ArrayIndex:
                    {
                        var binaryExpression = (BinaryExpression)node;
                        VisitArrayIndex(binaryExpression);
                        return;
                    }

                case ExpressionType.Parameter:
                    {
                        // Ignore
                        return;
                    }
            }

            throw new NotSupportedException(String.Format("NodeType '{0}' not supported.", node.NodeType));
        }

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            switch (node.Member.MemberType)
            {
                case MemberTypes.Field:
                case MemberTypes.Property:
                    VisitFieldOrProperty(node);
                    break;

                default:
                    throw new NotSupportedException(String.Format("MemberType {0} not supported.", node.Member.MemberType));
            }
        }

        private void VisitFieldOrProperty(MemberExpression node)
        {
            XmlNode parentXmlNode = _stack.Pop();

            XmlNode childXmlNode = GetChildXmlNode(parentXmlNode, node.Member);

            _stack.Push(childXmlNode);
        }

        private XmlNode GetChildXmlNode(XmlNode parentXmlNode, MemberInfo member)
        {
            // XML Attribute

            XmlAttributeAttribute xmlAttributeAttribute = member.GetCustomAttribute<XmlAttributeAttribute>();
            if (xmlAttributeAttribute != null)
            {
                string xmlAttributeName = FormatName(member.Name);
                if (!String.IsNullOrEmpty(xmlAttributeAttribute.AttributeName))
                {
                    xmlAttributeName = xmlAttributeAttribute.AttributeName;
                }

                string xpath = "@" + xmlAttributeName;

                XmlNode childXmlNode = parentXmlNode.SelectSingleNode(xpath);
                if (childXmlNode == null)
                {
                    throw new Exception(String.Format("XML attribute '{0}' not found.", xmlAttributeName));
                }

                return childXmlNode;
            }

            // Xml Element
            {
                string xmlElementName = FormatName(member.Name);

                XmlElementAttribute xmlElementAttribute = member.GetCustomAttribute<XmlElementAttribute>();
                if (xmlElementAttribute != null)
                {
                    if (!String.IsNullOrEmpty(xmlElementAttribute.ElementName))
                    {
                        xmlElementName = xmlElementAttribute.ElementName;
                    }
                }

                string xpath = xmlElementName;

                XmlNode childXmlNode = parentXmlNode.SelectSingleNode(xpath);
                if (childXmlNode == null)
                {
                    throw new Exception(String.Format("XML element '{0}' not found.", xmlElementName));
                }

                return childXmlNode;
            }
        }

        private string FormatName(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Left(1).ToLower() + input.CutLeft(1);
        }

        // Array[i] does not work, only Array[0], so ArrayLength is also not useful then.
        //private void VisitArrayLength(UnaryExpression node)
        //{
        //    if (node.Operand.NodeType == ExpressionType.MemberAccess)
        //    {
        //        var arrayExpression = (MemberExpression)node.Operand;
        //
        //        XmlNodeList xmlNodes = VisitArray(arrayExpression);
        //
        //        // HACK:
        //        // You want to put the array length on the stack,
        //        // but you can only put XmlNodes on the stack,
        //        // and array length is not an XmlNode, so create one.
        //        // TODO: Refactor so that int can be put on the stack.
        //        XmlDocument dummyXmlDocument = new XmlDocument();
        //        XmlNode arrayLengthXmlNode = dummyXmlDocument.CreateElement("arrayLength");
        //        arrayLengthXmlNode.InnerText = xmlNodes.Count.ToString();
        //        _stack.Push(arrayLengthXmlNode);
        //
        //        return;
        //    }
        //
        //    throw new ArgumentException(String.Format("Value cannot be obtained from NodeType {0}.", node.Operand.NodeType));
        //}

        private void VisitArrayIndex(BinaryExpression node)
        {
            // TODO: At least support [i] instead of just [0].
            if (!(node.Right is ConstantExpression))
            {
                throw new NotSupportedException("Array index must be a constant.");
            }

            var indexExpression = (ConstantExpression)node.Right;
            int index = (int)indexExpression.Value;

            var arrayExpression = (MemberExpression)node.Left;
            XmlNodeList xmlNodes = VisitArray(arrayExpression);

            if (index > xmlNodes.Count - 1)
            {
                throw new IndexOutOfRangeException(String.Format("{0} does not have index [{1}].", arrayExpression.Member.Name, index));
            }
            XmlElement arrayItemXml = (XmlElement)xmlNodes[index];
            _stack.Push(arrayItemXml);
        }

        private XmlNodeList VisitArray(MemberExpression arrayExpression)
        {
            // HACK:
            // This method should have returned void and put XmlNodeList on the stack,
            // The stack can only hold XmlNodes for now.
            // TODO: Refactor so that XmlNodeList can be put on the stack.
            // Or maybe refactoring the system entirely will make a separate VisitArray method not required anymore.

            VisitMember(arrayExpression);

            XmlElement arrayXml = (XmlElement)_stack.Pop();

            XmlArrayItemAttribute xmlArrayItemAttribute = arrayExpression.Member.GetCustomAttribute<XmlArrayItemAttribute>();
            if (xmlArrayItemAttribute != null)
            {
                string elementName = xmlArrayItemAttribute.ElementName;
                if (!String.IsNullOrEmpty(elementName))
                {
                    return arrayXml.GetElementsByTagName(elementName);
                }
            }

            throw new NotSupportedException("Array properties must have an XmlArrayItem attribute with a name.");
        }
    }
}
