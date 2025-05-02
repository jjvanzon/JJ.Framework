JJ.Framework.Reflection.Core
============================

Work with __Expressions__ and __Reflection__: two flexible techniques for inspecting code structure at run-time.


AccessorCore
------------

Allows easy access to the `internal`, `private` or `protected` elements of `assemblies` or `classes` and other constructs.

For instance, this invokes a `private` method:

```cs
_accessor.InvokeMethod("MyPrivateMethod", 10);
```

`MyPrivateMethod` has one parameter, there set to `10`.

This other option makes the same call:

```cs
public string MyPrivateMethod(int para) =>
    (string)_accessor.InvokeMethod(para);
```

`InvokeMethod` understands from context that you mean to call `MyPrivateMethod` there. It also infers parameter types from the calling context to disambiguate overloads.

Yet another option is this:

```cs
public string MyPrivateMethod(int para) =>
    _accessor.InvokeMethod(() => MyPrivateMethod(para));
```

There the method to call, its parameters, values, and return type are inferred from the __lambda__ expression:

```cs
() => MyPrivateMethod(para)
```

The `Accessor` can use the info from the expression to make the call.

### Supported Constructs

`AccessorCore` supports:

- `Fields`
- `Properties`
- `Methods`
- `Indexers[]`
- `<Type>` arguments
- `ref` and `out` parameters

Here's an example for a property:

```cs
public string MyProperty => _accessor.GetPropertyValue(() => MyProperty);
```

I personally like that syntax most, but there are other syntaxes available:

```cs
public string MyProperty => _accessor.GetPropertyValue<string>();
public string MyProperty => (string)_accessor.GetPropertyValue();
public string MyProperty => _accessor.GetPropertyValue<string>("MyProperty");
```

### Specifying the Instance, Statics or Type Name

Specifying what object to access, is done through the constructor of `AccessorCore`.

If you pass an `object` to it, that's usually enough:

```cs
var accessor = new AccessorCore(myObject);
```

If you want to access `static` members, you'd have to pass it the `Type` instead:

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
string myString = accessor.MyPrivateMethod(10);
```

You'd need to program that accessor class though, based on `AccessorCore`:

```cs
class MyAccessor(MyClass myObject)
{
    AccessorCore _accessor = new(myObject);
    
    public string MyPrivateMethod(int para) 
        => (string)_accessor.InvokeMethod(para);
}
```

### Tricky Cases

It can get tricky when the same method name is used for multiple overloads, that differ by parameter types. Usually it works out, but `AccessorCore` can get confused when passed `null`, `object` or the parameter is a base type that differs from the specific type you pass as an argument. In these cases, it can help `AccessorCore` to explicitly specify the parameter types:

```cs
public string MyPrivateMethod(int para) =>
    (string)_accessor.InvokeMethod( [ para ], [ typeof(int) ] );
```

You can use `null` for parameter types that didn't cause the ambiguity:

```cs
public string MyPrivateMethod2(int para1, int? para2) =>
    (string)_accessor.InvokeMethod( [ para1, para2 ], [ null, typeof(int?) ] );
```

As you can see, syntax gets more convoluted in more specific cases. Eventually `AccessorCore` might not help you much more than `System.Reflection` already could. Then you still have the options to use `PrivateObject` and `PrivateType` from a test framework you might use, or the ultimate fallback to `System.Reflection` itself.

`AccessorCore` is there to have short syntax for cases that resolve easily, without having to break your head over complicated `Reflection` code while having other things on your mind.


💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)