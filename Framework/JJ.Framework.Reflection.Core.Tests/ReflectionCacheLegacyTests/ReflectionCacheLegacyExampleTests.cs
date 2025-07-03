namespace JJ.Framework.Reflection.Core.Tests.ReflectionCacheLegacyTests;

[TestClass]
public class ReflectionCacheLegacyExampleTests
{
    class MyClass
    {
        private int Private => 3;
    }

    [TestMethod]
    public void ReflectionCache_Legacy_Example_Test()
    {
        var obj = new MyClass();
        var acc = new MyAccessor(obj);
        int num = acc.Private;
    }

    class MyAccessor(MyClass myObject)
    {
        Accessor _accessor = new(myObject);

        public int Private 
            => _accessor.GetPropertyValue(() => Private);
    }
}

