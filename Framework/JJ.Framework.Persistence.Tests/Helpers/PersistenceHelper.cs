using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Configuration;
using JJ.Framework.Persistence;

namespace JJ.Framework.Persistence.Tests
{
    public static class PersistenceHelper
    {
        public static IContext CreatePersistenceContext(string contextType = null)
        {
            PersistenceConfiguration persistenceConfiguration = CustomConfigurationManager.GetSection<PersistenceConfiguration>();
            
            return ContextFactory.CreateContext(
                contextType ?? persistenceConfiguration.ContextType,
                persistenceConfiguration.Location,
                persistenceConfiguration.ModelAssemblies);
        }
    }
}
