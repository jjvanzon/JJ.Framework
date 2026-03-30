namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class HashCode_Tests
{
    private readonly HashCode_TestBase _testBase = new();

    [TestMethod]
    public void Test_HashCode_PlatformStub() => _testBase.Test_HashCode_PlatformStub();
}