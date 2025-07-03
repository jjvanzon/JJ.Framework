namespace JJ.Framework.Reflection.Core.Tests.ReflectionCacheLegacyTests;

[TestClass]
public class ReflectionCacheLegacyExampleTests
{
    // Example

    class MyClass
    {
        private int Private(int arg) => 3;
    }

    [TestMethod]
    public void ReflectionCache_Legacy_Example_Test()
    {
        var obj = new MyClass();
        var acc = new MyAccessor(obj);
        int num = acc.Private(1);
    }

    class MyAccessor(MyClass myObject)
    {
        Accessor _accessor = new(myObject);

        public int Private(int arg) 
            => _accessor.InvokeMethod(
                () => Private((arg)));
    }
}
