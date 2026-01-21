namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_ValuesToText_Examples : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_ValsToString_Examples()
    {
        NoNullRet("1", Nully1.Coalesce(NullNum, NullText));
        NoNullRet(Text, 0.Coalesce(NullNum, Text));
        NoNullRet("1", Coalesce(1, NullNum, NullText));
        NoNullRet(Text, Coalesce(0, NullNum, Text));
    }
}