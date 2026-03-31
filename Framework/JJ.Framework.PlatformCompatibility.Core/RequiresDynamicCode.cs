// ReSharper disable UnusedType.Global

#if !NET7_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_requiresdynamiccode" />
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class, Inherited = false)]
internal sealed class RequiresDynamicCodeAttribute(string message) : Attribute
{
    public string Message { get; } = message;
    public string? Url { get; set; }
}

#endif
