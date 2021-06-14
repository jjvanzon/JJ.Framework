using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Testing.Tests
{
    [TestClass]
    public class AssertHelperMiscTests
    {
        // ThrowsException

        [TestMethod]
        public void Test_AssertHelper_ThrowsException_HasException() => AssertHelper.ThrowsException(() => throw new Exception());

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_AssertHelper_ThrowsException_WithNoException() => AssertHelper.ThrowsException(() => { });

        // IsOfType

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

        // NotEqual

        [TestMethod]
        public void Test_AssertHelper_NotEqual_Succeeds_WithExpressionParameter()
        {
            int a = 1;
            int b = 2;
            AssertHelper.NotEqual(a, () => b);
        }

        [TestMethod]
        public void Test_AssertHelper_NotEqual_Succeeds_WithNameParameter()
        {
            int a = 1;
            int b = 2;
            AssertHelper.NotEqual(a, () => b, "local variable");
        }

        [TestMethod]
        public void Test_AssertHelper_NotEqual_Fails_WithExpressionParameter()
        {
            int a = 1;
            int b = 1;
            AssertHelper.ThrowsException(
                () => AssertHelper.NotEqual(a, () => b),
                "Assert.NotEqual failed. Both values are <1>. Tested member: 'b'.");
        }

        [TestMethod]
        public void Test_AssertHelper_NotEqual_Fails_WithNameParameter()
        {
            int a = 1;
            int b = 1;
            AssertHelper.ThrowsException(
                () => AssertHelper.NotEqual(a, () => b, "local variable"),
                "Assert.NotEqual failed. Both values are <1>. Tested member: 'local variable'.");
        }

        // NotSame

        [TestMethod]
        public void Test_AssertHelper_NotSame_Succeeds_WithExpressionParameter()
        {
            var a = new object();
            var b = new object();
            AssertHelper.NotSame(a, () => b);
        }

        [TestMethod]
        public void Test_AssertHelper_NotSame_Succeeds_WithNameParameter()
        {
            var a = new object();
            var b = new object();
            AssertHelper.NotSame(a, () => b, "local variable");
        }

        [TestMethod]
        public void Test_AssertHelper_NotSame_Fails_WithExpressionParameter()
        {
            var a = new object();
            var b = a;
            AssertHelper.ThrowsException(
                () => AssertHelper.NotSame(a, () => b),
                "Assert.NotSame failed. Both values are <System.Object>. Tested member: 'b'.");
        }

        [TestMethod]
        public void Test_AssertHelper_NotSame_Fails_WithNameParameter()
        {
            var a = new object();
            var b = a;
            AssertHelper.ThrowsException(
                () => AssertHelper.NotSame(a, () => b, "local variable"),
                "Assert.NotSame failed. Both values are <System.Object>. Tested member: 'local variable'.");
        }
    }
}