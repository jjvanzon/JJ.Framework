namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Bool_Tests
{
    const    bool  True       = true ;
    const    bool  False      = false;
    readonly bool? NullyTrue  = true ;
    readonly bool? NullyFalse = false;
    readonly bool? NullBool   = null ;

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
    public void Test_Bool_Has_ZeroMatters()
    {
        IsTrue (Has     (true                          ));
        IsTrue (Has     (true,       zeroMatters: false));
        IsTrue (Has     (true,                    false));
        IsTrue (Has     (true,       zeroMatters       ));
        IsTrue (Has     (true,       zeroMatters: true ));
        IsTrue (Has     (true,                    true ));
        IsFalse(Has     (false                         ));
        IsFalse(Has     (false,      zeroMatters: false));
        IsFalse(Has     (false,                   false));
        IsTrue (Has     (false,      zeroMatters       ));
        IsTrue (Has     (false,      zeroMatters: true ));
        IsTrue (Has     (false,                   true ));
        IsTrue (Has     (True                          ));
        IsTrue (Has     (True,       zeroMatters: false));
        IsTrue (Has     (True,                    false));
        IsTrue (Has     (True,       zeroMatters       ));
        IsTrue (Has     (True,       zeroMatters: true ));
        IsTrue (Has     (True,                    true ));
        IsFalse(Has     (False                         ));
        IsFalse(Has     (False,      zeroMatters: false));
        IsFalse(Has     (False,                   false));
        IsTrue (Has     (False,      zeroMatters       ));
        IsTrue (Has     (False,      zeroMatters: true ));
        IsTrue (Has     (False,                   true ));
        IsTrue (Has     (NullyTrue                     ));
        IsTrue (Has     (NullyTrue,  zeroMatters: false));
        IsTrue (Has     (NullyTrue,               false));
        IsTrue (Has     (NullyTrue,  zeroMatters       ));
        IsTrue (Has     (NullyTrue,  zeroMatters: true ));
        IsTrue (Has     (NullyTrue,               true ));
        IsFalse(Has     (NullyFalse                    ));
        IsFalse(Has     (NullyFalse, zeroMatters: false));
        IsFalse(Has     (NullyFalse,              false));
        IsTrue (Has     (NullyFalse, zeroMatters       ));
        IsTrue (Has     (NullyFalse, zeroMatters: true ));
        IsTrue (Has     (NullyFalse,              true ));
        IsFalse(Has     (NullBool                      ));
        IsFalse(Has     (NullBool,   zeroMatters: false));
        IsFalse(Has     (NullBool,                false));
        IsFalse(Has     (NullBool,   zeroMatters       ));
        IsFalse(Has     (NullBool,   zeroMatters: true ));
        IsFalse(Has     (NullBool,                true ));
    }

    [TestMethod]
    public void Test_Bool_FilledIn_ZeroMatters()
    {
        IsTrue (FilledIn(true                          ));
        IsTrue (FilledIn(true,       zeroMatters: false));
        IsTrue (FilledIn(true,                    false));
        IsTrue (FilledIn(true,       zeroMatters       ));
        IsTrue (FilledIn(true,       zeroMatters: true ));
        IsTrue (FilledIn(true,                    true ));
        IsFalse(FilledIn(false                         ));
        IsFalse(FilledIn(false,      zeroMatters: false));
        IsFalse(FilledIn(false,                   false));
        IsTrue (FilledIn(false,      zeroMatters       ));
        IsTrue (FilledIn(false,      zeroMatters: true ));
        IsTrue (FilledIn(false,                   true ));
        IsTrue (FilledIn(True                          ));
        IsTrue (FilledIn(True,       zeroMatters: false));
        IsTrue (FilledIn(True,                    false));
        IsTrue (FilledIn(True,       zeroMatters       ));
        IsTrue (FilledIn(True,       zeroMatters: true ));
        IsTrue (FilledIn(True,                    true ));
        IsFalse(FilledIn(False                         ));
        IsFalse(FilledIn(False,      zeroMatters: false));
        IsFalse(FilledIn(False,                   false));
        IsTrue (FilledIn(False,      zeroMatters       ));
        IsTrue (FilledIn(False,      zeroMatters: true ));
        IsTrue (FilledIn(False,                   true ));
        IsTrue (FilledIn(NullyTrue                     ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: false));
        IsTrue (FilledIn(NullyTrue,               false));
        IsTrue (FilledIn(NullyTrue,  zeroMatters       ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTrue,               true ));
        IsFalse(FilledIn(NullyFalse                    ));
        IsFalse(FilledIn(NullyFalse, zeroMatters: false));
        IsFalse(FilledIn(NullyFalse,              false));
        IsTrue (FilledIn(NullyFalse, zeroMatters       ));
        IsTrue (FilledIn(NullyFalse, zeroMatters: true ));
        IsTrue (FilledIn(NullyFalse,              true ));
        IsFalse(FilledIn(NullBool                      ));
        IsFalse(FilledIn(NullBool,   zeroMatters: false));
        IsFalse(FilledIn(NullBool,                false));
        IsFalse(FilledIn(NullBool,   zeroMatters       ));
        IsFalse(FilledIn(NullBool,   zeroMatters: true ));
        IsFalse(FilledIn(NullBool,                true ));

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
    public void Test_Bool_IsNully_ZeroMatters()
    {
        IsFalse(IsNully (true                          ));
        IsFalse(IsNully (true,       zeroMatters: false));
        IsFalse(IsNully (true,                    false));
        IsFalse(IsNully (true,       zeroMatters       ));
        IsFalse(IsNully (true,       zeroMatters: true ));
        IsFalse(IsNully (true,                    true ));
        IsTrue (IsNully (false                         ));
        IsTrue (IsNully (false,      zeroMatters: false));
        IsTrue (IsNully (false,                   false));
        IsFalse(IsNully (false,      zeroMatters       ));
        IsFalse(IsNully (false,      zeroMatters: true ));
        IsFalse(IsNully (false,                   true ));
        IsFalse(IsNully (True                          ));
        IsFalse(IsNully (True,       zeroMatters: false));
        IsFalse(IsNully (True,                    false));
        IsFalse(IsNully (True,       zeroMatters       ));
        IsFalse(IsNully (True,       zeroMatters: true ));
        IsFalse(IsNully (True,                    true ));
        IsTrue (IsNully (False                         ));
        IsTrue (IsNully (False,      zeroMatters: false));
        IsTrue (IsNully (False,                   false));
        IsFalse(IsNully (False,      zeroMatters       ));
        IsFalse(IsNully (False,      zeroMatters: true ));
        IsFalse(IsNully (False,                   true ));
        IsFalse(IsNully (NullyTrue                     ));
        IsFalse(IsNully (NullyTrue,  zeroMatters: false));
        IsFalse(IsNully (NullyTrue,               false));
        IsFalse(IsNully (NullyTrue,  zeroMatters       ));
        IsFalse(IsNully (NullyTrue,  zeroMatters: true ));
        IsFalse(IsNully (NullyTrue,               true ));
        IsTrue (IsNully (NullyFalse                    ));
        IsTrue (IsNully (NullyFalse, zeroMatters: false));
        IsTrue (IsNully (NullyFalse,              false));
        IsFalse(IsNully (NullyFalse, zeroMatters       ));
        IsFalse(IsNully (NullyFalse, zeroMatters: true ));
        IsFalse(IsNully (NullyFalse,              true ));
        IsTrue (IsNully (NullBool                      ));
        IsTrue (IsNully (NullBool,   zeroMatters: false));
        IsTrue (IsNully (NullBool,                false));
        IsTrue (IsNully (NullBool,   zeroMatters       ));
        IsTrue (IsNully (NullBool,   zeroMatters: true ));
        IsTrue (IsNully (NullBool,                true ));

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

    [TestMethod]
    public void Test_Bool_Coalesce_ZeroMatters()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool                        ));
        IsTrue (Coalesce(False, NullyTrue, NullBool,     zeroMatters: false));
      //IsTrue (Coalesce(False, NullyTrue, NullBool,                  false)); // Overload clash
        IsFalse(Coalesce(False, NullyTrue, NullBool,     zeroMatters       ));
        IsFalse(Coalesce(False, NullyTrue, NullBool,     zeroMatters: true ));
      //IsFalse(Coalesce(False, NullyTrue, NullBool,                  true )); // Overload clash

        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue                    ));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters: false));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue,              false));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters: true ));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue,              true ));

        IsFalse(NullyFalse.Coalesce(NullBool                               ));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: false));
        IsFalse(NullyFalse.Coalesce(NullBool,                         false));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: true ));
        IsFalse(NullyFalse.Coalesce(NullBool,                         true ));
    }
}