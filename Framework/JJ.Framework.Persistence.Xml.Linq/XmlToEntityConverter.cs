using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using JJ.Framework.Reflection;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Persistence.Xml.Linq.Internal;

namespace JJ.Framework.Persistence.Xml.Linq
{
    public class XmlToEntityConverter<TEntity>
        where TEntity : class, new()
    {
        private readonly XmlElementAccessor _accessor;

        internal XmlToEntityConverter(XmlElementAccessor accessor)
        {
            if (accessor == null) throw new NullException(() => accessor);
            _accessor = accessor;
        }

        public TEntity ConvertXmlElementToEntity(XElement sourceElement)
        {
            TEntity destEntity = new TEntity();
            ConvertXmlElementToEntity(sourceElement, destEntity);
            return destEntity;
        }

        public void ConvertXmlElementToEntity(XElement sourceElement, TEntity destEntity)
        {
            if (sourceElement == null) throw new NullException(() => sourceElement);
            if (destEntity == null) throw new NullException(() => destEntity);

            foreach (PropertyInfo destProperty in ReflectionCache.GetProperties(typeof(TEntity)))
            {
                string sourceValue = _accessor.GetAttributeValue(sourceElement, destProperty.Name);
                object destValue = ConvertValue(sourceValue, destProperty.PropertyType);
                destProperty.SetValue(destEntity, destValue, null);
            }
        }

        public void ConvertEntityToXmlElement(object sourceEntity, XElement destElement)
        {
            foreach (PropertyInfo sourceProperty in ReflectionCache.GetProperties(typeof(TEntity)))
            {
                object sourceValue = sourceProperty.GetValue_PlatformSafe(sourceEntity);
                string destValue = Convert.ToString(sourceValue);
                _accessor.SetAttributeValue(destElement, sourceProperty.Name, destValue);
            }
        }

        private object ConvertValue(string value, Type type)
        {
            // TODO: Extend with other conversions.
            return System.Convert.ChangeType(value, type);
        }
    }
}
