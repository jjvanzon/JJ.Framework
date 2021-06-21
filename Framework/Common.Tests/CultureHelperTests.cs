using System.Globalization;
using System.Threading;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class CultureHelperTests
    {
        [TestMethod]
        public void Test_CultureHelper_SetCurrentCulture()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                CultureHelper.SetCurrentCulture(new CultureInfo("nl-NL"));
                AssertHelper.AreEqual("nl-NL", () => Thread.CurrentThread.CurrentCulture.Name);
                AssertHelper.AreEqual("nl-NL", () => Thread.CurrentThread.CurrentUICulture.Name);
                
                CultureHelper.SetCurrentCulture(new CultureInfo("de-DE"));
                AssertHelper.AreEqual("de-DE", () => Thread.CurrentThread.CurrentCulture.Name);
                AssertHelper.AreEqual("de-DE", () => Thread.CurrentThread.CurrentUICulture.Name);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalUICulture;
            }
        }

        [TestMethod]
        public void Test_CultureHelper_SetCurrentCultureName()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                CultureHelper.SetCurrentCultureName("nl-NL");
                AssertHelper.AreEqual("nl-NL", () => Thread.CurrentThread.CurrentCulture.Name);
                AssertHelper.AreEqual("nl-NL", () => Thread.CurrentThread.CurrentUICulture.Name);

                CultureHelper.SetCurrentCultureName("de-DE");
                AssertHelper.AreEqual("de-DE", () => Thread.CurrentThread.CurrentCulture.Name);
                AssertHelper.AreEqual("de-DE", () => Thread.CurrentThread.CurrentUICulture.Name);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalUICulture;
            }
        }

        [TestMethod]
        public void Test_CultureHelper_GetCurrentCulture()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                    CultureInfo currentCulture = CultureHelper.GetCurrentCulture();
                    AssertHelper.AreEqual("nl-NL", () => currentCulture.Name);
                }

                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                    CultureInfo currentCulture = CultureHelper.GetCurrentCulture();
                    AssertHelper.AreEqual("de-DE", () => currentCulture.Name);
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalUICulture;
            }
        }

        [TestMethod]
        public void Test_CultureHelper_GetCurrentCultureName()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                    string currentCultureName = CultureHelper.GetCurrentCultureName();
                    AssertHelper.AreEqual("nl-NL", () => currentCultureName);
                }
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                    string currentCultureName = CultureHelper.GetCurrentCultureName();
                    AssertHelper.AreEqual("de-DE", () => currentCultureName);
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalUICulture;
            }
        }
    }
}
