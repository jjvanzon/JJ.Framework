namespace JJ.Framework.Existence.Core.SBTextCombo.Tests;

/// <inheritdoc cref="_coalesce3argssbtextcombos" />
[TestClass]
public class Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch1()
    {
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullSB,        NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       ));
        NoNullRet("",         Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet("FilledSB", Null         .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch2()
    {
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       ));
        NoNullRet("",         NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmpty   .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch3()
    {
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullSB       ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       ));
        NoNullRet("",         NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(" ",        NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet("FilledSB", NullySpace   .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch4()
    {
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet("Filled",   NullyFilled  .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch5()
    {
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters: false, NullSB,        NullSB       )}");
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB )}");
        NoNullRet(SpaceSB,    NullSB       .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       )}");
        NoNullRet("",      $"{NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB )}");
        NoNullRet(SpaceSB,    NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch6()
    {
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch7()
    {
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet("",      $"{NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullSB       )}");
        NoNullRet(EmptySB,    NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("Filled",   NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet("",      $"{NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       )}");
        NoNullRet(EmptySB,    NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(SpaceSB,    NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }                                                         

    /// <inheritdoc cref="_coalesce3argssbtextcombos" />
    [TestMethod]
    public void Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch8()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, Null,          NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmpty,    NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpace,    NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullyFilled  ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullSB       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullyEmptySB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullySpaceSB ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilled,   NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, Null         ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullySpace   ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled  ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullSB       ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB ));
        NoNullRet(FilledSB,   NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB));
    }
}