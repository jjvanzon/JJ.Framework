#if NETFRAMEWORK || NETSTANDARD2_0

namespace System.Runtime.CompilerServices;

internal class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    public string ParameterName { get; } = parameterName;
}

#endif

// Stub is needed to compile code for .NET Standard 2.1,
// while all its supported frameworks already define it. (Even .NET 5 who officially does not.)
// So a paradox: It can't be tested, but you can't compile .NET Standard 2.1 without it.
#if NETSTANDARD2_1

namespace System.Runtime.CompilerServices;

// ncrunch: no coverage start
internal class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    public string ParameterName { get; } = parameterName;
}
// ncrunch: no coverage end

#endif