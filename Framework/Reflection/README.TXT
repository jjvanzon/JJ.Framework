JJ.Framework.Reflection contains extensions to the System.Reflection and System.Linq.Expressions namespaces.

Highlights:

- The ExpressionHelper class, which can convert many types of lambda expressions into text or retrieve its resulting value. It can also give you method, parameter names and parameter value info from lambda expressions.
- The Accessor class, allowing easy access to the internal, private or protected elements of an assembly or class.
- The ReflectionCache class, which makes using reflection much faster in certain cases. For instance the GetProperties method can be expensive, which is much faster through the ReflectionCache class.
- The ReflectionHelper class has various helper methods, but one of the most useful features is the GetImplementation methods, which allow you to retrieve an implementation of a certain base class or interface from an assembly, which is useful for plug-in development.
