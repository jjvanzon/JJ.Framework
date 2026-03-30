namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class OverloadResolutionPriority_Tests
{
    private readonly OverloadResolutionPriority_TestBase _testBase = new();

    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Create() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Create();

    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Implicit() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Implicit();
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Explicit() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Explicit();
}