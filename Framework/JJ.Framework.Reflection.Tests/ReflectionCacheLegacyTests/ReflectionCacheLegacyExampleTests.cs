#pragma warning disable IDE0051 // Remove unused private member

namespace JJ.Framework.Reflection.Legacy.Tests.ReflectionCacheLegacyTests;

[TestClass]
public class ReflectionCacheLegacyExampleTests
{
    class MyClass
    {
        private int Private => 3;
    }

    [DynamicDependency(NonPublicProps, typeof(MyClass))]
    [TestMethod]
    public void ReflectionCache_Legacy_Example_Test()
    {
        var obj = new MyClass();
        var acc = new MyAccessor(obj);
        int num = acc.Private;
    }

    [Suppress("Trimmer", "IL2026", Justification = TypeLoaded)]
    class MyAccessor(MyClass myObject)
    {
        Accessor _accessor = new(myObject);

        public int Private 
            => _accessor.GetPropertyValue(() => Private);
    }
}

