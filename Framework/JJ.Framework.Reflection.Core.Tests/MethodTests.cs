namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class MethodTests : ReflectorTestBase
{
    [TestMethod]
    public void Method_Core_Tests()
    {
        // Main Use
        {
            AssertMethod0 (                Method(_myObject, "Method0"));
            AssertMethod0 (                Method(_myType,   "Method0"));
            AssertMethod0 (                Method("MyType",  "Method0"));
            AssertMethod0 (                Method <MyType>(  "Method0"));
            AssertMethod0 (      _myObject.Method(           "Method0"));
            AssertMethod0 (      _myType  .Method(           "METHOD0"));
            AssertMethod0 (      "myType" .Method(           "Method0"));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0"));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0"));
            AssertMethod0 (      Reflect  .Method("MyType",  "Method0"));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0"));
        }
        foreach (var reflect in _reflectors)
        {
            AssertMethod0 (      reflect  .Method(_myObject, "Method0"));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0"));
            AssertMethod0 (      reflect  .Method("MyType",  "Method0"));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0"));
        }
        
        // TODO: This could inspire many more supported parameter orders.
        //AssertMethod0("Method0".Method <MyType>()); 
    }

    [TestMethod]
    public void Method_NotFound()
    {
        {
            IsNull        (                Method(_myObject, "NoName", null           ));
            IsNull        (                Method(_myObject, "NoName", nullable       ));
            IsNull        (                Method(_myObject, "NoName", nullable: true ));
            ThrowsNotFound(() =>           Method(_myObject, "NoName", nullable: false));
            ThrowsNotFound(() =>           Method(_myObject, "NoName"                 ));
            IsNull        (                Method(_myType,   "NoName", null           ));
            IsNull        (                Method(_myType,   "NoName", nullable       ));
            IsNull        (                Method(_myType,   "NoName", nullable: true ));
            ThrowsNotFound(() =>           Method(_myType,   "NoName", nullable: false));
            ThrowsNotFound(() =>           Method(_myType,   "NoName"                 ));
            IsNull        (                Method("MyType",  "NoName", null           ));
            IsNull        (                Method("MyType",  "NoName", nullable       ));
            IsNull        (                Method("MyType",  "NoName", nullable: true ));
            ThrowsNotFound(() =>           Method("MyType",  "NoName", nullable: false));
            ThrowsNotFound(() =>           Method("MyType",  "NoName"                 ));
            IsNull        (                Method <MyType>(  "NoName", null           ));
            IsNull        (                Method <MyType>(  "NoName", nullable       ));
            IsNull        (                Method <MyType>(  "NoName", nullable: true ));
            ThrowsNotFound(() =>           Method <MyType>(  "NoName", nullable: false));
            ThrowsNotFound(() =>           Method <MyType>(  "NoName"                 ));
            IsNull        (      _myObject.Method(           "NoName", null           ));
            IsNull        (      _myObject.Method(           "NoName", nullable       ));
            IsNull        (      _myObject.Method(           "NoName", nullable: true ));
            ThrowsNotFound(() => _myObject.Method(           "NoName", nullable: false));
            ThrowsNotFound(() => _myObject.Method(           "NoName"                 ));
            IsNull        (      _myType  .Method(           "NoName", null           ));
            IsNull        (      _myType  .Method(           "NoName", nullable       ));
            IsNull        (      _myType  .Method(           "NoName", nullable: true ));
            ThrowsNotFound(() => _myType  .Method(           "NoName", nullable: false));
            ThrowsNotFound(() => _myType  .Method(           "NoName"                 ));
            IsNull        (      "MyType" .Method(           "NoName", null           ));
            IsNull        (      "MyType" .Method(           "NoName", nullable       ));
            IsNull        (      "MyType" .Method(           "NoName", nullable: true ));
            ThrowsNotFound(() => "MyType" .Method(           "NoName", nullable: false));
            ThrowsNotFound(() => "MyType" .Method(           "NoName"                 ));
            IsNull        (      Reflect.  Method(_myObject, "NoName", null           ));
            IsNull        (      Reflect.  Method(_myObject, "NoName", nullable       ));
            IsNull        (      Reflect.  Method(_myObject, "NoName", nullable: true ));
            ThrowsNotFound(() => Reflect.  Method(_myObject, "NoName", nullable: false));
            ThrowsNotFound(() => Reflect.  Method(_myObject, "NoName"                 ));
            IsNull        (      Reflect.  Method(_myType,   "NoName", null           ));
            IsNull        (      Reflect.  Method(_myType,   "NoName", nullable       ));
            IsNull        (      Reflect.  Method(_myType,   "NoName", nullable: true ));
            ThrowsNotFound(() => Reflect.  Method(_myType,   "NoName", nullable: false));
            ThrowsNotFound(() => Reflect.  Method(_myType,   "NoName"                 ));
            IsNull        (      Reflect.  Method("MyType",  "NoName", null           ));
            IsNull        (      Reflect.  Method("MyType",  "NoName", nullable       ));
            IsNull        (      Reflect.  Method("MyType",  "NoName", nullable: true ));
            ThrowsNotFound(() => Reflect.  Method("MyType",  "NoName", nullable: false));
            ThrowsNotFound(() => Reflect.  Method("MyType",  "NoName"                 ));
            IsNull        (      Reflect.  Method <MyType>(  "NoName", null           ));
            IsNull        (      Reflect.  Method <MyType>(  "NoName", nullable       ));
            IsNull        (      Reflect.  Method <MyType>(  "NoName", nullable: true ));
            ThrowsNotFound(() => Reflect.  Method <MyType>(  "NoName", nullable: false));
            ThrowsNotFound(() => Reflect.  Method <MyType>(  "NoName"                 ));
        }
        foreach (var reflect in _reflectors)
        {
            IsNull        (      reflect  .Method(_myObject, "NoName", null           ));
            IsNull        (      reflect  .Method(_myObject, "NoName", nullable       ));
            IsNull        (      reflect  .Method(_myObject, "NoName", nullable: true ));
            ThrowsNotFound(() => reflect  .Method(_myObject, "NoName", nullable: false));
            ThrowsNotFound(() => reflect  .Method(_myObject, "NoName"                 ));
            IsNull        (      reflect  .Method(_myType,   "NoName", null           ));
            IsNull        (      reflect  .Method(_myType,   "NoName", nullable       ));
            IsNull        (      reflect  .Method(_myType,   "NoName", nullable: true ));
            ThrowsNotFound(() => reflect  .Method(_myType,   "NoName", nullable: false));
            ThrowsNotFound(() => reflect  .Method(_myType,   "NoName"                 ));
            IsNull        (      reflect  .Method("MyType",  "NoName", null           ));
            IsNull        (      reflect  .Method("MyType",  "NoName", nullable       ));
            IsNull        (      reflect  .Method("MyType",  "NoName", nullable: true ));
            ThrowsNotFound(() => reflect  .Method("MyType",  "NoName", nullable: false));
            ThrowsNotFound(() => reflect  .Method("MyType",  "NoName"                 ));
            IsNull        (      reflect  .Method <MyType>(  "NoName", null           ));
            IsNull        (      reflect  .Method <MyType>(  "NoName", nullable       ));
            IsNull        (      reflect  .Method <MyType>(  "NoName", nullable: true ));
            ThrowsNotFound(() => reflect  .Method <MyType>(  "NoName", nullable: false));
            ThrowsNotFound(() => reflect  .Method <MyType>(  "NoName"                 ));
        }
    }
    
    [TestMethod]
    public void Method_Success_InvariantUnderNullable()
    {
        {
            AssertMethod0 (                Method(_myObject, "Method0"                 ));
            AssertMethod0 (                Method(_myType,   "Method0"                 ));
            AssertMethod0 (                Method("MyType",  "Method0"                 ));
            AssertMethod0 (                Method <MyType>(  "Method0"                 ));
            AssertMethod0 (                Method(_myObject, "Method0", null           ));
            AssertMethod0 (                Method(_myType,   "Method0", null           ));
            AssertMethod0 (                Method("MyType",  "Method0", null           ));
            AssertMethod0 (                Method <MyType>(  "Method0", null           ));
            AssertMethod0 (                Method(_myObject, "Method0", nullable       ));
            AssertMethod0 (                Method(_myType,   "Method0", nullable       ));
            AssertMethod0 (                Method("MyType",  "Method0", nullable       ));
            AssertMethod0 (                Method <MyType>(  "Method0", nullable       ));
            AssertMethod0 (                Method(_myObject, "Method0", nullable: true ));
            AssertMethod0 (                Method(_myType,   "Method0", nullable: true ));
            AssertMethod0 (                Method("MyType",  "Method0", nullable: true ));
            AssertMethod0 (                Method <MyType>(  "Method0", nullable: true ));
            AssertMethod0 (                Method(_myObject, "Method0", nullable: false));
            AssertMethod0 (                Method(_myType,   "Method0", nullable: false));
            AssertMethod0 (                Method("MyType",  "Method0", nullable: false));
            AssertMethod0 (                Method <MyType>(  "Method0", nullable: false));
            AssertMethod0 (     _myObject .Method(           "Method0"                 ));
            AssertMethod0 (     _myType   .Method(           "Method0"                 ));
            AssertMethod0 (     "MyType"  .Method(           "Method0"                 ));
            AssertMethod0 (     _myObject .Method(           "Method0", null           ));
            AssertMethod0 (     _myType   .Method(           "Method0", null           ));
            AssertMethod0 (     "MyType"  .Method(           "Method0", null           ));
            AssertMethod0 (     _myObject .Method(           "Method0", nullable       ));
            AssertMethod0 (     _myType   .Method(           "Method0", nullable       ));
            AssertMethod0 (     "MyType"  .Method(           "Method0", nullable       ));
            AssertMethod0 (     _myObject .Method(           "Method0", nullable: true ));
            AssertMethod0 (     _myType   .Method(           "Method0", nullable: true ));
            AssertMethod0 (     "MyType"  .Method(           "Method0", nullable: true ));
            AssertMethod0 (     _myObject .Method(           "Method0", nullable: false));
            AssertMethod0 (     _myType   .Method(           "Method0", nullable: false));
            AssertMethod0 (     "MyType"  .Method(           "Method0", nullable: false));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0"                 ));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0"                 ));
            AssertMethod0 (      Reflect  .Method("MyType",  "Method0"                 ));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0"                 ));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0", null           ));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0", null           ));
            AssertMethod0 (      Reflect  .Method("MyType",  "Method0", null           ));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0", null           ));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0", nullable       ));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0", nullable       ));
            AssertMethod0 (      Reflect  .Method("MyType",  "Method0", nullable       ));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0", nullable       ));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0", nullable: true ));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0", nullable: true ));
            AssertMethod0 (      Reflect  .Method("MyType",  "Method0", nullable: true ));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0", nullable: true ));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0", nullable: false));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0", nullable: false));
            AssertMethod0 (      Reflect  .Method("MyType",  "Method0", nullable: false));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0", nullable: false));
        }
        foreach (var reflect in _reflectors)
        {
            AssertMethod0 (      reflect  .Method(_myObject, "Method0"                 ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0"                 ));
            AssertMethod0 (      reflect  .Method("MyType",  "Method0"                 ));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0"                 ));
            AssertMethod0 (      reflect  .Method(_myObject, "Method0", null           ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", null           ));
            AssertMethod0 (      reflect  .Method("MyType",  "Method0", null           ));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0", null           ));
            AssertMethod0 (      reflect  .Method(_myObject, "Method0", nullable       ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable       ));
            AssertMethod0 (      reflect  .Method("MyType",  "Method0", nullable       ));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0", nullable       ));
            AssertMethod0 (      reflect  .Method(_myObject, "Method0", nullable: true ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable: true ));
            AssertMethod0 (      reflect  .Method("MyType",  "Method0", nullable: true ));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0", nullable: true ));
            AssertMethod0 (      reflect  .Method(_myObject, "Method0", nullable: false));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable: false));
            AssertMethod0 (      reflect  .Method("MyType",  "Method0", nullable: false));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0", nullable: false));
        }
    }
    
    private void AssertMethod0(MethodInfo? method)
    {
        IsNotNull(method);
        AreEqual("Method0", method.Name);
        AreEqual(0, method.GetParameters().Length);
    }
}