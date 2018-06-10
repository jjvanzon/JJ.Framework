using System;
using System.Reflection;
using System.Xml.Linq;
using JetBrains.Annotations;
using JJ.Framework.Data.Xml.Linq.Internal;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Xml.Linq;

namespace JJ.Framework.Data.Xml.Linq
{
    [PublicAPI]
    public class XmlToEntityConverter
    {
        internal XmlToEntityConverter() { }

        public TEntity ConvertXmlElementToEntity<TEntity>(XElement sourceElement)
            where TEntity : new()
        {
            var destEntity = new TEntity();
            ConvertXmlElementToEntity(sourceElement, destEntity);
            return destEntity;
        }

        public void ConvertXmlElementToEntity(XElement sourceElement, object destEntity)
        {
            if (sourceElement == null) throw new NullException(() => sourceElement);
            if (destEntity == null) throw new NullException(() => destEntity);

            foreach (PropertyInfo destProperty in ReflectionCacheWrapper.ReflectionCache.GetProperties(destEntity.GetType()))
            {
                string sourceValue = XmlHelper.TryGetAttributeValue(sourceElement, destProperty.Name);
                object destValue = ConvertValue(sourceValue, destProperty.PropertyType);
                destProperty.SetValue(destEntity, destValue, null);
            }
        }

        public void ConvertEntityToXmlElement(object sourceEntity, XElement destElement)
        {
            foreach (PropertyInfo sourceProperty in ReflectionCacheWrapper.ReflectionCache.GetProperties(sourceEntity.GetType()))
            {
                object sourceValue = sourceProperty.GetValue_PlatformSafe(sourceEntity);
                string destValue = Convert.ToString(sourceValue);
                XmlHelper.SetAttributeValue(destElement, sourceProperty.Name, destValue);
            }
        }

        private object ConvertValue(string value, Type type) => Convert.ChangeType(value, type); // TODO: Extend with other conversions.
    }
}