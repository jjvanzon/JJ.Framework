// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

// Stub is also needed to compile code for .NET Standard 2.1,
// while all its supported frameworks already define it. (Even .NET 5 who officially does not.)
// So a paradox: It can't be tested, but you can't compile .NET Standard 2.1 without it.

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Runtime.CompilerServices;

/// <inheritdoc cref="_callerargumentexpression" />
internal class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    public string ParameterName { get; } = parameterName;
}

#endif
