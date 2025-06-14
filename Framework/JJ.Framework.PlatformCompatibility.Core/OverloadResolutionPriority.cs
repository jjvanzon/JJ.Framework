// ncrunch: no coverage start

#if !NET9_0_OR_GREATER

namespace System.Runtime.CompilerServices;

internal class OverloadResolutionPriorityAttribute(int priority) : Attribute
{
    public int Priority { get; } = priority;
}

#endif

// ncrunch: no coverage end
