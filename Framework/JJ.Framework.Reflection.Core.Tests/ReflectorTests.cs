// ReSharper disable StringLiteralTypo
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests
{
    private static readonly Reflector _reflector = new();
    
    [TestMethod]
    public void Reflector_Prop()
    {
        Assert(_reflector.Prop<MyClass>("MyProp"));
        Assert(_reflector.Prop<MyClass>("MyProp", throws));
        Assert(_reflector.Prop<MyClass>(throws, "MyProp"));
        Assert(_reflector.Prop(typeof(MyClass), "MyProp"));
        Assert(_reflector.Prop(typeof(MyClass), throws, "MyProp"));
        Assert(_reflector.Prop(typeof(MyClass), "MyProp", throws));
    }

    // NotFound
    
    [TestMethod]
    public void Reflector_Prop_NotFound_Throws()
    {
        ThrowsException(() => _reflector.Prop<MyClass>("NoProp"));
        ThrowsException(() => _reflector.Prop<MyClass>("NoProp", throws));
        ThrowsException(() => _reflector.Prop<MyClass>(throws, "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), throws, "NoProp"));
        ThrowsException(() => _reflector.Prop(typeof(MyClass), "NoProp", throws));
    }
    
    [TestMethod]
    public void Reflector_Prop_NotFound_NoThrow()
    {
        IsNull(_reflector.Prop<MyClass>("NoProp", nothrow));
        IsNull(_reflector.Prop<MyClass>(nothrow, "NoProp"));
        IsNull(_reflector.Prop(typeof(MyClass), nothrow, "NoProp"));
        IsNull(_reflector.Prop(typeof(MyClass), "NoProp", nothrow));
    }

    // MatchCase
        
    [TestMethod]
    public void Reflector_Prop_CaseInsensitive_Succeeds()
    {
        Assert(_reflector.Prop<MyClass>("myprop"));
        Assert(_reflector.Prop<MyClass>("myprop", throws));
        Assert(_reflector.Prop<MyClass>(throws, "myprop"));
        Assert(_reflector.Prop(typeof(MyClass), "myprop"));
        Assert(_reflector.Prop(typeof(MyClass), throws, "myprop"));
        Assert(_reflector.Prop(typeof(MyClass), "myprop", throws));
    }

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_Throws()
    {
        ThrowsNotFound(() => _reflector.Prop<MyClass>("myprop", matchcase));
        ThrowsNotFound(() => _reflector.Prop<MyClass>("myprop", matchcase | throws));
        ThrowsNotFound(() => _reflector.Prop<MyClass>(matchcase | throws, "myprop"));
        ThrowsNotFound(() => _reflector.Prop(typeof(MyClass), "myprop", matchcase));
        ThrowsNotFound(() => _reflector.Prop(typeof(MyClass), matchcase | throws, "myprop"));
        ThrowsNotFound(() => _reflector.Prop(typeof(MyClass), "myprop", matchcase | throws));
    }

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatchNoThrow()
    {
        IsNull(_reflector.Prop<MyClass>("myprop", matchcase | nothrow));
        IsNull(_reflector.Prop<MyClass>(matchcase | nothrow, "myprop"));
        IsNull(_reflector.Prop(typeof(MyClass), matchcase | nothrow, "myprop"));
        IsNull(_reflector.Prop(typeof(MyClass), "myprop", matchcase | nothrow));
    }
    
    // TODO: Trim tolerance
            
    private void Assert(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyProp", prop!.Name);
    }
    
    private void ThrowsNotFound(Func<object?> func) => ThrowsExceptionContaining(func, "not found");

    private class MyClass
    {
        public string MyProp => _reflector.Prop<MyClass>().Name;
        
    }
}