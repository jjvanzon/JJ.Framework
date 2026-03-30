namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class NotNullWhen_Shim_Tests
{
    private readonly NotNullWhen_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_NotNullWhen_PlatformStub() => _testBase.Test_NotNullWhen_PlatformStub();
}