namespace JJ.Framework.ResourceStrings.Legacy.Tests;

[TestClass]
public class CommonTitlesFormatterTests
{
    [TestMethod]
    public void EntityCount_WithEntityName_ReturnsFormattedString()
    {
        string result = CommonTitlesFormatter.EntityCount("Items");
        AreEqual("Number of Items", result);
    }

    [TestMethod]
    public void EntityCount_WithSingleCharacter_ReturnsFormattedString()
    {
        string result = CommonTitlesFormatter.EntityCount("X");
        AreEqual("Number of X", result);
    }

    [TestMethod]
    public void EntityCount_WithLongEntityName_ReturnsFormattedString()
    {
        string result = CommonTitlesFormatter.EntityCount("VeryLongEntityNameForTesting");
        AreEqual("Number of VeryLongEntityNameForTesting", result);
    }

    [TestMethod]
    public void EntityCount_WithEmptyString_ReturnsFormattedString()
    {
        string result = CommonTitlesFormatter.EntityCount("");
        AreEqual("Number of ", result);
    }

    [TestMethod]
    public void EntityCount_WithNull_ReturnsFormattedString()
    {
        string result = CommonTitlesFormatter.EntityCount(null);
        AreEqual("Number of ", result);
    }
}
