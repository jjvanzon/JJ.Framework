namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class DummyTests
{
    [TestMethod]
    public void SmokeTest_CreateDeleteFile()
    {
        string tempFile = Path.GetTempFileName();
        Assert.IsTrue(File.Exists(tempFile));
        File.Delete(tempFile);
        Assert.IsFalse(File.Exists(tempFile));
    }
}
