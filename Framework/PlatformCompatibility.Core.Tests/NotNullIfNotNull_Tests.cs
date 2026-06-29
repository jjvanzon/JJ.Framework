namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class NotNullIfNotNull_Tests
{
    private readonly NotNullIfNotNull_TestBase _testBase = new();

    [TestMethod]
    public void Test_NotNullIfNotNull_Constructor() => _testBase.Test_NotNullIfNotNull_Constructor();

    [TestMethod]
    public void Test_NotNullIfNotNull_Nullabilities() => _testBase.Test_NotNullIfNotNull_Nullabilities();
}
