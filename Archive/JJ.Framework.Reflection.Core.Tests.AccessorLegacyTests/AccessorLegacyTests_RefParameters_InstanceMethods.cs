using static JJ.Framework.Reflection.Core.Tests.Helpers.ParseHelperLegacy;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
#pragma warning disable IDE0018 // Inline variable declaration

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    [TestClass]
    public class AccessorLegacyTests_RefParameters_InstanceMethods
    {
        // 1 Parameter

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithOneParameter()
        {
            int arg;

            bool ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithOneParameter(out arg);

            AreEqual(1, () => arg);
            AreEqual(true, () => ret);
        }

        // 2 Parameters

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithTwoParameters_ByRef_ByVal()
        {
            float arg1 = 2;
            double arg2 = 4;

            long ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithTwoParameters(ref arg1, arg2);

            AreEqual(3, () => arg1);
            AreEqual(4, () => arg2);
            AreEqual(5, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithTwoParameters_ByVal_ByRef()
        {
            TimeSpan arg1 = ParseTimeSpan("00:06");
            string arg2;

            DateTime ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithTwoParameters(arg1, out arg2);

            AreEqual(ParseTimeSpan("00:06"), () => arg1);
            AreEqual("7", () => arg2);
            AreEqual(ParseDateTime("2008-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithTwoParameters_ByRef_ByRef()
        {
            string arg1 = "9";
            TimeSpan arg2;

            Guid ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithTwoParameters(ref arg1, out arg2);

            AreEqual("10", () => arg1);
            AreEqual(ParseTimeSpan("00:11"), () => arg2);
            AreEqual(new Guid("00000000-0000-0000-0000-000000000012"), () => ret);
        }

        // 3 Parameters

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameter_ByRef_ByVal_ByVal()
        {
            double arg1 = 13;
            float arg2 = 15;
            long arg3 = 16;

            DateTime ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(ref arg1, arg2, arg3);

            AreEqual(14, () => arg1);
            AreEqual(15, () => arg2);
            AreEqual(16, () => arg3);
            AreEqual(ParseDateTime("2017-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameters_ByVal_ByRef_ByVal()
        {
            bool arg1 = true;
            int arg2;
            long arg3 = 19;

            int ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(arg1, out arg2, arg3);

            AreEqual(true, () => arg1);
            AreEqual(18, () => arg2);
            AreEqual(19, () => arg3);
            AreEqual(20, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameters_ByRef_ByRef_ByVal()
        {
            double arg1 = 21;
            DateTime arg2;
            TimeSpan arg3 = ParseTimeSpan("00:24");

            float ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(ref arg1, out arg2, arg3);

            AreEqual(22, () => arg1);
            AreEqual(ParseDateTime("2023-01-01"), () => arg2);
            AreEqual(ParseTimeSpan("00:24"), () => arg3);
            AreEqual(25, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameters_ByVal_ByVal_ByRef()
        {
            Guid arg1 = new Guid("00000000-0000-0000-0000-000000000026");
            string arg2 = "27";
            TimeSpan arg3 = ParseTimeSpan("00:28");

            string ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(arg1, arg2, ref arg3);

            AreEqual(new Guid("00000000-0000-0000-0000-000000000026"), () => arg1);
            AreEqual("27", () => arg2);
            AreEqual(ParseTimeSpan("00:29"), () => arg3);
            AreEqual("30", () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameters_ByRef_ByVal_ByRef()
        {
            double arg1;
            float arg2 = 32;
            long arg3 = 33;

            DateTime ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(out arg1, arg2, ref arg3);

            AreEqual(31, () => arg1);
            AreEqual(32, () => arg2);
            AreEqual(34, () => arg3);
            AreEqual(ParseDateTime("2035-01-01"), () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameters_ByVal_ByRef_ByRef()
        {
            bool arg1 = true;
            int arg2;
            long arg3 = 37;

            int ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(arg1, out arg2, ref arg3);

            AreEqual(true, () => arg1);
            AreEqual(36, () => arg2);
            AreEqual(38, () => arg3);
            AreEqual(39, () => ret);
        }

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithThreeParameters_ByRef_ByRef_ByRef()
        {
            double arg1;
            DateTime arg2 = ParseDateTime("2041-01-01");
            TimeSpan arg3;

            float ret = new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithThreeParameters(out arg1, ref arg2, out arg3);

            AreEqual(40, () => arg1);
            AreEqual(ParseDateTime("2042-01-01"), () => arg2);
            AreEqual(ParseTimeSpan("00:43"), () => arg3);
            AreEqual(44, () => ret);
        }

        // Misc

        [TestMethod]
        public void Test_Accessor_RefParameters_InstanceMethod_WithReturnTypeVoid()
        {
            DateTime arg = ParseDateTime("2045-01-01");

            new ClassLegacy_RefParameters_InstanceMethods_Accessor().InstanceMethod_WithReturnTypeVoid(ref arg);

            AreEqual(ParseDateTime("2046-01-01"), () => arg);
        }
    }
}
