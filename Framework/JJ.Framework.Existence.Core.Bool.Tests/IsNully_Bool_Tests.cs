// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
namespace JJ.Framework.Existence.Core.Bool.Tests;

[TestClass]
public class IsNully_Bool_Tests : TestBase
{
    [TestMethod]
    public void IsNully_Bool_Static()
    {
        IsFalse(IsNully(true      ));
        IsTrue (IsNully(false     ));
        IsFalse(IsNully(True      ));
        IsTrue (IsNully(False     ));
        IsFalse(IsNully(NullyTrue ));
        IsTrue (IsNully(NullyFalse));
        IsTrue (IsNully(NullBool  ));
    }

    [TestMethod]
    public void IsNully_Bool_Extensions()
    {
        IsFalse(true      .IsNully());
        IsTrue (false     .IsNully());
        IsFalse(True      .IsNully());
        IsTrue (False     .IsNully());
        IsFalse(NullyTrue .IsNully());
        IsTrue (NullyFalse.IsNully());
        IsTrue (NullBool  .IsNully());
    }
        
    [TestMethod]
    public void IsNully_Bool_ZeroMattersNo_Extensions()
    { 
        IsFalse(true      .IsNully(                   ));
        IsFalse(true      .IsNully( zeroMatters: false));
        IsFalse(true      .IsNully(              false));
        IsTrue (false     .IsNully(                   ));
        IsTrue (false     .IsNully( zeroMatters: false));
        IsTrue (false     .IsNully(              false));
        IsFalse(True      .IsNully(                   ));
        IsFalse(True      .IsNully( zeroMatters: false));
        IsFalse(True      .IsNully(              false));
        IsTrue (False     .IsNully(                   ));
        IsTrue (False     .IsNully( zeroMatters: false));
        IsTrue (False     .IsNully(              false));
        IsFalse(NullyTrue .IsNully(                   ));
        IsFalse(NullyTrue .IsNully( zeroMatters: false));
        IsFalse(NullyTrue .IsNully(              false));
        IsTrue (NullyFalse.IsNully(                   ));
        IsTrue (NullyFalse.IsNully( zeroMatters: false));
        IsTrue (NullyFalse.IsNully(              false));
        IsTrue (NullBool  .IsNully(                   ));
        IsTrue (NullBool  .IsNully( zeroMatters: false));
        IsTrue (NullBool  .IsNully(              false));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersNo_StaticFlagsInBack()
    { 
        IsFalse(IsNully(true                          ));
        IsFalse(IsNully(true,       zeroMatters: false));
        IsFalse(IsNully(true,                    false));
        IsTrue (IsNully(false                         ));
        IsTrue (IsNully(false,      zeroMatters: false));
        IsTrue (IsNully(false,                   false));
        IsFalse(IsNully(True                          ));
        IsFalse(IsNully(True,       zeroMatters: false));
        IsFalse(IsNully(True,                    false));
        IsTrue (IsNully(False                         ));
        IsTrue (IsNully(False,      zeroMatters: false));
        IsTrue (IsNully(False,                   false));
        IsFalse(IsNully(NullyTrue                     ));
        IsFalse(IsNully(NullyTrue,  zeroMatters: false));
        IsFalse(IsNully(NullyTrue,               false));
        IsTrue (IsNully(NullyFalse                    ));
        IsTrue (IsNully(NullyFalse, zeroMatters: false));
        IsTrue (IsNully(NullyFalse,              false));
        IsTrue (IsNully(NullBool                      ));
        IsTrue (IsNully(NullBool,   zeroMatters: false));
        IsTrue (IsNully(NullBool,                false));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersNo_StaticFlagsInFront()
    {
        IsFalse(IsNully(                    true      ));
        IsFalse(IsNully(zeroMatters: false, true      ));
        IsFalse(IsNully(             false, true      ));
        IsTrue (IsNully(                    false     ));
        IsTrue (IsNully(zeroMatters: false, false     ));
        IsTrue (IsNully(             false, false     ));
        IsFalse(IsNully(                    True      ));
        IsFalse(IsNully(zeroMatters: false, True      ));
        IsFalse(IsNully(             false, True      ));
        IsTrue (IsNully(                    False     ));
        IsTrue (IsNully(zeroMatters: false, False     ));
        IsTrue (IsNully(             false, False     ));
        IsFalse(IsNully(                    NullyTrue ));
        IsFalse(IsNully(zeroMatters: false, NullyTrue ));
        IsFalse(IsNully(             false, NullyTrue ));
        IsTrue (IsNully(                    NullyFalse));
        IsTrue (IsNully(zeroMatters: false, NullyFalse));
        IsTrue (IsNully(             false, NullyFalse));
        IsTrue (IsNully(                    NullBool  ));
        IsTrue (IsNully(zeroMatters: false, NullBool  ));
        IsTrue (IsNully(             false, NullBool  ));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersYes_Extensions()
    { 
        IsFalse(true      .IsNully( zeroMatters       ));
        IsFalse(true      .IsNully( zeroMatters: true ));
        IsFalse(true      .IsNully(              true ));
        IsFalse(false     .IsNully( zeroMatters       ));
        IsFalse(false     .IsNully( zeroMatters: true ));
        IsFalse(false     .IsNully(              true ));
        IsFalse(True      .IsNully( zeroMatters       ));
        IsFalse(True      .IsNully( zeroMatters: true ));
        IsFalse(True      .IsNully(              true ));
        IsFalse(False     .IsNully( zeroMatters       ));
        IsFalse(False     .IsNully( zeroMatters: true ));
        IsFalse(False     .IsNully(              true ));
        IsFalse(NullyTrue .IsNully( zeroMatters       ));
        IsFalse(NullyTrue .IsNully( zeroMatters: true ));
        IsFalse(NullyTrue .IsNully(              true ));
        IsFalse(NullyFalse.IsNully( zeroMatters       ));
        IsFalse(NullyFalse.IsNully( zeroMatters: true ));
        IsFalse(NullyFalse.IsNully(              true ));
        IsTrue (NullBool  .IsNully( zeroMatters       ));
        IsTrue (NullBool  .IsNully( zeroMatters: true ));
        IsTrue (NullBool  .IsNully(              true ));
    }
    
    [TestMethod]
    public void IsNully_Bool_ZeroMattersYes_StaticFlagsInBack()
    { 
        IsFalse(IsNully(true,       zeroMatters       ));
        IsFalse(IsNully(true,       zeroMatters: true ));
        IsFalse(IsNully(true,                    true ));
        IsFalse(IsNully(false,      zeroMatters       ));
        IsFalse(IsNully(false,      zeroMatters: true ));
        IsFalse(IsNully(false,                   true ));
        IsFalse(IsNully(True,       zeroMatters       ));
        IsFalse(IsNully(True,       zeroMatters: true ));
        IsFalse(IsNully(True,                    true ));
        IsFalse(IsNully(False,      zeroMatters       ));
        IsFalse(IsNully(False,      zeroMatters: true ));
        IsFalse(IsNully(False,                   true ));
        IsFalse(IsNully(NullyTrue,  zeroMatters       ));
        IsFalse(IsNully(NullyTrue,  zeroMatters: true ));
        IsFalse(IsNully(NullyTrue,               true ));
        IsFalse(IsNully(NullyFalse, zeroMatters       ));
        IsFalse(IsNully(NullyFalse, zeroMatters: true ));
        IsFalse(IsNully(NullyFalse,              true ));
        IsTrue (IsNully(NullBool,   zeroMatters       ));
        IsTrue (IsNully(NullBool,   zeroMatters: true ));
        IsTrue (IsNully(NullBool,                true ));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersYes_StaticFlagsInFront()
    {
        IsFalse(IsNully(zeroMatters,        true      ));
        IsFalse(IsNully(zeroMatters: true,  true      ));
        IsFalse(IsNully(             true,  true      ));
        IsFalse(IsNully(zeroMatters,        false     ));
        IsFalse(IsNully(zeroMatters: true,  false     ));
        IsFalse(IsNully(             true,  false     ));
        IsFalse(IsNully(zeroMatters,        True      ));
        IsFalse(IsNully(zeroMatters: true,  True      ));
        IsFalse(IsNully(             true,  True      ));
        IsFalse(IsNully(zeroMatters,        False     ));
        IsFalse(IsNully(zeroMatters: true,  False     ));
        IsFalse(IsNully(             true,  False     ));
        IsFalse(IsNully(zeroMatters,        NullyTrue ));
        IsFalse(IsNully(zeroMatters: true,  NullyTrue ));
        IsFalse(IsNully(             true,  NullyTrue ));
        IsFalse(IsNully(zeroMatters,        NullyFalse));
        IsFalse(IsNully(zeroMatters: true,  NullyFalse));
        IsFalse(IsNully(             true,  NullyFalse));
        IsTrue (IsNully(zeroMatters,        NullBool  ));
        IsTrue (IsNully(zeroMatters: true,  NullBool  ));
        IsTrue (IsNully(             true,  NullBool  ));
    }

    /// <inheritdoc cref="_nullableflag" />
    [TestMethod]
    public void IsNully_Bool_NullableFlag()
    {
        bool? nullyZeroMattersFalse = false;
        bool? nullyZeroMattersTrue  = true;

        // NOTE: Extension methods do not have the ambiguity problem.

        IsFalse(IsNully(true,       nullyZeroMattersFalse         ));
        IsTrue (IsNully(false,      nullyZeroMattersFalse         ));
        IsFalse(IsNully(True,       nullyZeroMattersFalse         ));
        IsTrue (IsNully(False,      nullyZeroMattersFalse         ));
        IsFalse(IsNully(NullyTrue,  nullyZeroMattersFalse ?? false));
        IsTrue (IsNully(NullyFalse, nullyZeroMattersFalse ?? false));
        IsTrue (IsNully(NullBool,   nullyZeroMattersFalse ?? false));

        IsFalse(IsNully(true,       nullyZeroMattersTrue          ));
        IsFalse(IsNully(false,      nullyZeroMattersTrue          ));
        IsFalse(IsNully(True,       nullyZeroMattersTrue          ));
        IsFalse(IsNully(False,      nullyZeroMattersTrue          ));
        IsFalse(IsNully(NullyTrue,  nullyZeroMattersTrue  ?? true ));
        IsFalse(IsNully(NullyFalse, nullyZeroMattersTrue  ?? true ));
        IsTrue (IsNully(NullBool,   nullyZeroMattersTrue  ?? true ));

        IsFalse(IsNully(nullyZeroMattersFalse,          true       ));
        IsTrue (IsNully(nullyZeroMattersFalse,          false      ));
        IsFalse(IsNully(nullyZeroMattersFalse,          True       ));
        IsTrue (IsNully(nullyZeroMattersFalse,          False      ));
        IsFalse(IsNully(nullyZeroMattersFalse ?? false, NullyTrue  ));
        IsTrue (IsNully(nullyZeroMattersFalse ?? false, NullyFalse ));
        IsTrue (IsNully(nullyZeroMattersFalse ?? false, NullBool   ));

        IsFalse(IsNully(nullyZeroMattersTrue,           true       ));
        IsFalse(IsNully(nullyZeroMattersTrue,           false      ));
        IsFalse(IsNully(nullyZeroMattersTrue,           True       ));
        IsFalse(IsNully(nullyZeroMattersTrue,           False      ));
        IsFalse(IsNully(nullyZeroMattersTrue  ?? true , NullyTrue  ));
        IsFalse(IsNully(nullyZeroMattersTrue  ?? true , NullyFalse ));
        IsTrue (IsNully(nullyZeroMattersTrue  ?? true , NullBool   ));
    }
}