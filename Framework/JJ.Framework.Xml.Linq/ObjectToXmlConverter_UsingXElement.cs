using JJ.Framework.Common;
using JJ.Framework.IO;
using JJ.Framework.Reflection;
using JJ.Framework.Xml.Linq.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JJ.Framework.Xml.Linq
{
    /// <summary>
    /// Under certain platforms standard XML serialization may not be available 
    /// or may not be the best option. Hence this class.
    /// </summary>
    public class ObjectToXmlConverter_UsingXElement
    {
        // TODO: This is now code that cannot be ported between System.Xml and System.Xml.Linq.
        // TODO: Use the term 'Try' for the methods that can return null?

        private const string ROOT_ELEMENT_NAME = "root";

        private XmlCasingEnum _casing;

        public ObjectToXmlConverter_UsingXElement(XmlCasingEnum casing = XmlCasingEnum.CamelCase)
        {
            _casing = casing;
        }

        public byte[] ConvertToBytes(object sourceObject)
        {
            string text = ConvertToString(sourceObject);
            byte[] destBytes = StreamHelper.StringToBytes(text, Encoding.UTF8);
            return destBytes;
        }

        /// <summary>
        /// UTF-8 encoding is assumed.
        /// </summary>
        public Stream ConvertToStream(object sourceObject)
        {
            string text = ConvertToString(sourceObject);
            Stream stream = StreamHelper.StringToStream(text, Encoding.UTF8);
            return stream;
        }

        public string ConvertToString(object sourceObject)
        {
            if (sourceObject == null) throw new ArgumentNullException("sourceObject");

            // TODO: It stinks that you have to create a root.

            XElement destRootElement = new XElement(ROOT_ELEMENT_NAME);
            IList<XObject> destObjects = ConvertProperties(sourceObject);
            destRootElement.Add(destObjects);

            string destString = destRootElement.ToString();
            return destString;
        }

        /// <summary>
        /// Loops through the properties of the source object and calls
        /// another method to serialize the property.
        /// </summary>
        private IList<XObject> ConvertProperties(object sourceObject)
        {
            IList<XObject> destObjects = new List<XObject>();
            foreach (PropertyInfo sourceProperty in ReflectionCache.GetProperties(sourceObject.GetType()))
            {
                XObject destObject = ConvertProperty(sourceObject, sourceProperty);
                if (destObject != null)
                {
                    destObjects.Add(destObject);
                }
                
            }
            return destObjects;
        }

        /// <summary>
        /// Can return null.
        /// </summary>
        private XObject ConvertProperty(object sourceObject, PropertyInfo sourceProperty)
        {
            NodeTypeEnum nodeType = ConversionHelper.DetermineNodeType(sourceProperty);
            switch (nodeType)
            {
                case NodeTypeEnum.Element:
                    XElement destElement = ConvertElement(sourceObject, sourceProperty);
                    return destElement;

                case NodeTypeEnum.Attribute:
                    XAttribute destAttribute = ConvertAttribute(sourceObject, sourceProperty);
                    return destAttribute;

                case NodeTypeEnum.Array:
                    XElement destXmlArray = ConvertXmlArray(sourceObject, sourceProperty);
                    return destXmlArray;

                default:
                    throw new InvalidValueException(nodeType);
            }
        }

        // Elements

        /// <summary>
        /// Can return null.
        /// </summary>
        private XElement ConvertElement(object sourceParentObject, PropertyInfo sourceProperty)
        {
            string destName = ConversionHelper.GetElementNameForProperty(sourceProperty, _casing);
            object sourceObject = sourceProperty.GetGetMethod().Invoke(sourceParentObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.

            // TODO: Is this adequate handling of null (does it work for both reference types and nullable types)?
            if (sourceObject == null)
            {
                return null;
            }

            XElement destElement = ConvertElement(sourceObject, destName);
            return destElement;
        }

        /// <param name="sourceObject">not nullable</param>
        private XElement ConvertElement(object sourceObject, string destName)
        {
            // TODO: This assumes the object is never null.
            Type sourceType = sourceObject.GetType();
            if (ConversionHelper.IsLeafType(sourceType))
            {
                XElement destElement = ConvertLeafElement(sourceObject, destName);
                return destElement;
            }
            else
            {
                XElement destElement = ConvertCompositeElement(sourceObject, destName);
                return destElement;
            }
        }

        private XElement ConvertLeafElement(object sourceValue, string destName)
        {
            // TODO: Perhaps you do not need to format with XElement.
            string destValue = ConversionHelper.FormatValue(sourceValue);
            var destElement = new XElement(destName, destValue);
            return destElement;
        }

        private XElement ConvertCompositeElement(object sourceObject, string destName)
        {
            var destElement = new XElement(destName);
            IEnumerable<XObject> destChildElements = ConvertProperties(sourceObject);
            destElement.Add(destChildElements);
            return destElement;
        }

        // Attributes

        private XAttribute ConvertAttribute(object sourceObject, PropertyInfo sourceProperty)
        {
            string destName = ConversionHelper.GetAttributeNameForProperty(sourceProperty, _casing);
            object sourceValue = sourceProperty.GetGetMethod().Invoke(sourceObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.
            // TODO: Perhaps you do not need to format with XElement.
            string destValue = ConversionHelper.FormatValue(sourceValue);
            var destAttribute = new XAttribute(destName, destValue);
            return destAttribute;
        }

        // XML Arrays

        /// <summary>
        /// Can return null.
        /// </summary>
        private XElement ConvertXmlArray(object sourceParentObject, PropertyInfo sourceCollectionProperty)
        {
            // This type check might be redundant, because it could never happen that
            // the support collection type does not implement IList.
            // However, the code that makes sure this never happens is in a totally different place,
            // so a programming error is a possibility.
            object sourceCollectionObject = sourceCollectionProperty.GetGetMethod().Invoke(sourceParentObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.
            if (sourceCollectionObject == null)
            {
                return null;
            }

            if (!(sourceCollectionObject is IList))
            {
                throw new Exception(String.Format("Collection of type '{0}' does not implement IList.", sourceCollectionProperty.PropertyType));
            }

            IList sourceCollection = (IList)sourceCollectionObject;

            string destName = ConversionHelper.GetXmlArrayNameForCollectionProperty(sourceCollectionProperty, _casing);
            var destXmlArray = new XElement(destName);

            foreach (object sourceItem in sourceCollection)
            {
                XElement destXmlArrayItem = ConvertXmlArrayItem(sourceItem, sourceCollectionProperty);
                destXmlArray.Add(destXmlArrayItem);
            }

            return destXmlArray;
        }

        private XElement ConvertXmlArrayItem(object sourceItem, PropertyInfo sourceCollectionProperty)
        {
            string destName = ConversionHelper.GetXmlArrayItemNameForCollectionProperty(sourceCollectionProperty);

            // Recursive call
            XElement destXmlArrayItem = ConvertElement(sourceItem, destName);
            return destXmlArrayItem;
        }
    }
}