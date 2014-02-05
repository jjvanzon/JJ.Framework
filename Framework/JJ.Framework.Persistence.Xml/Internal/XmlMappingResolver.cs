using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.Xml.Internal
{
    internal static class XmlMappingResolver
    {
        /// <summary>
        /// Finds an implementation of XmlMapping&lt;TEntity&gt;.
        /// </summary>
        public static IXmlMapping GetXmlMapping(Type entityType, IList<Assembly> mappingAssemblies)
        {
            Type baseType = typeof(XmlMapping<>).MakeGenericType(entityType);
            Type derivedType = null;
            foreach (Assembly mappingAssembly in mappingAssemblies)
            {
                derivedType = ReflectionHelper.TryGetImplementation(mappingAssembly, baseType);
                if (derivedType != null)
                {
                    break;
                }
            }

            if (derivedType == null)
            {
                string mappingAssembliesDescription = String.Join(", ", mappingAssemblies.Select(x => x.GetName().Name));
                throw new Exception(String.Format("No implementation of type {0}<{1}> not found in any of the following assemblies: {2}.", baseType.Name, entityType.Name, mappingAssembliesDescription));
            }

            IXmlMapping instance = (IXmlMapping)Activator.CreateInstance(derivedType);

            return instance;
        }
    }
}
