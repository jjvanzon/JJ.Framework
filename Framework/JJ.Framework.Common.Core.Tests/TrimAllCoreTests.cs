namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class TrimAllCoreTests
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
        CollectionAssert.AreEqual(expectedTexts, resultTexts1);
        CollectionAssert.AreEqual(expectedTexts, resultTexts2);
    }
    
    [TestMethod]
    public void TrimAll_NullException_Core_Test()
    {
        IEnumerable<string> nullCollection = null;
        
        ThrowsExceptionContaining(
            () => nullCollection.TrimAll(),
            "Value cannot be null.", "Parameter", "values");
    }
}