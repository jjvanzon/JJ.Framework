#pragma warning disable IDE0002 // Simplify member access

namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class TextCore_Basics_Tests
{
    private static readonly string? Null = null;

    [TestMethod]
    public void Test_TextCore_Trim()
    {
        AreEqual(" Hello ", StringHelperCore.Trim("!? Hello !?!?",     "!?"));
        AreEqual(" Hello ",                  Trim("!? Hello !?!?",     "!?"));
        AreEqual(" Hello ",                       "!? Hello !?!?".Trim("!?"));
    }
    
    [TestMethod]
    public void Test_TextCore_Trim_Nullies()
    {
        AreEqual("",       Trim(null,     null!));
        AreEqual("",       Trim(null,     ""   ));
        AreEqual("",       Trim(null,     " "  ));
        AreEqual("",       Trim(null,     "  " ));
        AreEqual("",       Trim(null,     "!"  ));
        AreEqual("",       Trim(null,     "!?" ));
                                          
        AreEqual("",       Trim("",       null!));
        AreEqual("",       Trim("",       ""   ));
        AreEqual("",       Trim("",       " "  ));
        AreEqual("",       Trim("",       "  " ));
        AreEqual("",       Trim("",       "!"  ));
        AreEqual("",       Trim("",       "!?" ));
                                          
        AreEqual(" ",      Trim(" ",      null!));
        AreEqual(" ",      Trim(" ",      ""   ));
        AreEqual("",       Trim(" ",      " "  ));
        AreEqual(" ",      Trim(" ",      "  " ));
        AreEqual(" ",      Trim(" ",      "!"  ));
        AreEqual(" ",      Trim(" ",      "!?" ));

        AreEqual(" Hi ",   Trim(" Hi ",   null!));
        AreEqual(" Hi ",   Trim(" Hi ",   ""   ));
        AreEqual("Hi",     Trim(" Hi ",   " "  ));
        AreEqual(" Hi ",   Trim(" Hi ",   "  " ));

        AreEqual("  Hi  ", Trim("  Hi  ", null!));
        AreEqual("  Hi  ", Trim("  Hi  ", ""   ));
        AreEqual("Hi",     Trim("  Hi  ", " "  ));
        AreEqual("Hi",     Trim("  Hi  ", "  " ));
    }

    [TestMethod]
    public void Test_TextCore_Replace_CharWithString()
    {
        AreEqual("HeLaLaLaLao", StringHelperCore.Replace("Hello",        'l', "LaLa"));
        AreEqual("HeLaLaLaLao",                  Replace("Hello",        'l', "LaLa"));
        AreEqual("HeLaLaLaLao",                          "Hello".Replace('l', "LaLa"));
    }

    [TestMethod]
    public void Test_TextCore_Replace_CharWithString_Nullies()
    {
       AreEqual("",     Null.Replace('\0', Null!));
       AreEqual("",     Null.Replace('\0', ""   ));
       AreEqual("",     Null.Replace('\0', " "  ));
       AreEqual("",     Null.Replace('\0', "  " ));
       AreEqual("",     Null.Replace('\0', "AA" ));
       AreEqual("",     Null.Replace(' ',  Null!));
       AreEqual("",     Null.Replace(' ',  ""   ));
       AreEqual("",     Null.Replace(' ',  " "  ));
       AreEqual("",     Null.Replace(' ',  "  " ));
       AreEqual("",     Null.Replace(' ',  "AA" ));
       AreEqual("",     Null.Replace('A',  Null!));
       AreEqual("",     Null.Replace('A',  ""   ));
       AreEqual("",     Null.Replace('A',  " "  ));
       AreEqual("",     Null.Replace('A',  "  " ));
       AreEqual("",     Null.Replace('A',  "AA" ));

       AreEqual("",     ""  .Replace('\0', Null!));
       AreEqual("",     ""  .Replace('\0', ""   ));
       AreEqual("",     ""  .Replace('\0', " "  ));
       AreEqual("",     ""  .Replace('\0', "  " ));
       AreEqual("",     ""  .Replace('\0', "AA" ));
       AreEqual("",     ""  .Replace(' ',  Null!));
       AreEqual("",     ""  .Replace(' ',  ""   ));
       AreEqual("",     ""  .Replace(' ',  " "  ));
       AreEqual("",     ""  .Replace(' ',  "  " ));
       AreEqual("",     ""  .Replace(' ',  "AA" ));
       AreEqual("",     ""  .Replace('A',  Null!));
       AreEqual("",     ""  .Replace('A',  ""   ));
       AreEqual("",     ""  .Replace('A',  " "  ));
       AreEqual("",     ""  .Replace('A',  "  " ));
       AreEqual("",     ""  .Replace('A',  "AA" ));
       
       AreEqual(" ",    " " .Replace('\0', Null!));
       AreEqual(" ",    " " .Replace('\0', ""   ));
       AreEqual(" ",    " " .Replace('\0', " "  ));
       AreEqual(" ",    " " .Replace('\0', "  " ));
       AreEqual(" ",    " " .Replace('\0', "AA" ));
       AreEqual("",     " " .Replace(' ',  Null!));
       AreEqual("",     " " .Replace(' ',  ""   ));
       AreEqual(" ",    " " .Replace(' ',  " "  ));
       AreEqual("  ",   " " .Replace(' ',  "  " ));
       AreEqual("AA",   " " .Replace(' ',  "AA" ));
       AreEqual(" ",    " " .Replace('A',  Null!));
       AreEqual(" ",    " " .Replace('A',  ""   ));
       AreEqual(" ",    " " .Replace('A',  " "  ));
       AreEqual(" ",    " " .Replace('A',  "  " ));
       AreEqual(" ",    " " .Replace('A',  "AA" ));

       AreEqual("AA",   "AA".Replace('\0', Null!));
       AreEqual("AA",   "AA".Replace('\0', ""   ));
       AreEqual("AA",   "AA".Replace('\0', " "  ));
       AreEqual("AA",   "AA".Replace('\0', "  " ));
       AreEqual("AA",   "AA".Replace('\0', "AA" ));
       AreEqual("AA",   "AA".Replace(' ',  Null!));
       AreEqual("AA",   "AA".Replace(' ',  ""   ));
       AreEqual("AA",   "AA".Replace(' ',  " "  ));
       AreEqual("AA",   "AA".Replace(' ',  "  " ));
       AreEqual("AA",   "AA".Replace(' ',  "AA" ));
       AreEqual("",     "AA".Replace('A',  Null!));
       AreEqual("",     "AA".Replace('A',  ""   ));
       AreEqual("  ",   "AA".Replace('A',  " "  ));
       AreEqual("    ", "AA".Replace('A',  "  " ));
       AreEqual("AAAA", "AA".Replace('A',  "AA" ));
    }

    // TODO: Test nullies

    [TestMethod]
    public void Test_TextCore_Replace_StringWithChar()
    {
        AreEqual("He*o", StringHelperCore.Replace("Hello",        "ll", '*'));
        AreEqual("He*o",                  Replace("Hello",        "ll", '*'));
        AreEqual("He*o",                          "Hello".Replace("ll", '*'));
    }

    
}