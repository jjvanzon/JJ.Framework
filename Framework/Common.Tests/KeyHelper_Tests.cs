using System;
using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class KeyHelper_Tests
    {
        private const string SEPARATOR = "89765d597c724aa3832070f21446a543";

        [TestMethod]
        public void Test_KeyHelper_CreateKey_ValuesNull_ThrowsException()
            => Assert.ThrowsException<ArgumentNullException>(
                () => KeyHelper.CreateKey(null),
                $"Value cannot be null.{Environment.NewLine}Parameter name: values");

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithObjects_Succeeds()
        {
            // Arrange
            IEnumerable<object> objects = new object[] { 10, "lalala", GetType() };

            // Act
            string actualKey = KeyHelper.CreateKey(objects);

            // Assert
            string expectedKey = $"10{SEPARATOR}lalala{SEPARATOR}{GetType()}";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithStrings_Succeeds()
        {
            // Arrange
            IEnumerable<string> strings = new[] { "Part1", "Part2", "Part3" };

            // Act
            string actualKey = KeyHelper.CreateKey(strings);

            // Assert
            string expectedKey = $"Part1{SEPARATOR}Part2{SEPARATOR}Part3";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithInts_Succeeds()
        {
            // Arrange
            IEnumerable<int> strings = new[] { 3, 10, 1234 };

            // Act
            string actualKey = KeyHelper.CreateKey(strings);

            // Assert
            string expectedKey = $"3{SEPARATOR}10{SEPARATOR}1234";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }
    }
}
