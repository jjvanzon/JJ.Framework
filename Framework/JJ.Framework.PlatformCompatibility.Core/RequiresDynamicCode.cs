// ReSharper disable UnusedType.Global

// ncrunch: no coverage start
//#if NETSTANDARD2_0 || NETSTANDARD2_1 || NETFRAMEWORK || NET5_0 || NET6_0
#if !NET7_0_OR_GREATER

namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class, Inherited = false)]
internal sealed class RequiresDynamicCodeAttribute(string message) : Attribute
{
    public string Message { get; } = message;
    public string? Url { get; set; }
}

#endif
// ncrunch: no coverage end
