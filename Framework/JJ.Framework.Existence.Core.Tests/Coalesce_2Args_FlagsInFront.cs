namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_FlagsInFront : TestBase
{
    // Text

    [TestMethod]
    public void Coalesce_2Args_Text_LiteralsFlagsInBack()
    {
        NoNullRet("",         Coalesce(spaceMatters: false, NullText,  NullText ));
        NoNullRet("Fallback", Coalesce(spaceMatters: false, NullText, "Fallback"));
        NoNullRet("Fallback", Coalesce(spaceMatters: false, "",       "Fallback"));
        NoNullRet("Fallback", Coalesce(spaceMatters: false, "   ",    "Fallback"));
        NoNullRet("",         Coalesce(spaceMatters: true,  NullText,  NullText ));
        NoNullRet("Fallback", Coalesce(spaceMatters: true,  NullText, "Fallback"));
        NoNullRet("Fallback", Coalesce(spaceMatters: true,  "",       "Fallback"));
        NoNullRet("   ",      Coalesce(spaceMatters: true,  "   ",    "Fallback"));
        NoNullRet("",         Coalesce(spaceMatters,        NullText,  NullText ));
        NoNullRet("Fallback", Coalesce(spaceMatters,        NullText, "Fallback"));
        NoNullRet("Fallback", Coalesce(spaceMatters,        "",       "Fallback"));
        NoNullRet("   ",      Coalesce(spaceMatters,        "   ",    "Fallback"));
        NoNullRet("",         NullText.Coalesce(spaceMatters: false,   NullText ));
        NoNullRet("Fallback", NullText.Coalesce(spaceMatters: false,  "Fallback"));
        NoNullRet("Fallback", ""      .Coalesce(spaceMatters: false,  "Fallback"));
        NoNullRet("Fallback", "   "   .Coalesce(spaceMatters: false,  "Fallback"));
        NoNullRet("",         NullText.Coalesce(spaceMatters: true,    NullText ));
        NoNullRet("Fallback", NullText.Coalesce(spaceMatters: true,   "Fallback"));
        NoNullRet("Fallback", ""      .Coalesce(spaceMatters: true,   "Fallback"));
        NoNullRet("   ",      "   "   .Coalesce(spaceMatters: true,   "Fallback"));
        NoNullRet("",         NullText.Coalesce(spaceMatters,          NullText ));
        NoNullRet("Fallback", NullText.Coalesce(spaceMatters,         "Fallback"));
        NoNullRet("Fallback", ""      .Coalesce(spaceMatters,         "Fallback"));
        NoNullRet("   ",      "   "   .Coalesce(spaceMatters,         "Fallback"));
    }

    [TestMethod]
    public void Coalesce_2Args_Text_VarsFlagsInBack()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullText, NullText));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullText, Text    ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,    Text    ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,    Text    ));
        NoNullRet(Empty, Coalesce(spaceMatters: true,  NullText, NullText));
        NoNullRet(Text,  Coalesce(spaceMatters: true,  NullText, Text    ));
        NoNullRet(Text,  Coalesce(spaceMatters: true,  Empty,    Text    ));
        NoNullRet(Space, Coalesce(spaceMatters: true,  Space,    Text    ));
        NoNullRet(Empty, Coalesce(spaceMatters,        NullText, NullText));
        NoNullRet(Text,  Coalesce(spaceMatters,        NullText, Text    ));
        NoNullRet(Text,  Coalesce(spaceMatters,        Empty,    Text    ));
        NoNullRet(Space, Coalesce(spaceMatters,        Space,    Text    ));
        NoNullRet(Empty, NullText.Coalesce(spaceMatters: false,  NullText));
        NoNullRet(Text,  NullText.Coalesce(spaceMatters: false,  Text    ));
        NoNullRet(Text,  Empty   .Coalesce(spaceMatters: false,  Text    ));
        NoNullRet(Text,  Space   .Coalesce(spaceMatters: false,  Text    ));
        NoNullRet(Empty, NullText.Coalesce(spaceMatters: true,   NullText));
        NoNullRet(Text,  NullText.Coalesce(spaceMatters: true,   Text    ));
        NoNullRet(Text,  Empty   .Coalesce(spaceMatters: true,   Text    ));
        NoNullRet(Space, Space   .Coalesce(spaceMatters: true,   Text    ));
        NoNullRet(Empty, NullText.Coalesce(spaceMatters,         NullText));
        NoNullRet(Text,  NullText.Coalesce(spaceMatters,         Text    ));
        NoNullRet(Text,  Empty   .Coalesce(spaceMatters,         Text    ));
        NoNullRet(Space, Space   .Coalesce(spaceMatters,         Text    ));
    }
    
    // StringBuilder

    [TestMethod]
    public void Coalesce_2Args_StringBuilder_VarsFlagsInBack()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(spaceMatters: false, NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, EmptySB, FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, SpaceSB, FilledSB));
        NoNullRet(          Coalesce(spaceMatters: true,  NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(spaceMatters: true,  NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: true,  NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: true,  EmptySB, FilledSB));
        NoNullRet(SpaceSB,  Coalesce(spaceMatters: true,  SpaceSB, FilledSB));
        NoNullRet(          Coalesce(spaceMatters,        NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(spaceMatters,        NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters,        NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters,        EmptySB, FilledSB));
        NoNullRet(SpaceSB,  Coalesce(spaceMatters,        SpaceSB, FilledSB));
        NoNullRet(          NullSB .Coalesce(spaceMatters: false, NullSB   ));
        NoNullRet(FilledSB, NullSB .Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(FilledSB, NewSB  .Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(FilledSB, EmptySB.Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(FilledSB, SpaceSB.Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(          NullSB .Coalesce(spaceMatters: true,  NullSB   ));
        NoNullRet(FilledSB, NullSB .Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(FilledSB, NewSB  .Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(FilledSB, EmptySB.Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(          NullSB .Coalesce(spaceMatters,        NullSB   ));
        NoNullRet(FilledSB, NullSB .Coalesce(spaceMatters,        FilledSB ));
        NoNullRet(FilledSB, NewSB  .Coalesce(spaceMatters,        FilledSB ));
        NoNullRet(FilledSB, EmptySB.Coalesce(spaceMatters,        FilledSB ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce(spaceMatters,        FilledSB ));
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(spaceMatters: false, NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, EmptySB, FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{Coalesce(spaceMatters: true,  NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: true,  NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: true,  NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: true,  EmptySB, FilledSB)}");
        NoNullRet(Space,      $"{Coalesce(spaceMatters: true,  SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{Coalesce(spaceMatters,        NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters,        NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters,        NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters,        EmptySB, FilledSB)}");
        NoNullRet(Space,      $"{Coalesce(spaceMatters,        SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce(spaceMatters: false, NullSB   )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce(spaceMatters: true,  NullSB   )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce(spaceMatters,        NullSB   )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce(spaceMatters,        FilledSB )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce(spaceMatters,        FilledSB )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce(spaceMatters,        FilledSB )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce(spaceMatters,        FilledSB )}");
    }
    
    // StringBuilder / Text Combos
    
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersNoFlagsInBack()
    {
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        Text));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      Text));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Text));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false,  Text));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false,  Text));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false,  Text));
    }

    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(" ",      Coalesce(spaceMatters,       NullySpaceSB, NullyFilledText));
        NoNullRet(" ",      Coalesce(spaceMatters: true, NullySpaceSB, NullyFilledText));
        NoNullRet("Filled", Coalesce(spaceMatters,       NullyEmptySB, NullyFilledText));
        NoNullRet("Filled", Coalesce(spaceMatters: true, NullyEmptySB, NullyFilledText));
        NoNullRet(" ",      NullySpaceSB.Coalesce(spaceMatters,        NullyFilledText));
        NoNullRet(" ",      NullySpaceSB.Coalesce(spaceMatters: true,  NullyFilledText));
        NoNullRet("Filled", NullyEmptySB.Coalesce(spaceMatters,        NullyFilledText));
        NoNullRet("Filled", NullyEmptySB.Coalesce(spaceMatters: true,  NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullText,        NullyFilledSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilledText, NullyFilledSB ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullText,        NullSB        ));
        NoNullRet("FilledSB", NullText       .Coalesce(spaceMatters: false,  NullyFilledSB ));
        NoNullRet("Filled",   NullyFilledText.Coalesce(spaceMatters: false,  NullyFilledSB ));
        NoNullRet("",         NullText       .Coalesce(spaceMatters: false,  NullSB        ));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(Space,      Coalesce(spaceMatters,       NullySpace, NullyFilledSB));
        NoNullRet(Space,      Coalesce(spaceMatters: true, NullySpace, NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters,       NullyEmpty, NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty, NullyFilledSB));
        NoNullRet(Space,      NullySpace.Coalesce(spaceMatters,        NullyFilledSB));
        NoNullRet(Space,      NullySpace.Coalesce(spaceMatters: true,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty.Coalesce(spaceMatters,        NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty.Coalesce(spaceMatters: true,  NullyFilledSB));
    }

    // Objects to Text

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_ValToText_ZeroMattersNoNulliesFlagsInBack()
    {
        NoNullRet("",           Coalesce(zeroMatters: false, 0,  NullText ));
        NoNullRet("",           Coalesce(             false, 0,  NullText ));
        NoNullRet("0",          Coalesce(zeroMatters,        0,  NullText ));
        NoNullRet("0",          Coalesce(zeroMatters: true,  0,  NullText ));
        NoNullRet("0",          Coalesce(             true,  0,  NullText ));
        NoNullRet("peekaboo",   Coalesce(zeroMatters: false, 0, "peekaboo"));
        NoNullRet("peekaboo",   Coalesce(             false, 0, "peekaboo"));
        NoNullRet("0",          Coalesce(zeroMatters,        0, "peekaboo"));
        NoNullRet("0",          Coalesce(zeroMatters: true,  0, "peekaboo"));
        NoNullRet("0",          Coalesce(             true,  0, "peekaboo"));
        NoNullRet("1",          Coalesce(zeroMatters: false, 1,  NullText ));
        NoNullRet("1",          Coalesce(             false, 1,  NullText ));
        NoNullRet("1",          Coalesce(zeroMatters,        1,  NullText ));
        NoNullRet("1",          Coalesce(zeroMatters: true,  1,  NullText ));
        NoNullRet("1",          Coalesce(             true,  1,  NullText ));
        NoNullRet("1",          Coalesce(zeroMatters: false, 1, "peekaboo"));
        NoNullRet("1",          Coalesce(             false, 1, "peekaboo"));
        NoNullRet("1",          Coalesce(zeroMatters,        1, "peekaboo"));
        NoNullRet("1",          Coalesce(zeroMatters: true,  1, "peekaboo"));
        NoNullRet("1",          Coalesce(             true,  1, "peekaboo"));
        NoNullRet("",         0.Coalesce(zeroMatters: false,     NullText ));
        NoNullRet("",         0.Coalesce(             false,     NullText ));
        NoNullRet("0",        0.Coalesce(zeroMatters,            NullText ));
        NoNullRet("0",        0.Coalesce(zeroMatters: true,      NullText ));
        NoNullRet("0",        0.Coalesce(             true,      NullText ));
        NoNullRet("peekaboo", 0.Coalesce(zeroMatters: false,    "peekaboo"));
        NoNullRet("peekaboo", 0.Coalesce(             false,    "peekaboo"));
        NoNullRet("0",        0.Coalesce(zeroMatters,           "peekaboo"));
        NoNullRet("0",        0.Coalesce(zeroMatters: true,     "peekaboo"));
        NoNullRet("0",        0.Coalesce(             true,     "peekaboo"));
        NoNullRet("1",        1.Coalesce(zeroMatters: false,     NullText ));
        NoNullRet("1",        1.Coalesce(             false,     NullText ));
        NoNullRet("1",        1.Coalesce(zeroMatters,            NullText ));
        NoNullRet("1",        1.Coalesce(zeroMatters: true,      NullText ));
        NoNullRet("1",        1.Coalesce(             true,      NullText ));
        NoNullRet("1",        1.Coalesce(zeroMatters: false,    "peekaboo"));
        NoNullRet("1",        1.Coalesce(             false,    "peekaboo"));
        NoNullRet("1",        1.Coalesce(zeroMatters,           "peekaboo"));
        NoNullRet("1",        1.Coalesce(zeroMatters: true,     "peekaboo"));
        NoNullRet("1",        1.Coalesce(             true,     "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_ZeroMattersWithNulliesFlagsInBack()
    {
        NoNullRet("",    Coalesce(zeroMatters: false, NullNum,   NullText));
        NoNullRet("",    Coalesce(             false, NullNum,   NullText));
        NoNullRet("",    Coalesce(zeroMatters,        NullNum,   NullText));
        NoNullRet("",    Coalesce(zeroMatters: true,  NullNum,   NullText));
        NoNullRet("",    Coalesce(             true,  NullNum,   NullText));
        NoNullRet("boo", Coalesce(zeroMatters: false, NullNum,  "boo"    ));
        NoNullRet("boo", Coalesce(             false, NullNum,  "boo"    ));
        NoNullRet("boo", Coalesce(zeroMatters,        NullNum,  "boo"    ));
        NoNullRet("boo", Coalesce(zeroMatters: true,  NullNum,  "boo"    ));
        NoNullRet("boo", Coalesce(             true,  NullNum,  "boo"    ));
        NoNullRet("",    Coalesce(zeroMatters: false, Nully0,    NullText));
        NoNullRet("",    Coalesce(             false, Nully0,    NullText));
        NoNullRet("0",   Coalesce(zeroMatters,        Nully0,    NullText));
        NoNullRet("0",   Coalesce(zeroMatters: true,  Nully0,    NullText));
        NoNullRet("0",   Coalesce(             true,  Nully0,    NullText));
        NoNullRet("boo", Coalesce(zeroMatters: false, Nully0,   "boo"    ));
        NoNullRet("boo", Coalesce(             false, Nully0,   "boo"    ));
        NoNullRet("0",   Coalesce(zeroMatters,        Nully0,   "boo"    ));
        NoNullRet("0",   Coalesce(zeroMatters: true,  Nully0,   "boo"    ));
        NoNullRet("0",   Coalesce(             true,  Nully0,   "boo"    ));
        NoNullRet("1",   Coalesce(zeroMatters: false, Nully1,    NullText));
        NoNullRet("1",   Coalesce(             false, Nully1,    NullText));
        NoNullRet("1",   Coalesce(zeroMatters,        Nully1,    NullText));
        NoNullRet("1",   Coalesce(zeroMatters: true,  Nully1,    NullText));
        NoNullRet("1",   Coalesce(             true,  Nully1,    NullText));
        NoNullRet("1",   Coalesce(zeroMatters: false, Nully1,   "boo"    ));
        NoNullRet("1",   Coalesce(             false, Nully1,   "boo"    ));
        NoNullRet("1",   Coalesce(zeroMatters,        Nully1,   "boo"    ));
        NoNullRet("1",   Coalesce(zeroMatters: true,  Nully1,   "boo"    ));
        NoNullRet("1",   Coalesce(             true,  Nully1,   "boo"    ));
        NoNullRet("",    NullNum.Coalesce(zeroMatters: false,   NullText ));
        NoNullRet("",    NullNum.Coalesce(             false,   NullText ));
        NoNullRet("",    NullNum.Coalesce(zeroMatters,          NullText ));
        NoNullRet("",    NullNum.Coalesce(zeroMatters: true,    NullText ));
        NoNullRet("",    NullNum.Coalesce(             true,    NullText ));
        NoNullRet("boo", NullNum.Coalesce(zeroMatters: false,  "boo"     ));
        NoNullRet("boo", NullNum.Coalesce(             false,  "boo"     ));
        NoNullRet("boo", NullNum.Coalesce(zeroMatters,         "boo"     ));
        NoNullRet("boo", NullNum.Coalesce(zeroMatters: true,   "boo"     ));
        NoNullRet("boo", NullNum.Coalesce(             true,   "boo"     ));
        NoNullRet("",    Nully0 .Coalesce(zeroMatters: false,   NullText ));
        NoNullRet("",    Nully0 .Coalesce(             false,   NullText ));
        NoNullRet("0",   Nully0 .Coalesce(zeroMatters,          NullText ));
        NoNullRet("0",   Nully0 .Coalesce(zeroMatters: true,    NullText ));
        NoNullRet("0",   Nully0 .Coalesce(             true,    NullText ));
        NoNullRet("boo", Nully0 .Coalesce(zeroMatters: false,  "boo"     ));
        NoNullRet("boo", Nully0 .Coalesce(             false,  "boo"     ));
        NoNullRet("0",   Nully0 .Coalesce(zeroMatters,         "boo"     ));
        NoNullRet("0",   Nully0 .Coalesce(zeroMatters: true,   "boo"     ));
        NoNullRet("0",   Nully0 .Coalesce(             true,   "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(zeroMatters: false,   NullText ));
        NoNullRet("1",   Nully1 .Coalesce(             false,   NullText ));
        NoNullRet("1",   Nully1 .Coalesce(zeroMatters,          NullText ));
        NoNullRet("1",   Nully1 .Coalesce(zeroMatters: true,    NullText ));
        NoNullRet("1",   Nully1 .Coalesce(             true,    NullText ));
        NoNullRet("1",   Nully1 .Coalesce(zeroMatters: false,  "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(             false,  "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(zeroMatters,         "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(zeroMatters: true,   "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(             true,   "boo"     ));
    }

    // Vals

    [TestMethod]
    public void Coalesce_2Args_Vals_StaticZeroMattersFlagsInBack()
    {
        NoNullRet(0, Coalesce(zeroMatters: false,  Nully0, NullNum));
        NoNullRet(0, Coalesce(             false,  Nully0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters,         Nully0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true,   Nully0, NullNum));
        NoNullRet(0, Coalesce(             true,   Nully0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false,  Nully1, NullNum));
        NoNullRet(1, Coalesce(             false,  Nully1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters,         Nully1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true,   Nully1, NullNum));
        NoNullRet(1, Coalesce(             true,   Nully1, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: false,       0, NullNum));
        NoNullRet(0, Coalesce(             false,       0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters,              0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true,        0, NullNum));
        NoNullRet(0, Coalesce(             true,        0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false,       1, NullNum));
        NoNullRet(1, Coalesce(             false,       1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters,              1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true,        1, NullNum));
        NoNullRet(1, Coalesce(             true,        1, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum,  Nully0));
        NoNullRet(0, Coalesce(             false, NullNum,  Nully0));
        NoNullRet(0, Coalesce(zeroMatters,        NullNum,  Nully0));
        NoNullRet(0, Coalesce(zeroMatters: true,  NullNum,  Nully0));
        NoNullRet(0, Coalesce(             true,  NullNum,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters: false,  Nully1,  Nully0));
        NoNullRet(1, Coalesce(             false,  Nully1,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters,         Nully1,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters: true,   Nully1,  Nully0));
        NoNullRet(1, Coalesce(             true,   Nully1,  Nully0));
        NoNullRet(0, Coalesce(zeroMatters: false,       0,  Nully0));
        NoNullRet(0, Coalesce(             false,       0,  Nully0));
        NoNullRet(0, Coalesce(zeroMatters,              0,  Nully0));
        NoNullRet(0, Coalesce(zeroMatters: true,        0,  Nully0));
        NoNullRet(0, Coalesce(             true,        0,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters: false,       1,  Nully0));
        NoNullRet(1, Coalesce(             false,       1,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters,              1,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters: true,        1,  Nully0));
        NoNullRet(1, Coalesce(             true,        1,  Nully0));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum,  Nully1));
        NoNullRet(1, Coalesce(             false, NullNum,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters,        NullNum,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters: true,  NullNum,  Nully1));
        NoNullRet(1, Coalesce(             true,  NullNum,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters: false,  Nully0,  Nully1));
        NoNullRet(1, Coalesce(             false,  Nully0,  Nully1));
        NoNullRet(0, Coalesce(zeroMatters,         Nully0,  Nully1));
        NoNullRet(0, Coalesce(zeroMatters: true,   Nully0,  Nully1));
        NoNullRet(0, Coalesce(             true,   Nully0,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters: false,       0,  Nully1));
        NoNullRet(1, Coalesce(             false,       0,  Nully1));
        NoNullRet(0, Coalesce(zeroMatters,              0,  Nully1));
        NoNullRet(0, Coalesce(zeroMatters: true,        0,  Nully1));
        NoNullRet(0, Coalesce(             true,        0,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters: false,       1,  Nully1));
        NoNullRet(1, Coalesce(             false,       1,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters,              1,  Nully1));
        NoNullRet(1, Coalesce(zeroMatters: true,        1,  Nully1));
        NoNullRet(1, Coalesce(             true,        1,  Nully1));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum,       0));
        NoNullRet(0, Coalesce(             false, NullNum,       0));
        NoNullRet(0, Coalesce(zeroMatters,        NullNum,       0));
        NoNullRet(0, Coalesce(zeroMatters: true,  NullNum,       0));
        NoNullRet(0, Coalesce(             true,  NullNum,       0));
        NoNullRet(0, Coalesce(zeroMatters: false,  Nully0,       0));
        NoNullRet(0, Coalesce(             false,  Nully0,       0));
        NoNullRet(0, Coalesce(zeroMatters,         Nully0,       0));
        NoNullRet(0, Coalesce(zeroMatters: true,   Nully0,       0));
        NoNullRet(0, Coalesce(             true,   Nully0,       0));
        NoNullRet(1, Coalesce(zeroMatters: false,  Nully1,       0));
        NoNullRet(1, Coalesce(             false,  Nully1,       0));
        NoNullRet(1, Coalesce(zeroMatters,         Nully1,       0));
        NoNullRet(1, Coalesce(zeroMatters: true,   Nully1,       0));
        NoNullRet(1, Coalesce(             true,   Nully1,       0));
        NoNullRet(1, Coalesce(zeroMatters: false,       1,       0));
        NoNullRet(1, Coalesce(             false,       1,       0));
        NoNullRet(1, Coalesce(zeroMatters,              1,       0));
        NoNullRet(1, Coalesce(zeroMatters: true,        1,       0));
        NoNullRet(1, Coalesce(             true,        1,       0));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum,       1));
        NoNullRet(1, Coalesce(             false, NullNum,       1));
        NoNullRet(1, Coalesce(zeroMatters,        NullNum,       1));
        NoNullRet(1, Coalesce(zeroMatters: true,  NullNum,       1));
        NoNullRet(1, Coalesce(             true,  NullNum,       1));
        NoNullRet(1, Coalesce(zeroMatters: false,  Nully0,       1));
        NoNullRet(1, Coalesce(             false,  Nully0,       1));
        NoNullRet(0, Coalesce(zeroMatters,         Nully0,       1));
        NoNullRet(0, Coalesce(zeroMatters: true,   Nully0,       1));
        NoNullRet(0, Coalesce(             true,   Nully0,       1));
        NoNullRet(1, Coalesce(zeroMatters: false,  Nully1,       1));
        NoNullRet(1, Coalesce(             false,  Nully1,       1));
        NoNullRet(1, Coalesce(zeroMatters,         Nully1,       1));
        NoNullRet(1, Coalesce(zeroMatters: true,   Nully1,       1));
        NoNullRet(1, Coalesce(             true,   Nully1,       1));
        NoNullRet(1, Coalesce(zeroMatters: false,       0,       1));
        NoNullRet(1, Coalesce(             false,       0,       1));
        NoNullRet(0, Coalesce(zeroMatters,              0,       1));
        NoNullRet(0, Coalesce(zeroMatters: true,        0,       1));
        NoNullRet(0, Coalesce(             true,        0,       1));
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_ExtensionsZeroMattersFlagsInBack()
    {
        NoNullRet(0,   Nully0.Coalesce(zeroMatters: false, NullNum));
        NoNullRet(0,   Nully0.Coalesce(             false, NullNum));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters,        NullNum));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters: true,  NullNum));
        NoNullRet(0,   Nully0.Coalesce(             true,  NullNum));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: false, NullNum));
        NoNullRet(1,   Nully1.Coalesce(             false, NullNum));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters,        NullNum));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: true,  NullNum));
        NoNullRet(1,   Nully1.Coalesce(             true,  NullNum));
        NoNullRet(0,        0.Coalesce(zeroMatters: false, NullNum));
        NoNullRet(0,        0.Coalesce(             false, NullNum));
        NoNullRet(0,        0.Coalesce(zeroMatters,        NullNum));
        NoNullRet(0,        0.Coalesce(zeroMatters: true,  NullNum));
        NoNullRet(0,        0.Coalesce(             true,  NullNum));
        NoNullRet(1,        1.Coalesce(zeroMatters: false, NullNum));
        NoNullRet(1,        1.Coalesce(             false, NullNum));
        NoNullRet(1,        1.Coalesce(zeroMatters,        NullNum));
        NoNullRet(1,        1.Coalesce(zeroMatters: true,  NullNum));
        NoNullRet(1,        1.Coalesce(             true,  NullNum));
        NoNullRet(0,  NullNum.Coalesce(zeroMatters: false,  Nully0));
        NoNullRet(0,  NullNum.Coalesce(             false,  Nully0));
        NoNullRet(0,  NullNum.Coalesce(zeroMatters,         Nully0));
        NoNullRet(0,  NullNum.Coalesce(zeroMatters: true,   Nully0));
        NoNullRet(0,  NullNum.Coalesce(             true,   Nully0));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: false,  Nully0));
        NoNullRet(1,   Nully1.Coalesce(             false,  Nully0));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters,         Nully0));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: true,   Nully0));
        NoNullRet(1,   Nully1.Coalesce(             true,   Nully0));
        NoNullRet(0,        0.Coalesce(zeroMatters: false,  Nully0));
        NoNullRet(0,        0.Coalesce(             false,  Nully0));
        NoNullRet(0,        0.Coalesce(zeroMatters,         Nully0));
        NoNullRet(0,        0.Coalesce(zeroMatters: true,   Nully0));
        NoNullRet(0,        0.Coalesce(             true,   Nully0));
        NoNullRet(1,        1.Coalesce(zeroMatters: false,  Nully0));
        NoNullRet(1,        1.Coalesce(             false,  Nully0));
        NoNullRet(1,        1.Coalesce(zeroMatters,         Nully0));
        NoNullRet(1,        1.Coalesce(zeroMatters: true,   Nully0));
        NoNullRet(1,        1.Coalesce(             true,   Nully0));
        NoNullRet(1,  NullNum.Coalesce(zeroMatters: false,  Nully1));
        NoNullRet(1,  NullNum.Coalesce(             false,  Nully1));
        NoNullRet(1,  NullNum.Coalesce(zeroMatters,         Nully1));
        NoNullRet(1,  NullNum.Coalesce(zeroMatters: true,   Nully1));
        NoNullRet(1,  NullNum.Coalesce(             true,   Nully1));
        NoNullRet(1,   Nully0.Coalesce(zeroMatters: false,  Nully1));
        NoNullRet(1,   Nully0.Coalesce(             false,  Nully1));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters,         Nully1));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters: true,   Nully1));
        NoNullRet(0,   Nully0.Coalesce(             true,   Nully1));
        NoNullRet(1,        0.Coalesce(zeroMatters: false,  Nully1));
        NoNullRet(1,        0.Coalesce(             false,  Nully1));
        NoNullRet(0,        0.Coalesce(zeroMatters,         Nully1));
        NoNullRet(0,        0.Coalesce(zeroMatters: true,   Nully1));
        NoNullRet(0,        0.Coalesce(             true,   Nully1));
        NoNullRet(1,        1.Coalesce(zeroMatters: false,  Nully1));
        NoNullRet(1,        1.Coalesce(             false,  Nully1));
        NoNullRet(1,        1.Coalesce(zeroMatters,         Nully1));
        NoNullRet(1,        1.Coalesce(zeroMatters: true,   Nully1));
        NoNullRet(1,        1.Coalesce(             true,   Nully1));
        NoNullRet(0,  NullNum.Coalesce(zeroMatters: false,       0));
        NoNullRet(0,  NullNum.Coalesce(             false,       0));
        NoNullRet(0,  NullNum.Coalesce(zeroMatters,              0));
        NoNullRet(0,  NullNum.Coalesce(zeroMatters: true,        0));
        NoNullRet(0,  NullNum.Coalesce(             true,        0));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters: false,       0));
        NoNullRet(0,   Nully0.Coalesce(             false,       0));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters,              0));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters: true,        0));
        NoNullRet(0,   Nully0.Coalesce(             true,        0));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: false,       0));
        NoNullRet(1,   Nully1.Coalesce(             false,       0));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters,              0));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: true,        0));
        NoNullRet(1,   Nully1.Coalesce(             true,        0));
        NoNullRet(1,        1.Coalesce(zeroMatters: false,       0));
        NoNullRet(1,        1.Coalesce(             false,       0));
        NoNullRet(1,        1.Coalesce(zeroMatters,              0));
        NoNullRet(1,        1.Coalesce(zeroMatters: true,        0));
        NoNullRet(1,        1.Coalesce(             true,        0));
        NoNullRet(1,  NullNum.Coalesce(zeroMatters: false,       1));
        NoNullRet(1,  NullNum.Coalesce(             false,       1));
        NoNullRet(1,  NullNum.Coalesce(zeroMatters,              1));
        NoNullRet(1,  NullNum.Coalesce(zeroMatters: true,        1));
        NoNullRet(1,  NullNum.Coalesce(             true,        1));
        NoNullRet(1,   Nully0.Coalesce(zeroMatters: false,       1));
        NoNullRet(1,   Nully0.Coalesce(             false,       1));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters,              1));
        NoNullRet(0,   Nully0.Coalesce(zeroMatters: true,        1));
        NoNullRet(0,   Nully0.Coalesce(             true,        1));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: false,       1));
        NoNullRet(1,   Nully1.Coalesce(             false,       1));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters,              1));
        NoNullRet(1,   Nully1.Coalesce(zeroMatters: true,        1));
        NoNullRet(1,   Nully1.Coalesce(             true,        1));
        NoNullRet(1,        0.Coalesce(zeroMatters: false,       1));
        NoNullRet(1,        0.Coalesce(             false,       1));
        NoNullRet(0,        0.Coalesce(zeroMatters,              1));
        NoNullRet(0,        0.Coalesce(zeroMatters: true,        1));
        NoNullRet(0,        0.Coalesce(             true,        1));
    }
}
