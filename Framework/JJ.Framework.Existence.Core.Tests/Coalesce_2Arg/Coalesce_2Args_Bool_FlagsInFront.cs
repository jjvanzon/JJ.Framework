namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Bool_FlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_Bool_StaticZeroMattersFlagsInBack()
    {
        NoNullRet(false, Coalesce(zeroMatters: false, NullyFalse, NullBool  ));
        NoNullRet(false, Coalesce(             false, NullyFalse, NullBool  ));
        NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullBool  ));
        NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullBool  ));
      //NoNullRet(false, Coalesce(             true,  NullyFalse, NullBool  )); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(             false, NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullBool  ));
        NoNullRet(false, Coalesce(zeroMatters: false, False,      NullBool  ));
        NoNullRet(false, Coalesce(             false, False,      NullBool  ));
        NoNullRet(false, Coalesce(zeroMatters,        False,      NullBool  ));
        NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullBool  ));
      //NoNullRet(false, Coalesce(             true,  False,      NullBool  )); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullBool  ));
        NoNullRet(true,  Coalesce(             false, True,       NullBool  ));
        NoNullRet(true,  Coalesce(zeroMatters,        True,       NullBool  ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullBool  ));
        NoNullRet(true,  Coalesce(             true,  True,       NullBool  ));
        NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   NullyFalse));
        NoNullRet(false, Coalesce(             false, NullBool,   NullyFalse));
        NoNullRet(false, Coalesce(zeroMatters,        NullBool,   NullyFalse));
        NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   NullyFalse));
      //NoNullRet(false, Coalesce(             true,  NullBool,   NullyFalse)); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(             false, NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullyFalse));
        NoNullRet(false, Coalesce(zeroMatters: false, False,      NullyFalse));
        NoNullRet(false, Coalesce(             false, False,      NullyFalse));
        NoNullRet(false, Coalesce(zeroMatters,        False,      NullyFalse));
        NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyFalse));
      //NoNullRet(false, Coalesce(             true,  False,      NullyFalse)); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyFalse));
        NoNullRet(true,  Coalesce(             false, True,       NullyFalse));
        NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyFalse));
        NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyFalse));
        NoNullRet(true,  Coalesce(             true,  True,       NullyFalse));
        NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(             false, NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(             true,  NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullyTrue ));
        NoNullRet(true,  Coalesce(             false, NullyFalse, NullyTrue ));
        NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullyTrue ));
        NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullyTrue ));
      //NoNullRet(false, Coalesce(             true,  NullyFalse, NullyTrue )); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyTrue ));
        NoNullRet(true,  Coalesce(             false, False,      NullyTrue ));
        NoNullRet(false, Coalesce(zeroMatters,        False,      NullyTrue ));
        NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyTrue ));
      //NoNullRet(false, Coalesce(             true,  False,      NullyTrue )); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyTrue ));
        NoNullRet(true,  Coalesce(             false, True,       NullyTrue ));
        NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyTrue ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyTrue ));
        NoNullRet(true,  Coalesce(             true,  True,       NullyTrue ));
        NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   False     ));
        NoNullRet(false, Coalesce(             false, NullBool,   False     ));
        NoNullRet(false, Coalesce(zeroMatters,        NullBool,   False     ));
        NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   False     ));
      //NoNullRet(false, Coalesce(             true,  NullBool,   False     )); // Not a flag
        NoNullRet(false, Coalesce(zeroMatters: false, NullyFalse, False     ));
        NoNullRet(false, Coalesce(             false, NullyFalse, False     ));
        NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, False     ));
        NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, False     ));
      //NoNullRet(false, Coalesce(             true,  NullyFalse, False     )); // Not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(             false, NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(             true,  NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(zeroMatters: false, True,       False     ));
        NoNullRet(true,  Coalesce(             false, True,       False     ));
        NoNullRet(true,  Coalesce(zeroMatters,        True,       False     ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  True,       False     ));
        NoNullRet(true,  Coalesce(             true,  True,       False     ));
        NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   True      ));
        NoNullRet(true,  Coalesce(             false, NullBool,   True      ));
        NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   True      ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   True      ));
        NoNullRet(true,  Coalesce(             true,  NullBool,   True      ));
        NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, True      ));
        NoNullRet(true,  Coalesce(             false, NullyFalse, True      ));
        NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, True      ));
        NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, True      ));
      //NoNullRet(false, Coalesce(             true,  NullyFalse, True      )); // not a flag
        NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(             false, NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(             true,  NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(zeroMatters: false, False,      True      ));
        NoNullRet(true,  Coalesce(             false, False,      True      ));
        NoNullRet(false, Coalesce(zeroMatters,        False,      True      ));
        NoNullRet(false, Coalesce(zeroMatters: true,  False,      True      ));
      //NoNullRet(false, Coalesce(             true,  False,      True      )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_ExtensionsZeroMattersFlagsInBack()
    {
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(             false, NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullBool  ));
      //NoNullRet(false, NullyFalse.Coalesce(             true,  NullBool  )); // Not a flag
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, NullBool  ));
        NoNullRet(false, False     .Coalesce(             false, NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullBool  ));
      //NoNullRet(false, False     .Coalesce(             true,  NullBool  )); // Not a flag
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullBool  ));
        NoNullRet(true,  True      .Coalesce(             false, NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(             true,  NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(             false, NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  NullyFalse));
      //NoNullRet(false, NullBool  .Coalesce(             true,  NullyFalse)); // Not a flag
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, NullyFalse));
        NoNullRet(false, False     .Coalesce(             false, NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyFalse));
      //NoNullRet(false, False     .Coalesce(             true,  NullyFalse)); // Not a flag
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyFalse));
        NoNullRet(true,  True      .Coalesce(             false, NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(             true,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullyTrue ));
      //NoNullRet(false, NullyFalse.Coalesce(             true,  NullyTrue )); // Not a flag
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyTrue ));
        NoNullRet(true,  False     .Coalesce(             false, NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyTrue ));
      //NoNullRet(false, False     .Coalesce(             true,  NullyTrue )); // Not a flag
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             false, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, False     ));
        NoNullRet(false, NullBool  .Coalesce(             false, False     ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        False     ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  False     ));
      //NoNullRet(false, NullBool  .Coalesce(             true,  False     )); // Not a flag
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, False     ));
        NoNullRet(false, NullyFalse.Coalesce(             false, False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  False     ));
      //NoNullRet(false, NullyFalse.Coalesce(             true,  False     )); // Not a flag
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, False     ));
        NoNullRet(true,  True      .Coalesce(             false, False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  False     ));
        NoNullRet(true,  True      .Coalesce(             true,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, True      ));
        NoNullRet(true,  NullBool  .Coalesce(             false, True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  True      ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  True      ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, True      ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  True      ));
      //NoNullRet(false, NullyFalse.Coalesce(             true,  True      )); // Not a flag
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  True      ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, True      ));
        NoNullRet(true,  False     .Coalesce(             false, True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  True      ));
      //NoNullRet(false, False     .Coalesce(             true,  True      )); // Not a flag
    }

    // Bool to Text

    [TestMethod]
    public void Coalesce_2Args_BoolToText_ZeroMattersNoNulliesFlagsInBack()
    {
        NoNullRet("",                    Coalesce(zeroMatters: false, False,      NullText ));
        NoNullRet("",                    Coalesce(             false, False,      NullText ));
        NoNullRet("False",               Coalesce(zeroMatters,        False,      NullText ));
        NoNullRet("False",               Coalesce(zeroMatters: true,  False,      NullText ));
      //NoNullRet("False",               Coalesce(             true,  False,      NullText )); // Not a flag
        NoNullRet("peekaboo",            Coalesce(zeroMatters: false, False,     "peekaboo"));
        NoNullRet("peekaboo",            Coalesce(             false, False,     "peekaboo"));
        NoNullRet("False",               Coalesce(zeroMatters,        False,     "peekaboo"));
        NoNullRet("False",               Coalesce(zeroMatters: true,  False,     "peekaboo"));
      //NoNullRet("False",               Coalesce(             true,  False,     "peekaboo")); // Not a flag
        NoNullRet("True",                Coalesce(zeroMatters: false, True,       NullText ));
        NoNullRet("True",                Coalesce(             false, True,       NullText ));
        NoNullRet("True",                Coalesce(zeroMatters,        True,       NullText ));
        NoNullRet("True",                Coalesce(zeroMatters: true,  True,       NullText ));
        NoNullRet("True",                Coalesce(             true,  True,       NullText ));
        NoNullRet("True",                Coalesce(zeroMatters: false, True,      "peekaboo"));
        NoNullRet("True",                Coalesce(             false, True,      "peekaboo"));
        NoNullRet("True",                Coalesce(zeroMatters,        True,      "peekaboo"));
        NoNullRet("True",                Coalesce(zeroMatters: true,  True,      "peekaboo"));
        NoNullRet("True",                Coalesce(             true,  True,      "peekaboo"));
        NoNullRet("",         False     .Coalesce(zeroMatters: false,             NullText ));
        NoNullRet("",         False     .Coalesce(             false,             NullText ));
        NoNullRet("False",    False     .Coalesce(zeroMatters,                    NullText ));
        NoNullRet("False",    False     .Coalesce(zeroMatters: true,              NullText ));
      //NoNullRet("False",    False     .Coalesce(             true,              NullText )); // Not a flag
        NoNullRet("peekaboo", False     .Coalesce(zeroMatters: false,            "peekaboo"));
        NoNullRet("peekaboo", False     .Coalesce(             false,            "peekaboo"));
        NoNullRet("False",    False     .Coalesce(zeroMatters,                   "peekaboo"));
        NoNullRet("False",    False     .Coalesce(zeroMatters: true,             "peekaboo"));
      //NoNullRet("False",    False     .Coalesce(             true,             "peekaboo")); // Not a flag
        NoNullRet("True",     True      .Coalesce(zeroMatters: false,             NullText ));
        NoNullRet("True",     True      .Coalesce(             false,             NullText ));
        NoNullRet("True",     True      .Coalesce(zeroMatters,                    NullText ));
        NoNullRet("True",     True      .Coalesce(zeroMatters: true,              NullText ));
        NoNullRet("True",     True      .Coalesce(             true,              NullText ));
        NoNullRet("True",     True      .Coalesce(zeroMatters: false,            "peekaboo"));
        NoNullRet("True",     True      .Coalesce(             false,            "peekaboo"));
        NoNullRet("True",     True      .Coalesce(zeroMatters,                   "peekaboo"));
        NoNullRet("True",     True      .Coalesce(zeroMatters: true,             "peekaboo"));
        NoNullRet("True",     True      .Coalesce(             true,             "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_BoolToText_ZeroMattersWithNulliesFlagsInBack()
    {                      
        NoNullRet("",                    Coalesce(zeroMatters: false, NullBool,    NullText));
        NoNullRet("",                    Coalesce(             false, NullBool,    NullText));
        NoNullRet("",                    Coalesce(zeroMatters,        NullBool,    NullText));
        NoNullRet("",                    Coalesce(zeroMatters: true,  NullBool,    NullText));
      //NoNullRet("",                    Coalesce(             true,  NullBool,    NullText)); // Not a flag
        NoNullRet("boo",                 Coalesce(zeroMatters: false, NullBool,   "boo"    ));
        NoNullRet("boo",                 Coalesce(             false, NullBool,   "boo"    ));
        NoNullRet("boo",                 Coalesce(zeroMatters,        NullBool,   "boo"    ));
        NoNullRet("boo",                 Coalesce(zeroMatters: true,  NullBool,   "boo"    ));
      //NoNullRet("boo",                 Coalesce(             true,  NullBool,   "boo"    )); // Not a flag
        NoNullRet("",                    Coalesce(zeroMatters: false, NullyFalse,  NullText));
        NoNullRet("",                    Coalesce(             false, NullyFalse,  NullText));
        NoNullRet("False",               Coalesce(zeroMatters,        NullyFalse,  NullText));
        NoNullRet("False",               Coalesce(zeroMatters: true,  NullyFalse,  NullText));
      //NoNullRet("False",               Coalesce(             true,  NullyFalse,  NullText)); // Not a flag
        NoNullRet("boo",                 Coalesce(zeroMatters: false, NullyFalse, "boo"    ));
        NoNullRet("boo",                 Coalesce(             false, NullyFalse, "boo"    ));
        NoNullRet("False",               Coalesce(zeroMatters,        NullyFalse, "boo"    ));
        NoNullRet("False",               Coalesce(zeroMatters: true,  NullyFalse, "boo"    ));
      //NoNullRet("False",               Coalesce(             true,  NullyFalse, "boo"    )); // Not a flag
        NoNullRet("True",                Coalesce(zeroMatters: false, NullyTrue,   NullText));
        NoNullRet("True",                Coalesce(             false, NullyTrue,   NullText));
        NoNullRet("True",                Coalesce(zeroMatters,        NullyTrue,   NullText));
        NoNullRet("True",                Coalesce(zeroMatters: true,  NullyTrue,   NullText));
        NoNullRet("True",                Coalesce(             true,  NullyTrue,   NullText));
        NoNullRet("True",                Coalesce(zeroMatters: false, NullyTrue,  "boo"    ));
        NoNullRet("True",                Coalesce(             false, NullyTrue,  "boo"    ));
        NoNullRet("True",                Coalesce(zeroMatters,        NullyTrue,  "boo"    ));
        NoNullRet("True",                Coalesce(zeroMatters: true,  NullyTrue,  "boo"    ));
        NoNullRet("True",                Coalesce(             true,  NullyTrue,  "boo"    ));
        NoNullRet("",         NullBool  .Coalesce(zeroMatters: false,              NullText));
        NoNullRet("",         NullBool  .Coalesce(             false,              NullText));
        NoNullRet("",         NullBool  .Coalesce(zeroMatters,                     NullText));
        NoNullRet("",         NullBool  .Coalesce(zeroMatters: true,               NullText));
      //NoNullRet("",         NullBool  .Coalesce(             true,               NullText)); // Not a flag
        NoNullRet("boo",      NullBool  .Coalesce(zeroMatters: false,             "boo"    ));
        NoNullRet("boo",      NullBool  .Coalesce(             false,             "boo"    ));
        NoNullRet("boo",      NullBool  .Coalesce(zeroMatters,                    "boo"    ));
        NoNullRet("boo",      NullBool  .Coalesce(zeroMatters: true,              "boo"    ));
      //NoNullRet("boo",      NullBool  .Coalesce(             true,              "boo"    )); // Not a flag
        NoNullRet("",         NullyFalse.Coalesce(zeroMatters: false,              NullText));
        NoNullRet("",         NullyFalse.Coalesce(             false,              NullText));
        NoNullRet("False",    NullyFalse.Coalesce(zeroMatters,                     NullText));
        NoNullRet("False",    NullyFalse.Coalesce(zeroMatters: true,               NullText));
      //NoNullRet("False",    NullyFalse.Coalesce(             true,               NullText)); // Not a flag
        NoNullRet("boo",      NullyFalse.Coalesce(zeroMatters: false,             "boo"    ));
        NoNullRet("boo",      NullyFalse.Coalesce(             false,             "boo"    ));
        NoNullRet("False",    NullyFalse.Coalesce(zeroMatters,                    "boo"    ));
        NoNullRet("False",    NullyFalse.Coalesce(zeroMatters: true,              "boo"    ));
      //NoNullRet("False",    NullyFalse.Coalesce(             true,              "boo"    )); // Not a flag
        NoNullRet("True",     NullyTrue .Coalesce(zeroMatters: false,              NullText));
        NoNullRet("True",     NullyTrue .Coalesce(             false,              NullText));
        NoNullRet("True",     NullyTrue .Coalesce(zeroMatters,                     NullText));
        NoNullRet("True",     NullyTrue .Coalesce(zeroMatters: true,               NullText));
        NoNullRet("True",     NullyTrue .Coalesce(             true,               NullText));
        NoNullRet("True",     NullyTrue .Coalesce(zeroMatters: false,             "boo"    ));
        NoNullRet("True",     NullyTrue .Coalesce(             false,             "boo"    ));
        NoNullRet("True",     NullyTrue .Coalesce(zeroMatters,                    "boo"    ));
        NoNullRet("True",     NullyTrue .Coalesce(zeroMatters: true,              "boo"    ));
        NoNullRet("True",     NullyTrue .Coalesce(             true,              "boo"    ));
    }
}