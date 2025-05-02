
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