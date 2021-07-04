using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            => AssertHelper.AreEqual("1234", () => "1234".TakeEnd(5));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_InputEmptyString_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TakeEnd(3));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_LengthZero_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "1234".TakeEnd(0));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_InputNull_ThrowsException()
        {
            string input = null;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => input.TakeEnd(3), 
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_LengthNegative_ThrowsException() 
            => AssertHelper.ThrowsException(
                () => "1234".TakeEnd(-1), 
                "length of -1 is less than 0.");
    }
}
