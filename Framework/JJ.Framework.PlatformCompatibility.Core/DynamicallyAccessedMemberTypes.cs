// ncrunch: no coverage start

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
[Flags]
internal enum DynamicallyAccessedMemberTypes
{
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    None = 0,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicParameterlessConstructor = 1,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicConstructors = 3,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicConstructors = 4,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicMethods = 8,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicMethods = 16,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicFields = 32,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicFields = 64,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicNestedTypes = 128,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicNestedTypes = 256,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicProperties = 512,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicProperties = 1024,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicEvents = 2048,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicEvents = 4096,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    Interfaces = 8192,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    All = -1
}

#endif

// ncrunch: no coverage end