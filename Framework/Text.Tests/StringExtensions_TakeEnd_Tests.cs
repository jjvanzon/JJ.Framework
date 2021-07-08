using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeEnd_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TakeEnd()
            => AssertHelper.AreEqual("345", () => "12345".TakeEnd(3));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_NotEnoughCharacters_ReturnsLessCharacters()
            => AssertHelper.AreEqual("12345", () => "12345".TakeEnd(6));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_InputEmptyString_ReturnsEmptyString()
        {
            int dummyLength = 3;
            AssertHelper.AreEqual("", () => "".TakeEnd(dummyLength));
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_LengthZero_ReturnsEmptyString()
        {
            string dummyInput = "12345";
            AssertHelper.AreEqual("", () => dummyInput.TakeEnd(0));
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_InputNull_ThrowsException()
        {
            string nullInput = null;
            int dummyLength = 3;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => nullInput.TakeEnd(dummyLength), 
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_LengthNegative_ThrowsException()
        {
            string dummyInput = "12345";
            AssertHelper.ThrowsException(
                () => dummyInput.TakeEnd(-1),
                "length of -1 is less than 0.");
        }
    }
}
