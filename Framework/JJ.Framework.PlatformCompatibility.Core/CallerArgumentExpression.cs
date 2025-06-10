#pragma warning disable CS9113 // Parameter is unread.

namespace System.Runtime.CompilerServices;

#if NETSTANDARD2_0
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute;
#endif

// Stub is needed to compile code for .NET Standard 2.1,
// while all its supported frameworks already define it. (Even .NET 5 who officially does not.)
// So a paradox: it can't be tested, but you can't compile .NET Standard 2.1 without.
#if NETSTANDARD2_1
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute; // ncrunch: no coverage
#endif