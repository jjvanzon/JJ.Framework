// ReSharper disable StringLiteralTypo
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests
{
    private static readonly Reflector _reflector = new();
    
    [TestMethod]
    public void ReflectionCacheCore_Prop()
    {
        AssertProp(_reflector.Prop<MyClass>("MyProp"));
        AssertProp(_reflector.Prop<MyClass>("MyProp", throws));
        AssertProp(_reflector.Prop<MyClass>(throws, "MyProp"));
        AssertProp(_reflector.Prop(typeof(MyClass), "MyProp"));
        AssertProp(_reflector.Prop(typeof(MyClass), throws, "MyProp"));
        AssertProp(_reflector.Prop(typeof(MyClass), "MyProp", throws));
    }
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_CaseInsensitive()
    {
        AssertProp(_reflector.Prop<MyClass>("myprop"));
        AssertProp(_reflector.Prop<MyClass>("myprop", throws));
        AssertProp(_reflector.Prop<MyClass>(throws, "myprop"));
        AssertProp(_reflector.Prop(typeof(MyClass), "myprop"));
        AssertProp(_reflector.Prop(typeof(MyClass), throws, "myprop"));
        AssertProp(_reflector.Prop(typeof(MyClass), "myprop", throws));
    }
    
    // TODO: Case sensitive option.
    
    private void AssertProp(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyProp", prop!.Name);
    }
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_Throws()
    {
        ThrowsException(() => _reflector.Prop<MyClass>("NoProp"));
        ThrowsException(() => _reflector.Prop<MyClass>("NoProp", throws));
        ThrowsException(() => _reflector.Prop<MyClass>(throws, "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), throws, "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "NoProp", throws));
    }
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_NoThrow()
    {
        IsNull(_reflector.Prop<MyClass>("NoProp", nothrow));
        IsNull(_reflector.Prop<MyClass>(nothrow, "NoProp"));
        IsNull(_reflector.Prop(typeof(MyClass), nothrow, "NoProp"));
        IsNull(_reflector.Prop(typeof(MyClass), "NoProp", nothrow));
    }
    
    private class MyClass
    {
        // TODO: Would like to omit the type argument.
        public string MyProp => _reflector.Prop<MyClass>().Name;
        
        // TODO: Syntax like `Prop(MyProp)`
    }
}