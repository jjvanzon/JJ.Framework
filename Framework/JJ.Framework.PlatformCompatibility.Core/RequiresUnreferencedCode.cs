// ncrunch: no coverage start

// ReSharper disable UnusedAutoPropertyAccessor.Global

#if !NET5_0_OR_GREATER

namespace System.Diagnostics.CodeAnalysis;

internal class RequiresUnreferencedCodeAttribute(string message) : Attribute
{
    public string Message { get; } = message;
    public string? Url { get; set; }
}

#endif

// ncrunch: no coverage end