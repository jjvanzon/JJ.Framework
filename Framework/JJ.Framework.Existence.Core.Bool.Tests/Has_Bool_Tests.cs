// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
namespace JJ.Framework.Existence.Core.Bool.Tests;

[TestClass]
public class Has_Bool_Tests : TestBase
{
    [TestMethod]
    public void Has_Bool()
    {
        IsTrue (Has(true));
        IsFalse(Has(false));
        IsTrue (Has(True));
        IsFalse(Has(False));
        IsTrue (Has(NullyTrue));
        IsFalse(Has(NullyFalse));
        IsFalse(Has(NullBool));
    }
    
    [TestMethod]
    public void Has_Bool_ZeroMattersNo_FlagsInBack()
    { 
        IsTrue (Has(true                          ));
        IsTrue (Has(true,       zeroMatters: false));
        IsTrue (Has(true,                    false));
        IsFalse(Has(false                         ));
        IsFalse(Has(false,      zeroMatters: false));
        IsFalse(Has(false,                   false));
        IsTrue (Has(True                          ));
        IsTrue (Has(True,       zeroMatters: false));
        IsTrue (Has(True,                    false));
        IsFalse(Has(False                         ));
        IsFalse(Has(False,      zeroMatters: false));
        IsFalse(Has(False,                   false));
        IsTrue (Has(NullyTrue                     ));
        IsTrue (Has(NullyTrue,  zeroMatters: false));
        IsTrue (Has(NullyTrue,               false));
        IsFalse(Has(NullyFalse                    ));
        IsFalse(Has(NullyFalse, zeroMatters: false));
        IsFalse(Has(NullyFalse,              false));
        IsFalse(Has(NullBool                      ));
        IsFalse(Has(NullBool,   zeroMatters: false));
        IsFalse(Has(NullBool,                false));
    }

    [TestMethod]
    public void Has_Bool_ZeroMattersNo_FlagsInFront()
    {
        IsTrue (Has(                    true      ));
        IsTrue (Has(zeroMatters: false, true      ));
        IsTrue (Has(             false, true      ));
        IsFalse(Has(                    false     ));
        IsFalse(Has(zeroMatters: false, false     ));
        IsFalse(Has(             false, false     ));
        IsTrue (Has(                    True      ));
        IsTrue (Has(zeroMatters: false, True      ));
        IsTrue (Has(             false, True      ));
        IsFalse(Has(                    False     ));
        IsFalse(Has(zeroMatters: false, False     ));
        IsFalse(Has(             false, False     ));
        IsTrue (Has(                    NullyTrue ));
        IsTrue (Has(zeroMatters: false, NullyTrue ));
        IsTrue (Has(             false, NullyTrue ));
        IsFalse(Has(                    NullyFalse));
        IsFalse(Has(zeroMatters: false, NullyFalse));
        IsFalse(Has(             false, NullyFalse));
        IsFalse(Has(                    NullBool  ));
        IsFalse(Has(zeroMatters: false, NullBool  ));
        IsFalse(Has(             false, NullBool  ));
    }
    
    [TestMethod]
    public void Has_Bool_ZeroMattersYes_FlagsInBack()
    { 
        IsTrue (Has(true,       zeroMatters       ));
        IsTrue (Has(true,       zeroMatters: true ));
        IsTrue (Has(true,                    true ));
        IsTrue (Has(false,      zeroMatters       ));
        IsTrue (Has(false,      zeroMatters: true ));
        IsTrue (Has(false,                   true ));
        IsTrue (Has(True,       zeroMatters       ));
        IsTrue (Has(True,       zeroMatters: true ));
        IsTrue (Has(True,                    true ));
        IsTrue (Has(False,      zeroMatters       ));
        IsTrue (Has(False,      zeroMatters: true ));
        IsTrue (Has(False,                   true ));
        IsTrue (Has(NullyTrue,  zeroMatters       ));
        IsTrue (Has(NullyTrue,  zeroMatters: true ));
        IsTrue (Has(NullyTrue,               true ));
        IsTrue (Has(NullyFalse, zeroMatters       ));
        IsTrue (Has(NullyFalse, zeroMatters: true ));
        IsTrue (Has(NullyFalse,              true ));
        IsFalse(Has(NullBool,   zeroMatters       ));
        IsFalse(Has(NullBool,   zeroMatters: true ));
        IsFalse(Has(NullBool,                true ));
    }

    [TestMethod]
    public void Has_Bool_ZeroMattersYes_FlagsInFront()
    {
        IsTrue (Has(zeroMatters,        true      ));
        IsTrue (Has(zeroMatters: true,  true      ));
        IsTrue (Has(             true,  true      ));
        IsTrue (Has(zeroMatters,        false     ));
        IsTrue (Has(zeroMatters: true,  false     ));
        IsTrue (Has(             true,  false     ));
        IsTrue (Has(zeroMatters,        True      ));
        IsTrue (Has(zeroMatters: true,  True      ));
        IsTrue (Has(             true,  True      ));
        IsTrue (Has(zeroMatters,        False     ));
        IsTrue (Has(zeroMatters: true,  False     ));
        IsTrue (Has(             true,  False     ));
        IsTrue (Has(zeroMatters,        NullyTrue ));
        IsTrue (Has(zeroMatters: true,  NullyTrue ));
        IsTrue (Has(             true,  NullyTrue ));
        IsTrue (Has(zeroMatters,        NullyFalse));
        IsTrue (Has(zeroMatters: true,  NullyFalse));
        IsTrue (Has(             true,  NullyFalse));
        IsFalse(Has(zeroMatters,        NullBool  ));
        IsFalse(Has(zeroMatters: true,  NullBool  ));
        IsFalse(Has(             true,  NullBool  ));
    }

    /// <inheritdoc cref="_nullableflag" />
    [TestMethod]
    public void Has_Bool_NullableFlag()
    {
        bool? nullyZeroMattersFalse = false;
        bool? nullyZeroMattersTrue  = true;

        IsTrue (Has(true,       nullyZeroMattersFalse         ));
        IsFalse(Has(false,      nullyZeroMattersFalse         ));
        IsTrue (Has(True,       nullyZeroMattersFalse         ));
        IsFalse(Has(False,      nullyZeroMattersFalse         ));
        IsTrue (Has(NullyTrue,  nullyZeroMattersFalse ?? false));
        IsFalse(Has(NullyFalse, nullyZeroMattersFalse ?? false));
        IsFalse(Has(NullBool,   nullyZeroMattersFalse ?? false));

        IsTrue (Has(true,       nullyZeroMattersTrue          ));
        IsTrue (Has(false,      nullyZeroMattersTrue          ));
        IsTrue (Has(True,       nullyZeroMattersTrue          ));
        IsTrue (Has(False,      nullyZeroMattersTrue          ));
        IsTrue (Has(NullyTrue,  nullyZeroMattersTrue  ?? true ));
        IsTrue (Has(NullyFalse, nullyZeroMattersTrue  ?? true ));
        IsFalse(Has(NullBool,   nullyZeroMattersTrue  ?? true ));

        IsTrue (Has(nullyZeroMattersFalse,          true       ));
        IsFalse(Has(nullyZeroMattersFalse,          false      ));
        IsTrue (Has(nullyZeroMattersFalse,          True       ));
        IsFalse(Has(nullyZeroMattersFalse,          False      ));
        IsTrue (Has(nullyZeroMattersFalse ?? false, NullyTrue  ));
        IsFalse(Has(nullyZeroMattersFalse ?? false, NullyFalse ));
        IsFalse(Has(nullyZeroMattersFalse ?? false, NullBool   ));

        IsTrue (Has(nullyZeroMattersTrue,           true       ));
        IsTrue (Has(nullyZeroMattersTrue,           false      ));
        IsTrue (Has(nullyZeroMattersTrue,           True       ));
        IsTrue (Has(nullyZeroMattersTrue,           False      ));
        IsTrue (Has(nullyZeroMattersTrue  ?? true , NullyTrue  ));
        IsTrue (Has(nullyZeroMattersTrue  ?? true , NullyFalse ));
        IsFalse(Has(nullyZeroMattersTrue  ?? true , NullBool   ));
    }
}