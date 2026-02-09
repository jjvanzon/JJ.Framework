// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Bool_Tests : TestBase
{
    [TestMethod]
    public void FilledIn_Bool_Static()
    {
        IsTrue (FilledIn(true      ));
        IsFalse(FilledIn(false     ));
        IsTrue (FilledIn(True      ));
        IsFalse(FilledIn(False     ));
        IsTrue (FilledIn(NullyTrue ));
        IsFalse(FilledIn(NullyFalse));
        IsFalse(FilledIn(NullBool  ));
    }

    [TestMethod]
    public void FilledIn_Bool_Extensions()
    {
        IsTrue (true      .FilledIn());
        IsFalse(false     .FilledIn());
        IsTrue (True      .FilledIn());
        IsFalse(False     .FilledIn());
        IsTrue (NullyTrue .FilledIn());
        IsFalse(NullyFalse.FilledIn());
        IsFalse(NullBool  .FilledIn());
    }
        
    [TestMethod]
    public void FilledIn_Bool_ZeroMattersNo_Extensions()
    { 
        IsTrue (true      .FilledIn(                   ));
        IsTrue (true      .FilledIn( zeroMatters: false));
        IsTrue (true      .FilledIn(              false));
        IsFalse(false     .FilledIn(                   ));
        IsFalse(false     .FilledIn( zeroMatters: false));
        IsFalse(false     .FilledIn(              false));
        IsTrue (True      .FilledIn(                   ));
        IsTrue (True      .FilledIn( zeroMatters: false));
        IsTrue (True      .FilledIn(              false));
        IsFalse(False     .FilledIn(                   ));
        IsFalse(False     .FilledIn( zeroMatters: false));
        IsFalse(False     .FilledIn(              false));
        IsTrue (NullyTrue .FilledIn(                   ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: false));
        IsTrue (NullyTrue .FilledIn(              false));
        IsFalse(NullyFalse.FilledIn(                   ));
        IsFalse(NullyFalse.FilledIn( zeroMatters: false));
        IsFalse(NullyFalse.FilledIn(              false));
        IsFalse(NullBool  .FilledIn(                   ));
        IsFalse(NullBool  .FilledIn( zeroMatters: false));
        IsFalse(NullBool  .FilledIn(              false));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersNo_StaticFlagsInBack()
    { 
        IsTrue (FilledIn(true                          ));
        IsTrue (FilledIn(true,       zeroMatters: false));
        IsTrue (FilledIn(true,                    false));
        IsFalse(FilledIn(false                         ));
        IsFalse(FilledIn(false,      zeroMatters: false));
        IsFalse(FilledIn(false,                   false));
        IsTrue (FilledIn(True                          ));
        IsTrue (FilledIn(True,       zeroMatters: false));
        IsTrue (FilledIn(True,                    false));
        IsFalse(FilledIn(False                         ));
        IsFalse(FilledIn(False,      zeroMatters: false));
        IsFalse(FilledIn(False,                   false));
        IsTrue (FilledIn(NullyTrue                     ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: false));
        IsTrue (FilledIn(NullyTrue,               false));
        IsFalse(FilledIn(NullyFalse                    ));
        IsFalse(FilledIn(NullyFalse, zeroMatters: false));
        IsFalse(FilledIn(NullyFalse,              false));
        IsFalse(FilledIn(NullBool                      ));
        IsFalse(FilledIn(NullBool,   zeroMatters: false));
        IsFalse(FilledIn(NullBool,                false));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersNo_StaticFlagsInFront()
    {
        IsTrue (FilledIn(                    true      ));
        IsTrue (FilledIn(zeroMatters: false, true      ));
        IsTrue (FilledIn(             false, true      ));
        IsFalse(FilledIn(                    false     ));
        IsFalse(FilledIn(zeroMatters: false, false     ));
        IsFalse(FilledIn(             false, false     ));
        IsTrue (FilledIn(                    True      ));
        IsTrue (FilledIn(zeroMatters: false, True      ));
        IsTrue (FilledIn(             false, True      ));
        IsFalse(FilledIn(                    False     ));
        IsFalse(FilledIn(zeroMatters: false, False     ));
        IsFalse(FilledIn(             false, False     ));
        IsTrue (FilledIn(                    NullyTrue ));
        IsTrue (FilledIn(zeroMatters: false, NullyTrue ));
        IsTrue (FilledIn(             false, NullyTrue ));
        IsFalse(FilledIn(                    NullyFalse));
        IsFalse(FilledIn(zeroMatters: false, NullyFalse));
        IsFalse(FilledIn(             false, NullyFalse));
        IsFalse(FilledIn(                    NullBool  ));
        IsFalse(FilledIn(zeroMatters: false, NullBool  ));
        IsFalse(FilledIn(             false, NullBool  ));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersYes_Extensions()
    { 
        IsTrue (true      .FilledIn( zeroMatters       ));
        IsTrue (true      .FilledIn( zeroMatters: true ));
        IsTrue (true      .FilledIn(              true ));
        IsTrue (false     .FilledIn( zeroMatters       ));
        IsTrue (false     .FilledIn( zeroMatters: true ));
        IsTrue (false     .FilledIn(              true ));
        IsTrue (True      .FilledIn( zeroMatters       ));
        IsTrue (True      .FilledIn( zeroMatters: true ));
        IsTrue (True      .FilledIn(              true ));
        IsTrue (False     .FilledIn( zeroMatters       ));
        IsTrue (False     .FilledIn( zeroMatters: true ));
        IsTrue (False     .FilledIn(              true ));
        IsTrue (NullyTrue .FilledIn( zeroMatters       ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: true ));
        IsTrue (NullyTrue .FilledIn(              true ));
        IsTrue (NullyFalse.FilledIn( zeroMatters       ));
        IsTrue (NullyFalse.FilledIn( zeroMatters: true ));
        IsTrue (NullyFalse.FilledIn(              true ));
        IsFalse(NullBool  .FilledIn( zeroMatters       ));
        IsFalse(NullBool  .FilledIn( zeroMatters: true ));
        IsFalse(NullBool  .FilledIn(              true ));
    }
    
    [TestMethod]
    public void FilledIn_Bool_ZeroMattersYes_StaticFlagsInBack()
    { 
        IsTrue (FilledIn(true,       zeroMatters       ));
        IsTrue (FilledIn(true,       zeroMatters: true ));
        IsTrue (FilledIn(true,                    true ));
        IsTrue (FilledIn(false,      zeroMatters       ));
        IsTrue (FilledIn(false,      zeroMatters: true ));
        IsTrue (FilledIn(false,                   true ));
        IsTrue (FilledIn(True,       zeroMatters       ));
        IsTrue (FilledIn(True,       zeroMatters: true ));
        IsTrue (FilledIn(True,                    true ));
        IsTrue (FilledIn(False,      zeroMatters       ));
        IsTrue (FilledIn(False,      zeroMatters: true ));
        IsTrue (FilledIn(False,                   true ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters       ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTrue,               true ));
        IsTrue (FilledIn(NullyFalse, zeroMatters       ));
        IsTrue (FilledIn(NullyFalse, zeroMatters: true ));
        IsTrue (FilledIn(NullyFalse,              true ));
        IsFalse(FilledIn(NullBool,   zeroMatters       ));
        IsFalse(FilledIn(NullBool,   zeroMatters: true ));
        IsFalse(FilledIn(NullBool,                true ));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersYes_StaticFlagsInFront()
    {
        IsTrue (FilledIn(zeroMatters,        true      ));
        IsTrue (FilledIn(zeroMatters: true,  true      ));
        IsTrue (FilledIn(             true,  true      ));
        IsTrue (FilledIn(zeroMatters,        false     ));
        IsTrue (FilledIn(zeroMatters: true,  false     ));
        IsTrue (FilledIn(             true,  false     ));
        IsTrue (FilledIn(zeroMatters,        True      ));
        IsTrue (FilledIn(zeroMatters: true,  True      ));
        IsTrue (FilledIn(             true,  True      ));
        IsTrue (FilledIn(zeroMatters,        False     ));
        IsTrue (FilledIn(zeroMatters: true,  False     ));
        IsTrue (FilledIn(             true,  False     ));
        IsTrue (FilledIn(zeroMatters,        NullyTrue ));
        IsTrue (FilledIn(zeroMatters: true,  NullyTrue ));
        IsTrue (FilledIn(             true,  NullyTrue ));
        IsTrue (FilledIn(zeroMatters,        NullyFalse));
        IsTrue (FilledIn(zeroMatters: true,  NullyFalse));
        IsTrue (FilledIn(             true,  NullyFalse));
        IsFalse(FilledIn(zeroMatters,        NullBool  ));
        IsFalse(FilledIn(zeroMatters: true,  NullBool  ));
        IsFalse(FilledIn(             true,  NullBool  ));
    }

    /// <inheritdoc cref="_nullableflag" />
    [TestMethod]
    public void FilledIn_Bool_NullableFlag()
    {
        bool? nullyZeroMattersFalse = false;
        bool? nullyZeroMattersTrue  = true;

        // NOTE: Extension methods do not have the ambiguity problem.

        IsTrue (FilledIn(true,       nullyZeroMattersFalse         ));
        IsFalse(FilledIn(false,      nullyZeroMattersFalse         ));
        IsTrue (FilledIn(True,       nullyZeroMattersFalse         ));
        IsFalse(FilledIn(False,      nullyZeroMattersFalse         ));
        IsTrue (FilledIn(NullyTrue,  nullyZeroMattersFalse ?? false));
        IsFalse(FilledIn(NullyFalse, nullyZeroMattersFalse ?? false));
        IsFalse(FilledIn(NullBool,   nullyZeroMattersFalse ?? false));

        IsTrue (FilledIn(true,       nullyZeroMattersTrue          ));
        IsTrue (FilledIn(false,      nullyZeroMattersTrue          ));
        IsTrue (FilledIn(True,       nullyZeroMattersTrue          ));
        IsTrue (FilledIn(False,      nullyZeroMattersTrue          ));
        IsTrue (FilledIn(NullyTrue,  nullyZeroMattersTrue  ?? true ));
        IsTrue (FilledIn(NullyFalse, nullyZeroMattersTrue  ?? true ));
        IsFalse(FilledIn(NullBool,   nullyZeroMattersTrue  ?? true ));

        IsTrue (FilledIn(nullyZeroMattersFalse,          true       ));
        IsFalse(FilledIn(nullyZeroMattersFalse,          false      ));
        IsTrue (FilledIn(nullyZeroMattersFalse,          True       ));
        IsFalse(FilledIn(nullyZeroMattersFalse,          False      ));
        IsTrue (FilledIn(nullyZeroMattersFalse ?? false, NullyTrue  ));
        IsFalse(FilledIn(nullyZeroMattersFalse ?? false, NullyFalse ));
        IsFalse(FilledIn(nullyZeroMattersFalse ?? false, NullBool   ));

        IsTrue (FilledIn(nullyZeroMattersTrue,           true       ));
        IsTrue (FilledIn(nullyZeroMattersTrue,           false      ));
        IsTrue (FilledIn(nullyZeroMattersTrue,           True       ));
        IsTrue (FilledIn(nullyZeroMattersTrue,           False      ));
        IsTrue (FilledIn(nullyZeroMattersTrue  ?? true , NullyTrue  ));
        IsTrue (FilledIn(nullyZeroMattersTrue  ?? true , NullyFalse ));
        IsFalse(FilledIn(nullyZeroMattersTrue  ?? true , NullBool   ));
    }
}