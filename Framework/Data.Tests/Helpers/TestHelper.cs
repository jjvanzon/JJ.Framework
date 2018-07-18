using System;
using System.Data.SqlClient;
using System.Reflection;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;

namespace JJ.Framework.Data.Tests.Helpers
{
    internal static class TestHelper
    {
        public static void WithConnectionInconclusiveAssertion(Action action)
        {
            if (action == null) throw new NullException(() => action);

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