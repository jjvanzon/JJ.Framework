namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Bool_FlagsInBack : TestBase
{
    // TODO: Add True and False variables as cases next to false and true keywords.

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
        NoNullRet(false, Coalesce( false,      NullBool,   zeroMatters: false));
        NoNullRet(false, Coalesce( false,      NullBool,                false));
        NoNullRet(false, Coalesce( false,      NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce( false,      NullBool,   zeroMatters: true ));
      //NoNullRet(false, Coalesce( false,      NullBool,                true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( true,       NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce( true,       NullBool,                false));
        NoNullRet(true,  Coalesce( true,       NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce( true,       NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce( true,       NullBool,                true ));
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
        NoNullRet(false, Coalesce( false,      NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce( false,      NullyFalse,              false));
        NoNullRet(false, Coalesce( false,      NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce( false,      NullyFalse, zeroMatters: true ));
      //NoNullRet(false, Coalesce( false,      NullyFalse,              true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( true,       NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce( true,       NullyFalse,              false));
        NoNullRet(true,  Coalesce( true,       NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce( true,       NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce( true,       NullyFalse,              true ));
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
        NoNullRet(true,  Coalesce( false,      NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce( false,      NullyTrue,               false));
        NoNullRet(false, Coalesce( false,      NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce( false,      NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, Coalesce( false,      NullyTrue,               true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( true,       NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce( true,       NullyTrue,               false));
        NoNullRet(true,  Coalesce( true,       NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce( true,       NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce( true,       NullyTrue,               true ));
        NoNullRet(false, Coalesce( NullBool,   false,      zeroMatters: false));
        NoNullRet(false, Coalesce( NullBool,   false,                   false));
        NoNullRet(false, Coalesce( NullBool,   false,      zeroMatters       ));
        NoNullRet(false, Coalesce( NullBool,   false,      zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullBool,   false,                   true )); // TODO: Does not work
        NoNullRet(false, Coalesce( NullyFalse, false,      zeroMatters: false));
        NoNullRet(false, Coalesce( NullyFalse, false,                   false));
        NoNullRet(false, Coalesce( NullyFalse, false,      zeroMatters       ));
        NoNullRet(false, Coalesce( NullyFalse, false,      zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullyFalse, false,                   true )); // TODO: does not work
        NoNullRet(true,  Coalesce( NullyTrue,  false,      zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyTrue,  false,                   false));
        NoNullRet(true,  Coalesce( NullyTrue,  false,      zeroMatters       ));
        NoNullRet(true,  Coalesce( NullyTrue,  false,      zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullyTrue,  false,                   true ));
        NoNullRet(true,  Coalesce( true,       false,      zeroMatters: false));
        NoNullRet(true,  Coalesce( true,       false,                   false));
        NoNullRet(true,  Coalesce( true,       false,      zeroMatters       ));
        NoNullRet(true,  Coalesce( true,       false,      zeroMatters: true ));
        NoNullRet(true,  Coalesce( true,       false,                   true ));
        NoNullRet(true,  Coalesce( NullBool,   true,       zeroMatters: false));
        NoNullRet(true,  Coalesce( NullBool,   true,                    false));
        NoNullRet(true,  Coalesce( NullBool,   true,       zeroMatters       ));
        NoNullRet(true,  Coalesce( NullBool,   true,       zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullBool,   true,                    true ));
        NoNullRet(true,  Coalesce( NullyFalse, true,       zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyFalse, true,                    false));
        NoNullRet(false, Coalesce( NullyFalse, true,       zeroMatters       ));
        NoNullRet(false, Coalesce( NullyFalse, true,       zeroMatters: true ));
      //NoNullRet(false, Coalesce( NullyFalse, true,                    true )); // TODO: Does not work
        NoNullRet(true,  Coalesce( NullyTrue,  true,       zeroMatters: false));
        NoNullRet(true,  Coalesce( NullyTrue,  true,                    false));
        NoNullRet(true,  Coalesce( NullyTrue,  true,       zeroMatters       ));
        NoNullRet(true,  Coalesce( NullyTrue,  true,       zeroMatters: true ));
        NoNullRet(true,  Coalesce( NullyTrue,  true,                    true ));
        NoNullRet(true,  Coalesce( false,      true,       zeroMatters: false));
        NoNullRet(true,  Coalesce( false,      true,                    false));
        NoNullRet(false, Coalesce( false,      true,       zeroMatters       ));
        NoNullRet(false, Coalesce( false,      true,       zeroMatters: true ));
      //NoNullRet(false, Coalesce( false,      true,                    true )); // TODO: Does not work
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
        NoNullRet(false, false     .Coalesce(  NullBool,   zeroMatters: false));
        NoNullRet(false, false     .Coalesce(  NullBool,                false));
        NoNullRet(false, false     .Coalesce(  NullBool,   zeroMatters       ));
        NoNullRet(false, false     .Coalesce(  NullBool,   zeroMatters: true ));
      //NoNullRet(false, false     .Coalesce(  NullBool,                true )); // TODO: Does not work
        NoNullRet(true,  true      .Coalesce(  NullBool,   zeroMatters: false));
        NoNullRet(true,  true      .Coalesce(  NullBool,                false));
        NoNullRet(true,  true      .Coalesce(  NullBool,   zeroMatters       ));
        NoNullRet(true,  true      .Coalesce(  NullBool,   zeroMatters: true ));
        NoNullRet(true,  true      .Coalesce(  NullBool,                true ));
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
        NoNullRet(false, false     .Coalesce(  NullyFalse, zeroMatters: false));
        NoNullRet(false, false     .Coalesce(  NullyFalse,              false));
        NoNullRet(false, false     .Coalesce(  NullyFalse, zeroMatters       ));
        NoNullRet(false, false     .Coalesce(  NullyFalse, zeroMatters: true ));
      //NoNullRet(false, false     .Coalesce(  NullyFalse,              true )); // TODO: Does not work
        NoNullRet(true,  true      .Coalesce(  NullyFalse, zeroMatters: false));
        NoNullRet(true,  true      .Coalesce(  NullyFalse,              false));
        NoNullRet(true,  true      .Coalesce(  NullyFalse, zeroMatters       ));
        NoNullRet(true,  true      .Coalesce(  NullyFalse, zeroMatters: true ));
        NoNullRet(true,  true      .Coalesce(  NullyFalse,              true ));
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
        NoNullRet(true,  false     .Coalesce(  NullyTrue,  zeroMatters: false));
        NoNullRet(true,  false     .Coalesce(  NullyTrue,               false));
        NoNullRet(false, false     .Coalesce(  NullyTrue,  zeroMatters       ));
        NoNullRet(false, false     .Coalesce(  NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, false     .Coalesce(  NullyTrue,               true )); // TODO: Does not work
        NoNullRet(true,  true      .Coalesce(  NullyTrue,  zeroMatters: false));
        NoNullRet(true,  true      .Coalesce(  NullyTrue,               false));
        NoNullRet(true,  true      .Coalesce(  NullyTrue,  zeroMatters       ));
        NoNullRet(true,  true      .Coalesce(  NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  true      .Coalesce(  NullyTrue,               true ));
        NoNullRet(false, NullBool  .Coalesce(  false,      zeroMatters: false));
        NoNullRet(false, NullBool  .Coalesce(  false,                   false));
        NoNullRet(false, NullBool  .Coalesce(  false,      zeroMatters       ));
        NoNullRet(false, NullBool  .Coalesce(  false,      zeroMatters: true ));
      //NoNullRet(false, NullBool  .Coalesce(  false,                   true )); // TODO: Does n work
        NoNullRet(false, NullyFalse.Coalesce(  false,      zeroMatters: false));
        NoNullRet(false, NullyFalse.Coalesce(  false,                   false));
        NoNullRet(false, NullyFalse.Coalesce(  false,      zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(  false,      zeroMatters: true ));
      //NoNullRet(false, NullyFalse.Coalesce(  false,                   true )); // TODO: Does not work
        NoNullRet(true,  NullyTrue .Coalesce(  false,      zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(  false,                   false));
        NoNullRet(true,  NullyTrue .Coalesce(  false,      zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(  false,      zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(  false,                   true ));
        NoNullRet(true,  true      .Coalesce(  false,      zeroMatters: false));
        NoNullRet(true,  true      .Coalesce(  false,                   false));
        NoNullRet(true,  true      .Coalesce(  false,      zeroMatters       ));
        NoNullRet(true,  true      .Coalesce(  false,      zeroMatters: true ));
        NoNullRet(true,  true      .Coalesce(  false,                   true ));
        NoNullRet(true,  NullBool  .Coalesce(  true,       zeroMatters: false));
        NoNullRet(true,  NullBool  .Coalesce(  true,                    false));
        NoNullRet(true,  NullBool  .Coalesce(  true,       zeroMatters       ));
        NoNullRet(true,  NullBool  .Coalesce(  true,       zeroMatters: true ));
        NoNullRet(true,  NullBool  .Coalesce(  true,                    true ));
        NoNullRet(true,  NullyFalse.Coalesce(  true,       zeroMatters: false));
        NoNullRet(true,  NullyFalse.Coalesce(  true,                    false));
        NoNullRet(false, NullyFalse.Coalesce(  true,       zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(  true,       zeroMatters: true ));
      //NoNullRet(false, NullyFalse.Coalesce(  true,                    true )); // TODO: Does not work
        NoNullRet(true,  NullyTrue .Coalesce(  true,       zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(  true,                    false));
        NoNullRet(true,  NullyTrue .Coalesce(  true,       zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(  true,       zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(  true,                    true ));
        NoNullRet(true,  false     .Coalesce(  true,       zeroMatters: false));
        NoNullRet(true,  false     .Coalesce(  true,                    false));
        NoNullRet(false, false     .Coalesce(  true,       zeroMatters       ));
        NoNullRet(false, false     .Coalesce(  true,       zeroMatters: true ));
      //NoNullRet(false, false     .Coalesce(  true,                    true )); // TODO: Does not work
    }                                                    

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_BoolToText_ZeroMattersNoNulliesFlagsInBack()
    {
        NoNullRet("",         Coalesce(false,     NullText,  zeroMatters: false));
        NoNullRet("",         Coalesce(false,     NullText,               false));
        NoNullRet("False",    Coalesce(false,     NullText,  zeroMatters       ));
        NoNullRet("False",    Coalesce(false,     NullText,  zeroMatters: true ));
        NoNullRet("False",    Coalesce(false,     NullText,               true ));
        NoNullRet("peekaboo", Coalesce(false,    "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo", Coalesce(false,    "peekaboo",              false));
        NoNullRet("False",    Coalesce(false,    "peekaboo", zeroMatters       ));
        NoNullRet("False",    Coalesce(false,    "peekaboo", zeroMatters: true ));
        NoNullRet("False",    Coalesce(false,    "peekaboo",              true ));
        NoNullRet("True",     Coalesce(true,      NullText,  zeroMatters: false));
        NoNullRet("True",     Coalesce(true,      NullText,               false));
        NoNullRet("True",     Coalesce(true,      NullText,  zeroMatters       ));
        NoNullRet("True",     Coalesce(true,      NullText,  zeroMatters: true ));
        NoNullRet("True",     Coalesce(true,      NullText,               true ));
        NoNullRet("True",     Coalesce(true,     "peekaboo", zeroMatters: false));
        NoNullRet("True",     Coalesce(true,     "peekaboo",              false));
        NoNullRet("True",     Coalesce(true,     "peekaboo", zeroMatters       ));
        NoNullRet("True",     Coalesce(true,     "peekaboo", zeroMatters: true ));
        NoNullRet("True",     Coalesce(true,     "peekaboo",              true ));
        NoNullRet("",         false   .Coalesce(  NullText,  zeroMatters: false));
        NoNullRet("",         false   .Coalesce(  NullText,               false));
        NoNullRet("False",    false   .Coalesce(  NullText,  zeroMatters       ));
        NoNullRet("False",    false   .Coalesce(  NullText,  zeroMatters: true ));
        NoNullRet("False",    false   .Coalesce(  NullText,               true ));
        NoNullRet("peekaboo", false   .Coalesce( "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo", false   .Coalesce( "peekaboo",              false));
        NoNullRet("False",    false   .Coalesce( "peekaboo", zeroMatters       ));
        NoNullRet("False",    false   .Coalesce( "peekaboo", zeroMatters: true ));
        NoNullRet("False",    false   .Coalesce( "peekaboo",              true ));
        NoNullRet("True",     true    .Coalesce(  NullText,  zeroMatters: false));
        NoNullRet("True",     true    .Coalesce(  NullText,               false));
        NoNullRet("True",     true    .Coalesce(  NullText,  zeroMatters       ));
        NoNullRet("True",     true    .Coalesce(  NullText,  zeroMatters: true ));
        NoNullRet("True",     true    .Coalesce(  NullText,               true ));
        NoNullRet("True",     true    .Coalesce( "peekaboo", zeroMatters: false));
        NoNullRet("True",     true    .Coalesce( "peekaboo",              false));
        NoNullRet("True",     true    .Coalesce( "peekaboo", zeroMatters       ));
        NoNullRet("True",     true    .Coalesce( "peekaboo", zeroMatters: true ));
        NoNullRet("True",     true    .Coalesce( "peekaboo",              true ));
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