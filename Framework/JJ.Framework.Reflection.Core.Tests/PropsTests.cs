namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class PropsTests : ReflectorTestBase
{
    [TestMethod]
    public void Reflector_Props()
    {
        AssertProps  ( _myType.Props()           );
        AssertPropDic( _myType.PropDic()         );
        AssertProps  ( Props  (_myType)          );
        AssertPropDic( PropDic(_myType)          );
        AssertProps  ( Props  <MyType>()         );
        AssertPropDic( PropDic<MyType>()         );
        AssertProps  ( Props  ("MyType")         );
        AssertPropDic( PropDic("MyType")         );
        AssertProps  ( Reflect.Props  ("MyType") );
        AssertPropDic( Reflect.PropDic("MyType") );
        AssertProps  ( Reflect.Props  <MyType>() );
        AssertPropDic( Reflect.PropDic<MyType>() );
        AssertProps  ( Reflect.Props  (_myType)  );
        AssertPropDic( Reflect.PropDic(_myType)  );
    
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            AssertProps  ( reflect.Props  ("MyType") );
            AssertPropDic( reflect.PropDic("MyType") );
            AssertProps  ( reflect.Props  <MyType>() );
            AssertPropDic( reflect.PropDic<MyType>() );
            AssertProps  ( reflect.Props  (_myType)  );
            AssertPropDic( reflect.PropDic(_myType)  );
        }
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