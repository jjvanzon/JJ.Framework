namespace JJ.Framework.ResourceStrings.Legacy.Tests;

[TestClass]
public class CommonTitlesFormatterTests() 
    : ResourceStringTester(
        typeof(CommonTitlesFormatter),
        @default: "",
        known: ["en-US", "nl-NL"],
        unknown: "de-DE")
{
    
    [TestMethod]
    public void CommonTitlesFormatter_AllPublicStatics_ReturnText_ForKnownCultures() 
        => Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    
    [TestMethod]
    public void CommonTitlesFormatter_UnknownCulture_DefaultsToEnUS() 
        => Assert_UnknownCulture_UsesDefaultCulture();

    // TODO: Vary culture

    [TestMethod]
    public void CommonTitlesFormatter_EntityCount_WithEntityName_ReturnsFormattedString()
    {
        string result = CommonTitlesFormatter.EntityCount("Items");
        AreEqual("Number of Items", result);
    }

    [TestMethod]
    public void CommonTitlesFormatter_EntityCount_WithSingleCharacter_ReturnsFormattedString()
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
