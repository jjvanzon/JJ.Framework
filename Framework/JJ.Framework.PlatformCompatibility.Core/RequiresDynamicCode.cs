#if NETSTANDARD2_0 || NETSTANDARD2_1

using static System.AttributeTargets;

namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Method | Constructor | Class, Inherited = false)]
internal sealed class RequiresDynamicCodeAttribute(string message) : Attribute
{
    public string Message { get; } = message;
    public string? Url { get; set; }
}

#endif