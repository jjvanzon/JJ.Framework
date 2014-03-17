using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence.Xml.Internal
{
    internal static class XmlMappingResolver
    {
        /// <summary>
        /// Finds an implementation of XmlMapping&lt;TEntity&gt;.
        /// </summary>
        public static IXmlMapping GetXmlMapping(Type entityType, Assembly mappingAssembly)
        {
            Type baseType = typeof(XmlMapping<>).MakeGenericType(entityType);
            Type derivedType = ReflectionHelper.GetImplementation(mappingAssembly, baseType);
            IXmlMapping instance = (IXmlMapping)Activator.CreateInstance(derivedType);
            return instance;
        }
    }
}