namespace JJ.Framework.Existence.Core.SBTextCombo.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch1()
    {
        NoNullRet("",         Coalesce(Null,          Null,          Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          Null,          NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          Null,          NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(Null,          Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullSB,        Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(Null,          NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(Null,          NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(Null,          NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(Null,          NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    Null,          NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullSB,        spaceMatters: true ));
        NoNullRet(EmptySB,    Coalesce(NullyEmpty,    NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmpty,    NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullSB,        spaceMatters: true ));
        NoNullRet(EmptySB,    Coalesce(NullyEmpty,    NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmpty,    NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch3()
    {
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch4()
    {
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch5()
    {
        NoNullRet("",         Coalesce(NullSB,        Null,          Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        Null,          NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullSB,        Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet("",      $"{Coalesce(NullSB,        NullSB,        NullSB,        spaceMatters: true )}");
        NoNullRet(EmptySB,    Coalesce(NullSB,        NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullSB,        NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet("",      $"{Coalesce(NullSB,        NullyEmptySB,  NullSB,        spaceMatters: true )}");
        NoNullRet(EmptySB,    Coalesce(NullSB,        NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullSB,        NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch6()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  Null,          NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet("",      $"{Coalesce(NullyEmptySB,  NullSB,        NullSB,        spaceMatters: true )}");
        NoNullRet(EmptySB,    Coalesce(NullyEmptySB,  NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmptySB,  NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet("",      $"{Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB,        spaceMatters: true )}");
        NoNullRet(EmptySB,    Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch7()
    {
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullSB,        spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullSB,        spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch8()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyFilled,   spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullSB,        spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyEmptySB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyFilled,   spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullSB,        spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyFilled,   spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullSB,        spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyEmptySB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyFilled,   spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullSB,        spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyEmptySB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullySpaceSB,  spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilledSB, spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null,          spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace,    spaceMatters: true ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled,   spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullSB,        spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullyEmptySB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullySpaceSB,  spaceMatters: true ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullyFilledSB, spaceMatters: true ));
    }
}