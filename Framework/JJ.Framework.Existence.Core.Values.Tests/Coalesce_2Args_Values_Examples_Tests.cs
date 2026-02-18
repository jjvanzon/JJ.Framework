namespace JJ.Framework.Existence.Core.Values.Tests;

[TestClass]
public class Coalesce_2Args_Values_Examples_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_Values_Examples()
    {
        NoNullRet(1, Coalesce(null, 0, 1));
        NoNullRet(0, Coalesce(null, 0, 1, zeroMatters));
    }
}