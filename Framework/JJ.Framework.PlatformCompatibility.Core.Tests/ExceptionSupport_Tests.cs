namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class ExceptionSupport_Tests
{
    private readonly ExceptionSupport_TestBase _testBase = new();

    [TestMethod]
    public void Test_ExceptionSupport_PlatformStub() => _testBase.Test_ExceptionSupport_PlatformStub();
}