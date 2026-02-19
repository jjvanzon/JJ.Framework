namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_2Args_Text_NoFlags : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_Text_Examples()
    {
        NoNullRet("Hello", Coalesce("", "Hello", "World"));
        NoNullRet("Hello", "".Coalesce("Hello", "World"));
    }

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
}