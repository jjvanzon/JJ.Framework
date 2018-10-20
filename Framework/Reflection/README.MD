# JJ.Framework.Reflection

Extensions to the `System.Reflection` and `System.Linq.Expressions` namespaces.

## ExpressionHelper

Converts many types of lambda expressions into text or retrieves its resulting value. Here are some of the things it can do:

For instance:

	ExpressionHelper.GetText(() => myParam.MyProperty.MyList[i].MySomething)

Will return the string:

	"myParam.MyProperty.MyList[i].MySomething"

Similarly you can retrieve its value:

	ExpressionHelper.GetValue(() => myParam.MyProperty.MyList[i].MySomething)

which can return:

	3

It can also give you method info, parameter names and parameter value info from lambda expressions.

For instance:

	ExpressionHelper.GetMethodCallInfo(() => MyMethod(3));

Will return:

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

## Accessor

Allows easy access to the internal, private or protected elements of an assembly or class.

For instance if you have the following private method in a class:

    class MyClass
    {
        private int MyPrivateMethod(int myParameter)
        {
            return 3;
        }
    }

You can run that private method, that would otherwise not be available:

    var myObject = new MyClass();
    var accessor = new MyAccessor(myObject);
    int myInt = accessor.MyPrivateMethod(1);

You can do that by writing the following wrapper class:

    class MyAccessor
    {
        Accessor _accessor;

        public MyAccessor(MyClass myObject) => _accessor = new Accessor(myObject);

        public int MyPrivateMethod(int myParameter) 
			=> _accessor.InvokeMethod(() => MyPrivateMethod(default), myParameter);
    }

## ReflectionCache

Makes using reflection much faster in certain cases. For instance the `GetProperties` method can be expensive, which is much faster through the `ReflectionCache` class.

Example:

	private static readonly ReflectionCache _reflectionCache 
		= new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

	PropertyInfo[] properties = _reflectionCache.GetProperties(typeof(MyClass));

You can also get other types of constructs in a fast way:

* `GetFields`
* `GetConstructor`
* `GetTypeByShortName`

## ReflectionExtensions

Various helper methods, but one of the most useful features is the `GetImplementation` method and variations thereof, which allow you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.

* `GetBaseClasses`
	* Returns a type's base type and its base type, etc.
* `GetItemType`
	* Gets the item type of a collection type.
* `GetImplementations`
	* Allows you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.
* `GetPropertyOrException`
	* `Type.GetProperty` returns null if the property does not exist. This method is a little safer than that and throws a clear exception if the property does not exist.
* `GetUnderlyingNullableTypeFast`
	* Slightly faster than `Nullable.GetUnderlyingType`.
* `GetValue`
	* Similar to `PropertyInfo.GetValue`, but for static properties you can now omit the object parameter. 
* `IsAssignableFrom` / `IsAssignableTo`
	* Similar to the original `Type.IsAssignableFrom`, but now also an `IsAssignableTo` variation, if you find that more intuitive. Also has variations with a type argument e.g. `myInterfaceType.IsAssignableFrom`<`MyClass`>`();`
* `IsIndexer`
	* Can tell you if a `MethodBase` points to an indexer property.
* `IsNullableType`
	* Can tell you if a `Type` is a nullable type.
* `IsProperty`
	* Can tell you if a `MethodBase` is a property.
* `IsReferenceType`
	* Can tell you if a `Type` is a reference type.
* `IsStatic`
	* Can tell you if a `MemberInfo` is static.
* `IsSimpleType`
	* Tells you if a `Type` is a 'simple type'. A simple type can be a .NET primitive types: `Boolean`, `Char`, `Byte`, `IntPtr`, `UIntPtr`, the numeric types, their signed and unsigned variations, but also `String`, `Guid`, `DateTime`, `TimeSpan` and `Enum` types.

## ReflectionHelper

* `CreateInstance`
	* A variation on the existing `Type.CreateInstance`, that takes a type name as a `string`, instead of a `Type`.
* `IsDefault`
	* Can tell you if a value is the default value for its type. (E.g. 0 is the default value for Int32.)
* `IsSimpleType`
	* Tells you if a value is of a 'simple type'. A simple type can be a .NET primitive types: `Boolean`, `Char`, `Byte`, `IntPtr`, `UIntPtr`, the numeric types, their signed and unsigned variations, but also `String`, `Guid`, `DateTime`, `TimeSpan` and `Enum` types.
* `TypesFromObjects`
	* You can pass objects to it, and it will return the concrete types of those objects, with some tolerance for nulls.
