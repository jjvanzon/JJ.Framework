JJ.Framework.Reflection
=======================

Work with __Expressions__ and __Reflection__: two flexible techniques for inspecting code structure at run-time.

Turn lambdas into text:

```cs
"myParam.MyList[i].MyProperty"
```

Extract structured method call data:

```cs
{ "MyMethod", Parameters = { "myParameter", int, 3 } }
```

Find types and implementations for plug-ins. Access private members with `Accessors`. Use `ReflectionCache` for fast access to properties, fields, methods and indexers. Includes helpers like `IsIndexer`, `IsStatic` and more!

- [ExpressionHelper](#expressionhelper)
- [Accessor](#accessor)
    - [Constructs](#constructs)
    - [Instance, Statics, Types](#instance-statics-types)
    - [Wrappers](#wrappers)
    - [Tricky Cases](#tricky-cases)
- [ReflectionCache](#reflectioncache)
- [Reflection Helpers](#reflection-helpers)


ExpressionHelper
----------------

Converts many types of lambda expressions into text or retrieves its resulting value. Here are some of the things it can do:

For instance:

```cs
ExpressionHelper.GetText(() => myParam.MyProperty.MyList[i].MySomething)
```

Will return the string:

```cs
"myParam.MyProperty.MyList[i].MySomething"
```

Similarly you can retrieve its value:

```cs
ExpressionHelper.GetValue(() => myParam.MyProperty.MyList[i].MySomething)
```

which can return:

```cs
3
```

It can also give you method info, parameter names and parameter value info from lambda expressions.

For instance:

```cs
ExpressionHelper.GetMethodCallInfo(() => MyMethod(3));
```

Will return:

```cs
MethodCallInfo
{
    Name = "MyMethod",
    Parameters = 
    {
        ParameterType = typeof(int),
        Name = "myParameter",
        Value = 3
    }
};
```

Accessor
--------

Allows easy access to the `internal`, `private` or `protected` elements of `assemblies` or `classes` and other constructs.

Let's take this example `class` with one `private` method:

```cs
class MyClass
{
    private int MyPrivateMethod(int myParameter) => 3;
}
```

You can invoke that `private` method like this:

```cs
_accessor.InvokeMethod("MyPrivateMethod", 10);
```

This is another option to make the same call:

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

### Constructs

`Accessor` supports the following constructs:

- `Fields`
- `Properties`
- `Methods`
- `Indexers[]`
- `<Type>` arguments
- `ref` and `out` for up to 3 parameters

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

### Instance, Statics, Types

Specifying what object to access, is done through the constructor of `Accessor`.

Passing an `object` to it is usually enough:

```cs
var accessor = new Accessor(myObject);
```

If you want to access `static` members, you'd have to pass it a `Type` instead:

```cs
var accessor = new Accessor(typeof(MyStaticClass));
```

But to access the `base` class members of an object, you pass it both `Type` and `object`:

```cs
var accessor = new Accessor(myObject, typeof(TheBaseClass));
```

So if you want to access both *concrete* and *base* members, you need 2 `Accessor` instances:

```cs
var concreteAccessor = new Accessor(myObject);
var baseAccessor = new Accessor(myObject, typeof(TheBaseClass));
```

Lastly, for `internal` classes, you might not be able to pass `typeof(TheBaseClass)`. This is because `TheBaseClass` might not be in scope. Then you'd need to specify the type name instead:

```cs
var accessor = new Accessor("MyNamespace.MyPrivateClass, MyAssembly");
```

### Wrappers

Programming your own wrapper accesors might be a good idea. Then you make access to the internals even easier with syntax as follows:

```cs
var accessor = new MyAccessor(new MyClass());
string myString = accessor.MyPrivateMethod(10);
```

You'd need to program that accessor class though, based on `Accessor`:

```cs
class MyAccessor(MyClass myObject)
{
    Accessor _accessor = new(myObject);
    
    public string MyPrivateMethod(int para) 
        => (string)_accessor.InvokeMethod(para);
}
```

### Tricky Cases

It can get tricky when the same method name is used for multiple overloads, that differ by parameter types. Usually it works out, but `Accessor` can get confused when passed `null`, `object` or the parameter is a base type that differs from the specific type you pass as an argument. In these cases, it can help `Accessor` to explicitly specify the parameter types:

```cs
public string MyPrivateMethod(int para) =>
    (string)_accessor.InvokeMethod( [ para ], [ typeof(int) ] );
```

You can use `null` for parameter types that didn't cause the ambiguity:

```cs
public string MyPrivateMethod2(int para1, int? para2) =>
    (string)_accessor.InvokeMethod( [ para1, para2 ], [ null, typeof(int?) ] );
```

As you can see, syntax gets more convoluted in more specific cases. Eventually `Accessor` might not help you much more than `System.Reflection` already could. Then you still have the options to use `PrivateObject` and `PrivateType` from a test framework you might use, or the ultimate fallback to `System.Reflection` itself.

`Accessor` is there to have short syntax for cases that resolve easily, without having to break your head over complicated `Reflection` code while having other things on your mind.


ReflectionCache
---------------

Makes using reflection much faster in certain cases. For instance the `GetProperties` method can be expensive, which is much faster through the `ReflectionCache` class.

Example:

```cs
private static readonly ReflectionCache _reflectionCache 
    = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

PropertyInfo[] properties = _reflectionCache.GetProperties(typeof(MyClass));
```

You can also get other types of constructs in a fast way:

* `Methods`
* `Indexers`
* `Fields`
* `Constructor`
* `GetTypeByShortName`


Reflection Helpers
------------------

Various helper methods, but one of the most useful features is the `GetImplementation` method and variations thereof, which allow you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.

* `GetImplementations`
    * Allows you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.
* `GetBaseClasses`
    * Returns a type's base type and its base type, etc.
* `GetItemType`
    * Gets the item type of a collection type.
* `IsIndexer`
    * Can tell you if a `MethodBase` points to an indexer property.
* `IsStatic`
    * Can tell you if a `MemberInfo` is static.
* `IsProperty`
    * Can tell you if a `MethodBase` is a property.
* `IsNullableType`
    * Can tell you if a `Type` is a nullable type.
* `IsReferenceType`
    * Can tell you if a `Type` is a reference type.
* `IsSimpleType`
    * Tells you if a `Type` is a 'simple type'. A simple type can be a .NET primitive types: `Boolean`, `Char`, `Byte`, `IntPtr`, `UIntPtr`, the numeric types, their signed and unsigned variations, but also `String`, `Guid`, `DateTime`, `TimeSpan` and `Enum` types.
* `IsDefault`
    * Can tell you if a value is the default value for its type. (E.g. 0 is the default value for Int32.)
* `TypesFromObjects`
    * You can pass objects to it, and it will return the concrete types of those objects, with some tolerance for nulls.
* `GetPropertyOrException`
    * `Type.GetProperty` returns null if the property does not exist. This method is a little safer than that and throws a clear exception if the property does not exist.
* `GetValue`
    * Similar to `PropertyInfo.GetValue`, but for static properties you can now omit the object parameter. 
* `GetUnderlyingNullableTypeFast`
    * Slightly faster than `Nullable.GetUnderlyingType`.
* `IsAssignableFrom` / `IsAssignableTo`
    * Similar to the original `Type.IsAssignableFrom`, but now also an `IsAssignableTo` variation, if you find that more intuitive. Also has variations with a type argument e.g. `myInterfaceType.IsAssignableFrom`<`MyClass`>`();`
* `CreateInstance`
    * A variation on the existing `Type.CreateInstance`, that takes a type name as a `string`, instead of a `Type`.

💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)