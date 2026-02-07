namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class BasicType_Bool_Tests : TestBase
{
    [TestMethod]
    public void Test_Bool_Has()
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
    public void Test_Bool_FilledIn()
    {
        IsTrue (FilledIn(true));
        IsFalse(FilledIn(false));
        IsTrue (FilledIn(True));
        IsFalse(FilledIn(False));
        IsTrue (FilledIn(NullyTrue));
        IsFalse(FilledIn(NullyFalse));
        IsFalse(FilledIn(NullBool));

        IsTrue (true.FilledIn());
        IsFalse(false.FilledIn());
        IsTrue (True.FilledIn());
        IsFalse(False.FilledIn());
        IsTrue (NullyTrue.FilledIn());
        IsFalse(NullyFalse.FilledIn());
        IsFalse(NullBool.FilledIn());
    }
        
    [TestMethod]
    public void Test_Bool_IsNully()
    {
        IsFalse(IsNully (true));
        IsTrue (IsNully (false));
        IsFalse(IsNully (True));
        IsTrue (IsNully (False));
        IsFalse(IsNully (NullyTrue));
        IsTrue (IsNully (NullyFalse));
        IsTrue (IsNully (NullBool));

        IsFalse(true.IsNully ());
        IsTrue (false.IsNully ());
        IsFalse(True.IsNully ());
        IsTrue (False.IsNully ());
        IsFalse(NullyTrue.IsNully ());
        IsTrue (NullyFalse.IsNully ());
        IsTrue (NullBool.IsNully ());
    }

    [TestMethod]
    public void Test_Bool_Coalesce()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(NullBool));
    }

    [TestMethod]
    public void Test_Bool_Has_ZeroMattersFlagsInBack()
    {
        IsTrue (Has     (true,       zeroMatters: false));
        IsTrue (Has     (true,                    false));
        IsTrue (Has     (true,       zeroMatters       ));
        IsTrue (Has     (true,       zeroMatters: true ));
        IsTrue (Has     (true,                    true ));
        IsFalse(Has     (false,      zeroMatters: false));
        IsFalse(Has     (false,                   false));
        IsTrue (Has     (false,      zeroMatters       ));
        IsTrue (Has     (false,      zeroMatters: true ));
        IsTrue (Has     (false,                   true ));
        IsTrue (Has     (True,       zeroMatters: false));
        IsTrue (Has     (True,                    false));
        IsTrue (Has     (True,       zeroMatters       ));
        IsTrue (Has     (True,       zeroMatters: true ));
        IsTrue (Has     (True,                    true ));
        IsFalse(Has     (False,      zeroMatters: false));
        IsFalse(Has     (False,                   false));
        IsTrue (Has     (False,      zeroMatters       ));
        IsTrue (Has     (False,      zeroMatters: true ));
        IsTrue (Has     (False,                   true ));
        IsTrue (Has     (NullyTrue,  zeroMatters: false));
        IsTrue (Has     (NullyTrue,               false));
        IsTrue (Has     (NullyTrue,  zeroMatters       ));
        IsTrue (Has     (NullyTrue,  zeroMatters: true ));
        IsTrue (Has     (NullyTrue,               true ));
        IsFalse(Has     (NullyFalse, zeroMatters: false));
        IsFalse(Has     (NullyFalse,              false));
        IsTrue (Has     (NullyFalse, zeroMatters       ));
        IsTrue (Has     (NullyFalse, zeroMatters: true ));
        IsTrue (Has     (NullyFalse,              true ));
        IsFalse(Has     (NullBool,   zeroMatters: false));
        IsFalse(Has     (NullBool,                false));
        IsFalse(Has     (NullBool,   zeroMatters       ));
        IsFalse(Has     (NullBool,   zeroMatters: true ));
        IsFalse(Has     (NullBool,                true ));
    }

    [TestMethod]
    public void Test_Bool_Has_ZeroMattersFlagsInFront()
    {
        IsTrue (Has     (zeroMatters: false, true        ));
        IsTrue (Has     (             false, true        ));
        IsTrue (Has     (zeroMatters,        true        ));
        IsTrue (Has     (zeroMatters: true,  true        ));
        IsTrue (Has     (             true,  true        ));
        IsFalse(Has     (zeroMatters: false, false       ));
        IsFalse(Has     (             false, false       ));
        IsTrue (Has     (zeroMatters,        false       ));
        IsTrue (Has     (zeroMatters: true,  false       ));
        IsTrue (Has     (             true,  false       ));
        IsTrue (Has     (zeroMatters: false, True        ));
        IsTrue (Has     (             false, True        ));
        IsTrue (Has     (zeroMatters,        True        ));
        IsTrue (Has     (zeroMatters: true,  True        ));
        IsTrue (Has     (             true,  True        ));
        IsFalse(Has     (zeroMatters: false, False       ));
        IsFalse(Has     (             false, False       ));
        IsTrue (Has     (zeroMatters,        False       ));
        IsTrue (Has     (zeroMatters: true,  False       ));
        IsTrue (Has     (             true,  False       ));
        IsTrue (Has     (zeroMatters: false, NullyTrue   ));
        IsTrue (Has     (             false, NullyTrue   ));
        IsTrue (Has     (zeroMatters,        NullyTrue   ));
        IsTrue (Has     (zeroMatters: true,  NullyTrue   ));
        IsTrue (Has     (             true,  NullyTrue   ));
        IsFalse(Has     (zeroMatters: false, NullyFalse  ));
        IsFalse(Has     (             false, NullyFalse  ));
        IsTrue (Has     (zeroMatters,        NullyFalse  ));
        IsTrue (Has     (zeroMatters: true,  NullyFalse  ));
        IsTrue (Has     (             true,  NullyFalse  ));
        IsFalse(Has     (zeroMatters: false, NullBool    ));
        IsFalse(Has     (             false, NullBool    ));
        IsFalse(Has     (zeroMatters,        NullBool    ));
        IsFalse(Has     (zeroMatters: true,  NullBool    ));
        IsFalse(Has     (             true,  NullBool    ));
    }

    [TestMethod]
    public void Test_Bool_FilledIn_StaticZeroMattersFlagsInBack()
    {
        IsTrue (FilledIn(true,       zeroMatters: false));
        IsTrue (FilledIn(true,                    false));
        IsTrue (FilledIn(true,       zeroMatters       ));
        IsTrue (FilledIn(true,       zeroMatters: true ));
        IsTrue (FilledIn(true,                    true ));
        IsFalse(FilledIn(false,      zeroMatters: false));
        IsFalse(FilledIn(false,                   false));
        IsTrue (FilledIn(false,      zeroMatters       ));
        IsTrue (FilledIn(false,      zeroMatters: true ));
        IsTrue (FilledIn(false,                   true ));
        IsTrue (FilledIn(True,       zeroMatters: false));
        IsTrue (FilledIn(True,                    false));
        IsTrue (FilledIn(True,       zeroMatters       ));
        IsTrue (FilledIn(True,       zeroMatters: true ));
        IsTrue (FilledIn(True,                    true ));
        IsFalse(FilledIn(False,      zeroMatters: false));
        IsFalse(FilledIn(False,                   false));
        IsTrue (FilledIn(False,      zeroMatters       ));
        IsTrue (FilledIn(False,      zeroMatters: true ));
        IsTrue (FilledIn(False,                   true ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: false));
        IsTrue (FilledIn(NullyTrue,               false));
        IsTrue (FilledIn(NullyTrue,  zeroMatters       ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTrue,               true ));
        IsFalse(FilledIn(NullyFalse, zeroMatters: false));
        IsFalse(FilledIn(NullyFalse,              false));
        IsTrue (FilledIn(NullyFalse, zeroMatters       ));
        IsTrue (FilledIn(NullyFalse, zeroMatters: true ));
        IsTrue (FilledIn(NullyFalse,              true ));
        IsFalse(FilledIn(NullBool,   zeroMatters: false));
        IsFalse(FilledIn(NullBool,                false));
        IsFalse(FilledIn(NullBool,   zeroMatters       ));
        IsFalse(FilledIn(NullBool,   zeroMatters: true ));
        IsFalse(FilledIn(NullBool,                true ));
    }

    [TestMethod]
    public void Test_Bool_FilledIn_StaticZeroMattersFlagsInFront()
    {
        IsTrue (FilledIn(zeroMatters: false, true      ));
        IsTrue (FilledIn(             false, true      ));
        IsTrue (FilledIn(zeroMatters,        true      ));
        IsTrue (FilledIn(zeroMatters: true,  true      ));
        IsTrue (FilledIn(             true,  true      ));
        IsFalse(FilledIn(zeroMatters: false, false     ));
        IsFalse(FilledIn(             false, false     ));
        IsTrue (FilledIn(zeroMatters,        false     ));
        IsTrue (FilledIn(zeroMatters: true,  false     ));
        IsTrue (FilledIn(             true,  false     ));
        IsTrue (FilledIn(zeroMatters: false, True      ));
        IsTrue (FilledIn(             false, True      ));
        IsTrue (FilledIn(zeroMatters,        True      ));
        IsTrue (FilledIn(zeroMatters: true,  True      ));
        IsTrue (FilledIn(             true,  True      ));
        IsFalse(FilledIn(zeroMatters: false, False     ));
        IsFalse(FilledIn(             false, False     ));
        IsTrue (FilledIn(zeroMatters,        False     ));
        IsTrue (FilledIn(zeroMatters: true,  False     ));
        IsTrue (FilledIn(             true,  False     ));
        IsTrue (FilledIn(zeroMatters: false, NullyTrue ));
        IsTrue (FilledIn(             false, NullyTrue ));
        IsTrue (FilledIn(zeroMatters,        NullyTrue ));
        IsTrue (FilledIn(zeroMatters: true,  NullyTrue ));
        IsTrue (FilledIn(             true,  NullyTrue ));
        IsFalse(FilledIn(zeroMatters: false, NullyFalse));
        IsFalse(FilledIn(             false, NullyFalse));
        IsTrue (FilledIn(zeroMatters,        NullyFalse));
        IsTrue (FilledIn(zeroMatters: true,  NullyFalse));
        IsTrue (FilledIn(             true,  NullyFalse));
        IsFalse(FilledIn(zeroMatters: false, NullBool  ));
        IsFalse(FilledIn(             false, NullBool  ));
        IsFalse(FilledIn(zeroMatters,        NullBool  ));
        IsFalse(FilledIn(zeroMatters: true,  NullBool  ));
        IsFalse(FilledIn(             true,  NullBool  ));
    }

    [TestMethod]
    public void Test_Bool_FilledIn_ExtensionsZeroMatters()
    {
        IsTrue (true      .FilledIn(                   ));
        IsTrue (true      .FilledIn( zeroMatters: false));
        IsTrue (true      .FilledIn(              false));
        IsTrue (true      .FilledIn( zeroMatters       ));
        IsTrue (true      .FilledIn( zeroMatters: true ));
        IsTrue (true      .FilledIn(              true ));
        IsFalse(false     .FilledIn(                   ));
        IsFalse(false     .FilledIn( zeroMatters: false));
        IsFalse(false     .FilledIn(              false));
        IsTrue (false     .FilledIn( zeroMatters       ));
        IsTrue (false     .FilledIn( zeroMatters: true ));
        IsTrue (false     .FilledIn(              true ));
        IsTrue (True      .FilledIn(                   ));
        IsTrue (True      .FilledIn( zeroMatters: false));
        IsTrue (True      .FilledIn(              false));
        IsTrue (True      .FilledIn( zeroMatters       ));
        IsTrue (True      .FilledIn( zeroMatters: true ));
        IsTrue (True      .FilledIn(              true ));
        IsFalse(False     .FilledIn(                   ));
        IsFalse(False     .FilledIn( zeroMatters: false));
        IsFalse(False     .FilledIn(              false));
        IsTrue (False     .FilledIn( zeroMatters       ));
        IsTrue (False     .FilledIn( zeroMatters: true ));
        IsTrue (False     .FilledIn(              true ));
        IsTrue (NullyTrue .FilledIn(                   ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: false));
        IsTrue (NullyTrue .FilledIn(              false));
        IsTrue (NullyTrue .FilledIn( zeroMatters       ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: true ));
        IsTrue (NullyTrue .FilledIn(              true ));
        IsFalse(NullyFalse.FilledIn(                   ));
        IsFalse(NullyFalse.FilledIn( zeroMatters: false));
        IsFalse(NullyFalse.FilledIn(              false));
        IsTrue (NullyFalse.FilledIn( zeroMatters       ));
        IsTrue (NullyFalse.FilledIn( zeroMatters: true ));
        IsTrue (NullyFalse.FilledIn(              true ));
        IsFalse(NullBool  .FilledIn(                   ));
        IsFalse(NullBool  .FilledIn( zeroMatters: false));
        IsFalse(NullBool  .FilledIn(              false));
        IsFalse(NullBool  .FilledIn( zeroMatters       ));
        IsFalse(NullBool  .FilledIn( zeroMatters: true ));
        IsFalse(NullBool  .FilledIn(              true ));
    }

    [TestMethod]
    public void Test_Bool_IsNully_StaticZeroMattersFlagsInBack()
    {
        IsFalse(IsNully (true,       zeroMatters: false));
        IsFalse(IsNully (true,                    false));
        IsFalse(IsNully (true,       zeroMatters       ));
        IsFalse(IsNully (true,       zeroMatters: true ));
        IsFalse(IsNully (true,                    true ));
        IsTrue (IsNully (false,      zeroMatters: false));
        IsTrue (IsNully (false,                   false));
        IsFalse(IsNully (false,      zeroMatters       ));
        IsFalse(IsNully (false,      zeroMatters: true ));
        IsFalse(IsNully (false,                   true ));
        IsFalse(IsNully (True,       zeroMatters: false));
        IsFalse(IsNully (True,                    false));
        IsFalse(IsNully (True,       zeroMatters       ));
        IsFalse(IsNully (True,       zeroMatters: true ));
        IsFalse(IsNully (True,                    true ));
        IsTrue (IsNully (False,      zeroMatters: false));
        IsTrue (IsNully (False,                   false));
        IsFalse(IsNully (False,      zeroMatters       ));
        IsFalse(IsNully (False,      zeroMatters: true ));
        IsFalse(IsNully (False,                   true ));
        IsFalse(IsNully (NullyTrue,  zeroMatters: false));
        IsFalse(IsNully (NullyTrue,               false));
        IsFalse(IsNully (NullyTrue,  zeroMatters       ));
        IsFalse(IsNully (NullyTrue,  zeroMatters: true ));
        IsFalse(IsNully (NullyTrue,               true ));
        IsTrue (IsNully (NullyFalse, zeroMatters: false));
        IsTrue (IsNully (NullyFalse,              false));
        IsFalse(IsNully (NullyFalse, zeroMatters       ));
        IsFalse(IsNully (NullyFalse, zeroMatters: true ));
        IsFalse(IsNully (NullyFalse,              true ));
        IsTrue (IsNully (NullBool,   zeroMatters: false));
        IsTrue (IsNully (NullBool,                false));
        IsTrue (IsNully (NullBool,   zeroMatters       ));
        IsTrue (IsNully (NullBool,   zeroMatters: true ));
        IsTrue (IsNully (NullBool,                true ));
    }

    [TestMethod]
    public void Test_Bool_IsNully_StaticZeroMattersFlagsInFront()
    {
        IsFalse(IsNully (zeroMatters: false, true      ));
        IsFalse(IsNully (             false, true      ));
        IsFalse(IsNully (zeroMatters,        true      ));
        IsFalse(IsNully (zeroMatters: true,  true      ));
        IsFalse(IsNully (             true,  true      ));
        IsTrue (IsNully (zeroMatters: false, false     ));
        IsTrue (IsNully (             false, false     ));
        IsFalse(IsNully (zeroMatters,        false     ));
        IsFalse(IsNully (zeroMatters: true,  false     ));
        IsFalse(IsNully (             true,  false     ));
        IsFalse(IsNully (zeroMatters: false, True      ));
        IsFalse(IsNully (             false, True      ));
        IsFalse(IsNully (zeroMatters,        True      ));
        IsFalse(IsNully (zeroMatters: true,  True      ));
        IsFalse(IsNully (             true,  True      ));
        IsTrue (IsNully (zeroMatters: false, False     ));
        IsTrue (IsNully (             false, False     ));
        IsFalse(IsNully (zeroMatters,        False     ));
        IsFalse(IsNully (zeroMatters: true,  False     ));
        IsFalse(IsNully (             true,  False     ));
        IsFalse(IsNully (zeroMatters: false, NullyTrue ));
        IsFalse(IsNully (             false, NullyTrue ));
        IsFalse(IsNully (zeroMatters,        NullyTrue ));
        IsFalse(IsNully (zeroMatters: true,  NullyTrue ));
        IsFalse(IsNully (             true,  NullyTrue ));
        IsTrue (IsNully (zeroMatters: false, NullyFalse));
        IsTrue (IsNully (             false, NullyFalse));
        IsFalse(IsNully (zeroMatters,        NullyFalse));
        IsFalse(IsNully (zeroMatters: true,  NullyFalse));
        IsFalse(IsNully (             true,  NullyFalse));
        IsTrue (IsNully (zeroMatters: false, NullBool  ));
        IsTrue (IsNully (             false, NullBool  ));
        IsTrue (IsNully (zeroMatters,        NullBool  ));
        IsTrue (IsNully (zeroMatters: true,  NullBool  ));
        IsTrue (IsNully (             true,  NullBool  ));
    }

    [TestMethod]
    public void Test_Bool_IsNully_ExtensionsZeroMatters()
    {
        IsFalse(true      .IsNully (                   ));
        IsFalse(true      .IsNully ( zeroMatters: false));
        IsFalse(true      .IsNully (              false));
        IsFalse(true      .IsNully ( zeroMatters       ));
        IsFalse(true      .IsNully ( zeroMatters: true ));
        IsFalse(true      .IsNully (              true ));
        IsTrue (false     .IsNully (                   ));
        IsTrue (false     .IsNully ( zeroMatters: false));
        IsTrue (false     .IsNully (              false));
        IsFalse(false     .IsNully ( zeroMatters       ));
        IsFalse(false     .IsNully ( zeroMatters: true ));
        IsFalse(false     .IsNully (              true ));
        IsFalse(True      .IsNully (                   ));
        IsFalse(True      .IsNully ( zeroMatters: false));
        IsFalse(True      .IsNully (              false));
        IsFalse(True      .IsNully ( zeroMatters       ));
        IsFalse(True      .IsNully ( zeroMatters: true ));
        IsFalse(True      .IsNully (              true ));
        IsTrue (False     .IsNully (                   ));
        IsTrue (False     .IsNully ( zeroMatters: false));
        IsTrue (False     .IsNully (              false));
        IsFalse(False     .IsNully ( zeroMatters       ));
        IsFalse(False     .IsNully ( zeroMatters: true ));
        IsFalse(False     .IsNully (              true ));
        IsFalse(NullyTrue .IsNully (                   ));
        IsFalse(NullyTrue .IsNully ( zeroMatters: false));
        IsFalse(NullyTrue .IsNully (              false));
        IsFalse(NullyTrue .IsNully ( zeroMatters       ));
        IsFalse(NullyTrue .IsNully ( zeroMatters: true ));
        IsFalse(NullyTrue .IsNully (              true ));
        IsTrue (NullyFalse.IsNully (                   ));
        IsTrue (NullyFalse.IsNully ( zeroMatters: false));
        IsTrue (NullyFalse.IsNully (              false));
        IsFalse(NullyFalse.IsNully ( zeroMatters       ));
        IsFalse(NullyFalse.IsNully ( zeroMatters: true ));
        IsFalse(NullyFalse.IsNully (              true ));
        IsTrue (NullBool  .IsNully (                   ));
        IsTrue (NullBool  .IsNully ( zeroMatters: false));
        IsTrue (NullBool  .IsNully (              false));
        IsTrue (NullBool  .IsNully ( zeroMatters       ));
        IsTrue (NullBool  .IsNully ( zeroMatters: true ));
        IsTrue (NullBool  .IsNully (              true ));
    }
}