// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnuzedType.Local
// ReSharper disable UnusedType.Global

#if !NET9_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Runtime.CompilerServices;

/// <inheritdoc cref="_overloadresolutionpriority" />
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Property, Inherited = false)]
internal class OverloadResolutionPriorityAttribute(int priority) : Attribute
{
    public int Priority { get; } = priority;
}

#endif
