using System;
using System.Reflection;
using System.Xml;
using JJ.Framework.Data.Xml.Internal;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Reflection;
using JJ.Framework.Xml;

namespace JJ.Framework.Data.Xml
{
    public class XmlToEntityConverter
    {
        // TODO: Reuse a central reflection cache.
        private readonly ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

        internal XmlToEntityConverter() { }

        public TEntity ConvertXmlElementToEntity<TEntity>(XmlElement sourceElement)
            where TEntity : new()
        {
            var destEntity = new TEntity();
            ConvertXmlElementToEntity(sourceElement, destEntity);
            return destEntity;
        }

        public void ConvertXmlElementToEntity(XmlElement sourceElement, object destEntity)
        {
            if (sourceElement == null) throw new NullException(() => sourceElement);
            if (destEntity == null) throw new NullException(() => destEntity);

            foreach (PropertyInfo destProperty in _reflectionCache.GetProperties(destEntity.GetType()))
            {
                string sourceValue = XmlHelper.TryGetAttributeValue(sourceElement, destProperty.Name);
                object destValue = ConvertValue(sourceValue, destProperty.PropertyType);
                destProperty.SetValue(destEntity, destValue, null);
            }
        }

        public void ConvertEntityToXmlElement(object sourceEntity, XmlElement destXmlElement)
        {
            foreach (PropertyInfo sourceProperty in ReflectionCacheWrapper.ReflectionCache.GetProperties(sourceEntity.GetType()))
            {
                object sourceValue = sourceProperty.GetValue(sourceEntity, null);
                string destValue = Convert.ToString(sourceValue);
                XmlHelper.SetAttributeValue(destXmlElement, sourceProperty.Name, destValue);
            }
        }

        private object ConvertValue(string value, Type type) => Convert.ChangeType(value, type);
    }
}