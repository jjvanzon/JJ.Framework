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
        AreEqual(9, accessor[1]);
        
        // Set with indexer 
        accessor[1] = 90;
        AreEqual(90, accessor[1]);

        // Get with method
        AreEqual(7, accessor.Get(3));

        // Set with method
        accessor.Set(3, 70);
        AreEqual(70, accessor[3]);

        // Get with collection
        AreEqual(6, accessor.Get([4]));

        // Set with collection
        accessor.Set([4], 60);
        AreEqual(60, accessor[4]);
    }
    
    [TestMethod]
    public void AccessorCore_Indexer_WrapperAccessor()
    {
        var obj = new MyClass();
        var myAccessor = new MyAccessor(obj);
        
        // Get  
        AreEqual(9, myAccessor[1]);
        
        // Set
        myAccessor[1] = 90;
        AreEqual(90, myAccessor[1]);
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
        private Dictionary<object, int> _invertedDigitDic = CreateInvertedDigitDic();

        private int this[int i]
        {
            get => _invertedDigitDic[i];
            set => _invertedDigitDic[i] = value;
        }
    }

    // With Object / Null Arg
    
    [TestMethod]
    public void AccessorCore_Indexer_NullInput()
    {
        var obj = new MyClass_WithObjectArg();
        var accessor = new MyAccessor_WithObjectArg(obj);
        
        // Get  
        AreEqual(-1, accessor[null]);
        
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
        private Dictionary<object, int> _invertedDigitDic = CreateInvertedDigitDic();
        
        private int this[object? i]
        {
            get => _invertedDigitDic[i ?? -1];
            set => _invertedDigitDic[i ?? -1] = value;
        }
    }
    
    // With Overloads
    
    [TestMethod]
    public void AccessorCore_Indexer_Overloads_NotFound()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new MyAccessor_WithOverloads(obj);
        
        ThrowsExceptionContaining(
            () => { int number = accessor[null]; },
            "No indexer found");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromStackFrame()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new MyAccessor_WithOverloads(obj);

        // With int
        AreEqual("60" , accessor[2, 3]);
        AreEqual("60*", accessor[2, 3] += "*");
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200" , accessor[5, nullableNum]);
        AreEqual("200*", accessor[5, nullableNum] += "*");
        
        // With null int
        int? nullNum = null;
        AreEqual("", accessor[6, nullNum]);
        // TODO: Should have been resolved from stack frame.
        //AreEqual("*", accessor[ 6, nullNum] += "*");
        
        // With string
        AreEqual("70test" , accessor[7, "test"]);
        AreEqual("70test*", accessor[7, "test"] += "*");
        
        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test" , accessor[8, nullableText]);
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
        AreEqual("60" , accessor[2, 3]);
        AreEqual("60*", accessor[2, 3] += "*");
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200" , accessor[5, nullableNum]);
        AreEqual("200*", accessor[5, nullableNum] += "*");
        
        // With null int
        // (resolution not possible)
        int? nullNum = null;
        ThrowsExceptionContaining(() => accessor[6, nullNum]      , "No indexer found");
        ThrowsExceptionContaining(() => accessor[6, nullNum] = "*", "No indexer found");
        
        // With string
        AreEqual("70test" , accessor[7, "test"]);
        AreEqual("70test*", accessor[7, "test"] += "*");
        
        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test" , accessor[8, nullableText]);
        AreEqual("80test*", accessor[8, nullableText] += "*");
        
        // With null string
        // (resolution not possible)
        string? nullText = null;
        ThrowsExceptionContaining(() => accessor[9, nullText]      , "No indexer found");
        ThrowsExceptionContaining(() => accessor[9, nullText] = "*", "No indexer found");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromValueColl()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);

        // With int
        AreEqual("60" , accessor.Get([ 2, 3 ])); accessor.Set([ 2, 3 ], "60*");
        AreEqual("60*", accessor.Get([ 2, 3 ]));
        
        // With nullable int
        int? nullableNum = 4;
        AreEqual("200" , accessor.Get([ 5, nullableNum ])); accessor.Set([ 5, nullableNum ], "200*");
        AreEqual("200*", accessor.Get([ 5, nullableNum ]));
            
        // With null int
        // (resolution not possible)
        int? nullNum = null;
        ThrowsExceptionContaining(() => accessor.Get([ 6, nullNum ]     ), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 6, nullNum ], "*"), "No indexer found");

        // With string
        AreEqual("70test" , accessor.Get([ 7, "test" ])); accessor.Set([ 7, "test" ], "70test*");
        AreEqual("70test*", accessor.Get([ 7, "test" ]));
        
        // With nullable string
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("80test" , accessor.Get([ 8, nullableText ])); accessor.Set([ 8, nullableText ], "80test*");
        AreEqual("80test*", accessor.Get([ 8, nullableText ]));
        
        // With null string
        // (resolution not possible)
        string? nullText = null;
        ThrowsExceptionContaining(() => accessor.Get([ 9, nullText ]     ), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 9, nullText ], "*"), "No indexer found");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_ResolvedFromArgTypeColl()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);
        
        // With int
        // (no ambiguity from values; arg type optional)
        AreEqual("60"  , accessor.Get([ 2, 3 ], [ typeof(int), typeof(int?) ])); accessor.Set([ 2, 3 ], "60*" , [ typeof(int), typeof(int?) ]);
        AreEqual("60*" , accessor.Get([ 2, 3 ], [ typeof(int), typeof(int?) ]));
        AreEqual("80"  , accessor.Get([ 2, 4 ], [ null,        typeof(int?) ])); accessor.Set([ 2, 4 ], "80*" , [ null, typeof(int?) ]);
        AreEqual("80*" , accessor.Get([ 2, 4 ], [ null,        typeof(int?) ]));
        AreEqual("100" , accessor.Get([ 2, 5 ], [ null,        null         ])); accessor.Set([ 2, 5 ], "100*", [ null, null ]);
        AreEqual("100*", accessor.Get([ 2, 5 ], [ null,        null         ]));
        AreEqual("120" , accessor.Get([ 2, 6 ], [ null                      ])); accessor.Set([ 2, 6 ], "120*", [ null ]);
        AreEqual("120*", accessor.Get([ 2, 6 ], [ null                      ]));
        AreEqual("140" , accessor.Get([ 2, 7 ], [                           ])); accessor.Set([ 2, 7 ], "140*", [ ]);
        AreEqual("140*", accessor.Get([ 2, 7 ], [                           ]));
       
        // With nullable int
        // (No ambiguity from values: arg type spec optional)
        int? nullable4 = 4;
        AreEqual("120" , accessor.Get([ 3, nullable4 ], [ typeof(int), typeof(int?) ])); accessor.Set([ 3, nullable4 ], "120*", [ typeof(int), typeof(int?) ]);
        AreEqual("120*", accessor.Get([ 3, nullable4 ], [ typeof(int), typeof(int?) ])); 
        AreEqual("160" , accessor.Get([ 4, nullable4 ], [ null       , typeof(int?) ])); accessor.Set([ 4, nullable4 ], "160*", [ null, typeof(int?) ]);
        AreEqual("160*", accessor.Get([ 4, nullable4 ], [ null       , typeof(int?) ])); 
        AreEqual("200" , accessor.Get([ 5, nullable4 ], [ null       , null         ])); accessor.Set([ 5, nullable4 ], "200*", [ null, null ]);
        AreEqual("200*", accessor.Get([ 5, nullable4 ], [ null       , null         ])); 
        AreEqual("240" , accessor.Get([ 6, nullable4 ], [ null                      ])); accessor.Set([ 6, nullable4 ], "240*", [ null ]);
        AreEqual("240*", accessor.Get([ 6, nullable4 ], [ null                      ])); 
        AreEqual("280" , accessor.Get([ 7, nullable4 ], [                           ])); accessor.Set([ 7, nullable4 ], "280*", [ ]);
        AreEqual("280*", accessor.Get([ 7, nullable4 ], [                           ])); 
        
        // With null int
        int? nullNum = null;
        AreEqual("" ,                   accessor.Get([  8, nullNum ],     [ typeof(int), typeof(int?) ])); accessor.Set([ 8, nullNum ], "*", [ typeof(int), typeof(int?) ]);
        AreEqual("*",                   accessor.Get([  8, nullNum ],     [ typeof(int), typeof(int?) ])); 
        AreEqual("" ,                   accessor.Get([  9, nullNum ],     [ null       , typeof(int?) ])); accessor.Set([ 9, nullNum ], "*", [ null, typeof(int?) ]);
        AreEqual("*",                   accessor.Get([  9, nullNum ],     [ null       , typeof(int?) ])); 
        // (Ambiguities: exceptions)
        ThrowsExceptionContaining(() => accessor.Get([ 10, nullNum ],     [ null       , null         ]), "No indexer found"); 
        ThrowsExceptionContaining(() => accessor.Set([ 10, nullNum ], "", [ null       , null         ]), "No indexer found"); 
        ThrowsExceptionContaining(() => accessor.Get([ 11, nullNum ],     [ null                      ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 11, nullNum ], "", [ null                      ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 12, nullNum ],     [                           ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 12, nullNum ], "", [                           ]), "No indexer found");

        // With string
        // (No ambiguity from values: arg type spec optional)
        AreEqual("110test" , accessor.Get([ 11, "test" ], [ typeof(int), typeof(string) ])); accessor.Set([ 11, "test" ], "110test*", [ typeof(int), typeof(string) ]);
        AreEqual("110test*", accessor.Get([ 11, "test" ], [ typeof(int), typeof(string) ])); 
        AreEqual("120test" , accessor.Get([ 12, "test" ], [ null       , typeof(string) ])); accessor.Set([ 12, "test" ], "120test*", [ null, typeof(string) ]);
        AreEqual("120test*", accessor.Get([ 12, "test" ], [ null       , typeof(string) ])); 
        AreEqual("130test" , accessor.Get([ 13, "test" ], [ null       , null           ])); accessor.Set([ 13, "test" ], "130test*", [ null, null ]);
        AreEqual("130test*", accessor.Get([ 13, "test" ], [ null       , null           ])); 
        AreEqual("140test" , accessor.Get([ 14, "test" ], [ null                        ])); accessor.Set([ 14, "test" ], "140test*", [ null ]);
        AreEqual("140test*", accessor.Get([ 14, "test" ], [ null                        ])); 
        AreEqual("150test" , accessor.Get([ 15, "test" ], [                             ])); accessor.Set([ 15, "test" ], "150test*", [ ]);
        AreEqual("150test*", accessor.Get([ 15, "test" ], [                             ])); 

        // With nullable string
        // (No ambiguity from values: arg type spec optional)
        // ReSharper disable once VariableCanBeNotNullable
        string? nullableText = "test";
        AreEqual("160test" , accessor.Get([ 16, nullableText ], [ typeof(int), typeof(string) ])); accessor.Set([ 16, nullableText ], "160test*", [ typeof(int), typeof(string) ]);
        AreEqual("160test*", accessor.Get([ 16, nullableText ], [ typeof(int), typeof(string) ])); 
        AreEqual("170test" , accessor.Get([ 17, nullableText ], [ null       , typeof(string) ])); accessor.Set([ 17, nullableText ], "170test*", [ null, typeof(string) ]);
        AreEqual("170test*", accessor.Get([ 17, nullableText ], [ null       , typeof(string) ])); 
        AreEqual("180test" , accessor.Get([ 18, nullableText ], [ null       , null           ])); accessor.Set([ 18, nullableText ], "180test*", [ null, null ]);
        AreEqual("180test*", accessor.Get([ 18, nullableText ], [ null       , null           ])); 
        AreEqual("190test" , accessor.Get([ 19, nullableText ], [ null                        ])); accessor.Set([ 19, nullableText ], "190test*", [ null ]);
        AreEqual("190test*", accessor.Get([ 19, nullableText ], [ null                        ])); 
        AreEqual("200test" , accessor.Get([ 20, nullableText ], [                             ])); accessor.Set([ 20, nullableText ], "200test*", [ ]);
        AreEqual("200test*", accessor.Get([ 20, nullableText ], [                             ])); 
        
        // With null string
        string? nullText = null;
        AreEqual("210" ,                accessor.Get([ 21, nullText ],     [ typeof(int), typeof(string) ])); accessor.Set([ 21, nullText ], "210*", [ typeof(int), typeof(string) ]);
        AreEqual("210*",                accessor.Get([ 21, nullText ],     [ typeof(int), typeof(string) ])); 
        AreEqual("220" ,                accessor.Get([ 22, nullText ],     [ null       , typeof(string) ])); accessor.Set([ 22, nullText ], "220*", [ null, typeof(string) ]);
        AreEqual("220*",                accessor.Get([ 22, nullText ],     [ null       , typeof(string) ])); 
        // (Ambiguities: exceptions)
        ThrowsExceptionContaining(() => accessor.Get([ 23, nullText ],     [ null       , null            ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 23, nullText ], "", [ null       , null            ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 24, nullText ],     [ null                         ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 24, nullText ], "", [ null                         ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Get([ 25, nullText ],     [                              ]), "No indexer found");
        ThrowsExceptionContaining(() => accessor.Set([ 25, nullText ], "", [                              ]), "No indexer found");
    }

    [TestMethod]
    public void AccessorCore_Indexer_Overload_NotResolved_Exception()
    {
        var obj = new MyClass_WithOverloads();
        var accessor = new AccessorCore(obj);

        // Too many argTypes
        ThrowsException(() => accessor.Get([ 2, 3 ],     [ null, null, null ]), "More argTypes than args.");
        ThrowsException(() => accessor.Set([ 2, 3 ], "", [ null, null, null ]), "More argTypes than args.");
        
        // TODO: Really expected an exception.
        //Type nonNullType = typeof(int);
        //ThrowsException(
        //    () => (string)accessor.Get([ 2, nullNum ], [ typeof(int), nonNullType ]),
        //    "No indexer found with argument types [Int32, Int32].");
        //ThrowsException(
        //    () => (string)accessor.Set([ 2, nullNum ], "", [ typeof(int), nonNullType ]),
        //    "No indexer found with argument types [Int32, Int32].");
    }

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
        private Dictionary<object, int> _invertedDigitDic = CreateInvertedDigitDic();

        private int this[int i]
        {
            get => _invertedDigitDic[i];
            set => _invertedDigitDic[i] = value;
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
                    return val;
                }
                else
                {
                    return $"{10 * arg1 * arg2}";
                }
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
                    return val;
                }
                else
                {
                    return $"{10 * arg1}{arg2}";
                }
            }
            set => _numNullyTextDic[(arg1, arg2)] = value;
        }
    }

    // Helpers

    
    static Dictionary<object, int> CreateInvertedDigitDic() => new()
        { [-1] = -1, [0] = 10, [1] = 9, [2] = 8, [3] = 7, [4] = 6, [5] = 5, [6] = 4, [7] = 3, [8] = 2, [9] = 1 };
}