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
        public static IContext CreateContext(string persistenceContextTypeName, string persistenceLocation, params string[] modelAssemblyNames)
        {
            Type persistenceContextType = Type.GetType(persistenceContextTypeName);

            Assembly[] modelAssemblies = modelAssemblyNames.Select(x => Assembly.Load(x)).ToArray();

            return ContextFactory.CreateContext(persistenceContextType, persistenceLocation, modelAssemblies);
        }

        private static IContext CreateContext(Type persistenceContextType, string persistenceLocation, params Assembly[] modelAssemblies)
        {
            return (IContext)Activator.CreateInstance(persistenceContextType, persistenceLocation, modelAssemblies);
        }
    }
}
