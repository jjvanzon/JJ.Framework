namespace System.Runtime.CompilerServices;

#if NETSTANDARD2_0
public sealed class NotNullWhenAttribute(bool returnValue) : Attribute
{
    public bool ReturnValue { get; } = returnValue;
}
#endif
