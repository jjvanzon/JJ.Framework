namespace System.Runtime.CompilerServices;

#if !NET9_0_OR_GREATER
public class OverloadResolutionPriorityAttribute : Attribute
{
    public OverloadResolutionPriorityAttribute() { }
    public OverloadResolutionPriorityAttribute(int priority) { }
}
#endif
