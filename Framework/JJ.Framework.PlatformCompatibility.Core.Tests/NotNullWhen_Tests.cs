namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class NotNullWhen_Tests
{
    private readonly NotNullWhen_TestBase _testBase = new();

    [TestMethod]
    public void Test_NotNullWhen_PlatformStub() => _testBase.Test_NotNullWhen_PlatformStub();
}