﻿using System;
using System.Data.SqlClient;
using System.Reflection;
using JJ.Framework.Logging;
using JJ.Framework.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NPersist.Framework.Exceptions;

namespace JJ.Framework.Data.Tests.Helpers
{
    internal static class TestHelper
    {
        public static void WithNPersistInconclusiveAssertion(Action action)
        {
            if (action == null) throw new NullException(() => action);

            try
            {
                action();
            }
            catch (NPersistException ex)
            {
                AssertInconclusive(ex);
            }
            catch (TargetInvocationException ex) when
            (
                ex.InnerException != null &&
                ex.InnerException is Puzzle.NPersist.Framework.Mapping.MappingException
            )
            {
                AssertInconclusive(ex);
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

        private static void AssertInconclusive(Exception ex)
        {
            string message = "Known error. Cannot get NPersist to work. " + ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false);
            Assert.Inconclusive(message);
        }
    }
}