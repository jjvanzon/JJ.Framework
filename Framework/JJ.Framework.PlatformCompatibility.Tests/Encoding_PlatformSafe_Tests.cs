using System.Text;
using JJ.Framework.IO.Legacy;
using JJ.Framework.Testing;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.PlatformCompatibility.Legacy.Tests
{
    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    [TestClass]
    public class Encoding_PlatformSafe_Tests
    {
        [TestMethod]
        public void Test_Encoding_GetString_PlatformSafe()
        {
            // Arrange
            string expectedText = "Test text";
            byte[] bytes = StreamHelper.StringToBytes(expectedText, Encoding.UTF8, includeByteOrderMark: false);

            // Act
            string actualText = Encoding.UTF8.GetString_PlatformSafe(bytes);

            // Assert
            AssertHelper.AreEqual(expectedText, () => actualText);
        }

        [TestMethod]
        public void Test_Encoding_GetString_FromDotNet()
        {
            // Arrange
            string expectedText = "Test text";
            byte[] bytes = StreamHelper.StringToBytes(expectedText, Encoding.UTF8, includeByteOrderMark: false);

            // Act
            string actualText = Encoding.UTF8.GetString(bytes);

            // Assert
            AssertHelper.AreEqual(expectedText, () => actualText);
        }
    }
}
