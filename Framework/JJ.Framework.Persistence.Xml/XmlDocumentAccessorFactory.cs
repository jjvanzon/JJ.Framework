using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.Xml
{
    internal static class XmlDocumentAccessorFactory
    {
        /// <summary>
        /// Creates an XmlDocumentAccessor that gives access to the XML file that
        /// stores a particular entity type.
        /// The complexity in creating the XmlDocumentAccessor is finding an implementation of XmlMapping&lt;TEntity&gt;.
        /// </summary>
        public static XmlDocumentAcessor Create(Type entityType, string filePath, IList<Assembly> mappingAssemblies)
        {
            Type xmlMappingBaseType = typeof(XmlMapping<>).MakeGenericType(entityType);
            Type xmlMappingDerivedType = null;
            foreach (Assembly mappingAssembly in mappingAssemblies)
            {
                xmlMappingDerivedType = ReflectionHelper.TryGetImplementation(mappingAssembly, xmlMappingBaseType);
                if (xmlMappingDerivedType != null)
                {
                    break;
                }
            }

            if (xmlMappingDerivedType == null)
            {
                string mappingAssembliesDescription = String.Join(", ", mappingAssemblies.Select(x => x.GetName().Name));
                throw new Exception(String.Format("No implementation of type {0}<{1}> not found in any of the following assemblies: {2}.", xmlMappingBaseType.Name, entityType.Name, mappingAssembliesDescription));
            }

            IXmlMapping xmlMapping = (IXmlMapping)Activator.CreateInstance(xmlMappingDerivedType);

            return new XmlDocumentAcessor(filePath, xmlMapping);
        }
    }
}
