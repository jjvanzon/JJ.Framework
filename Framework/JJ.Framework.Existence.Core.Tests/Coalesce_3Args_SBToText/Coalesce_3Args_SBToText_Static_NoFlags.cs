namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_coalesce3argssbtotext" />
[TestClass]
public class Coalesce_3Args_SBToText_Static_NoFlags : TestBase
{
    private const string? NullyFilled = NullyFilledText;
    private const string? Null = NullText;
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch1()
    {
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Null       ));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        Text       ));
        NoNullRet("",         Coalesce(NullSB,        NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullSB,        NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(NullSB,        NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(NullSB,        NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullSB,        NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(NullSB,        NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(NullSB,        NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(NullSB,        NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(NullSB,        NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(NullSB,        NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullSB,        NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(NullSB,        NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullSB,        NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Null       ));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       Text       ));
        NoNullRet("",         Coalesce(NullSB,        EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullSB,        EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(NullSB,        EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(NullSB,        SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(NullSB,        SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(NullSB,        SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(NullSB,        SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullSB,        SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(NullSB,        SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullSB,        FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch2()
    {
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Null       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        Text       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Null       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       Text       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(NullyEmptySB,  SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(NullyEmptySB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullyEmptySB,  SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(NullyEmptySB,  SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyEmptySB,  FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch3()
    {
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        Null       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullSB,        Text       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(NullySpaceSB,  EmptySB,       Null       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  EmptySB,       Text       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(NullySpaceSB,  SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(NullySpaceSB,  SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(NullySpaceSB,  SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(NullySpaceSB,  SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullySpaceSB,  FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch4()
    {
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB, FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch5()
    {
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Null       ));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        Text       ));
        NoNullRet("",         Coalesce(EmptySB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(EmptySB,       NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(EmptySB,       NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(EmptySB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(EmptySB,       NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(EmptySB,       NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(EmptySB,       NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(EmptySB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(EmptySB,       NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(EmptySB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(EmptySB,       NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(EmptySB,       NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Null       ));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       Text       ));
        NoNullRet("",         Coalesce(EmptySB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(EmptySB,       EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(EmptySB,       EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(EmptySB,       SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(EmptySB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(EmptySB,       SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(EmptySB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(EmptySB,       SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(EmptySB,       SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(EmptySB,       FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch6()
    {
        NoNullRet("",         Coalesce(SpaceSB,       NullSB,        Null       ));
        NoNullRet("",         Coalesce(SpaceSB,       NullSB,        Empty      ));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        Space      ));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullSB,        Text       ));
        NoNullRet("",         Coalesce(SpaceSB,       NullSB,        NullyEmpty ));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullSB,        NullySpace ));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullSB,        NullyFilled));
        NoNullRet("",         Coalesce(SpaceSB,       NullyEmptySB,  Null       ));
        NoNullRet("",         Coalesce(SpaceSB,       NullyEmptySB,  Empty      ));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  Space      ));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullyEmptySB,  Text       ));
        NoNullRet("",         Coalesce(SpaceSB,       NullyEmptySB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullyEmptySB,  NullySpace ));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullyEmptySB,  NullyFilled));
        NoNullRet("",         Coalesce(SpaceSB,       NullySpaceSB,  Null       ));
        NoNullRet("",         Coalesce(SpaceSB,       NullySpaceSB,  Empty      ));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  Space      ));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullySpaceSB,  Text       ));
        NoNullRet("",         Coalesce(SpaceSB,       NullySpaceSB,  NullyEmpty ));
        NoNullRet(" ",        Coalesce(SpaceSB,       NullySpaceSB,  NullySpace ));
        NoNullRet(Text,       Coalesce(SpaceSB,       NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       NullyFilledSB, NullyFilled));
        NoNullRet("",         Coalesce(SpaceSB,       EmptySB,       Null       ));
        NoNullRet("",         Coalesce(SpaceSB,       EmptySB,       Empty      ));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       Space      ));
        NoNullRet(Text,       Coalesce(SpaceSB,       EmptySB,       Text       ));
        NoNullRet("",         Coalesce(SpaceSB,       EmptySB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(SpaceSB,       EmptySB,       NullySpace ));
        NoNullRet(Text,       Coalesce(SpaceSB,       EmptySB,       NullyFilled));
        NoNullRet("",         Coalesce(SpaceSB,       SpaceSB,       Null       ));
        NoNullRet("",         Coalesce(SpaceSB,       SpaceSB,       Empty      ));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       Space      ));
        NoNullRet(Text,       Coalesce(SpaceSB,       SpaceSB,       Text       ));
        NoNullRet("",         Coalesce(SpaceSB,       SpaceSB,       NullyEmpty ));
        NoNullRet(" ",        Coalesce(SpaceSB,       SpaceSB,       NullySpace ));
        NoNullRet(Text,       Coalesce(SpaceSB,       SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(SpaceSB,       FilledSB,      NullyFilled));
    }
    
    /// <inheritdoc cref="_coalesce3argssbtotext" />
    [TestMethod]
    public void Coalesce_3Args_SBToText_Static_NoFlags_Batch7()
    {
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullSB,        NullyFilled));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyEmptySB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullySpaceSB,  NullyFilled));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      NullyFilledSB, NullyFilled));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      EmptySB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      SpaceSB,       NullyFilled));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Null       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Empty      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Space      ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      Text       ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyEmpty ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullySpace ));
        NoNullRet("FilledSB", Coalesce(FilledSB,      FilledSB,      NullyFilled));
    }
}