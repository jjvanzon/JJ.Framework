namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class DummyTests
{
    [TestMethod]
    public void SmokeTest_CreateDeleteFile()
    {
        string tempFile = Path.GetTempFileName();
        IsTrue(File.Exists(tempFile));
        File.Delete(tempFile);
        IsFalse(File.Exists(tempFile));
    }
}
