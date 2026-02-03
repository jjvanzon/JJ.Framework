namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch1()
    {
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("",         NullSB       .Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch2()
    {
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch3()
    {
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch4()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch5()
    {
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("",         EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch6()
    {
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("",         SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch7()
    {
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullSB,        NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false, FilledSB,      NullyFilled));
    }
}