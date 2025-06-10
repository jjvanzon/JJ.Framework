namespace System.Runtime.CompilerServices;

#if !NET9_0_OR_GREATER
public class OverloadResolutionPriorityAttribute(int priority) : Attribute
{
    public int Priority { get; } = priority;
}
#endif
