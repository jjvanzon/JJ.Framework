#if NETSTANDARD2_0 || NETSTANDARD2_1

namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class UnconditionalSuppressMessageAttribute(string category, string checkId) : Attribute
{
    public string Category { get; } = category;
    public string CheckId { get; } = checkId;
    public string? Scope { get; set; }
    public string? Target { get; set; }
    public string? MessageId { get; set; }
    public string? Justification { get; set; }
}

#endif