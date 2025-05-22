


namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class PropsTests : ReflectorTestBase
{
    [TestMethod]
    public void Reflector_Props()
    {
        // Main use + trims + ignores case 
        {
            AssertProps     (      _myObject.Props  (         ));
            AssertPropDic   (      _myObject.PropDic(         ));
            AssertProps     (      _myType  .Props  (         ));
            AssertPropDic   (      _myType  .PropDic(         ));
            AssertProps     (      "MyType ".Props  (         ));
            AssertPropDic   (      " mytype".PropDic(         ));
            AssertProps     (                Props  (_myObject));
            AssertPropDic   (                PropDic(_myObject));
            AssertProps     (                Props  (_myType  ));
            AssertPropDic   (                PropDic(_myType  ));
            AssertProps     (                Props   <MyType>());
            AssertPropDic   (                PropDic <MyType>());
            AssertProps     (                Props  ("MYTYPE" ));
            AssertPropDic   (                PropDic("MyType" ));
            AssertProps     (      Reflect  .Props  (_myObject));
            AssertPropDic   (      Reflect  .PropDic(_myObject));
            AssertProps     (      Reflect  .Props  (_myType  ));
            AssertPropDic   (      Reflect  .PropDic(_myType  ));
            AssertProps     (      Reflect  .Props   <MyType>());
            AssertPropDic   (      Reflect  .PropDic <MyType>());
            AssertProps     (      Reflect  .Props  (" MyType"));
            AssertPropDic   (      Reflect  .PropDic(" mytype"));
        }
        // Not found scenarios
        {
            ThrowsNotFound  (() => "NoType" .Props  (         ));
            ThrowsNotFound  (() => "NoType" .PropDic(         ));
            ThrowsNotFound  (() =>           Props  ("NoType" ));
            ThrowsNotFound  (() =>           PropDic("NoType" ));
            ThrowsNotFound  (() => Reflect  .Props  ("NoType" ));
            ThrowsNotFound  (() => Reflect  .PropDic("NoType" ));
        }
        // Instantiated (allows custom options)
        foreach (var reflect in Union(_reflectors, _reflectorsMatchCase))
        {
            AssertProps     (      reflect  .Props  (_myObject));
            AssertPropDic   (      reflect  .PropDic(_myObject));
            AssertProps     (      reflect  .Props  (_myType  ));
            AssertPropDic   (      reflect  .PropDic(_myType  ));
            AssertProps     (      reflect  .Props   <MyType>());
            AssertPropDic   (      reflect  .PropDic <MyType>());
            AssertProps     (      reflect  .Props  ("MyType" ));
            AssertPropDic   (      reflect  .PropDic(" MyType"));
            ThrowsNotFound  (() => reflect  .Props  ("NoType" ));
            ThrowsNotFound  (() => reflect  .PropDic("NoType" ));
        }
        // Match case (optional)
        foreach (var reflect in _reflectorsMatchCase)
        {
            AssertProps     (      reflect  .Props  ("MyType" ));
            AssertPropDic   (      reflect  .PropDic("MyType "));
            ThrowsNotFound  (() => reflect  .Props  ("MYTYPE" ));
            ThrowsNotFound  (() => reflect  .PropDic("mytype" ));
        }
        // Base Types
        {
            AssertBaseProps        (_myBase .Props  (         ));
            AssertBasePropDic      (_myBase .PropDic(         ));
            AssertBaseProps        ("myBase".Props  (         ));
            AssertBasePropDic      ("myBase".PropDic(         ));
            AssertBaseProps        (         Props  (_myBase  ));
            AssertBasePropDic      (         PropDic(_myBase  ));
            AssertBaseProps        (         Props   <MyBase>());
            AssertBasePropDic      (         PropDic <MyBase>());
            AssertBaseProps        (         Props  ("MyBase" ));
            AssertBasePropDic      (         PropDic("mybase" ));
            AssertBaseProps        (Reflect .Props  (_myBase  ));
            AssertBasePropDic      (Reflect .PropDic(_myBase  ));
            AssertBaseProps        (Reflect .Props   <MyBase>());
            AssertBasePropDic      (Reflect .PropDic <MyBase>());
            AssertBaseProps        (Reflect .Props  ("MYBASE" ));
            AssertBasePropDic      (Reflect .PropDic("MyBase" ));
        }
        foreach (var reflect in _baselessReflectors)
        {
            AssertBaselessProps    (reflect .Props  (_myObject));
            AssertBaselessPropDic  (reflect .PropDic(_myObject));
            AssertBaselessProps    (reflect .Props  (_myType  ));
            AssertBaselessPropDic  (reflect .PropDic(_myType  ));
            AssertBaselessProps    (reflect .Props   <MyType>());
            AssertBaselessPropDic  (reflect .PropDic <MyType>());
            AssertBaselessProps    (reflect .Props  ("MyType" ));
            AssertBaselessPropDic  (reflect .PropDic("myType "));
            AssertBaseProps        (reflect .Props  (_myBase  ));
            AssertBasePropDic      (reflect .PropDic(_myBase  ));
            AssertBaseProps        (reflect .Props   <MyBase>());
            AssertBasePropDic      (reflect .PropDic <MyBase>());
            AssertBaseProps        (reflect .Props  ("MyBase" ));
            AssertBasePropDic      (reflect .PropDic("MyBase" ));
        }
        // Statics
        foreach (var reflect in _reflectorsStatic)
        {
            AssertStaticProps      (reflect .Props  (_myObject));
            AssertStaticPropDic    (reflect .PropDic(_myObject));
            AssertStaticProps      (reflect .Props  (_myType  ));
            AssertStaticPropDic    (reflect .PropDic(_myType  ));
            AssertStaticProps      (reflect .Props   <MyType>());
            AssertStaticPropDic    (reflect .PropDic <MyType>());
            AssertStaticProps      (reflect .Props  ("MyType" ));
            AssertStaticPropDic    (reflect .PropDic(" MyType"));
        }
        // Instance
        foreach (var reflect in _reflectorsInstance)
        {
            AssertInstanceProps    (reflect .Props  (_myObject));
            AssertInstancePropDic  (reflect .PropDic(_myObject));
            AssertInstanceProps    (reflect .Props  (_myType  ));
            AssertInstancePropDic  (reflect .PropDic(_myType  ));
            AssertInstanceProps    (reflect .Props   <MyType>());
            AssertInstancePropDic  (reflect .PropDic <MyType>());
            AssertInstanceProps    (reflect .Props  ("MyType" ));
            AssertInstancePropDic  (reflect .PropDic(" MyType"));
        }
    }
    
    private void AssertProps(PropertyInfo[] props)
    {
        props = props.OrderBy(x => x.Name).ToArray();
        IsNotNull(                    props        );
        AreEqual (4,                  props.Length );
        IsNotNull(                    props[0]     );
        IsNotNull(                    props[1]     );
        IsNotNull(                    props[2]     );
        IsNotNull(                    props[3]     );
        AreEqual ("MyBaseProp",       props[0].Name);
        AreEqual ("MyProp",           props[1].Name);
        AreEqual ("MyStaticBaseProp", props[2].Name);
        AreEqual ("MyStaticProp",     props[3].Name);
    }
    
    private void AssertPropDic(Dictionary<string, PropertyInfo> props)
    {
        IsNotNull(                    props                         );
        AreEqual (4,                  props.Count                   );
        IsNotNull(                    props["MyBaseProp"      ]     );
        IsNotNull(                    props["MyProp"          ]     );
        IsNotNull(                    props["MyStaticBaseProp"]     );
        IsNotNull(                    props["MyStaticProp"    ]     );
        AreEqual ("MyBaseProp",       props["MyBaseProp"      ].Name);
        AreEqual ("MyProp",           props["MyProp"          ].Name);
        AreEqual ("MyStaticBaseProp", props["MyStaticBaseProp"].Name);
        AreEqual ("MyStaticProp",     props["MyStaticProp"    ].Name);
    }
    
    private void AssertBaseProps(PropertyInfo[] props)
    {
        props = props.OrderBy(x => x.Name).ToArray();
        IsNotNull(                    props        );
        AreEqual (2,                  props.Length );
        IsNotNull(                    props[0]     );
        IsNotNull(                    props[1]     );
        AreEqual ("MyBaseProp",       props[0].Name);
        AreEqual ("MyStaticBaseProp", props[1].Name);
    }
        
    private void AssertBasePropDic(Dictionary<string, PropertyInfo> props)
    {
        IsNotNull(                    props                         );
        AreEqual (2,                  props.Count                   );
        IsNotNull(                    props["MyBaseProp"      ]     );
        IsNotNull(                    props["MyStaticBaseProp"]     );
        AreEqual ("MyBaseProp",       props["MyBaseProp"      ].Name);
        AreEqual ("MyStaticBaseProp", props["MyStaticBaseProp"].Name);
    }

    private void AssertBaselessProps(PropertyInfo[] props)
    {
        props = props.OrderBy(x => x.Name).ToArray();
        IsNotNull(                    props        );
        AreEqual (2,                  props.Length );
        IsNotNull(                    props[0]     );
        IsNotNull(                    props[1]     );
        AreEqual ("MyProp",           props[0].Name);
        AreEqual ("MyStaticProp",     props[1].Name);
    }
    
    private void AssertBaselessPropDic(Dictionary<string, PropertyInfo> props)
    {
        IsNotNull(                    props                         );
        AreEqual (2,                  props.Count                   );
        IsNotNull(                    props["MyProp"          ]     );
        IsNotNull(                    props["MyStaticProp"    ]     );
        AreEqual ("MyProp",           props["MyProp"          ].Name);
        AreEqual ("MyStaticProp",     props["MyStaticProp"    ].Name);
    }
    
    private void AssertStaticProps(PropertyInfo[] props)
    {
        props = props.OrderBy(x => x.Name).ToArray();
        IsNotNull(                    props        );
        AreEqual (2,                  props.Length );
        IsNotNull(                    props[0]     );
        IsNotNull(                    props[1]     );
        AreEqual ("MyStaticBaseProp", props[0].Name);
        AreEqual ("MyStaticProp",     props[1].Name);
    }
    
    private void AssertStaticPropDic(Dictionary<string, PropertyInfo> props)
    {
        IsNotNull(                    props                         );
        AreEqual (2,                  props.Count                   );
        IsNotNull(                    props["MyStaticBaseProp"]     );
        IsNotNull(                    props["MyStaticProp"    ]     );
        AreEqual ("MyStaticBaseProp", props["MyStaticBaseProp"].Name);
        AreEqual ("MyStaticProp",     props["MyStaticProp"    ].Name);
    }
    
    private void AssertInstanceProps(PropertyInfo[] props)
    {
        props = props.OrderBy(x => x.Name).ToArray();
        IsNotNull(                    props        );
        AreEqual (2,                  props.Length );
        IsNotNull(                    props[0]     );
        IsNotNull(                    props[1]     );
        AreEqual ("MyBaseProp",       props[0].Name);
        AreEqual ("MyProp",           props[1].Name);
    }
    
    private void AssertInstancePropDic(Dictionary<string, PropertyInfo> props)
    {
        IsNotNull(                    props                        );
        AreEqual (2,                  props.Count                  );
        IsNotNull(                    props["MyBaseProp"     ]     );
        IsNotNull(                    props["MyProp"         ]     );
        AreEqual ("MyBaseProp",       props["MyBaseProp"     ].Name);
        AreEqual ("MyProp",           props["MyProp"         ].Name);
    }
}