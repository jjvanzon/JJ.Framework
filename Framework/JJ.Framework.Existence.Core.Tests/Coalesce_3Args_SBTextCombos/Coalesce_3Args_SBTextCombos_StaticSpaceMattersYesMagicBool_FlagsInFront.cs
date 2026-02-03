namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         Coalesce(spaceMatters, Null,          Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, Null,          Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, Null,          NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullSB,        NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, Null,          NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, Null,          NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, Null,          NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, Null,          NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmptySB,  NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, Null,          NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, Null,          NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, Null,          NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, Null,          NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, Null,          NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, Null,          NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, Null,          NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, Null,          NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, Null,          NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, Null,          NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, Null,          NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmpty,    Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmpty,    NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullSB       ));
        NoNullRet(EmptySB,    Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmpty,    NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullSB       ));
        NoNullRet(EmptySB,    Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    Null,          NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullySpace,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullSB,        NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpace,    NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   Null,          NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmpty,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilled,   NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullSB,        NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyEmptySB,  NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyFilled,   NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters, NullSB,        NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters, NullSB,        NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullSB,        NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullSB,        NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  Null,          NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpace,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyFilled  ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullSB       ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullySpaceSB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyFilled  ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullSB       ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyFilled  ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullSB       ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch8()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, Null,          NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmpty,    NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpace,    NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilled,   NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyFilledSB));
    }
}