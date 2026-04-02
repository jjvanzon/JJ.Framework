
namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class CallerArgumentExpression_Tests
{
    private readonly CallerArgumentExpression_TestBase _testBase = new();

    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformStub() => _testBase.Test_CallerArgumentExpression_PlatformStub();
}