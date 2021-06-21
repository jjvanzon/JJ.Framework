using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class DoubleHelperTests
    {
        [TestMethod]
        public void Test_DoubleHelper_IsSpecialValue_False()
        {
            bool isSpecialValue = DoubleHelper.IsSpecialValue(10);
            AssertHelper.IsFalse(() => isSpecialValue);
        }

        [TestMethod]
        public void Test_DoubleHelper_IsSpecialValue_NaN()
        {
            bool isSpecialValue = DoubleHelper.IsSpecialValue(double.NaN);
            AssertHelper.IsTrue(() => isSpecialValue);
        }

        [TestMethod]
        public void Test_DoubleHelper_IsSpecialValue_PositiveInfinity()
        {
            bool isSpecialValue = DoubleHelper.IsSpecialValue(double.PositiveInfinity);
            AssertHelper.IsTrue(() => isSpecialValue);
        }

        [TestMethod]
        public void Test_DoubleHelper_IsSpecialValue_NegativeInfinity()
        {
            bool isSpecialValue = DoubleHelper.IsSpecialValue(double.NegativeInfinity);
            AssertHelper.IsTrue(() => isSpecialValue);
        }
    }
}
