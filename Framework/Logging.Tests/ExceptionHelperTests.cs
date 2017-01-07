using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JJ.Framework.Logging.Tests
{
    [TestClass]
    public class ExceptionHelperTests
    {
        [TestMethod]
        public void Test_ExceptionHelper_FormatExceptionWithInnerExceptions()
        {
            try
            {
                try
                {
                    throw new Exception("Something bad happend.");
                }
                catch (Exception ex)
                {
                    throw new Exception("I cought a bad exception.", ex);
                }
            }
            catch (Exception ex)
            {
                string message = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: true);
            }
        }
    }
}
