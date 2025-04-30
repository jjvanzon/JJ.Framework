// ReSharper disable RedundantArgumentDefaultValue
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreExamples
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
        protected AccessorCore _accessor = new(new MyClass());
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
    public void AccessorCore_MethodCall_ByLambda()
    {
        var accessor = new TestAccessor_MethodCall_ByLambda();
        AreEqual("10", () => accessor.MyPrivateMethod(1));
    }

    [TestMethod]
    public void AccessorCore_MethodCall_ByCallerMemberName()
    {
        var accessor = new TestAccessor_MethodCall_ByCallerMemberName();
        AreEqual("20", () => accessor.MyPrivateMethod(2));
    }

    [TestMethod]
    public void AccessorCore_MethodCall_ByName()
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
    public void AccessorCore_Property_ByLambda()
    {
        var accessor = new MyAccessor_Property_ByLambda();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void AccessorCore_Property_ByCallerMemberName()
    {
        var accessor = new MyAccessor_Property_ByCallerMemberName();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void AccessorCore_Property_ByCallerMemberName_WithTypeArgument()
    {
        var accessor = new MyAccessor_Property_ByCallerMemberName_WithTypeArgument();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void AccessorCore_Property_ByName()
    {
        var accessor = new MyAccessor_Property_ByName();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void AccessorCore_Property_ByName_WithTypeArgument()
    {
        var accessor = new MyAccessor_Property_ByName_WithTypeArgument();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    // Construction
    
    [TestMethod]
    public void AccessorCore_Construction_WithObject()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore(myObject);
    }
    
    [TestMethod]
    public void AccessorCore_Construction_WithType()
    {
        var accessor = new AccessorCore(typeof(MyStaticClass));
    }
    
    [TestMethod]
    public void AccessorCore_Construction_WithObjectAndType()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore(myObject, typeof(TheBaseClass));
    }
    
    [TestMethod]
    public void AccessorCore_Construction_BaseAndDerived()
    { 
        var myObject = new MyClass();
        var concreteAccessor = new AccessorCore(myObject);
        var baseAccessor = new AccessorCore(myObject, typeof(TheBaseClass));
    }
   
    [TestMethod]
    public void AccessorCore_Construction_WithTypeName()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore($"{MyNamespace}.{MyPrivateClass}, {MyAssembly}");
    }
    
    string MyNamespace => GetType().Namespace; 
    string MyPrivateClass => GetType().Name;
    string MyAssembly => GetType().Assembly.GetName().Name;

    // Wrappers

    [TestMethod]
    public void AccessorCore_Wrapper()
    {
        var accessor = new MyAccessor(new MyClass());
        string myString = accessor.MyPrivateMethod(10);
        AreEqual("100", () => myString);
    }
    
    class MyAccessor(MyClass myObject)
    {
        AccessorCore _accessor = new(myObject);
        
        public string MyPrivateMethod(int para) 
            => (string)_accessor.InvokeMethod(para);
    }

    // Overloaded Methods

    class OverloadAccessor1 : TestAccessorBase
    {
        public string MyPrivateMethod(int myParameter) =>
            (string)_accessor.InvokeMethod( [ myParameter ], [ typeof(int) ] );
    }

    class OverloadAccessor2 : TestAccessorBase
    {
        public string MyPrivateMethod2(int myParameter1, int? myParameter2) =>
            (string)_accessor.InvokeMethod( [ myParameter1, myParameter2 ], [ null, typeof(int?) ] );
    }

    class OverloadAccessor3 : TestAccessorBase
    {
        public string MyPrivateMethod2(object parameter, object parameter2) =>
            (string)_accessor.InvokeMethod<int, int?>("MyPrivateMethod2", parameter, parameter2);
    }
    
    [TestMethod]
    public void AccessorCore_OverloadedMethod1()
    {
        var accessor = new OverloadAccessor1();
        AreEqual("10", () => accessor.MyPrivateMethod(1));
    }
    
    [TestMethod]
    public void AccessorCore_OverloadedMethod2()
    {
        var accessor = new OverloadAccessor2();
        AreEqual("60", () => accessor.MyPrivateMethod2(2, 3));
    }
    
    [TestMethod]
    public void AccessorCore_OverloadedMethod3()
    {
        var accessor = new OverloadAccessor3();
        AreEqual("150", () => accessor.MyPrivateMethod2(3, 5));
    }
}
