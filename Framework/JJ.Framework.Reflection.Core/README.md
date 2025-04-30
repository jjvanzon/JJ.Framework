JJ.Framework.Reflection.Core
============================

Work with __Expressions__ and __Reflection__: two flexible techniques for inspecting code structure at run-time.


AccessorCore
------------

Allows easy access to the `internal`, `private` or `protected` elements of `assemblies` or `classes` and other constructs.

-----

For instance, this invokes a `private` method:

```cs
_accessor.InvokeMethod("MyPrivateMethod", 10);
```

`MyPrivateMethod` has one parameter, there set to `10`.

-----

This other option makes the same call:

```cs
public int MyPrivateMethod(int myParameter) =>
    (int)_accessor.InvokeMethod(myParameter);
```

`InvokeMethod` understands from context that you mean to call `MyPrivateMethod` there.

-----

Yet another option is this:

```cs
public int MyPrivateMethod(int myParameter) =>
    _accessor.InvokeMethod(() => MyPrivateMethod(myParameter));
```

There the method to call, its parameters, values, and return type are inferred from the __lambda__ expression:

```cs
() => MyPrivateMethod(myParameter)
```

The `Accessor` can use the info from that expression to make the call.

### Supported Constructs

`AccessorCore` supports:

- `Fields`
- `Properties`
- `Methods`
- `Indexers`
- `ref` and `out`

Here's an example for a property:

```cs
public int MyProperty => _accessor.GetPropertyValue(() => MyProperty);
```

I personally like that syntax most but there are other syntaxes available:

```cs
public int MyProperty => _accessor.GetPropertyValue<int>();
public int MyProperty => (int)_accessor.GetPropertyValue();
public int MyProperty => _accessor.GetPropertyValue<int>("MyProperty");
```

### Specifying the Instance, Statics or Type Name

Specifying what object to access, is done through the constructor of `AccessorCore`.

If you pass an `object` to it, that's usually enough:

```cs
var accessor = new AccessorCore(myObject);
```

If you want to access static members, you'd have to pass it the `Type` instead:

```cs
var accessor = new AccessorCore(typeof(MyStaticClass));
```

But to access the `base` class members of an object, you pass it both `Type` and `object`:

```cs
var accessor = new AccessorCore(myObject, typeof(TheBaseClass));
```

So if you want to access both *concrete* and *base* members, you need 2 `AccessorCore` instances:

```cs
var concreteAccessor = new AccessorCore(myObject);
var baseAccessor = new AccessorCore(myObject, typeof(TheBaseClass));
```

Lastly, for `internal` classes, you might not be able to say `typeof(TheBaseClass)`. This is because `TheBaseClass` might not be in scope. Then you'd need to specify the type name instead:

```cs
var accessor = new AccessorCore("MyNamespace.MyPrivateClass, MyAssembly");
```

### Accessor Wrappers

Programming your own wrapper accesors might be a good idea. Then you make access to the internals even easier with syntax as follows:

```cs
var accessor = new MyAccessor(new MyClass());
int myInt = accessor.MyPrivateMethod(1);
```

You'd need to program that accessor class though, based on `AccessorCore`:

```cs
class MyAccessor(MyClass myObject)
{
    AccessorCore _accessor = new(myObject);
    
    public int MyPrivateMethod(int myParameter) 
        => (int)_accessor.InvokeMethod(myParameter);
}    
```

### Tricky Cases

It can get tricky when the same method name is used for multiple overloads, that differ by parameter types. Usually it works out, but when passing `null` or `object` it can get confused. You can help `AccessorCore` out by explicitly specifying parameter types:

You can also pass the parameter values and types as separate collections:

```cs
public int MyPrivateMethod(int? myParameter) =>
    (int)_accessor.InvokeMethod( [ myParameter ], [ typeof(int?) ] );
```

You can use `null` for parameter types that don't cause ambiguity:

```cs
public int MyPrivateMethod2(int? myParameter1, int myParameter2) =>
    (int)_accessor.InvokeMethod( [ myParameter1, myParameter2 ], [ null, typeof(int) ] );
```

You can also use type arguments:

```cs
public string MyPrivateMethod2(object parameter, object parameter2) =>
    (string)_accessor.InvokeMethod<int, int?>("MyPrivateMethod2", parameter, parameter2);
```

Unfortunately the type argument syntax clashes a little, where it is unclear whether a type argument is used for the return type or for the parameter types. Also all of a sudden, the member name is required.

As you can see, syntax gets more convoluted in more specific cases. Eventually `AccessorCore` might not help you much more than `System.Reflection` already could. Then you still have the options to use `PrivateObject` and `PrivateType` from a test framework you might use, or the ultimate fallback to `System.Reflection` itself.

`AccessorCore` is there to have short syntax for cases that resolve easily, without having to break your head over complicated `Reflection` code while you have other things on your mind.


💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)