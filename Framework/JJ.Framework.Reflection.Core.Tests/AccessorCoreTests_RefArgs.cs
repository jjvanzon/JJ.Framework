namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_RefArgs
{
    [TestMethod]
    public void AccessorCore_1RefArg()
    {
        var obj = new MyClass();
        var accessor = new MyAccessor(obj);
        
        int num = 14;
        bool isEven = accessor.MyMethod(ref num);
        
        IsTrue(() => isEven);
        AreEqual(15, () => num);
    }
    
    private class MyAccessor(MyClass obj) : AccessorCore(obj)
    {
        public bool MyMethod(ref int num) => (bool)Call(ref num);
    }
    
    private class MyClass
    {
        private bool MyMethod(ref int num)
        {
            bool isEven = num % 2 == 0;
            num++;
            return isEven;
        }
    }
}