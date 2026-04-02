namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class Lock_TestBase
{

    public void Test_Lock_EnterAndDispose()
    {
        var x = new Lock();
        var scope = x.EnterScope();
        scope.Dispose();
    }

    public void Test_Lock_UsingScope()
    {
        var x = new Lock();
        using var scope = x.EnterScope();
    }

    public void Test_Lock_NestedScopes()
    {
        var x = new Lock();
        using var scope1 = x.EnterScope();
        using var scope2 = x.EnterScope();
    }

    public void Test_Lock_LockStatement()
    {
        var x = new Lock();
        lock (x) { }
    }
}
