using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JJ.Framework.Logging;
using JJ.Framework.Testing;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class CultureHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_CultureHelper_Obsolete_SetThreadCultureName_ThrowsException()
        {
            try
            {
                CultureHelper_Accessor.SetThreadCultureName("nl-NL");
            }
            catch (Exception ex)
            {
                ex = ex.GetInnermostException();
                Assert.IsInstanceOfType(ex, typeof(NotSupportedException));
                AssertHelper.AreEqual("Use SetCurrentCultureName instead.",  () => ex.Message);
            }
        }
    }
}
