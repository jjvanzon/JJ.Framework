// ReSharper disable RedundantArgumentDefaultValue
#pragma warning disable CS0169 // Field is never used

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_GetSet
{
    [TestMethod]
    public void AccessorCore_GetSet()
    {
        var obj = new MyClass();
        
        var accessors = new IMyAccessor[]
        {
            new Accessor_ByLambda(obj),
            new Accessor_WithCallerMemberName_AndTypeArg(obj),
            new Accessor_WithCallerMemberName_AndCast(obj),
            new Accessor_WithExplicitName_AndTypeArg(obj),
            new Accessor_WithExplicitName_AndCast(obj)
        };
        
        foreach (var accessor in accessors)
        {
            accessor.MyProperty1 = 10;
            AreEqual(10, () => accessor.MyProperty1);

            accessor.MyProperty2 = "Hello";
            AreEqual("Hello", () => accessor.MyProperty2);

            accessor._myField1 = true;
            IsTrue(() => accessor._myField1);

            accessor._myField2 = 20.5;
            AreEqual(20.5, () => accessor._myField2);
        }
    }
    
    [TestMethod]
    public void AccessorCore_GetSet_FieldOrPropertyNotFound_Exception()
    {
        var obj = new MyClass();
        var accessor = new AccessorCore(obj);
        
        ThrowsExceptionContaining(() => accessor.Get("DoesNotExist"    ), "Property or field", "DoesNotExist", "not found");
        ThrowsExceptionContaining(() => accessor.Set("DoesNotExist", 10), "Property or field", "DoesNotExist", "not found");
    }
    


    private class Accessor_ByLambda(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => Get(() => MyProperty1);
            set => Set(() => MyProperty1, value);
        }

        public string MyProperty2
        {
            get => Get(() => MyProperty2); 
            set => Set(() => MyProperty2, value);
        }

        public bool _myField1
        {
            get => Get(() => _myField1);
            set => Set(() => _myField1, value);
        }

        public double _myField2
        {
            get => Get(() => _myField2);
            set => Set(() => _myField2, value);
        }
    }
    
    private class Accessor_WithCallerMemberName_AndTypeArg(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => Get<int>()!;
            set => Set(value);
        }

        public string MyProperty2
        {
            get => Get<string>()!;
            set => Set(value);
        }

        public bool _myField1
        {
            get => Get<bool>()!;
            set => Set(value);
        }

        public double _myField2
        {
            get => Get<double>()!;
            set => Set(value);
        }
    }
    
    private class Accessor_WithCallerMemberName_AndCast(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => (int)Get()!;
            set => Set(value);
        }

        public string MyProperty2
        {
            get => (string)Get()!;
            set => Set(value);
        }

        public bool _myField1
        {
            get => (bool)Get()!;
            set => Set(value);
        }

        public double _myField2
        {
            get => (double)Get()!;
            set => Set(value);
        }
    }
        
    private class Accessor_WithExplicitName_AndTypeArg(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => Get<int>("MyProperty1");
            set => Set("MyProperty1", value);
        }
        
        public string MyProperty2
        {
            get => Get<string>("MyProperty2");
            set => Set("MyProperty2", value);
        }
        
        public bool _myField1
        {
            get => Get<bool>("_myField1");
            set => Set("_myField1", value);
        }
        
        public double _myField2
        {
            get => Get<double>("_myField2");
            set => Set("_myField2", value);
        }
    }
        
    private class Accessor_WithExplicitName_AndCast(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => (int)Get("MyProperty1")!;
            set => Set("MyProperty1", value);
        }
        
        public string MyProperty2
        {
            get => (string)Get("MyProperty2")!;
            set => Set("MyProperty2", value);
        }
        
        public bool _myField1
        {
            get => (bool)Get("_myField1")!;
            set => Set("_myField1", value);
        }
        
        public double _myField2
        {
            get => (double)Get("_myField2")!;
            set => Set("_myField2", value);
        }
    }

    private class MyClass
    {
        private int MyProperty1 { get; set; }
        private string MyProperty2 { get; set; }
        private bool _myField1;
        private double _myField2;
    }

    private interface IMyAccessor
    {
        int MyProperty1 { get; set; }
        string MyProperty2 { get; set; }
        bool _myField1 { get; set; }
        double _myField2 { get; set; }
    }
}