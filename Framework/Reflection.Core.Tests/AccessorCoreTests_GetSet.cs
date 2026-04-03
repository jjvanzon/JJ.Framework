// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ExplicitCallerInfoArgument
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
            new Accessor_WithCallerMemberName_AndTypeArg_WithInheritance(obj),
            new Accessor_WithCallerMemberName_AndTypeArg_WithComposition(obj),
            new Accessor_WithCallerMemberName_AndCast_WithInheritance(obj),
            new Accessor_WithCallerMemberName_AndCast_WithComposition(obj),
            new Accessor_ByLambda_WithInheritance(obj),
            new Accessor_ByLambda_WithComposition(obj),
            new Accessor_WithExplicitName_AndTypeArg_WithInheritance(obj),
            new Accessor_WithExplicitName_AndTypeArg_WithComposition(obj),
            new Accessor_WithExplicitName_AndCast_WithInheritance(obj),
            new Accessor_WithExplicitName_AndCast_WithComposition(obj)
        };
        
        int i;
        bool flag = true;
        
        for (i = 0; i < accessors.Length; i++)
        {
            var accessor = accessors[i];

            accessor.MyProperty1 = 10 + i;
            AreEqual(10 + i, accessor.MyProperty1);
            
            accessor.MyProperty2 = "Hello" + i;
            AreEqual("Hello" + i, accessor.MyProperty2);
            
            accessor._myField1 = 20.5 + i;
            AreEqual(20.5 + i, accessor._myField1);
            
            accessor._myField2 = flag;
            AreEqual(flag, accessor._myField2);
            
            flag = !flag;
        }

        // Without Wrapper, By Name
        {
            var accessor = new AccessorCore(obj);
            
            accessor.Set("MyProperty1", 10 + i);
            AreEqual(10 + i, accessor.Get("MyProperty1"));
            
            accessor.Set("MyProperty2", "Hello" + i);
            AreEqual("Hello" + i, accessor.Get("MyProperty2"));
            
            accessor.Set("_myField1", 20.5 + i);
            AreEqual(20.5 + i, accessor.Get("_myField1"));
            
            accessor.Set("_myField2", flag);
            AreEqual(flag, accessor.Get("_myField2"));
            
            flag = !flag;
            i++;
        }
        // Without Wrapper, By Name with Type Arg
        {
            var accessor = new AccessorCore(obj);
            
            accessor.Set("MyProperty1", 10 + i);
            AreEqual(10 + i, accessor.Get<int>("MyProperty1"));
            
            accessor.Set("MyProperty2", "Hello" + i);
            AreEqual("Hello" + i, accessor.Get<string>("MyProperty2"));
            
            accessor.Set("_myField1", 20.5 + i);
            AreEqual(20.5 + i, accessor.Get<double>("_myField1"));
            
            accessor.Set("_myField2", flag);
            AreEqual(flag, accessor.Get<bool>("_myField2"));
            
            flag = !flag;
            i++;
        }
        // Without Wrapper, By Name with Cast
        {
            var accessor = new AccessorCore(obj);
            
            accessor.Set("MyProperty1", 10 + i);
            AreEqual(10 + i, (int)accessor.Get("MyProperty1")!);
            
            accessor.Set("MyProperty2", "Hello" + i);
            AreEqual("Hello" + i, (string)accessor.Get("MyProperty2")!);
            
            accessor.Set("_myField1", 20.5 + i);
            AreEqual(20.5 + i, (double)accessor.Get("_myField1")!);
            
            accessor.Set("_myField2", flag);
            AreEqual(flag, (bool)accessor.Get("_myField2")!);
            
            flag = !flag;
            i++;
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
    
    private class Accessor_WithCallerMemberName_AndTypeArg_WithInheritance(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => Get<int>();
            set => Set(value);
        }

        public string MyProperty2
        {
            get => Get<string>()!;
            set => Set(value);
        }

        public double _myField1
        {
            get => Get<double>();
            set => Set(value);
        }

        public bool _myField2
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
    
    private class Accessor_WithCallerMemberName_AndCast_WithInheritance(MyClass obj) : AccessorCore(obj), IMyAccessor
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

        public double _myField1
        {
            get => (double)Get()!;
            set => Set(value);
        }

        public bool _myField2
        {
            get => (bool)Get()!;
            set => Set(value);
        }
    }
     
    private class Accessor_ByLambda_WithInheritance(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => Get(() => MyProperty1);
            set => Set(() => MyProperty1, value);
        }

        public string MyProperty2
        {
            get => Get(() => MyProperty2)!; 
            set => Set(() => MyProperty2, value);
        }

        public double _myField1
        {
            get => Get(() => _myField1);
            set => Set(() => _myField1, value);
        }

        public bool _myField2
        {
            get => Get(() => _myField2);
            set => Set(() => _myField2, value);
        }
    }
   
    private class Accessor_WithExplicitName_AndTypeArg_WithInheritance(MyClass obj) : AccessorCore(obj), IMyAccessor
    {
        public int MyProperty1
        {
            get => Get<int>("MyProperty1");
            set => Set("MyProperty1", value);
        }
        
        public string MyProperty2
        {
            get => Get<string>("MyProperty2")!;
            set => Set("MyProperty2", value);
        }
        
        public double _myField1
        {
            get => Get<double>("_myField1");
            set => Set("_myField1", value);
        }
        
        public bool _myField2
        {
            get => Get<bool>("_myField2");
            set => Set("_myField2", value);
        }
    }
        
    private class Accessor_WithExplicitName_AndCast_WithInheritance(MyClass obj) : AccessorCore(obj), IMyAccessor
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
        
        public double _myField1
        {
            get => (double)Get("_myField1")!;
            set => Set("_myField1", value);
        }
        
        public bool _myField2
        {
            get => (bool)Get("_myField2")!;
            set => Set("_myField2", value);
        }
    }
    
    private class Accessor_WithCallerMemberName_AndTypeArg_WithComposition(MyClass obj) : IMyAccessor
    {
        private AccessorCore _accessor = new(obj);
        
        public int MyProperty1
        {
            get => _accessor.Get<int>();
            set => _accessor.Set(value);
        }

        public string MyProperty2
        {
            get => _accessor.Get<string>()!;
            set => _accessor.Set(value);
        }

        public double _myField1
        {
            get => _accessor.Get<double>();
            set => _accessor.Set(value);
        }

        public bool _myField2
        {
            get => _accessor.Get<bool>();
            set => _accessor.Set(value);
        }
    }
        
    private class Accessor_WithCallerMemberName_AndCast_WithComposition(MyClass obj) : IMyAccessor
    {
        private AccessorCore _accessor = new(obj);
        
        public int MyProperty1
        {
            get => (int)_accessor.Get()!;
            set => _accessor.Set(value);
        }

        public string MyProperty2
        {
            get => (string)_accessor.Get()!;
            set => _accessor.Set(value);
        }

        public double _myField1
        {
            get => (double)_accessor.Get()!;
            set => _accessor.Set(value);
        }

        public bool _myField2
        {
            get => (bool)_accessor.Get()!;
            set => _accessor.Set(value);
        }
    }
     
    private class Accessor_ByLambda_WithComposition(MyClass obj) : IMyAccessor
    {
        private AccessorCore _accessor = new(obj);
        
        public int MyProperty1
        {
            get => _accessor.Get(() => MyProperty1);
            set => _accessor.Set(() => MyProperty1, value);
        }

        public string MyProperty2
        {
            get => _accessor.Get(() => MyProperty2)!; 
            set => _accessor.Set(() => MyProperty2, value);
        }

        public double _myField1
        {
            get => _accessor.Get(() => _myField1);
            set => _accessor.Set(() => _myField1, value);
        }

        public bool _myField2
        {
            get => _accessor.Get(() => _myField2);
            set => _accessor.Set(() => _myField2, value);
        }
    }
       
    private class Accessor_WithExplicitName_AndTypeArg_WithComposition(MyClass obj) : IMyAccessor
    {
        private AccessorCore _accessor = new(obj);
        
        public int MyProperty1
        {
            get => _accessor.Get<int>("MyProperty1");
            set => _accessor.Set("MyProperty1", value);
        }
        
        public string MyProperty2
        {
            get => _accessor.Get<string>("MyProperty2")!;
            set => _accessor.Set("MyProperty2", value);
        }
        
        public double _myField1
        {
            get => _accessor.Get<double>("_myField1");
            set => _accessor.Set("_myField1", value);
        }
        
        public bool _myField2
        {
            get => _accessor.Get<bool>("_myField2");
            set => _accessor.Set("_myField2", value);
        }
    }
        
    private class Accessor_WithExplicitName_AndCast_WithComposition(MyClass obj) : IMyAccessor
    {
        private AccessorCore _accessor = new(obj);

        public int MyProperty1
        {
            get => (int)_accessor.Get("MyProperty1")!;
            set => _accessor.Set("MyProperty1", value);
        }
        
        public string MyProperty2
        {
            get => (string)_accessor.Get("MyProperty2")!;
            set => _accessor.Set("MyProperty2", value);
        }
        
        public double _myField1
        {
            get => (double)_accessor.Get("_myField1")!;
            set => _accessor.Set("_myField1", value);
        }
        
        public bool _myField2
        {
            get => (bool)_accessor.Get("_myField2")!;
            set => _accessor.Set("_myField2", value);
        }
    }
    
    private class MyClass
    {
        private int MyProperty1 { get; set; }
        private string MyProperty2 { get; set; } = "";
        private double _myField1;
        private bool _myField2;
    }

    private interface IMyAccessor
    {
        int MyProperty1 { get; set; }
        string MyProperty2 { get; set; }
        double _myField1 { get; set; }
        bool _myField2 { get; set; }
    }
}