namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_2Args_Text_FlagsInBack : TestBase
{
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
}