namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class ExceptionSupport_Tests
{
    private readonly ExceptionSupport_TestBase _testBase = new();

    [TestMethod]
    public void Test_ThrowIfNull() => _testBase.Test_ThrowIfNull();

    [TestMethod]
    public void Test_ThrowIfNullOrWhiteSpace() => _testBase.Test_ThrowIfNullOrWhiteSpace();
}