namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigManagerCoreTests
{
    [TestMethod]
    public void Test_CustomConfigManagerCore_MainCase()
    {
        var config = CustomConfigManagerCore.GetSection<ConfigSection>("jj.framework.configuration.core.tests");
    }
}