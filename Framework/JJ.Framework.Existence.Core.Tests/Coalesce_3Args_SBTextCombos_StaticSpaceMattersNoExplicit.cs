namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch1()
    {
        NoNullRet("",         Coalesce(Null,          Null,          Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          Null,          NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullySpace,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullSB,        Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(Null,          NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(Null,          NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullySpace,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch3()
    {
        NoNullRet("",         Coalesce(NullySpace,    Null,          Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    Null,          NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullySpace,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullSB,        Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullSB,        NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpace,    NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmptySB,  NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpace,    NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpace,    NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch4()
    {
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch5()
    {
        NoNullRet("",         Coalesce(NullSB,        Null,          Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpace,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("",      $"{Coalesce(NullSB,        NullSB,        NullSB       , spaceMatters: false)}");
        NoNullRet("",      $"{Coalesce(NullSB,        NullSB,        NullyEmptySB , spaceMatters: false)}");
        NoNullRet(SpaceSB,    Coalesce(NullSB,        NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("",      $"{Coalesce(NullSB,        NullyEmptySB,  NullSB       , spaceMatters: false)}");
        NoNullRet("",      $"{Coalesce(NullSB,        NullyEmptySB,  NullyEmptySB , spaceMatters: false)}");
        NoNullRet(SpaceSB,    Coalesce(NullSB,        NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch6()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpace,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("",      $"{Coalesce(NullyEmptySB,  NullSB,        NullSB       , spaceMatters: false)}");
        NoNullRet(EmptySB,    Coalesce(NullyEmptySB,  NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet(SpaceSB,    Coalesce(NullyEmptySB,  NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("",      $"{Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB       , spaceMatters: false)}");
        NoNullRet(EmptySB,    Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet(SpaceSB,    Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch7()
    {
        NoNullRet("",         Coalesce(NullySpaceSB,  Null,          Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  Null,          NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpace,    Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet("",      $"{Coalesce(NullySpaceSB,  NullSB,        NullSB       , spaceMatters: false)}");
        NoNullRet(EmptySB,    Coalesce(NullySpaceSB,  NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullySpaceSB,  NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet("",      $"{Coalesce(NullySpaceSB,  NullyEmptySB,  NullSB       , spaceMatters: false)}");
        NoNullRet(EmptySB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullySpaceSB,  NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullySpaceSB,  NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_Batch8()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyFilled  , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullSB       , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyEmptySB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullySpaceSB , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled  , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullSB       , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullyEmptySB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled  , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullSB       , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmptySB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilledSB, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null         , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace   , spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled  , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullSB       , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullyEmptySB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullySpaceSB , spaceMatters: false));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullyFilledSB, spaceMatters: false));
    }
}