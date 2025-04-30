namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests
{
    // Helper Classes
    
    private class MyClass : TheBaseClass
    {
        private string MyProperty { get; set; } = "10";
        private string MyPrivateMethod(int para) => "20";
        private string MyPrivateMethod2(int para1, int? para2) => "30";
    }
    
    private static class MyStaticClass;

    private class TheBaseClass
    {
        public int MyBaseProperty { get; set; }
    }
    
    private class MyAccessorBase
    {
        protected AccessorCore _accessor = new(new MyClass());
    }
    
    // Method Access

    private class MyAccessor_MethodCall_ByLambda : MyAccessorBase
    {
        public string MyPrivateMethod(int para) =>
            _accessor.InvokeMethod(() => MyPrivateMethod(para));
    }

    private class MyAccessor_MethodCall_ByCallerMemberName : MyAccessorBase
    {
        public string MyPrivateMethod(int para) =>
            (string)_accessor.InvokeMethod(para);
    }
    
    private class MyAccessor_MethodCall_ByName : MyAccessorBase
    {
        public string MyPrivateMethod(int para) =>
            (string)_accessor.InvokeMethod("MyPrivateMethod", 10);
    }

    // Property Access
    
    private class MyAccessor_Property_ByLambda : MyAccessorBase
    {
        public int MyProperty => _accessor.GetPropertyValue(() => MyProperty);
    }

    private class MyAccessor_Property_ByCallerMemberName : MyAccessorBase
    {
        public string MyProperty => (string)_accessor.GetPropertyValue();
    }
    
    private class MyAccessor_Property_ByCallerMemberName_WithTypeArgument : MyAccessorBase
    {
        public string MyProperty => _accessor.GetPropertyValue<string>();
    }
    
    private class MyAccessor_Property_ByName : MyAccessorBase
    {
        public string MyProperty => (string)_accessor.GetPropertyValue("MyProperty");
    }
    
    private class MyAccessor_Property_ByName_WithTypeArgument : MyAccessorBase
    {
        public string MyProperty => _accessor.GetPropertyValue<string>("MyProperty");
    }
    
    // Construction
    
    [TestMethod]
    public void AccessorCore_Construction_WithObject_Example()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore(myObject);
    }
    
    [TestMethod]
    public void AccessorCore_Construction_WithType_Example()
    {
        var accessor = new AccessorCore(typeof(MyStaticClass));
    }
    
    [TestMethod]
    public void AccessorCore_Construction_WithObjectAndType_Example()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore(myObject, typeof(TheBaseClass));
    }
    
    [TestMethod]
    public void AccessorCore_Construction_BaseAndDerived_Example()
    { 
        var myObject = new MyClass();
        var concreteAccessor = new AccessorCore(myObject);
        var baseAccessor = new AccessorCore(myObject, typeof(TheBaseClass));
    }
   
    [TestMethod]
    public void AccessorCore_Construction_WithTypeName_Example()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore($"{MyNamespace}.{MyPrivateClass}, {MyAssembly}");
    }
    
    string MyNamespace => GetType().Namespace; 
    string MyPrivateClass => GetType().Name;
    string MyAssembly => GetType().Assembly.GetName().Name;

    // Wrappers

    [TestMethod]
    public void AccessorCore_Wrapper_Example()
    {
        var accessor = new MyAccessor(new MyClass());
        string myString= accessor.MyPrivateMethod(1);
    }
    
    class MyAccessor(MyClass myObject)
    {
        AccessorCore _accessor = new(myObject);
        
        public string MyPrivateMethod(int para) 
            => (string)_accessor.InvokeMethod(para);
    }

    // Overloaded Methods

    class OverloadAccessor1 : MyAccessorBase
    {
        public int MyPrivateMethod(int? myParameter) =>
            (int)_accessor.InvokeMethod( [ myParameter ], [ typeof(int?) ] );
    }

    class OverloadAccessor2 : MyAccessorBase
    {
        public int MyPrivateMethod2(int? myParameter1, int myParameter2) =>
            (int)_accessor.InvokeMethod( [ myParameter1, myParameter2 ], [ null, typeof(int) ] );
    }

    class OverloadAccessor3 : MyAccessorBase
    {
        public string MyPrivateMethod2(object parameter, object parameter2) =>
            (string)_accessor.InvokeMethod<int, int?>("MyPrivateMethod2", parameter, parameter2);
    }
}
