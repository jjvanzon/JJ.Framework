// ReSharper disable UnusedAutoPropertyAccessor.Global

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_requiresunreferencedcode" />
internal class RequiresUnreferencedCodeAttribute(string message) : Attribute
{
    /// <inheritdoc cref="_requiresunreferencedcode" />
    public string Message { get; } = message;
    /// <inheritdoc cref="_requiresunreferencedcode" />
    public string? Url { get; set; }
}

#endif
