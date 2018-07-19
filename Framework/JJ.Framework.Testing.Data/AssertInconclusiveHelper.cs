using System;
using System.Data.SqlClient;
using System.Reflection;
using JetBrains.Annotations;
using JJ.Framework.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;

namespace JJ.Framework.Testing.Data
{
    /// <summary>
    /// If your unit test relies on resources, that is not available on other machines,
    /// this class helps turn connection failures into an inconclusive test result, instead of a test failure.
    /// </summary>
    [PublicAPI]
    public static class AssertInconclusiveHelper
    {
        /// <summary>
        /// If your unit test relies on a database, that is not available on other machines,
        /// this helps turn connection failures into an inconclusive test result, instead of a test failure.
        /// </summary>
        /// <param name="action">
        /// You can pass a lambda that contains the code to execute around which this method will catch database connection failures
        /// to make a unit test inconclusive.
        /// For instance:
        /// () => { /* Test code to execute */ }
        /// </param>
        public static void WithConnectionInconclusiveAssertion(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            catch (NPersistException ex)
            {
                AssertNPersistInconclusive(ex);
            }
            catch (TargetInvocationException ex) when (ex.InnerException is MappingException)
            {
                AssertNPersistInconclusive(ex);
            }
            catch (SqlException ex)
            {
                AssertInconclusive(ex);
            }
            catch (Exception ex) when (ex.InnerException is SqlException)
            {
                AssertInconclusive(ex);
            }
            catch (Exception ex) when (ExceptionHelper.HasExceptionOrInnerExceptionsOfType<SqlException>(ex))
            {
                AssertInconclusive(ex);
            }
            catch (Exception ex) when (ExceptionHelper.HasExceptionOrInnerExceptionsOfType<TimeoutException>(ex))
            {
                AssertInconclusive(ex);
            }
        }

        private static void AssertInconclusive(Exception ex)
        {
            string message = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, false);
            Assert.Inconclusive(message);
        }

        private static void AssertNPersistInconclusive(Exception ex)
        {
            string message = "Known error. Cannot get NPersist to work. " + ExceptionHelper.FormatExceptionWithInnerExceptions(ex, false);
            Assert.Inconclusive(message);
        }
    }
}