// ReSharper disable RedundantArgumentDefaultValue
namespace JJ.Framework.Reflection.Tests.AccessorTests;

[TestClass]
public class AccessorTests_Examples
{
    // Helper Classes
    
    private class MyClass : TheBaseClass
    {
        private string MyProperty { get; set; } = "10";
        private string MyPrivateMethod(int para) => (para * 10).ToString();
        private string MyPrivateMethod2(int para1, int? para2) => (para1 * para2 * 10).ToString();
    }
    
    private static class MyStaticClass;

    private class TheBaseClass
    {
        public int MyBaseProperty { get; set; }
    }
    
    private class TestAccessorBase
    {
        protected Accessor _accessor = new(new MyClass());
    }
    
    // Method Access

    private class TestAccessor_MethodCall_ByLambda : TestAccessorBase
    {
        public string MyPrivateMethod(int para) =>
            _accessor.InvokeMethod(() => MyPrivateMethod(para));
    }

    private class TestAccessor_MethodCall_ByCallerMemberName : TestAccessorBase
    {
        public string MyPrivateMethod(int para) =>
            (string)_accessor.InvokeMethod(para);
    }
    
    private class TestAccessor_MethodCall_ByName : TestAccessorBase
    {
        public void MyPrivateMethod() =>
            _accessor.InvokeMethod("MyPrivateMethod", 10);
    }
            
    [TestMethod]
    public void Accessor_MethodCall_ByLambda()
    {
        var accessor = new TestAccessor_MethodCall_ByLambda();
        AreEqual("10", () => accessor.MyPrivateMethod(1));
    }

    [TestMethod]
    public void Accessor_MethodCall_ByCallerMemberName()
    {
        var accessor = new TestAccessor_MethodCall_ByCallerMemberName();
        AreEqual("20", () => accessor.MyPrivateMethod(2));
    }

    [TestMethod]
    public void Accessor_MethodCall_ByName()
    {
        var accessor = new TestAccessor_MethodCall_ByName();
        accessor.MyPrivateMethod();
    }

    // Property Access
    
    private class MyAccessor_Property_ByLambda : TestAccessorBase
    {
        public string MyProperty => _accessor.GetPropertyValue(() => MyProperty);
    }

    private class MyAccessor_Property_ByCallerMemberName : TestAccessorBase
    {
        public string MyProperty => (string)_accessor.GetPropertyValue();
    }
    
    private class MyAccessor_Property_ByCallerMemberName_WithTypeArgument : TestAccessorBase
    {
        public string MyProperty => _accessor.GetPropertyValue<string>();
    }
    
    private class MyAccessor_Property_ByName : TestAccessorBase
    {
        public string MyProperty => (string)_accessor.GetPropertyValue("MyProperty");
    }
    
    private class MyAccessor_Property_ByName_WithTypeArgument : TestAccessorBase
    {
        public string MyProperty => _accessor.GetPropertyValue<string>("MyProperty");
    }
    
    [TestMethod]
    public void Accessor_Property_ByLambda()
    {
        var accessor = new MyAccessor_Property_ByLambda();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void Accessor_Property_ByCallerMemberName()
    {
        var accessor = new MyAccessor_Property_ByCallerMemberName();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void Accessor_Property_ByCallerMemberName_WithTypeArgument()
    {
        var accessor = new MyAccessor_Property_ByCallerMemberName_WithTypeArgument();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void Accessor_Property_ByName()
    {
        var accessor = new MyAccessor_Property_ByName();
        AreEqual("10", () => accessor.MyProperty);
        AssertHelper.AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void Accessor_Property_ByName_WithTypeArgument()
    {
        var accessor = new MyAccessor_Property_ByName_WithTypeArgument();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    // Construction
    
    [TestMethod]
    public void Accessor_Construction_WithObject()
    {
        var myObject = new MyClass();
        var accessor = new Accessor(myObject);
    }
    
    [TestMethod]
    public void Accessor_Construction_WithType()
    {
        var accessor = new Accessor(typeof(MyStaticClass));
    }
    
    [TestMethod]
    public void Accessor_Construction_WithObjectAndType()
    {
        var myObject = new MyClass();
        var accessor = new Accessor(myObject, typeof(TheBaseClass));
    }
    
    [TestMethod]
    public void Accessor_Construction_BaseAndDerived()
    { 
        var myObject = new MyClass();
        var concreteAccessor = new Accessor(myObject);
        var baseAccessor = new Accessor(myObject, typeof(TheBaseClass));
    }
   
    [TestMethod]
    public void Accessor_Construction_WithTypeName()
    {
        var myObject = new MyClass();
        var accessor = new Accessor($"{MyNamespace}.{MyPrivateClass}, {MyAssembly}");
    }
    
    string MyNamespace => GetType().Namespace; 
    string MyPrivateClass => GetType().Name;
    string MyAssembly => GetType().Assembly.GetName().Name;

    // Wrappers

    [TestMethod]
    public void Accessor_Wrapper()
    {
        var accessor = new MyAccessor(new MyClass());
        string myString = accessor.MyPrivateMethod(10);
        AreEqual("100", () => myString);
    }
    
    class MyAccessor(MyClass myObject)
    {
        Accessor _accessor = new(myObject);
        
        public string MyPrivateMethod(int para) 
            => (string)_accessor.InvokeMethod(para);
    }

    // Overloaded Methods
    
    class OverloadAccessor1 : TestAccessorBase
    {
        public string MyPrivateMethod2(int para1, int? para2) =>
            (string)_accessor.InvokeMethod(para1, para2);
    }

    class OverloadAccessor3 : TestAccessorBase
    {
        public string MyPrivateMethod(int para) =>
            (string)_accessor.InvokeMethod( [ para ], [ typeof(int) ] );
    }

    class OverloadAccessor4 : TestAccessorBase
    {
        public string MyPrivateMethod2(int para1, int? para2) =>
            (string)_accessor.InvokeMethod( [ para1, para2 ], [ null, typeof(int?) ] );
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod1()
    {
        var accessor = new OverloadAccessor1();
        AreEqual("60", () => accessor.MyPrivateMethod2(2, 3));
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod3()
    {
        var accessor = new OverloadAccessor3();
        AreEqual("10", () => accessor.MyPrivateMethod(1));
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod4()
    {
        var accessor = new OverloadAccessor4();
        AreEqual("350", () => accessor.MyPrivateMethod2(5, 7));
    }
}
