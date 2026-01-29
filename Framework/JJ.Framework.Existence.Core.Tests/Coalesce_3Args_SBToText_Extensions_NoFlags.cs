namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_Extensions_NoFlags : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch1()
    {
        NoNullRet("",         NullSB       .Coalesce( NullSB,        Null       ));
        NoNullRet("",         NullSB       .Coalesce( NullSB,        Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce( NullSB,        Space      ));
        NoNullRet(Text,       NullSB       .Coalesce( NullSB,        Text       ));
        NoNullRet("",         NullSB       .Coalesce( NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce( NullSB,        NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce( NullSB,        NullyFilled));
        NoNullRet("",         NullSB       .Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce( NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullSB       .Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("",         NullSB       .Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("",         NullSB       .Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("",         NullSB       .Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpaceSB,  Space      ));
        NoNullRet(Text,       NullSB       .Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("",         NullSB       .Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("",         NullSB       .Coalesce( EmptySB,       Null       ));
        NoNullRet("",         NullSB       .Coalesce( EmptySB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce( EmptySB,       Space      ));
        NoNullRet(Text,       NullSB       .Coalesce( EmptySB,       Text       ));
        NoNullRet("",         NullSB       .Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce( EmptySB,       NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce( EmptySB,       NullyFilled));
        NoNullRet("",         NullSB       .Coalesce( SpaceSB,       Null       ));
        NoNullRet("",         NullSB       .Coalesce( SpaceSB,       Empty      ));
        NoNullRet(" ",        NullSB       .Coalesce( SpaceSB,       Space      ));
        NoNullRet(Text,       NullSB       .Coalesce( SpaceSB,       Text       ));
        NoNullRet("",         NullSB       .Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullSB       .Coalesce( SpaceSB,       NullySpace ));
        NoNullRet(Text,       NullSB       .Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullSB       .Coalesce( FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch2()
    {
        NoNullRet("",         NullyEmptySB .Coalesce( NullSB,        Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullSB,        Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullSB,        Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( NullSB,        Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullSB,        NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( NullSB,        NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpaceSB,  Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce( EmptySB,       Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce( EmptySB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( EmptySB,       Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( EmptySB,       Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( EmptySB,       NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( EmptySB,       NullyFilled));
        NoNullRet("",         NullyEmptySB .Coalesce( SpaceSB,       Null       ));
        NoNullRet("",         NullyEmptySB .Coalesce( SpaceSB,       Empty      ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( SpaceSB,       Space      ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( SpaceSB,       Text       ));
        NoNullRet("",         NullyEmptySB .Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullyEmptySB .Coalesce( SpaceSB,       NullySpace ));
        NoNullRet(Text,       NullyEmptySB .Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyEmptySB .Coalesce( FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch3()
    {
        NoNullRet("",         NullySpaceSB .Coalesce( NullSB,        Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce( NullSB,        Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullSB,        Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( NullSB,        Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce( NullSB,        NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullSB,        NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( NullSB,        NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmptySB,  Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpaceSB,  Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce( EmptySB,       Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce( EmptySB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( EmptySB,       Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( EmptySB,       Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( EmptySB,       NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( EmptySB,       NullyFilled));
        NoNullRet("",         NullySpaceSB .Coalesce( SpaceSB,       Null       ));
        NoNullRet("",         NullySpaceSB .Coalesce( SpaceSB,       Empty      ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( SpaceSB,       Space      ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( SpaceSB,       Text       ));
        NoNullRet("",         NullySpaceSB .Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        NullySpaceSB .Coalesce( SpaceSB,       NullySpace ));
        NoNullRet(Text,       NullySpaceSB .Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullySpaceSB .Coalesce( FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch4()
    {
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullSB,        NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( EmptySB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce( FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch5()
    {
        NoNullRet("",         EmptySB      .Coalesce( NullSB,        Null       ));
        NoNullRet("",         EmptySB      .Coalesce( NullSB,        Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce( NullSB,        Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce( NullSB,        Text       ));
        NoNullRet("",         EmptySB      .Coalesce( NullSB,        NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce( NullSB,        NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce( NullSB,        NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("",         EmptySB      .Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce( NullyEmptySB,  Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("",         EmptySB      .Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("",         EmptySB      .Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce( NullySpaceSB,  Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("",         EmptySB      .Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce( EmptySB,       Null       ));
        NoNullRet("",         EmptySB      .Coalesce( EmptySB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce( EmptySB,       Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce( EmptySB,       Text       ));
        NoNullRet("",         EmptySB      .Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce( EmptySB,       NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce( EmptySB,       NullyFilled));
        NoNullRet("",         EmptySB      .Coalesce( SpaceSB,       Null       ));
        NoNullRet("",         EmptySB      .Coalesce( SpaceSB,       Empty      ));
        NoNullRet(" ",        EmptySB      .Coalesce( SpaceSB,       Space      ));
        NoNullRet(Text,       EmptySB      .Coalesce( SpaceSB,       Text       ));
        NoNullRet("",         EmptySB      .Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        EmptySB      .Coalesce( SpaceSB,       NullySpace ));
        NoNullRet(Text,       EmptySB      .Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", EmptySB      .Coalesce( FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch6()
    {
        NoNullRet("",         SpaceSB      .Coalesce( NullSB,        Null       ));
        NoNullRet("",         SpaceSB      .Coalesce( NullSB,        Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce( NullSB,        Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce( NullSB,        Text       ));
        NoNullRet("",         SpaceSB      .Coalesce( NullSB,        NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce( NullSB,        NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce( NullSB,        NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("",         SpaceSB      .Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce( NullyEmptySB,  Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("",         SpaceSB      .Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("",         SpaceSB      .Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce( NullySpaceSB,  Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("",         SpaceSB      .Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce( EmptySB,       Null       ));
        NoNullRet("",         SpaceSB      .Coalesce( EmptySB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce( EmptySB,       Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce( EmptySB,       Text       ));
        NoNullRet("",         SpaceSB      .Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce( EmptySB,       NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce( EmptySB,       NullyFilled));
        NoNullRet("",         SpaceSB      .Coalesce( SpaceSB,       Null       ));
        NoNullRet("",         SpaceSB      .Coalesce( SpaceSB,       Empty      ));
        NoNullRet(" ",        SpaceSB      .Coalesce( SpaceSB,       Space      ));
        NoNullRet(Text,       SpaceSB      .Coalesce( SpaceSB,       Text       ));
        NoNullRet("",         SpaceSB      .Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        SpaceSB      .Coalesce( SpaceSB,       NullySpace ));
        NoNullRet(Text,       SpaceSB      .Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", SpaceSB      .Coalesce( FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Extensions_NoFlags_Batch7()
    {
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullSB,        NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( EmptySB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      Null       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      Empty      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      Space      ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      Text       ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      NullySpace ));
        NoNullRet("FilledSB", FilledSB     .Coalesce( FilledSB,      NullyFilled));
    }
}