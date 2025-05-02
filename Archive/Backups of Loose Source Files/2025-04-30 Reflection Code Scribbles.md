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


```cs
            PropertyInfo? property = _reflectionCache.TryGetProperty(_type, name);
            if (property != null) return property.GetValue(_object, null);
```

```

    //private object CallCore(string name, object[] parameters)
    //    => GetMethod(name, parameters).Invoke(_object, parameters);
    
    //private object CallCore(string name, object[] parameters, Type[] parameterTypes)
    //    => GetMethod(name, parameters, parameterTypes).Invoke(_object, parameters);

    
    //private MethodInfo GetMethod(string name, object[] parameters)
    //    => GetMethod(name, parameters, [], [], []);

    //private MethodInfo GetMethod(string name, object[] parameters, Type[] parameterTypes)
    //    => GetMethod(name, parameters, parameterTypes, [], []);

    //private MethodInfo GetMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
    //    => GetMethod(name, parameters, parameterTypes, typeArguments, []);
    
    //private MethodInfo GetMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments, StackFrame[] stackFrames)
    //{
    //    parameterTypes = ComplementParameterTypes(parameterTypes, parameters, stackFrames);
        
    //    foreach (Type type in _types)
    //    {
    //        var method = _reflectionCache.TryGetMethod(type, name, parameterTypes, typeArguments);
    //        if (method != null) return method;
    //    }
        
    //    throw new Exception($"Method '{name}' not found.");
    //}

```