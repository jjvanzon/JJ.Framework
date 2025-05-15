// ReSharper disable RedundantArgumentDefaultValue
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_Examples
{
    // Helper Classes
    
    private class MyClass : TheBaseClass
    {
        private string MyProperty { get; set; } = "10";
        private string MyMethod(int para) => $"{para * 10}";
        private string MyMethod2(int para1, int? para2) => $"{10 * para1 * para2}";
        private string MyMethod3(int para1, string para2) => $"{10 * para1}{para2}";
    }
    
    private static class MyStaticClass;

    private class TheBaseClass
    {
        public int MyBaseProperty { get; set; }
    }
    
    private class TestAccessorBase
    {
        protected AccessorCore _accessor = new(typeof(MyClass));
    }
    
    // Method Access

    private class TestAccessor_Call_ByLambda : TestAccessorBase
    {
        public string MyMethod(int para) =>
            _accessor.Call(() => MyMethod(para))!;
    }

    private class TestAccessor_Call_ByCallerMemberName : TestAccessorBase
    {
        public string MyMethod(int para) =>
            (string)_accessor.Call(para)!;
    }
    
    private class TestAccessor_Call_ByName : TestAccessorBase
    {
        public string MyMethod() =>
            (string)_accessor.Call("MyMethod", 10)!;
    }
            
    [TestMethod]
    public void Accessor_Call_ByLambda()
    {
        var accessor = new TestAccessor_Call_ByLambda();
        AreEqual("10", () => accessor.MyMethod(1));
    }

    [TestMethod]
    public void Accessor_Call_ByCallerMemberName()
    {
        var accessor = new TestAccessor_Call_ByCallerMemberName();
        AreEqual("20", () => accessor.MyMethod(2));
    }

    [TestMethod]
    public void Accessor_Call_ByName()
    {
        var    accessor = new TestAccessor_Call_ByName();
        string result = accessor.MyMethod();
    }

    // Property Access
    
    private class MyAccessor_Property_ByLambda : TestAccessorBase
    {
        public string MyProperty => _accessor.Get(() => MyProperty)!;
    }

    private class MyAccessor_Property_ByCallerMemberName : TestAccessorBase
    {
        public string MyProperty => (string)_accessor.Get()!;
    }
    
    private class MyAccessor_Property_ByCallerMemberName_UsingTypeArgument : TestAccessorBase
    {
        public string MyProperty => _accessor.Get<string>()!;
    }
    
    private class MyAccessor_Property_ByName : TestAccessorBase
    {
        public string MyProperty => (string)_accessor.Get("MyProperty")!;
    }
    
    private class MyAccessor_Property_ByName_UsingTypeArgument : TestAccessorBase
    {
        public string MyProperty => _accessor.Get<string>("MyProperty")!;
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
        var accessor = new MyAccessor_Property_ByCallerMemberName_UsingTypeArgument();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void Accessor_Property_ByName()
    {
        var accessor = new MyAccessor_Property_ByName();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    [TestMethod]
    public void Accessor_Property_ByName_WithTypeArgument()
    {
        var accessor = new MyAccessor_Property_ByName_UsingTypeArgument();
        AreEqual("10", () => accessor.MyProperty);
    }
    
    // Construction
    
    [TestMethod]
    public void Accessor_Construction_WithObject()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore(myObject);
    }
    
    [TestMethod]
    public void Accessor_Construction_WithType()
    {
        var accessor = new AccessorCore(typeof(MyStaticClass));
    }
   
    [TestMethod]
    public void Accessor_Construction_WithTypeName()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore($"{MyPrivateClass}");
    }
    
    string MyPrivateClass => GetType().Name;

    // Wrappers
    
    class MyAccessor(MyClass myObject)
    {
        AccessorCore _accessor = new(myObject);
        
        public string MyMethod(int para) 
            => (string)_accessor.Call(para)!;
    }

    [TestMethod]
    public void Accessor_Wrapper()
    {
        var accessor = new MyAccessor(new MyClass());
        string myString = accessor.MyMethod(10);
        AreEqual("100", () => myString);
    }

    // Overloaded Methods
    
    class OverloadAccessor1 : TestAccessorBase
    {
        public string MyMethod2(int para1, int? para2) =>
            (string)_accessor.Call(para1, para2)!;
    }

    class OverloadAccessor2 : TestAccessorBase
    {
        public string MyMethod(int para) =>
            (string)_accessor.Call([ para ], [ typeof(int) ])!;
    }

    class OverloadAccessor3 : TestAccessorBase
    {
        public string MyMethod2(int para1, int? para2) =>
            (string)_accessor.Call([ para1, para2 ], [ null, typeof(int?) ])!;
    }

    class OverloadAccessor4 : TestAccessorBase
    {
        public string MyMethod2(int para1, int? para2) =>
            (string)_accessor.Call(para1, para2)!;
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod1()
    {
        var accessor = new OverloadAccessor1();
        AreEqual("60", () => accessor.MyMethod2(2, 3));
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod2()
    {
        var accessor = new OverloadAccessor2();
        AreEqual("10", () => accessor.MyMethod(1));
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod3()
    {
        var accessor = new OverloadAccessor3();
        AreEqual("350", () => accessor.MyMethod2(5, 7));
    }
    
    [TestMethod]
    public void Accessor_OverloadedMethod4()
    {
        var accessor = new OverloadAccessor4();
        AreEqual("", () => accessor.MyMethod2(5, null));
    }
    
    // Ref Args
    
    [TestMethod]
    public void AccessorCore_RefArg()
    {
        var obj = new MyClassWithRef();
        var accessor = new MyAccessorWithRef(obj);
        
        int num = 14;
        bool isEven = accessor.MyMethod(ref num);
        
        IsTrue(() => isEven);
        AreEqual(15, () => num);
    }
    
    private class MyAccessorWithRef(MyClassWithRef obj) : AccessorCore(obj)
    {
        public bool MyMethod(ref int num) => (bool)Call(ref num)!;
    }
    
    private class MyClassWithRef
    {
        private bool MyMethod(ref int num)
        {
            bool isEven = num % 2 == 0;
            num++;
            return isEven;
        }
    }
}
