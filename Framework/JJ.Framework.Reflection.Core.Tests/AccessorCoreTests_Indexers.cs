using JJ.Framework.Testing.Core;
using static JJ.Framework.Existence.Core.FilledInHelper;

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
        AreEqual(1, (int?)accessor[1]);
        
        // Set with indexer 
        accessor[1] = 2;
        AreEqual(2, accessor[1]);

        // Get with method
        AreEqual(3, (int?)accessor.Get(3));

        // Set with method
        accessor.Set(3, 4);
        AreEqual(4, accessor[3]);

        // Get with collection
        AreEqual(4, (int?)accessor.Get([4]));

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
        AreEqual(Int32.MaxValue, (int)accessor[null]);
        
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
            () => { int number = accessor[null]; },
            "No indexer found with argument types [Object].");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromStackFrame()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new MyAccessor_WithOverloads(obj);

        // With int
        AreEqual("60",  accessor[2, 3]);
        AreEqual("60*", accessor[2, 3] += "*");
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200",  accessor[5, nullableNum]);
        AreEqual("200*", accessor[5, nullableNum] += "*");
        
        // With null int
        int? nullNum = null;
        AreEqual("", accessor[6, nullNum]);
        // TODO: Should have been resolved from stack frame.
        //AreEqual("*", accessor[ 6, nullNum] += "*");
        
        // With string
        AreEqual("70test",  accessor[7, "test"]);
        AreEqual("70test*", accessor[7, "test"] += "*");
        
        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test",  accessor[8, nullableText]);
        AreEqual("80test*", accessor[8, nullableText] += "*");
        
        // With null string
        string? nullText = null;
        AreEqual("90",  accessor[9, nullText]);
        // TODO: Should have been resolved from stack frame.
        //AreEqual("90*", accessor[9, nullText] += "*");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromValues()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);

        // With int
        AreEqual("60",  accessor[2, 3]);
        AreEqual("60*", accessor[2, 3] += "*");
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200",  accessor[5, nullableNum]);
        AreEqual("200*", accessor[5, nullableNum] += "*");
        
        // With null int
        // (resolution not possible)
        int? nullNum = null;
        ThrowsExceptionContaining(() => accessor[6, nullNum],       "No indexer found");
        ThrowsExceptionContaining(() => accessor[6, nullNum] = "*", "No indexer found");
        
        // With string
        AreEqual("70test",  accessor[7, "test"]);
        AreEqual("70test*", accessor[7, "test"] += "*");
        
        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test",  accessor[8, nullableText]);
        AreEqual("80test*", accessor[8, nullableText] += "*");
        
        // With null string
        // (resolution not possible)
        string? nullText = null;
        ThrowsExceptionContaining(() => accessor[9, nullText], "No indexer found");
        ThrowsExceptionContaining(() => accessor[9, nullText] = "*", "No indexer found");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromValueColl()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);

        // With int
        AreEqual("60", accessor.Get([ 2, 3 ]));
        accessor.Set([ 2, 3 ], "60*");
        AreEqual("60*", accessor.Get([ 2, 3 ]));
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200", accessor.Get([ 5, nullableNum ]));
        accessor.Set([ 5, nullableNum ], "200*");
        AreEqual("200*", accessor.Get([ 5, nullableNum ]));
            
        // With null int
        // (resolution not possible)
        int? nullNum = null;
        ThrowsExceptionContaining(() => accessor.Get([ 6, nullNum ]     ), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 6, nullNum ], "*"), "No indexer found");

        // With string
        AreEqual("70test", accessor.Get([ 7, "test" ]));
        accessor.Set([ 7, "test" ], "70test*");
        AreEqual("70test*", accessor.Get([ 7, "test" ]));
        
        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test", accessor.Get([ 8, nullableText ]));
        accessor.Set([ 8, nullableText ], "80test*");
        AreEqual("80test*", accessor.Get([ 8, nullableText ]));
        
        // With null string
        // (resolution not possible)
        string? nullText = null;
        ThrowsExceptionContaining(() => accessor.Get([ 9, nullText ]     ), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 9, nullText ], "*"), "No indexer found");
    }
                    
    // TODO: Setters

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromArgTypeColl()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);
        
        // With int
        AreEqual("60", accessor.Get([ 2, 3 ], [ typeof(int), typeof(int?) ]));
        AreEqual("60", accessor.Get([ 2, 3 ], [ null, typeof(int?) ]));
        
        // No ambiguity: arg type spec optional
        AreEqual("60", accessor.Get([ 2, 3 ], [ ]));
        AreEqual("60", accessor.Get([ 2, 3 ], [ null ]));
        AreEqual("60", accessor.Get([ 2, 3 ], [ null, null ]));
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200", accessor.Get([ 5, nullableNum ], [ typeof(int), typeof(int?) ]));
        AreEqual("200", accessor.Get([ 5, nullableNum ], [ null, typeof(int?) ]));
        
        // No ambiguity: arg type spec optional
        AreEqual("200", accessor.Get([ 5, nullableNum ], [ ]));
        AreEqual("200", accessor.Get([ 5, nullableNum ], [ null ]));
        AreEqual("200", accessor.Get([ 5, nullableNum ], [ null, null ]));
        
        // With null int
        int? nullNum = null;
        AreEqual("", accessor.Get([ 6, nullNum ], [ typeof(int), typeof(int?) ]));
        AreEqual("", accessor.Get([ 6, nullNum ], [ null, typeof(int?) ]));
        
        // Ambiguity: exceptions
        ThrowsExceptionContaining(() => accessor.Get([ 6, nullNum ], [ ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 6, nullNum ], [ null ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 6, nullNum ], [ null, null ]), "No indexer found");

        // With string
        AreEqual("70test", accessor.Get([ 7, "test" ], [ typeof(int), typeof(string) ]));
        AreEqual("70test", accessor.Get([ 7, "test" ], [ null, typeof(string) ]));
        
        // No ambiguity: arg type spec optional
        AreEqual("70test", accessor.Get([ 7, "test" ], [ ]));
        AreEqual("70test", accessor.Get([ 7, "test" ], [ null ]));
        AreEqual("70test", accessor.Get([ 7, "test" ], [ null, null ]));

        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test", accessor.Get([ 8, nullableText ], [ typeof(int), typeof(string) ]));
        AreEqual("80test", accessor.Get([ 8, nullableText ], [ null, typeof(string) ]));

        // No ambiguity: arg type spec optional
        AreEqual("80test", accessor.Get([ 8, nullableText ], [ ]));
        AreEqual("80test", accessor.Get([ 8, nullableText ], [ null ]));
        AreEqual("80test", accessor.Get([ 8, nullableText ], [ null, null ]));
        
        // With null string
        string? nullText = null;
        AreEqual("80", accessor.Get([ 8, nullText ], [ typeof(int), typeof(string) ]));
        AreEqual("80", accessor.Get([ 8, nullText ], [ null, typeof(string) ]));

        // Ambiguity: exceptions
        ThrowsExceptionContaining(() => accessor.Get([ 8, nullText ], [ ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 8, nullText ], [ null ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 8, nullText ], [ null, null ]), "No indexer found");

    }
        
    [TestMethod]
    public void AccessorCore_Indexer_Overload_NotResolved_Exception()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);

        // With int
        
        // Too many argTypes
        ThrowsException(() => accessor.Get([ 2, 3 ], [ null, null, null ]), "More argTypes than args.");
        
        // TODO: Really expected an exception.
        Type nonNullType = typeof(int);
        //ThrowsException(
        //    () => (string)accessor.Get([ 2, nullNum ], [ typeof(int), nonNullType ]),
        //    "No indexer found with argument types [Int32, Int32].");
    }
    
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

        private Dictionary<(int, int?), string> _numNullyNumDic = new();
        
        private string this[int arg1, int? arg2]
        {
            get
            {
                _numNullyNumDic.TryGetValue((arg1, arg2), out string? val);
                if (Has(val)) 
                { 
                    return val!;
                }
                
                return $"{10 * arg1 * arg2}";
            }
            set => _numNullyNumDic[(arg1, arg2)] = value;
        }
        
        private Dictionary<(int, string?), string> _numNullyTextDic = new();

        private string this[int arg1, string? arg2]
        {
            get
            {
                _numNullyTextDic.TryGetValue((arg1, arg2), out string? val);
                if (Has(val)) 
                { 
                    return val!;
                }
                
                return $"{10 * arg1}{arg2}";
            }
            set => _numNullyTextDic[(arg1, arg2)] = value;
        }
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