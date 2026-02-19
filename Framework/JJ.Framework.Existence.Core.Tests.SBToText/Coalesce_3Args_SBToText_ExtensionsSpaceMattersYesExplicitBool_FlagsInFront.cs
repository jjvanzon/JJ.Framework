namespace JJ.Framework.Existence.Core.SBToText.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, EmptySB,       Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       Null       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       Null       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, EmptySB,       Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       Null       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, EmptySB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, EmptySB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, EmptySB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullyFilled));
    }
}