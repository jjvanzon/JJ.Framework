using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Configuration.Core.Test.Dummy;

[TestClass]
public class DummyTests
{
    [TestMethod]
    public void DummyTest()
    {
        string? name = System.Configuration.ConfigurationManager.AppSettings.Get("SourceFileName");
        Assert.IsNotNull(name);
    }

}
