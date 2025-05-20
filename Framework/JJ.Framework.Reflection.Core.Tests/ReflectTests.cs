namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectTests
{
    private Type _myType = typeof(MyType);
    private Type _myBase = typeof(MyBase);

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
            IsFalse(reflect.MatchCase);
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
            ThrowsNotFound(() => reflect.Prop("MyType", "NoProp"));
            ThrowsNotFound(() => reflect.Prop <MyType>( "NoProp"));
            ThrowsNotFound(() => reflect.Prop(_myType , "NoProp"));
            ThrowsNotFound(() => reflect.Prop("MyType", "NoProp", nullable: false));
            ThrowsNotFound(() => reflect.Prop <MyType>( "NoProp", nullable: false));
            ThrowsNotFound(() => reflect.Prop(_myType , "NoProp", nullable: false));
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
            IsTrue(reflect.MatchCase);
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
            IsTrue(reflect.MatchCase);
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
    
    // ToString
    
    [TestMethod]
    public void Reflector_Prop_ToString()
    {
        BindingFlags bindingFlagsMatchCase = ClearFlag(BindingFlagsAll, BindingFlags.IgnoreCase);
        
        foreach (var reflector in _reflectors)
        {
            AreEqual($"Reflector ({BindingFlagsAll})", $"{reflector}");
        }
        
        foreach (var reflector in _reflectorsMatchCase)
        {
            AreEqual($"Reflector ({bindingFlagsMatchCase})", $"{reflector}");
        }        
    }
    
    // Static

    [TestMethod]
    public void Reflect_Prop_Static()
    {
        // Qualified
        AssertProp(Reflect.Prop("MyType", "MyProp"));
        AssertProp(Reflect.Prop <MyType>( "MyProp"));
        AssertProp(Reflect.Prop(_myType,  "MyProp"));

        // Non-qualified
        AssertProp(Prop("MyType", "MyProp"));
        AssertProp(Prop <MyType>( "MyProp"));
        AssertProp(Prop(_myType,  "MyProp"));
        
        // NotFound
        ThrowsNotFound(() => Prop<MyType>("None"));
        IsNull(() => Prop<MyType>("None", nullable));

        // Base Types
        AssertBaseProp(Prop(_myType, "MyBaseProp"));
        AssertBaseProp(Prop(_myBase, "MyBaseProp"));
       
        // Ignore Case / Trims
        AssertProp(Prop(" mytype ", "myprop \r\n"));
        
        // Coverage
        AssertProp(Prop("MyType", "MyProp", nullable));
        AssertProp(Prop(_myType , "MyProp", nullable));
        AssertProp(Prop("MyType", "MyProp", nullable: true));
        AssertProp(Prop <MyType>( "MyProp", nullable: false));
        AssertProp(Prop(_myType , "MyProp", nullable: true));
        AssertProp(Prop("MyType", nullable, "MyProp"));
        AssertProp(Prop <MyType>( nullable, "MyProp"));
        AssertProp(Prop(_myType , nullable, "MyProp"));
        AssertProp(Prop("MyType", nullable: true, "MyProp"));
        AssertProp(Prop <MyType>( nullable: true, "MyProp"));
        AssertProp(Prop(_myType , nullable: true, "MyProp"));
    }
    
    // Extensions

    [TestMethod]
    public void Reflect_Prop_Extensions()
    {
        // Main case
        AssertProp(_myType.Prop("MyProp"));
        
        // NotFound
        ThrowsNotFound(() => _myType.Prop("None"));
        IsNull(() => _myType.Prop("None", nullable));

        // Base Types
        AssertBaseProp(_myType.Prop("MyBaseProp"));
        AssertBaseProp(_myBase.Prop("MyBaseProp"));
       
        // Ignore Case / Trims
        AssertProp(_myType.Prop("myprop \r\n"));
        
        // Coverage
        AssertProp(_myType.Prop("MyProp", nullable));
        AssertProp(_myType.Prop("MyProp", nullable: true));
        AssertProp(_myType.Prop(nullable, "MyProp"));
        AssertProp(_myType.Prop(nullable: true, "MyProp"));
    }
    
    // From Object 
    
    [TestMethod]
    public void Reflect_Prop_FromObject()
    {
        MyType obj = new();
        {
            AssertProp    (              Prop(obj, "MyProp"                  ));
            AssertProp    (              Prop(obj, "myprop", nullable: false ));
            AssertProp    (              Prop(obj, "myPROP", nullable: true  ));
            AssertProp    (              Prop(obj, "MYPROP", nullable        ));
            AssertProp    (              Prop(obj, nullable: false, "MyProp "));
            AssertProp    (              Prop(obj, nullable: true,  "myprop "));
            AssertProp    (              Prop(obj, nullable,        "MYPROP "));
            ThrowsNotFound(() =>         Prop(obj, "NoProp"                  ));
            ThrowsNotFound(() =>         Prop(obj, "NoProp", nullable: false ));
            IsNull        (              Prop(obj, "NoProp", nullable: true  ));
            IsNull        (              Prop(obj, "NoProp", nullable        ));
            ThrowsNotFound(() =>         Prop(obj, nullable: false, "NoProp" ));
            IsNull        (              Prop(obj, nullable: true,  "NoProp" ));
            IsNull        (              Prop(obj, nullable,        "NoProp" ));
            AssertBaseProp(              Prop(obj, "MyBASEProp "             ));
            AssertProp    (      obj    .Prop(     "MyProp"                  ));
            AssertProp    (      obj    .Prop(     "myprop", nullable: false ));
            AssertProp    (      obj    .Prop(     "myPROP", nullable: true  ));
            AssertProp    (      obj    .Prop(     "MYPROP", nullable        ));
            AssertProp    (      obj    .Prop(     nullable: false, "MyProp "));
            AssertProp    (      obj    .Prop(     nullable: true,  "myprop "));
            AssertProp    (      obj    .Prop(     nullable,        "MYPROP "));
            ThrowsNotFound(() => obj    .Prop(     "NoProp"                  ));
            ThrowsNotFound(() => obj    .Prop(     "NoProp", nullable: false ));
            IsNull        (      obj    .Prop(     "NoProp", nullable: true  ));
            IsNull        (      obj    .Prop(     "NoProp", nullable        ));
            ThrowsNotFound(() => obj    .Prop(     nullable: false, "NoProp" ));
            IsNull        (      obj    .Prop(     nullable: true,  "NoProp" ));
            IsNull        (      obj    .Prop(     nullable,        "NoProp" ));
            AssertBaseProp(      obj    .Prop(     "MyBASEProp "             ));
            AssertProp    (      Reflect.Prop(obj, "MyProp"                  ));
            AssertProp    (      Reflect.Prop(obj, "myprop", nullable: false ));
            AssertProp    (      Reflect.Prop(obj, "myPROP", nullable: true  ));
            AssertProp    (      Reflect.Prop(obj, "MYPROP", nullable        ));
            AssertProp    (      Reflect.Prop(obj, nullable: false, "MyProp "));
            AssertProp    (      Reflect.Prop(obj, nullable: true,  "myprop "));
            AssertProp    (      Reflect.Prop(obj, nullable,        "MYPROP "));
            ThrowsNotFound(() => Reflect.Prop(obj, "NoProp"                  ));
            ThrowsNotFound(() => Reflect.Prop(obj, "NoProp", nullable: false ));
            IsNull        (      Reflect.Prop(obj, "NoProp", nullable: true  ));
            IsNull        (      Reflect.Prop(obj, "NoProp", nullable        ));
            ThrowsNotFound(() => Reflect.Prop(obj, nullable: false, "NoProp" ));
            IsNull        (      Reflect.Prop(obj, nullable: true,  "NoProp" ));
            IsNull        (      Reflect.Prop(obj, nullable,        "NoProp" ));
            AssertBaseProp(      Reflect.Prop(obj, "MyBASEProp "             ));
        }
        
        foreach (Reflector reflect in _reflectors)
        {
            AssertProp    (      reflect.Prop(obj, "MyProp"                  ));
            AssertProp    (      reflect.Prop(obj, "myprop", nullable: false ));
            AssertProp    (      reflect.Prop(obj, "myPROP", nullable: true  ));
            AssertProp    (      reflect.Prop(obj, "MYPROP", nullable        ));
            AssertProp    (      reflect.Prop(obj, nullable: false, "MyProp "));
            AssertProp    (      reflect.Prop(obj, nullable: true,  "myprop "));
            AssertProp    (      reflect.Prop(obj, nullable,        "MYPROP "));
            ThrowsNotFound(() => reflect.Prop(obj, "NoProp"                  ));
            ThrowsNotFound(() => reflect.Prop(obj, "NoProp", nullable: false ));
            IsNull        (      reflect.Prop(obj, "NoProp", nullable: true  ));
            IsNull        (      reflect.Prop(obj, "NoProp", nullable        ));
            ThrowsNotFound(() => reflect.Prop(obj, nullable: false, "NoProp" ));
            IsNull        (      reflect.Prop(obj, nullable: true,  "NoProp" ));
            IsNull        (      reflect.Prop(obj, nullable,        "NoProp" ));
            AssertBaseProp(      reflect.Prop(obj, "MyBASEProp "             ));
        }
        
        foreach (Reflector reflect in _reflectorsMatchCase)
        {
            AssertProp    (      reflect.Prop(obj, "MyProp"                  ));
            ThrowsNotFound(() => reflect.Prop(obj, "myprop", nullable: false ));
            IsNull        (      reflect.Prop(obj, "myPROP", nullable: true  ));
            IsNull        (      reflect.Prop(obj, "MYPROP", nullable        ));
            AssertProp    (      reflect.Prop(obj, nullable: false, " MyProp"));
            IsNull        (      reflect.Prop(obj, nullable: true,  " myprop"));
            IsNull        (      reflect.Prop(obj, nullable,        " MYPROP"));
            AssertBaseProp(      reflect.Prop(obj, "MyBaseProp"              ));
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
        Reflector _reflect = new();
        
        public string MyProp
        {
            get => _reflect.Prop(GetType()).Name; // TODO: Assert value.
        }
    }
    
    private class MyBase
    {
        public int MyBaseProp => default;
    }
}