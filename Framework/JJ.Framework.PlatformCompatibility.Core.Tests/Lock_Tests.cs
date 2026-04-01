namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class Lock_Tests
{
    [TestMethod]
    public void Test_Lock_EnterAndDispose() 
        => new Lock_TestBase()
            .Test_Lock_EnterAndDispose();

    [TestMethod]
    public void Test_Lock_UsingScope() 
        => new Lock_TestBase()
            .Test_Lock_UsingScope();

    [TestMethod]
    public void Test_Lock_NestedScopes() 
        => new Lock_TestBase()
            .Test_Lock_NestedScopes();

    [TestMethod]
    public void Test_Lock_LockStatement() 
        => new Lock_TestBase()
            .Test_Lock_LockStatement();
}
