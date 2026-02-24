using System;
using System.IO;

namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class FileHelperCoreTests
{
    [TestMethod]
    public void SmokeTest_FileHelper_CreateDelete()
    {
        string tempFile = Path.GetTempFileName();
        Assert.IsTrue(File.Exists(tempFile));
        File.Delete(tempFile);
        Assert.IsFalse(File.Exists(tempFile));
    }
}
