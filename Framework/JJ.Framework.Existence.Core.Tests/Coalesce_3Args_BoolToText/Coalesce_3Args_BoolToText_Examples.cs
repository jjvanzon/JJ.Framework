namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_BoolToText_Examples : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_ValsToString_Examples()
    {
        NoNullRet("True", NullyTrue.Coalesce( NullBool, NullText));
        NoNullRet(Text,   false    .Coalesce( NullBool, Text    ));
        NoNullRet("True", Coalesce(true,  NullBool, NullText));
        NoNullRet(Text,   Coalesce(false, NullBool, Text    ));
    }
}