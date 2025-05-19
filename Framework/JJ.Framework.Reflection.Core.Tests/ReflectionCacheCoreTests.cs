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
        
    private void AssertProp(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyProp", prop!.Name);
    }

    // NotFound
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_NotFound_Throws()
    {
        ThrowsException(() => _reflector.Prop<MyClass>("NoProp"));
        ThrowsException(() => _reflector.Prop<MyClass>("NoProp", throws));
        ThrowsException(() => _reflector.Prop<MyClass>(throws, "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), throws, "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "NoProp", throws));
    }
    
    [TestMethod]
    public void ReflectionCacheCore_Prop_NotFound_NoThrow()
    {
        IsNull(_reflector.Prop<MyClass>("NoProp", nothrow));
        IsNull(_reflector.Prop<MyClass>(nothrow, "NoProp"));
        IsNull(_reflector.Prop(typeof(MyClass), nothrow, "NoProp"));
        IsNull(_reflector.Prop(typeof(MyClass), "NoProp", nothrow));
    }

    // MatchCase
        
    [TestMethod]
    public void ReflectionCacheCore_Prop_CaseInsensitive_Succeeds()
    {
        AssertProp(_reflector.Prop<MyClass>("myprop"));
        AssertProp(_reflector.Prop<MyClass>("myprop", throws));
        AssertProp(_reflector.Prop<MyClass>(throws, "myprop"));
        AssertProp(_reflector.Prop(typeof(MyClass), "myprop"));
        AssertProp(_reflector.Prop(typeof(MyClass), throws, "myprop"));
        AssertProp(_reflector.Prop(typeof(MyClass), "myprop", throws));
    }

    [TestMethod]
    public void ReflectionCacheCore_Prop_CaseSensitive_NoMatch_Throws()
    {
        ThrowsException(() => _reflector.Prop<MyClass>("myprop", matchcase));
        ThrowsException(() => _reflector.Prop<MyClass>("myprop", matchcase | throws));
        ThrowsException(() => _reflector.Prop<MyClass>(matchcase | throws, "myprop"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "myprop", matchcase));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), matchcase | throws, "myprop"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "myprop", matchcase | throws));
    }

    [TestMethod]
    public void ReflectionCacheCore_Prop_CaseSensitive_NoMatchNoThrow()
    {
        IsNull(_reflector.Prop<MyClass>("myprop", matchcase | nothrow));
        IsNull(_reflector.Prop<MyClass>(matchcase | nothrow, "myprop"));
        IsNull(_reflector.Prop(typeof(MyClass), matchcase | nothrow, "myprop"));
        IsNull(_reflector.Prop(typeof(MyClass), "myprop", matchcase | nothrow));
    }
    
    // TODO: Trim tolerance
    
    private class MyClass
    {
        public string MyProp => _reflector.Prop<MyClass>().Name;
        
    }
}