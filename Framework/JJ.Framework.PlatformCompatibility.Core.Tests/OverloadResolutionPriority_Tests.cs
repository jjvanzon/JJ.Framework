namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class OverloadResolutionPriority_Tests
{
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Create()
        => new OverloadResolutionPriority_TestBase()
            .Test_PlatformStub_OverloadResolutionPriority_Create();

    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Implicit()
        => new OverloadResolutionPriority_TestBase()
            .Test_PlatformStub_OverloadResolutionPriority_Implicit();
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Explicit() 
        => new OverloadResolutionPriority_TestBase()
            .Test_PlatformStub_OverloadResolutionPriority_Explicit();
}