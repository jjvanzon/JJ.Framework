namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class MethodTests : ReflectorTestBase
{
    [TestMethod]
    public void MethodTests_GetMethods()
    {
        // Main Use
        {
            AssertMethod0 (      _myObject.Method(           "Method0"));
            AssertMethod0 (      _myType  .Method(           "METHOD0"));
            AssertMethod0 (                Method(_myObject, "Method0"));
            //AssertMethod0(               Method(_myType,  " Method0"));
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
        }
        // Nullable
        foreach (var reflect in _reflectors)
        {
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", null           ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable       ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable: true ));
            AssertMethod0 (      reflect  .Method(_myType,   "Method0", nullable: false));
        }
        // Not Found
        foreach (var reflect in _reflectors)
        {
            IsNull        (      reflect  .Method(_myType,   "NoName", null           ));
            IsNull        (      reflect  .Method(_myType,   "NoName", nullable       ));
            IsNull        (      reflect  .Method(_myType,   "NoName", nullable: true ));
            ThrowsNotFound(() => reflect  .Method(_myType,   "NoName", nullable: false));
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