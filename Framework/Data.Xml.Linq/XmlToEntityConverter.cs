using System;
using System.Reflection;
using System.Xml.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Data.Xml.Linq.Internal;
using JJ.Framework.Xml.Linq;

namespace JJ.Framework.Data.Xml.Linq
{
	public class XmlToEntityConverter
	{
		internal XmlToEntityConverter()
		{ }

		public TEntity ConvertXmlElementToEntity<TEntity>(XElement sourceElement)
			where TEntity : new()
		{
			TEntity destEntity = new TEntity();
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

		private object ConvertValue(string value, Type type)
		{
			// TODO: Extend with other conversions.
			return System.Convert.ChangeType(value, type);
		}
	}
}
