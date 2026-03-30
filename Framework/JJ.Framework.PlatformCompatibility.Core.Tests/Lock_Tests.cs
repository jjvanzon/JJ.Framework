namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class Lock_Tests
{
    private readonly Lock_TestBase _testBase = new();

    [TestMethod]
    public void Test_Lock_PlatformStub() => _testBase.Test_Lock();
}
