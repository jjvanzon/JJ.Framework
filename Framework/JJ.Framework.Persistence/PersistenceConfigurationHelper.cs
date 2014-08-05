using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Persistence;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence
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

        private const string JJ_FRAMEWORK_CONFIGURATION_ASSEMBLY_STRING = "JJ.Framework.Configuration"; // TODO: Include version info?
        private const string CUSTOM_CONFIGURATION_MANAGER_TYPE_STRING = "JJ.Framework.Configuration.CustomConfigurationManager";
        private const string GET_SECTION_METHOD_NAME = "GetSection";

        private static object _lock = new object();
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
                    throw new Exception(String.Format(@"Type '{0}' not found in assembly '{1}'.", CUSTOM_CONFIGURATION_MANAGER_TYPE_STRING, assembly.GetName().Name));
                }

                MethodInfo openGenericMethod = type.GetMethod(GET_SECTION_METHOD_NAME, BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);
                if (openGenericMethod == null)
                {
                    throw new Exception(String.Format("Method '{0}' not found in type '{1}'.", GET_SECTION_METHOD_NAME, type.Name));
                }

                MethodInfo closedGenericMethod = openGenericMethod.MakeGenericMethod(typeof(PersistenceConfiguration));

                _persistenceConfiguration = (PersistenceConfiguration)closedGenericMethod.Invoke(null, null);

                return _persistenceConfiguration;
            }
        }
    }
}
