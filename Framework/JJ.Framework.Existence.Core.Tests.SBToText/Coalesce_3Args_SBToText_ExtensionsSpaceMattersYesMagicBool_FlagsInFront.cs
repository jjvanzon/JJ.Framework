namespace JJ.Framework.Existence.Core.SBToText.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, EmptySB,       Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       Null       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, EmptySB,       Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       Null       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, EmptySB,       Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       Null       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }

    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullSB,        NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, EmptySB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, EmptySB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, EmptySB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, SpaceSB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, SpaceSB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters, FilledSB,      NullyFilled));
    }
}