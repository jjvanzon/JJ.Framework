// ncrunch: no coverage start

// ReSharper disable UnusedAutoPropertyAccessor.Global

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

namespace System.Diagnostics.CodeAnalysis;

internal class RequiresUnreferencedCodeAttribute : Attribute
{
    public RequiresUnreferencedCodeAttribute(string message)
    {
        Message = message;
    }

    public string Message { get; }
    public string? Url { get; set; }
}

#endif

// ncrunch: no coverage end