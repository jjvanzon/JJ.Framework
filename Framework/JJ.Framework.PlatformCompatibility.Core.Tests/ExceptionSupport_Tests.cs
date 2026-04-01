namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class ExceptionSupport_Tests
{
    [TestMethod]
    public void Test_ThrowIfNull() 
        => new ExceptionSupport_TestBase()
            .Test_ThrowIfNull();

    [TestMethod]
    public void Test_ThrowIfNullOrWhiteSpace() 
        => new ExceptionSupport_TestBase()
            .Test_ThrowIfNullOrWhiteSpace();
}