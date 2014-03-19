using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence
{
    public static class ContextFactory
    {
        /// <summary>
        /// Creates a context using the values out of the config file.
        /// A configuration example can be found in your bin directory.
        /// </summary>
        public static IContext CreateContextFromConfiguration()
        {
            PersistenceConfiguration persistenceConfiguration = PersistenceConfigurationHelper.GetPersistenceConfiguration();

            return CreateContextFromConfiguration(persistenceConfiguration);
        }

        public static IContext CreateContextFromConfiguration(PersistenceConfiguration persistenceConfiguration)
        {
            if (persistenceConfiguration == null) throw new ArgumentNullException("persistenceConfiguration");

            return ContextFactory.CreateContext(
                persistenceConfiguration.ContextType,
                persistenceConfiguration.Location,
                persistenceConfiguration.ModelAssembly,
                persistenceConfiguration.MappingAssembly);
        }

        /// <param name="contextTypeName">
        /// Can be a fully qualified type name, or the name of the assembly that holds the type, 
        /// or if the assembly name starts with 'JJ.Framework.Persistence' you can omit the 'JJ.Framework.Persistence.' from the name.
        /// </param>
        public static IContext CreateContext(string contextTypeName, string location, string modelAssemblyName, string mappingAssemblyName)
        {
            Type persistenceContextType = ResolveContextType(contextTypeName);

            Assembly modelAssembly = null;
            if (!String.IsNullOrEmpty(modelAssemblyName))
            {
                modelAssembly = Assembly.Load(modelAssemblyName);
            }

            Assembly mappingAssembly = null;
            if (!String.IsNullOrEmpty(mappingAssemblyName))
            {
                mappingAssembly = Assembly.Load(mappingAssemblyName);
            }

            return ContextFactory.CreateContext(persistenceContextType, location, modelAssembly, mappingAssembly);
        }

        public static IContext CreateContext(Type persistenceContextType, string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly)
        {
            return (IContext)Activator.CreateInstance(persistenceContextType, persistenceLocation, modelAssembly, mappingAssembly);
        }

        private static object _contextTypeDictionaryLock = new object();
        private static Dictionary<string, Type> _contextTypeDictionary = new Dictionary<string, Type>();

        private static Type ResolveContextType(string contextTypeName)
        {
            if (contextTypeName == null) throw new ArgumentNullException("contextTypeName");

            lock (_contextTypeDictionaryLock)
            {
                if (_contextTypeDictionary.ContainsKey(contextTypeName))
                {
                    return _contextTypeDictionary[contextTypeName];
                }

                // Try to get type by name
                Type type = Type.GetType(contextTypeName);
                if (type == null)
                {
                    // Otherwise assume the assembly name is :JJ.Framework.Persistence." + persistenceContextTypeName.
                    string assumedAssemblyName = typeof(JJ.Framework.Persistence.ContextFactory).Assembly.GetName().Name + "." + contextTypeName;
                    Assembly assembly;
                    try
                    {
                        assembly = Assembly.Load(assumedAssemblyName);
                    }
                    catch
                    {
                        // Otherwise assume it is a full assembly name.
                        assembly = Assembly.Load(contextTypeName);
                    }
                    IList<Type> types = ReflectionHelper.GetImplementations<IContext>(assembly);
                    switch (types.Count)
                    {
                        case 1:
                            type = types[0];
                            break;

                        case 0:
                            throw new Exception(String.Format("Context type '{0}' not found.", contextTypeName));

                        default:
                            throw new Exception(String.Format("Multiple context types found in assembly '{0}'. Please specify a fully qualified type name or implement only one context in the assembly.", assembly.GetName().Name));
                    }
                }

                _contextTypeDictionary[contextTypeName] = type;
                return type;
            }
        }
    }
}
