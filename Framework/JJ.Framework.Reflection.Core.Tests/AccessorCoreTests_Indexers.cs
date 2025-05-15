namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_Indexers
{
    // Regular Cases
    
    [TestMethod]
    public void AccessorCore_Indexer_RawAccessor()
    {
        var obj = new MyClass();
        var accessor = new AccessorCore(obj);
        
        // Get with indexer 
        var number = (int?)accessor[1];
        AreEqual(1, () => number);
        
        // Set with indexer 
        accessor[1] = 2;
        AreEqual(2, accessor[1]);

        // Get with method
        number = (int?)accessor.Get(3);
        AreEqual(3, () => number);

        // Set with method
        accessor.Set(3, 4);
        AreEqual(4, accessor[3]);

        // Get with collection
        number = (int?)accessor.Get([4]);
        AreEqual(4, () => number);

        // Set with collection
        accessor.Set([4], 5);
        AreEqual(5, accessor[4]);
    }
    
    [TestMethod]
    public void AccessorCore_Indexer_WrapperAccessor()
    {
        var obj = new MyClass();
        var myAccessor = new MyAccessor(obj);
        
        // Get  
        int number = (int)myAccessor[1];
        AreEqual(1, number);
        
        // Set
        myAccessor[1] = 2;
        AreEqual(2, myAccessor[1]);
    }
        
    private class MyAccessor(MyClass obj)
    {
        private readonly AccessorCore _accessor = new(obj);
        
        public int this[object i]
        {
            get => (int)_accessor[i]!;
            set => _accessor[i] = value;
        }
    }

    private class MyClass
    {
        private Dictionary<object, int> _numberDic = CreateNumberDic();

        private int this[int i]
        {
            get => _numberDic[i ];
            set => _numberDic[i] = value;
        }
    }

    // With Object / Null Arg
    
    [TestMethod]
    public void AccessorCore_Indexer_NullInput()
    {
        var obj = new MyClass_WithObjectArg();
        var accessor = new MyAccessor_WithObjectArg(obj);
        
        // Get  
        int number = (int)accessor[null];
        AreEqual(Int32.MaxValue, number);
        
        // Set
        accessor[null] = 5;
        AreEqual(5, accessor[null]);
    }
    
    private class MyAccessor_WithObjectArg(MyClass_WithObjectArg obj)
    {
        private readonly AccessorCore _accessor = new(obj);
        
        public int this[object? i]
        {
            get => (int)_accessor[i]!;
            set => _accessor[i] = value;
        }
    }

    private class MyClass_WithObjectArg
    {
        private Dictionary<object, int> _numberDic = CreateNumberDic();
        
        private int this[object? i]
        {
            get => _numberDic[i ?? 0];
            set => _numberDic[i ?? 0] = value;
        }
    }
    
    // With Overloads
    
    [TestMethod]
    public void AccessorCore_Indexer_Overloads_NotFound()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new MyAccessor_WithOverloads(obj);
        
        ThrowsException(
            () => { int number = accessor [ null]; },
            "No indexer found with argument types [Object].");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromStackFrame()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new MyAccessor_WithOverloads(obj);

        // With null int
        {
            int? nullNum = null;
            string text = accessor[2, nullNum];
            AreEqual("", () => text);
        }
        // With nullable int
        {
            int? nullyNum = 3;
            string text = accessor[4, nullyNum];
            AreEqual("120", () => text);
        }
        // With int
        {
            string text = accessor[5, 6];
            AreEqual("300", () => text);
        }
        // With null string
        {
            #pragma warning disable CS8604 // null ref arg
            
            string? input = null;
            string text = accessor[7, input];
            AreEqual("70", () => text);
            
            #pragma warning restore CS8604 // null ref arg
        }
        // With nullable string
        {
            // ReSharper disable once VariableCanBeNotNullable
            string? input = "test";
            string text = accessor[9, input];
            AreEqual("90test", () => text);
        }
        // With string
        {
            string text = accessor[10, "test"];
            AreEqual("100test", () => text);
        }
    }
                    
    // TODO: Resolved with Type Args
    
    // TODO: Test the setters

    private class MyAccessor_WithOverloads(MyClass_WithOverloads obj)
    {
        private readonly AccessorCore _accessor = new(obj);
        
        public int this[object? i]
        {
            get => (int)_accessor[i]!;
            set => _accessor[i] = value;
        }
        
        public string this[int para1, int? para2]
        {
            get => (string)_accessor[para1, para2]!;
            set => _accessor[para1, para2] = value;
        }
        
        public string this[int para1, string? para2]
        {
            get => (string)_accessor[para1, para2]!;
            set => _accessor[para1, para2] = value;
        }
    }

    private class MyClass_WithOverloads
    {
        private Dictionary<object, int> _numberDic = CreateNumberDic();

        private int this[int i]
        {
            get => _numberDic[i];
            set => _numberDic[i] = value;
        }

        private string this[string i]
        {
            get => "";
            set { }
        }

        private string this[int para1, int? para2] => $"{10 * para1 * para2}";
        private string this[int para1, string? para2] => $"{para1 * 10}{para2}";
    }

    // Helpers

    // TODO: Use inverse digits instead, for variance between index and value.
    
    static Dictionary<object, int> CreateNumberDic() => new()
    {
        [0] = Int32.MaxValue,
        [1] = 1, [2] = 2, [3] = 3, [4] = 4, [5]  = 5,
        [6] = 6, [7] = 7, [8] = 8, [9] = 9, [10] = 10
    };
}