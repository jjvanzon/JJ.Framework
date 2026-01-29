namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, Null,          Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, Null,          NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullSB,        NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, Null,          NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, Null,          NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, Null,          NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, Null,          NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, Null,          NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty,    Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullSB       ));
        NoNullRet(EmptySB,    Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmpty,    NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullSB       ));
        NoNullRet(EmptySB,    Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    Null,          NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullySpace,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullSB,        NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   Null,          NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilled,   NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullSB,        NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB,  NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: true, NullSB,        NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullSB,        NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  Null,          Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  Null,          NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullSB       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   Null         ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled,   NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyFilledSB));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  Null         ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  Null,          NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace,    NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullSB       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyFilled  ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullSB       ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullySpaceSB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyFilled  ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullSB       ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, Null         ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyFilled  ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullSB       ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(SpaceSB,    Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch8()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, Null,          NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty,    NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpace,    NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullyFilled  ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullSB       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullyEmptySB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullySpaceSB ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled,   NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyFilledSB));
    }
}