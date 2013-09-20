using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Testing.Tests
{
    [TestClass]
    public class AssertExtensionsTests
    {
        [TestMethod]
        public void Test_ThrowsException_HasException()
        {
            AssertExtensions.ThrowsException(() => { throw new Exception(); });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_ThrowsException_NoException()
        {
            AssertExtensions.ThrowsException(() => { });
        }
    }
}
