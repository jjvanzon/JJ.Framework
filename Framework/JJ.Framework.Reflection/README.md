JJ.Framework.Reflection.Legacy
==============================

Extensions to the `System.Reflection` and `System.Linq.Expressions` namespaces. Work with expressions and reflection. Turn lambdas into text:

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
- [ReflectionCache](#reflectioncache)
- [Reflection Helpers](#reflection-helpers)


ExpressionHelper
----------------

Converts many types of lambda expressions into text or retrieves its resulting value. Here are some of the things it can do:

For instance:

```cs
GetText(() => myParam.MyProperty.MyList[i].MySomething)
```

Will return the string:

```cs
"myParam.MyProperty.MyList[i].MySomething"
```

Similarly you can retrieve its value:

```cs
GetValue(() => myParam.MyProperty.MyList[i].MySomething)
```

which can return:

```cs
3
```

It can also give you method info, parameter names and parameter value info from lambda expressions.

For instance:

```cs
GetMethodCallInfo(() => MyMethod(3));
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

Allows easy access to the internal, private or protected elements of an assembly or class.

For instance if you have the following private method in a class:

```cs
class MyClass
{
    private int MyPrivateMethod(int myParameter)
    {
        return 3;
    }
}
```

You can run that private method, that would otherwise not be available:

```cs
var myObject = new MyClass();
var accessor = new MyAccessor(myObject);
int myInt = accessor.MyPrivateMethod(1);
```

You can do that by writing the following wrapper class:

```cs
class MyAccessor
{
    Accessor _accessor;

    public MyAccessor(MyClass myObject) => _accessor = new Accessor(myObject);

    public int MyPrivateMethod(int myParameter) 
        => _accessor.InvokeMethod(() => MyPrivateMethod((myParameter));
}
```

*Limitations*  
`Accessor` may suffice for most use cases, but there are some casees where it might be an idea to use `System.Reflection` directly or `PrivateObject` and `PrivateType` from a test framework you might use. Those may have slightly more complex syntax, but may offer a diversion where this `Accessor` class might not be able to help you.


ReflectionCache
---------------

Makes using reflection much faster in certain cases. For instance the `GetProperties` method can be expensive, which is much faster through the `ReflectionCache` class.

Example:

```cs
private static readonly ReflectionCache _reflectionCache 
    = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

PropertyInfo[] properties 
    = _reflectionCache.GetProperties(typeof(MyClass));
```

You can also get other types of constructs in a fast way:

* `Methods`
* `Indexers`
* `Fields`
* `Constructor`
* `GetTypeByShortName`

In this version, some of the options may only be available in the `StaticReflectionCache` variant. That variant may perform slightly less fast.

Reflection Helpers
------------------

Various helper methods, but one of the most useful features is the `GetImplementation` method and variations thereof, which allow you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.

* `GetImplementations`
    * Allows you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.
* `GetItemType`
    * Gets the item type of a collection type.
* `IsIndexerMethod`
    * Can tell you if a `MethodInfo` points to an indexer property.
* `IsStatic`
    * Can tell you if a `MemberInfo` is static.
* `TypesFromObjects`
    * You can pass objects to it, and it will return the concrete types of those objects, with some tolerance for nulls.
* `IsAssignableFrom` / `IsAssignableTo`
    * Similar to the original `Type.IsAssignableFrom`, but now also an `IsAssignableTo` variation, if you find that more intuitive.

💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)