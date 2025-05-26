namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsTests
{
    
    [TestMethod]
    public void Test_String_Is()

    {
        // NullOrWhiteSpace
        IsTrue(Is(NullText,   NullText));
        IsTrue(Is(" "     ,   NullText));
        IsTrue(   " "     .Is(NullText));
        IsTrue(Is(""      ,   " "     ));
        IsTrue(   ""      .Is(" "     ));
        IsTrue(Is(""      ,   "  \t"  ));
        IsTrue(   ""      .Is("  \t"  ));
        
        // Ignore Case
        IsTrue(Is("test",   "test"));
        IsTrue(Is("test",   "test", ignoreCase: true));
        IsTrue(   "test".Is("test"));
        IsTrue(   "test".Is("test", ignoreCase: true));
        IsTrue(Is("test",   "TEST"));
        IsTrue(Is("test",   "TEST", ignoreCase: true));
        IsTrue(   "test".Is("TEST"));
        IsTrue(   "test".Is("TEST", ignoreCase: true));
        IsTrue(Is("TEST",   "test"));
        IsTrue(Is("TEST",   "test", ignoreCase: true));
        IsTrue(   "TEST".Is("test"));
        IsTrue(   "TEST".Is("test", ignoreCase: true));
        
        // Bunch of white space and case mismatch
        IsTrue(Is("test",   "\r\n \t TEST  \n"));
        IsTrue(Is("test",   "\r\n \t TEST  \n", ignoreCase: true));
        IsTrue(   "test".Is("\r\n \t TEST  \n"));
        IsTrue(   "test".Is("\r\n \t TEST  \n", ignoreCase: true));
        IsTrue(Is("\r\n \t TEST  \n",   "test"));
        IsTrue(Is("\r\n \t TEST  \n",   "test", ignoreCase: true));
        IsTrue(   "\r\n \t TEST  \n".Is("test"));
        IsTrue(   "\r\n \t TEST  \n".Is("test", ignoreCase: true));
        
        // Excess white space
        string a = "I am a STRING .  ";
        string b = "   i am a string    . \t";
        IsTrue(a.Is(b));
        IsTrue(a.Is(b,  ignoreCase: true));
        IsTrue(Is(a, b));
        IsTrue(Is(a, b, ignoreCase: true));
        
        // Case sensitive
        IsFalse("TEST".Is("test", ignoreCase: false));
        IsFalse(Is("test", "Test", ignoreCase: false));

        // Negative match
        IsFalse("Plant".Is("Animal"));
        IsFalse(Is("Animal", "Plant"));

        // Diacritics
        string c = "   i ÂM ã string   . \t";
        IsTrue(a.Is(c));
        IsTrue(c.Is(a));
        IsTrue(Is(a, c));
        IsTrue(Is(c, a));
    }
}