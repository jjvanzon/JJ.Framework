namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class OperatingSystemSupport_Tests
{
    private readonly OperatingSystemSupport_TestBase _testBase = new();

    [TestMethod]
    public void Test_IsWindows() => _testBase.Test_IsWindows();
}
