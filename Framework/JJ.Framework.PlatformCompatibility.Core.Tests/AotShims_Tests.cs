namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class AotShims_Tests
{
    private readonly AotShims_TestBase _testBase = new();

    [TestMethod]
    public void Test_DynamicallyAccessedMembers_PlatformStub() => _testBase.Test_DynamicallyAccessedMembers_PlatformStub();

    [TestMethod]
    public void Test_DynamicallyAccessedMemberTypes_PlatformStub() => _testBase.Test_DynamicallyAccessedMemberTypes_PlatformStub();

    [TestMethod]
    public void Test_RequiresUnreferencedCode_PlatformStub() => _testBase.Test_RequiresUnreferencedCode_PlatformStub();

    [TestMethod]
    public void Test_RequiresDynamicCode_PlatformStub() => _testBase.Test_RequiresDynamicCode_PlatformStub();

    [TestMethod]
    public void Test_DynamicDependency_PlatformStub() => _testBase.Test_DynamicDependency_PlatformStub();

    [TestMethod]
    public void Test_UnconditionalSuppressMessage_PlatformStub() => _testBase.Test_UnconditionalSuppressMessage_PlatformStub();
}
