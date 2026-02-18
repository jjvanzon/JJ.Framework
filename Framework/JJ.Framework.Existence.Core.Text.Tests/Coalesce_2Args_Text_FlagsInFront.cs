namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_2Args_Text_FlagsInFront : TestBase
{
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
}