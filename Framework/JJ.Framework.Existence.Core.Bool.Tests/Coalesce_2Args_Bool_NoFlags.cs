namespace JJ.Framework.Existence.Core.Bool.Tests;

[TestClass]
public class Coalesce_2Args_Bool_NoFlags : TestBase
{
    // Bool

    [TestMethod]
    public void Coalesce_2Args_Bool_VerifyInputs()
    {
        // Assert input states
        IsNull   (       NullBool  );
        NullRet  (false, NullyFalse);
        NullRet  (true,  NullyTrue );
        NoNullRet(false, False     );
        NoNullRet(true,  True      );
        NoNullRet(       false     );
        NoNullRet(       true      );
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Static()
    {
        NoNullRet(false, Coalesce(NullBool,   NullBool  ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(false, Coalesce(False,      NullBool  ));
        NoNullRet(true,  Coalesce(True,       NullBool  ));
        NoNullRet(false, Coalesce(false,      NullBool  ));
        NoNullRet(true,  Coalesce(true,       NullBool  ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse));
        NoNullRet(false, Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(false, Coalesce(False,      NullyFalse));
        NoNullRet(true,  Coalesce(True,       NullyFalse));
        NoNullRet(false, Coalesce(false,      NullyFalse));
        NoNullRet(true,  Coalesce(true,       NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(False,      NullyTrue ));
        NoNullRet(true,  Coalesce(True,       NullyTrue ));
        NoNullRet(true,  Coalesce(false,      NullyTrue ));
        NoNullRet(true,  Coalesce(true,       NullyTrue ));
        NoNullRet(false, Coalesce(NullBool,   False     ));
        NoNullRet(false, Coalesce(NullyFalse, False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  False     ));
        NoNullRet(false, Coalesce(False,      False     ));
        NoNullRet(true,  Coalesce(True,       False     ));
        NoNullRet(false, Coalesce(false,      False     ));
        NoNullRet(true,  Coalesce(true,       False     ));
        NoNullRet(true,  Coalesce(NullBool,   True      ));
        NoNullRet(true,  Coalesce(NullyFalse, True      ));
        NoNullRet(true,  Coalesce(NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(False,      True      ));
        NoNullRet(true,  Coalesce(True,       True      ));
        NoNullRet(true,  Coalesce(false,      True      ));
        NoNullRet(true,  Coalesce(true,       True      ));
        NoNullRet(false, Coalesce(NullBool,   false     ));
        NoNullRet(false, Coalesce(NullyFalse, false     ));
        NoNullRet(true,  Coalesce(NullyTrue,  false     ));
        NoNullRet(false, Coalesce(False,      false     ));
        NoNullRet(true,  Coalesce(True,       false     ));
        NoNullRet(false, Coalesce(false,      false     ));
        NoNullRet(true,  Coalesce(true,       false     ));
        NoNullRet(true,  Coalesce(NullBool,   true      ));
        NoNullRet(true,  Coalesce(NullyFalse, true      ));
        NoNullRet(true,  Coalesce(NullyTrue,  true      ));
        NoNullRet(true,  Coalesce(False,      true      ));
        NoNullRet(true,  Coalesce(True,       true      ));
        NoNullRet(true,  Coalesce(false,      true      ));
        NoNullRet(true,  Coalesce(true,       true      ));
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Extensions()
    {
        NoNullRet(false, NullBool  .Coalesce( NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce( NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce( NullBool  ));
        NoNullRet(false, False     .Coalesce( NullBool  ));
        NoNullRet(true,  True      .Coalesce( NullBool  ));
        NoNullRet(false, false     .Coalesce( NullBool  ));
        NoNullRet(true,  true      .Coalesce( NullBool  ));
        NoNullRet(false, NullBool  .Coalesce( NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce( NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce( NullyFalse));
        NoNullRet(false, false     .Coalesce( NullyFalse));
        NoNullRet(true,  true      .Coalesce( NullyFalse));
        NoNullRet(false, False     .Coalesce( NullyFalse));
        NoNullRet(true,  True      .Coalesce( NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce( NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce( NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce( NullyTrue ));
        NoNullRet(true,  False     .Coalesce( NullyTrue ));
        NoNullRet(true,  True      .Coalesce( NullyTrue ));
        NoNullRet(true,  false     .Coalesce( NullyTrue ));
        NoNullRet(true,  true      .Coalesce( NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce( False     ));
        NoNullRet(false, NullyFalse.Coalesce( False     ));
        NoNullRet(true,  NullyTrue .Coalesce( False     ));
        NoNullRet(false, False     .Coalesce( False     ));
        NoNullRet(true,  True      .Coalesce( False     ));
        NoNullRet(false, false     .Coalesce( False     ));
        NoNullRet(true,  true      .Coalesce( False     ));
        NoNullRet(true,  NullBool  .Coalesce( True      ));
        NoNullRet(true,  NullyFalse.Coalesce( True      ));
        NoNullRet(true,  NullyTrue .Coalesce( True      ));
        NoNullRet(true,  False     .Coalesce( True      ));
        NoNullRet(true,  True      .Coalesce( True      ));
        NoNullRet(true,  false     .Coalesce( True      ));
        NoNullRet(true,  true      .Coalesce( True      ));
        NoNullRet(false, NullBool  .Coalesce( false     ));
        NoNullRet(false, NullyFalse.Coalesce( false     ));
        NoNullRet(true,  NullyTrue .Coalesce( false     ));
        NoNullRet(false, False     .Coalesce( false     ));
        NoNullRet(true,  True      .Coalesce( false     ));
        NoNullRet(false, false     .Coalesce( false     ));
        NoNullRet(true,  true      .Coalesce( false     ));
        NoNullRet(true,  NullBool  .Coalesce( true      ));
        NoNullRet(true,  NullyFalse.Coalesce( true      ));
        NoNullRet(true,  NullyTrue .Coalesce( true      ));
        NoNullRet(true,  False     .Coalesce( true      ));
        NoNullRet(true,  True      .Coalesce( true      ));
        NoNullRet(true,  false     .Coalesce( true      ));
        NoNullRet(true,  true      .Coalesce( true      ));
    }

    // Bools to Text

    [TestMethod]
    public void Coalesce_2Args_BoolToText_NoNullies()
    {
        NoNullRet("",           Coalesce(false,  NullText ));
        NoNullRet("peekaboo",   Coalesce(false, "peekaboo"));
        NoNullRet("",           false.Coalesce(  NullText ));
        NoNullRet("peekaboo",   false.Coalesce( "peekaboo"));
        NoNullRet("True",       true. Coalesce(  NullText ));
        NoNullRet("True",       true. Coalesce( "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_BoolToText_WithNullies()
    {
        NoNullRet("",     Coalesce(NullBool,   NullText ));
        NoNullRet("boo",  Coalesce(NullBool,   "boo"     ));
        NoNullRet("",     Coalesce(NullyFalse, NullText ));
        NoNullRet("boo",  Coalesce(NullyFalse, "boo"     ));
        NoNullRet("True", Coalesce(NullyTrue,  NullText ));
        NoNullRet("True", Coalesce(NullyTrue,  "boo"     ));
        NoNullRet("",     NullBool  .Coalesce( NullText ));
        NoNullRet("boo",  NullBool  .Coalesce( "boo"     ));
        NoNullRet("",     NullyFalse.Coalesce( NullText ));
        NoNullRet("boo",  NullyFalse.Coalesce( "boo"     ));
        NoNullRet("True", NullyTrue .Coalesce( NullText ));
        NoNullRet("True", NullyTrue .Coalesce( "boo"     ));
    }
}