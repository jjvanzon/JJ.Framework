using System.Reflection;
using JJ.Framework.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable RedundantCast
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

#pragma warning disable IDE0004

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public class PropertyInfo_GetValue_PlatformSafe_Tests
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache();

        [TestMethod]
        public void Test_PropertyInfo_GetValue_PlatformSafe_InstanceProperty()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestHelper).GetProperty("InstanceProperty", BindingFlags.Public | BindingFlags.Instance);
            var testHelper = new TestHelper();

            // Act
            object obj = propertyInfo.GetValue_PlatformSafe(testHelper);

            // Assert
            AssertHelper.IsOfType<double>(() => obj);
            var value = (double)obj;
            AssertHelper.AreEqual(testHelper.InstanceProperty, () => value);
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_WithDotNet_InstanceProperty()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestHelper).GetProperty("InstanceProperty", BindingFlags.Public | BindingFlags.Instance);
            var testHelper = new TestHelper();

            // Act
            object obj = propertyInfo.GetValue(testHelper);

            // Assert
            AssertHelper.IsOfType<double>(() => obj);
            var value = (double)obj;
            AssertHelper.AreEqual(testHelper.InstanceProperty, () => value);
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_PlatformSafe_StaticProperty()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestHelper).GetProperty("StaticProperty", BindingFlags.Public | BindingFlags.Static);
            
            // Act
            object obj = propertyInfo.GetValue_PlatformSafe(null);

            // Assert
            AssertHelper.IsOfType<float>(() => obj);
            var value = (float)obj;
            AssertHelper.AreEqual(TestHelper.StaticProperty, () => value);
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_WithDotNet_StaticProperty()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestHelper).GetProperty("StaticProperty", BindingFlags.Public | BindingFlags.Static);

            // Act
            object obj = propertyInfo.GetValue(null);

            // Assert
            AssertHelper.IsOfType<float>(() => obj);
            var value = (float)obj;
            AssertHelper.AreEqual(TestHelper.StaticProperty, () => value);
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_PlatformSafe_IndexerProperty()
        {
            // Arrange
            PropertyInfo propertyInfo = _reflectionCache.GetIndexer<int, long>(typeof(TestHelper));
            var testHelper = new TestHelper();

            {
                // Act
                object actualObject00 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)0, (long)0);

                // Assert
                string expectedValue00 = testHelper[0, 0];
                AssertHelper.IsOfType<string>(() => actualObject00);
                var actualValue00 = (string)actualObject00;
                AssertHelper.AreEqual(expectedValue00, () => actualValue00);
            }

            {
                // Act
                object actualObject01 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)0, (long)1);

                // Assert
                string expectedValue01 = testHelper[0, 1];
                AssertHelper.IsOfType<string>(() => actualObject01);
                var actualValue01 = (string)actualObject01;
                AssertHelper.AreEqual(expectedValue01, () => actualValue01);
            }

            {
                // Act
                object actualObject10 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)1, (long)0);

                // Assert
                string expectedValue10 = testHelper[1, 0];
                AssertHelper.IsOfType<string>(() => actualObject10);
                var actualValue01 = (string)actualObject10;
                AssertHelper.AreEqual(expectedValue10, () => actualValue01);
            }

            {
                // Act
                object actualObject11 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)1, (long)1);

                // Assert
                string expectedValue11 = testHelper[1, 1];
                AssertHelper.IsOfType<string>(() => actualObject11);
                var actualValue11 = (string)actualObject11;
                AssertHelper.AreEqual(expectedValue11, () => actualValue11);
            }
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_WithDotNet_IndexerProperty()
        {
            // Arrange
            PropertyInfo propertyInfo = _reflectionCache.GetIndexer<int, long>(typeof(TestHelper));
            var testHelper = new TestHelper();

            {
                // Act
                object actualObject00 = propertyInfo.GetValue(testHelper, new object[] { (int)0, (long)0 });

                // Assert
                string expectedValue00 = testHelper[0, 0];
                AssertHelper.IsOfType<string>(() => actualObject00);
                var actualValue00 = (string)actualObject00;
                AssertHelper.AreEqual(expectedValue00, () => actualValue00);
            }

            {
                // Act
                object actualObject01 = propertyInfo.GetValue(testHelper, new object[] { (int)0, (long)1 });

                // Assert
                string expectedValue01 = testHelper[0, 1];
                AssertHelper.IsOfType<string>(() => actualObject01);
                var actualValue01 = (string)actualObject01;
                AssertHelper.AreEqual(expectedValue01, () => actualValue01);
            }

            {
                // Act
                object actualObject10 = propertyInfo.GetValue(testHelper, new object[] { (int)1, (long)0 });

                // Assert
                string expectedValue10 = testHelper[1, 0];
                AssertHelper.IsOfType<string>(() => actualObject10);
                var actualValue01 = (string)actualObject10;
                AssertHelper.AreEqual(expectedValue10, () => actualValue01);
            }

            {
                // Act
                object actualObject11 = propertyInfo.GetValue(testHelper, new object[] { (int)1, (long)1 });

                // Assert
                string expectedValue11 = testHelper[1, 1];
                AssertHelper.IsOfType<string>(() => actualObject11);
                var actualValue11 = (string)actualObject11;
                AssertHelper.AreEqual(expectedValue11, () => actualValue11);
            }
        }

        // Helpers

        private class TestHelper
        {
            public double InstanceProperty { get; set; } = 1;

            public static float StaticProperty { get; set; } = 2;

            private static readonly string[,] _indexerValues =
            {
                { "Element[0, 0]", "Element[0, 1]" },
                { "Element[1, 0]", "Element[1, 1]" }
            };

            public string this[int index1, long index2] => _indexerValues[index1, index2];
        }
    }
}
