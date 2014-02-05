using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml.Internal
{
    internal class XmlToEntityConverter<TEntity>
        where TEntity : class, new()
    {
        private readonly XmlElementAccessor _accessor;

        public XmlToEntityConverter(XmlElementAccessor accessor)
        {
            if (accessor == null) throw new ArgumentNullException("accessor");
            _accessor = accessor;
        }

        public TEntity ConvertXmlElementToEntity(XmlElement sourceElement)
        {
            TEntity destEntity = new TEntity();
            ConvertXmlElementToEntity(sourceElement, destEntity);
            return destEntity;
        }

        public void ConvertXmlElementToEntity(XmlElement sourceElement, TEntity destEntity)
        {
            if (sourceElement == null) throw new ArgumentNullException("sourceElement");
            if (destEntity == null) throw new ArgumentNullException("destEntity");

            // TODO: Use ReflectionCache.
            foreach (PropertyInfo destProperty in typeof(TEntity).GetProperties())
            {
                string sourceValue = _accessor.GetAttributeValue(sourceElement, destProperty.Name);
                object destValue = ConvertValue(sourceValue, destProperty.PropertyType);
                destProperty.SetValue(destEntity, destValue, null);
            }
        }

        public void ConvertEntityToXmlElement(object sourceEntity, XmlElement destXmlElement)
        {
            // TODO: Use reflection cache.
            foreach (PropertyInfo sourceProperty in typeof(TEntity).GetProperties())
            {
                object sourceValue = sourceProperty.GetValue(sourceEntity, null);
                string destValue = Convert.ToString(sourceValue);
                _accessor.SetAttributeValue(destXmlElement, sourceProperty.Name, destValue);
            }
        }

        private object ConvertValue(string value, Type type)
        {
            // TODO: Extend with other conversions.
            return System.Convert.ChangeType(value, type);
        }
    }
}
