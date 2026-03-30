namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class ExceptionSupport_Shim_Tests
{
    private readonly ExceptionSupport_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_ExceptionSupport_PlatformStub() => _testBase.Test_ExceptionSupport_PlatformStub();
}