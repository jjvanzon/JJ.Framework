using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable NotAccessedVariable
// ReSharper disable UnusedVariable
#pragma warning disable IDE0018 // Inline variable declaration

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    [TestClass]
    public class AccessorTests_OutParameters_InstanceMethods
    {
        // 1 Parameter

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithOneParameter()
        {
            int arg;

            bool ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithOneParameter(out arg);

            AssertHelper.AreEqual(1, () => arg);
            AssertHelper.AreEqual(true, () => ret);
        }

        // 2 Parameters

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithTwoParameters_Out_ByVal()
        {
            float arg1;
            double arg2 = 3;

            long ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithTwoParameters(out arg1, arg2);

            AssertHelper.AreEqual(2, () => arg1);
            AssertHelper.AreEqual(3, () => arg2);
            AssertHelper.AreEqual(4, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithTwoParameters_ByVal_Out()
        {
            TimeSpan arg1 = ParseHelper.ParseTimeSpan("00:05");
            string arg2;

            DateTime ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithTwoParameters(arg1, out arg2);

            AssertHelper.AreEqual(ParseHelper.ParseTimeSpan("00:05"), () => arg1);
            AssertHelper.AreEqual("6", () => arg2);
            AssertHelper.AreEqual(ParseHelper.ParseDateTime("2007-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithTwoParameters_Out_Out()
        {
            string arg1;
            TimeSpan arg2;

            Guid ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithTwoParameters(out arg1, out arg2);

            AssertHelper.AreEqual("8", () => arg1);
            AssertHelper.AreEqual(ParseHelper.ParseTimeSpan("00:09"), () => arg2);
            AssertHelper.AreEqual(new Guid("00000000-0000-0000-0000-000000000010"), () => ret);
        }

        // 3 Parameters

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameter_Out_ByVal_ByVal()
        {
            double arg1;
            float arg2 = 12;
            long arg3 = 13;

            DateTime ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(out arg1, arg2, arg3);

            AssertHelper.AreEqual(11, () => arg1);
            AssertHelper.AreEqual(12, () => arg2);
            AssertHelper.AreEqual(13, () => arg3);
            AssertHelper.AreEqual(ParseHelper.ParseDateTime("2014-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameters_ByVal_Out_ByVal()
        {
            bool arg1 = false;
            int arg2;
            long arg3 = 16;

            int ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(arg1, out arg2, arg3);

            AssertHelper.AreEqual(false, () => arg1);
            AssertHelper.AreEqual(15, () => arg2);
            AssertHelper.AreEqual(16, () => arg3);
            AssertHelper.AreEqual(17, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameters_Out_Out_ByVal()
        {
            double arg1;
            DateTime arg2;
            TimeSpan arg3 = ParseHelper.ParseTimeSpan("00:20");

            float ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(out arg1, out arg2, arg3);

            AssertHelper.AreEqual(18, () => arg1);
            AssertHelper.AreEqual(ParseHelper.ParseDateTime("2019-01-01"), () => arg2);
            AssertHelper.AreEqual(ParseHelper.ParseTimeSpan("00:20"), () => arg3);
            AssertHelper.AreEqual(21, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameters_ByVal_ByVal_Out()
        {
            Guid arg1 = new Guid("00000000-0000-0000-0000-000000000022");
            string arg2 = "23";
            TimeSpan arg3;

            string ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(arg1, arg2, out arg3);

            AssertHelper.AreEqual(new Guid("00000000-0000-0000-0000-000000000022"), () => arg1);
            AssertHelper.AreEqual("23", () => arg2);
            AssertHelper.AreEqual(ParseHelper.ParseTimeSpan("00:24"), () => arg3);
            AssertHelper.AreEqual("25", () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameters_Out_ByVal_Out()
        {
            double arg1;
            float arg2 = 27;
            long arg3;

            DateTime ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(out arg1, arg2, out arg3);

            AssertHelper.AreEqual(26, () => arg1);
            AssertHelper.AreEqual(27, () => arg2);
            AssertHelper.AreEqual(28, () => arg3);
            AssertHelper.AreEqual(ParseHelper.ParseDateTime("2029-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameters_ByVal_Out_Out()
        {
            bool arg1 = true;
            int arg2;
            long arg3;

            int ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(arg1, out arg2, out arg3);

            AssertHelper.AreEqual(true, () => arg1);
            AssertHelper.AreEqual(30, () => arg2);
            AssertHelper.AreEqual(31, () => arg3);
            AssertHelper.AreEqual(32, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithThreeParameters_Out_Out_Out()
        {
            double arg1;
            DateTime arg2;
            TimeSpan arg3;

            float ret = new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(out arg1, out arg2, out arg3);

            AssertHelper.AreEqual(33, () => arg1);
            AssertHelper.AreEqual(ParseHelper.ParseDateTime("2034-01-01"), () => arg2);
            AssertHelper.AreEqual(ParseHelper.ParseTimeSpan("00:35"), () => arg3);
            AssertHelper.AreEqual(36, () => ret);
        }

        // Misc

        [TestMethod]
        public void Test_Accessor_OutParameters_InstanceMethod_WithReturnTypeVoid()
        {
            DateTime arg;

            new Class_OutParameters_InstanceMethods_Accessor().InstanceMethod_WithReturnTypeVoid(out arg);

            AssertHelper.AreEqual(ParseHelper.ParseDateTime("2037-01-01"), () => arg);
        }
    }
}
