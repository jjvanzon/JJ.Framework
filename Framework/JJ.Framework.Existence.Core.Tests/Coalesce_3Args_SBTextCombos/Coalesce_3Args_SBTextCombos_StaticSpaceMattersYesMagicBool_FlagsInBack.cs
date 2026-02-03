namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch1()
    {
        NoNullRet("",         Coalesce(Null,          Null,          Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(Null,          Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(Null,          NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(Null,          NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(Null,          NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(Null,          NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(Null,          NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(Null,          NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(Null,          NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(EmptySB,    Coalesce(NullyEmpty,    NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmpty,    NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmpty,    NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmpty,    NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmpty,    NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(EmptySB,    Coalesce(NullyEmpty,    NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmpty,    NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty,    NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmpty,    NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch3()
    {
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpace,    NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch4()
    {
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyFilled,   NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch5()
    {
        NoNullRet("",         Coalesce(NullSB,        Null,          Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{Coalesce(NullSB,        NullSB,        NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    Coalesce(NullSB,        NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullSB,        NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullSB,        NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{Coalesce(NullSB,        NullyEmptySB,  NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    Coalesce(NullSB,        NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullSB,        NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullSB,        NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch6()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{Coalesce(NullyEmptySB,  NullSB,        NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    Coalesce(NullyEmptySB,  NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmptySB,  NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch7()
    {
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch8()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Coalesce(NullyFilledSB, NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }
}