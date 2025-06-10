namespace System.Runtime.CompilerServices;

#if NETSTANDARD2_0
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    public string ParameterName { get; } = parameterName;
}
#endif

// Stub is needed to compile code for .NET Standard 2.1,
// while all its supported frameworks already define it. (Even .NET 5 who officially does not.)
// So a paradox: It can't be tested, but you can't compile .NET Standard 2.1 without it.
#if NETSTANDARD2_1

// ncrunch: no coverage start
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    public string ParameterName { get; } = parameterName;
}
// ncrunch: no coverage end

#endif