
namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class CallerArgumentExpression_Shim_Tests
{
    private readonly CallerArgumentExpression_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformStub() => _testBase.Test_CallerArgumentExpression_PlatformStub();
}

[TestClass]
public class ExceptionSupport_Shim_Tests
{
    private readonly ExceptionSupport_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_ExceptionSupport_PlatformStub() => _testBase.Test_ExceptionSupport_PlatformStub();
}

[TestClass]
public class HashCode_Shim_Tests
{
    private readonly HashCode_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_HashCode_PlatformStub() => _testBase.Test_HashCode_PlatformStub();
}

[TestClass]
public class NotNullWhen_Shim_Tests
{
    private readonly NotNullWhen_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_NotNullWhen_PlatformStub() => _testBase.Test_NotNullWhen_PlatformStub();
}

[TestClass]
public class OverloadResolutionPriority_Shim_Tests
{
    private readonly OverloadResolutionPriority_Shim_Tests_Base _testBase = new();

    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Create() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Create();

    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Implicit() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Implicit();
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Explicit() => _testBase.Test_PlatformStub_OverloadResolutionPriority_Explicit();
}