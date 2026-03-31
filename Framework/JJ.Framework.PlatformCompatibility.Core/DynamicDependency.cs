// ReSharper disable UnusedType.Global

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_dynamicdependency" />
[AttributeUsage(
    AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method,
    AllowMultiple = true, Inherited = false)]
internal sealed class DynamicDependencyAttribute : Attribute
{
    /// <inheritdoc cref="_dynamicdependency" />
    public DynamicDependencyAttribute(string memberSignature) => MemberSignature = memberSignature;

    /// <inheritdoc cref="_dynamicdependency" />
    public DynamicDependencyAttribute(string memberSignature, Type type)
    {
        MemberSignature = memberSignature;
        Type = type;
    }

    /// <inheritdoc cref="_dynamicdependency" />
    public DynamicDependencyAttribute(string memberSignature, string typeName, string assemblyName)
    {
        MemberSignature = memberSignature;
        TypeName = typeName;
        AssemblyName = assemblyName;
    }

    /// <inheritdoc cref="_dynamicdependency" />
    public DynamicDependencyAttribute(DynamicallyAccessedMemberTypes memberTypes, Type type)
    {
        MemberTypes = memberTypes;
        Type = type;
    }

    /// <inheritdoc cref="_dynamicdependency" />
    public DynamicDependencyAttribute(DynamicallyAccessedMemberTypes memberTypes, string typeName, string assemblyName)
    {
        MemberTypes = memberTypes;
        TypeName = typeName;
        AssemblyName = assemblyName;
    }

    public string? MemberSignature { get; }
    public DynamicallyAccessedMemberTypes MemberTypes { get; }
    public Type? Type { get; }
    public string? TypeName { get; }
    public string? AssemblyName { get; }
}

#endif
