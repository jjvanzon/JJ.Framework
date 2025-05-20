namespace System.Runtime.CompilerServices;

#if NETSTANDARD2_0 || NETSTANDARD2_1
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute;
#endif