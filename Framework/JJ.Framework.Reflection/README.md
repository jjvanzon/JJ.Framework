JJ.Framework.Reflection
=======================

Extensions to the `System.Reflection` and `System.Linq.Expressions` namespaces.

- [ExpressionHelper](#expressionhelper)
- [Accessor](#accessor)
- [ReflectionCache](#reflectioncache)
- [Reflection Extensions and Helpers](#reflection-extensions-and-helpers)


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

__Limitations__

There are limitations to this `Accessor` class.

Perhaps for these cases it might be a solution to use `System.Reflection` directly or `PrivateObject` and `PrivateType` from a test framework. Those may have slightly more complex syntax, but may offer a diversion where this `Accessor` class cannot not help you.


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

In this version, some of the options may only be available in the `StaticReflectionCache` variant. That variant may perform slightly less fast.

Reflection Extensions and Helpers
---------------------------------

Various helper methods, but one of the most useful features is the `GetImplementation` method and variations thereof, which allow you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.

* `GetImplementations`
    * Allows you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.

-----

* `GetItemType`
    * Gets the item type of a collection type.

-----

* `IsIndexer`
    * Can tell you if a `MethodBase` points to an indexer property.

-----

* `IsStatic`
    * Can tell you if a `MemberInfo` is static.

-----

* `TypesFromObjects`
    * You can pass objects to it, and it will return the concrete types of those objects, with some tolerance for nulls.

-----

* `IsAssignableFrom` / `IsAssignableTo`
    * Similar to the original `Type.IsAssignableFrom`, but now also an `IsAssignableTo` variation, if you find that more intuitive.

-----

* `GetFieldOrException`
    * `Type.GetField` returns null if the field does not exist. This method is a little safer than that and throws a clear exception if the field does not exist.
