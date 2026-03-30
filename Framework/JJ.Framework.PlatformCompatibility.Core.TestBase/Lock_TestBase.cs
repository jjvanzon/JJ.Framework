namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class Lock_TestBase
{
    public void Test_Lock()
    {
        var x = new Lock();
        var scope = x.EnterScope();
        scope.Dispose();
    }
}
