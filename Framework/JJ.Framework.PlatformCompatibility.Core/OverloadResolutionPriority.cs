// ReSharper disable CheckNamespace
// ReSharper disable UnusedParameter.Local

#if !NET9_0_OR_GREATER
namespace System.Runtime.CompilerServices;
public class OverloadResolutionPriorityAttribute : Attribute
{
    public OverloadResolutionPriorityAttribute() { }
    public OverloadResolutionPriorityAttribute(int priority) { }
}
#endif
