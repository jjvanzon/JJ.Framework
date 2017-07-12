using JJ.Framework.Reflection;
using System;
using System.Reflection;

namespace JJ.Framework.Data.Xml.Internal
{
    internal static class XmlMappingResolver
    {
        /// <summary>
        /// Finds an implementation of XmlMapping&lt;TEntity&gt;.
        /// </summary>
        public static IXmlMapping GetXmlMapping(Type entityType, Assembly mappingAssembly)
        {
            Type baseType = typeof(XmlMapping<>).MakeGenericType(entityType);
            Type derivedType = mappingAssembly.GetImplementation(baseType);
            IXmlMapping instance = (IXmlMapping)Activator.CreateInstance(derivedType);
            return instance;
        }
    }
}