using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence
{
    public static class ContextFactory
    {
        public static IContext CreateContext(string persistenceContextTypeName, string persistenceLocation, string modelAssemblyName, string mappingAssemblyName = null)
        {
            Type persistenceContextType = ReflectionHelper.GetType(persistenceContextTypeName);
            Assembly modelAssembly = Assembly.Load(modelAssemblyName);
            Assembly mappingAssembly = mappingAssemblyName != null ? Assembly.Load(mappingAssemblyName) : null;

            return ContextFactory.CreateContext(persistenceContextType, persistenceLocation, modelAssembly, mappingAssembly);
        }

        //public static IContext CreateContext(string persistenceLocation, Assembly modelAssembly,)
        //{
        //    return ContextFactory.CreateContext(persistenceLocation, modelAssembly, GetType(persistenceContextTypeName));
        //}

        //public static IContext CreateContext(string persistenceLocation, string modelAssemblyName, Type persistenceContextType)
        //{
        //    return ContextFactory.CreateContext(persistenceLocation, GetAssembly(modelAssemblyName), persistenceContextType);
        //}

        private static IContext CreateContext(Type persistenceContextType, string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly)
        {
            return (IContext)Activator.CreateInstance(persistenceContextType, persistenceLocation, modelAssembly, mappingAssembly);
        }

        //private static Assembly GetAssembly(string assemblyName)
        //{
        //    return Assembly.Load(modelAssemblyName);
        //}

        //private static Type GetType(string typeName)
        //{
        //    return ReflectionHelper.GetType(persistenceContextTypeName);
        //}
    }
}
