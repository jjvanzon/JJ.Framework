namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class TrimShimCreation_Tests
{
    private readonly TrimShimCreation_TestBase _testBase = new();

    [TestMethod]
    public void Test_DynamicallyAccessedMembers_New() => _testBase.Test_DynamicallyAccessedMembers();

    [TestMethod]
    public void Test_DynamicallyAccessedMemberTypes() => _testBase.Test_DynamicallyAccessedMemberTypes();

    [TestMethod]
    public void Test_RequiresUnreferencedCode_New() => _testBase.Test_RequiresUnreferencedCode();

    [TestMethod]
    public void Test_RequiresDynamicCode_New() => _testBase.Test_RequiresDynamicCode();

    [TestMethod]
    public void Test_DynamicDependency_New() => _testBase.Test_DynamicDependency();

    [TestMethod]
    public void Test_UnconditionalSuppressMessage_New() => _testBase.Test_UnconditionalSuppressMessage();
}
