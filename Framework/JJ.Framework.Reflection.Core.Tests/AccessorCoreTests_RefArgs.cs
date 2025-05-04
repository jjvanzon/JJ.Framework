// ReSharper disable InlineOutVariableDeclaration
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_RefArgs
{
    [TestMethod]
    public void AccessorCore_1RefArg()
    {
        var accessor = new MyAccessor();
        
        int arg;
        bool ret = accessor.MyMethod(out arg);
        
        AreEqual(1, () => arg);
        IsTrue(() => ret);
    }
    
    private class MyAccessor() : AccessorCore(new MyClass())
    {
        public bool MyMethod(out int arg)
        {
            arg = default;
            return (bool)Call(ref arg)!;
        }
    }
    
    private class MyClass
    {
        private bool MyMethod(out int arg)
        {
            arg = 1;
            return true;
        }
    }
}