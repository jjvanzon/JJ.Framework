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

namespace JJ.Framework.Xml.Linq
{
    /// <summary>
    /// Under certain platforms standard XML serialization may not be available 
    /// or may not be the best option. Hence this class.
    /// </summary>
    public class ObjectToXmlConverter_UsingXmlWriter
    {
        private const string ROOT_ELEMENT_NAME = "root";

        private object _sourceObject;
        private Stream _destStream;
        private XmlWriter _xmlWriter; // XmlWriter is faster than other API's.
        private XmlCasingEnum _casing;

        public ObjectToXmlConverter_UsingXmlWriter(object sourceObject, XmlCasingEnum casing = XmlCasingEnum.CamelCase)
            : this(sourceObject, new MemoryStream(), casing)
        { }

        public ObjectToXmlConverter_UsingXmlWriter(object sourceObject, Stream destStream, XmlCasingEnum casing = XmlCasingEnum.CamelCase)
        {
            if (sourceObject == null) throw new ArgumentNullException("sourceObject");
            if (destStream == null) throw new ArgumentNullException("stream");

            _sourceObject = sourceObject;
            _destStream = destStream;
            _xmlWriter = XmlWriter.Create(_destStream);
            _casing = casing;
        }

        public string ConvertToString()
        {
            _xmlWriter.WriteStartElement(ROOT_ELEMENT_NAME);

            ConvertProperties(_sourceObject);

            _xmlWriter.WriteEndElement();

            string destString = StreamHelper.StreamToString(_destStream, Encoding.UTF8);
            return destString;
        }

        public byte[] ConvertToBytes()
        {
            _xmlWriter.WriteStartElement(ROOT_ELEMENT_NAME);

            ConvertProperties(_sourceObject);
            byte[] destBytes = StreamHelper.StreamToBytes(_destStream);

            _xmlWriter.WriteEndElement();

            return destBytes;
        }

        public Stream ConvertToStream()
        {
            _xmlWriter.WriteStartElement(ROOT_ELEMENT_NAME);

            ConvertProperties(_sourceObject);

            _xmlWriter.WriteEndElement();

            return _destStream;
        }

        /// <summary>
        /// Loops through the properties of the source object and calls
        /// another method to serialize the property.
        /// </summary>
        private void ConvertProperties(object sourceObject)
        {
            foreach (PropertyInfo sourceProperty in ReflectionCache.GetProperties(sourceObject.GetType()))
            {
                ConvertProperty(sourceObject, sourceProperty);
            }
        }

        private void ConvertProperty(object sourceObject, PropertyInfo sourceProperty)
        {
            NodeTypeEnum nodeType = ConversionHelper.DetermineNodeType(sourceProperty);
            switch (nodeType)
            {
                case NodeTypeEnum.Element:
                    ConvertElement(sourceObject, sourceProperty);
                    break;

                case NodeTypeEnum.Attribute:
                    ConvertAttribute(sourceObject, sourceProperty);
                    break;

                case NodeTypeEnum.Array:
                    ConvertXmlArray(sourceObject, sourceProperty);
                    break;

                default:
                    throw new InvalidValueException(nodeType);
            }
        }

        // Elements

        private void ConvertElement(object sourceParentObject, PropertyInfo sourceProperty)
        {
            string destName = ConversionHelper.GetElementNameForProperty(sourceProperty, _casing);
            object sourceObject = sourceProperty.GetGetMethod().Invoke(sourceParentObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.
            ConvertElement(sourceObject, destName);
        }

        private void ConvertElement(object sourceObject, string destName)
        {
            // TODO: This assumes the object is never null.
            Type sourceType = sourceObject.GetType();
            if (ConversionHelper.IsLeafType(sourceType))
            {
                ConvertLeafElement(sourceObject, destName);
            }
            else
            {
                ConvertCompositeElement(sourceObject, destName);
            }
        }

        private void ConvertLeafElement(object sourceValue, string destName)
        {
            string destValue = ConversionHelper.FormatValue(sourceValue);
            _xmlWriter.WriteElementString(destName, destValue);
        }

        private void ConvertCompositeElement(object sourceObject, string destName)
        {
            _xmlWriter.WriteStartElement(destName);

            ConvertProperties(sourceObject);

            _xmlWriter.WriteEndElement();
        }

        // Attributes

        private void ConvertAttribute(object sourceObject, PropertyInfo sourceProperty)
        {
            string destName = ConversionHelper.GetAttributeNameForProperty(sourceProperty, _casing);
            object sourceValue = sourceProperty.GetGetMethod().Invoke(sourceObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.
            string destValue = ConversionHelper.FormatValue(sourceValue);
            _xmlWriter.WriteAttributeString(destName, destValue);
        }

        // XML Arrays

        private void ConvertXmlArray(object sourceParentObject, PropertyInfo sourceCollectionProperty)
        {
            string destName = ConversionHelper.GetXmlArrayNameForCollectionProperty(sourceCollectionProperty, _casing);
            _xmlWriter.WriteStartElement(destName);

            // This type check might be redundant, because it could never happen that
            // the support collection type does not implement IList.
            // However, the code that makes sure this never happens is in a totally different place,
            // so a programming error is a possibility.
            object sourceCollectionObject = sourceCollectionProperty.GetGetMethod().Invoke(sourceParentObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.
            if (!(sourceCollectionObject is IList))
            {
                throw new Exception(String.Format("Collection of type '{0}' does not implement IList.", sourceCollectionProperty.PropertyType));
            }

            IList sourceCollection = (IList)sourceCollectionObject;

            foreach (object sourceItem in sourceCollection)
            {
                ConvertXmlArrayItem(sourceItem, sourceCollectionProperty);
            }

            _xmlWriter.WriteEndElement();
        }

        private void ConvertXmlArrayItem(object sourceItem, PropertyInfo sourceCollectionProperty)
        {
            string destName = ConversionHelper.GetXmlArrayItemNameForCollectionProperty(sourceCollectionProperty);

            // Recursive call
            ConvertElement(sourceItem, destName);
        }
    }
}