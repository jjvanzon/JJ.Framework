namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch1()
    {
        NoNullRet("",         Null         .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Null         .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", Null         .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(EmptySB,    Null         .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Null         .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Null         .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        Null         .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   Null         .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",         Null         .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(EmptySB,    Null         .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    Null         .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Null         .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", Null         .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", Null         .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", Null         .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", Null         .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   Null         .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   Null         .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   Null         .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   Null         .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch2()
    {
        NoNullRet("",         NullyEmpty   .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(EmptySB,    NullyEmpty   .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullyEmpty   .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullyEmpty   .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(EmptySB,    NullyEmpty   .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullyEmpty   .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch3()
    {
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpace   .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch4()
    {
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch5()
    {
        NoNullRet("",         NullSB       .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{NullSB       .Coalesce( NullSB,        NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    NullSB       .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullSB       .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullSB       .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullSB       .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{NullSB       .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    NullSB       .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullSB       .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch6()
    {
        NoNullRet("",         NullyEmptySB .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce( NullSB,        NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch7()
    {
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullSB,        Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullSB,        NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_Batch8()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( Null,          NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmpty,    NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpace,    NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullyFilled,   spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullSB,        spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullyEmptySB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullySpaceSB,  spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilled,   NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullSB,        NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullSB,        NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullSB,        NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullSB,        NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyEmptySB,  NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyEmptySB,  NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyEmptySB,  NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyEmptySB,  NullyFilledSB, spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, Null,          spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, NullyEmpty,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, NullySpace,    spaceMatters       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, NullyFilled,   spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyFilledSB, NullSB,        spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyFilledSB, NullyEmptySB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyFilledSB, NullySpaceSB,  spaceMatters       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce( NullyFilledSB, NullyFilledSB, spaceMatters       ));
    }
}