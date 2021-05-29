using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Testing;
using System;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable SuggestVarOrType_BuiltInTypes

namespace JJ.Framework.Mathematics.Tests
{
    [TestClass]
    public class MathHelperTests
    {
        [TestMethod]
        public void Test_MathHelper_Pow()
        {
            AssertHelper.AreEqual(1, () => MathHelper.Pow(2, 0));
            AssertHelper.AreEqual(2, () => MathHelper.Pow(2, 1));
            AssertHelper.AreEqual(4, () => MathHelper.Pow(2, 2));
            AssertHelper.AreEqual(8, () => MathHelper.Pow(2, 3));
        }

        [TestMethod]
        public void Test_MathHelper_Pow_WithNegativeExponent_AlwaysReturns1() => AssertHelper.AreEqual(1, () => MathHelper.Pow(2, -1));

        [TestMethod]
        public void Test_MathHelper_FormatWithDecimalCount()
        {
            (decimal value, int decimalCount, string expectedFormattedValue)[] tuplesToTest =
            {
                (.45m, 4, "0.4500"),
                (.45m, 3, "0.450"),
                (.45m, 2, "0.45"),
                (.45m, 1, "0.5"),
                (123.45m, 4, "123.4500"),
                (123.45m, 3, "123.450"),
                (123.45m, 2, "123.45"),
                (123.45m, 1, "123.5"),
                (123.45m, 0, "123"),
                (123.4m, 3, "123.400"),
                (123.4m, 2, "123.40"),
                (123.4m, 1, "123.4"),
                (123.4m, 0, "123"),
                (123m, 2, "123.00"),
                (123m, 1, "123.0"),
                (123m, 0, "123")
            };

            foreach ((decimal value, int decimalCount, string expectedFormattedValue) in tuplesToTest)
            {
                Test_MathHelper_FormatWithDecimalCount(value, "0", decimalCount, expectedFormattedValue);
            }
        }

        [TestMethod]
        public void Test_MathHelper_FormatWithDecimalCount_WithBaseFormatString_ZeroPointZero()
        {
            string baseFormatString = "0.0";

            (decimal value, int additionalDecimalCount, string expectedFormattedValue)[] tuplesToTest =
            {
                (.45m, 3, "0.4500"),
                (.45m, 2, "0.450"),
                (.45m, 1, "0.45"),
                (.45m, 0, "0.5"),
                (123.45m, 3, "123.4500"),
                (123.45m, 2, "123.450"),
                (123.45m, 1, "123.45"),
                (123.45m, 0, "123.5"),
                (123.4m, 2, "123.400"),
                (123.4m, 1, "123.40"),
                (123.4m, 0, "123.4"),
                (123m, 1, "123.00"),
                (123m, 0, "123.0")
            };

            foreach ((decimal value, int additionalDecimalCount, string expectedFormattedValue) in tuplesToTest)
            {
                Test_MathHelper_FormatWithDecimalCount(value, baseFormatString, additionalDecimalCount, expectedFormattedValue);
            }
        }

        [TestMethod]
        public void Test_MathHelper_FormatWithDecimalCount_WithBaseFormatString_Hash()
        {
            string baseFormatString = "#";

            (decimal value, int additionalDecimalCount, string expectedFormattedValue)[] tuplesToTest =
            {
                (.45m, 4, ".4500"),
                (.45m, 3, ".450"),
                (.45m, 2, ".45"),
                (.45m, 1, ".5"),
                (.45m, 0, ""),
                (123.45m, 4, "123.4500"),
                (123.45m, 3, "123.450"),
                (123.45m, 2, "123.45"),
                (123.45m, 1, "123.5"),
                (123.45m, 0, "123"),
                (123.4m, 3, "123.400"),
                (123.4m, 2, "123.40"),
                (123.4m, 1, "123.4"),
                (123.4m, 0, "123"),
                (123m, 2, "123.00"),
                (123m, 1, "123.0"),
                (123m, 0, "123")
            };

            foreach ((decimal value, int additionalDecimalCount, string expectedFormattedValue) in tuplesToTest)
            {
                Test_MathHelper_FormatWithDecimalCount(value, baseFormatString, additionalDecimalCount, expectedFormattedValue);
            }
        }

        private static void Test_MathHelper_FormatWithDecimalCount(decimal value, string baseFormatString, int additionalDecimalCount, string expectedFormattedValue)
        {
            string testedExpression = @$"MathHelper.FormatWithDecimalCount({value}, ""{baseFormatString}"", {nameof(additionalDecimalCount)}: {additionalDecimalCount})";
            string actual = MathHelper.FormatWithDecimalCount(value, baseFormatString, additionalDecimalCount);
            Console.WriteLine(@$"{testedExpression} = ""{actual}""");

            Assert.AreEqual(expectedFormattedValue, actual, "Tested expression: " + testedExpression);
        }
    }
}
