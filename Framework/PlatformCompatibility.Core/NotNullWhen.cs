// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#if NETFRAMEWORK || NETSTANDARD2_0

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_notnullwhen" />
[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class NotNullWhenAttribute : Attribute
{
    /// <inheritdoc cref="_notnullwhen" />
    public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

    public bool ReturnValue { get; }
}

#endif
