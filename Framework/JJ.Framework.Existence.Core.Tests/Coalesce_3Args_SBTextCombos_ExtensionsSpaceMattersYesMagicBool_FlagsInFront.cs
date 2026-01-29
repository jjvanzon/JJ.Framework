namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         Null         .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(EmptySB,    Null         .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    Null         .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(EmptySB,    Null         .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    Null         .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   Null         .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(EmptySB,    NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(EmptySB,    NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmpty   .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters, NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    NullSB       .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullSB       .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch8()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, Null,          NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmpty,    NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpace,    NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilled,   NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
    }
}