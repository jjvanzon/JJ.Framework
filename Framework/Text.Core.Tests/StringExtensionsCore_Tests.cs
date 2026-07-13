namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringExtensionsCore_Tests
{
    [TestMethod]
    public void Test_StringExtensionsCore_StartsWithBlankLine()
    {
        const string text = "\nHello";
        bool result = text.StartsWithBlankLine();
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringExtensionsCore_EndsWithBlankLine()
    {
        const string text = "Hello\n";
        bool result = text.EndsWithBlankLine();
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringExtensionsCore_RemoveAccents()
    {
        const string input = "café";
        string result = input.RemoveAccents();
        AreEqual("cafe", result);
    }
}
