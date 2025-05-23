namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class MethodTests : ReflectorTestBase
{
    [TestMethod]
    public void MethodTests_GetMethods()
    {
        {
            AssertMethod0 (      _myObject.Method(           "method0"));
            AssertMethod0 (      _myType  .Method(           "Method0"));
            AssertMethod0 (                Method(_myObject, "Method0"));
            AssertMethod0 (                Method(_myType,   "Method0"));
            AssertMethod0 (                Method <MyType>(  "Method0"));
            AssertMethod0 (      Reflect  .Method(_myObject, "Method0"));
            AssertMethod0 (      Reflect  .Method(_myType,   "Method0"));
            AssertMethod0 (      Reflect  .Method <MyType>(  "Method0"));
        }
        foreach (var reflect in _reflectors)
        {
            AssertMethod0 (      reflect  .Method(_myObject, "Method0"));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0"));
            AssertMethod0 (      reflect  .Method <MyType>(  "Method0"));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable: true ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable: false));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable       ));
        }
        // Not found
        foreach (var reflect in _reflectors)
        {
            IsNull        (      reflect  .Method(_myType,   "NoName", nullable: true ));
            ThrowsNotFound(() => reflect  .Method(_myType,   "NoName", nullable: false));
            IsNull        (      reflect  .Method(_myType,   "NoName", nullable       ));
            ThrowsNotFound(() => reflect  .Method(_myType,   "NoName"                 ));
        }
    }
    
    private void AssertMethod0(MethodInfo? method)
    {
        IsNotNull(method);
        AreEqual("Method0", method.Name);
        AreEqual(0, method.GetParameters().Length);
    }
}