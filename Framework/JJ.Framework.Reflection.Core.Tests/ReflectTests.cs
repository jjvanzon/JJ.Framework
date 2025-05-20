namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectTests
{
    private Type _myType = typeof(MyType);
    private Type _myBase = typeof(MyBase);

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
            AssertProp(reflect.Prop("MyType", "MyProp"));
            AssertProp(reflect.Prop <MyType>( "MyProp"));
            AssertProp(reflect.Prop(_myType,  "MyProp"));
        }
    }
    
    [TestMethod]
    public void Reflector_Prop_IgnoresCase()
    {
        foreach (var reflect in _reflectors)
        {
            AssertProp(reflect.Prop("mytype", "myprop"));
            AssertProp(reflect.Prop(_myType,  "myprop"));
            AssertProp(reflect.Prop <MyType>( "myprop"));
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
    
    // Trim
    
    [TestMethod]
    public void Reflector_Prop_Trim()
    {
        foreach (var reflect in _reflectors)
        {
            AssertProp(reflect.Prop("\t\t MyType \n\r", " MyProp "));
            AssertProp(reflect.Prop <MyType>( "MyProp  "));
            AssertProp(reflect.Prop(_myType,  "\r\nMyProp \t   "));
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

    [TestMethod]
    public void Reflector_Prop_CaseSensitive_NoMatch_ReturnsNull()
    {
        foreach (var reflect in _reflectorsMatchCase)
        {
            IsNull(reflect.Prop("MyType", "myprop",       nullable      ));
            IsNull(reflect.Prop <MyType>( "myprop",       nullable      ));
            IsNull(reflect.Prop(_myType , "myprop",       nullable      ));
            IsNull(reflect.Prop("myType", "MyProp",       nullable: true));
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
    
    // Base Types
    [TestMethod]
    public void Reflector_Prop_BaseTypes()
    {
        foreach (var reflect in _reflectors)
        {
            AssertBaseProp(reflect.Prop("MyBase", "MyBaseProp"));
            AssertBaseProp(reflect.Prop <MyBase>( "MyBaseProp"));
            AssertBaseProp(reflect.Prop(_myBase , "MyBaseProp"));
            AssertBaseProp(reflect.Prop("MyType", "MyBaseProp"));
            AssertBaseProp(reflect.Prop <MyType>( "MyBaseProp"));
            AssertBaseProp(reflect.Prop(_myType , "MyBaseProp"));
            // Negative match
            ThrowsNotFound(() => reflect.Prop("MyBase", "MyProp"));
            ThrowsNotFound(() => reflect.Prop <MyBase>( "MyProp"));
            ThrowsNotFound(() => reflect.Prop(_myBase , "MyProp"));
            IsNull(reflect.Prop("MyBase", "MyProp", nullable));
            IsNull(reflect.Prop <MyBase>( "MyProp", nullable));
            IsNull(reflect.Prop(_myBase , "MyProp", nullable));
        }
    }
    
    // Invariant under Nullable

    [TestMethod]
    public void Reflector_Prop_Success_Invariant_UnderNullable()
    {
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            AssertProp(reflect.Prop("MyType", "MyProp"                        ));
            AssertProp(reflect.Prop <MyType>( "MyProp"                        ));
            AssertProp(reflect.Prop(_myType , "MyProp"                        ));
            AssertProp(reflect.Prop("MyType", "MyProp",        nullable       ));
            AssertProp(reflect.Prop <MyType>( "MyProp",        nullable       ));
            AssertProp(reflect.Prop(_myType , "MyProp",        nullable       ));
            AssertProp(reflect.Prop("MyType", "MyProp",        nullable: true ));
            AssertProp(reflect.Prop <MyType>( "MyProp",        nullable: true ));
            AssertProp(reflect.Prop(_myType , "MyProp",        nullable: true ));
            AssertProp(reflect.Prop("MyType", "MyProp",        nullable: false));
            AssertProp(reflect.Prop <MyType>( "MyProp",        nullable: false));
            AssertProp(reflect.Prop(_myType , "MyProp",        nullable: false));
            AssertProp(reflect.Prop("MyType", nullable,        "MyProp"       ));
            AssertProp(reflect.Prop <MyType>( nullable,        "MyProp"       ));
            AssertProp(reflect.Prop(_myType , nullable,        "MyProp"       ));
            AssertProp(reflect.Prop("MyType", nullable: true,  "MyProp"       ));
            AssertProp(reflect.Prop <MyType>( nullable: true,  "MyProp"       ));
            AssertProp(reflect.Prop(_myType , nullable: true,  "MyProp"       ));
            AssertProp(reflect.Prop("MyType", nullable: false, "MyProp"       ));
            AssertProp(reflect.Prop <MyType>( nullable: false, "MyProp"       ));
            AssertProp(reflect.Prop(_myType , nullable: false, "MyProp"       ));
        }
    }
    
    // Helpers

    private void AssertProp(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyProp", prop!.Name);
    }

    private void AssertBaseProp(PropertyInfo? prop)
    {
        IsNotNull(prop);
        AreEqual("MyBaseProp", prop!.Name);
    }
    
    private void ThrowsNotFound(Func<object?> func)
    {
        ThrowsExceptionContaining(func, "not found");
    }
    
    private class MyType : MyBase
    {
        Reflect _reflector = new();
        public string MyProp => _reflector.Prop<MyType>().Name; // TODO: Assert value.
    }
    
    private class MyBase
    {
        public int MyBaseProp => default;
    }
}