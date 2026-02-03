namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullSB,        NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullSB,        NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullSB,        NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullSB,        EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters, NullSB,        EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullSB,        EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullSB,        SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullSB,        FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullyEmptySB,  NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, EmptySB,       NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, EmptySB,       NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters, EmptySB,       EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters, EmptySB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters, EmptySB,       EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, EmptySB,       FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullSB,        NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters, FilledSB,      FilledSB,      NullyFilled));
    }
}