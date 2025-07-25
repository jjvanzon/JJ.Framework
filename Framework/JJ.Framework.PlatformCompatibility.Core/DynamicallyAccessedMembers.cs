// ncrunch: no coverage start

// ReSharper disable UnusedAutoPropertyAccessor.Global

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_dynamicallyaccessedmembers" />
internal class DynamicallyAccessedMembersAttribute : Attribute
{
    /// <inheritdoc cref="_dynamicallyaccessedmembers" />
    public DynamicallyAccessedMembersAttribute(DynamicallyAccessedMemberTypes memberTypes)
    {
        MemberTypes = memberTypes;
    }

    /// <inheritdoc cref="_dynamicallyaccessedmembers" />
    public DynamicallyAccessedMemberTypes MemberTypes { get; }
}

#endif

// ncrunch: no coverage end