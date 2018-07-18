using System.Reflection;
using JJ.Framework.Configuration;

namespace JJ.Framework.Data.Tests.Helpers
{
    public static class PersistenceHelper
    {
        public static IContext CreatePersistenceContext(string contextType)
        {
            var configuration = CustomConfigurationManager.GetSection<ConfigurationSection>();

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