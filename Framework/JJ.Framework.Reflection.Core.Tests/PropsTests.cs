namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class PropsTests : ReflectorTestBase
{
    [TestMethod]
    public void Reflector_Props()
    {
        // Main use + trims + ignores case 
        {
            AssertProps   (      _myObject.Props  (         ));
            AssertPropDic (      _myObject.PropDic(         ));
            AssertProps   (      _myType  .Props  (         ));
            AssertPropDic (      _myType  .PropDic(         ));
            AssertProps   (      "MyType ".Props  (         ));
            AssertPropDic (      " mytype".PropDic(         ));
            AssertProps   (                Props  (_myObject));
            AssertPropDic (                PropDic(_myObject));
            AssertProps   (                Props  (_myType  ));
            AssertPropDic (                PropDic(_myType  ));
            AssertProps   (                Props   <MyType>());
            AssertPropDic (                PropDic <MyType>());
            AssertProps   (                Props  ("MYTYPE" ));
            AssertPropDic (                PropDic("MyType" ));
            AssertProps   (      Reflect  .Props  (_myObject));
            AssertPropDic (      Reflect  .PropDic(_myObject));
            AssertProps   (      Reflect  .Props  (_myType  ));
            AssertPropDic (      Reflect  .PropDic(_myType  ));
            AssertProps   (      Reflect  .Props   <MyType>());
            AssertPropDic (      Reflect  .PropDic <MyType>());
            AssertProps   (      Reflect  .Props  (" MyType"));
            AssertPropDic (      Reflect  .PropDic(" mytype"));
        }
        // Not found scenarios
        {
            ThrowsNotFound(() => "NoType" .Props  (         ));
            ThrowsNotFound(() => "NoType" .PropDic(         ));
            ThrowsNotFound(() =>           Props  ("NoType" ));
            ThrowsNotFound(() =>           PropDic("NoType" ));
            ThrowsNotFound(() => Reflect  .Props  ("NoType" ));
            ThrowsNotFound(() => Reflect  .PropDic("NoType" ));
        }
        // Instantiated (allowing custom options)
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            AssertProps   (      reflect  .Props  (_myObject));
            AssertPropDic (      reflect  .PropDic(_myObject));
            AssertProps   (      reflect  .Props  (_myType  ));
            AssertPropDic (      reflect  .PropDic(_myType  ));
            AssertProps   (      reflect  .Props   <MyType>());
            AssertPropDic (      reflect  .PropDic <MyType>());
            AssertProps   (      reflect  .Props  ("MyType" ));
            AssertPropDic (      reflect  .PropDic(" MyType"));
            ThrowsNotFound(() => reflect  .Props  ("NoType" ));
            ThrowsNotFound(() => reflect  .PropDic("NoType" ));
        }
        // Match case (optional)
        foreach (var reflect in _reflectorsMatchCase)
        {
            AssertProps   (      reflect  .Props  ("MyType" ));
            AssertPropDic (      reflect  .PropDic("MyType "));
            ThrowsNotFound(() => reflect  .Props  ("MYTYPE" ));
            ThrowsNotFound(() => reflect  .PropDic("mytype" ));
        }
        
        // TODO: Base type
    }
    
    private void AssertProps(PropertyInfo[] props)
    {
        IsNotNull(props                      );
        AreEqual (props.Length, 2            );
        IsNotNull(props[0]                   );
        IsNotNull(props[1]                   );
        AreEqual (props[0].Name, "MyProp"    );
        AreEqual (props[1].Name, "MyBaseProp");
    }
    
    private void AssertPropDic(Dictionary<string, PropertyInfo> props)
    {
        IsNotNull(props                                 );
        AreEqual (props.Count, 2                        );
        IsNotNull(props["MyProp"    ]                   );
        IsNotNull(props["MyBaseProp"]                   );
        AreEqual (props["MyProp"    ].Name, "MyProp"    );
        AreEqual (props["MyBaseProp"].Name, "MyBaseProp");
    }
}