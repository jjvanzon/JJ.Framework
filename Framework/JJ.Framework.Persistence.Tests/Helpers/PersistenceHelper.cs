using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Configuration;
using JJ.Framework.Persistence;
using JJ.Framework.Persistence.Tests.Model;
using JJ.Framework.Persistence.Tests.NHibernate;

namespace JJ.Framework.Persistence.Tests
{
    public static class PersistenceHelper
    {
        public static IContext CreatePersistenceContext(string contextType)
        {
            ConfigurationSection configuration = CustomConfigurationManager.GetSection<ConfigurationSection>();
            
            string modelAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string mappingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            return ContextFactory.CreateContext(
                contextType,
                configuration.Location,
                modelAssemblyName,
                mappingAssemblyName,
                configuration.Dialect);
        }
    }
}
