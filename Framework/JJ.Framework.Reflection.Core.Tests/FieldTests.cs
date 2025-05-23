namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class FieldTests : ReflectorTestBase
{
    // Main Use

    [TestMethod]
    public void Reflector_Field_MainCase()
    {
        foreach (var reflect in _reflectors)
        {
            AssertField(reflect.Field("MyType", "_myField"));
            AssertField(reflect.Field <MyType>( "_myField"));
            AssertField(reflect.Field(_myType,  "_myField"));
        }
    }
    
    [TestMethod]
    public void Reflector_Field_IgnoresCase()
    {
        foreach (var reflect in _reflectors)
        {
            IsFalse(reflect.MatchCase);
            AssertField(reflect.Field("mytype", "_myfield"));
            AssertField(reflect.Field(_myType,  "_myfield"));
            AssertField(reflect.Field <MyType>( "_myfield"));
        }
    }

    // NotFound
    
    [TestMethod]
    public void Reflector_Field_NotFound_Throws()
    {
        foreach (var reflect in _reflectors)
        {
            ThrowsNotFound(() => reflect.Field("MyType", "_noField"                 ));
            ThrowsNotFound(() => reflect.Field <MyType>( "_noField"                 ));
            ThrowsNotFound(() => reflect.Field(_myType , "_noField"                 ));
            ThrowsNotFound(() => reflect.Field("MyType", "_noField", nullable: false));
            ThrowsNotFound(() => reflect.Field <MyType>( "_noField", nullable: false));
            ThrowsNotFound(() => reflect.Field(_myType , "_noField", nullable: false));
        }
    }

    [TestMethod]
    public void Reflector_Field_NotFound_ReturnsNull()
    {
        foreach (var reflect in _reflectors)
        {
            IsNull(reflect.Field("MyType", "_noField",       null          ));
            IsNull(reflect.Field <MyType>( "_noField",       null          ));
            IsNull(reflect.Field(_myType , "_noField",       null          ));
            IsNull(reflect.Field("MyType", "_noField",       nullable      ));
            IsNull(reflect.Field <MyType>( "_noField",       nullable      ));
            IsNull(reflect.Field(_myType , "_noField",       nullable      ));
            IsNull(reflect.Field("MyType", "_noField",       nullable: true));
            IsNull(reflect.Field <MyType>( "_noField",       nullable: true));
            IsNull(reflect.Field(_myType , "_noField",       nullable: true));
            IsNull(reflect.Field("MyType", null,           "_noField"      ));
            IsNull(reflect.Field <MyType>( null,           "_noField"      ));
            IsNull(reflect.Field(_myType , null,           "_noField"      ));
            IsNull(reflect.Field("MyType", nullable,       "_noField"      ));
            IsNull(reflect.Field <MyType>( nullable,       "_noField"      ));
            IsNull(reflect.Field(_myType , nullable,       "_noField"      ));
            IsNull(reflect.Field("MyType", nullable: true, "_noField"      ));
            IsNull(reflect.Field <MyType>( nullable: true, "_noField"      ));
            IsNull(reflect.Field(_myType , nullable: true, "_noField"      ));
        }
    }
    
    // Trim
    
    [TestMethod]
    public void Reflector_Field_Trim()
    {
        foreach (var reflect in _reflectors)
        {
            AssertField(reflect.Field("\t\t MyType \n\r", " _myField "));
            AssertField(reflect.Field <MyType>( "_myField  "));
            AssertField(reflect.Field(_myType,  "\r\n_myField \t   "));
        }
    }

    // MatchCase

    [TestMethod]
    public void Reflector_Field_CaseSensitive_NoMatch_Throws()
    {
        foreach (var reflect in _reflectorsMatchCase)
        {
            IsTrue(reflect.MatchCase);
            ThrowsNotFound(() => reflect.Field("MyType", "_myfield"                 ));
            ThrowsNotFound(() => reflect.Field <MyType>( "_myfield"                 ));
            ThrowsNotFound(() => reflect.Field(_myType , "_myfield"                 ));
            ThrowsNotFound(() => reflect.Field("mytype", "_myField", nullable: false));
            ThrowsNotFound(() => reflect.Field <MyType>( "_myfield", nullable: false));
            ThrowsNotFound(() => reflect.Field(_myType , "_myfield", nullable: false));
        }
    }

    [TestMethod]
    public void Reflector_Field_CaseSensitive_NoMatch_ReturnsNull()
    {
        foreach (var reflect in _reflectorsMatchCase)
        {
            IsTrue(reflect.MatchCase);
            IsNull(reflect.Field("MyType", "_myfield",       null          ));
            IsNull(reflect.Field <MyType>( "_myfield",       null          ));
            IsNull(reflect.Field(_myType , "_myfield",       null          ));
            IsNull(reflect.Field("MyType", "_myfield",       nullable      ));
            IsNull(reflect.Field <MyType>( "_myfield",       nullable      ));
            IsNull(reflect.Field(_myType , "_myfield",       nullable      ));
            IsNull(reflect.Field("myType", "_myField",       nullable: true));
            IsNull(reflect.Field <MyType>( "_myfield",       nullable: true));
            IsNull(reflect.Field(_myType , "_myfield",       nullable: true));
            IsNull(reflect.Field("MyType", null,           "_myfield"      ));
            IsNull(reflect.Field <MyType>( null,           "_myfield"      ));
            IsNull(reflect.Field(_myType , null,           "_myfield"      ));
            IsNull(reflect.Field("MyType", nullable,       "_myfield"      ));
            IsNull(reflect.Field <MyType>( nullable,       "_myfield"      ));
            IsNull(reflect.Field(_myType , nullable,       "_myfield"      ));
            IsNull(reflect.Field("MyType", nullable: true, "_myfield"      ));
            IsNull(reflect.Field <MyType>( nullable: true, "_myfield"      ));
            IsNull(reflect.Field(_myType , nullable: true, "_myfield"      ));
        }
    }
    
    // Base Types
    
    [TestMethod]
    public void Reflector_Field_BaseTypes()
    {
        foreach (var reflect in _reflectors)
        {
            AssertBaseField(     reflect.Field("MyBase", "_myBaseField"      ));
            AssertBaseField(     reflect.Field <MyBase>( "_myBaseField"      ));
            AssertBaseField(     reflect.Field(_myBase , "_myBaseField"      ));
            AssertBaseField(     reflect.Field("MyType", "_myBaseField"      ));
            AssertBaseField(     reflect.Field <MyType>( "_myBaseField"      ));
            AssertBaseField(     reflect.Field(_myType , "_myBaseField"      ));
            // Negative match
            ThrowsNotFound(() => reflect.Field("MyBase", "_myField"          ));
            ThrowsNotFound(() => reflect.Field <MyBase>( "_myField"          ));
            ThrowsNotFound(() => reflect.Field(_myBase , "_myField"          ));
            IsNull(              reflect.Field("MyBase", "_myField", null    ));
            IsNull(              reflect.Field <MyBase>( "_myField", null    ));
            IsNull(              reflect.Field(_myBase , "_myField", null    ));
            IsNull(              reflect.Field("MyBase", "_myField", nullable));
            IsNull(              reflect.Field <MyBase>( "_myField", nullable));
            IsNull(              reflect.Field(_myBase , "_myField", nullable));
        }
    }
    
    // Static

    [TestMethod]
    public void Reflect_Field_Static()
    {
        // Qualified
        AssertField(Reflect.Field("MyType", "_myField"));
        AssertField(Reflect.Field <MyType>( "_myField"));
        AssertField(Reflect.Field(_myType,  "_myField"));

        // Non-qualified
        AssertField(Field("MyType", "_myField"));
        AssertField(Field <MyType>( "_myField"));
        AssertField(Field(_myType,  "_myField"));
        
        // NotFound
        ThrowsNotFound(() => Field<MyType>("None"));
        IsNull(() => Field<MyType>("None", nullable));

        // Base Types
        AssertBaseField(Field(_myType, "_myBaseField"));
        AssertBaseField(Field(_myBase, "_myBaseField"));
       
        // Ignore Case / Trims
        AssertField(Field(" mytype ", "_myfield \r\n"));
        
        // Coverage
        AssertField(Field("MyType", "_myField", null           ));
        AssertField(Field(_myType , "_myField", null           ));
        AssertField(Field("MyType", "_myField", nullable       ));
        AssertField(Field(_myType , "_myField", nullable       ));
        AssertField(Field("MyType", "_myField", nullable: true ));
        AssertField(Field <MyType>( "_myField", nullable: false));
        AssertField(Field(_myType , "_myField", nullable: true ));
        AssertField(Field("MyType", null,           "_myField" ));
        AssertField(Field <MyType>( null,           "_myField" ));
        AssertField(Field(_myType , null,           "_myField" ));
        AssertField(Field("MyType", nullable,       "_myField" ));
        AssertField(Field <MyType>( nullable,       "_myField" ));
        AssertField(Field(_myType , nullable,       "_myField" ));
        AssertField(Field("MyType", nullable: true, "_myField" ));
        AssertField(Field <MyType>( nullable: true, "_myField" ));
        AssertField(Field(_myType , nullable: true, "_myField" ));
    }
    
    // Extensions

    [TestMethod]
    public void Reflect_Field_Extensions()
    {
        // Main case
        AssertField(_myType .Field("_myField"));
        AssertField("myType".Field("_myField"));
        
        // NotFound
        ThrowsNotFound(() => _myType.Field("None"          ));
        IsNull        (() => _myType.Field("None", null    ));
        IsNull        (() => _myType.Field("None", nullable));

        // Base Types
        AssertBaseField(_myType.Field("_myBaseField"));
        AssertBaseField(_myBase.Field("_myBaseField"));
       
        // Ignore Case / Trims
        AssertField(_myType.Field("_myfield \r\n"));
        
        // Coverage
        AssertField(_myType .Field("_myField",       null          ));
        AssertField(_myType .Field("_myField",       nullable      ));
        AssertField(_myType .Field("_myField",       nullable: true));
        AssertField(_myType .Field(null,           "_myField"      ));
        AssertField(_myType .Field(nullable,       "_myField"      ));
        AssertField(_myType .Field(nullable: true, "_myField"      ));
        AssertField("myType".Field("_myField",       null          ));
        AssertField("myType".Field("_myField",       nullable      ));
        AssertField("myType".Field("_myField",       nullable: true));
        AssertField("myType".Field(null,           "_myField"      ));
        AssertField("myType".Field(nullable,       "_myField"      ));
        AssertField("myType".Field(nullable: true, "_myField"      ));
    }
    
    // From Object 
    
    [TestMethod]
    public void Reflect_Field_FromObject()
    {
        MyType obj = new();
        {
            AssertField    (              Field(obj, "_myField"                  ));
            AssertField    (              Field(obj, "_myfield", nullable: false ));
            AssertField    (              Field(obj, "_myField", nullable: true  ));
            AssertField    (              Field(obj, "_MYFIELD", nullable        ));
            AssertField    (              Field(obj, "_MYFIELD", null            ));
            AssertField    (              Field(obj, nullable: false, "_myField "));
            AssertField    (              Field(obj, nullable: true,  "_myfield "));
            AssertField    (              Field(obj, nullable,        "_MYFIELD "));
            AssertField    (              Field(obj, null,            "_MYFIELD "));
            ThrowsNotFound (() =>         Field(obj, "_noField"                  ));
            ThrowsNotFound (() =>         Field(obj, "_noField", nullable: false ));
            IsNull         (              Field(obj, "_noField", nullable: true  ));
            IsNull         (              Field(obj, "_noField", nullable        ));
            IsNull         (              Field(obj, "_noField", null            ));
            ThrowsNotFound (() =>         Field(obj, nullable: false, "_noField" ));
            IsNull         (              Field(obj, nullable: true,  "_noField" ));
            IsNull         (              Field(obj, nullable,        "_noField" ));
            IsNull         (              Field(obj, null,            "_noField" ));
            AssertBaseField(              Field(obj, "_myBaseField "             ));
            AssertField    (      obj    .Field(     "_myField"                  ));
            AssertField    (      obj    .Field(     "_myfield", nullable: false ));
            AssertField    (      obj    .Field(     "_myField", nullable: true  ));
            AssertField    (      obj    .Field(     "_MYFIELD", nullable        ));
            AssertField    (      obj    .Field(     "_MYFIELD", null            ));
            AssertField    (      obj    .Field(     nullable: false, "_myField "));
            AssertField    (      obj    .Field(     nullable: true,  "_myfield "));
            AssertField    (      obj    .Field(     nullable,        "_MYFIELD "));
            AssertField    (      obj    .Field(     null,            "_MYFIELD "));
            ThrowsNotFound (() => obj    .Field(     "_noField"                  ));
            ThrowsNotFound (() => obj    .Field(     "_noField", nullable: false ));
            IsNull         (      obj    .Field(     "_noField", nullable: true  ));
            IsNull         (      obj    .Field(     "_noField", nullable        ));
            IsNull         (      obj    .Field(     "_noField", null            ));
            ThrowsNotFound (() => obj    .Field(     nullable: false, "_noField" ));
            IsNull         (      obj    .Field(     nullable: true,  "_noField" ));
            IsNull         (      obj    .Field(     nullable,        "_noField" ));
            IsNull         (      obj    .Field(     null,            "_noField" ));
            AssertBaseField(      obj    .Field(     "_myBaseField "             ));
            AssertField    (      Reflect.Field(obj, "_myField"                  ));
            AssertField    (      Reflect.Field(obj, "_myfield", nullable: false ));
            AssertField    (      Reflect.Field(obj, "_myField", nullable: true  ));
            AssertField    (      Reflect.Field(obj, "_MYFIELD", nullable        ));
            AssertField    (      Reflect.Field(obj, "_MYFIELD", null            ));
            AssertField    (      Reflect.Field(obj, nullable: false, "_myField "));
            AssertField    (      Reflect.Field(obj, nullable: true,  "_myfield "));
            AssertField    (      Reflect.Field(obj, nullable,        "_MYFIELD "));
            AssertField    (      Reflect.Field(obj, null,            "_MYFIELD "));
            ThrowsNotFound (() => Reflect.Field(obj, "_noField"                  ));
            ThrowsNotFound (() => Reflect.Field(obj, "_noField", nullable: false ));
            IsNull         (      Reflect.Field(obj, "_noField", nullable: true  ));
            IsNull         (      Reflect.Field(obj, "_noField", nullable        ));
            IsNull         (      Reflect.Field(obj, "_noField", null            ));
            ThrowsNotFound (() => Reflect.Field(obj, nullable: false, "_noField" ));
            IsNull         (      Reflect.Field(obj, nullable: true,  "_noField" ));
            IsNull         (      Reflect.Field(obj, nullable,        "_noField" ));
            IsNull         (      Reflect.Field(obj, null,            "_noField" ));
            AssertBaseField(      Reflect.Field(obj, "_myBaseField "             ));
        }
        
        foreach (Reflector reflect in _reflectors)
        {
            AssertField    (      reflect.Field(obj, "_myField"                  ));
            AssertField    (      reflect.Field(obj, "_myfield", nullable: false ));
            AssertField    (      reflect.Field(obj, "_myField", nullable: true  ));
            AssertField    (      reflect.Field(obj, "_MYFIELD", nullable        ));
            AssertField    (      reflect.Field(obj, "_MYFIELD", null            ));
            AssertField    (      reflect.Field(obj, nullable: false, "_myField "));
            AssertField    (      reflect.Field(obj, nullable: true,  "_myfield "));
            AssertField    (      reflect.Field(obj, nullable,        "_MYFIELD "));
            AssertField    (      reflect.Field(obj, null,            "_MYFIELD "));
            ThrowsNotFound (() => reflect.Field(obj, "_noField"                  ));
            ThrowsNotFound (() => reflect.Field(obj, "_noField", nullable: false ));
            IsNull         (      reflect.Field(obj, "_noField", nullable: true  ));
            IsNull         (      reflect.Field(obj, "_noField", nullable        ));
            IsNull         (      reflect.Field(obj, "_noField", null            ));
            ThrowsNotFound (() => reflect.Field(obj, nullable: false, "_noField" ));
            IsNull         (      reflect.Field(obj, nullable: true,  "_noField" ));
            IsNull         (      reflect.Field(obj, nullable,        "_noField" ));
            IsNull         (      reflect.Field(obj, null,            "_noField" ));
            AssertBaseField(      reflect.Field(obj, "_myBaseField "             ));
        }
        
        foreach (Reflector reflect in _reflectorsMatchCase)
        {
            AssertField    (      reflect.Field(obj, "_myField"                  ));
            ThrowsNotFound (() => reflect.Field(obj, "_myfield", nullable: false ));
            IsNull         (      reflect.Field(obj, "_myFIELD", nullable: true  ));
            IsNull         (      reflect.Field(obj, "_MYFIELD", nullable        ));
            IsNull         (      reflect.Field(obj, "_MYFIELD", null            ));
            AssertField    (      reflect.Field(obj, nullable: false, " _myField"));
            IsNull         (      reflect.Field(obj, nullable: true,  " _myfield"));
            IsNull         (      reflect.Field(obj, nullable,        " _MYFIELD"));
            IsNull         (      reflect.Field(obj, null,            " _MYFIELD"));
            AssertBaseField(      reflect.Field(obj, "_myBaseField"              ));
        }
    }
    
    // Invariant under Nullable

    [TestMethod]
    public void Reflector_Field_Success_Invariant_UnderNullable()
    {
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            AssertField(reflect.Field("MyType", "_myField"                        ));
            AssertField(reflect.Field <MyType>( "_myField"                        ));
            AssertField(reflect.Field(_myType , "_myField"                        ));
            AssertField(reflect.Field("MyType", "_myField",        null           ));
            AssertField(reflect.Field <MyType>( "_myField",        null           ));
            AssertField(reflect.Field(_myType , "_myField",        null           ));
            AssertField(reflect.Field("MyType", "_myField",        nullable       ));
            AssertField(reflect.Field <MyType>( "_myField",        nullable       ));
            AssertField(reflect.Field(_myType , "_myField",        nullable       ));
            AssertField(reflect.Field("MyType", "_myField",        nullable: true ));
            AssertField(reflect.Field <MyType>( "_myField",        nullable: true ));
            AssertField(reflect.Field(_myType , "_myField",        nullable: true ));
            AssertField(reflect.Field("MyType", "_myField",        nullable: false));
            AssertField(reflect.Field <MyType>( "_myField",        nullable: false));
            AssertField(reflect.Field(_myType , "_myField",        nullable: false));
            AssertField(reflect.Field("MyType", null,            "_myField"       ));
            AssertField(reflect.Field <MyType>( null,            "_myField"       ));
            AssertField(reflect.Field(_myType , null,            "_myField"       ));
            AssertField(reflect.Field("MyType", nullable,        "_myField"       ));
            AssertField(reflect.Field <MyType>( nullable,        "_myField"       ));
            AssertField(reflect.Field(_myType , nullable,        "_myField"       ));
            AssertField(reflect.Field("MyType", nullable: true,  "_myField"       ));
            AssertField(reflect.Field <MyType>( nullable: true,  "_myField"       ));
            AssertField(reflect.Field(_myType , nullable: true,  "_myField"       ));
            AssertField(reflect.Field("MyType", nullable: false, "_myField"       ));
            AssertField(reflect.Field <MyType>( nullable: false, "_myField"       ));
            AssertField(reflect.Field(_myType , nullable: false, "_myField"       ));
        }
    }

    // Helpers

    private void AssertField(FieldInfo? field)
    {
        IsNotNull(field);
        AreEqual("_myField", field.Name);
    }

    private void AssertBaseField(FieldInfo? field)
    {
        IsNotNull(field);
        AreEqual("_myBaseField", field.Name);
    }
}