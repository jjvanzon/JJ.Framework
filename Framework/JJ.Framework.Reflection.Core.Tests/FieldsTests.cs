namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class FieldsTests : ReflectorTestBase
{
    [TestMethod]
    public void Reflector_Fields()
    {
        // Main use + trims + ignores case 
        {
            AssertFields     (      _myObject.Fields  (         ));
            AssertFieldDic   (      _myObject.FieldDic(         ));
            AssertFields     (      _myType  .Fields  (         ));
            AssertFieldDic   (      _myType  .FieldDic(         ));
            AssertFields     (      "MyType ".Fields  (         ));
            AssertFieldDic   (      " mytype".FieldDic(         ));
            AssertFields     (                Fields  (_myObject));
            AssertFieldDic   (                FieldDic(_myObject));
            AssertFields     (                Fields  (_myType  ));
            AssertFieldDic   (                FieldDic(_myType  ));
            AssertFields     (                Fields   <MyType>());
            AssertFieldDic   (                FieldDic <MyType>());
            AssertFields     (                Fields  ("MYTYPE" ));
            AssertFieldDic   (                FieldDic("MyType" ));
            AssertFields     (      Reflect  .Fields  (_myObject));
            AssertFieldDic   (      Reflect  .FieldDic(_myObject));
            AssertFields     (      Reflect  .Fields  (_myType  ));
            AssertFieldDic   (      Reflect  .FieldDic(_myType  ));
            AssertFields     (      Reflect  .Fields   <MyType>());
            AssertFieldDic   (      Reflect  .FieldDic <MyType>());
            AssertFields     (      Reflect  .Fields  (" MyType"));
            AssertFieldDic   (      Reflect  .FieldDic(" mytype"));
        }
        // Not found scenarios
        {
            ThrowsNotFound  (() => "NoType"  .Fields  (         ));
            ThrowsNotFound  (() => "NoType"  .FieldDic(         ));
            ThrowsNotFound  (() =>            Fields  ("NoType" ));
            ThrowsNotFound  (() =>            FieldDic("NoType" ));
            ThrowsNotFound  (() => Reflect   .Fields  ("NoType" ));
            ThrowsNotFound  (() => Reflect   .FieldDic("NoType" ));
        }
        // Instantiated (allows custom options)
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            AssertFields     (      reflect  .Fields  (_myObject));
            AssertFieldDic   (      reflect  .FieldDic(_myObject));
            AssertFields     (      reflect  .Fields  (_myType  ));
            AssertFieldDic   (      reflect  .FieldDic(_myType  ));
            AssertFields     (      reflect  .Fields   <MyType>());
            AssertFieldDic   (      reflect  .FieldDic <MyType>());
            AssertFields     (      reflect  .Fields  ("MyType" ));
            AssertFieldDic   (      reflect  .FieldDic(" MyType"));
            ThrowsNotFound   (() => reflect  .Fields  ("NoType" ));
            ThrowsNotFound   (() => reflect  .FieldDic("NoType" ));
        }
        // Match case (optional)
        foreach (var reflect in _reflectorsMatchCase)
        {
            AssertFields     (      reflect  .Fields  ("MyType" ));
            AssertFieldDic   (      reflect  .FieldDic("MyType "));
            ThrowsNotFound   (() => reflect  .Fields  ("MYTYPE" ));
            ThrowsNotFound   (() => reflect  .FieldDic("mytype" ));
        }
        // Base Types
        {
            AssertBaseFields        (_myBase .Fields  (         ));
            AssertBaseFieldDic      (_myBase .FieldDic(         ));
            AssertBaseFields        ("myBase".Fields  (         ));
            AssertBaseFieldDic      ("myBase".FieldDic(         ));
            AssertBaseFields        (         Fields  (_myBase  ));
            AssertBaseFieldDic      (         FieldDic(_myBase  ));
            AssertBaseFields        (         Fields   <MyBase>());
            AssertBaseFieldDic      (         FieldDic <MyBase>());
            AssertBaseFields        (         Fields  ("MyBase" ));
            AssertBaseFieldDic      (         FieldDic("mybase" ));
            AssertBaseFields        (Reflect .Fields  (_myBase  ));
            AssertBaseFieldDic      (Reflect .FieldDic(_myBase  ));
            AssertBaseFields        (Reflect .Fields   <MyBase>());
            AssertBaseFieldDic      (Reflect .FieldDic <MyBase>());
            AssertBaseFields        (Reflect .Fields  ("MYBASE" ));
            AssertBaseFieldDic      (Reflect .FieldDic("MyBase" ));
        }
        foreach (var reflect in _baselessReflectors)
        {
            AssertBaselessFields    (reflect .Fields  (_myObject));
            AssertBaselessFieldDic  (reflect .FieldDic(_myObject));
            AssertBaselessFields    (reflect .Fields  (_myType  ));
            AssertBaselessFieldDic  (reflect .FieldDic(_myType  ));
            AssertBaselessFields    (reflect .Fields   <MyType>());
            AssertBaselessFieldDic  (reflect .FieldDic <MyType>());
            AssertBaselessFields    (reflect .Fields  ("MyType" ));
            AssertBaselessFieldDic  (reflect .FieldDic("myType "));
            AssertBaseFields        (reflect .Fields  (_myBase  ));
            AssertBaseFieldDic      (reflect .FieldDic(_myBase  ));
            AssertBaseFields        (reflect .Fields   <MyBase>());
            AssertBaseFieldDic      (reflect .FieldDic <MyBase>());
            AssertBaseFields        (reflect .Fields  ("MyBase" ));
            AssertBaseFieldDic      (reflect .FieldDic("MyBase" ));
        }
        // Statics
        foreach (var reflect in _reflectorsStatic)
        {
            AssertStaticFields      (reflect .Fields  (_myObject));
            AssertStaticFieldDic    (reflect .FieldDic(_myObject));
            AssertStaticFields      (reflect .Fields  (_myType  ));
            AssertStaticFieldDic    (reflect .FieldDic(_myType  ));
            AssertStaticFields      (reflect .Fields   <MyType>());
            AssertStaticFieldDic    (reflect .FieldDic <MyType>());
            AssertStaticFields      (reflect .Fields  ("MyType" ));
            AssertStaticFieldDic    (reflect .FieldDic(" MyType"));
        }
        // Instance
        foreach (var reflect in _reflectorsInstance)
        {
            AssertInstanceFields    (reflect .Fields  (_myObject));
            AssertInstanceFieldDic  (reflect .FieldDic(_myObject));
            AssertInstanceFields    (reflect .Fields  (_myType  ));
            AssertInstanceFieldDic  (reflect .FieldDic(_myType  ));
            AssertInstanceFields    (reflect .Fields   <MyType>());
            AssertInstanceFieldDic  (reflect .FieldDic <MyType>());
            AssertInstanceFields    (reflect .Fields  ("MyType" ));
            AssertInstanceFieldDic  (reflect .FieldDic(" MyType"));
        }
    }
    
    private void AssertFields(FieldInfo[] fields)
    {
        fields = fields.OrderBy(x => x.Name).ToArray();
        IsNotNull(                      fields        );
        AreEqual (4,                    fields.Length );
        IsNotNull(                      fields[0]     );
        IsNotNull(                      fields[1]     );
        IsNotNull(                      fields[2]     );
        IsNotNull(                      fields[3]     );
        AreEqual ("_myBaseField",       fields[0].Name);
        AreEqual ("_myField",           fields[1].Name);
        AreEqual ("_myStaticBaseField", fields[2].Name);
        AreEqual ("_myStaticField",     fields[3].Name);
    }
    
    private void AssertFieldDic(Dictionary<string, FieldInfo> fields)
    {
        IsNotNull(                      fields                           );
        AreEqual (4,                    fields.Count                     );
        IsNotNull(                      fields["_myBaseField"      ]     );
        IsNotNull(                      fields["_myField"          ]     );
        IsNotNull(                      fields["_myStaticBaseField"]     );
        IsNotNull(                      fields["_myStaticField"    ]     );
        AreEqual ("_myBaseField",       fields["_myBaseField"      ].Name);
        AreEqual ("_myField",           fields["_myField"          ].Name);
        AreEqual ("_myStaticBaseField", fields["_myStaticBaseField"].Name);
        AreEqual ("_myStaticField",     fields["_myStaticField"    ].Name);
    }
    
    private void AssertBaseFields(FieldInfo[] fields)
    {
        fields = fields.OrderBy(x => x.Name).ToArray();
        IsNotNull(                      fields        );
        AreEqual (2,                    fields.Length );
        IsNotNull(                      fields[0]     );
        IsNotNull(                      fields[1]     );
        AreEqual ("_myBaseField",       fields[0].Name);
        AreEqual ("_myStaticBaseField", fields[1].Name);
    }
        
    private void AssertBaseFieldDic(Dictionary<string, FieldInfo> fields)
    {
        IsNotNull(                      fields                           );
        AreEqual (2,                    fields.Count                     );
        IsNotNull(                      fields["_myBaseField"      ]     );
        IsNotNull(                      fields["_myStaticBaseField"]     );
        AreEqual ("_myBaseField",       fields["_myBaseField"      ].Name);
        AreEqual ("_myStaticBaseField", fields["_myStaticBaseField"].Name);
    }

    private void AssertBaselessFields(FieldInfo[] fields)
    {
        fields = fields.OrderBy(x => x.Name).ToArray();
        IsNotNull(                      fields        );
        AreEqual (2,                    fields.Length );
        IsNotNull(                      fields[0]     );
        IsNotNull(                      fields[1]     );
        AreEqual ("_myField",           fields[0].Name);
        AreEqual ("_myStaticField",     fields[1].Name);
    }
    
    private void AssertBaselessFieldDic(Dictionary<string, FieldInfo> fields)
    {
        IsNotNull(                      fields                           );
        AreEqual (2,                    fields.Count                     );
        IsNotNull(                      fields["_myField"          ]     );
        IsNotNull(                      fields["_myStaticField"    ]     );
        AreEqual ("_myField",           fields["_myField"          ].Name);
        AreEqual ("_myStaticField",     fields["_myStaticField"    ].Name);
    }
    
    private void AssertStaticFields(FieldInfo[] fields)
    {
        fields = fields.OrderBy(x => x.Name).ToArray();
        IsNotNull(                      fields        );
        AreEqual (2,                    fields.Length );
        IsNotNull(                      fields[0]     );
        IsNotNull(                      fields[1]     );
        AreEqual ("_myStaticBaseField", fields[0].Name);
        AreEqual ("_myStaticField",     fields[1].Name);
    }
    
    private void AssertStaticFieldDic(Dictionary<string, FieldInfo> fields)
    {
        IsNotNull(                      fields                           );
        AreEqual (2,                    fields.Count                     );
        IsNotNull(                      fields["_myStaticBaseField"]     );
        IsNotNull(                      fields["_myStaticField"    ]     );
        AreEqual ("_myStaticBaseField", fields["_myStaticBaseField"].Name);
        AreEqual ("_myStaticField",     fields["_myStaticField"    ].Name);
    }
    
    private void AssertInstanceFields(FieldInfo[] fields)
    {
        fields = fields.OrderBy(x => x.Name).ToArray();
        IsNotNull(                      fields        );
        AreEqual (2,                    fields.Length );
        IsNotNull(                      fields[0]     );
        IsNotNull(                      fields[1]     );
        AreEqual ("_myBaseField",       fields[0].Name);
        AreEqual ("_myField",           fields[1].Name);
    }
    
    private void AssertInstanceFieldDic(Dictionary<string, FieldInfo> fields)
    {
        IsNotNull(                      fields                          );
        AreEqual (2,                    fields.Count                    );
        IsNotNull(                      fields["_myBaseField"     ]     );
        IsNotNull(                      fields["_myField"         ]     );
        AreEqual ("_myBaseField",       fields["_myBaseField"     ].Name);
        AreEqual ("_myField",           fields["_myField"         ].Name);
    }
}