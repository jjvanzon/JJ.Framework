// ReSharper disable StringLiteralTypo

using static JJ.Framework.Reflection.Core.MatchCaseFlag;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests
{
    private Reflector[] _reflectors = new[]
    {
        new Reflector(),
        new Reflector(ignoreCase), // TODO: either support `ignoreCase: true` syntax or call it maybe 'none' to discourage use and express default.
        new Reflector(matchCase: false),
        new Reflector(BindingFlagsAll),
        new Reflector(BindingFlagsAll, ignoreCase),
        new Reflector(BindingFlagsAll, matchCase: false),
    };
    
    private Reflector[] _reflectorsMatchCase = new[]
    {
        new Reflector(matchCase),
        new Reflector(matchCase: true),
        new Reflector(BindingFlagsAll, matchCase),
        new Reflector(BindingFlagsAll, matchCase: true),
    };

    [TestMethod]
    public void Reflector_Prop()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>("MyProp"));
            Assert(reflector.Prop<MyClass>("MyProp", throws));
            Assert(reflector.Prop<MyClass>(throws, "MyProp"));
            Assert(reflector.Prop(typeof(MyClass), "MyProp"));
            Assert(reflector.Prop(typeof(MyClass), throws, "MyProp"));
            Assert(reflector.Prop(typeof(MyClass), "MyProp", throws));
        }
    }

    // NotFound
    
    [TestMethod]
    public void Reflector_Prop_NotFound_Throws()
    {
        foreach (var reflector in _reflectors)
        {
            ThrowsException(() => reflector.Prop<MyClass>("NoProp"));
            ThrowsException(() => reflector.Prop<MyClass>("NoProp", throws));
            ThrowsException(() => reflector.Prop<MyClass>(throws, "NoProp"));
            ThrowsException(() => reflector.Prop(typeof(MyClass), "NoProp"));
            ThrowsException(() => reflector.Prop(typeof(MyClass), throws, "NoProp"));
            ThrowsException(() => reflector.Prop(typeof(MyClass), "NoProp", throws));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_NotFound_ReturnsNull()
    {
        foreach (var reflector in _reflectors)
        {
            IsNull(reflector.Prop<MyClass>("NoProp", nothrow));
            IsNull(reflector.Prop<MyClass>(nothrow, "NoProp"));
            IsNull(reflector.Prop(typeof(MyClass), nothrow, "NoProp"));
            IsNull(reflector.Prop(typeof(MyClass), "NoProp", nothrow));
        }
    }
        
    [TestMethod]
    public void Reflector_Prop_CaseInsensitive_Succeeds()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>("myprop"));
            Assert(reflector.Prop<MyClass>("myprop", throws));
            Assert(reflector.Prop<MyClass>(throws, "myprop"));
            Assert(reflector.Prop(typeof(MyClass), "myprop"));
            Assert(reflector.Prop(typeof(MyClass), throws, "myprop"));
            Assert(reflector.Prop(typeof(MyClass), "myprop", throws));
        }
    }

    // MatchCase

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_Throws()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            ThrowsNotFound(() => reflector.Prop<MyClass>("myprop"));
            ThrowsNotFound(() => reflector.Prop<MyClass>("myprop", throws));
            ThrowsNotFound(() => reflector.Prop<MyClass>(throws, "myprop"));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), "myprop"));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), throws, "myprop"));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), "myprop", throws));
        }
    }

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_ReturnsNull()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            IsNull(reflector.Prop<MyClass>("myprop", nothrow));
            IsNull(reflector.Prop<MyClass>(nothrow, "myprop"));
            IsNull(reflector.Prop(typeof(MyClass), nothrow, "myprop"));
            IsNull(reflector.Prop(typeof(MyClass), "myprop", nothrow));
        }
    }
    
    // TODO: Trim tolerance
    
    // Helpers

    private void Assert(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyProp", prop!.Name);
    }
    
    private void ThrowsNotFound(Func<object?> func) => ThrowsExceptionContaining(func, "not found");

    private class MyClass
    {
        Reflector _reflector = new();

        // TODO Assert return value.
        public string MyProp => _reflector.Prop<MyClass>().Name;
        
    }
}