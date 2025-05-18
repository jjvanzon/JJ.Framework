namespace System.Runtime.CompilerServices;

#if NETSTANDARD2_0
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute;
#endif