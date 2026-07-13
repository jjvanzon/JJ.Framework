namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringExtensionsCore_Tests
{
    [TestMethod]
    public void Test_StringExtensionsCore_StartsWithBlankLine() 
        => IsTrue("\nHello".StartsWithBlankLine());

    [TestMethod]
    public void Test_StringExtensionsCore_EndsWithBlankLine() 
        => IsTrue("Hello\n".EndsWithBlankLine());

    [TestMethod]
    public void Test_StringExtensionsCore_RemoveAccents() 
        => AreEqual("cafe", "café".RemoveAccents());
}
