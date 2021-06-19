using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedMember.Local
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EnumHelper_Tests
    {
        private enum TestEnum
        {
            EnumMember1,
            EnumMember2
        }

        // GetValues

        [TestMethod]
        public void Test_EnumHelper_GetValues()
        {
            IList<TestEnum> values = EnumHelper.GetValues<TestEnum>();

            AssertHelper.IsNotNull(() => values);
            AssertHelper.AreEqual(2, () => values.Count);
            AssertHelper.AreEqual(TestEnum.EnumMember1, () => values[0]);
            AssertHelper.AreEqual(TestEnum.EnumMember2, () => values[1]);
        }

        // IsValidEnum (with Enum Parameter)

        [TestMethod]
        public void Test_EnumHelper_IsValidEnum_WithEnumParameter_ValidValue_ReturnsTrue()
        {
            TestEnum validEnum = TestEnum.EnumMember2;
            bool isValidEnum = EnumHelper.IsValidEnum(validEnum);
            AssertHelper.IsTrue(() => isValidEnum);
        }

        [TestMethod]
        public void Test_EnumHelper_IsValidEnum_WithEnumParameter_InValidValue_ReturnsFalse()
        {
            TestEnum invalidEnum = (TestEnum)1234;
            bool isValidEnum = EnumHelper.IsValidEnum(invalidEnum);
            AssertHelper.IsFalse(() => isValidEnum);
        }

        // IsValidEnum (With Object Parameter)

        [TestMethod]
        public void Test_EnumHelper_IsValidEnum_WithObjectParameter_Null_ReturnsFalse()
        {
            bool isValidEnum = EnumHelper.IsValidEnum<TestEnum>(null);
            AssertHelper.IsFalse(() => isValidEnum);
        }

        [TestMethod]
        public void Test_EnumHelper_IsValidEnum_WithObjectParameter_WrongType_ReturnsFalse()
        {
            bool isValidEnum = EnumHelper.IsValidEnum<TestEnum>("Test string");
            AssertHelper.IsFalse(() => isValidEnum);
        }

        [TestMethod]
        public void Test_EnumHelper_IsValidEnum_WithObjectParameter_ValueOutOfRange_ReturnsFalse()
        {
            bool isValidEnum = EnumHelper.IsValidEnum<TestEnum>(1234);
            AssertHelper.IsFalse(() => isValidEnum);
        }

        [TestMethod]
        public void Test_EnumHelper_IsValidEnum_WithObjectParameter_ValueInOfRange_ReturnsTrue()
        {
            bool isValidEnum = EnumHelper.IsValidEnum<TestEnum>(1);
            AssertHelper.IsTrue(() => isValidEnum);
        }
    }
}
