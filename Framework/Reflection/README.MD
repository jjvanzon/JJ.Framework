# JJ.Framework.Reflection

Extensions to the System.Reflection and System.Linq.Expressions namespaces.

Highlights:

* `ExpressionHelper`: Converts many types of lambda expressions into text or retrieves its resulting value. It can also give you method info, parameter names and parameter value info from lambda expressions.
* `Accessor`: Allows easy access to the internal, private or protected elements of an assembly or class.
* `ReflectionCache`: Makes using reflection much faster in certain cases. For instance the GetProperties method can be expensive, which is much faster through the ReflectionCache class.
* `ReflectionExtensions`: Various helper methods, but one of the most useful features is the `GetImplementation` method and variations thereof, which allow you to retrieve implementations of a specified base class or interface from an assembly, which is useful for plug-in development.

For instance:

	ExpressionHelper.GetText(() => myParam.MyProperty.MyList[i].MySomething)

Will return :

	"myParam.MyProperty.MyList[i].MySomething"