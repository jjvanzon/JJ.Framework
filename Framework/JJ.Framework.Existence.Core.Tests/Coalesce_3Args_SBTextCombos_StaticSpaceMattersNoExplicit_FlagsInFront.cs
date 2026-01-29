namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch1()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullySpace,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullySpace,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullySpace,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullSB,        NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullSB,        NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullSB,        NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, Null,          NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch2()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch3()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullySpace,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch4()
    {
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   Null,          NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilled,   NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullSB,        NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB,  NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch5()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpace,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullSB,        NullSB,        NullSB       )}");
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullSB,        NullSB,        NullyEmptySB )}");
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: false, NullSB,        NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullSB,        NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullSB       )}");
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullyEmptySB )}");
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch6()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch7()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront_Batch8()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Null,          NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty,    NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpace,    NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled,   NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullyFilledSB));
    }
}