namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class Lock_Tests
{
    private readonly Lock_TestBase _testBase = new();

    [TestMethod]
    public void Test_Lock_EnterAndDispose() => _testBase.Test_Lock_EnterAndDispose();

    [TestMethod]
    public void Test_Lock_UsingScope() => _testBase.Test_Lock_UsingScope();

    [TestMethod]
    public void Test_Lock_NestedScopes() => _testBase.Test_Lock_NestedScopes();

    [TestMethod]
    public void Test_Lock_LockStatement() => _testBase.Test_Lock_LockStatement();
}
