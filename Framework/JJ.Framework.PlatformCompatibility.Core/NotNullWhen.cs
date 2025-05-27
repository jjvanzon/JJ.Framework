//namespace System.Runtime.CompilerServices;
namespace System.Diagnostics.CodeAnalysis;

#if NETSTANDARD2_0
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class NotNullWhenAttribute(bool returnValue) : Attribute
{
    public bool ReturnValue { get; } = returnValue;
}
#endif
