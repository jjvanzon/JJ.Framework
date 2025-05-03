using JJ.Framework.Testing.Core;

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
        int number = (int)accessor[1]!;
        AreEqual(1, number);
        
        // Set with indexer 
        accessor[1] = 2;
        AreEqual(2, accessor[1]);

        // Get with method
        number = (int)accessor.Get(3)!;
        AreEqual(3, number);

        // Set with method
        accessor.Set(3, 4);
        AreEqual(4, accessor[3]);
    }
    
    [TestMethod]
    public void AccessorCore_Indexer_UsingComposition()
    {
        var obj = new MyClass();
        var accessor = new MyAccessor(obj);
        
        // Get  
        int number = (int)accessor[1];
        AreEqual(1, number);
        
        // Set
        accessor[1] = 2;
        AreEqual(2, accessor[1]);
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
        
        public int this[object i]
        {
            get => (int)_accessor[i]!;
            set => _accessor[i] = value;
        }
    }

    private class MyClass_WithObjectArg
    {
        private Dictionary<object, int> _numberDic = CreateNumberDic();
        
        private int this[object i]
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
            () => { int number = accessor[null]; },
            "No indexer found with argument types [System.Object].");
    }
                
    [TestMethod]
    public void AccessorCore_Indexer_Overloads_Resolved_ByStackTraceInspection()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new MyAccessor_WithOverloads(obj);
        int? nully = null;
        
        string text = accessor[2, nully];
        
        AreEqual("", () => text);
    }

    private class MyAccessor_WithOverloads(MyClass_WithOverloads obj)
    {
        private readonly AccessorCore _accessor = new(obj);
        
        public int this[object i]
        {
            get => (int)_accessor[i]!;
            set => _accessor[i] = value;
        }
        
        public string this[int para1, int? para2]
        {
            get => (string)_accessor[para1, para2]!;
            set => _accessor[para1, para2] = value;
        }
        
        //public string this[int para1, string para2]
        //{
        //    get => (string)_accessor[para1, para2]!;
        //    set => _accessor[para1, para2] = value;
        //}
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
            get => default;
            set { }
        }

        private string this[int para1, int? para2] => (para1 * para2 * 10).ToString();
        private string this[int para1, string para2] => $"{para1 * 10}{para2}";
    }

    // Helpers

    static Dictionary<object, int> CreateNumberDic() => new()
    {
        [0] = Int32.MaxValue,
        [1] = 1, [2] = 2, [3] = 3, [4] = 4, [5]  = 5,
        [6] = 6, [7] = 7, [8] = 8, [9] = 9, [10] = 10
    };
}