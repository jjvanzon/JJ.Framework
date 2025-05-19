// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests
{
    private Type _myType = typeof(MyType);

    // Constructors

    Reflector[] _reflectors =
    [
        new (                                  ),
        new (matchcase: false                  ),
        new (matchcase: false, BindingFlagsAll ),
        new (BindingFlagsAll                   ),
        new (BindingFlagsAll,  matchcase: false)
    ];
    
    Reflector[] _reflectorsMatchCase =
    [
        new (matchcase                       ),
        new (matchcase: true                 ),
        new (matchcase,       BindingFlagsAll),
        new (matchcase: true, BindingFlagsAll),
        new (BindingFlagsAll, matchcase      ),
        new (BindingFlagsAll, matchcase: true)
    ];

    // Main Use

    [TestMethod]
    public void Reflector_Prop_MainCase()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop("MyType", "MyProp"));
            Assert(reflector.Prop <MyType>( "MyProp"));
            Assert(reflector.Prop(_myType,  "MyProp"));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_IgnoresCase()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop("mytype", "myprop"));
            Assert(reflector.Prop(_myType,  "myprop"));
            Assert(reflector.Prop <MyType>( "myprop"));
        }
    }

    // NotFound
    
    [TestMethod]
    public void Reflector_Prop_NotFound_Throws()
    {
        foreach (var reflector in _reflectors)
        {
            ThrowsException(() => reflector.Prop("MyType", "NoProp"));
            ThrowsException(() => reflector.Prop <MyType>( "NoProp"));
            ThrowsException(() => reflector.Prop(_myType , "NoProp"));
            ThrowsException(() => reflector.Prop("MyType", "NoProp", nullable: false));
            ThrowsException(() => reflector.Prop <MyType>( "NoProp", nullable: false));
            ThrowsException(() => reflector.Prop(_myType , "NoProp", nullable: false));
        }
    }

    [TestMethod]
    public void Reflector_Prop_NotFound_ReturnsNull()
    {
        foreach (var reflector in _reflectors)
        {
            IsNull(reflector.Prop("MyType", "NoProp",       nullable      ));
            IsNull(reflector.Prop <MyType>( "NoProp",       nullable      ));
            IsNull(reflector.Prop(_myType , "NoProp",       nullable      ));
            IsNull(reflector.Prop("MyType", "NoProp",       nullable: true));
            IsNull(reflector.Prop <MyType>( "NoProp",       nullable: true));
            IsNull(reflector.Prop(_myType , "NoProp",       nullable: true));
            IsNull(reflector.Prop("MyType", nullable,       "NoProp"      ));
            IsNull(reflector.Prop <MyType>( nullable,       "NoProp"      ));
            IsNull(reflector.Prop(_myType , nullable,       "NoProp"      ));
            IsNull(reflector.Prop("MyType", nullable: true, "NoProp"      ));
            IsNull(reflector.Prop <MyType>( nullable: true, "NoProp"      ));
            IsNull(reflector.Prop(_myType , nullable: true, "NoProp"      ));
        }
    }

    // MatchCase

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_Throws()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            ThrowsNotFound(() => reflector.Prop("MyType", "myprop"));
            ThrowsNotFound(() => reflector.Prop <MyType>( "myprop"));
            ThrowsNotFound(() => reflector.Prop(_myType , "myprop"));
            // TODO: Inconsistent handling of case sensitivity for the type name.
            //ThrowsNotFound(() => reflector.Prop("mytype", "MyProp", nullable: false));
            ThrowsNotFound(() => reflector.Prop <MyType>( "myprop", nullable: false));
            ThrowsNotFound(() => reflector.Prop(_myType , "myprop", nullable: false));
        }
    }

    // TODO: Add calls that take "MyType" as string.

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_ReturnsNull()
    {
        foreach (var reflector in _reflectorsMatchCase)
        {
            IsNull(reflector.Prop("MyType", "myprop",       nullable      ));
            IsNull(reflector.Prop <MyType>( "myprop",       nullable      ));
            IsNull(reflector.Prop(_myType , "myprop",       nullable      ));
            // TODO: Inconsistent handling of case sensitivity for the type name.
            //IsNull(reflector.Prop("myType", "MyProp",       nullable: true));
            IsNull(reflector.Prop <MyType>( "myprop",       nullable: true));
            IsNull(reflector.Prop(_myType , "myprop",       nullable: true));
            IsNull(reflector.Prop("MyType", nullable,       "myprop"      ));
            IsNull(reflector.Prop <MyType>( nullable,       "myprop"      ));
            IsNull(reflector.Prop(_myType , nullable,       "myprop"      ));
            IsNull(reflector.Prop("MyType", nullable: true, "myprop"      ));
            IsNull(reflector.Prop <MyType>( nullable: true, "myprop"      ));
            IsNull(reflector.Prop(_myType , nullable: true, "myprop"      ));
        }
    }
    
    // Invariant under Nullable

    [TestMethod]
    public void Reflector_Prop_MainCase_Invariant_UnderNullable()
    {
        foreach (var reflector in Union(_reflectors, _reflectorsMatchCase))
        {
            Assert(reflector.Prop("MyType", "MyProp"                        ));
            Assert(reflector.Prop <MyType>( "MyProp"                        ));
            Assert(reflector.Prop(_myType , "MyProp"                        ));
            Assert(reflector.Prop("MyType", "MyProp",        nullable       ));
            Assert(reflector.Prop <MyType>( "MyProp",        nullable       ));
            Assert(reflector.Prop(_myType , "MyProp",        nullable       ));
            Assert(reflector.Prop("MyType", "MyProp",        nullable: true ));
            Assert(reflector.Prop <MyType>( "MyProp",        nullable: true ));
            Assert(reflector.Prop(_myType , "MyProp",        nullable: true ));
            Assert(reflector.Prop("MyType", "MyProp",        nullable: false));
            Assert(reflector.Prop <MyType>( "MyProp",        nullable: false));
            Assert(reflector.Prop(_myType , "MyProp",        nullable: false));
            Assert(reflector.Prop("MyType", nullable,        "MyProp"       ));
            Assert(reflector.Prop <MyType>( nullable,        "MyProp"       ));
            Assert(reflector.Prop(_myType , nullable,        "MyProp"       ));
            Assert(reflector.Prop("MyType", nullable: true,  "MyProp"       ));
            Assert(reflector.Prop <MyType>( nullable: true,  "MyProp"       ));
            Assert(reflector.Prop(_myType , nullable: true,  "MyProp"       ));
            Assert(reflector.Prop("MyType", nullable: false, "MyProp"       ));
            Assert(reflector.Prop <MyType>( nullable: false, "MyProp"       ));
            Assert(reflector.Prop(_myType , nullable: false, "MyProp"       ));
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
    
    private class MyType
    {
        Reflector _reflector = new();

        // TODO Assert return value.
        public string MyProp => _reflector.Prop<MyType>().Name;
        
    }
}