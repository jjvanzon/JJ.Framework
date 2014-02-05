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
        /// <param name="persistenceContextTypeName">Can be a fully qualified type name, or the name of the assembly that holds the type.</param>
        public static IContext CreateContext(string persistenceContextTypeName, string persistenceLocation, params string[] modelAssemblyNames)
        {
            Type persistenceContextType = GetPersistenceContextType(persistenceContextTypeName);

            Assembly[] modelAssemblies = modelAssemblyNames.Select(x => Assembly.Load(x)).ToArray();

            return ContextFactory.CreateContext(persistenceContextType, persistenceLocation, modelAssemblies);
        }

        private static IContext CreateContext(Type persistenceContextType, string persistenceLocation, params Assembly[] modelAssemblies)
        {
            return (IContext)Activator.CreateInstance(persistenceContextType, persistenceLocation, modelAssemblies);
        }

        private static object _contextTypeDictionaryLock = new object();

        private static Dictionary<string, Type> _contextTypeDictionary = new Dictionary<string, Type>();

        private static Type GetPersistenceContextType(string persistenceContextTypeName)
        {
            if (persistenceContextTypeName == null) throw new ArgumentNullException("persistenceContextTypeName");

            lock (_contextTypeDictionaryLock)
            {
                if (_contextTypeDictionary.ContainsKey(persistenceContextTypeName))
                {
                    return _contextTypeDictionary[persistenceContextTypeName];
                }

                // Try to get type by name
                Type type = Type.GetType(persistenceContextTypeName);
                if (type == null)
                {
                    // Otherwise assume the assembly name is :JJ.Framework.Persistence." + persistenceContextTypeName.
                    string assumedAssemblyName = typeof(JJ.Framework.Persistence.ContextFactory).Assembly.GetName().Name + "." + persistenceContextTypeName;
                    Assembly assembly;
                    try
                    {
                        assembly = Assembly.Load(assumedAssemblyName);
                    }
                    catch
                    {
                        // Otherwise assume it is a full assembly name.
                        assembly = Assembly.Load(persistenceContextTypeName);
                    }
                    IList<Type> types = ReflectionHelper.GetImplementations<IContext>(assembly);
                    switch (types.Count)
                    {
                        case 1:
                            type = types[0];
                            break;

                        case 0:
                            throw new Exception(String.Format("Context type '{0}' not found.", persistenceContextTypeName));

                        default:
                            throw new Exception(String.Format("Multiple context types found in assembly '{0}'. Please specify a fully qualified type name or implement only one context in the assembly.", assembly.GetName().Name));
                    }
                }

                _contextTypeDictionary[persistenceContextTypeName] = type;
                return type;
            }
        }
    }
}
