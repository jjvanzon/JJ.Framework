// ReSharper disable UnusedAutoPropertyAccessor.Global

// ncrunch: no coverage start
#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_requiresunreferencedcode" />
internal class RequiresUnreferencedCodeAttribute(string message) : Attribute
{
    public string Message { get; } = message;
    public string? Url { get; set; }
}

#endif
// ncrunch: no coverage end