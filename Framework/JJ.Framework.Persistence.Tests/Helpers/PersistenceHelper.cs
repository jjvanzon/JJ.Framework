using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Configuration;
#if NET5_0_OR_GREATER
using ExceptionHelper = JJ.Framework.Logging.Core.ExceptionHelper_Copied;
#else
using JJ.Framework.Logging;
#endif
using JJ.Framework.Persistence;
using JJ.Framework.Persistence.Tests.Model;
using JJ.Framework.Persistence.Tests.NHibernate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Persistence.Tests
{
    public static class PersistenceHelper
    {
        public static IContext CreatePersistenceContext(string contextType)
        {
            ConfigurationSection configuration = CustomConfigurationManager.GetSection<ConfigurationSection>("jj.framework.persistence.tests");
            
            string modelAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string mappingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            try
            {
                return ContextFactory.CreateContext(
                    contextType,
                    configuration.Location,
                    modelAssemblyName,
                    mappingAssemblyName,
                    configuration.Dialect);
            }
            #if NET5_0_OR_GREATER
            catch (SqlException ex)
            {
                AssertInconclusive(ex);
                return null;
            }
            catch (Exception ex) when (ex.InnerException is SqlException)
            {
                AssertInconclusive(ex);
                return null;
            }
            catch (Exception ex) when (ExceptionHelper.HasExceptionOrInnerExceptionsOfType<SqlException>(ex))
            {
                AssertInconclusive(ex);
                return null;
            }
            catch (Exception ex) when (ExceptionHelper.HasExceptionOrInnerExceptionsOfType<TimeoutException>(ex))
            {
                AssertInconclusive(ex);
                return null;
            }
            
            #else
            catch (Exception ex)
            {
				Assert.Inconclusive($"Database connection failed. Exception:{Environment.NewLine}{ex}");
                throw;
			}
            #endif
		}

        #if NET5_0_OR_GREATER
        private static void AssertInconclusive(Exception ex)
        {
            string message = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, false);
            Assert.Inconclusive(message);
        }
        #endif
    }
}
