// ReSharper disable ClassNeverInstantiated.Local
#pragma warning disable CA2263 // Prefer type arg

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionCacheCoreTests
{
    private static readonly ReflectionCacheCore _reflectionCache = new();
    
    [TestMethod]
    public void ReflectionCacheCore_Prop()
    {
        IsNotNull(_reflectionCache.Prop<MyClass>("MyProp"));
        IsNotNull(_reflectionCache.Prop<MyClass>("MyProp", throws));
        IsNotNull(_reflectionCache.Prop<MyClass>(throws, "MyProp"));
        IsNotNull(_reflectionCache.Prop(typeof(MyClass), "MyProp"));
        IsNotNull(_reflectionCache.Prop(typeof(MyClass), throws, "MyProp"));
        IsNotNull(_reflectionCache.Prop(typeof(MyClass), "MyProp", throws));
    }
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_Throws()
    {
        ThrowsException(() => _reflectionCache.Prop<MyClass>("NoProp"));
        ThrowsException(() => _reflectionCache.Prop<MyClass>("NoProp", throws));
        ThrowsException(() => _reflectionCache.Prop<MyClass>(throws, "NoProp"));
        ThrowsException(() => _reflectionCache.Prop(typeof(MyClass), "NoProp"));
        ThrowsException(() => _reflectionCache.Prop(typeof(MyClass), throws, "NoProp"));
        ThrowsException(() => _reflectionCache.Prop(typeof(MyClass), "NoProp", throws));
    }
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_NoThrow()
    {
        IsNull(() => _reflectionCache.Prop<MyClass>("NoProp", nothrow));
        IsNull(() => _reflectionCache.Prop<MyClass>(nothrow, "NoProp"));
        IsNull(() => _reflectionCache.Prop(typeof(MyClass), nothrow, "NoProp"));
        IsNull(() => _reflectionCache.Prop(typeof(MyClass), "NoProp", nothrow));
    }
    
    private class MyClass
    {
        // TODO: Would like to omit the type argument.
        public string MyProp => _reflectionCache.Prop<MyClass>().Name;
    }
}