namespace JJ.Framework.Existence.Core.SBToText.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullSB,        NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullSB,        EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, EmptySB,       NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, EmptySB,       EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullyFilled));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      Null       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      Space      ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      Text       ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullySpace ));
        NoNullRet(" ",        Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullyFilled));
    }
}