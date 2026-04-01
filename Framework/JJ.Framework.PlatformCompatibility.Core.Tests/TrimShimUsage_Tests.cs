namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class TrimShimUsage_Tests
{
    [TestMethod]
    public void Test_DynamicallyAccessedMembers() 
        => new TrimShimUsage_TestBase()
            .Test_DynamicallyAccessedMembers();

    [TestMethod]
    public void Test_DynamicallyAccessedMemberTypes() 
        => new TrimShimUsage_TestBase()
            .Test_DynamicallyAccessedMemberTypes();

    [TestMethod]
    public void Test_RequiresUnreferencedCode()
        => new TrimShimUsage_TestBase()
            .Test_RequiresUnreferencedCode();

    [TestMethod]
    public void Test_RequiresDynamicCode() 
        => new TrimShimUsage_TestBase()
            .Test_RequiresDynamicCode();

    [TestMethod]
    public void Test_DynamicDependency() 
        => new TrimShimUsage_TestBase()
            .Test_DynamicDependency();

    [TestMethod]
    public void Test_UnconditionalSuppressMessage() 
        => new TrimShimUsage_TestBase()
            .Test_UnconditionalSuppressMessage();
}
