//namespace System.Runtime.CompilerServices;
namespace System.Diagnostics.CodeAnalysis;

#if NETSTANDARD2_0
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class NotNullWhenAttribute(bool returnValue) : Attribute
{
    public bool ReturnValue { get; } = returnValue;
}
#endif
