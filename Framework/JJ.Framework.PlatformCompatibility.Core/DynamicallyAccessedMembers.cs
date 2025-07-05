// ncrunch: no coverage start

// ReSharper disable UnusedAutoPropertyAccessor.Global

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

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