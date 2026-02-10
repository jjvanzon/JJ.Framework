namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_SBTextCombos_FlagsInBack : TestBase
{
    // Text

    [TestMethod]
    public void Coalesce_2Args_Text_LiteralsFlagsInBack()
    {
        NoNullRet("",         Coalesce(NullText,  NullText,  spaceMatters: false));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback", spaceMatters: false));
        NoNullRet("Fallback", Coalesce("",       "Fallback", spaceMatters: false));
        NoNullRet("Fallback", Coalesce("   ",    "Fallback", spaceMatters: false));
        NoNullRet("",         Coalesce(NullText,  NullText,  spaceMatters: true ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback", spaceMatters: true ));
        NoNullRet("Fallback", Coalesce("",       "Fallback", spaceMatters: true ));
        NoNullRet("   ",      Coalesce("   ",    "Fallback", spaceMatters: true ));
        NoNullRet("",         Coalesce(NullText,  NullText,  spaceMatters       ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback", spaceMatters       ));
        NoNullRet("Fallback", Coalesce("",       "Fallback", spaceMatters       ));
        NoNullRet("   ",      Coalesce("   ",    "Fallback", spaceMatters       ));
        NoNullRet("",         NullText.Coalesce(  NullText,  spaceMatters: false));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback", spaceMatters: false));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback", spaceMatters: false));
        NoNullRet("Fallback", "   "   .Coalesce( "Fallback", spaceMatters: false));
        NoNullRet("",         NullText.Coalesce(  NullText,  spaceMatters: true ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback", spaceMatters: true ));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback", spaceMatters: true ));
        NoNullRet("   ",      "   "   .Coalesce( "Fallback", spaceMatters: true ));
        NoNullRet("",         NullText.Coalesce(  NullText,  spaceMatters       ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback", spaceMatters       ));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback", spaceMatters       ));
        NoNullRet("   ",      "   "   .Coalesce( "Fallback", spaceMatters       ));
    }

    [TestMethod]
    public void Coalesce_2Args_Text_VarsFlagsInBack()
    {
        NoNullRet(Empty, Coalesce(NullText, NullText, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullText, Text,     spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,    Text,     spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,    Text,     spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullText, NullText, spaceMatters: true ));
        NoNullRet(Text,  Coalesce(NullText, Text,     spaceMatters: true ));
        NoNullRet(Text,  Coalesce(Empty,    Text,     spaceMatters: true ));
        NoNullRet(Space, Coalesce(Space,    Text,     spaceMatters: true ));
        NoNullRet(Empty, Coalesce(NullText, NullText, spaceMatters       ));
        NoNullRet(Text,  Coalesce(NullText, Text,     spaceMatters       ));
        NoNullRet(Text,  Coalesce(Empty,    Text,     spaceMatters       ));
        NoNullRet(Space, Coalesce(Space,    Text,     spaceMatters       ));
        NoNullRet(Empty, NullText.Coalesce( NullText, spaceMatters: false));
        NoNullRet(Text,  NullText.Coalesce( Text,     spaceMatters: false));
        NoNullRet(Text,  Empty   .Coalesce( Text,     spaceMatters: false));
        NoNullRet(Text,  Space   .Coalesce( Text,     spaceMatters: false));
        NoNullRet(Empty, NullText.Coalesce( NullText, spaceMatters: true ));
        NoNullRet(Text,  NullText.Coalesce( Text,     spaceMatters: true ));
        NoNullRet(Text,  Empty   .Coalesce( Text,     spaceMatters: true ));
        NoNullRet(Space, Space   .Coalesce( Text,     spaceMatters: true ));
        NoNullRet(Empty, NullText.Coalesce( NullText, spaceMatters       ));
        NoNullRet(Text,  NullText.Coalesce( Text,     spaceMatters       ));
        NoNullRet(Text,  Empty   .Coalesce( Text,     spaceMatters       ));
        NoNullRet(Space, Space   .Coalesce( Text,     spaceMatters       ));
    }

    // StringBuilder

    [TestMethod]
    public void Coalesce_2Args_StringBuilder_VarsFlagsInBack()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(NullSB,  NullSB,   spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB, spaceMatters: false));
        NoNullRet(          Coalesce(NullSB,  NullSB,   spaceMatters: true ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, spaceMatters: true ));
        NoNullRet(SpaceSB,  Coalesce(SpaceSB, FilledSB, spaceMatters: true ));
        NoNullRet(          Coalesce(NullSB,  NullSB,   spaceMatters       ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, spaceMatters       ));
        NoNullRet(SpaceSB,  Coalesce(SpaceSB, FilledSB, spaceMatters       ));
        NoNullRet(          NullSB .Coalesce( NullSB,   spaceMatters: false));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(          NullSB .Coalesce( NullSB,   spaceMatters: true ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(          NullSB .Coalesce( NullSB,   spaceMatters       ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, spaceMatters       ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce( FilledSB, spaceMatters       ));
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB, spaceMatters: false)}");
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   spaceMatters: true )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, spaceMatters: true )}");
        NoNullRet(Space,      $"{Coalesce(SpaceSB, FilledSB, spaceMatters: true )}");
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   spaceMatters       )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, spaceMatters       )}");
        NoNullRet(Space,      $"{Coalesce(SpaceSB, FilledSB, spaceMatters       )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   spaceMatters: false)}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   spaceMatters: true )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   spaceMatters       )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, spaceMatters       )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce( FilledSB, spaceMatters       )}");
    }
    
    // StringBuilder / Text Combos
    
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersNoFlagsInBack()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text, spaceMatters: false));
        NoNullRet(Text,       NullSB       .Coalesce(Text, spaceMatters: false));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text, spaceMatters: false));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text, spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(" ",      Coalesce(NullySpaceSB, NullyFilledText, spaceMatters      ));
        NoNullRet(" ",      Coalesce(NullySpaceSB, NullyFilledText, spaceMatters: true));
        NoNullRet("Filled", Coalesce(NullyEmptySB, NullyFilledText, spaceMatters      ));
        NoNullRet("Filled", Coalesce(NullyEmptySB, NullyFilledText, spaceMatters: true));
        NoNullRet(" ",      NullySpaceSB.Coalesce( NullyFilledText, spaceMatters      ));
        NoNullRet(" ",      NullySpaceSB.Coalesce( NullyFilledText, spaceMatters: true));
        NoNullRet("Filled", NullyEmptySB.Coalesce( NullyFilledText, spaceMatters      ));
        NoNullRet("Filled", NullyEmptySB.Coalesce( NullyFilledText, spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullText,        NullSB,        spaceMatters: false));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB, spaceMatters: false));
        NoNullRet("",         NullText       .Coalesce( NullSB,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(Space,      Coalesce(NullySpace, NullyFilledSB, spaceMatters      ));
        NoNullRet(Space,      Coalesce(NullySpace, NullyFilledSB, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmpty, NullyFilledSB, spaceMatters      ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty, NullyFilledSB, spaceMatters: true));
        NoNullRet(Space,      NullySpace.Coalesce( NullyFilledSB, spaceMatters      ));
        NoNullRet(Space,      NullySpace.Coalesce( NullyFilledSB, spaceMatters: true));
        NoNullRet("FilledSB", NullyEmpty.Coalesce( NullyFilledSB, spaceMatters      ));
        NoNullRet("FilledSB", NullyEmpty.Coalesce( NullyFilledSB, spaceMatters: true));
    }

    // TODO: Booleans
}

[TestClass]
public class Coalesce_2Arg_Values_FlagsInBack : TestBase
{
    // Vals

    [TestMethod]
    public void Coalesce_2Args_Vals_StaticZeroMattersFlagsInBack()
    {
        NoNullRet(0, Coalesce(  Nully0, NullNum, zeroMatters: false));
        NoNullRet(0, Coalesce(  Nully0, NullNum,              false));
        NoNullRet(0, Coalesce(  Nully0, NullNum, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0, NullNum, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0, NullNum,              true ));
        NoNullRet(1, Coalesce(  Nully1, NullNum, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1, NullNum,              false));
        NoNullRet(1, Coalesce(  Nully1, NullNum, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1, NullNum, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1, NullNum,              true ));
        NoNullRet(0, Coalesce(       0, NullNum, zeroMatters: false));
        NoNullRet(0, Coalesce(       0, NullNum,              false));
        NoNullRet(0, Coalesce(       0, NullNum, zeroMatters       ));
        NoNullRet(0, Coalesce(       0, NullNum, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0, NullNum,              true ));
        NoNullRet(1, Coalesce(       1, NullNum, zeroMatters: false));
        NoNullRet(1, Coalesce(       1, NullNum,              false));
        NoNullRet(1, Coalesce(       1, NullNum, zeroMatters       ));
        NoNullRet(1, Coalesce(       1, NullNum, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1, NullNum,              true ));
        NoNullRet(0, Coalesce( NullNum,  Nully0, zeroMatters: false));
        NoNullRet(0, Coalesce( NullNum,  Nully0,              false));
        NoNullRet(0, Coalesce( NullNum,  Nully0, zeroMatters       ));
        NoNullRet(0, Coalesce( NullNum,  Nully0, zeroMatters: true ));
        NoNullRet(0, Coalesce( NullNum,  Nully0,              true ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1,  Nully0,              false));
        NoNullRet(1, Coalesce(  Nully1,  Nully0, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0,              true ));
        NoNullRet(0, Coalesce(       0,  Nully0, zeroMatters: false));
        NoNullRet(0, Coalesce(       0,  Nully0,              false));
        NoNullRet(0, Coalesce(       0,  Nully0, zeroMatters       ));
        NoNullRet(0, Coalesce(       0,  Nully0, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0,  Nully0,              true ));
        NoNullRet(1, Coalesce(       1,  Nully0, zeroMatters: false));
        NoNullRet(1, Coalesce(       1,  Nully0,              false));
        NoNullRet(1, Coalesce(       1,  Nully0, zeroMatters       ));
        NoNullRet(1, Coalesce(       1,  Nully0, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1,  Nully0,              true ));
        NoNullRet(1, Coalesce( NullNum,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce( NullNum,  Nully1,              false));
        NoNullRet(1, Coalesce( NullNum,  Nully1, zeroMatters       ));
        NoNullRet(1, Coalesce( NullNum,  Nully1, zeroMatters: true ));
        NoNullRet(1, Coalesce( NullNum,  Nully1,              true ));
        NoNullRet(1, Coalesce(  Nully0,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully0,  Nully1,              false));
        NoNullRet(0, Coalesce(  Nully0,  Nully1, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0,  Nully1, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0,  Nully1,              true ));
        NoNullRet(1, Coalesce(       0,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce(       0,  Nully1,              false));
        NoNullRet(0, Coalesce(       0,  Nully1, zeroMatters       ));
        NoNullRet(0, Coalesce(       0,  Nully1, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0,  Nully1,              true ));
        NoNullRet(1, Coalesce(       1,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce(       1,  Nully1,              false));
        NoNullRet(1, Coalesce(       1,  Nully1, zeroMatters       ));
        NoNullRet(1, Coalesce(       1,  Nully1, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1,  Nully1,              true ));
        NoNullRet(0, Coalesce( NullNum,       0, zeroMatters: false));
        NoNullRet(0, Coalesce( NullNum,       0,              false));
        NoNullRet(0, Coalesce( NullNum,       0, zeroMatters       ));
        NoNullRet(0, Coalesce( NullNum,       0, zeroMatters: true ));
        NoNullRet(0, Coalesce( NullNum,       0,              true ));
        NoNullRet(0, Coalesce(  Nully0,       0, zeroMatters: false));
        NoNullRet(0, Coalesce(  Nully0,       0,              false));
        NoNullRet(0, Coalesce(  Nully0,       0, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0,       0, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0,       0,              true ));
        NoNullRet(1, Coalesce(  Nully1,       0, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1,       0,              false));
        NoNullRet(1, Coalesce(  Nully1,       0, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1,       0, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1,       0,              true ));
        NoNullRet(1, Coalesce(       1,       0, zeroMatters: false));
        NoNullRet(1, Coalesce(       1,       0,              false));
        NoNullRet(1, Coalesce(       1,       0, zeroMatters       ));
        NoNullRet(1, Coalesce(       1,       0, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1,       0,              true ));
        NoNullRet(1, Coalesce( NullNum,       1, zeroMatters: false));
        NoNullRet(1, Coalesce( NullNum,       1,              false));
        NoNullRet(1, Coalesce( NullNum,       1, zeroMatters       ));
        NoNullRet(1, Coalesce( NullNum,       1, zeroMatters: true ));
        NoNullRet(1, Coalesce( NullNum,       1,              true ));
        NoNullRet(1, Coalesce(  Nully0,       1, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully0,       1,              false));
        NoNullRet(0, Coalesce(  Nully0,       1, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0,       1, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0,       1,              true ));
        NoNullRet(1, Coalesce(  Nully1,       1, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1,       1,              false));
        NoNullRet(1, Coalesce(  Nully1,       1, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1,       1, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1,       1,              true ));
        NoNullRet(1, Coalesce(       0,       1, zeroMatters: false));
        NoNullRet(1, Coalesce(       0,       1,              false));
        NoNullRet(0, Coalesce(       0,       1, zeroMatters       ));
        NoNullRet(0, Coalesce(       0,       1, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0,       1,              true ));
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_ExtensionsZeroMattersFlagsInBack()
    {
        NoNullRet(0,   Nully0.Coalesce( NullNum, zeroMatters: false));
        NoNullRet(0,   Nully0.Coalesce( NullNum,              false));
        NoNullRet(0,   Nully0.Coalesce( NullNum, zeroMatters       ));
        NoNullRet(0,   Nully0.Coalesce( NullNum, zeroMatters: true ));
        NoNullRet(0,   Nully0.Coalesce( NullNum,              true ));
        NoNullRet(1,   Nully1.Coalesce( NullNum, zeroMatters: false));
        NoNullRet(1,   Nully1.Coalesce( NullNum,              false));
        NoNullRet(1,   Nully1.Coalesce( NullNum, zeroMatters       ));
        NoNullRet(1,   Nully1.Coalesce( NullNum, zeroMatters: true ));
        NoNullRet(1,   Nully1.Coalesce( NullNum,              true ));
        NoNullRet(0,        0.Coalesce( NullNum, zeroMatters: false));
        NoNullRet(0,        0.Coalesce( NullNum,              false));
        NoNullRet(0,        0.Coalesce( NullNum, zeroMatters       ));
        NoNullRet(0,        0.Coalesce( NullNum, zeroMatters: true ));
        NoNullRet(0,        0.Coalesce( NullNum,              true ));
        NoNullRet(1,        1.Coalesce( NullNum, zeroMatters: false));
        NoNullRet(1,        1.Coalesce( NullNum,              false));
        NoNullRet(1,        1.Coalesce( NullNum, zeroMatters       ));
        NoNullRet(1,        1.Coalesce( NullNum, zeroMatters: true ));
        NoNullRet(1,        1.Coalesce( NullNum,              true ));
        NoNullRet(0,  NullNum.Coalesce(  Nully0, zeroMatters: false));
        NoNullRet(0,  NullNum.Coalesce(  Nully0,              false));
        NoNullRet(0,  NullNum.Coalesce(  Nully0, zeroMatters       ));
        NoNullRet(0,  NullNum.Coalesce(  Nully0, zeroMatters: true ));
        NoNullRet(0,  NullNum.Coalesce(  Nully0,              true ));
        NoNullRet(1,   Nully1.Coalesce(  Nully0, zeroMatters: false));
        NoNullRet(1,   Nully1.Coalesce(  Nully0,              false));
        NoNullRet(1,   Nully1.Coalesce(  Nully0, zeroMatters       ));
        NoNullRet(1,   Nully1.Coalesce(  Nully0, zeroMatters: true ));
        NoNullRet(1,   Nully1.Coalesce(  Nully0,              true ));
        NoNullRet(0,        0.Coalesce(  Nully0, zeroMatters: false));
        NoNullRet(0,        0.Coalesce(  Nully0,              false));
        NoNullRet(0,        0.Coalesce(  Nully0, zeroMatters       ));
        NoNullRet(0,        0.Coalesce(  Nully0, zeroMatters: true ));
        NoNullRet(0,        0.Coalesce(  Nully0,              true ));
        NoNullRet(1,        1.Coalesce(  Nully0, zeroMatters: false));
        NoNullRet(1,        1.Coalesce(  Nully0,              false));
        NoNullRet(1,        1.Coalesce(  Nully0, zeroMatters       ));
        NoNullRet(1,        1.Coalesce(  Nully0, zeroMatters: true ));
        NoNullRet(1,        1.Coalesce(  Nully0,              true ));
        NoNullRet(1,  NullNum.Coalesce(  Nully1, zeroMatters: false));
        NoNullRet(1,  NullNum.Coalesce(  Nully1,              false));
        NoNullRet(1,  NullNum.Coalesce(  Nully1, zeroMatters       ));
        NoNullRet(1,  NullNum.Coalesce(  Nully1, zeroMatters: true ));
        NoNullRet(1,  NullNum.Coalesce(  Nully1,              true ));
        NoNullRet(1,   Nully0.Coalesce(  Nully1, zeroMatters: false));
        NoNullRet(1,   Nully0.Coalesce(  Nully1,              false));
        NoNullRet(0,   Nully0.Coalesce(  Nully1, zeroMatters       ));
        NoNullRet(0,   Nully0.Coalesce(  Nully1, zeroMatters: true ));
        NoNullRet(0,   Nully0.Coalesce(  Nully1,              true ));
        NoNullRet(1,        0.Coalesce(  Nully1, zeroMatters: false));
        NoNullRet(1,        0.Coalesce(  Nully1,              false));
        NoNullRet(0,        0.Coalesce(  Nully1, zeroMatters       ));
        NoNullRet(0,        0.Coalesce(  Nully1, zeroMatters: true ));
        NoNullRet(0,        0.Coalesce(  Nully1,              true ));
        NoNullRet(1,        1.Coalesce(  Nully1, zeroMatters: false));
        NoNullRet(1,        1.Coalesce(  Nully1,              false));
        NoNullRet(1,        1.Coalesce(  Nully1, zeroMatters       ));
        NoNullRet(1,        1.Coalesce(  Nully1, zeroMatters: true ));
        NoNullRet(1,        1.Coalesce(  Nully1,              true ));
        NoNullRet(0,  NullNum.Coalesce(       0, zeroMatters: false));
        NoNullRet(0,  NullNum.Coalesce(       0,              false));
        NoNullRet(0,  NullNum.Coalesce(       0, zeroMatters       ));
        NoNullRet(0,  NullNum.Coalesce(       0, zeroMatters: true ));
        NoNullRet(0,  NullNum.Coalesce(       0,              true ));
        NoNullRet(0,   Nully0.Coalesce(       0, zeroMatters: false));
        NoNullRet(0,   Nully0.Coalesce(       0,              false));
        NoNullRet(0,   Nully0.Coalesce(       0, zeroMatters       ));
        NoNullRet(0,   Nully0.Coalesce(       0, zeroMatters: true ));
        NoNullRet(0,   Nully0.Coalesce(       0,              true ));
        NoNullRet(1,   Nully1.Coalesce(       0, zeroMatters: false));
        NoNullRet(1,   Nully1.Coalesce(       0,              false));
        NoNullRet(1,   Nully1.Coalesce(       0, zeroMatters       ));
        NoNullRet(1,   Nully1.Coalesce(       0, zeroMatters: true ));
        NoNullRet(1,   Nully1.Coalesce(       0,              true ));
        NoNullRet(1,        1.Coalesce(       0, zeroMatters: false));
        NoNullRet(1,        1.Coalesce(       0,              false));
        NoNullRet(1,        1.Coalesce(       0, zeroMatters       ));
        NoNullRet(1,        1.Coalesce(       0, zeroMatters: true ));
        NoNullRet(1,        1.Coalesce(       0,              true ));
        NoNullRet(1,  NullNum.Coalesce(       1, zeroMatters: false));
        NoNullRet(1,  NullNum.Coalesce(       1,              false));
        NoNullRet(1,  NullNum.Coalesce(       1, zeroMatters       ));
        NoNullRet(1,  NullNum.Coalesce(       1, zeroMatters: true ));
        NoNullRet(1,  NullNum.Coalesce(       1,              true ));
        NoNullRet(1,   Nully0.Coalesce(       1, zeroMatters: false));
        NoNullRet(1,   Nully0.Coalesce(       1,              false));
        NoNullRet(0,   Nully0.Coalesce(       1, zeroMatters       ));
        NoNullRet(0,   Nully0.Coalesce(       1, zeroMatters: true ));
        NoNullRet(0,   Nully0.Coalesce(       1,              true ));
        NoNullRet(1,   Nully1.Coalesce(       1, zeroMatters: false));
        NoNullRet(1,   Nully1.Coalesce(       1,              false));
        NoNullRet(1,   Nully1.Coalesce(       1, zeroMatters       ));
        NoNullRet(1,   Nully1.Coalesce(       1, zeroMatters: true ));
        NoNullRet(1,   Nully1.Coalesce(       1,              true ));
        NoNullRet(1,        0.Coalesce(       1, zeroMatters: false));
        NoNullRet(1,        0.Coalesce(       1,              false));
        NoNullRet(0,        0.Coalesce(       1, zeroMatters       ));
        NoNullRet(0,        0.Coalesce(       1, zeroMatters: true ));
        NoNullRet(0,        0.Coalesce(       1,              true ));
    }

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_ValToText_ZeroMattersNoNulliesFlagsInBack()
    {
        NoNullRet("",           Coalesce(0,  NullText,  zeroMatters: false));
        NoNullRet("",           Coalesce(0,  NullText,               false));
        NoNullRet("0",          Coalesce(0,  NullText,  zeroMatters       ));
        NoNullRet("0",          Coalesce(0,  NullText,  zeroMatters: true ));
        NoNullRet("0",          Coalesce(0,  NullText,               true ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo",              false));
        NoNullRet("0",          Coalesce(0, "peekaboo", zeroMatters       ));
        NoNullRet("0",          Coalesce(0, "peekaboo", zeroMatters: true ));
        NoNullRet("0",          Coalesce(0, "peekaboo",              true ));
        NoNullRet("1",          Coalesce(1,  NullText,  zeroMatters: false));
        NoNullRet("1",          Coalesce(1,  NullText,               false));
        NoNullRet("1",          Coalesce(1,  NullText,  zeroMatters       ));
        NoNullRet("1",          Coalesce(1,  NullText,  zeroMatters: true ));
        NoNullRet("1",          Coalesce(1,  NullText,               true ));
        NoNullRet("1",          Coalesce(1, "peekaboo", zeroMatters: false));
        NoNullRet("1",          Coalesce(1, "peekaboo",              false));
        NoNullRet("1",          Coalesce(1, "peekaboo", zeroMatters       ));
        NoNullRet("1",          Coalesce(1, "peekaboo", zeroMatters: true ));
        NoNullRet("1",          Coalesce(1, "peekaboo",              true ));
        NoNullRet("",         0.Coalesce(    NullText,  zeroMatters: false));
        NoNullRet("",         0.Coalesce(    NullText,               false));
        NoNullRet("0",        0.Coalesce(    NullText,  zeroMatters       ));
        NoNullRet("0",        0.Coalesce(    NullText,  zeroMatters: true ));
        NoNullRet("0",        0.Coalesce(    NullText,               true ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo",              false));
        NoNullRet("0",        0.Coalesce(   "peekaboo", zeroMatters       ));
        NoNullRet("0",        0.Coalesce(   "peekaboo", zeroMatters: true ));
        NoNullRet("0",        0.Coalesce(   "peekaboo",              true ));
        NoNullRet("1",        1.Coalesce(    NullText,  zeroMatters: false));
        NoNullRet("1",        1.Coalesce(    NullText,               false));
        NoNullRet("1",        1.Coalesce(    NullText,  zeroMatters       ));
        NoNullRet("1",        1.Coalesce(    NullText,  zeroMatters: true ));
        NoNullRet("1",        1.Coalesce(    NullText,               true ));
        NoNullRet("1",        1.Coalesce(   "peekaboo", zeroMatters: false));
        NoNullRet("1",        1.Coalesce(   "peekaboo",              false));
        NoNullRet("1",        1.Coalesce(   "peekaboo", zeroMatters       ));
        NoNullRet("1",        1.Coalesce(   "peekaboo", zeroMatters: true ));
        NoNullRet("1",        1.Coalesce(   "peekaboo",              true ));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_ZeroMattersWithNulliesFlagsInBack()
    {
        NoNullRet("",    Coalesce(NullNum,   NullText,  zeroMatters: false));
        NoNullRet("",    Coalesce(NullNum,   NullText,               false));
        NoNullRet("",    Coalesce(NullNum,   NullText,  zeroMatters       ));
        NoNullRet("",    Coalesce(NullNum,   NullText,  zeroMatters: true ));
        NoNullRet("",    Coalesce(NullNum,   NullText,               true ));
        NoNullRet("boo", Coalesce(NullNum,  "boo",      zeroMatters: false));
        NoNullRet("boo", Coalesce(NullNum,  "boo",                   false));
        NoNullRet("boo", Coalesce(NullNum,  "boo",      zeroMatters       ));
        NoNullRet("boo", Coalesce(NullNum,  "boo",      zeroMatters: true ));
        NoNullRet("boo", Coalesce(NullNum,  "boo",                   true ));
        NoNullRet("",    Coalesce(Nully0,    NullText,  zeroMatters: false));
        NoNullRet("",    Coalesce(Nully0,    NullText,               false));
        NoNullRet("0",   Coalesce(Nully0,    NullText,  zeroMatters       ));
        NoNullRet("0",   Coalesce(Nully0,    NullText,  zeroMatters: true ));
        NoNullRet("0",   Coalesce(Nully0,    NullText,               true ));
        NoNullRet("boo", Coalesce(Nully0,   "boo",      zeroMatters: false));
        NoNullRet("boo", Coalesce(Nully0,   "boo",                   false));
        NoNullRet("0",   Coalesce(Nully0,   "boo",      zeroMatters       ));
        NoNullRet("0",   Coalesce(Nully0,   "boo",      zeroMatters: true ));
        NoNullRet("0",   Coalesce(Nully0,   "boo",                   true ));
        NoNullRet("1",   Coalesce(Nully1,    NullText,  zeroMatters: false));
        NoNullRet("1",   Coalesce(Nully1,    NullText,               false));
        NoNullRet("1",   Coalesce(Nully1,    NullText,  zeroMatters       ));
        NoNullRet("1",   Coalesce(Nully1,    NullText,  zeroMatters: true ));
        NoNullRet("1",   Coalesce(Nully1,    NullText,               true ));
        NoNullRet("1",   Coalesce(Nully1,   "boo",      zeroMatters: false));
        NoNullRet("1",   Coalesce(Nully1,   "boo",                   false));
        NoNullRet("1",   Coalesce(Nully1,   "boo",      zeroMatters       ));
        NoNullRet("1",   Coalesce(Nully1,   "boo",      zeroMatters: true ));
        NoNullRet("1",   Coalesce(Nully1,   "boo",                   true ));
        NoNullRet("",    NullNum.Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("",    NullNum.Coalesce(   NullText,               false));
        NoNullRet("",    NullNum.Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("",    NullNum.Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("",    NullNum.Coalesce(   NullText,               true ));
        NoNullRet("boo", NullNum.Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("boo", NullNum.Coalesce(  "boo",                   false));
        NoNullRet("boo", NullNum.Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("boo", NullNum.Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("boo", NullNum.Coalesce(  "boo",                   true ));
        NoNullRet("",    Nully0 .Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("",    Nully0 .Coalesce(   NullText,               false));
        NoNullRet("0",   Nully0 .Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("0",   Nully0 .Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("0",   Nully0 .Coalesce(   NullText,               true ));
        NoNullRet("boo", Nully0 .Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("boo", Nully0 .Coalesce(  "boo",                   false));
        NoNullRet("0",   Nully0 .Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("0",   Nully0 .Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("0",   Nully0 .Coalesce(  "boo",                   true ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,               false));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,               true ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",                   false));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",                   true ));
    }
}
