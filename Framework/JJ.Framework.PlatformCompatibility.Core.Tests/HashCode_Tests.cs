namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class HashCode_Tests
{
    [TestMethod]
    public void Test_HashCode_PlatformStub() 
        => new HashCode_TestBase()
            .Test_HashCode_PlatformStub();
}