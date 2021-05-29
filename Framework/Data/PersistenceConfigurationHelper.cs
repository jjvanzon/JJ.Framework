using System;
using System.Reflection;

namespace JJ.Framework.Data
{
    public static class PersistenceConfigurationHelper
    {
        // Windows Phone 8 does not support System.Configuration, 
        // so dynamically reference JJ.Framework.Configuration.

        // This is the old code when statically linked to JJ.Framework.Configuration.
        //public static PersistenceConfiguration GetPersistenceConfiguration()
        //{
        //    return CustomConfigurationManager.GetSection<PersistenceConfiguration>();
        //}

        private const string JJ_FRAMEWORK_CONFIGURATION_ASSEMBLY_STRING = "JJ.Framework.Configuration";
        private const string CUSTOM_CONFIGURATION_MANAGER_TYPE_STRING = "JJ.Framework.Configuration.CustomConfigurationManager";
        private const string GET_SECTION_METHOD_NAME = "GetSection";

        private static readonly object _lock = new object();
        private static PersistenceConfiguration _persistenceConfiguration;

        public static PersistenceConfiguration GetPersistenceConfiguration()
        {
            lock (_lock)
            {
                if (_persistenceConfiguration != null)
                {
                    return _persistenceConfiguration;
                }

                Assembly assembly = Assembly.Load(JJ_FRAMEWORK_CONFIGURATION_ASSEMBLY_STRING);

                Type type = assembly.GetType(CUSTOM_CONFIGURATION_MANAGER_TYPE_STRING);
                if (type == null)
                {
                    throw new Exception($@"Type '{CUSTOM_CONFIGURATION_MANAGER_TYPE_STRING}' not found in assembly '{assembly.GetName().Name}'.");
                }

                MethodInfo openGenericMethod = type.GetMethod(GET_SECTION_METHOD_NAME, BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);
                if (openGenericMethod == null)
                {
                    throw new Exception($"Method '{GET_SECTION_METHOD_NAME}' not found in type '{type.Name}'.");
                }

                MethodInfo closedGenericMethod = openGenericMethod.MakeGenericMethod(typeof(PersistenceConfiguration));

                _persistenceConfiguration = (PersistenceConfiguration)closedGenericMethod.Invoke(null, null);

                return _persistenceConfiguration;
            }
        }
    }
}
