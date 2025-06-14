//namespace System.Runtime.CompilerServices;
namespace System.Diagnostics.CodeAnalysis;

#if NETFRAMEWORK || NETSTANDARD2_0
[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class NotNullWhenAttribute(bool returnValue) : Attribute
{
    public bool ReturnValue { get; } = returnValue;
}
#endif
