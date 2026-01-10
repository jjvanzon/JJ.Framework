namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch1()
    {
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null,        spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        Text,        spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        NullyFilled, spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null,        spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  Text,        spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Null,        spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       Text,        spaceMatters));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyFilled, spaceMatters));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null,        spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        Text,        spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        NullyFilled, spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null,        spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  Text,        spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Null,        spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       Text,        spaceMatters));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyFilled, spaceMatters));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch3()
    {
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  FilledSB,      NullyFilled, spaceMatters));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyFilled, spaceMatters));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch5()
    {
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Null,        spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        Text,        spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        NullyFilled, spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Null,        spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  Text,        spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Null,        spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       Space,       spaceMatters));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       Text,        spaceMatters));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       NullySpace,  spaceMatters));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyFilled, spaceMatters));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch6()
    {
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Null,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Empty,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Space,       spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      Text,        spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      NullySpace,  spaceMatters));
        NoNullRet(" ",        Coalesce(SpaceSB,       FilledSB,      NullyFilled, spaceMatters));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyFilled, spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Null,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Empty,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Space,       spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Text,        spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyEmpty,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullySpace,  spaceMatters));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyFilled, spaceMatters));
    }
}