namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_1Arg_Text_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_1Arg_Text_Literals()
    {
        NoNullRet(""   , ""      .Coalesce());
        NoNullRet("   ", "   "   .Coalesce());
        NoNullRet("Hi" , "Hi"    .Coalesce());
        NoNullRet(""   , Coalesce(NullText ));
        NoNullRet(""   , Coalesce(""       ));
        NoNullRet("   ", Coalesce("   "    ));
        NoNullRet("Hi" , Coalesce("Hi"     ));
    }

    [TestMethod]
    public void Coalesce_1Arg_Text_Vars()
    {
        NoNullRet(Empty, NullText       .Coalesce());
        NoNullRet(Empty, Empty          .Coalesce());
        NoNullRet(Empty, NullyEmpty     .Coalesce());
        NoNullRet(Space, Space          .Coalesce());
        NoNullRet(Space, NullySpace     .Coalesce());
        NoNullRet(Text,  Text           .Coalesce());
        NoNullRet(Text,  NullyFilledText.Coalesce());
        NoNullRet(Empty, Coalesce(NullText       ));
        NoNullRet(Empty, Coalesce(Empty          ));
        NoNullRet(Empty, Coalesce(NullyEmpty     ));
        NoNullRet(Space, Coalesce(Space          ));
        NoNullRet(Space, Coalesce(NullySpace     ));
        NoNullRet(Text,  Coalesce(Text           ));
        NoNullRet(Text,  Coalesce(NullyFilledText));
    }
}