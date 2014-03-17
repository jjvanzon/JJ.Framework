using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Net45;
using JJ.Framework.Xml.Internal;

namespace JJ.Framework.Xml
{
    public class XmlToObjectConverter<T>
        where T: new()
    {
        // TODO: Support standard <add> syntax for XML arrays.

        // Only Array types are supported.

        public T Convert(XmlNode sourceNode)
        {
            T destObject = new T();
            ConvertProperties(sourceNode, destObject);
            return destObject;
        }

        /// <summary>
        /// Goes through all the properties of the destObject's type, and tries them fill it in.
        /// </summary>
        private void ConvertProperties(XmlNode sourceNode, object destObject)
        {
            foreach (PropertyInfo destProperty in ReflectionCache.GetProperties(destObject.GetType()))
            {
                NodeTypeEnum nodeType = GetNodeType(destProperty);
                switch (nodeType)
                {
                    case NodeTypeEnum.Attribute:
                        ConvertAttribute(sourceNode, destObject, destProperty);
                        break;

                    case NodeTypeEnum.Element:
                        ConvertElement(sourceNode, destObject, destProperty);
                        break;

                    case NodeTypeEnum.Array:
                        ConvertArray(sourceNode, destObject, destProperty);
                        break;

                    default:
                        throw new InvalidValueException(nodeType);
                }
            }
        }

        private NodeTypeEnum GetNodeType(PropertyInfo destProperty)
        {
            bool isAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>() != null;
            bool isElement = destProperty.GetCustomAttribute<XmlElementAttribute>() != null;
            bool isArray = destProperty.GetCustomAttribute<XmlArrayAttribute>() != null;
            bool isArrayItem = destProperty.GetCustomAttribute<XmlArrayItemAttribute>() != null;
            bool isArrayType = destProperty.PropertyType.IsAssignableTo(typeof(Array));

            if (isArrayType)
            {
                bool isValid = !isAttribute && !isElement;
                if (!isValid)
                {
                    throw new Exception(String.Format("Property '{0}' is an array and therefore cannot be marked with XmlAttribute or XmlElement. Use XmlArray and XmlArrayItem instead.", destProperty.Name));
                }
                return NodeTypeEnum.Array;
            }

            else if (isAttribute)
            {
                bool isValid = !isElement && !isArray && !isArrayItem;
                if (!isValid)
                {
                    throw new Exception(String.Format("Property '{0}' is an XML attribute and therefore cannot be marked with XmlElement, XmlArray or XmlArrayItem.", destProperty.Name));
                }
                return NodeTypeEnum.Attribute;
            }

            else
            {
                // If it is not an array or attribute, then it is an element.
                bool isValidElement = !isAttribute && !isArray && !isArrayItem;
                if (!isValidElement)
                {
                    throw new Exception(String.Format("Property '{0}' is an Xml element and therefore cannot be marked with XmlAttribute, XmlArray or XmlArrayItem.", destProperty.Name));
                }
                return NodeTypeEnum.Element;
            }
        }

        // XML Attributes

        private void ConvertAttribute(XmlNode sourceParentNode, object destObject, PropertyInfo destProperty)
        {
            XmlAttribute sourceAttribute = GetSourceAttribute(sourceParentNode, destProperty);
            string sourceValue = GetSourceValue(sourceAttribute);
            object destValue = ConversionHelper.ConvertValue(sourceValue, destProperty.PropertyType);
            destProperty.SetValue(destObject, destValue);
        }

        private XmlAttribute GetSourceAttribute(XmlNode sourceParentNode, PropertyInfo destProperty)
        {
            string name = GetAttributeName(destProperty);
            string xpath = "@" + name;

            XmlAttribute sourceAttribute = (XmlAttribute)sourceParentNode.SelectSingleNode(xpath);
            if (sourceAttribute == null)
            {
                Type type = destProperty.PropertyType;
                if (!IsNullable(type))
                {
                    throw new Exception(String.Format("XML node '{0}' does not have the required attribute '{1}'.", sourceParentNode.Name, name));
                }
            }

            return sourceAttribute;
        }

        private string GetAttributeName(PropertyInfo destProperty)
        {
            XmlAttributeAttribute attributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>();
            if (!String.IsNullOrEmpty(attributeAttribute.AttributeName))
            {
                return attributeAttribute.AttributeName;
            }
            else
            {
                return FormatCamelCase(destProperty.Name);
            }
        }

        // XML Elements

        private void ConvertElement(XmlNode sourceParent, object destObject, PropertyInfo destProperty)
        {
            XmlElement sourceElement = GetSourceElement(sourceParent, destProperty);

            Type type = destProperty.PropertyType;

            if (IsLeafType(type))
            {
                string sourceValue = GetSourceValue(sourceElement);
                object destValue = ConversionHelper.ConvertValue(sourceValue, type);
                destProperty.SetValue(destObject, destValue);
            }
            else
            {
                object destValue = Activator.CreateInstance(type);
                destProperty.SetValue(destObject, destValue);
                ConvertProperties(sourceElement, destValue); // Recursive call
            }
        }

        private XmlElement GetSourceElement(XmlNode sourceParent, PropertyInfo destProperty)
        {
            string name = GetElementName(destProperty);

            XmlElement sourceElement = (XmlElement)sourceParent.SelectSingleNode(name);
            if (sourceElement == null)
            {
                Type type = destProperty.PropertyType;
                if (!IsNullable(type))
                {
                    throw new Exception(String.Format("XML node '{0}' does not have the required child element '{1}'.", sourceParent.Name, name));
                }
            }

            return sourceElement;
        }

        private string GetElementName(PropertyInfo destProperty)
        {
            XmlElementAttribute elementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>();
            if (elementAttribute != null)
            {
                if (!String.IsNullOrEmpty(elementAttribute.ElementName))
                {
                    return elementAttribute.ElementName;
                }
            }

            return FormatCamelCase(destProperty.Name);
        }

        // XML Arrays

        private void ConvertArray(XmlNode sourceParent, object destObject, PropertyInfo destProperty)
        {
            Type type = destProperty.PropertyType;
            Type itemType = destProperty.PropertyType.GetElementType();

            XmlElement sourceArray = TryGetSourceArray(sourceParent, destProperty);
            if (sourceArray == null)
            {
                return;
            }
            XmlNodeList sourceItems = GetSourceArrayItems(sourceArray, destProperty);

            Array destArray = (Array)Activator.CreateInstance(type, sourceItems.Count);
            destProperty.SetValue(destObject, destArray);

            for (int i = 0; i < sourceItems.Count; i++)
            {
                XmlElement sourceItem = (XmlElement)sourceItems[i];

                if (IsLeafType(itemType))
                {
                    string sourceValue = GetSourceValue(sourceItem);
                    object destValue = ConversionHelper.ConvertValue(sourceValue, itemType);
                    destArray.SetValue(destValue, i);
                }
                else
                {
                    object destValue = Activator.CreateInstance(itemType);
                    destArray.SetValue(destValue, i);
                    ConvertProperties(sourceItem, destValue); // Recursive call
                }
            }
        }

        private XmlElement TryGetSourceArray(XmlNode sourceParent, PropertyInfo destProperty)
        {
            string name = GetXmlArrayName(destProperty);
            XmlElement sourceArray = (XmlElement)sourceParent.SelectSingleNode(name);

            return sourceArray;
        }

        private XmlNodeList GetSourceArrayItems(XmlElement sourceArray, PropertyInfo destProperty)
        {
            string itemName = GetItemName(destProperty);
            XmlNodeList sourceItems = sourceArray.GetElementsByTagName(itemName);
            return sourceItems;
        }

        private string GetXmlArrayName(PropertyInfo destProperty)
        {
            XmlArrayAttribute arrayAttribute = destProperty.GetCustomAttribute<XmlArrayAttribute>();
            if (arrayAttribute != null)
            {
                if (!String.IsNullOrEmpty(arrayAttribute.ElementName))
                {
                    return arrayAttribute.ElementName;
                }
            }

            return FormatCamelCase(destProperty.Name);
        }

        private string GetItemName(PropertyInfo destProperty)
        {
            XmlArrayItemAttribute arrayItemAttribute = destProperty.GetCustomAttribute<XmlArrayItemAttribute>();
            if (arrayItemAttribute != null)
            {
                if (!String.IsNullOrEmpty(arrayItemAttribute.ElementName))
                {
                    return arrayItemAttribute.ElementName;
                }
            }

            return FormatCamelCase(destProperty.Name);
        }

        // Helpers
        
        private string FormatCamelCase(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Left(1).ToLower() + input.CutLeft(1);
        }

        private string GetSourceValue(XmlNode sourceNode)
        {
            return sourceNode != null ? sourceNode.InnerText : null;
        }

        private bool IsNullable(Type type)
        {
            return type.IsReferenceType() || type.IsNullableType();
        }

        private bool IsLeafType(Type type)
        {
            return type.IsPrimitive || type == typeof(string);
        }
    }
}
