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

        private static Type GetPersistenceContextType(string name)
        {
            lock (_contextTypeDictionaryLock)
            {
                if (_contextTypeDictionary.ContainsKey(name))
                {
                    return _contextTypeDictionary[name];
                }

                // Try to get type by name
                Type type = Type.GetType(name);
                if (type == null)
                {
                    // Otherwise assume it is an assembly name.
                    Assembly assembly = Assembly.Load(name);
                    Type[] types = assembly.GetTypes().Where(x => x.GetInterface(typeof(IContext).Name) != null).ToArray();
                    type = types.SingleOrDefault();
                    if (type == null)
                    {
                        throw new Exception(String.Format("Context type '{0}' not found.", name));
                    }
                }

                _contextTypeDictionary[name] = type;
                return type;
            }
        }
    }
}
