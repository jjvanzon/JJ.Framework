namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests
{
    private Reflector[] _reflectors = new[]
    {
        new Reflector(),
        new Reflector(matchcase: false),
        new Reflector(BindingFlagsAll),
        new Reflector(BindingFlagsAll, matchcase: false),
    };
    
    private Reflector[] _reflectorsMatchCase = new[]
    {
        new Reflector(matchcase),
        new Reflector(matchcase: true),
        new Reflector(BindingFlagsAll, matchcase),
        new Reflector(BindingFlagsAll, matchcase: true),
    };

    [TestMethod]
    public void Reflector_Prop_Core_Test()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "MyProp"));
            Assert(reflector.Prop(typeof(MyClass), "MyProp"));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_IgnoresCase()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "myprop"));
            Assert(reflector.Prop(typeof(MyClass), "myprop"));
        }
    }

    // NotFound
    
    [TestMethod]
    public void Reflector_Prop_NotFound_Throws()
    {
        foreach (var reflector in _reflectors)
        {
            ThrowsException(() => reflector.Prop<MyClass>(        "NoProp"));
            ThrowsException(() => reflector.Prop(typeof(MyClass), "NoProp"));
            ThrowsException(() => reflector.Prop<MyClass>(        "NoProp", nothrow: false));
            ThrowsException(() => reflector.Prop(typeof(MyClass), "NoProp", nothrow: false));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_NotFound_ReturnsNull()
    {
        foreach (var reflector in _reflectors)
        {
            IsNull(reflector.Prop<MyClass>(        "NoProp",       nothrow      ));
            IsNull(reflector.Prop(typeof(MyClass), "NoProp",       nothrow      ));
            IsNull(reflector.Prop<MyClass>(        "NoProp",       nothrow: true));
            IsNull(reflector.Prop(typeof(MyClass), "NoProp",       nothrow: true));
            IsNull(reflector.Prop<MyClass>(        nothrow,       "NoProp"      ));
            IsNull(reflector.Prop(typeof(MyClass), nothrow,       "NoProp"      ));
            IsNull(reflector.Prop<MyClass>(        nothrow: true, "NoProp"      ));
            IsNull(reflector.Prop(typeof(MyClass), nothrow: true, "NoProp"      ));
        }
    }

    // MatchCase

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_Throws()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            ThrowsNotFound(() => reflector.Prop<MyClass>(        "myprop"));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), "myprop"));
            ThrowsNotFound(() => reflector.Prop<MyClass>(        "myprop", nothrow: false));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), "myprop", nothrow: false));
        }
    }

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_ReturnsNull()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            IsNull(reflector.Prop<MyClass>(        "myprop", nothrow      ));
            IsNull(reflector.Prop(typeof(MyClass), "myprop", nothrow      ));
            IsNull(reflector.Prop<MyClass>(        "myprop", nothrow: true));
            IsNull(reflector.Prop(typeof(MyClass), "myprop", nothrow: true));
            IsNull(reflector.Prop<MyClass>(        nothrow,       "myprop"));
            IsNull(reflector.Prop(typeof(MyClass), nothrow,       "myprop"));
            IsNull(reflector.Prop<MyClass>(        nothrow: true, "myprop"));
            IsNull(reflector.Prop(typeof(MyClass), nothrow: true, "myprop"));
        }
    }
    
    // Invariant under NoThrow

    [TestMethod]
    public void Reflector_Prop_Core_Test_Invariant_UnderNoThrow()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "MyProp"                      ));
            Assert(reflector.Prop(typeof(MyClass), "MyProp"                      ));
            Assert(reflector.Prop<MyClass>(        "MyProp",       nothrow       ));
            Assert(reflector.Prop(typeof(MyClass), "MyProp",       nothrow       ));
            Assert(reflector.Prop<MyClass>(        "MyProp",       nothrow: true ));
            Assert(reflector.Prop(typeof(MyClass), "MyProp",       nothrow: true ));
            Assert(reflector.Prop<MyClass>(        "MyProp",       nothrow: false));
            Assert(reflector.Prop(typeof(MyClass), "MyProp",       nothrow: false));
            Assert(reflector.Prop<MyClass>(        nothrow,        "MyProp"      ));
            Assert(reflector.Prop(typeof(MyClass), nothrow,        "MyProp"      ));
            Assert(reflector.Prop<MyClass>(        nothrow: true,  "MyProp"      ));
            Assert(reflector.Prop(typeof(MyClass), nothrow: true,  "MyProp"      ));
            Assert(reflector.Prop<MyClass>(        nothrow: false, "MyProp"      ));
            Assert(reflector.Prop(typeof(MyClass), nothrow: false, "MyProp"      ));
        }
    }
        
    [TestMethod]
    public void Reflector_Prop_IgnoresCase_Invariant_UnderNoThrow()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "myprop"                ));
            Assert(reflector.Prop(typeof(MyClass), "myprop"                ));
            Assert(reflector.Prop<MyClass>(        "myprop", nothrow       ));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nothrow       ));
            Assert(reflector.Prop<MyClass>(        "myprop", nothrow: true ));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nothrow: true ));
            Assert(reflector.Prop<MyClass>(        "myprop", nothrow: false));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nothrow: false));
        }
    }

    // TODO: Trim tolerance
    
    // Helpers

    private void Assert(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyProp", prop!.Name);
    }
    
    private void ThrowsNotFound(Func<object?> func)
    {
        ThrowsExceptionContaining(func, "not found");
    }
    
    private class MyClass
    {
        Reflector _reflector = new();

        // TODO Assert return value.
        public string MyProp => _reflector.Prop<MyClass>().Name;
        
    }
}