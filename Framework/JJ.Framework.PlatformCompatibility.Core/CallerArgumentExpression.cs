namespace System.Runtime.CompilerServices;

#pragma warning disable CS9113 // Parameter is unread.

#if NETSTANDARD2_0 || NETSTANDARD2_1
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute;
#endif