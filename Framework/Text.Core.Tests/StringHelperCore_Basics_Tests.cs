namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_Basics_Tests
{
    // Contains

    [TestMethod]
    public void Test_StringHelperCore_Contains_String_IgnoreCase() 
        => IsTrue("Hello World".Contains("WORLD", ignoreCase: true));

    [TestMethod]
    public void Test_StringHelperCore_Contains_String_IgnoreCaseFalse()
    {
        IsFalse("Hello World".Contains("WORLD", ignoreCase: false));
        IsTrue ("Hello World".Contains("World", ignoreCase: false));
    }

    [TestMethod]
    public void Test_StringHelperCore_Contains_String_DefaultIgnoreCaseFalse()
    {
        IsFalse("Hello World".Contains("WORLD"));
        IsTrue ("Hello World".Contains("World"));
    }

    // TODO: Test ignoreCase for Contains with (string, collection).

    [TestMethod]
    public void Test_StringHelperCore_Contains_StringCollection() 
        => IsTrue("The quick brown fox".Contains(["cat", "fox", "dog"]));

    [TestMethod]
    public void Test_StringHelperCore_Contains_CharCollection() 
        => IsTrue("Hello".Contains(['x', 'e', 'z']));
    
    // Other Basics

    [TestMethod]
    public void Test_StringHelperCore_BoolIgnoreCase_True_ToStringComparison()
    {
        const bool ignoreCaseTrue = true;
        AreEqual(OrdinalIgnoreCase, ignoreCaseTrue.ToStringComparison());
    }

    [TestMethod]
    public void Test_StringHelperCore_BoolIgnoreCase_False_ToStringComparison()
    {
        const bool ignoreCaseTrue = false;
        AreEqual(Ordinal, ignoreCaseTrue.ToStringComparison());
    }

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