namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Bool_FlagsInBack : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_Bool_StaticZeroMattersFlagsInBack()
    {
        NoNullRet(false, Coalesce( NullyFalse, NullBool,   zeroMatters: false));
        NoNullRet(false, Coalesce( NullyFalse, NullBool,                false));
        NoNullRet(false, Coalesce( NullyFalse, NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce( NullyFalse, NullBool,   zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullyFalse, NullBool,                true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( NullyTrue,  NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyTrue,  NullBool,                false));
        NoNullRet(true,  Coalesce( NullyTrue,  NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce( NullyTrue,  NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullyTrue,  NullBool,                true ));
        NoNullRet(false, Coalesce( False,      NullBool,   zeroMatters: false));
        NoNullRet(false, Coalesce( False,      NullBool,                false));
        NoNullRet(false, Coalesce( False,      NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce( False,      NullBool,   zeroMatters: true ));
      //NoNullRet(false, Coalesce( False,      NullBool,                true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( True,       NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce( True,       NullBool,                false));
        NoNullRet(true,  Coalesce( True,       NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce( True,       NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce( True,       NullBool,                true ));
        NoNullRet(false, Coalesce( NullBool,   NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce( NullBool,   NullyFalse,              false));
        NoNullRet(false, Coalesce( NullBool,   NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce( NullBool,   NullyFalse, zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullBool,   NullyFalse,              true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( NullyTrue,  NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyTrue,  NullyFalse,              false));
        NoNullRet(true,  Coalesce( NullyTrue,  NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce( NullyTrue,  NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullyTrue,  NullyFalse,              true ));
        NoNullRet(false, Coalesce( False,      NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce( False,      NullyFalse,              false));
        NoNullRet(false, Coalesce( False,      NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce( False,      NullyFalse, zeroMatters: true ));
      //NoNullRet(false, Coalesce( False,      NullyFalse,              true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( True,       NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce( True,       NullyFalse,              false));
        NoNullRet(true,  Coalesce( True,       NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce( True,       NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce( True,       NullyFalse,              true ));
        NoNullRet(true,  Coalesce( NullBool,   NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce( NullBool,   NullyTrue,               false));
        NoNullRet(true,  Coalesce( NullBool,   NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce( NullBool,   NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullBool,   NullyTrue,               true ));
        NoNullRet(true,  Coalesce( NullyFalse, NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyFalse, NullyTrue,               false));
        NoNullRet(false, Coalesce( NullyFalse, NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce( NullyFalse, NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullyFalse, NullyTrue,               true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( False,      NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce( False,      NullyTrue,               false));
        NoNullRet(false, Coalesce( False,      NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce( False,      NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, Coalesce( False,      NullyTrue,               true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( True,       NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce( True,       NullyTrue,               false));
        NoNullRet(true,  Coalesce( True,       NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce( True,       NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce( True,       NullyTrue,               true ));
        NoNullRet(false, Coalesce( NullBool,   False,      zeroMatters: false));
        NoNullRet(false, Coalesce( NullBool,   False,                   false));
        NoNullRet(false, Coalesce( NullBool,   False,      zeroMatters       ));
        NoNullRet(false, Coalesce( NullBool,   False,      zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullBool,   False,                   true )); // TODO: Does not work
        NoNullRet(false, Coalesce( NullyFalse, False,      zeroMatters: false));
        NoNullRet(false, Coalesce( NullyFalse, False,                   false));
        NoNullRet(false, Coalesce( NullyFalse, False,      zeroMatters       ));
        NoNullRet(false, Coalesce( NullyFalse, False,      zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullyFalse, False,                   true )); // TODO: does not work
        NoNullRet(true,  Coalesce( NullyTrue,  False,      zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyTrue,  False,                   false));
        NoNullRet(true,  Coalesce( NullyTrue,  False,      zeroMatters       ));
        NoNullRet(true,  Coalesce( NullyTrue,  False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullyTrue,  False,                   true ));
        NoNullRet(true,  Coalesce( True,       False,      zeroMatters: false));
        NoNullRet(true,  Coalesce( True,       False,                   false));
        NoNullRet(true,  Coalesce( True,       False,      zeroMatters       ));
        NoNullRet(true,  Coalesce( True,       False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce( True,       False,                   true ));
        NoNullRet(true,  Coalesce( NullBool,   True,       zeroMatters: false));
        NoNullRet(true,  Coalesce( NullBool,   True,                    false));
        NoNullRet(true,  Coalesce( NullBool,   True,       zeroMatters       ));
        NoNullRet(true,  Coalesce( NullBool,   True,       zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullBool,   True,                    true ));
        NoNullRet(true,  Coalesce( NullyFalse, True,       zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyFalse, True,                    false));
        NoNullRet(false, Coalesce( NullyFalse, True,       zeroMatters       ));
        NoNullRet(false, Coalesce( NullyFalse, True,       zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullyFalse, True,                    true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( NullyTrue,  True,       zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyTrue,  True,                    false));
        NoNullRet(true,  Coalesce( NullyTrue,  True,       zeroMatters       ));
        NoNullRet(true,  Coalesce( NullyTrue,  True,       zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullyTrue,  True,                    true ));
        NoNullRet(true,  Coalesce( False,      True,       zeroMatters: false));
        NoNullRet(true,  Coalesce( False,      True,                    false));
        NoNullRet(false, Coalesce( False,      True,       zeroMatters       ));
        NoNullRet(false, Coalesce( False,      True,       zeroMatters: true ));
      //NoNullRet(false, Coalesce( False,      True,                    true )); // TODO: Does not work
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_ExtensionsZeroMattersFlagsInBack()
    {
        NoNullRet(false, NullyFalse.Coalesce(  NullBool,   zeroMatters: false));
        NoNullRet(false, NullyFalse.Coalesce(  NullBool,                false));
        NoNullRet(false, NullyFalse.Coalesce(  NullBool,   zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(  NullBool,   zeroMatters: true ));
      //NoNullRet(false, NullyFalse.Coalesce(  NullBool,                true )); // TODO: Does not work
        NoNullRet(true,  NullyTrue .Coalesce(  NullBool,   zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(  NullBool,                false));
        NoNullRet(true,  NullyTrue .Coalesce(  NullBool,   zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(  NullBool,   zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(  NullBool,                true ));
        NoNullRet(false, False     .Coalesce(  NullBool,   zeroMatters: false));
        NoNullRet(false, False     .Coalesce(  NullBool,                false));
        NoNullRet(false, False     .Coalesce(  NullBool,   zeroMatters       ));
        NoNullRet(false, False     .Coalesce(  NullBool,   zeroMatters: true ));
      //NoNullRet(false, False     .Coalesce(  NullBool,                true )); // TODO: Does not work
        NoNullRet(true,  True      .Coalesce(  NullBool,   zeroMatters: false));
        NoNullRet(true,  True      .Coalesce(  NullBool,                false));
        NoNullRet(true,  True      .Coalesce(  NullBool,   zeroMatters       ));
        NoNullRet(true,  True      .Coalesce(  NullBool,   zeroMatters: true ));
        NoNullRet(true,  True      .Coalesce(  NullBool,                true ));
        NoNullRet(false, NullBool  .Coalesce(  NullyFalse, zeroMatters: false));
        NoNullRet(false, NullBool  .Coalesce(  NullyFalse,              false));
        NoNullRet(false, NullBool  .Coalesce(  NullyFalse, zeroMatters       ));
        NoNullRet(false, NullBool  .Coalesce(  NullyFalse, zeroMatters: true ));
      //NoNullRet(false, NullBool  .Coalesce(  NullyFalse,              true )); // TODO: Does not work
        NoNullRet(true,  NullyTrue .Coalesce(  NullyFalse, zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(  NullyFalse,              false));
        NoNullRet(true,  NullyTrue .Coalesce(  NullyFalse, zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(  NullyFalse, zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(  NullyFalse,              true ));
        NoNullRet(false, False     .Coalesce(  NullyFalse, zeroMatters: false));
        NoNullRet(false, False     .Coalesce(  NullyFalse,              false));
        NoNullRet(false, False     .Coalesce(  NullyFalse, zeroMatters       ));
        NoNullRet(false, False     .Coalesce(  NullyFalse, zeroMatters: true ));
      //NoNullRet(false, False     .Coalesce(  NullyFalse,              true )); // TODO: Does not work
        NoNullRet(true,  True      .Coalesce(  NullyFalse, zeroMatters: false));
        NoNullRet(true,  True      .Coalesce(  NullyFalse,              false));
        NoNullRet(true,  True      .Coalesce(  NullyFalse, zeroMatters       ));
        NoNullRet(true,  True      .Coalesce(  NullyFalse, zeroMatters: true ));
        NoNullRet(true,  True      .Coalesce(  NullyFalse,              true ));
        NoNullRet(true,  NullBool  .Coalesce(  NullyTrue,  zeroMatters: false));
        NoNullRet(true,  NullBool  .Coalesce(  NullyTrue,               false));
        NoNullRet(true,  NullBool  .Coalesce(  NullyTrue,  zeroMatters       ));
        NoNullRet(true,  NullBool  .Coalesce(  NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  NullBool  .Coalesce(  NullyTrue,               true ));
        NoNullRet(true,  NullyFalse.Coalesce(  NullyTrue,  zeroMatters: false));
        NoNullRet(true,  NullyFalse.Coalesce(  NullyTrue,               false));
        NoNullRet(false, NullyFalse.Coalesce(  NullyTrue,  zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(  NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, NullyFalse.Coalesce(  NullyTrue,               true )); // TODO: Does not work
        NoNullRet(true,  False     .Coalesce(  NullyTrue,  zeroMatters: false));
        NoNullRet(true,  False     .Coalesce(  NullyTrue,               false));
        NoNullRet(false, False     .Coalesce(  NullyTrue,  zeroMatters       ));
        NoNullRet(false, False     .Coalesce(  NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, False     .Coalesce(  NullyTrue,               true )); // TODO: Does not work
        NoNullRet(true,  True      .Coalesce(  NullyTrue,  zeroMatters: false));
        NoNullRet(true,  True      .Coalesce(  NullyTrue,               false));
        NoNullRet(true,  True      .Coalesce(  NullyTrue,  zeroMatters       ));
        NoNullRet(true,  True      .Coalesce(  NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  True      .Coalesce(  NullyTrue,               true ));
        NoNullRet(false, NullBool  .Coalesce(  False,      zeroMatters: false));
        NoNullRet(false, NullBool  .Coalesce(  False,                   false));
        NoNullRet(false, NullBool  .Coalesce(  False,      zeroMatters       ));
        NoNullRet(false, NullBool  .Coalesce(  False,      zeroMatters: true ));
      //NoNullRet(false, NullBool  .Coalesce(  False,                   true )); // TODO: Does n work
        NoNullRet(false, NullyFalse.Coalesce(  False,      zeroMatters: false));
        NoNullRet(false, NullyFalse.Coalesce(  False,                   false));
        NoNullRet(false, NullyFalse.Coalesce(  False,      zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(  False,      zeroMatters: true ));
      //NoNullRet(false, NullyFalse.Coalesce(  False,                   true )); // TODO: Does not work
        NoNullRet(true,  NullyTrue .Coalesce(  False,      zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(  False,                   false));
        NoNullRet(true,  NullyTrue .Coalesce(  False,      zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(  False,      zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(  False,                   true ));
        NoNullRet(true,  True      .Coalesce(  False,      zeroMatters: false));
        NoNullRet(true,  True      .Coalesce(  False,                   false));
        NoNullRet(true,  True      .Coalesce(  False,      zeroMatters       ));
        NoNullRet(true,  True      .Coalesce(  False,      zeroMatters: true ));
        NoNullRet(true,  True      .Coalesce(  False,                   true ));
        NoNullRet(true,  NullBool  .Coalesce(  True,       zeroMatters: false));
        NoNullRet(true,  NullBool  .Coalesce(  True,                    false));
        NoNullRet(true,  NullBool  .Coalesce(  True,       zeroMatters       ));
        NoNullRet(true,  NullBool  .Coalesce(  True,       zeroMatters: true ));
        NoNullRet(true,  NullBool  .Coalesce(  True,                    true ));
        NoNullRet(true,  NullyFalse.Coalesce(  True,       zeroMatters: false));
        NoNullRet(true,  NullyFalse.Coalesce(  True,                    false));
        NoNullRet(false, NullyFalse.Coalesce(  True,       zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(  True,       zeroMatters: true ));
      //NoNullRet(false, NullyFalse.Coalesce(  True,                    true )); // TODO: Does not work
        NoNullRet(true,  NullyTrue .Coalesce(  True,       zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(  True,                    false));
        NoNullRet(true,  NullyTrue .Coalesce(  True,       zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(  True,       zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(  True,                    true ));
        NoNullRet(true,  False     .Coalesce(  True,       zeroMatters: false));
        NoNullRet(true,  False     .Coalesce(  True,                    false));
        NoNullRet(false, False     .Coalesce(  True,       zeroMatters       ));
        NoNullRet(false, False     .Coalesce(  True,       zeroMatters: true ));
      //NoNullRet(false, False     .Coalesce(  True,                    true )); // TODO: Does not work
    }                                                    

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_BoolToText_ZeroMattersNoNulliesFlagsInBack()
    {
        NoNullRet("",         Coalesce(False,     NullText,  zeroMatters: false));
        NoNullRet("",         Coalesce(False,     NullText,               false));
        NoNullRet("False",    Coalesce(False,     NullText,  zeroMatters       ));
        NoNullRet("False",    Coalesce(False,     NullText,  zeroMatters: true ));
        NoNullRet("False",    Coalesce(False,     NullText,               true ));
        NoNullRet("peekaboo", Coalesce(False,    "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo", Coalesce(False,    "peekaboo",              false));
        NoNullRet("False",    Coalesce(False,    "peekaboo", zeroMatters       ));
        NoNullRet("False",    Coalesce(False,    "peekaboo", zeroMatters: true ));
        NoNullRet("False",    Coalesce(False,    "peekaboo",              true ));
        NoNullRet("True",     Coalesce(True,      NullText,  zeroMatters: false));
        NoNullRet("True",     Coalesce(True,      NullText,               false));
        NoNullRet("True",     Coalesce(True,      NullText,  zeroMatters       ));
        NoNullRet("True",     Coalesce(True,      NullText,  zeroMatters: true ));
        NoNullRet("True",     Coalesce(True,      NullText,               true ));
        NoNullRet("True",     Coalesce(True,     "peekaboo", zeroMatters: false));
        NoNullRet("True",     Coalesce(True,     "peekaboo",              false));
        NoNullRet("True",     Coalesce(True,     "peekaboo", zeroMatters       ));
        NoNullRet("True",     Coalesce(True,     "peekaboo", zeroMatters: true ));
        NoNullRet("True",     Coalesce(True,     "peekaboo",              true ));
        NoNullRet("",         False   .Coalesce(  NullText,  zeroMatters: false));
        NoNullRet("",         False   .Coalesce(  NullText,               false));
        NoNullRet("False",    False   .Coalesce(  NullText,  zeroMatters       ));
        NoNullRet("False",    False   .Coalesce(  NullText,  zeroMatters: true ));
        NoNullRet("False",    False   .Coalesce(  NullText,               true ));
        NoNullRet("peekaboo", False   .Coalesce( "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo", False   .Coalesce( "peekaboo",              false));
        NoNullRet("False",    False   .Coalesce( "peekaboo", zeroMatters       ));
        NoNullRet("False",    False   .Coalesce( "peekaboo", zeroMatters: true ));
        NoNullRet("False",    False   .Coalesce( "peekaboo",              true ));
        NoNullRet("True",     True    .Coalesce(  NullText,  zeroMatters: false));
        NoNullRet("True",     True    .Coalesce(  NullText,               false));
        NoNullRet("True",     True    .Coalesce(  NullText,  zeroMatters       ));
        NoNullRet("True",     True    .Coalesce(  NullText,  zeroMatters: true ));
        NoNullRet("True",     True    .Coalesce(  NullText,               true ));
        NoNullRet("True",     True    .Coalesce( "peekaboo", zeroMatters: false));
        NoNullRet("True",     True    .Coalesce( "peekaboo",              false));
        NoNullRet("True",     True    .Coalesce( "peekaboo", zeroMatters       ));
        NoNullRet("True",     True    .Coalesce( "peekaboo", zeroMatters: true ));
        NoNullRet("True",     True    .Coalesce( "peekaboo",              true ));
    }

    [TestMethod]
    public void Coalesce_2Args_BoolToText_ZeroMattersWithNulliesFlagsInBack()
    {
        NoNullRet("",      Coalesce( NullBool,    NullText,  zeroMatters: false));
        NoNullRet("",      Coalesce( NullBool,    NullText,               false));
        NoNullRet("",      Coalesce( NullBool,    NullText,  zeroMatters       ));
        NoNullRet("",      Coalesce( NullBool,    NullText,  zeroMatters: true ));
        NoNullRet("",      Coalesce( NullBool,    NullText,               true ));
        NoNullRet("boo",   Coalesce( NullBool,   "boo",      zeroMatters: false));
        NoNullRet("boo",   Coalesce( NullBool,   "boo",                   false));
        NoNullRet("boo",   Coalesce( NullBool,   "boo",      zeroMatters       ));
        NoNullRet("boo",   Coalesce( NullBool,   "boo",      zeroMatters: true ));
        NoNullRet("boo",   Coalesce( NullBool,   "boo",                   true ));
        NoNullRet("",      Coalesce( NullyFalse,  NullText,  zeroMatters: false));
        NoNullRet("",      Coalesce( NullyFalse,  NullText,               false));
        NoNullRet("False", Coalesce( NullyFalse,  NullText,  zeroMatters       ));
        NoNullRet("False", Coalesce( NullyFalse,  NullText,  zeroMatters: true ));
        NoNullRet("False", Coalesce( NullyFalse,  NullText,               true ));
        NoNullRet("boo",   Coalesce( NullyFalse, "boo",      zeroMatters: false));
        NoNullRet("boo",   Coalesce( NullyFalse, "boo",                   false));
        NoNullRet("False", Coalesce( NullyFalse, "boo",      zeroMatters       ));
        NoNullRet("False", Coalesce( NullyFalse, "boo",      zeroMatters: true ));
        NoNullRet("False", Coalesce( NullyFalse, "boo",                   true ));
        NoNullRet("True",  Coalesce( NullyTrue,   NullText,  zeroMatters: false));
        NoNullRet("True",  Coalesce( NullyTrue,   NullText,               false));
        NoNullRet("True",  Coalesce( NullyTrue,   NullText,  zeroMatters       ));
        NoNullRet("True",  Coalesce( NullyTrue,   NullText,  zeroMatters: true ));
        NoNullRet("True",  Coalesce( NullyTrue,   NullText,               true ));
        NoNullRet("True",  Coalesce( NullyTrue,  "boo",      zeroMatters: false));
        NoNullRet("True",  Coalesce( NullyTrue,  "boo",                   false));
        NoNullRet("True",  Coalesce( NullyTrue,  "boo",      zeroMatters       ));
        NoNullRet("True",  Coalesce( NullyTrue,  "boo",      zeroMatters: true ));
        NoNullRet("True",  Coalesce( NullyTrue,  "boo",                   true ));
        NoNullRet("",      NullBool  .Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("",      NullBool  .Coalesce(   NullText,               false));
        NoNullRet("",      NullBool  .Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("",      NullBool  .Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("",      NullBool  .Coalesce(   NullText,               true ));
        NoNullRet("boo",   NullBool  .Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("boo",   NullBool  .Coalesce(  "boo",                   false));
        NoNullRet("boo",   NullBool  .Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("boo",   NullBool  .Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("boo",   NullBool  .Coalesce(  "boo",                   true ));
        NoNullRet("",      NullyFalse.Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("",      NullyFalse.Coalesce(   NullText,               false));
        NoNullRet("False", NullyFalse.Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("False", NullyFalse.Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("False", NullyFalse.Coalesce(   NullText,               true ));
        NoNullRet("boo",   NullyFalse.Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("boo",   NullyFalse.Coalesce(  "boo",                   false));
        NoNullRet("False", NullyFalse.Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("False", NullyFalse.Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("False", NullyFalse.Coalesce(  "boo",                   true ));
        NoNullRet("True",  NullyTrue .Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("True",  NullyTrue .Coalesce(   NullText,               false));
        NoNullRet("True",  NullyTrue .Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("True",  NullyTrue .Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("True",  NullyTrue .Coalesce(   NullText,               true ));
        NoNullRet("True",  NullyTrue .Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("True",  NullyTrue .Coalesce(  "boo",                   false));
        NoNullRet("True",  NullyTrue .Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("True",  NullyTrue .Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("True",  NullyTrue .Coalesce(  "boo",                   true ));
    }
}