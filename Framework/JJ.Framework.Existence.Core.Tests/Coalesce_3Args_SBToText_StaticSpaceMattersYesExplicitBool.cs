namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch1()
    {
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyFilled, spaceMatters: true));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyFilled, spaceMatters: true));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch3()
    {
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      NullyFilled, spaceMatters: true));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyFilled, spaceMatters: true));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch5()
    {
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Null,        spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       Space,       spaceMatters: true));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       Text,        spaceMatters: true));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyFilled, spaceMatters: true));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch6()
    {
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Null,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Empty,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Space,       spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Text,        spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      NullyFilled, spaceMatters: true));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyFilled, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Null,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Empty,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Space,       spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Text,        spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyEmpty,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullySpace,  spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyFilled, spaceMatters: true));
    }
}