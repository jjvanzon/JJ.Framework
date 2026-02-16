namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_SBText_FlagsInFront : TestBase
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
}