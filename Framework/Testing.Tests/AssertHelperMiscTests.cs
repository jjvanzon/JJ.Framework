using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Testing.Tests
{
    [TestClass]
    public class AssertHelperMiscTests
    {
        [TestMethod]
        public void Test_AssertHelper_ThrowsException_HasException() => AssertHelper.ThrowsException(() => throw new Exception());

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_AssertHelper_ThrowsException_WithNoException() => AssertHelper.ThrowsException(() => { });

        [TestMethod]
        public void Test_AssertHelper_IsOfType_Succeeds()
        {
            object actualValue = "This is a string";
            AssertHelper.IsOfType<string>(() => actualValue);
        }

        [TestMethod]
        public void Test_AssertHelper_IsOfType_Fails()
        {
            object actualValue = 1;

            AssertHelper.ThrowsException<Exception>(
                () => AssertHelper.IsOfType<string>(() => actualValue),
                "Assert.IsOfType failed. Expected <System.String>, Actual <System.Int32>. Tested member: 'actualValue'.");
        }

        [TestMethod]
        public void Test_AssertHelper_IsOfType_Fails_WithNameParameter()
        {
            object actualValue = 1;

            AssertHelper.ThrowsException<Exception>(
                () => AssertHelper.IsOfType<string>(() => actualValue, "local variable"),
                "Assert.IsOfType failed. Expected <System.String>, Actual <System.Int32>. Tested member: 'local variable'.");
        }
    }
}