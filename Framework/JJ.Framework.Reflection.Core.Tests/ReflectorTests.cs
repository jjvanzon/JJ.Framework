// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests
{
    private Type _myType = typeof(MyType);

    // Constructors

    Reflect[] _reflectors =
    [
        new (                                  ),
        new (matchcase: false                  ),
        new (matchcase: false, BindingFlagsAll ),
        new (BindingFlagsAll                   ),
        new (BindingFlagsAll,  matchcase: false)
    ];
    
    Reflect[] _reflectorsMatchCase =
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
        foreach (var reflect in _reflectors)
        {
            Assert(reflect.Prop("MyType", "MyProp"));
            Assert(reflect.Prop <MyType>( "MyProp"));
            Assert(reflect.Prop(_myType,  "MyProp"));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_IgnoresCase()
    {
        foreach (var reflect in _reflectors)
        {
            Assert(reflect.Prop("mytype", "myprop"));
            Assert(reflect.Prop(_myType,  "myprop"));
            Assert(reflect.Prop <MyType>( "myprop"));
        }
    }

    // NotFound
    
    [TestMethod]
    public void Reflector_Prop_NotFound_Throws()
    {
        foreach (var reflect in _reflectors)
        {
            ThrowsException(() => reflect.Prop("MyType", "NoProp"));
            ThrowsException(() => reflect.Prop <MyType>( "NoProp"));
            ThrowsException(() => reflect.Prop(_myType , "NoProp"));
            ThrowsException(() => reflect.Prop("MyType", "NoProp", nullable: false));
            ThrowsException(() => reflect.Prop <MyType>( "NoProp", nullable: false));
            ThrowsException(() => reflect.Prop(_myType , "NoProp", nullable: false));
        }
    }

    [TestMethod]
    public void Reflector_Prop_NotFound_ReturnsNull()
    {
        foreach (var reflect in _reflectors)
        {
            IsNull(reflect.Prop("MyType", "NoProp",       nullable      ));
            IsNull(reflect.Prop <MyType>( "NoProp",       nullable      ));
            IsNull(reflect.Prop(_myType , "NoProp",       nullable      ));
            IsNull(reflect.Prop("MyType", "NoProp",       nullable: true));
            IsNull(reflect.Prop <MyType>( "NoProp",       nullable: true));
            IsNull(reflect.Prop(_myType , "NoProp",       nullable: true));
            IsNull(reflect.Prop("MyType", nullable,       "NoProp"      ));
            IsNull(reflect.Prop <MyType>( nullable,       "NoProp"      ));
            IsNull(reflect.Prop(_myType , nullable,       "NoProp"      ));
            IsNull(reflect.Prop("MyType", nullable: true, "NoProp"      ));
            IsNull(reflect.Prop <MyType>( nullable: true, "NoProp"      ));
            IsNull(reflect.Prop(_myType , nullable: true, "NoProp"      ));
        }
    }

    // MatchCase

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_Throws()
    {
        foreach (var reflect in _reflectorsMatchCase)
        {
            ThrowsNotFound(() => reflect.Prop("MyType", "myprop"));
            ThrowsNotFound(() => reflect.Prop <MyType>( "myprop"));
            ThrowsNotFound(() => reflect.Prop(_myType , "myprop"));
            ThrowsNotFound(() => reflect.Prop("mytype", "MyProp", nullable: false));
            ThrowsNotFound(() => reflect.Prop <MyType>( "myprop", nullable: false));
            ThrowsNotFound(() => reflect.Prop(_myType , "myprop", nullable: false));
        }
    }

    // TODO: Add calls that take "MyType" as string.

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_ReturnsNull()
    {
        foreach (var reflect in _reflectorsMatchCase)
        {
            IsNull(reflect.Prop("MyType", "myprop",       nullable      ));
            IsNull(reflect.Prop <MyType>( "myprop",       nullable      ));
            IsNull(reflect.Prop(_myType , "myprop",       nullable      ));
            // TODO: Inconsistent handling of case sensitivity for the type name.
            //IsNull(reflect.Prop("myType", "MyProp",       nullable: true));
            IsNull(reflect.Prop <MyType>( "myprop",       nullable: true));
            IsNull(reflect.Prop(_myType , "myprop",       nullable: true));
            IsNull(reflect.Prop("MyType", nullable,       "myprop"      ));
            IsNull(reflect.Prop <MyType>( nullable,       "myprop"      ));
            IsNull(reflect.Prop(_myType , nullable,       "myprop"      ));
            IsNull(reflect.Prop("MyType", nullable: true, "myprop"      ));
            IsNull(reflect.Prop <MyType>( nullable: true, "myprop"      ));
            IsNull(reflect.Prop(_myType , nullable: true, "myprop"      ));
        }
    }
    
    // Invariant under Nullable

    [TestMethod]
    public void Reflector_Prop_MainCase_Invariant_UnderNullable()
    {
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            Assert(reflect.Prop("MyType", "MyProp"                        ));
            Assert(reflect.Prop <MyType>( "MyProp"                        ));
            Assert(reflect.Prop(_myType , "MyProp"                        ));
            Assert(reflect.Prop("MyType", "MyProp",        nullable       ));
            Assert(reflect.Prop <MyType>( "MyProp",        nullable       ));
            Assert(reflect.Prop(_myType , "MyProp",        nullable       ));
            Assert(reflect.Prop("MyType", "MyProp",        nullable: true ));
            Assert(reflect.Prop <MyType>( "MyProp",        nullable: true ));
            Assert(reflect.Prop(_myType , "MyProp",        nullable: true ));
            Assert(reflect.Prop("MyType", "MyProp",        nullable: false));
            Assert(reflect.Prop <MyType>( "MyProp",        nullable: false));
            Assert(reflect.Prop(_myType , "MyProp",        nullable: false));
            Assert(reflect.Prop("MyType", nullable,        "MyProp"       ));
            Assert(reflect.Prop <MyType>( nullable,        "MyProp"       ));
            Assert(reflect.Prop(_myType , nullable,        "MyProp"       ));
            Assert(reflect.Prop("MyType", nullable: true,  "MyProp"       ));
            Assert(reflect.Prop <MyType>( nullable: true,  "MyProp"       ));
            Assert(reflect.Prop(_myType , nullable: true,  "MyProp"       ));
            Assert(reflect.Prop("MyType", nullable: false, "MyProp"       ));
            Assert(reflect.Prop <MyType>( nullable: false, "MyProp"       ));
            Assert(reflect.Prop(_myType , nullable: false, "MyProp"       ));
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
        Reflect _reflector = new();

        // TODO Assert return value.
        public string MyProp => _reflector.Prop<MyType>().Name;
        
    }
}