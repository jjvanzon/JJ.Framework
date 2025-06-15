namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Is_Tests
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
        IsTrue(Is("test",   "test", matchCase: false));
        IsTrue(   "test".Is("test"));
        IsTrue(   "test".Is("test", matchCase: false));
        IsTrue(Is("test",   "TEST"));
        IsTrue(Is("test",   "TEST", matchCase: false));
        IsTrue(   "test".Is("TEST"));
        IsTrue(   "test".Is("TEST", matchCase: false));
        IsTrue(Is("TEST",   "test"));
        IsTrue(Is("TEST",   "test", matchCase: false));
        IsTrue(   "TEST".Is("test"));
        IsTrue(   "TEST".Is("test", matchCase: false));
        
        // Bunch of white space and case mismatch
        IsTrue(Is("test",   "\r\n \t TEST  \n"));
        IsTrue(Is("test",   "\r\n \t TEST  \n", matchCase: false));
        IsTrue(   "test".Is("\r\n \t TEST  \n"));
        IsTrue(   "test".Is("\r\n \t TEST  \n", matchCase: false));
        IsTrue(Is("\r\n \t TEST  \n",   "test"));
        IsTrue(Is("\r\n \t TEST  \n",   "test", matchCase: false));
        IsTrue(   "\r\n \t TEST  \n".Is("test"));
        IsTrue(   "\r\n \t TEST  \n".Is("test", matchCase: false));
        
        // Excess white space
        string a = "I am a STRING .  ";
        string b = "   i am a string    . \t";
        IsTrue(a.Is(b));
        IsTrue(a.Is(b,  matchCase: false));
        IsTrue(Is(a, b));
        IsTrue(Is(a, b, matchCase: false));
        
        // Case-sensitive
        IsFalse("TEST".Is("test", matchCase: true));
        IsFalse(Is("test", "Test", matchCase: true));

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