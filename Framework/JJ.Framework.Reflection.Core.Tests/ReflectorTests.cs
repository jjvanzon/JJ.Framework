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
            ThrowsException(() => reflector.Prop<MyClass>(        "NoProp", nullable: false));
            ThrowsException(() => reflector.Prop(typeof(MyClass), "NoProp", nullable: false));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_NotFound_Nullable()
    {
        foreach (var reflector in _reflectors)
        {
            IsNull(reflector.Prop<MyClass>(        "NoProp",       nullable      ));
            IsNull(reflector.Prop(typeof(MyClass), "NoProp",       nullable      ));
            IsNull(reflector.Prop<MyClass>(        "NoProp",       nullable: true));
            IsNull(reflector.Prop(typeof(MyClass), "NoProp",       nullable: true));
            IsNull(reflector.Prop<MyClass>(        nullable,       "NoProp"      ));
            IsNull(reflector.Prop(typeof(MyClass), nullable,       "NoProp"      ));
            IsNull(reflector.Prop<MyClass>(        nullable: true, "NoProp"      ));
            IsNull(reflector.Prop(typeof(MyClass), nullable: true, "NoProp"      ));
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
            ThrowsNotFound(() => reflector.Prop<MyClass>(        "myprop", nullable: false));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), "myprop", nullable: false));
        }
    }

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_Nullable()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            IsNull(reflector.Prop<MyClass>(        "myprop", nullable      ));
            IsNull(reflector.Prop(typeof(MyClass), "myprop", nullable      ));
            IsNull(reflector.Prop<MyClass>(        "myprop", nullable: true));
            IsNull(reflector.Prop(typeof(MyClass), "myprop", nullable: true));
            IsNull(reflector.Prop<MyClass>(        nullable,       "myprop"));
            IsNull(reflector.Prop(typeof(MyClass), nullable,       "myprop"));
            IsNull(reflector.Prop<MyClass>(        nullable: true, "myprop"));
            IsNull(reflector.Prop(typeof(MyClass), nullable: true, "myprop"));
        }
    }
    
    // Invariant under Nullable

    [TestMethod]
    public void Reflector_Prop_Core_Test_Invariant_UnderNullable()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "MyProp"                       ));
            Assert(reflector.Prop(typeof(MyClass), "MyProp"                       ));
            Assert(reflector.Prop<MyClass>(        "MyProp",       nullable       ));
            Assert(reflector.Prop(typeof(MyClass), "MyProp",       nullable       ));
            Assert(reflector.Prop<MyClass>(        "MyProp",       nullable: true ));
            Assert(reflector.Prop(typeof(MyClass), "MyProp",       nullable: true ));
            Assert(reflector.Prop<MyClass>(        "MyProp",       nullable: false));
            Assert(reflector.Prop(typeof(MyClass), "MyProp",       nullable: false));
            Assert(reflector.Prop<MyClass>(        nullable,        "MyProp"      ));
            Assert(reflector.Prop(typeof(MyClass), nullable,        "MyProp"      ));
            Assert(reflector.Prop<MyClass>(        nullable: true,  "MyProp"      ));
            Assert(reflector.Prop(typeof(MyClass), nullable: true,  "MyProp"      ));
            Assert(reflector.Prop<MyClass>(        nullable: false, "MyProp"      ));
            Assert(reflector.Prop(typeof(MyClass), nullable: false, "MyProp"      ));
        }
    }
        
    [TestMethod]
    public void Reflector_Prop_IgnoresCase_Invariant_UnderNullable()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "myprop"                 ));
            Assert(reflector.Prop(typeof(MyClass), "myprop"                 ));
            Assert(reflector.Prop<MyClass>(        "myprop", nullable       ));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nullable       ));
            Assert(reflector.Prop<MyClass>(        "myprop", nullable: true ));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nullable: true ));
            Assert(reflector.Prop<MyClass>(        "myprop", nullable: false));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nullable: false));
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