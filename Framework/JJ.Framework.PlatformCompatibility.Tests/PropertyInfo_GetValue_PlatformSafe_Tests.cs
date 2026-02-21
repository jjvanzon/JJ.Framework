using System.Reflection;
using JJ.Framework.PlatformCompatibility.Core;
using JJ.Framework.Reflection.Core;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable RedundantCast
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedMember.Local

#pragma warning disable IDE0004

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    [TestClass]
    public class PropertyInfo_GetValue_PlatformSafe_Tests
    {
        private static readonly ReflectionCacheLegacy _reflectionCache = new ReflectionCacheLegacy();

        [TestMethod]
        public void Test_PropertyInfo_GetValue_PlatformSafe_InstanceProperty()
        {
            // Arrange
            var testHelper = new TestHelper();
            PropertyInfo propertyInfo = typeof(TestHelper).GetProperty("InstanceProperty", BindingFlags.Public | BindingFlags.Instance);

            // Act
            object obj = propertyInfo.GetValue_PlatformSafe(testHelper);

            // Assert
            AssertHelper.IsOfType<double>(() => obj);
            var expectedValue = 1;
            var actualValue = (double)obj;
            AssertHelper.AreEqual(expectedValue, () => actualValue);
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_WithDotNet_InstanceProperty()
        {
            // Arrange
            var testHelper = new TestHelper();
            PropertyInfo propertyInfo = typeof(TestHelper).GetProperty("InstanceProperty", BindingFlags.Public | BindingFlags.Instance);

            // Act
            object obj = propertyInfo.GetValue(testHelper);

            // Assert
            AssertHelper.IsOfType<double>(() => obj);
            var expectedValue = 1;
            var actualValue = (double)obj;
            AssertHelper.AreEqual(expectedValue, () => actualValue);
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
            var expectedValue = 2;
            var actualValue = (float)obj;
            AssertHelper.AreEqual(expectedValue, () => actualValue);
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
            var expectedValue = 2;
            var actualValue = (float)obj;
            AssertHelper.AreEqual(expectedValue, () => actualValue);
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_PlatformSafe_IndexerProperty()
        {
            // Arrange
            var testHelper = new TestHelper();
            PropertyInfo propertyInfo = _reflectionCache.GetIndexer<int, long>(typeof(TestHelper));

            {
                // Act
                object actualObject_0_0 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)0, (long)0);

                // Assert
                string expectedValue_0_0 = "Element[0, 0]";
                AssertHelper.IsOfType<string>(() => actualObject_0_0);
                var actualValue_0_0 = (string)actualObject_0_0;
                AssertHelper.AreEqual(expectedValue_0_0, () => actualValue_0_0);
            }

            {
                // Act
                object actualObject_0_1 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)0, (long)1);

                // Assert
                string expectedValue_0_1 = "Element[0, 1]";
                AssertHelper.IsOfType<string>(() => actualObject_0_1);
                var actualValue_0_1 = (string)actualObject_0_1;
                AssertHelper.AreEqual(expectedValue_0_1, () => actualValue_0_1);
            }

            {
                // Act
                object actualObject_1_0 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)1, (long)0);

                // Assert
                string expectedValue_1_0 = "Element[1, 0]";
                AssertHelper.IsOfType<string>(() => actualObject_1_0);
                var actualValue_1_0 = (string)actualObject_1_0;
                AssertHelper.AreEqual(expectedValue_1_0, () => actualValue_1_0);
            }

            {
                // Act
                object actualObject_1_1 = propertyInfo.GetValue_PlatformSafe(testHelper, (int)1, (long)1);

                // Assert
                string expectedValue_1_1 = "Element[1, 1]";
                AssertHelper.IsOfType<string>(() => actualObject_1_1);
                var actualValue_1_1 = (string)actualObject_1_1;
                AssertHelper.AreEqual(expectedValue_1_1, () => actualValue_1_1);
            }
        }

        [TestMethod]
        public void Test_PropertyInfo_GetValue_WithDotNet_IndexerProperty()
        {
            // Arrange
            var testHelper = new TestHelper();
            PropertyInfo propertyInfo = _reflectionCache.GetIndexer<int, long>(typeof(TestHelper));

            {
                // Act
                object actualObject_0_0 = propertyInfo.GetValue(testHelper, new object[] { (int)0, (long)0 });

                // Assert
                string expectedValue_0_0 = "Element[0, 0]";
                AssertHelper.IsOfType<string>(() => actualObject_0_0);
                var actualValue_0_0 = (string)actualObject_0_0;
                AssertHelper.AreEqual(expectedValue_0_0, () => actualValue_0_0);
            }

            {
                // Act
                object actualObject_0_1 = propertyInfo.GetValue(testHelper, new object[] { (int)0, (long)1 });

                // Assert
                string expectedValue_0_1 = "Element[0, 1]";
                AssertHelper.IsOfType<string>(() => actualObject_0_1);
                var actualValue_0_1 = (string)actualObject_0_1;
                AssertHelper.AreEqual(expectedValue_0_1, () => actualValue_0_1);
            }

            {
                // Act
                object actualObject_1_0 = propertyInfo.GetValue(testHelper, new object[] { (int)1, (long)0 });

                // Assert
                string expectedValue_1_0 = "Element[1, 0]";
                AssertHelper.IsOfType<string>(() => actualObject_1_0);
                var actualValue_1_0 = (string)actualObject_1_0;
                AssertHelper.AreEqual(expectedValue_1_0, () => actualValue_1_0);
            }

            {
                // Act
                object actualObject_1_1 = propertyInfo.GetValue(testHelper, new object[] { (int)1, (long)1 });

                // Assert
                string expectedValue_1_1 = "Element[1, 1]";
                AssertHelper.IsOfType<string>(() => actualObject_1_1);
                var actualValue_1_1 = (string)actualObject_1_1;
                AssertHelper.AreEqual(expectedValue_1_1, () => actualValue_1_1);
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
