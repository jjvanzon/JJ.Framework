using System;
using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class KeyHelper_Tests
    {
        private const string DEFAULT_SEPARATOR = "89765d597c724aa3832070f21446a543";
        private const string CUSTOM_SEPARATOR = "@";

        [TestMethod]
        public void Test_KeyHelper_CreateKey_ValuesNull_WithDefaultSeparator_ThrowsException()
            => Assert.ThrowsException<ArgumentNullException>(
                () => KeyHelper.CreateKey(null),
                $"Value cannot be null.{Environment.NewLine}Parameter name: values");

        [TestMethod]
        public void Test_KeyHelper_CreateKey_ValuesNull_WithCustomSeparator_ThrowsException()
            => Assert.ThrowsException<ArgumentNullException>(
                () => KeyHelper.CreateKey(null, CUSTOM_SEPARATOR),
                $"Value cannot be null.{Environment.NewLine}Parameter name: values");

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithNullSeparator_Works()
        {
            // Arrange
            var items = new[] { 1, 2, 3 };

            // Act
            string actualKey = KeyHelper.CreateKey(items, null);

            // Assert
            string expectedKey = "123";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithEmptySTringSeparator_Works()
        {
            // Arrange
            var items = new[] { 1, 2, 3 };

            // Act
            string actualKey = KeyHelper.CreateKey(items, "");

            // Assert
            string expectedKey = "123";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithObjects_WithDefaultSeparator_Succeeds()
        {
            // Arrange
            IEnumerable<object> objects = new object[] { 10, "lalala", GetType() };

            // Act
            string actualKey = KeyHelper.CreateKey(objects);

            // Assert
            string expectedKey = $"10{DEFAULT_SEPARATOR}lalala{DEFAULT_SEPARATOR}{GetType()}";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithObjects_WithCustomSeparator_Succeeds()
        {
            // Arrange
            IEnumerable<object> objects = new object[] { 10, "lalala", GetType() };

            // Act
            string actualKey = KeyHelper.CreateKey(objects, CUSTOM_SEPARATOR);

            // Assert
            string expectedKey = $"10{CUSTOM_SEPARATOR}lalala{CUSTOM_SEPARATOR}{GetType()}";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithStrings_WithDefaultSeparator_Succeeds()
        {
            // Arrange
            IEnumerable<string> strings = new[] { "Part1", "Part2", "Part3" };

            // Act
            string actualKey = KeyHelper.CreateKey(strings);

            // Assert
            string expectedKey = $"Part1{DEFAULT_SEPARATOR}Part2{DEFAULT_SEPARATOR}Part3";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithStrings_WithCustomSeparator_Succeeds()
        {
            // Arrange
            IEnumerable<string> strings = new[] { "Part1", "Part2", "Part3" };

            // Act
            string actualKey = KeyHelper.CreateKey(strings, CUSTOM_SEPARATOR);

            // Assert
            string expectedKey = $"Part1{CUSTOM_SEPARATOR}Part2{CUSTOM_SEPARATOR}Part3";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithInts_WithDefaultSeparator_Succeeds()
        {
            // Arrange
            IEnumerable<int> strings = new[] { 3, 10, 1234 };

            // Act
            string actualKey = KeyHelper.CreateKey(strings);

            // Assert
            string expectedKey = $"3{DEFAULT_SEPARATOR}10{DEFAULT_SEPARATOR}1234";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }

        [TestMethod]
        public void Test_KeyHelper_CreateKey_WithInts_WithCustomSeparator_Succeeds()
        {
            // Arrange
            IEnumerable<int> strings = new[] { 3, 10, 1234 };

            // Act
            string actualKey = KeyHelper.CreateKey(strings, CUSTOM_SEPARATOR);

            // Assert
            string expectedKey = $"3{CUSTOM_SEPARATOR}10{CUSTOM_SEPARATOR}1234";
            AssertHelper.AreEqual(expectedKey, () => actualKey);
        }
    }
}
