using System;
using System.Data.SqlClient;
using System.Reflection;
using JJ.Framework.Configuration;
using JJ.Framework.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Data.Tests.Helpers
{
    public static class PersistenceHelper
    {
        public static IContext CreatePersistenceContext(string contextType)
        {
            try
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
            catch (Exception ex)
            {
                Exception innerMostException = ExceptionHelper.GetInnermostException(ex);
                if (innerMostException is SqlException)
                {
                    string message = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false);
                    Assert.Inconclusive(message);
                }

                throw;
            }
        }
    }
}
