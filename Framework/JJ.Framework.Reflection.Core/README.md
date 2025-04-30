JJ.Framework.Reflection.Core
============================

Work with __Expressions__ and __Reflection__: two flexible techniques for inspecting code structure at run-time.


AccessorCore
------------

`[ TODO: Verify example code. ]`


Allows easy access to the `internal`, `private` or `protected` elements of an `assembly` or `class` or other constructs.

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
    _accessor.InvokeMethod(myParameter);
```

`[ TODO: Cast the return value? ]`

`InvokeMethod` understands from context that you mean to call `MyPrivateMethod` there.

-----

Yet another option is this:

```cs
public int MyPrivateMethod(int myParameter) =>
    _accessor.InvokeMethod(() => MyPrivateMethod(myParameter));
```

There the method to call, its parameters, values, and return type are inferred from the __lambda__ expression `() => MyPrivateMethod(myParameter)`. `Accessors` can use the info from that expression to make the call.

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

I like that syntax most but there are other syntaxes available:

```cs
public int MyProperty => _accessor.GetPropertyValue<int>();
public int MyProperty => (int)_accessor.GetPropertyValue();
public int MyProperty => _accessor.GetPropertyValue<int>("MyProperty");
```

### Instance and Static Types and by Name

Specifying the `object` and `Type` the accessor should act upon.

`[ TODO ]`

### Accessor Wrappers

`[ TODO ]`

### Tricky Cases

It can get tricky when the same method name is used for multiple overloads, that differ by parameter types. Usually it works out, but when passing `null` or `object` it can get confused. You can help it out by specifying parameter types explicitly:

```cs
public int MyPrivateMethod(int? myParameter) =>
    _accessor.InvokeMethod<int?>(myParameter);
```

There you passed a type argument `<int?>` for that.

```cs
public int MyPrivateMethod(int? myParameter) =>
    _accessor.InvokeMethod( [ myParameter ], [ typeof(int?) ] );
```

There you  pass the parameter values and types as separate collections.

As you can see, syntax gets more convoluted in more specific cases. Eventually `AccessorCore` might noit help you much more than `System.Reflection` already could. Then you still have the options to use `PrivateObject` and `PrivateType` from a test framework you might use, or the ultimate fallback to `System.Reflection` itself.

`AccessorCore` is there to have short syntax for cases that just resolve easily, without having to break your head over complicated `Reflection` code while you have other things on your mind.

