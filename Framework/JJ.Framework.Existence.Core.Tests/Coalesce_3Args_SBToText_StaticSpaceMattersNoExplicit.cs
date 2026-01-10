namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch1()
    {
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullSB,        SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullSB,        SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyFilled, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullyEmptySB,  SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyFilled, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch3()
    {
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullSB,        Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  EmptySB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  EmptySB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  EmptySB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(NullySpaceSB,  SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      NullyFilled, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyFilled, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch5()
    {
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(EmptySB,       SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(EmptySB,       SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyFilled, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch6()
    {
        NoNullRet("",         Coalesce(SpaceSB,       NullSB,        Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullSB,        Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullSB,        Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       EmptySB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       EmptySB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       EmptySB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Space,       spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("",         Coalesce(SpaceSB,       SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,       Coalesce(SpaceSB,       SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      NullyFilled, spaceMatters: false));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyFilled, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Null,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Empty,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Space,       spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Text,        spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyEmpty,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullySpace,  spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyFilled, spaceMatters: false));
    }
}