### EADME

You can omit the method name:

```cs
_accessor.InvokeMethod(myParameter)
```

`[ Reformulate ]`  
But then the name of the method is assumed to be the name of the method you called it from:


You can pass it the `object`, the `Type` or both. Specifically, to access static members you'd have to pass it the `Type`. 

### Accessor type arguments now map to type arguments, not return values

```cs
/// <inheritdoc cref="_invokemethod" />
public object InvokeMethod<T>([CallerMemberName] string callerMemberName = null) 
    => (T)base.InvokeMethod(callerMemberName);
/// <inheritdoc cref="_invokemethod" />
public T InvokeMethod<T>(object param1, [CallerMemberName] string callerMemberName = null) 
    => (T)base.InvokeMethod(callerMemberName, param1);
/// <inheritdoc cref="_invokemethod" />
public T InvokeMethod<T>(object param1, object param2, [CallerMemberName] string callerMemberName = null) 
    => (T)base.InvokeMethod(callerMemberName, param1, param2);
/ <inheritdoc cref="_invokemethod" />
public T InvokeMethod<T>(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) 
    => (T)base.InvokeMethod(callerMemberName, param1, param2, param3);
```

```cs
class OverloadAccessor2 : TestAccessorBase
{
    public string MyPrivateMethod2(int para1, int? para2) =>
        _accessor.InvokeMethod<string>(para1, para2);
}

class OverloadAccessor5 : TestAccessorBase
{
    public string MyPrivateMethod2(object para, object para2) =>
        (string)_accessor.InvokeMethod<int, int?>("MyPrivateMethod2", para, para2);
}

[TestMethod]
public void AccessorCore_OverloadedMethod2()
{
    var accessor = new OverloadAccessor2();
    AreEqual("150", () => accessor.MyPrivateMethod2(3, 5));
}

[TestMethod]
public void AccessorCore_OverloadedMethod5()
{
    var accessor = new OverloadAccessor5();
    AreEqual("770", () => accessor.MyPrivateMethod2(7, 11));
}
```

### README

You can also use type arguments:

```cs
public string MyPrivateMethod2(object para, object para2) =>
    (string)_accessor.InvokeMethod<int, int?>("MyPrivateMethod2", para, para2);
```

Unfortunately the type argument syntax clashes a little, where it is unclear whether a type argument is used for the return type or for the parameter types. And also, all of a sudden, the member name is required.


### Moving CallerMemberName variants from AccessorCore to AccessorLegacy

```cs
        
        /// <inheritdoc cref="_invokemethod" />
        public new object GetPropertyValue([CallerMemberName] string callerMemberName = null) 
            => base.GetPropertyValue(callerMemberName);
        /// <inheritdoc cref="_invokemethod" />
        public T GetPropertyValue<T>([CallerMemberName] string callerMemberName = null) 
            => (T)base.GetPropertyValue(callerMemberName);
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod([CallerMemberName] string callerMemberName = null) 
            => base.InvokeMethod(callerMemberName);
        ///// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, [CallerMemberName] string callerMemberName = null) 
            => base.InvokeMethod(callerMemberName, param1);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, [CallerMemberName] string callerMemberName = null)
            => base.InvokeMethod(callerMemberName, param1, param2);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) 
            => base.InvokeMethod(callerMemberName, param1, param2, param3);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object[] parameters, [CallerMemberName] string callerMemberName = null) 
            => base.InvokeMethod(callerMemberName, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object[] parameters, Type[] parameterTypes, [CallerMemberName] string callerMemberName = null) 
            => base.InvokeMethod(callerMemberName, parameters, parameterTypes);
```

### Redefined base members no longer needed

```cs

        // Redefined all base members
        
        // (To prevent overloads in derived class from shadowing better matches in the base class.)

        /// <inheritdoc cref="_nameexpression" />
        public new T GetFieldValue<T>(Expression<Func<T>> nameExpression) 
            => base.GetFieldValue(nameExpression);
        
        public new object GetFieldValue(string name)
            => base.GetFieldValue(name);
        
        /// <inheritdoc cref="_nameexpression" />
        public new void SetFieldValue<T>(Expression<Func<T>> nameExpression, T value)
            => base.SetFieldValue(nameExpression, value);
        
        public new void SetFieldValue(string name, object value) 
            => base.SetFieldValue(name, value);
        
        /// <inheritdoc cref="_nameexpression" />
        public new T GetPropertyValue<T>(Expression<Func<T>> nameExpression) 
            => base.GetPropertyValue(nameExpression);
        
        public new void SetPropertyValue(string name, object value) 
            => base.SetPropertyValue(name, value);

        /// <inheritdoc cref="_invokemethod" />
        public new void InvokeMethod(Expression<Action> callExpression) 
            => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="_invokemethod" />
        public new T InvokeMethod<T>(Expression<Func<T>> callExpression)
            => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(LambdaExpression callExpression) 
            => base.InvokeMethod(callExpression);

        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(string name, params object[] parameters) 
            => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(string name, object[] parameters, Type[] parameterTypes) 
            => base.InvokeMethod(name, parameters, parameterTypes);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1, TArg2>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1, TArg2, TArg3>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1, TArg2, TArg3, TArg4>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters) 
            => base.InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
            => base.InvokeMethod(name, parameters, parameterTypes, typeArguments);

        public new object GetIndexerValue(params object[] parameters) 
            => base.GetIndexerValue(parameters);
        public new void SetIndexerValue(params object[] parametersAndValue) 
            => base.SetIndexerValue(parametersAndValue);
```

### New AccessorCore


```cs
            PropertyInfo? property = _reflectionCache.TryGetProperty(_type, name);
            if (property != null) return property.GetValue(_object, null);
```

```cs

    private object CallCore(string name, object[] parameters)
        => GetMethod(name, parameters).Invoke(_object, parameters);
    
    private object CallCore(string name, object[] parameters, Type[] parameterTypes)
        => GetMethod(name, parameters, parameterTypes).Invoke(_object, parameters);

    
    private MethodInfo GetMethod(string name, object[] parameters)
        => GetMethod(name, parameters, [], [], []);

    private MethodInfo GetMethod(string name, object[] parameters, Type[] parameterTypes)
        => GetMethod(name, parameters, parameterTypes, [], []);

    private MethodInfo GetMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
        => GetMethod(name, parameters, parameterTypes, typeArguments, []);
    
    private MethodInfo GetMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments, StackFrame[] stackFrames)
    {
        parameterTypes = ComplementParameterTypes(parameterTypes, parameters, stackFrames);
        
        foreach (Type type in _types)
        {
            var method = _reflectionCache.TryGetMethod(type, name, parameterTypes, typeArguments);
            if (method != null) return method;
        }
        
        throw new Exception($"Method '{name}' not found.");
    }

        // Try resolve parameterless
        if (parameters.Count == 0)
        {
            foreach (Type type in _types)
            {
                MethodInfo? method = _reflectionCache.TryGetMethod(type, name, [], typeArguments.ToArray());
                if (method != null) return method;
            }
        }

        // Try resolve from parameter types and values.
        if (parameterTypes.Count > 0)
        {
        }

        if (parameterTypes == null) throw new ArgumentNullException(nameof(parameters));
        if (parameters == null) throw new ArgumentNullException(nameof(parameters));

```

### AccessorCoreTests_Examples

```cs
        protected AccessorCore _accessor = new(new MyClass());
    
    [TestMethod]
    public void AccessorLegacy_Construction_WithObjectAndType()
    {
        var myObject = new MyClass();
        var accessor = new AccessorCore(myObject, typeof(TheBaseClass));
    }
    
    [TestMethod]
    public void AccessorLegacy_Construction_BaseAndDerived()
    { 
        var myObject = new MyClass();
        var concreteAccessor = new AccessorCore(myObject);
        var baseAccessor = new AccessorCore(myObject, typeof(TheBaseClass));
    }

        var accessor = new AccessorCore($"{MyNamespace}.{MyPrivateClass}, {MyAssembly}");
    string MyNamespace => GetType().Namespace; 
    string MyAssembly => GetType().Assembly.GetName().Name;

```


### AccessorCore

```cs
    /// <inheritdoc cref="_invokemethod" />
    public object? Call(object? param1 = null, object? param2 = null, object? param3 = null, object? param4 = null, object? param5 = null, object? param6 = null, object? param7 = null, object? param8 = null, object? param9 = null, object? param10 = null, [Caller] string name = "")
        => CallCore(name, [ param1, param2, param3, param4, param5, param6, param7, param8, param9, param10 ]);

    public void Set    (object? value,   [Caller] string  name = "") => SetCore(name, value);
    #if NET9_0_OR_GREATER
    [OverloadResolutionPriority(1)] 
    #end if
    public void Set    (string  name ,            object? value    ) => SetCore(name, value);

    
    ///// <inheritdoc cref="_invokemethod" />
    //[OverloadPriority(1)] 
    //public object? Call(string name, params object?[] args)
    //    => CallCore(name, args);

```

### AccessorCore Indexers

```cs
    // TODO: Now getting it from StackFrame inspection is not done yet.
    ICollection<Type> complementedIndexTypes = ComplementArgTypes(indexes, indexTypes);
    
    foreach (Type type in _typesInHierarchy)
    {
        var property = _reflectionCacheLegacy.TryGetIndexer(type, complementedIndexTypes.ToArray());
        if (property != null) return property.GetValue(Obj, indexes.ToArray());
    }
    
    throw new Exception($"Indexer not found with index types: [{Join(", ", indexTypes.Select(x => $"{x}"))}].");

    // TODO: Now getting it from StackFrame inspection is not done yet.
    ICollection<Type> complementedIndexTypes = ComplementArgTypes(indexes, indexTypes);
    
    foreach (Type type in _typesInHierarchy)
    {
        var property = _reflectionCacheLegacy.TryGetIndexer(type, complementedIndexTypes.ToArray());
        if (property != null) { property.SetValue(Obj, value, indexes.ToArray()); return; }
    }
    
    throw new Exception($"Indexer not found with index types: [{Join(", ", indexTypes.Select(x => $"{x}"))}].");
```

### AccessorCore Indexer Tests

```cs
    public AccessorCoreTests_Indexers() => _accessor = new AccessorCore(this);

    private readonly AccessorCore _accessor;
    private Dictionary<int, int> _numberDic = CreateNumberDic();
    private string _text = "11";
    
    public int this[int index] 
    { 
        get => _numberDic[index]; 
        set => _numberDic[index] = value; 
    }
    
    public string this[string key]
    {
        get => _text; 
        set => _text = value;
    }
```

### AccessorCore Ref Args

```cs
    MethodInfo method = _reflectionCacheLegacy.GetMethod(_objectType, name, [ typeof(TArg1).MakeByRefType() ]);
    MethodInfo method = ResolveMethod(name, args, [ typeof(TArg1).MakeByRefType() ], [ ]);
    Type[] argTypes = [ typeof(TArg).MakeByRefType() ];
    MethodInfo method = ResolveMethod(name, args, argTypes, [ ]);
    
    private class MyAccessorWithLambda(MyClass obj) : AccessorCore(obj)
    {
        public bool MyMethod(ref int num)
            => Call(() => MyMethod(ref num));
    }
```

### AccessorCore Ref Args Tests (Duplicate Case)

```cs
    
    public TimeSpan MyMethod(ref Guid arg1, out byte arg2, ref int arg3, out long arg4)
    {
        arg2 = default;
        arg4 = default;
        return (TimeSpan)Call(ref arg1, ref arg2, ref arg3, ref arg4)!;
    }
        
    private TimeSpan MyMethod(ref Guid arg1, out byte arg2, ref int arg3, out long arg4)
    {
        AreEqual(ToGuid(126), arg1, nameof(arg1));
        arg1 = ToGuid(127);
        arg2 = 128;
        AreEqual(129, arg3, nameof(arg3));
        arg3 = 130;
        arg4 = 131; 
        return FromSeconds(132);
    }
```

### AccessorByName that couldn't delegate.

```cs
    private class MyAccessorByName : MyAccessor
    {
        // 1 Parameter
        
        public new bool MyMethod(out int arg) => base.MyMethod(out arg);

        // 2 Parameters (+ explicit names)
        
        public new long     MyMethod(ref float  arg1, double       arg2) => base.MyMethod(ref arg1, arg2);
        public new DateTime MyMethod(TimeSpan   arg1, out string   arg2) => base.MyMethod(arg1,     out arg2);
        public     Guid     MyMethod(ref string arg1, out TimeSpan arg2) => base.MyMethod(ref arg1, out arg2);

        // 3 Parameters (+ inline out parameters)
        
        public new DateTime MyMethod(ref double arg1, float        arg2, long         arg3) => base.MyMethod(ref arg1, arg2,     arg3);
        public new int      MyMethod(bool       arg1, out int      arg2, long         arg3) => base.MyMethod(arg1,     out arg2, arg3);
        public new float    MyMethod(ref double arg1, out DateTime arg2, TimeSpan     arg3) => base.MyMethod(ref arg1, out arg2, arg3);
        public new string   MyMethod(Guid       arg1, string       arg2, ref TimeSpan arg3) => base.MyMethod(arg1,     arg2,     ref arg3);
        public new DateTime MyMethod(out double arg1, float        arg2, ref long     arg3) => base.MyMethod(out arg1, arg2,     ref arg3);
        public new int      MyMethod(bool       arg1, out int      arg2, ref long     arg3) => base.MyMethod(arg1,     out arg2, ref arg3);
        public new float    MyMethod(out double arg1, ref DateTime arg2, out TimeSpan arg3) => base.MyMethod(out arg1, ref arg2, out arg3);

        // 4 Parameters

        public new byte     MyMethod(ref int      arg1, long         arg2, float        arg3, double       arg4) => base.MyMethod(ref arg1, arg2,     arg3,     arg4);
        public new decimal  MyMethod(bool         arg1, out string   arg2, DateTime     arg3, TimeSpan     arg4) => base.MyMethod(arg1,     out arg2, arg3,     arg4);
        public new Guid     MyMethod(ref byte     arg1, out int      arg2, long         arg3, float        arg4) => base.MyMethod(ref arg1, out arg2, arg3,     arg4);
        public new double   MyMethod(decimal      arg1, bool         arg2, ref string   arg3, DateTime     arg4) => base.MyMethod(arg1,     arg2,     ref arg3, arg4);
        public new TimeSpan MyMethod(out Guid     arg1, byte         arg2, ref int      arg3, long         arg4) => base.MyMethod(out arg1, arg2,     ref arg3, arg4);
        public new float    MyMethod(double       arg1, out decimal  arg2, ref bool     arg3, string       arg4) => base.MyMethod(arg1,     out arg2, ref arg3, arg4);
        public new DateTime MyMethod(out TimeSpan arg1, ref Guid     arg2, out byte     arg3, int          arg4) => base.MyMethod(out arg1, ref arg2, out arg3, arg4);
        public new long     MyMethod(float        arg1, double       arg2, decimal      arg3, ref bool     arg4) => base.MyMethod(arg1,     arg2,     arg3,     ref arg4);
        public new string   MyMethod(out DateTime arg1, TimeSpan     arg2, Guid         arg3, ref byte     arg4) => base.MyMethod(out arg1, arg2,     arg3,     ref arg4);
        public new int      MyMethod(long         arg1, out float    arg2, double       arg3, ref decimal  arg4) => base.MyMethod(arg1,     out arg2, arg3,     ref arg4);
        public new bool     MyMethod(out string   arg1, ref DateTime arg2, TimeSpan     arg3, out Guid     arg4) => base.MyMethod(out arg1, ref arg2, arg3,     out arg4);
        public new byte     MyMethod(int          arg1, long         arg2, ref float    arg3, out double   arg4) => base.MyMethod(arg1,     arg2,     ref arg3, out arg4);
        public new decimal  MyMethod(ref bool     arg1, string       arg2, out DateTime arg3, ref TimeSpan arg4) => base.MyMethod(ref arg1, arg2,     out arg3, ref arg4);
        public new Guid     MyMethod(byte         arg1, out int      arg2, ref long     arg3, out float    arg4) => base.MyMethod(arg1,     out arg2, ref arg3, out arg4);
        public new double   MyMethod(ref decimal  arg1, out bool     arg2, ref string   arg3, out DateTime arg4) => base.MyMethod(ref arg1, out arg2, ref arg3, out arg4);
    }
```

### AccessorCore

```cs
    //.ToArray()
    //.Take(indices.Count) // TODO: Might remove. Exact matches might be better.

    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)] 
    public object? Call(string arg1, [Caller] string name = "")
        => CallCore(name, [ arg1 ]);

    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, string arg2, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2 ]);

    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, string arg3, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3 ]);

    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, string arg4, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, string arg5, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, string arg6, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, string arg7, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7 ]);
    
    // <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, string arg8, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, string arg9, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 ]);
    
    /// <inheritdoc cref="_invokemethod" />
    [Priority(2)]
    public object? Call(object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9, string arg10, [Caller] string name = "")
        => CallCore(name, [ arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 ]);

```


### AccessorCore Tests

```cs
        // By CallerMemberName + Type Arg
        {
            var accessor = new Accessor_WithCallerMemberName_AndTypeArg(obj);

            accessor.MyProperty1 = 10;
            AreEqual(10, () => accessor.MyProperty1);

            accessor.MyProperty2 = "Hello";
            AreEqual("Hello", () => accessor.MyProperty2);

            accessor._myField1 = true;
            IsTrue(() => accessor._myField1);

            accessor._myField2 = 20.5;
            AreEqual(20.5, () => accessor._myField2);
        }

        // By CallerMemberName + Cast
        {
            var accessor = new Accessor_WithCallerMemberName_AndCast(obj);

            accessor.MyProperty1 = 10;
            AreEqual(10, () => accessor.MyProperty1);

            accessor.MyProperty2 = "Hello";
            AreEqual("Hello", () => accessor.MyProperty2);

            accessor._myField1 = true;
            IsTrue(() => accessor._myField1);

            accessor._myField2 = 20.5;
            AreEqual(20.5, () => accessor._myField2);
        }

        // TODO: With explicit name
        {
            var accessor = new Accessor_WithExplicitName_AndCast(obj);
            
            accessor.MyProperty1 = 10;
            AreEqual(10, () => accessor.MyProperty1);
            
            accessor.MyProperty2 = "Hello";
            AreEqual("Hello", () => accessor.MyProperty2);
            
            accessor._myField1 = true;
            IsTrue(() => accessor._myField1);
            
            accessor._myField2 = 20.5;
            AreEqual(20.5, () => accessor._myField2);
        }

        // With null int
        {
            int? nullNum = null;
            ThrowsException(
                () => (string)accessor.Get([ 2, nullNum ])!,
                "No indexer found with argument types [Int32, Object].");
        }
```

### PlatformCompatibility CallerArgumentExpressionAttribute:

```cs
#if NETSTANDARD2_0 || NETSTANDARD2_1
#if !NET5_0_OR_GREATER
#if NET5_0 || NETSTANDARD2_0 || NETSTANDARD2_1
#if NET5_0 || NETSTANDARD2_0
#if !NET5_0_OR_GREATER || NETSTANDARD2_0
```

### AccessorCore

```cs
    public object? Get(params object?[] indices) => Get((ICollection<object?>)indices);
    public object? Get(ICollection<object?> indices)
```

### AccessorCore Indexer Tests

```cs
#pragma warning disable CS8604 // null ref arg
#pragma warning restore CS8604 // null ref arg

// TODO: Overloads that vary by int/double for clearer disambiguation needs not only by nullables?

private double this[double i]
{
    get => _numberDic[i] + .5;
    set => _numberDic[i] = (int)(value - 0.5);
}

private string this[int para1, double para2] => $"{10 * para1 * para2}";

private string _dummy = "";

        accessor.Set([ 2, 3 ], "60*", [ typeof(int), typeof(int?) ]);
        AreEqual("60*", accessor.Get([ 2, 3 ], [ typeof(int), typeof(int?) ]));

```

### Reflect

```cs
// TODO: Would like to omit the type argument.
// TODO: Syntax like `Prop(MyProp)`

        //if (matchCaseFlag == MatchCaseFlag.matchCase)
        //if (matchCaseFlag == MatchCaseFlag.ignoreCase)

        if (bindingFlags == default) bindingFlags = BindingFlagsAll;

    public Reflector(BindingFlags bindingFlags, bool matchCase         ) => Initialize(bindingFlags, matchCase);
    private void Initialize(BindingFlags bindingFlags, bool? matchCase)

    private static MatchCaseFlag GetMatchCaseFlag(bool matchCase) => matchCase ? MatchCaseFlag.matchCase : default;
    private static bool GetMatchCase() => false;
    private static bool GetMatchCase(bool matchcase) => matchcase;
    private static bool GetMatchCase(MatchCaseFlag matchcase) => matchcase == MatchCaseFlag.matchcase;

        // TODO: Too much logic. Some flags should be fixed upon construction.
        if (HasFlag(flags, ReflectFlags.matchcase))
        {
            if (!string.Equals(prop?.Name, name, Ordinal))
            {
                prop = null;
            }
        }
 
    private bool ShouldThrow(NoThrowFlag flags)
    {
        if (HasFlag(flags, none)) return true;
        if (HasFlag(flags, nothrow)) return false;
        return true;
    }

    private bool HasFlag(NoThrowFlag flags, NoThrowFlag flag) => (flags & flag) != 0;

    //none = 0,
    //none = 0,

    private PropertyInfo? PropOrNull(string shortTypeName, string name)
    {
        var type = TypeOrNull(shortTypeName);
        if (type == null) return null;
        return PropOrNull(type, name);
    }

    private PropertyInfo? PropOrSomething(string shortTypeName, string name, bool nullable)
    {
        var type = TypeOrSomething(shortTypeName, nullable);
        if (type == null) return null;
        return PropOrSomething(type, name, nullable);
    }
```

### Reflect Tests

```cs
            private static readonly Reflector _reflector = new();

        new Reflector(MatchCaseFlag.none), // TODO: either support `ignoreCase: true` syntax or call it maybe 'none' to discourage use and express default.
        new Reflector(BindingFlagsAll, MatchCaseFlag.none),

            Assert(reflector.Prop<MyClass>("MyProp", NoThrowFlag.none));
            Assert(reflector.Prop<MyClass>(NoThrowFlag.none, "MyProp"));
            Assert(reflector.Prop(typeof(MyClass), NoThrowFlag.none, "MyProp"));
            Assert(reflector.Prop(typeof(MyClass), "MyProp", NoThrowFlag.none));

            ThrowsException(() => reflector.Prop<MyClass>("NoProp", NoThrowFlag.none));
            ThrowsException(() => reflector.Prop<MyClass>(NoThrowFlag.none, "NoProp"));
            ThrowsException(() => reflector.Prop(typeof(MyClass), NoThrowFlag.none, "NoProp"));
            ThrowsException(() => reflector.Prop(typeof(MyClass), "NoProp", NoThrowFlag.none));

            Assert(reflector.Prop<MyClass>("myprop", NoThrowFlag.none));
            Assert(reflector.Prop<MyClass>(NoThrowFlag.none, "myprop"));
            Assert(reflector.Prop(typeof(MyClass), NoThrowFlag.none, "myprop"));
            Assert(reflector.Prop(typeof(MyClass), "myprop", NoThrowFlag.none));

            ThrowsNotFound(() => reflector.Prop<MyClass>("myprop", NoThrowFlag.none));
            ThrowsNotFound(() => reflector.Prop<MyClass>(NoThrowFlag.none, "myprop"));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), NoThrowFlag.none, "myprop"));
            ThrowsNotFound(() => reflector.Prop(typeof(MyClass), "myprop", NoThrowFlag.none));
        
    [TestMethod]
    public void Reflector_Prop_Invariant_UnderNullable_IgnoresCase()
    {
        foreach (var reflector in _reflectors)
        {
            Assert(reflector.Prop<MyClass>(        "myprop"                 ));
            Assert(reflector.Prop(typeof(MyClass), "myprop"                 ));
            Assert(reflector.Prop<MyClass>(        "myprop", nullable       ));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nullable       ));
            Assert(reflector.Prop<MyClass>(        "myprop", nullable: true ));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nullable: true ));
            Assert(reflector.Prop<MyClass>(        "myprop", nullable: false));
            Assert(reflector.Prop(typeof(MyClass), "myprop", nullable: false));
        }
    }

```