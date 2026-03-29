// ReSharper disable UnusedType.Global

// ncrunch: no coverage start
#if NETFRAMEWORK || NETSTANDARD2_0

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_notnullwhen" />
[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class NotNullWhenAttribute(bool returnValue) : Attribute
{
    public bool ReturnValue { get; } = returnValue;
}

#endif
// ncrunch: no coverage end
