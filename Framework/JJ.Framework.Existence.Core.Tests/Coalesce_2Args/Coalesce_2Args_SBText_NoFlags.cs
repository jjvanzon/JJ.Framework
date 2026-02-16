namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_SBText_NoFlags : TestBase
{
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
        NoNullRet("",         Coalesce(NullText,  NullText ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback"));
        NoNullRet("Fallback", Coalesce("",       "Fallback"));
        NoNullRet("Fallback", Coalesce("   ",    "Fallback"));
        NoNullRet("",         NullText.Coalesce(  NullText ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback"));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback"));
        NoNullRet("Fallback", "   "   .Coalesce( "Fallback"));
    }

    [TestMethod]
    public void Coalesce_2Args_Text_Vars()
    {
        NoNullRet(Empty, Coalesce(NullText, NullText));
        NoNullRet(Text,  Coalesce(NullText, Text    ));
        NoNullRet(Text,  Coalesce(Empty,    Text    ));
        NoNullRet(Text,  Coalesce(Space,    Text    ));
        NoNullRet(Empty, NullText.Coalesce( NullText));
        NoNullRet(Text,  NullText.Coalesce( Text    ));
        NoNullRet(Text,  Empty   .Coalesce( Text    ));
        NoNullRet(Text,  Space   .Coalesce( Text    ));
    }

    // StringBuilder

    [TestMethod]
    public void Coalesce_2Args_StringBuilder()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB));
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB));
        NoNullRet(          NullSB .Coalesce( NullSB  ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB));
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB));
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB  )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB)}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB)}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB)}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB)}");
    }
    
    // StringBuilder / Text Combos
    
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text));
        NoNullRet(Text,       NullSB       .Coalesce(Text));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder()
    {
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB));
        NoNullRet("",         Coalesce(NullText,        NullSB       ));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB));
        NoNullRet("",         NullText       .Coalesce( NullSB       ));
    }
}