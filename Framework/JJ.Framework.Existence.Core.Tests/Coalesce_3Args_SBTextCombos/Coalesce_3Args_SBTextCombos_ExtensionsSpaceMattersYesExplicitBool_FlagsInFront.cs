namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(EmptySB,    Null         .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Null         .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(EmptySB,    Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(EmptySB,    NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(EmptySB,    NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters: true, NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullSB       .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch8()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, Null,          NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmpty,    NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpace,    NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilled,   NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
    }
}