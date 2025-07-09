// ncrunch: no coverage start

// ReSharper disable UnusedAutoPropertyAccessor.Global

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

namespace System.Diagnostics.CodeAnalysis;

internal class RequiresUnreferencedCodeAttribute(string message) : Attribute
{
    public string Message { get; } = message;
    public string? Url { get; set; }
}

#endif

// ncrunch: no coverage end