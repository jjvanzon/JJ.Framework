namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class TrimShimInstantiation_Tests
{
    private readonly TrimShimInstantiation_TestBase _testBase = new();

    [TestMethod]
    public void Test_DynamicallyAccessedMembers() => _testBase.Test_DynamicallyAccessedMembers();

    [TestMethod]
    public void Test_DynamicallyAccessedMemberTypes() => _testBase.Test_DynamicallyAccessedMemberTypes();

    [TestMethod]
    public void Test_RequiresUnreferencedCode() => _testBase.Test_RequiresUnreferencedCode();

    [TestMethod]
    public void Test_RequiresDynamicCode() => _testBase.Test_RequiresDynamicCode();

    [TestMethod]
    public void Test_DynamicDependency() => _testBase.Test_DynamicDependency();

    [TestMethod]
    public void Test_UnconditionalSuppressMessage() => _testBase.Test_UnconditionalSuppressMessage();
}
