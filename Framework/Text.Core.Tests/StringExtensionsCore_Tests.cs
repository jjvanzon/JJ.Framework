namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringExtensionsCore_Tests
{
    [TestMethod]
    public void StartsWithBlankLine_WithBlankLineAtStart_ReturnsTrue()
    {
        string text = "\nHello";
        bool result = text.StartsWithBlankLine();
        IsTrue(result);
    }

    [TestMethod]
    public void EndsWithBlankLine_WithBlankLineAtEnd_ReturnsTrue()
    {
        string text = "Hello\n";
        bool result = text.EndsWithBlankLine();
        IsTrue(result);
    }

    [TestMethod]
    public void RemoveAccents_WithAccentedCharacters_ReturnsUnaccentedString()
    {
        string input = "café";
        string result = input.RemoveAccents();
        AreEqual("cafe", result);
    }

    [TestMethod]
    public void RemoveAccents_WithNull_ReturnsEmptyString()
    {
        string? input = null;
        string result = input.RemoveAccents();
        AreEqual("", result);
    }
}
