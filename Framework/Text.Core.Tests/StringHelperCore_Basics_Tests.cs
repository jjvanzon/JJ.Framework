namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_Basics_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_Trim() 
        => AreEqual(" Hello ", "!? Hello !?!?".Trim("!?"));

    [TestMethod]
    public void Test_StringHelperCore_Replace_CharWithString() 
        => AreEqual("HeLaLaLaLao", Replace("Hello", 'l', "LaLa"));

    [TestMethod]
    public void Test_StringHelperCore_Replace_StringWithChar() 
        => AreEqual("He*o", Replace("Hello", "ll", '*'));
}