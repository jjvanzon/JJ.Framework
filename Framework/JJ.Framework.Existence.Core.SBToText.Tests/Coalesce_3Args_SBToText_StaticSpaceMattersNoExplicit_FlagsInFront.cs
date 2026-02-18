namespace JJ.Framework.Existence.Core.SBToText.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch1()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullSB,        SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullSB,        SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullSB,        FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch2()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullyEmptySB,  SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyEmptySB,  FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch3()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullySpaceSB,  SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullySpaceSB,  FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch5()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, EmptySB,       SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, EmptySB,       FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch6()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullSB,        Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       NullSB,        Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(spaceMatters: false, SpaceSB,       SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, SpaceSB,       FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      FilledSB,      NullyFilled));
    }
}