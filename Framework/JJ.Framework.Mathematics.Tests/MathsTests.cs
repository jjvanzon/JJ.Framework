using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Testing;

namespace JJ.Framework.Mathematics.Tests
{
    [TestClass]
    public class MathsTests
    {
        [TestMethod]
        public void Test_Maths_Pow()
        {
            AssertHelper.AreEqual(1, () => Maths.Pow(2, 0));
            AssertHelper.AreEqual(2, () => Maths.Pow(2, 1));
            AssertHelper.AreEqual(4, () => Maths.Pow(2, 2));
            AssertHelper.AreEqual(8, () => Maths.Pow(2, 3));
        }

        [TestMethod]
        public void Test_Maths_Pow_WithNegativeExponent_AlwaysReturns1()
        {
            AssertHelper.AreEqual(1, () => Maths.Pow(2, -1));
        }
    }
}
