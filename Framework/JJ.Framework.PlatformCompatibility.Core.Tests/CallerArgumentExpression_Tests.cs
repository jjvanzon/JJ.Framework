namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class CallerArgumentExpression_Tests
{
    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformStub() 
        => new CallerArgumentExpression_TestBase()
            .Test_CallerArgumentExpression_PlatformStub();
}