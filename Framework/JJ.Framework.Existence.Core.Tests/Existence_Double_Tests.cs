namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Double_Tests
{
    // Double

    readonly double? NullDouble            = null;
    const    double  ZeroDouble            = 0.0;
    const    double  OneDouble             = 1.0;
    const    double  TwoDouble             = 2.0;
    readonly double? NullyZeroDouble       = 0.0;
    readonly double? NullyOneDouble        = 1.0;
    readonly double? NullyTwoDouble        = 2.0;
    readonly double? NullyNaN              = Double.NaN;
    readonly double? NullyNegativeInfinity = Double.NegativeInfinity;
    readonly double? NullyPositiveInfinity = Double.PositiveInfinity;
    #if NET7_0_OR_GREATER
    readonly double? NullyNegativeZero     = Double.NegativeZero;
    #endif

    [TestMethod]
    public void Test_Double_Has()
    {
        IsFalse(Has(NullDouble));
        IsFalse(Has(ZeroDouble));
        IsTrue (Has(OneDouble));
        IsTrue (Has(TwoDouble));
        IsFalse(Has(NullyZeroDouble));
        IsTrue (Has(NullyOneDouble));
        IsTrue (Has(NullyTwoDouble));
    }

    [TestMethod]
    public void Test_Double_FilledIn()
    {
        IsFalse(FilledIn(NullDouble));
        IsFalse(FilledIn(ZeroDouble));
        IsTrue (FilledIn(OneDouble));
        IsTrue (FilledIn(TwoDouble));
        IsFalse(FilledIn(NullyZeroDouble));
        IsTrue (FilledIn(NullyOneDouble));
        IsTrue (FilledIn(NullyTwoDouble));
        IsFalse(ZeroDouble.FilledIn());
        IsTrue (OneDouble.FilledIn());
        IsTrue (TwoDouble.FilledIn());
        IsFalse(NullyZeroDouble.FilledIn());
        IsTrue (NullyOneDouble.FilledIn());
        IsTrue (NullyTwoDouble.FilledIn());
    }

    [TestMethod]
    public void Test_Double_IsNully()
    {
        IsTrue (IsNully(NullDouble));
        IsTrue (IsNully(ZeroDouble));
        IsFalse(IsNully(OneDouble));
        IsFalse(IsNully(TwoDouble));
        IsTrue (IsNully(NullyZeroDouble));
        IsFalse(IsNully(NullyOneDouble));
        IsFalse(IsNully(NullyTwoDouble));
        IsTrue (ZeroDouble.IsNully());
        IsFalse(OneDouble.IsNully());
        IsFalse(TwoDouble.IsNully());
        IsTrue (NullyZeroDouble.IsNully());
        IsFalse(NullyOneDouble.IsNully());
        IsFalse(NullyTwoDouble.IsNully());
    }
    
    [TestMethod]
    public void Test_Double_Has_ZeroMatters()
    {
        IsFalse(Has     (NullDouble                         ));
        IsFalse(Has     (NullDouble,      zeroMatters: false));
        IsFalse(Has     (NullDouble,                   false));
        IsFalse(Has     (NullDouble,      zeroMatters       ));
        IsFalse(Has     (NullDouble,      zeroMatters: true ));
        IsFalse(Has     (NullDouble,                   true ));
        IsFalse(Has     (ZeroDouble                         ));
        IsFalse(Has     (ZeroDouble,      zeroMatters: false));
        IsFalse(Has     (ZeroDouble,                   false));
        IsTrue (Has     (ZeroDouble,      zeroMatters       ));
        IsTrue (Has     (ZeroDouble,      zeroMatters: true ));
        IsTrue (Has     (ZeroDouble,                   true ));
        IsTrue (Has     (OneDouble                          ));
        IsTrue (Has     (OneDouble,       zeroMatters: false));
        IsTrue (Has     (OneDouble,                    false));
        IsTrue (Has     (OneDouble,       zeroMatters       ));
        IsTrue (Has     (OneDouble,       zeroMatters: true ));
        IsTrue (Has     (OneDouble,                    true ));
        IsTrue (Has     (TwoDouble                          ));
        IsTrue (Has     (TwoDouble,       zeroMatters: false));
        IsTrue (Has     (TwoDouble,                    false));
        IsTrue (Has     (TwoDouble,       zeroMatters       ));
        IsTrue (Has     (TwoDouble,       zeroMatters: true ));
        IsTrue (Has     (TwoDouble,                    true ));
        IsFalse(Has     (NullyZeroDouble                    ));
        IsFalse(Has     (NullyZeroDouble, zeroMatters: false));
        IsFalse(Has     (NullyZeroDouble,              false));
        IsTrue (Has     (NullyZeroDouble, zeroMatters       ));
        IsTrue (Has     (NullyZeroDouble, zeroMatters: true ));
        IsTrue (Has     (NullyZeroDouble,              true ));
        IsTrue (Has     (NullyOneDouble                     ));
        IsTrue (Has     (NullyOneDouble,  zeroMatters: false));
        IsTrue (Has     (NullyOneDouble,               false));
        IsTrue (Has     (NullyOneDouble,  zeroMatters       ));
        IsTrue (Has     (NullyOneDouble,  zeroMatters: true ));
        IsTrue (Has     (NullyOneDouble,               true ));
        IsTrue (Has     (NullyTwoDouble                     ));
        IsTrue (Has     (NullyTwoDouble,  zeroMatters: false));
        IsTrue (Has     (NullyTwoDouble,               false));
        IsTrue (Has     (NullyTwoDouble,  zeroMatters       ));
        IsTrue (Has     (NullyTwoDouble,  zeroMatters: true ));
        IsTrue (Has     (NullyTwoDouble,               true ));
    }
    
    [TestMethod]
    public void Test_Double_FilledIn_ZeroMatters_Static()
    {
        IsFalse(FilledIn(NullDouble                         ));
        IsFalse(FilledIn(NullDouble,      zeroMatters: false));
        IsFalse(FilledIn(NullDouble,                   false));
        IsFalse(FilledIn(NullDouble,      zeroMatters       ));
        IsFalse(FilledIn(NullDouble,      zeroMatters: true ));
        IsFalse(FilledIn(NullDouble,                   true ));
        IsFalse(FilledIn(ZeroDouble                         ));
        IsFalse(FilledIn(ZeroDouble,      zeroMatters: false));
        IsFalse(FilledIn(ZeroDouble,                   false));
        IsTrue (FilledIn(ZeroDouble,      zeroMatters       ));
        IsTrue (FilledIn(ZeroDouble,      zeroMatters: true ));
        IsTrue (FilledIn(ZeroDouble,                   true ));
        IsTrue (FilledIn(OneDouble                          ));
        IsTrue (FilledIn(OneDouble,       zeroMatters: false));
        IsTrue (FilledIn(OneDouble,                    false));
        IsTrue (FilledIn(OneDouble,       zeroMatters       ));
        IsTrue (FilledIn(OneDouble,       zeroMatters: true ));
        IsTrue (FilledIn(OneDouble,                    true ));
        IsTrue (FilledIn(TwoDouble                          ));
        IsTrue (FilledIn(TwoDouble,       zeroMatters: false));
        IsTrue (FilledIn(TwoDouble,                    false));
        IsTrue (FilledIn(TwoDouble,       zeroMatters       ));
        IsTrue (FilledIn(TwoDouble,       zeroMatters: true ));
        IsTrue (FilledIn(TwoDouble,                    true ));
        IsFalse(FilledIn(NullyZeroDouble                    ));
        IsFalse(FilledIn(NullyZeroDouble, zeroMatters: false));
        IsFalse(FilledIn(NullyZeroDouble,              false));
        IsTrue (FilledIn(NullyZeroDouble, zeroMatters       ));
        IsTrue (FilledIn(NullyZeroDouble, zeroMatters: true ));
        IsTrue (FilledIn(NullyZeroDouble,              true ));
        IsTrue (FilledIn(NullyOneDouble                     ));
        IsTrue (FilledIn(NullyOneDouble,  zeroMatters: false));
        IsTrue (FilledIn(NullyOneDouble,               false));
        IsTrue (FilledIn(NullyOneDouble,  zeroMatters       ));
        IsTrue (FilledIn(NullyOneDouble,  zeroMatters: true ));
        IsTrue (FilledIn(NullyOneDouble,               true ));
        IsTrue (FilledIn(NullyTwoDouble                     ));
        IsTrue (FilledIn(NullyTwoDouble,  zeroMatters: false));
        IsTrue (FilledIn(NullyTwoDouble,               false));
        IsTrue (FilledIn(NullyTwoDouble,  zeroMatters       ));
        IsTrue (FilledIn(NullyTwoDouble,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTwoDouble,               true ));
    }
    
    [TestMethod]
    public void Test_Double_FilledIn_ZeroMatters_Extensions()
    {
        IsFalse(NullDouble     .FilledIn(                   ));
        IsFalse(NullDouble     .FilledIn( zeroMatters: false));
        IsFalse(NullDouble     .FilledIn(              false));
        IsFalse(NullDouble     .FilledIn( zeroMatters       ));
        IsFalse(NullDouble     .FilledIn( zeroMatters: true ));
        IsFalse(NullDouble     .FilledIn(              true ));
        IsFalse(ZeroDouble     .FilledIn(                   ));
        IsFalse(ZeroDouble     .FilledIn( zeroMatters: false));
        IsFalse(ZeroDouble     .FilledIn(              false));
        IsTrue (ZeroDouble     .FilledIn( zeroMatters       ));
        IsTrue (ZeroDouble     .FilledIn( zeroMatters: true ));
        IsTrue (ZeroDouble     .FilledIn(              true ));
        IsTrue (OneDouble      .FilledIn(                   ));
        IsTrue (OneDouble      .FilledIn( zeroMatters: false));
        IsTrue (OneDouble      .FilledIn(              false));
        IsTrue (OneDouble      .FilledIn( zeroMatters       ));
        IsTrue (OneDouble      .FilledIn( zeroMatters: true ));
        IsTrue (OneDouble      .FilledIn(              true ));
        IsTrue (TwoDouble      .FilledIn(                   ));
        IsTrue (TwoDouble      .FilledIn( zeroMatters: false));
        IsTrue (TwoDouble      .FilledIn(              false));
        IsTrue (TwoDouble      .FilledIn( zeroMatters       ));
        IsTrue (TwoDouble      .FilledIn( zeroMatters: true ));
        IsTrue (TwoDouble      .FilledIn(              true ));
        IsFalse(NullyZeroDouble.FilledIn(                   ));
        IsFalse(NullyZeroDouble.FilledIn( zeroMatters: false));
        IsFalse(NullyZeroDouble.FilledIn(              false));
        IsTrue (NullyZeroDouble.FilledIn( zeroMatters       ));
        IsTrue (NullyZeroDouble.FilledIn( zeroMatters: true ));
        IsTrue (NullyZeroDouble.FilledIn(              true ));
        IsTrue (NullyOneDouble .FilledIn(                   ));
        IsTrue (NullyOneDouble .FilledIn( zeroMatters: false));
        IsTrue (NullyOneDouble .FilledIn(              false));
        IsTrue (NullyOneDouble .FilledIn( zeroMatters       ));
        IsTrue (NullyOneDouble .FilledIn( zeroMatters: true ));
        IsTrue (NullyOneDouble .FilledIn(              true ));
        IsTrue (NullyTwoDouble .FilledIn(                   ));
        IsTrue (NullyTwoDouble .FilledIn( zeroMatters: false));
        IsTrue (NullyTwoDouble .FilledIn(              false));
        IsTrue (NullyTwoDouble .FilledIn( zeroMatters       ));
        IsTrue (NullyTwoDouble .FilledIn( zeroMatters: true ));
        IsTrue (NullyTwoDouble .FilledIn(              true ));
    }

    [TestMethod]
    public void Test_Double_IsNully_ZeroMatters_Static()
    {
        IsTrue (IsNully (NullDouble                         ));
        IsTrue (IsNully (NullDouble,      zeroMatters: false));
        IsTrue (IsNully (NullDouble,                   false));
        IsTrue (IsNully (NullDouble,      zeroMatters       ));
        IsTrue (IsNully (NullDouble,      zeroMatters: true ));
        IsTrue (IsNully (NullDouble,                   true ));
        IsTrue (IsNully (ZeroDouble                         ));
        IsTrue (IsNully (ZeroDouble,      zeroMatters: false));
        IsTrue (IsNully (ZeroDouble,                   false));
        IsFalse(IsNully (ZeroDouble,      zeroMatters       ));
        IsFalse(IsNully (ZeroDouble,      zeroMatters: true ));
        IsFalse(IsNully (ZeroDouble,                   true ));
        IsFalse(IsNully (OneDouble                          ));
        IsFalse(IsNully (OneDouble,       zeroMatters: false));
        IsFalse(IsNully (OneDouble,                    false));
        IsFalse(IsNully (OneDouble,       zeroMatters       ));
        IsFalse(IsNully (OneDouble,       zeroMatters: true ));
        IsFalse(IsNully (OneDouble,                    true ));
        IsFalse(IsNully (TwoDouble                          ));
        IsFalse(IsNully (TwoDouble,       zeroMatters: false));
        IsFalse(IsNully (TwoDouble,                    false));
        IsFalse(IsNully (TwoDouble,       zeroMatters       ));
        IsFalse(IsNully (TwoDouble,       zeroMatters: true ));
        IsFalse(IsNully (TwoDouble,                    true ));
        IsTrue (IsNully (NullyZeroDouble                    ));
        IsTrue (IsNully (NullyZeroDouble, zeroMatters: false));
        IsTrue (IsNully (NullyZeroDouble,              false));
        IsFalse(IsNully (NullyZeroDouble, zeroMatters       ));
        IsFalse(IsNully (NullyZeroDouble, zeroMatters: true ));
        IsFalse(IsNully (NullyZeroDouble,              true ));
        IsFalse(IsNully (NullyOneDouble                     ));
        IsFalse(IsNully (NullyOneDouble,  zeroMatters: false));
        IsFalse(IsNully (NullyOneDouble,               false));
        IsFalse(IsNully (NullyOneDouble,  zeroMatters       ));
        IsFalse(IsNully (NullyOneDouble,  zeroMatters: true ));
        IsFalse(IsNully (NullyOneDouble,               true ));
        IsFalse(IsNully (NullyTwoDouble                     ));
        IsFalse(IsNully (NullyTwoDouble,  zeroMatters: false));
        IsFalse(IsNully (NullyTwoDouble,               false));
        IsFalse(IsNully (NullyTwoDouble,  zeroMatters       ));
        IsFalse(IsNully (NullyTwoDouble,  zeroMatters: true ));
        IsFalse(IsNully (NullyTwoDouble,               true ));
    }
    
    [TestMethod]
    public void Test_Double_IsNully_ZeroMatters_Extensions()
    {
        IsTrue (NullDouble     .IsNully (                   ));
        IsTrue (NullDouble     .IsNully ( zeroMatters: false));
        IsTrue (NullDouble     .IsNully (              false));
        IsTrue (NullDouble     .IsNully ( zeroMatters       ));
        IsTrue (NullDouble     .IsNully ( zeroMatters: true ));
        IsTrue (NullDouble     .IsNully (              true ));
        IsTrue (ZeroDouble     .IsNully (                   ));
        IsTrue (ZeroDouble     .IsNully ( zeroMatters: false));
        IsTrue (ZeroDouble     .IsNully (              false));
        IsFalse(ZeroDouble     .IsNully ( zeroMatters       ));
        IsFalse(ZeroDouble     .IsNully ( zeroMatters: true ));
        IsFalse(ZeroDouble     .IsNully (              true ));
        IsFalse(OneDouble      .IsNully (                   ));
        IsFalse(OneDouble      .IsNully ( zeroMatters: false));
        IsFalse(OneDouble      .IsNully (              false));
        IsFalse(OneDouble      .IsNully ( zeroMatters       ));
        IsFalse(OneDouble      .IsNully ( zeroMatters: true ));
        IsFalse(OneDouble      .IsNully (              true ));
        IsFalse(TwoDouble      .IsNully (                   ));
        IsFalse(TwoDouble      .IsNully ( zeroMatters: false));
        IsFalse(TwoDouble      .IsNully (              false));
        IsFalse(TwoDouble      .IsNully ( zeroMatters       ));
        IsFalse(TwoDouble      .IsNully ( zeroMatters: true ));
        IsFalse(TwoDouble      .IsNully (              true ));
        IsTrue (NullyZeroDouble.IsNully (                   ));
        IsTrue (NullyZeroDouble.IsNully ( zeroMatters: false));
        IsTrue (NullyZeroDouble.IsNully (              false));
        IsFalse(NullyZeroDouble.IsNully ( zeroMatters       ));
        IsFalse(NullyZeroDouble.IsNully ( zeroMatters: true ));
        IsFalse(NullyZeroDouble.IsNully (              true ));
        IsFalse(NullyOneDouble .IsNully (                   ));
        IsFalse(NullyOneDouble .IsNully ( zeroMatters: false));
        IsFalse(NullyOneDouble .IsNully (              false));
        IsFalse(NullyOneDouble .IsNully ( zeroMatters       ));
        IsFalse(NullyOneDouble .IsNully ( zeroMatters: true ));
        IsFalse(NullyOneDouble .IsNully (              true ));
        IsFalse(NullyTwoDouble .IsNully (                   ));
        IsFalse(NullyTwoDouble .IsNully ( zeroMatters: false));
        IsFalse(NullyTwoDouble .IsNully (              false));
        IsFalse(NullyTwoDouble .IsNully ( zeroMatters       ));
        IsFalse(NullyTwoDouble .IsNully ( zeroMatters: true ));
        IsFalse(NullyTwoDouble .IsNully (              true ));
    }

    [TestMethod]
    public void Double_Coalesce_Tests()
    {
        // Static 4-Arg/Variadic
        NoNullRet(OneDouble, Coalesce(NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        // Extension 3-Arg
        NoNullRet(OneDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble));
        // Chaining
        NoNullRet(TwoDouble, Coalesce(NullDouble, ZeroDouble).Coalesce(TwoDouble).Coalesce(NullyOneDouble));
    }

    [TestMethod]
    public void Double_Coalesce_ZeroMatters_Tests()
    {
        // Static 4-Arg/Variadic
        NoNullRet(OneDouble,  Coalesce(                    NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(OneDouble,  Coalesce(zeroMatters: false, NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(OneDouble,  Coalesce(             false, NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(ZeroDouble, Coalesce(zeroMatters,        NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(ZeroDouble, Coalesce(zeroMatters: true,  NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(ZeroDouble, Coalesce(             true,  NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));

        // Extension 3-Arg
        NoNullRet(OneDouble,  NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble                    ));
        NoNullRet(OneDouble,  NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble, zeroMatters: false));
        NoNullRet(OneDouble,  NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble,              false));
        NoNullRet(ZeroDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble, zeroMatters       ));
        NoNullRet(ZeroDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble, zeroMatters: true ));
        NoNullRet(ZeroDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble,              true ));
        NoNullRet(OneDouble,  NullyZeroDouble.Coalesce(                    NullyOneDouble, OneDouble));
        NoNullRet(OneDouble,  NullyZeroDouble.Coalesce(zeroMatters: false, NullyOneDouble, OneDouble));
        NoNullRet(OneDouble,  NullyZeroDouble.Coalesce(             false, NullyOneDouble, OneDouble));
        NoNullRet(ZeroDouble, NullyZeroDouble.Coalesce(zeroMatters,        NullyOneDouble, OneDouble));
        NoNullRet(ZeroDouble, NullyZeroDouble.Coalesce(zeroMatters: true,  NullyOneDouble, OneDouble));
        NoNullRet(ZeroDouble, NullyZeroDouble.Coalesce(             true,  NullyOneDouble, OneDouble));

        // Chaining
        NoNullRet(TwoDouble,  Coalesce(NullDouble, ZeroDouble                    ).Coalesce(TwoDouble                    ).Coalesce(NullyOneDouble                    ));
        NoNullRet(TwoDouble,  Coalesce(NullDouble, ZeroDouble, zeroMatters: false).Coalesce(TwoDouble, zeroMatters: false).Coalesce(NullyOneDouble, zeroMatters: false));
        NoNullRet(TwoDouble,  Coalesce(NullDouble, ZeroDouble,              false).Coalesce(TwoDouble,              false).Coalesce(NullyOneDouble,              false));
        NoNullRet(ZeroDouble, Coalesce(NullDouble, ZeroDouble, zeroMatters       ).Coalesce(TwoDouble, zeroMatters       ).Coalesce(NullyOneDouble, zeroMatters       ));
        NoNullRet(ZeroDouble, Coalesce(NullDouble, ZeroDouble, zeroMatters: true ).Coalesce(TwoDouble, zeroMatters: true ).Coalesce(NullyOneDouble, zeroMatters: true ));
        NoNullRet(ZeroDouble, Coalesce(NullDouble, ZeroDouble,              true ).Coalesce(TwoDouble,              true ).Coalesce(NullyOneDouble,              true ));
        NoNullRet(TwoDouble,  Coalesce(                    NullDouble, ZeroDouble).Coalesce(                    TwoDouble).Coalesce(                    NullyOneDouble));
        NoNullRet(TwoDouble,  Coalesce(zeroMatters: false, NullDouble, ZeroDouble).Coalesce(zeroMatters: false, TwoDouble).Coalesce(zeroMatters: false, NullyOneDouble));
        NoNullRet(TwoDouble,  Coalesce(             false, NullDouble, ZeroDouble).Coalesce(             false, TwoDouble).Coalesce(             false, NullyOneDouble));
        NoNullRet(ZeroDouble, Coalesce(zeroMatters,        NullDouble, ZeroDouble).Coalesce(zeroMatters,        TwoDouble).Coalesce(zeroMatters,        NullyOneDouble));
        NoNullRet(ZeroDouble, Coalesce(zeroMatters: true,  NullDouble, ZeroDouble).Coalesce(zeroMatters: true,  TwoDouble).Coalesce(zeroMatters: true,  NullyOneDouble));
        NoNullRet(ZeroDouble, Coalesce(             true,  NullDouble, ZeroDouble).Coalesce(             true,  TwoDouble).Coalesce(             true,  NullyOneDouble));
    }

    [TestMethod]
    public void BUG_Double_SpecialValue_ConsideredFilledIn()
    {
        // TODO: Make these special values count as not filled in.
        //IsFalse  (Has(NaN));
        //IsFalse  (Has(NullyNaN));
        //IsFalse  (Has(PositiveInfinity));
        //IsFalse  (Has(NullyPositiveInfinity));
        //IsFalse  (Has(NegativeInfinity));
        //IsFalse  (Has(NullyNegativeInfinity));
        //NoNullRet(1, Coalesce(NaN, PositiveInfinity, NegativeInfinity, NegativeZero, ZeroDouble, OneDouble, TwoDouble));
        IsTrue   (Has(Double.NaN));
        IsTrue   (Has(NullyNaN));
        IsTrue   (Has(Double.PositiveInfinity));
        IsTrue   (Has(NullyPositiveInfinity));
        IsTrue   (Has(Double.NegativeInfinity));
        IsTrue   (Has(NullyNegativeInfinity));
        IsFalse  (Has(ZeroDouble));
        IsFalse  (Has(NullyZeroDouble));
        IsFalse  (Has(0.0));
        NoNullRet(Double.NaN, Coalesce(Double.NaN, Double.PositiveInfinity, Double.NegativeInfinity, ZeroDouble, OneDouble, TwoDouble));
        #if NET7_0_OR_GREATER
        IsFalse(Has(Double.NegativeZero));
        IsFalse(Has(NullyNegativeZero));
        #endif
    }
}