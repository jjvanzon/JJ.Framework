namespace System.Runtime.CompilerServices;

#if !NET9_0_OR_GREATER
internal class OverloadResolutionPriorityAttribute(int priority) : Attribute
{
    public int Priority { get; } = priority;
}
#endif
