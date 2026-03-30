
namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class CallerArgumentExpression_Shim_Tests
{
    private readonly CallerArgumentExpression_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformStub() => _testBase.Test_CallerArgumentExpression_PlatformStub();
}