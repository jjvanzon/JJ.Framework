
namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Core_Tests
{
    private readonly PlatformCompatibility_Core_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformStub() => _testBase.Test_CallerArgumentExpression_PlatformStub();

    [TestMethod]
    public void Test_ExceptionSupport_PlatformStub() => _testBase.Test_ExceptionSupport_PlatformStub();
    
    [TestMethod]
    public void Test_HashCode_PlatformStub() => _testBase.Test_HashCode_PlatformStub();
    
    [TestMethod]
    public void Test_NotNullWhen_PlatformStub() => _testBase.Test_NotNullWhen_PlatformStub();
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Create() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Create();

    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Implicit() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Implicit();
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Explicit() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Explicit();
}