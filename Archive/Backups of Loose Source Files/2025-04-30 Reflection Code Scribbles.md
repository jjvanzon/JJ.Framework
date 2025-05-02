
You can omit the method name:

```cs
_accessor.InvokeMethod(myParameter)
```

`[ Reformulate ]`  
But then the name of the method is assumed to be the name of the method you called it from:


You can pass it the `object`, the `Type` or both. Specifically, to access static members you'd have to pass it the `Type`. 

Accessor type arguments now map to type arguments, not return values:

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

You can also use type arguments:

```cs
public string MyPrivateMethod2(object para, object para2) =>
    (string)_accessor.InvokeMethod<int, int?>("MyPrivateMethod2", para, para2);
```

Unfortunately the type argument syntax clashes a little, where it is unclear whether a type argument is used for the return type or for the parameter types. And also, all of a sudden, the member name is required.
