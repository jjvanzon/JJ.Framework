namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class IEnumerableOfStringExtensionsCoreTests
{
    [TestMethod]
    public void TrimAll_Core_Test()
    {
        // Arrange
        IEnumerable<string> inputTexts = [ "  test1 \n ", " \r test2", "test3 \t " ];
        string[] expectedTexts = [ "test1", "test2", "test3" ];

        // Act
        string[] resultTexts1 = inputTexts.Select(x => x.Trim()).ToArray();
        string[] resultTexts2 = inputTexts.TrimAll();

        // Assert
        AreEqual(expectedTexts, resultTexts1);
        AreEqual(expectedTexts, resultTexts2);
    }
}