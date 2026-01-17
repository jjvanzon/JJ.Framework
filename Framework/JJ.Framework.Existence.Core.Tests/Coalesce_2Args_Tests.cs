namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Tests : TestBase
{
    private static Dummy? NullyFilled = NullyFilledObj;
            
    [TestMethod]
    public void Coalesce_2Args_RandomCases()
    {
        NoNullRet("Hello", Coalesce("", "Hello", "World"));
        NoNullRet("Hello", "".Coalesce("Hello", "World"));
        NoNullRet(1, Coalesce(null, 0, 1));
        NoNullRet(0, Coalesce(null, 0, 1, zeroMatters));
    }

    // Text

    [TestMethod]
    public void Coalesce_2Args_Text_Literals()
    {
        NoNullRet("",         Coalesce(NullText,  NullText                      ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback"                     ));
        NoNullRet("Fallback", Coalesce("",       "Fallback"                     ));
        NoNullRet("Fallback", Coalesce("   ",    "Fallback"                     ));
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
        NoNullRet("",         NullText.Coalesce(  NullText                      ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback"                     ));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback"                     ));
        NoNullRet("Fallback", "   "   .Coalesce( "Fallback"                     ));
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
    public void Coalesce_2Args_Text_Vars()
    {
        NoNullRet(Empty, Coalesce(NullText, NullText                     ));
        NoNullRet(Text,  Coalesce(NullText, Text                         ));
        NoNullRet(Text,  Coalesce(Empty,    Text                         ));
        NoNullRet(Text,  Coalesce(Space,    Text                         ));
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
        NoNullRet(Empty, NullText.Coalesce( NullText                     ));
        NoNullRet(Text,  NullText.Coalesce( Text                         ));
        NoNullRet(Text,  Empty   .Coalesce( Text                         ));
        NoNullRet(Text,  Space   .Coalesce( Text                         ));
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
    public void Coalesce_2Args_StringBuilder_Vars()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(NullSB,  NullSB                       ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB                     ));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB                     ));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB                     ));
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB                     ));
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
        NoNullRet(          NullSB .Coalesce( NullSB                       ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB                     ));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB                     ));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB                     ));
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB                     ));
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
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB                       )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB                     )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB                     )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB                     )}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB                     )}");
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
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB                       )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB                     )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB                     )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB                     )}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB                     )}");
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
    public void Coalesce_2Args_StringBuilderAndText()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text                     ));
        NoNullRet(Text,       Coalesce(NullSB,       Text, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text                     ));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text                     ));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text, spaceMatters: false));
        NoNullRet(Text,       NullSB       .Coalesce(Text                     ));
        NoNullRet(Text,       NullSB       .Coalesce(Text, spaceMatters: false));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text                     ));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text, spaceMatters: false));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text                     ));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text, spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMatters()
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
    public void Coalesce_2Args_TextAndStringBuilder()
    {
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB                     ));
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB                     ));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullText,        NullSB                            ));
        NoNullRet("",         Coalesce(NullText,        NullSB,        spaceMatters: false));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB                     ));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB                     ));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB, spaceMatters: false));
        NoNullRet("",         NullText       .Coalesce( NullSB                            ));
        NoNullRet("",         NullText       .Coalesce( NullSB,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMatters()
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

    // Objects to Text

    [TestMethod]
    public void Coalesce_2Args_ObjectToText()
    {
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet("NoNull", Coalesce(NoNullObj,  Text));
        NoNullRet("Filled", Coalesce(NullyFilled,Text));
        NoNullRet(Text,     NullObj    .Coalesce(Text));
        NoNullRet("NoNull", NoNullObj  .Coalesce(Text));
        NoNullRet("Filled", NullyFilled.Coalesce(Text));
    }

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_ValToText_NoNullies()
    {
        NoNullRet("",           Coalesce(0,  NullText ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo"));
        NoNullRet("",         0.Coalesce(    NullText ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo"));
        NoNullRet("1",        1.Coalesce(    NullText ));
        NoNullRet("1",        1.Coalesce(   "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_WithNullies()
    {
        NoNullRet("",    Coalesce(NullNum,   NullText ));
        NoNullRet("boo", Coalesce(NullNum,  "boo"     ));
        NoNullRet("",    Coalesce(Nully0,    NullText ));
        NoNullRet("boo", Coalesce(Nully0,   "boo"     ));
        NoNullRet("1",   Coalesce(Nully1,    NullText ));
        NoNullRet("1",   Coalesce(Nully1,   "boo"     ));
        NoNullRet("",    NullNum.Coalesce(   NullText ));
        NoNullRet("boo", NullNum.Coalesce(  "boo"     ));
        NoNullRet("",    Nully0 .Coalesce(   NullText ));
        NoNullRet("boo", Nully0 .Coalesce(  "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo"     ));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_ZeroMatters_NoNullies()
    {
        NoNullRet("",           Coalesce(0,  NullText                     ));
        NoNullRet("",           Coalesce(0,  NullText,  zeroMatters: false));
        NoNullRet("",           Coalesce(0,  NullText,               false));
        NoNullRet("0",          Coalesce(0,  NullText,  zeroMatters       ));
        NoNullRet("0",          Coalesce(0,  NullText,  zeroMatters: true ));
        NoNullRet("0",          Coalesce(0,  NullText,               true ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo"                    ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo",              false));
        NoNullRet("0",          Coalesce(0, "peekaboo", zeroMatters       ));
        NoNullRet("0",          Coalesce(0, "peekaboo", zeroMatters: true ));
        NoNullRet("0",          Coalesce(0, "peekaboo",              true ));
        NoNullRet("",         0.Coalesce(    NullText                     ));
        NoNullRet("",         0.Coalesce(    NullText,  zeroMatters: false));
        NoNullRet("",         0.Coalesce(    NullText,               false));
        NoNullRet("0",        0.Coalesce(    NullText,  zeroMatters       ));
        NoNullRet("0",        0.Coalesce(    NullText,  zeroMatters: true ));
        NoNullRet("0",        0.Coalesce(    NullText,               true ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo"                    ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo", zeroMatters: false));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo",              false));
        NoNullRet("0",        0.Coalesce(   "peekaboo", zeroMatters       ));
        NoNullRet("0",        0.Coalesce(   "peekaboo", zeroMatters: true ));
        NoNullRet("0",        0.Coalesce(   "peekaboo",              true ));
        NoNullRet("1",        1.Coalesce(    NullText                     ));
        NoNullRet("1",        1.Coalesce(    NullText,  zeroMatters: false));
        NoNullRet("1",        1.Coalesce(    NullText,               false));
        NoNullRet("1",        1.Coalesce(    NullText,  zeroMatters       ));
        NoNullRet("1",        1.Coalesce(    NullText,  zeroMatters: true ));
        NoNullRet("1",        1.Coalesce(    NullText,               true ));
        NoNullRet("1",        1.Coalesce(   "peekaboo"                    ));
        NoNullRet("1",        1.Coalesce(   "peekaboo", zeroMatters: false));
        NoNullRet("1",        1.Coalesce(   "peekaboo",              false));
        NoNullRet("1",        1.Coalesce(   "peekaboo", zeroMatters       ));
        NoNullRet("1",        1.Coalesce(   "peekaboo", zeroMatters: true ));
        NoNullRet("1",        1.Coalesce(   "peekaboo",              true ));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_ZeroMatters_WithNullies()
    {
        NoNullRet("",    Coalesce(NullNum,   NullText                     ));
        NoNullRet("",    Coalesce(NullNum,   NullText,  zeroMatters: false));
        NoNullRet("",    Coalesce(NullNum,   NullText,               false));
        NoNullRet("",    Coalesce(NullNum,   NullText,  zeroMatters       ));
        NoNullRet("",    Coalesce(NullNum,   NullText,  zeroMatters: true ));
        NoNullRet("",    Coalesce(NullNum,   NullText,               true ));
        NoNullRet("boo", Coalesce(NullNum,  "boo"                         ));
        NoNullRet("boo", Coalesce(NullNum,  "boo",      zeroMatters: false));
        NoNullRet("boo", Coalesce(NullNum,  "boo",                   false));
        NoNullRet("boo", Coalesce(NullNum,  "boo",      zeroMatters       ));
        NoNullRet("boo", Coalesce(NullNum,  "boo",      zeroMatters: true ));
        NoNullRet("boo", Coalesce(NullNum,  "boo",                   true ));
        NoNullRet("",    Coalesce(Nully0,    NullText                     ));
        NoNullRet("",    Coalesce(Nully0,    NullText,  zeroMatters: false));
        NoNullRet("",    Coalesce(Nully0,    NullText,               false));
        NoNullRet("0",   Coalesce(Nully0,    NullText,  zeroMatters       ));
        NoNullRet("0",   Coalesce(Nully0,    NullText,  zeroMatters: true ));
        NoNullRet("0",   Coalesce(Nully0,    NullText,               true ));
        NoNullRet("boo", Coalesce(Nully0,   "boo"                         ));
        NoNullRet("boo", Coalesce(Nully0,   "boo",      zeroMatters: false));
        NoNullRet("boo", Coalesce(Nully0,   "boo",                   false));
        NoNullRet("0",   Coalesce(Nully0,   "boo",      zeroMatters       ));
        NoNullRet("0",   Coalesce(Nully0,   "boo",      zeroMatters: true ));
        NoNullRet("0",   Coalesce(Nully0,   "boo",                   true ));
        NoNullRet("1",   Coalesce(Nully1,    NullText                     ));
        NoNullRet("1",   Coalesce(Nully1,    NullText,  zeroMatters: false));
        NoNullRet("1",   Coalesce(Nully1,    NullText,               false));
        NoNullRet("1",   Coalesce(Nully1,    NullText,  zeroMatters       ));
        NoNullRet("1",   Coalesce(Nully1,    NullText,  zeroMatters: true ));
        NoNullRet("1",   Coalesce(Nully1,    NullText,               true ));
        NoNullRet("1",   Coalesce(Nully1,   "boo"                         ));
        NoNullRet("1",   Coalesce(Nully1,   "boo",      zeroMatters: false));
        NoNullRet("1",   Coalesce(Nully1,   "boo",                   false));
        NoNullRet("1",   Coalesce(Nully1,   "boo",      zeroMatters       ));
        NoNullRet("1",   Coalesce(Nully1,   "boo",      zeroMatters: true ));
        NoNullRet("1",   Coalesce(Nully1,   "boo",                   true ));
        NoNullRet("",    NullNum.Coalesce(   NullText                     ));
        NoNullRet("",    NullNum.Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("",    NullNum.Coalesce(   NullText,               false));
        NoNullRet("",    NullNum.Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("",    NullNum.Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("",    NullNum.Coalesce(   NullText,               true ));
        NoNullRet("boo", NullNum.Coalesce(  "boo"                         ));
        NoNullRet("boo", NullNum.Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("boo", NullNum.Coalesce(  "boo",                   false));
        NoNullRet("boo", NullNum.Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("boo", NullNum.Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("boo", NullNum.Coalesce(  "boo",                   true ));
        NoNullRet("",    Nully0 .Coalesce(   NullText                     ));
        NoNullRet("",    Nully0 .Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("",    Nully0 .Coalesce(   NullText,               false));
        NoNullRet("0",   Nully0 .Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("0",   Nully0 .Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("0",   Nully0 .Coalesce(   NullText,               true ));
        NoNullRet("boo", Nully0 .Coalesce(  "boo"                         ));
        NoNullRet("boo", Nully0 .Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("boo", Nully0 .Coalesce(  "boo",                   false));
        NoNullRet("0",   Nully0 .Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("0",   Nully0 .Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("0",   Nully0 .Coalesce(  "boo",                   true ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText                     ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,  zeroMatters: false));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,               false));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,  zeroMatters       ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,  zeroMatters: true ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText,               true ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo"                         ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",      zeroMatters: false));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",                   false));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",      zeroMatters       ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",      zeroMatters: true ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo",                   true ));
    }

    // Vals

    [TestMethod]
    public void Coalesce_2Args_Vals_VerifyInputs()
    {
        // Assert input states
        IsNull (   NullNum);
        NullRet(0, Nully0 );
        NullRet(1, Nully1 );
        NullRet(2, Nully2 );
        NoNullRet(0);
        NoNullRet(1);
        NoNullRet(2);
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_Static()
    {
        NoNullRet(0, Coalesce( NullNum, NullNum));
        NoNullRet(0, Coalesce(  Nully0, NullNum));
        NoNullRet(1, Coalesce(  Nully1, NullNum));
        NoNullRet(2, Coalesce(  Nully2, NullNum));
        NoNullRet(0, Coalesce(       0, NullNum));
        NoNullRet(1, Coalesce(       1, NullNum));
        NoNullRet(2, Coalesce(       2, NullNum));
        NoNullRet(0, Coalesce( NullNum,  Nully0));
        NoNullRet(0, Coalesce(  Nully0,  Nully0));
        NoNullRet(1, Coalesce(  Nully1,  Nully0));
        NoNullRet(2, Coalesce(  Nully2,  Nully0));
        NoNullRet(0, Coalesce(       0,  Nully0));
        NoNullRet(1, Coalesce(       1,  Nully0));
        NoNullRet(2, Coalesce(       2,  Nully0));
        NoNullRet(1, Coalesce( NullNum,  Nully1));
        NoNullRet(1, Coalesce(  Nully0,  Nully1));
        NoNullRet(1, Coalesce(  Nully1,  Nully1));
        NoNullRet(2, Coalesce(  Nully2,  Nully1));
        NoNullRet(1, Coalesce(       0,  Nully1));
        NoNullRet(1, Coalesce(       1,  Nully1));
        NoNullRet(2, Coalesce(       2,  Nully1));
        NoNullRet(2, Coalesce( NullNum,  Nully2));
        NoNullRet(2, Coalesce(  Nully0,  Nully2));
        NoNullRet(1, Coalesce(  Nully1,  Nully2));
        NoNullRet(2, Coalesce(  Nully2,  Nully2));
        NoNullRet(2, Coalesce(       0,  Nully2));
        NoNullRet(1, Coalesce(       1,  Nully2));
        NoNullRet(2, Coalesce(       2,  Nully2));
        NoNullRet(0, Coalesce( NullNum,       0));
        NoNullRet(0, Coalesce(  Nully0,       0));
        NoNullRet(1, Coalesce(  Nully1,       0));
        NoNullRet(2, Coalesce(  Nully2,       0));
        NoNullRet(0, Coalesce(       0,       0));
        NoNullRet(1, Coalesce(       1,       0));
        NoNullRet(2, Coalesce(       2,       0));
        NoNullRet(1, Coalesce( NullNum,       1));
        NoNullRet(1, Coalesce(  Nully0,       1));
        NoNullRet(1, Coalesce(  Nully1,       1));
        NoNullRet(2, Coalesce(  Nully2,       1));
        NoNullRet(1, Coalesce(       0,       1));
        NoNullRet(1, Coalesce(       1,       1));
        NoNullRet(2, Coalesce(       2,       1));
        NoNullRet(2, Coalesce( NullNum,       2));
        NoNullRet(2, Coalesce(  Nully0,       2));
        NoNullRet(1, Coalesce(  Nully1,       2));
        NoNullRet(2, Coalesce(  Nully2,       2));
        NoNullRet(2, Coalesce(       0,       2));
        NoNullRet(1, Coalesce(       1,       2));
        NoNullRet(2, Coalesce(       2,       2));
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_StaticZeroMatters()
    {
        NoNullRet(0, Coalesce(  Nully0, NullNum                    ));
        NoNullRet(0, Coalesce(  Nully0, NullNum, zeroMatters: false));
        NoNullRet(0, Coalesce(  Nully0, NullNum,              false));
        NoNullRet(0, Coalesce(  Nully0, NullNum, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0, NullNum, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0, NullNum,              true ));
        NoNullRet(1, Coalesce(  Nully1, NullNum                    ));
        NoNullRet(1, Coalesce(  Nully1, NullNum, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1, NullNum,              false));
        NoNullRet(1, Coalesce(  Nully1, NullNum, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1, NullNum, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1, NullNum,              true ));
        NoNullRet(0, Coalesce(       0, NullNum                    ));
        NoNullRet(0, Coalesce(       0, NullNum, zeroMatters: false));
        NoNullRet(0, Coalesce(       0, NullNum,              false));
        NoNullRet(0, Coalesce(       0, NullNum, zeroMatters       ));
        NoNullRet(0, Coalesce(       0, NullNum, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0, NullNum,              true ));
        NoNullRet(1, Coalesce(       1, NullNum                    ));
        NoNullRet(1, Coalesce(       1, NullNum, zeroMatters: false));
        NoNullRet(1, Coalesce(       1, NullNum,              false));
        NoNullRet(1, Coalesce(       1, NullNum, zeroMatters       ));
        NoNullRet(1, Coalesce(       1, NullNum, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1, NullNum,              true ));
        NoNullRet(0, Coalesce( NullNum,  Nully0                    ));
        NoNullRet(0, Coalesce( NullNum,  Nully0, zeroMatters: false));
        NoNullRet(0, Coalesce( NullNum,  Nully0,              false));
        NoNullRet(0, Coalesce( NullNum,  Nully0, zeroMatters       ));
        NoNullRet(0, Coalesce( NullNum,  Nully0, zeroMatters: true ));
        NoNullRet(0, Coalesce( NullNum,  Nully0,              true ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0                    ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1,  Nully0,              false));
        NoNullRet(1, Coalesce(  Nully1,  Nully0, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1,  Nully0,              true ));
        NoNullRet(0, Coalesce(       0,  Nully0                    ));
        NoNullRet(0, Coalesce(       0,  Nully0, zeroMatters: false));
        NoNullRet(0, Coalesce(       0,  Nully0,              false));
        NoNullRet(0, Coalesce(       0,  Nully0, zeroMatters       ));
        NoNullRet(0, Coalesce(       0,  Nully0, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0,  Nully0,              true ));
        NoNullRet(1, Coalesce(       1,  Nully0                    ));
        NoNullRet(1, Coalesce(       1,  Nully0, zeroMatters: false));
        NoNullRet(1, Coalesce(       1,  Nully0,              false));
        NoNullRet(1, Coalesce(       1,  Nully0, zeroMatters       ));
        NoNullRet(1, Coalesce(       1,  Nully0, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1,  Nully0,              true ));
        NoNullRet(1, Coalesce( NullNum,  Nully1                    ));
        NoNullRet(1, Coalesce( NullNum,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce( NullNum,  Nully1,              false));
        NoNullRet(1, Coalesce( NullNum,  Nully1, zeroMatters       ));
        NoNullRet(1, Coalesce( NullNum,  Nully1, zeroMatters: true ));
        NoNullRet(1, Coalesce( NullNum,  Nully1,              true ));
        NoNullRet(1, Coalesce(  Nully0,  Nully1                    ));
        NoNullRet(1, Coalesce(  Nully0,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully0,  Nully1,              false));
        NoNullRet(0, Coalesce(  Nully0,  Nully1, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0,  Nully1, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0,  Nully1,              true ));
        NoNullRet(1, Coalesce(       0,  Nully1                    ));
        NoNullRet(1, Coalesce(       0,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce(       0,  Nully1,              false));
        NoNullRet(0, Coalesce(       0,  Nully1, zeroMatters       ));
        NoNullRet(0, Coalesce(       0,  Nully1, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0,  Nully1,              true ));
        NoNullRet(1, Coalesce(       1,  Nully1                    ));
        NoNullRet(1, Coalesce(       1,  Nully1, zeroMatters: false));
        NoNullRet(1, Coalesce(       1,  Nully1,              false));
        NoNullRet(1, Coalesce(       1,  Nully1, zeroMatters       ));
        NoNullRet(1, Coalesce(       1,  Nully1, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1,  Nully1,              true ));
        NoNullRet(0, Coalesce( NullNum,       0                    ));
        NoNullRet(0, Coalesce( NullNum,       0, zeroMatters: false));
        NoNullRet(0, Coalesce( NullNum,       0,              false));
        NoNullRet(0, Coalesce( NullNum,       0, zeroMatters       ));
        NoNullRet(0, Coalesce( NullNum,       0, zeroMatters: true ));
        NoNullRet(0, Coalesce( NullNum,       0,              true ));
        NoNullRet(0, Coalesce(  Nully0,       0                    ));
        NoNullRet(0, Coalesce(  Nully0,       0, zeroMatters: false));
        NoNullRet(0, Coalesce(  Nully0,       0,              false));
        NoNullRet(0, Coalesce(  Nully0,       0, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0,       0, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0,       0,              true ));
        NoNullRet(1, Coalesce(  Nully1,       0                    ));
        NoNullRet(1, Coalesce(  Nully1,       0, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1,       0,              false));
        NoNullRet(1, Coalesce(  Nully1,       0, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1,       0, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1,       0,              true ));
        NoNullRet(1, Coalesce(       1,       0                    ));
        NoNullRet(1, Coalesce(       1,       0, zeroMatters: false));
        NoNullRet(1, Coalesce(       1,       0,              false));
        NoNullRet(1, Coalesce(       1,       0, zeroMatters       ));
        NoNullRet(1, Coalesce(       1,       0, zeroMatters: true ));
        NoNullRet(1, Coalesce(       1,       0,              true ));
        NoNullRet(1, Coalesce( NullNum,       1                    ));
        NoNullRet(1, Coalesce( NullNum,       1, zeroMatters: false));
        NoNullRet(1, Coalesce( NullNum,       1,              false));
        NoNullRet(1, Coalesce( NullNum,       1, zeroMatters       ));
        NoNullRet(1, Coalesce( NullNum,       1, zeroMatters: true ));
        NoNullRet(1, Coalesce( NullNum,       1,              true ));
        NoNullRet(1, Coalesce(  Nully0,       1                    ));
        NoNullRet(1, Coalesce(  Nully0,       1, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully0,       1,              false));
        NoNullRet(0, Coalesce(  Nully0,       1, zeroMatters       ));
        NoNullRet(0, Coalesce(  Nully0,       1, zeroMatters: true ));
        NoNullRet(0, Coalesce(  Nully0,       1,              true ));
        NoNullRet(1, Coalesce(  Nully1,       1                    ));
        NoNullRet(1, Coalesce(  Nully1,       1, zeroMatters: false));
        NoNullRet(1, Coalesce(  Nully1,       1,              false));
        NoNullRet(1, Coalesce(  Nully1,       1, zeroMatters       ));
        NoNullRet(1, Coalesce(  Nully1,       1, zeroMatters: true ));
        NoNullRet(1, Coalesce(  Nully1,       1,              true ));
        NoNullRet(1, Coalesce(       0,       1                    ));
        NoNullRet(1, Coalesce(       0,       1, zeroMatters: false));
        NoNullRet(1, Coalesce(       0,       1,              false));
        NoNullRet(0, Coalesce(       0,       1, zeroMatters       ));
        NoNullRet(0, Coalesce(       0,       1, zeroMatters: true ));
        NoNullRet(0, Coalesce(       0,       1,              true ));
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_Extensions()
    {
        NoNullRet(0,  NullNum.Coalesce( NullNum));
        NoNullRet(0,   Nully0.Coalesce( NullNum));
        NoNullRet(1,   Nully1.Coalesce( NullNum));
        NoNullRet(2,   Nully2.Coalesce( NullNum));
        NoNullRet(0,        0.Coalesce( NullNum));
        NoNullRet(1,        1.Coalesce( NullNum));
        NoNullRet(2,        2.Coalesce( NullNum));
        NoNullRet(0,  NullNum.Coalesce(  Nully0));
        NoNullRet(0,   Nully0.Coalesce(  Nully0));
        NoNullRet(1,   Nully1.Coalesce(  Nully0));
        NoNullRet(2,   Nully2.Coalesce(  Nully0));
        NoNullRet(0,        0.Coalesce(  Nully0));
        NoNullRet(1,        1.Coalesce(  Nully0));
        NoNullRet(2,        2.Coalesce(  Nully0));
        NoNullRet(1,  NullNum.Coalesce(  Nully1));
        NoNullRet(1,   Nully0.Coalesce(  Nully1));
        NoNullRet(1,   Nully1.Coalesce(  Nully1));
        NoNullRet(2,   Nully2.Coalesce(  Nully1));
        NoNullRet(1,        0.Coalesce(  Nully1));
        NoNullRet(1,        1.Coalesce(  Nully1));
        NoNullRet(2,        2.Coalesce(  Nully1));
        NoNullRet(2,  NullNum.Coalesce(  Nully2));
        NoNullRet(2,   Nully0.Coalesce(  Nully2));
        NoNullRet(1,   Nully1.Coalesce(  Nully2));
        NoNullRet(2,   Nully2.Coalesce(  Nully2));
        NoNullRet(2,        0.Coalesce(  Nully2));
        NoNullRet(1,        1.Coalesce(  Nully2));
        NoNullRet(2,        2.Coalesce(  Nully2));
        NoNullRet(0,  NullNum.Coalesce(       0));
        NoNullRet(0,   Nully0.Coalesce(       0));
        NoNullRet(1,   Nully1.Coalesce(       0));
        NoNullRet(2,   Nully2.Coalesce(       0));
        NoNullRet(0,        0.Coalesce(       0));
        NoNullRet(1,        1.Coalesce(       0));
        NoNullRet(2,        2.Coalesce(       0));
        NoNullRet(1,  NullNum.Coalesce(       1));
        NoNullRet(1,   Nully0.Coalesce(       1));
        NoNullRet(1,   Nully1.Coalesce(       1));
        NoNullRet(2,   Nully2.Coalesce(       1));
        NoNullRet(1,        0.Coalesce(       1));
        NoNullRet(1,        1.Coalesce(       1));
        NoNullRet(2,        2.Coalesce(       1));
        NoNullRet(2,  NullNum.Coalesce(       2));
        NoNullRet(2,   Nully0.Coalesce(       2));
        NoNullRet(1,   Nully1.Coalesce(       2));
        NoNullRet(2,   Nully2.Coalesce(       2));
        NoNullRet(2,        0.Coalesce(       2));
        NoNullRet(1,        1.Coalesce(       2));
        NoNullRet(2,        2.Coalesce(       2));
    }

    // TODO: Use zeroMatters parameters
    
    [TestMethod]
    public void Coalesce_2Args_Vals_ExtensionsZeroMatters()
    {
        NoNullRet(0,   Nully0.Coalesce( NullNum));
        NoNullRet(1,   Nully1.Coalesce( NullNum));
        NoNullRet(0,        0.Coalesce( NullNum));
        NoNullRet(1,        1.Coalesce( NullNum));
        NoNullRet(0,  NullNum.Coalesce(  Nully0));
        NoNullRet(1,   Nully1.Coalesce(  Nully0));
        NoNullRet(0,        0.Coalesce(  Nully0));
        NoNullRet(1,        1.Coalesce(  Nully0));
        NoNullRet(1,  NullNum.Coalesce(  Nully1));
        NoNullRet(1,   Nully0.Coalesce(  Nully1));
        NoNullRet(1,        0.Coalesce(  Nully1));
        NoNullRet(1,        1.Coalesce(  Nully1));
        NoNullRet(0,  NullNum.Coalesce(       0));
        NoNullRet(0,   Nully0.Coalesce(       0));
        NoNullRet(1,   Nully1.Coalesce(       0));
        NoNullRet(1,        1.Coalesce(       0));
        NoNullRet(1,  NullNum.Coalesce(       1));
        NoNullRet(1,   Nully0.Coalesce(       1));
        NoNullRet(1,   Nully1.Coalesce(       1));
        NoNullRet(1,        0.Coalesce(       1));
    }

    // Objects

    [TestMethod]
    public void Coalesce_2Args_Objects()
    {
        NoNullRet(              Coalesce(NullObj,     NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullObj    ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NullObj,     NoNullObj  ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NoNullObj  ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NoNullObj  ));
        NoNullRet(NullyFilled!, Coalesce(NullObj,     NullyFilled));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullyFilled));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullyFilled));
        NoNullRet(              NullObj    .Coalesce(NullObj     ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NullObj     ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullObj     ));
        NoNullRet(NoNullObj,    NullObj    .Coalesce(NoNullObj   ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NoNullObj   ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NoNullObj   ));
        NoNullRet(NullyFilled!, NullObj    .Coalesce(NullyFilled ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NullyFilled ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullyFilled ));
    }
}
