namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class TrimShimCreation_Tests
{
    [TestMethod]
    public void Test_DynamicallyAccessedMembers_New() 
        => new TrimShimCreation_TestBase()
            .Test_DynamicallyAccessedMembers();

    [TestMethod]
    public void Test_RequiresUnreferencedCode_New()
        => new TrimShimCreation_TestBase()
            .Test_RequiresUnreferencedCode();

    [TestMethod]
    public void Test_RequiresDynamicCode_New() 
        => new TrimShimCreation_TestBase()
            .Test_RequiresDynamicCode();

    [TestMethod]
    public void Test_DynamicDependency_New() 
        => new TrimShimCreation_TestBase()
            .Test_DynamicDependency();

    [TestMethod]
    public void Test_UnconditionalSuppressMessage_New()
        => new TrimShimCreation_TestBase()
            .Test_UnconditionalSuppressMessage();
}
