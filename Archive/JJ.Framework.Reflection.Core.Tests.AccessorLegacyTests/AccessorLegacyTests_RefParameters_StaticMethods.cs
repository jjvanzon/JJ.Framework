using System;
using JJ.Framework.Reflection.Core.Tests.Helpers;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InlineOutVariableDeclaration

// ReSharper disable ConvertToConstant.Local
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable NotAccessedVariable
// ReSharper disable UnusedVariable
#pragma warning disable IDE0018 // Inline variable declaration

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    [TestClass]
    public class AccessorLegacyTests_RefParameters_StaticMethods
    {
        // 1 Parameter

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithOneParameter()
        {
            int arg;

            bool ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithOneParameter(out arg);

            AssertHelper.AreEqual(1, () => arg);
            AssertHelper.AreEqual(true, () => ret);
        }

        // 2 Parameters

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithTwoParameters_ByRef_ByVal()
        {
            float arg1 = 2;
            double arg2 = 4;

            long ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithTwoParameters(ref arg1, arg2);

            AssertHelper.AreEqual(3, () => arg1);
            AssertHelper.AreEqual(4, () => arg2);
            AssertHelper.AreEqual(5, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithTwoParameters_ByVal_ByRef()
        {
            TimeSpan arg1 = ParseHelperLegacy.ParseTimeSpan("00:06");
            string arg2;

            DateTime ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithTwoParameters(arg1, out arg2);

            AssertHelper.AreEqual(ParseHelperLegacy.ParseTimeSpan("00:06"), () => arg1);
            AssertHelper.AreEqual("7", () => arg2);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseDateTime("2008-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithTwoParameters_ByRef_ByRef()
        {
            string arg1 = "9";
            TimeSpan arg2;

            Guid ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithTwoParameters(ref arg1, out arg2);

            AssertHelper.AreEqual("10", () => arg1);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseTimeSpan("00:11"), () => arg2);
            AssertHelper.AreEqual(new Guid("00000000-0000-0000-0000-000000000012"), () => ret);
        }

        // 3 Parameters

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameter_ByRef_ByVal_ByVal()
        {
            double arg1 = 13;
            float arg2 = 15;
            long arg3 = 16;

            DateTime ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(ref arg1, arg2, arg3);

            AssertHelper.AreEqual(14, () => arg1);
            AssertHelper.AreEqual(15, () => arg2);
            AssertHelper.AreEqual(16, () => arg3);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseDateTime("2017-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameters_ByVal_ByRef_ByVal()
        {
            bool arg1 = true;
            int arg2;
            long arg3 = 19;

            int ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(arg1, out arg2, arg3);

            AssertHelper.AreEqual(true, () => arg1);
            AssertHelper.AreEqual(18, () => arg2);
            AssertHelper.AreEqual(19, () => arg3);
            AssertHelper.AreEqual(20, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameters_ByRef_ByRef_ByVal()
        {
            double arg1 = 21;
            DateTime arg2;
            TimeSpan arg3 = ParseHelperLegacy.ParseTimeSpan("00:24");

            float ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(ref arg1, out arg2, arg3);

            AssertHelper.AreEqual(22, () => arg1);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseDateTime("2023-01-01"), () => arg2);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseTimeSpan("00:24"), () => arg3);
            AssertHelper.AreEqual(25, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameters_ByVal_ByVal_ByRef()
        {
            Guid arg1 = new Guid("00000000-0000-0000-0000-000000000026");
            string arg2 = "27";
            TimeSpan arg3 = ParseHelperLegacy.ParseTimeSpan("00:28");

            string ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(arg1, arg2, ref arg3);

            AssertHelper.AreEqual(new Guid("00000000-0000-0000-0000-000000000026"), () => arg1);
            AssertHelper.AreEqual("27", () => arg2);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseTimeSpan("00:29"), () => arg3);
            AssertHelper.AreEqual("30", () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameters_ByRef_ByVal_ByRef()
        {
            double arg1;
            float arg2 = 32;
            long arg3 = 33;

            DateTime ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(out arg1, arg2, ref arg3);

            AssertHelper.AreEqual(31, () => arg1);
            AssertHelper.AreEqual(32, () => arg2);
            AssertHelper.AreEqual(34, () => arg3);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseDateTime("2035-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameters_ByVal_ByRef_ByRef()
        {
            bool arg1 = true;
            int arg2;
            long arg3 = 37;

            int ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(arg1, out arg2, ref arg3);

            AssertHelper.AreEqual(true, () => arg1);
            AssertHelper.AreEqual(36, () => arg2);
            AssertHelper.AreEqual(38, () => arg3);
            AssertHelper.AreEqual(39, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithThreeParameters_ByRef_ByRef_ByRef()
        {
            double arg1;
            DateTime arg2 = ParseHelperLegacy.ParseDateTime("2041-01-01");
            TimeSpan arg3;

            float ret = ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithThreeParameters(out arg1, ref arg2, out arg3);

            AssertHelper.AreEqual(40, () => arg1);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseDateTime("2042-01-01"), () => arg2);
            AssertHelper.AreEqual(ParseHelperLegacy.ParseTimeSpan("00:43"), () => arg3);
            AssertHelper.AreEqual(44, () => ret);
        }

        // Misc

        [TestMethod]
        public void Test_Accessor_RefParameters_StaticMethod_WithReturnTypeVoid()
        {
            DateTime arg = ParseHelperLegacy.ParseDateTime("2045-01-01");

            ClassLegacy_RefParameters_StaticMethods_Accessor.StaticMethod_WithReturnTypeVoid(ref arg);

            AssertHelper.AreEqual(ParseHelperLegacy.ParseDateTime("2046-01-01"), () => arg);
        }
    }
}
