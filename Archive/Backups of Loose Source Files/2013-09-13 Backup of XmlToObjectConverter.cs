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
using JJ.Framework.Reflection;

namespace JJ.Framework.Configuration
{
    internal class XmlToObjectConverter<T>
        where T: new()
    {
        public T Convert(XmlNode sourceXmlNode)
        {
            T destObj = new T();
            ConvertProperties(sourceXmlNode, destObj);
            return destObj;
        }

        private void ConvertProperties(XmlNode sourceXmlNode, object destObj)
        {
            foreach (PropertyInfo destProperty in destObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                NodeType nodeType = GetNodeType(destProperty);
                switch (nodeType)
                {
                    case NodeType.Attribute:
                        ConvertXmlAttribute(sourceXmlNode, destObj, destProperty);
                        break;

                    case NodeType.Element:
                        ConvertXmlElement(sourceXmlNode, destObj, destProperty);
                        break;

                    case NodeType.Array:
                        ConvertXmlArray(sourceXmlNode, destObj, destProperty);
                        break;

                    default:
                        throw new InvalidEnumValueException(nodeType);
                }
            }
        }

        private NodeType GetNodeType(PropertyInfo destProperty)
        {
            bool hasXmlAttributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>() != null;
            bool hasXmlElementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>() != null;
            bool hasXmlArrayAttribute = destProperty.GetCustomAttribute<XmlArrayAttribute>() != null;
            bool hasXmlArrayItemAttribute = destProperty.GetCustomAttribute<XmlArrayItemAttribute>() != null;
            bool isArrayType = destProperty.PropertyType.IsAssignableTo(typeof(Array));

            if (isArrayType)
            {
                bool isValidArrayProperty = !hasXmlAttributeAttribute && !hasXmlElementAttribute;
                if (!isValidArrayProperty)
                {
                    // TODO: Add an exception message.
                    throw new Exception();
                }
                return NodeType.Array;
            }

            else if (hasXmlAttributeAttribute)
            {
                bool isValidAttributeProperty = !hasXmlElementAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
                if (!isValidAttributeProperty)
                {
                    // TODO: Add an exception message.
                    throw new Exception();
                }
                return NodeType.Attribute;
            }

            else
            {
                bool isValidElementProperty = !hasXmlAttributeAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
                if (!isValidElementProperty)
                {
                    // TODO: Add an exception message.
                    throw new Exception();
                }
                return NodeType.Element;
            }
        }

        // XML Attributes

        private void ConvertXmlAttribute(XmlNode sourceParentXmlNode, object destObj, PropertyInfo destProperty)
        {
            XmlAttribute sourceXmlAttribute = GetSourceXmlAttribute(sourceParentXmlNode, destProperty);
            string sourceValue = GetXmlAttributeValue(sourceXmlAttribute);
            object destValue = ConfigurationHelper.ConvertValue(sourceValue, destProperty.PropertyType);
            destProperty.SetValue(destObj, destValue);
        }

        private XmlAttribute GetSourceXmlAttribute(XmlNode sourceParentXmlNode, PropertyInfo destProperty)
        {
            string xmlAttributeName = GetXmlAttributeName(destProperty);
            string xpath = "@" + xmlAttributeName;

            XmlAttribute sourceXmlAttribute = (XmlAttribute)sourceParentXmlNode.SelectSingleNode(xpath);
            if (sourceXmlAttribute == null)
            {
                if (!IsNullable(destProperty.PropertyType))
                {
                    //throw new Exception(String.Format("Property '{0}' cannot be null and XML attribute '{1}' is not found.", destProperty.Name, xmlAttributeName));
                    //throw new Exception(String.Format("XML attribute '{0}' is required.", xmlAttributeName));
                    throw new Exception(String.Format("XML node '{0}' does not have the required attribute '{1}'.", sourceParentXmlNode.Name, xmlAttributeName));
                }
            }

            return sourceXmlAttribute;
        }

        private string GetXmlAttributeName(PropertyInfo destProperty)
        {
            XmlAttributeAttribute xmlAttributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>();
            if (!String.IsNullOrEmpty(xmlAttributeAttribute.AttributeName))
            {
                return xmlAttributeAttribute.AttributeName;
            }
            else
            {
                return FormatName(destProperty.Name);
            }
        }

        private string GetXmlAttributeValue(XmlAttribute sourceXmlAttribute)
        {
            return sourceXmlAttribute != null ? sourceXmlAttribute.Value : null;
        }

        // XML Elements

        private void ConvertXmlElement(XmlNode sourceParentXmlNode, object destObj, PropertyInfo destProperty)
        {
            XmlElement sourceXmlElement = GetSourceXmlElement(sourceParentXmlNode, destProperty);

            Type type = destProperty.PropertyType;

            if (IsLeafType(type))
            {
                string sourceValue = GetXmlElementValue(sourceXmlElement);
                object destValue = ConfigurationHelper.ConvertValue(sourceValue, type);
                destProperty.SetValue(destObj, destValue);
            }
            else
            {
                object destValue = Activator.CreateInstance(type);
                destProperty.SetValue(destObj, destValue);

                // Recursive call
                ConvertProperties(sourceXmlElement, destValue);
            }
        }

        private XmlElement GetSourceXmlElement(XmlNode sourceParentXmlNode, PropertyInfo destProperty)
        {
            string xmlElementName = GetXmlElementName(destProperty);
            string xpath = xmlElementName;

            XmlElement sourceXmlElement = (XmlElement)sourceParentXmlNode.SelectSingleNode(xpath);
            if (sourceXmlElement == null)
            {
                if (!IsNullable(destProperty.PropertyType))
                {
                    //throw new Exception(String.Format("Property '{0}' cannot be null and XML element '{1}' is not found.", destProperty.Name, xmlElementName));
                    //throw new Exception(String.Format("XML element '{0}' is required.", xmlElementName));
                    throw new Exception(String.Format("XML node '{0}' does not have the required child element '{1}'.", sourceParentXmlNode.Name, xmlElementName));
                }
            }

            return sourceXmlElement;
        }

        private string GetXmlElementName(PropertyInfo destProperty)
        {
            XmlElementAttribute xmlElementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>();
            if (xmlElementAttribute != null)
            {
                if (!String.IsNullOrEmpty(xmlElementAttribute.ElementName))
                {
                    return xmlElementAttribute.ElementName;
                }
            }

            return FormatName(destProperty.Name);
        }

        private string GetXmlElementValue(XmlElement sourceXmlElement)
        {
            return sourceXmlElement != null ? sourceXmlElement.InnerText : null;
        }

        // XML Arrays

        private void ConvertXmlArray(XmlNode sourceParentXmlNode, object destObj, PropertyInfo destArrayProperty)
        {
            XmlElement sourceXmlArray = TryGetSourceXmlArray(sourceParentXmlNode, destArrayProperty);
            if (sourceXmlArray == null)
            {
                return;
            }
            XmlNodeList sourceXmlArrayItems = GetSourceXmlArrayItems(sourceXmlArray, destArrayProperty);

            Type arrayType = destArrayProperty.PropertyType;
            Array destArray = (Array)Activator.CreateInstance(arrayType, sourceXmlArrayItems.Count);
            destArrayProperty.SetValue(destObj, destArray);

            Type itemType = destArrayProperty.PropertyType.GetElementType();

            for (int i = 0; i < sourceXmlArrayItems.Count; i++)
            {
                XmlElement sourceXmlArrayItem = (XmlElement)sourceXmlArrayItems[i];

                if (IsLeafType(itemType))
                {
                    string sourceValue = GetXmlArrayItemValue(sourceXmlArrayItem);
                    object destValue = ConfigurationHelper.ConvertValue(sourceValue, itemType);

                    destArray.SetValue(destValue, i);
                }
                else
                {
                    object destValue = Activator.CreateInstance(itemType);
                    destArray.SetValue(destValue, i);

                    // Recursive call
                    ConvertProperties(sourceXmlArrayItem, destValue);
                }
            }
        }

        private XmlElement TryGetSourceXmlArray(XmlNode sourceParentXmlNode, PropertyInfo destProperty)
        {
            string xmlArrayName = GetXmlArrayName(destProperty);
            string arrayXPath = xmlArrayName;
            XmlElement sourceXmlArray = (XmlElement)sourceParentXmlNode.SelectSingleNode(arrayXPath);

            return sourceXmlArray;
        }

        private XmlNodeList GetSourceXmlArrayItems(XmlElement sourceXmlArray, PropertyInfo destProperty)
        {
            string xmlArrayItemName = GetXmlArrayItemName(destProperty);
            XmlNodeList sourceXmlArrayItems = sourceXmlArray.GetElementsByTagName(xmlArrayItemName);
            return sourceXmlArrayItems;
        }

        private string GetXmlArrayName(PropertyInfo destProperty)
        {
            XmlArrayAttribute xmlArrayAttribute = destProperty.GetCustomAttribute<XmlArrayAttribute>();
            if (xmlArrayAttribute != null)
            {
                if (!String.IsNullOrEmpty(xmlArrayAttribute.ElementName))
                {
                    return xmlArrayAttribute.ElementName;
                }
            }

            return FormatName(destProperty.Name);
        }

        private string GetXmlArrayItemName(PropertyInfo destProperty)
        {
            XmlArrayItemAttribute xmlArrayItemAttribute = destProperty.GetCustomAttribute<XmlArrayItemAttribute>();
            if (xmlArrayItemAttribute != null)
            {
                if (!String.IsNullOrEmpty(xmlArrayItemAttribute.ElementName))
                {
                    return xmlArrayItemAttribute.ElementName;
                }
            }

            return FormatName(destProperty.Name);
        }

        private string GetXmlArrayItemValue(XmlElement sourceXmlArrayItem)
        {
            return sourceXmlArrayItem != null ? sourceXmlArrayItem.InnerText : null;
        }

        // Helpers

        private bool IsNullable(Type type)
        {
            if (type.IsReferenceType())
            {
                return true;
            }

            if (type.IsNullableType())
            {
                return true;
            }

            return false;
        }
        
        private string FormatName(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Left(1).ToLower() + input.CutLeft(1);
        }

        private HashSet<Type> _additionalLeafTypes = new HashSet<Type> { typeof(string) };

        private bool IsLeafType(Type type)
        {
            if (type.IsValueType)
            {
                return true;
            }

            if (type.IsPrimitive)
            {
                return true;
            }

            if (_additionalLeafTypes.Contains(type))
            {
                return true;
            }

            return false;
        }

        // Old

        /*private void VisitArrayIndex(BinaryExpression node)
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
        }*/
    }
}
